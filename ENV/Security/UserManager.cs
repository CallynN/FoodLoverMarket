using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ENV.IO;
using ENV.Security.Entities;
using Firefly.Box;
using System.Xml;
using ENV.Security.UI;
using Firefly.Box.Data.DataProvider;
using SearchScope = System.DirectoryServices.Protocols.SearchScope;
using Form = Firefly.Box.UI.Form;

namespace ENV.Security
{
    public static class UserManager
    {
        public static bool CaseSensitive { get; set; }

        static DataSetDataProvider CreateDatasource()
        {
            var result = new DataSetDataProvider();
            result.DataSet.CaseSensitive = CaseSensitive;
            return result;
        }

        public static string UsersFile = "Security";

        static void Save(DataSetDataProvider ds)
        {
            Save(ds, UsersFile);
        }

        static void Save(DataSetDataProvider ds, string fileName)
        {
            try
            {
                using (FileStream sw = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    CryptoStream cs = new CryptoStream(sw, CreateCrypto().CreateEncryptor(), CryptoStreamMode.Write);
                    ds.DataSet.WriteXml(cs, System.Data.XmlWriteMode.WriteSchema);
                    cs.Close();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                ErrorLog.WriteToLogFile(ex);
                Common.ShowMessageBox("Access Denied", System.Windows.Forms.MessageBoxIcon.Error, "Save has failed because: " + ex.Message);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteToLogFile(ex);
                Common.ShowExceptionDialog(ex, true, "Save of security file failed");
            }
        }

        static AesCryptoServiceProvider CreateCrypto()
        {
            var x = new AesCryptoServiceProvider();
            var pdb = new Rfc2898DeriveBytes("FireflyRulls",
                new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            x.Key = pdb.GetBytes(32);
            x.IV = pdb.GetBytes(16);
            return x;
        }

        public static DataSetDataProvider Load()
        {
            UsersFile = PathDecoder.DecodePath(UsersFile);
            if (!File.Exists(UsersFile))
            {
                var y = System.Reflection.Assembly.GetEntryAssembly();
                if (y != null)
                {
                    var s = y.Location;
                    s = Path.GetDirectoryName(s);
                    UsersFile = Path.Combine(s, UsersFile);
                }
            }
            return Load(UsersFile);
        }

        public static DataSetDataProvider Load(string fileName)
        {
            var ds = CreateDatasource();
            if (!System.IO.File.Exists(fileName))
                return ds;
            using (FileStream sw = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                CryptoStream cs = new CryptoStream(sw, CreateCrypto().CreateDecryptor(), CryptoStreamMode.Read);
                ds.DataSet.ReadXml(cs);
                ds.DataSet.CaseSensitive = CaseSensitive;
                cs.Close();
            }
            return ds;

        }

        public static void ChangePassword()
        {
            Lock((db, s) => new Tasks.ChangePassword(db), false);
        }

        public static void ChangeBlankPassword(string user)
        {
            Lock((db, s) => new Tasks.ChangePassword(db, user), false);
        }

        public static void ManageUsers()
        {
            Lock((db, s) => new Tasks.ManageUsers(db, s), true);

        }

        public static void ManageGroups()
        {
            UserManager.Lock((db, s) => new Tasks.ManageGroups(db), true);
        }

        public static void ManageSecuredValues()
        {
            Lock((db, s) => new Tasks.SecuredValues(db), true);
        }

        public static string DefaultUser { set; get; }
        public static string DefaultPassword { set; get; }
        public static bool DisplayLoginDialog = true;

        public static bool ShowLoginDialog(bool mustShowLoginDialog)
        {
            return ShowLoginDialog(mustShowLoginDialog, null);
        }

        public static bool ShowLoginDialog(bool mustShowLoginDialog, Role loginRole)
        {
            if (!string.IsNullOrEmpty(DefaultUser) && !DisplayLoginDialog)
                if (Login(DefaultUser, DefaultPassword ?? "") && (loginRole == null || loginRole.Allowed))
                    return true;
            if (!mustShowLoginDialog && !DisplayLoginDialog)
                return true;

            return new Tasks.Login(loginRole).Run();

        }

        public static User CurrentUser
        {
            get { return _currentUser.Value; }
        }

        static ContextStatic<List<Action>> _currentUserChanged = new ContextStatic<List<Action>>();
        public static event Action CurrentUserChanged
        {
            add { _currentUserChanged.Value.Add(value); }
            remove { _currentUserChanged.Value.Remove(value); }
        }
        static Func<User> _getDefaultUser = () => new User("", "", "", "", "");
        static ContextStatic<User> _currentUser = new ContextStatic<User>(() => _getDefaultUser());

        public static Role.Administrator Administrator
        {
            get { return _administrator; }
            set { _administrator = value; }
        }

        static Role.Administrator _administrator;

        public static void UseWindowsUserInsteadOfInternalSecurity()
        {
            UseThisUser(System.Environment.UserName);
        }
        public static void UseThisUser(string userId)
        {
            _getDefaultUser = () => new User(userId, userId, "", "", "");
            SetCurrentUser(_getDefaultUser());

        }

        public static void SetCurrentUser(User user)
        {
            _currentUser.Value = user;
            ENV.UserSettings.ParseAndSet("User=*" + user.Name, false, false, false);
            _currentUserChanged.Value.ForEach(x => x());
        }

        public static bool Login(Text username, Text password)
        {
            User result = User.Find(username, password);
            if (result != null)
            {
                SetCurrentUser(result);
                return true;
            }
            return false;
        }

        internal static void LoadFromMagicDump(string fileName, UserStorage db)
        {
            XmlDocument doc = new XmlDocument();
            using (StreamReader sr = new StreamReader(fileName, ENV.LocalizationInfo.Current.OuterEncoding))
            {
                doc.Load(sr);
            }

            foreach (XmlNode o in doc.SelectNodes("*/Users/User"))
            {
                string s = o.SelectSingleNode("ID").InnerText;
                User u = db.FindUser(s);
                try
                {
                    var descNode = o.SelectSingleNode("NAME");
                    string desc = "";
                    if (descNode != null)
                        desc = descNode.InnerText;
                    string password = "";
                    var node = o.SelectSingleNode("PASSWORD");
                    if (node != null)
                        password = node.InnerText;
                    if (u == null)
                        u = db.CreateUser(s, password, desc, "");
                }
                catch
                {
                }

            }
            foreach (XmlNode o in doc.SelectNodes("*/UserRights/UserRight"))
            {
                string s = o.SelectSingleNode("ID").InnerText;
                User u = db.FindUser(s);
                try
                {
                    if (u == null)
                        u = db.CreateUser(s, "", "", "");
                }
                catch
                {
                }

                foreach (XmlNode node in o.SelectNodes("RIGHT"))
                {
                    u.AddRole(node.InnerText, db);
                }
            }
            foreach (XmlNode o in doc.SelectNodes("*/Groups/Group"))
            {
                string s = o.SelectSingleNode("NAME").InnerText;
                Text groupId = db.CreateGroupAndReturnID(s);

                foreach (XmlNode node in o.SelectNodes("RIGHT"))
                {
                    db.AddRole(groupId, node.InnerText);
                }
                if (s == "קבוצת אחראי" || s == "SUPERVISOR GROUP" || s == "SUPERVISOR GRUPPE")
                    db.AddRole(groupId, "UserMAnager");
            }
            foreach (XmlNode o in doc.SelectNodes("*/UserGroups/UserGroup"))
            {
                string s = o.SelectSingleNode("ID").InnerText;
                User u = db.FindUser(s);
                try
                {
                    if (u == null)
                        db.CreateUser(s, "", "", "");
                }
                catch
                {
                }

                foreach (XmlNode node in o.SelectNodes("GROUP"))
                {
                    u.AddGroup(node.InnerText, db);
                }
            }



        }



        static bool iAmLocking = false;
        static bool iAmReadOnly = false;
        internal abstract class SecurityUIController : UIControllerBase
        {
            bool _canceled = false;
            protected new  internal  Func<Form> View
            {
                set
                {

                    base.View = value;
                    if (From == null)
                        return;
                    Number _rows = 0;
                    _uiController.SavingRow += e => _rows += DeltaOf(() => 1);

                    _uiController.Start += () => _rows = ((ENV.Data.Entity)From).CountRows(_uiController.Where);
                    var x = _uiController.View.Text;
                    _uiController.View.BindText += (s, e) => e.Value = x + " - " + _rows.ToString();

                    Handlers.Add(GridForm.OkCommand).Invokes += e =>
                    {
                        e.Handled = true;
                        Exit();
                    };

                    Handlers.Add(GridForm.CancelCommand).Invokes += e =>
                    {
                        e.Handled = true;
                        _canceled = true;
                        Exit();
                    };

                    AllowSelectOrderBy = false;
                }
            }

            public bool RunAndReturnTrueToSaveChanges()
            {
                Execute();
                return !_canceled;
            }
            public void MakeReadOnly()
            {
                Activity = Activities.Browse;
                AllowUpdate = false;
                AllowInsert = false;
                AllowDelete = false;
            }
        }
        internal static void Lock(Func<IEntityDataProvider, UserStorage, SecurityUIController> createSecurityUI, bool allowReadOnly)
        {


            Action readonlyRun = () => ChangeUserFile((db) =>
            {
                var x = db.CreateSecurityUIUsing(createSecurityUI);
                x.MakeReadOnly();
                return x.RunAndReturnTrueToSaveChanges();

            });

            if (iAmLocking)
            {
                if (iAmReadOnly)
                    readonlyRun();
                else
                    ChangeUserFile(db => db.CreateSecurityUIUsing(createSecurityUI).RunAndReturnTrueToSaveChanges());
                return;
            }

            iAmLocking = true;
            try
            {

                var started = false;
                try
                {
                    UsersFile = PathDecoder.DecodePath(UsersFile);
                    using (new StreamWriter(UsersFile + ".lck", false))
                    {
                        started = true;
                        ChangeUserFile(db => db.CreateSecurityUIUsing(createSecurityUI).RunAndReturnTrueToSaveChanges());
                    }
                    System.IO.File.Delete(UsersFile + ".lck");
                }
                catch (Exception ex)
                {
                    ErrorLog.WriteToLogFile(ex, "Error attempting to lock {0}.lck", UsersFile);

                    if (!started)
                    {
                        if (allowReadOnly)
                        {
                            if (ENV.Common.ShowYesNoMessageBox(LocalizationInfo.Current.UserFileIsLocked,
                                                               LocalizationInfo.Current.UserFileIsLockedEnterReadOnly, false))
                            {
                                Load();
                                iAmReadOnly = true;
                                readonlyRun();
                            }
                        }
                        else
                            ENV.Common.ShowMessageBox(LocalizationInfo.Current.UserFileIsLocked,
                                                      System.Windows.Forms.MessageBoxIcon.Error,
                                                      LocalizationInfo.Current.UserFileIsLocked);
                    }
                    else
                        throw;
                }
            }
            finally
            {
                iAmLocking = false;
                iAmReadOnly = false;
            }
        }

        static bool _inProgress = false;
        static UserDirectory _externalUserDirectory;
        public static void SetExternalUserDirectory(UserDirectory directory)
        {
            _externalUserDirectory = directory;
        }

        public interface UserDirectory
        {
            User FindUser(string username, string password);
            void FindUserGroups(string username, Action<string> addGroupById, Action<string[]> addGroupsByName);
        }

        internal class LdapUserDirectory : UserDirectory
        {
            string GetUserDn(string username)
            {
                return SecuredValues.Decode(LdapAuthenticationConnectionString).Replace("$USER$", username.Trim());
            }
            public User FindUser(string username, string password)
            {
                try
                {
                    if (string.IsNullOrEmpty(password.TrimEnd())) return null;
                    LdapClient.DefaultClient.Connect(GetUserDn(username), password.Trim());
                    return new User(username, username, password, "", "");
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public void FindUserGroups(string username, Action<string> addGroupById, Action<string[]> addGroupsByName)
            {
                try
                {
                    var userDn = GetUserDn(username);
                    var groups = new List<string>();

                    groups.AddRange(
                        LdapClient.DefaultClient.Search(SecuredValues.Decode(LdapUserGroupsDomainContext), SearchScope.Subtree,
                            String.Format("(&(objectclass=groupofuniquenames)(uniquemember={0}))", userDn), "cn"));

                    groups.AddRange(
                        LdapClient.DefaultClient.Search(SecuredValues.Decode(LdapUserGroupsDomainContext), SearchScope.Subtree,
                                             String.Format("(&(|(objectclass=groupofnames)(objectclass=group))(member={0}))", userDn), "cn"));

                    foreach (var groupDn in LdapClient.DefaultClient.Search(SecuredValues.Decode(LdapUserGroupsDomainContext), SearchScope.Subtree,
                        string.Format("(&(objectclass=person)(userPrincipalName={0}))", userDn), "memberof"))
                    {
                        groups.AddRange(LdapClient.DefaultClient.Search(groupDn, SearchScope.Subtree, "(objectclass=*)", "cn"));
                    }

                    groups.AddRange(
                        LdapClient.DefaultClient.Search(SecuredValues.Decode(LdapUserGroupsDomainContext), SearchScope.Subtree,
                            String.Format("(&(objectclass=posixGroup)(memberUid={0}))", username.Trim()), "cn"));

                    addGroupsByName(groups.ToArray());
                }
                catch (Exception)
                {
                }
            }

            public static string LdapAuthenticationConnectionString;
            public static string LdapUserGroupsDomainContext;
        }

        internal class ADsUserDirectory : UserDirectory
        {
            DirectoryEntry _userEntry;

            public User FindUser(string username, string password)
            {
                try
                {
                    username = username.Trim();
                    password = password.Trim();
                    string searchRoot = SecuredValues.Decode("%Directory_Binding%");
                    _userEntry = new DirectoryEntry(searchRoot, username.Trim(), password.Trim());
                    DirectorySearcher search = new DirectorySearcher(_userEntry);
                    search.Filter = "(&(objectClass=user)(objectCategory=person)(samaccountname=" + username.Trim() + "))";
                    search.PropertiesToLoad.Add("samaccountname");
                    search.PropertiesToLoad.Add("mail");
                    search.PropertiesToLoad.Add("memberOf"); //this will have a list of all groups that the user is a part of
                    search.PropertiesToLoad.Add("department");
                    search.PropertiesToLoad.Add("name");

                    if (string.Compare(System.Environment.UserName, username, StringComparison.InvariantCultureIgnoreCase) == 0 &&
                        string.IsNullOrEmpty(password))
                        _userEntry.AuthenticationType = AuthenticationTypes.Secure;

                    var x = search.FindOne(); // Causes Bind
                    string mail = "";
                    string department = "";
                    string fullName = "";


                    if (x != null)
                    {
                        _userEntry = x.GetDirectoryEntry();

                        mail = _userEntry.Properties["mail"].Value == null ? "Unknown" : _userEntry.Properties["mail"].Value.ToString().Trim(); //making sure we dont get a null ref exception
                        department = _userEntry.Properties["department"].Value == null ? "Unknown" : _userEntry.Properties["department"].Value.ToString().Trim();
                        fullName = _userEntry.Properties["name"].Value == null ? "Unknown" : _userEntry.Properties["name"].Value.ToString().Trim();
                    }

                    return new User(username, username, password, "", "", mail, department, fullName);
                }
                catch (Exception ex)
                {
                    ErrorLog.WriteToLogFile(ex);
                    return null;
                }

            }

            public void FindUserGroups(string username, Action<string> addGroupById, Action<string[]> addGroupsByName)
            {
                try
                {
                    var groups = new List<string>();

                    foreach (var item in (IEnumerable)_userEntry.Invoke("Groups", null)) //added a null parameter to 'invoke' 
                        groups.Add(new DirectoryEntry(item).Name.Split('=')[1].Trim()); // stripping off the 'CN=' prefix on group names

                    addGroupsByName(groups.ToArray());
                }
                catch (Exception e)
                {
                    ErrorLog.WriteToLogFile(e);
                }
            }

            //public User FindUser(string username, string password)
            //{
            //    try
            //    {
            //        username = username.Trim();
            //        password = password.Trim();
            //        _userEntry = new DirectoryEntry(SecuredValues.Decode("%Directory_Binding%") + username + ",user");
            //        if (string.Compare(System.Environment.UserName, username, StringComparison.InvariantCultureIgnoreCase) == 0 &&
            //            string.IsNullOrEmpty(password))
            //            _userEntry.AuthenticationType = AuthenticationTypes.Secure;
            //        else
            //        {
            //            _userEntry.AuthenticationType = AuthenticationTypes.None;
            //            _userEntry.Username = username;
            //            _userEntry.Password = password;
            //        }
            //        var x = _userEntry.NativeObject; // Causes Bind
            //        return new User(username, username, password, "", "");
            //    }
            //    catch (Exception ex)
            //    {
            //        ErrorLog.WriteToLogFile(ex);
            //        return null;
            //    }

            //}

            //public void FindUserGroups(string username, Action<string> addGroupById, Action<string[]> addGroupsByName)
            //{
            //    try
            //    {
            //        var groups = new List<string>();
            //        foreach (var item in (IEnumerable)_userEntry.Invoke("Groups"))
            //            groups.Add(new DirectoryEntry(item).Name);
            //        addGroupsByName(groups.ToArray());
            //    }
            //    catch (Exception e)
            //    {
            //        ErrorLog.WriteToLogFile(e);
            //    }
            //}
        }

        public class UserStorage
        {
            DataSetDataProvider _db;
            UserDirectory _userDirectory;

            public UserStorage(DataSetDataProvider db, UserDirectory userDirectory)
                : this(db)
            {
                _userDirectory = userDirectory;
            }

            public UserStorage(DataSetDataProvider db)
            {
                _db = db;
                _userDirectory = new myUserDirectory(this);
            }

            class myUserDirectory : UserDirectory
            {
                UserStorage _parent;
                public myUserDirectory(UserStorage parent)
                {
                    _parent = parent;
                }

                public User FindUser(string username, string password)
                {
                    User result = null;
                    BusinessProcess bp = new BusinessProcess();
                    Entities.Users users = new ENV.Security.Entities.Users(_parent._db);
                    bp.From = users;
                    bp.AddAllColumns();
                    //                    bp.Where.Add(users.Password.IsEqualTo(password));
                    bp.Where.Add("{0}={1}", users.Password, password);
                    bp.ForEachRow(delegate ()
                    {
                        if (users.UserName.ToString().ToUpper(CultureInfo.InvariantCulture).Trim() == username.ToUpper(CultureInfo.InvariantCulture).Trim())
                        {
                            result = users.GetUser();
                            bp.Exit();
                        }
                    });
                    return result;
                }

                public void FindUserGroups(string username, Action<string> addGroupById, Action<string[]> addGroupsByName)
                {
                    BusinessProcess bp = new BusinessProcess();
                    Entities.UserGroups gr = new ENV.Security.Entities.UserGroups(_parent._db);
                    bp.From = gr;
                    bp.AddAllColumns();
                    bp.Where.Add(gr.ParentID.IsEqualTo(username));
                    bp.ForEachRow(() => addGroupById(gr.GroupID));
                }
            }

            public IEntityDataProvider GetDb()
            {
                return _db;
            }
            internal string CreateGroupAndReturnID(string s)
            {
                string groupId = null;
                try
                {
                    BusinessProcess bp = new BusinessProcess();
                    Entities.Groups g = new ENV.Security.Entities.Groups(_db);
                    bp.Relations.Add(g, RelationType.InsertIfNotFound, g.Description.IsEqualTo(s));
                    bp.AddAllColumns();
                    bp.ForFirstRow(delegate
                    {
                        if (g.ID.Value == "")
                            g.ID.SetToNewValue();
                        g.Description.Value = s;
                        groupId = g.ID;
                    });
                }
                catch
                {
                }
                return groupId;
            }
            public void AddSecuredValue(string name, string value)
            {
                var e = new Entities.SecuredValues(_db);
                var bp = new BusinessProcess { From = e, Activity = Activities.Insert };
                bp.ForFirstRow(() =>
                {
                    e.Name.Value = name;
                    e.Value.Value = value;
                });
            }

            public User FindUser(string username)
            {
                User result = null;
                DoOnUser(username, Activities.Browse,
                    delegate (User obj)
                    {
                        result = obj;
                    });
                return result;
            }
            public User FindUser(string username, string password)
            {
                return _userDirectory.FindUser(username, password);
            }

            public User CreateUser(string username, string password, string description, string additionalInfo)
            {
                User result = null;
                if (FindUser(username) != null)
                {
                    throw new Exception("User already exists");
                }
                Users u = new Users(_db);
                BusinessProcess bp = new BusinessProcess();
                bp.From = u;
                bp.AddAllColumns();
                bp.Activity = Activities.Insert;

                bp.ForFirstRow(delegate ()
                {
                    u.ID.SetToNewValue();
                    result = u.GetUser();
                    u.UserName.Value = username;
                    u.Password.Value = password;
                    if (string.IsNullOrEmpty(description))
                        u.Description.Value = username;
                    else
                        u.Description.Value = description;

                    u.AdditionalInfo.Value = additionalInfo;
                });

                return result;

            }
            public void DeleteUser(string username)
            {
                DoOnUser(username, Activities.Delete, delegate { });
            }

            void DoOnUser(string username, Firefly.Box.Activities activity, Action<User> whatToDo)
            {
                BusinessProcess bp = new BusinessProcess();
                Entities.Users u = new ENV.Security.Entities.Users(_db);
                bp.From = u;
                bp.AddAllColumns();
                bp.Activity = activity;
                bp.Where.Add(u.UserName.IsEqualTo(username));
                bp.ForFirstRow(delegate ()
                {
                    whatToDo(u.GetUser());
                });
            }

            public void AddRole(string id, string key)
            {

                BusinessProcess bp = new BusinessProcess();
                Roles r = new Roles(_db);
                bp.Relations.Add(r, RelationType.InsertIfNotFound,
                                 r.ParentID.IsEqualTo(id).And(r.Role.IsEqualTo(key)));
                try
                {
                    bp.ForFirstRow(delegate ()
                    {
                        r.ParentID.Value = id;
                        r.Role.Value = key;
                    });
                }
                catch { }


            }

            public void AddGroupToUser(string id, string groupName)
            {
                Groups g = new Groups(_db);
                BusinessProcess bp = new BusinessProcess();
                bp.From = g;
                bp.AddAllColumns();
                bp.Where.Add(g.Description.IsEqualTo(groupName));

                UserGroups ug = new UserGroups(_db);
                bp.Relations.Add(ug, RelationType.InsertIfNotFound,
                                 ug.ParentID.IsEqualTo(id).And(ug.GroupID.IsEqualTo(g.ID)));
                bp.ForEachRow(delegate ()
                {
                    ug.ParentID.Value = id;
                    ug.GroupID.Value = g.ID;
                });
            }

            internal SecurityUIController CreateSecurityUIUsing(Func<IEntityDataProvider, UserStorage, SecurityUIController> createSecurityUi)
            {
                return createSecurityUi(_db, this);
            }

            public void ProvideUserRoles(string id, Action<string> addAvailableRole)
            {
                //Entities.Roles.ProvideRolesTo(id, addAvailableRole, _db);
                Entities.Roles.ProvideRolesTo("Administrator", addAvailableRole, _db);
                _userDirectory.FindUserGroups(id, groupId => Entities.Roles.ProvideRolesTo(groupId, addAvailableRole, _db),
                    groupNames =>
                    {
                        var hs = new HashSet<string>(Array.ConvertAll(groupNames, input => input.Trim().ToUpperInvariant()));
                        var g = new Groups(_db);
                        new BusinessProcess() { From = g }.ForEachRow(() =>
                        {
                            if (hs.Contains(g.Description.Trim().ToString().ToUpperInvariant()))
                                Entities.Roles.ProvideRolesTo(g.ID, addAvailableRole, _db);
                        });
                    });
            }

            public void SaveChanges()
            {
                Save(_db);
            }

            public void LoadSecuredValues()
            {
                SecuredValues.Load(_db);
            }
        }
        public static void ChangeUserFile(Func<UserStorage, bool> returnTrueToSaveChanges)
        {
            //System.Windows.Forms.MessageBox.Show(_inProgress.ToString());
            //if (_inProgress)
            //throw new Exception("JHGFD");
            _inProgress = true;
            try
            {
                //System.Windows.Forms.MessageBox.Show("1");
                var db = Load();
                //System.Windows.Forms.MessageBox.Show("2");
                var ds = _externalUserDirectory != null ? new UserStorage(db, _externalUserDirectory) : new UserStorage(db);
                //System.Windows.Forms.MessageBox.Show("3");
                ds.LoadSecuredValues();
                //System.Windows.Forms.MessageBox.Show("4");


                if (returnTrueToSaveChanges(ds))
                {
                    //System.Windows.Forms.MessageBox.Show("5");
                    CurrentUser.ReloadRoles(ds);
                    //System.Windows.Forms.MessageBox.Show("6");
                    ds.LoadSecuredValues();
                    //System.Windows.Forms.MessageBox.Show("7");
                    ds.SaveChanges();
                    //System.Windows.Forms.MessageBox.Show("8");
                    //System.Threading.Thread.Sleep(5000);

                }

            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                _inProgress = false;
            }
        }

        internal static bool CanDelete(Text username)
        {
            var x = username.Trim().ToString().ToUpper();
            if (x.Equals("SUPERVISOR"))
                return false;
            if (x.Equals(ENV.Security.UserManager.CurrentUser.Name, StringComparison.InvariantCultureIgnoreCase))
                return false;
            return true;
        }
    }
}
