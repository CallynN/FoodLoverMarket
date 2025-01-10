using ENV;
using ENV.Data;
using Firefly.Box;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Globalization;
using System.Xml.Linq;


namespace EMS.MasterData
{
    public class CN010ImportData : BusinessProcessBase
    {
        #region Models

        #endregion
        #region Columns 
        public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
        public readonly TextColumn P_FileType = new TextColumn("P_FileType");
        public readonly TextColumn P_Table = new TextColumn("P_Table");

        #endregion

        public CN010ImportData()
        {
            Title = "CN010 Import Data";
            InitializeDataViewAndUserFlow();
        }

        void InitializeDataViewAndUserFlow()
        {


            #region Column Selection and USerFlow

            Columns.Add(P_FilePath);
            Columns.Add(P_FileType);
            Columns.Add(P_Table);

           // Flow.Add(() => MessageBox.Show("Test" + P_Table), () => true == true);
            

            #endregion
        }



        public void Run(TextParameter pP_FilePath, TextParameter pP_FileType, TextParameter pP_Table)
        {
            #region BindParameters
            BindParameter(P_FilePath, pP_FilePath);
            BindParameter(P_FileType, pP_FileType);
            BindParameter(P_Table, pP_Table);
            #endregion

            Execute();
        }

        protected override void OnLoad()
        {
            Exit(ExitTiming.AfterRow);
          //  BindGoToToNextRowAfterLastControl(() => !(V_Accept == "N"));
            
        }

        protected override void OnLeaveRow()
        {

            // MessageBox.Show("Test" + P_Table +" " + P_FileType +" " + P_FilePath);
            if (P_FileType == "C") // CSV
            {

                //Do Validation for that file is CSV

               // Create<ImportCSV>().Run();
                Cached<ImportCSV>().Run(P_Table, P_FilePath);
            }
            if (P_FileType == "J") // Json
            {
                //Do Validation for that file is Json

                
                Cached<ImportJson>().Run(P_Table, P_FilePath);
            }
            if (P_FileType == "X") // XML
            {
                // Do validation for the file is XML


                Cached<ImportXML>().Run(P_Table, P_FilePath);
            }



        }




        //Import CSV 
        internal class ImportCSV : BusinessProcessBase
        {
            CN010ImportData _parent;

            #region Models 
            // public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

            #endregion
            #region COlumns 
            public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
            public readonly TextColumn P_FileType = new TextColumn("P_FileType");
            public readonly TextColumn P_Table = new TextColumn("P_Table");

            #endregion


            public ImportCSV(CN010ImportData parent)
            {
                _parent = parent;
                InitializeDataViewAndUserFlow();

            }
            void InitializeDataViewAndUserFlow()
            {

                #region Column Selection and UserFlow
                Columns.Add(P_Table);
                Columns.Add(P_FilePath);

                #endregion


            }

            public void Run(TextParameter pP_Table, TextParameter pP_FilePath)
            {
                #region BindParameter
                BindParameter(P_Table, pP_Table);
                BindParameter(P_FilePath, pP_FilePath);
                #endregion

                Execute();
            }
            protected override void OnLoad()
            {
                Exit(ExitTiming.AfterRow);
            }


            protected override void OnEnterRow()
            {

            }

            //Call Import Table Class
            protected override void OnLeaveRow()
            {

                if (P_Table == "B") // Branch 
                {
                    Cached<ImportBranch>().Run(P_FilePath);
                }
                if (P_Table == "P") // Product
                {
                    Cached<ImportProduct>().Run(P_FilePath);
                }
                if (P_Table == "R") // Product Branch 
                {
                    Cached<ImportProductBranch>().Run(P_FilePath);
                }


            }

            // Import Branch 
            internal class ImportBranch : BusinessProcessBase
            {
                ImportCSV _parent;

                #region Models 
                // public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

                #endregion
                #region COlumns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
                public readonly TextColumn P_FileType = new TextColumn("P_FileType");
                public readonly TextColumn P_Table = new TextColumn("P_Table");

                NumberColumn counter = new NumberColumn();
                NumberColumn Id = new NumberColumn();
                TextColumn Name = new TextColumn();
                TextColumn Telephone = new TextColumn();
                DateColumn Opendate = new DateColumn();
                TextColumn Status = new TextColumn();


                #endregion
                #region Streams
                ENV.IO.FileReader _reader;

                #endregion

                public ImportBranch(ImportCSV parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {




                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion

                    Execute();
                }
                protected override void OnLoad()
                {
                   // Link File 
                    _reader = new ENV.IO.FileReader(P_FilePath);
                    Streams.Add(_reader);
                    Exit(Firefly.Box.ExitTiming.BeforeRow, () => _reader.EndOfFile);

                    counter.Value = 0;
                }


                protected override void OnEnterRow()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {
                    counter.Value = counter.Value + 1;
                    var line = _reader.ReadLine();

                    if (counter.Value > 1)
                    {
                        var split = line.Split(',');
                        // branch.Value = Int32.Parse(split[0]);
                        Id.Value = Int32.Parse(split[0]);
                        Name.Value = split[1].Trim();
                        Telephone.Value = split[2].Trim();
                        //Opendate.Value = Date.Parse(split[3]);
                        Status.Value = "A";

                        // quantity.Value = Int32.Parse(split[2]);

                        new WriteData(this).Run();
                    }


                }



                // Write Data Branch
                internal class WriteData : BusinessProcessBase
                {
                    #region Models
                    public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

                    #endregion

                    ImportBranch _parent;
                    public WriteData(ImportBranch parent)
                    {
                        _parent = parent;
                        Title = "Write Data";
                        InitializeDataView();
                    }
                    void InitializeDataView()
                    {
                        #region Relations
                        Relations.Add(Branch_ , RelationType.InsertIfNotFound, Branch_.Id.IsEqualTo(_parent.Id), Branch_.SortByPkBranch);

                        #endregion

                        #region Column Selection and UserFlow 
                        Columns.Add(Branch_.Id);
                        Columns.Add(Branch_.Name);
                        Columns.Add(Branch_.TelephoneNumber);
                        Columns.Add(Branch_.OpenDate);
                        Columns.Add(Branch_.Status);
                       

                        #endregion


                    }
                    

                    public void Run()
                    {
                        Execute();
                    }
                    protected override void OnLoad()
                    {
                        Exit(ExitTiming.AfterRow);
                        RowLocking = LockingStrategy.OnRowLoading;
                        TransactionScope = TransactionScopes.Task;

                    }
                    protected override void OnLeaveRow()
                    {
                        // Save Data to table 
                        Branch_.Id.Value = _parent.Id.Value;
                        Branch_.Name.Value = _parent.Name.Value;
                        Branch_.TelephoneNumber.Value = _parent.Telephone.Value;
                        Branch_.OpenDate.Value = Date.Now;
                        Branch_.Status.Value = _parent.Status;
                        

                    }
                }


            }

            // Import Product 
            internal class ImportProduct : BusinessProcessBase
            {
                ImportCSV _parent;

                #region Models 
                // public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

                #endregion
                #region COlumns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
                public readonly TextColumn P_FileType = new TextColumn("P_FileType");
                public readonly TextColumn P_Table = new TextColumn("P_Table");


                NumberColumn counter = new NumberColumn();
                NumberColumn Id = new NumberColumn();
                TextColumn Name = new TextColumn();
                TextColumn Weighted = new TextColumn();
                TextColumn Temp = new TextColumn();
                NumberColumn SuggestPrice = new NumberColumn();
                TextColumn Status = new TextColumn();


                TextColumn TempIdentSuggestPrice = new TextColumn();
                float TempSuggested;

                #endregion
                #region Streams
                ENV.IO.FileReader _reader;

                #endregion

                public ImportProduct(ImportCSV parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {




                }

                public void Run( TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion

                    Execute();
                }
                protected override void OnLoad()
                {
                    
                    // Link File 
                    _reader = new ENV.IO.FileReader(P_FilePath);
                    Streams.Add(_reader);
                    Exit(Firefly.Box.ExitTiming.BeforeRow, () => _reader.EndOfFile);

                    counter.Value = 0;
                }


                protected override void OnEnterRow()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {

                    counter.Value = counter.Value + 1;
                    var line = _reader.ReadLine();

                    if (counter.Value > 1)
                    {
                        var split = line.Split(',');
                        // branch.Value = Int32.Parse(split[0]);
                        Id.Value = Int32.Parse(split[0]);
                        Name.Value = split[1].Trim();
                        Weighted.Value = split[2].Trim();
                        //SuggestPrice.Value = float.Parse("1123,22") ;//float.Parse(split[3], System.Globalization.CultureInfo.InvariantCulture); 

                        if (float.TryParse(split[3], NumberStyles.Any, CultureInfo.InvariantCulture, out float parsedValue))
                        {
                            TempSuggested = parsedValue;
                            Debug.WriteLine(TempSuggested.ToString("F2")); // Format to 2 decimal places
                        }
                        SuggestPrice.Value = TempSuggested;
                        //Temp.Value = split[3].Trim();
                        //string Temp2 = split[3].Trim();
                        //string Temp3 = Temp2.Replace(".", ",");
                        //Temp.Value = Temp2.Replace(".", ",") ;
                        //SuggestPrice = float.Parse(Temp3.ToString());
                        Status.Value = "A";

                        // quantity.Value = Int32.Parse(split[2]);

                        new WriteData(this).Run();
                    }

                }



                // Write Data Product
                internal class WriteData : BusinessProcessBase
                {
                    #region Models
                    public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();

                    #endregion

                    ImportProduct _parent;
                    public WriteData(ImportProduct parent)
                    {
                        _parent = parent;
                        Title = "Write Data";
                        InitializeDataView();
                    }
                    void InitializeDataView()
                    {
                        #region Relations
                        // Relations.Add(Branch_, RelationType.InsertIfNotFound, Branch_.Id.IsEqualTo(_parent.Id), Branch_.SortByPkBranch);
                        Relations.Add(Product_, RelationType.InsertIfNotFound, Product_.Id.IsEqualTo(_parent.Id), Product_.SortByPKProduct);

                        #endregion

                        #region Column Selection and UserFlow 
                        Columns.Add(Product_.Id);
                        Columns.Add(Product_.Name);
                        Columns.Add(Product_.WeightedItem);
                        Columns.Add(Product_.SuggestedSellingPrice);
                        Columns.Add(Product_.Status);


                        #endregion


                    }


                    public void Run()
                    {
                        Execute();
                    }
                    protected override void OnLoad()
                    {
                        Exit(ExitTiming.AfterRow);
                        RowLocking = LockingStrategy.OnRowLoading;
                        TransactionScope = TransactionScopes.Task;

                    }
                    protected override void OnLeaveRow()
                    {
                        // Save Data to table 
                        Product_.Id.Value = _parent.Id.Value;
                        Product_.Name.Value = _parent.Name.Value;
                        if (_parent.Weighted == "N")
                        {
                            Product_.WeightedItem.Value = false;
                        }
                        else
                        {
                            Product_.WeightedItem.Value = true;
                        }
                       
                        Product_.SuggestedSellingPrice.Value = _parent.SuggestPrice;
                        Product_.Status.Value = _parent.Status;


                    }
                }



            }

            // Import Product Branch 
            internal class ImportProductBranch : BusinessProcessBase
            {
                ImportCSV _parent;

                #region Models 
                 //public readonly EMS.Models.MasterData.BranchProduct BranchProduct_ = new EMS.Models.MasterData.BranchProduct();

                #endregion
                #region COlumns 
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
                public readonly TextColumn P_FileType = new TextColumn("P_FileType");
                public readonly TextColumn P_Table = new TextColumn("P_Table");

                NumberColumn counter = new NumberColumn();
                NumberColumn BranchId = new NumberColumn();
                NumberColumn ProductId = new NumberColumn();
                TextColumn Status = new TextColumn();

                #endregion
                #region Streams
                ENV.IO.FileReader _reader;

                #endregion

                public ImportProductBranch(ImportCSV parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();

                }
                void InitializeDataViewAndUserFlow()
                {




                }

                public void Run( TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion

                    Execute();
                }
                protected override void OnLoad()
                {
                    _reader = new ENV.IO.FileReader(P_FilePath);
                    Streams.Add(_reader);
                    Exit(Firefly.Box.ExitTiming.BeforeRow, () => _reader.EndOfFile);

                    counter.Value = 0;
                }


                protected override void OnEnterRow()
                {

                }

                //Save data to Table 
                protected override void OnLeaveRow()
                {

                    counter.Value = counter.Value + 1;
                    var line = _reader.ReadLine();

                    if (counter.Value > 1)
                    {
                        var split = line.Split(',');
                        // branch.Value = Int32.Parse(split[0]);
                        BranchId.Value = Int32.Parse(split[0]);
                        ProductId.Value = Int32.Parse(split[1]);
                        Status.Value = "A";

                        // Write Data
                        new WriteData(this).Run();
                    }

                }


                // Write Data 
                internal class WriteData : BusinessProcessBase
                {
                    #region Models
                    public readonly EMS.Models.MasterData.BranchProduct BranchProduct_ = new EMS.Models.MasterData.BranchProduct();
                    #endregion

                    ImportProductBranch _parent;
                    public WriteData(ImportProductBranch parent)
                    {
                        _parent = parent;
                        Title = "Write Data";
                        InitializeDataView();
                    }
                    void InitializeDataView()
                    {
                        #region Relations
                         Relations.Add(BranchProduct_, RelationType.InsertIfNotFound, BranchProduct_.BranchID.IsEqualTo(_parent.BranchId).And(BranchProduct_.ProductID.IsEqualTo(_parent.ProductId)), BranchProduct_.SortByPKBranch);

                        #endregion

                        #region Column Selection and UserFlow 
                        Columns.Add(BranchProduct_.BranchID);
                        Columns.Add(BranchProduct_.ProductID);
                        //Columns.Add(BranchProduct_.Status);


                        #endregion


                    }


                    public void Run()
                    {
                        Execute();
                    }
                    protected override void OnLoad()
                    {
                        Exit(ExitTiming.AfterRow);
                        RowLocking = LockingStrategy.OnRowLoading;
                        TransactionScope = TransactionScopes.Task;

                    }
                    protected override void OnLeaveRow()
                    {
                        // Save Data to table 
                        BranchProduct_.BranchID.Value = _parent.BranchId.Value;
                        BranchProduct_.ProductID.Value = _parent.ProductId.Value;
                        //BranchProduct_.Status.Value = _parent.Status;


                    }
                }


            }


        }

        //Import Json
        internal class ImportJson : BusinessProcessBase
        {
            CN010ImportData _parent;

            #region Models 
            // public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

            #endregion
            #region COlumns 
            public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
            public readonly TextColumn P_FileType = new TextColumn("P_FileType");
            public readonly TextColumn P_Table = new TextColumn("P_Table");

           

            #endregion


            public ImportJson(CN010ImportData parent)
            {
                _parent = parent;
                InitializeDataViewAndUserFlow();

            }
            void InitializeDataViewAndUserFlow()
            {

                #region Column Selection and UserFlow
                Columns.Add(P_Table);
                Columns.Add(P_FilePath);

                #endregion


            }

            public void Run(TextParameter pP_Table, TextParameter pP_FilePath)
            {
                #region BindParameter
                BindParameter(P_Table, pP_Table);
                BindParameter(P_FilePath, pP_FilePath);
                #endregion

                Execute();
            }
            protected override void OnLoad()
            {
                Exit(ExitTiming.AfterRow);
            }


            protected override void OnEnterRow()
            {

            }

            //Save data to Table 
            protected override void OnLeaveRow()
            {
                if (P_Table == "B") // Branch 
                {
                    Cached<ImportBranch>().Run(P_FilePath);
                }
                if (P_Table == "P") // Product
                {
                    Cached<ImportProduct>().Run(P_FilePath);
                }
                if (P_Table == "R") // Product Branch 
                {
                    Cached<ImportBranchProduct>().Run(P_FilePath);
                }


            }


            // Import Branch 
            internal class ImportBranch : BusinessProcessBase
            {
                ImportJson _parent;

                #region Models
              

                #endregion
                #region Columns
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
                public readonly TextColumn P_FileType = new TextColumn("P_FileType");
                public readonly TextColumn P_Table = new TextColumn("P_Table");

                public readonly NumberColumn V_CounterStart = new NumberColumn("V_CounterStart");
                public readonly BoolColumn V_EndOfFile = new BoolColumn("V_EndOfFile");
                public readonly BoolColumn V_GroupStart = new BoolColumn("V_GroupStart");
                public readonly BoolColumn V_EndOfGroup = new BoolColumn("V_EndOfGroup");
                public readonly BoolColumn V_Problem = new BoolColumn("V_Problem");
                public readonly NumberColumn V_MainCounter = new NumberColumn("V_MainCounter");

                NumberColumn counter = new NumberColumn();
                NumberColumn Id = new NumberColumn();
                TextColumn Name = new TextColumn();
                TextColumn Telephone = new TextColumn();
                DateColumn OpenDate = new DateColumn();
                TextColumn Status = new TextColumn();


                NumberColumn CounterWriteVar = new NumberColumn();

                TextColumn Ident = new TextColumn();
                TextColumn IdentOpenDate = new TextColumn();
                TextColumn IdentTelephone = new TextColumn();
                TextColumn TempIdentOpenDate = new TextColumn();
                TextColumn NewLine = new TextColumn();
                TextColumn tempNewLine = new TextColumn();
                DateColumn TempOpendate = new DateColumn();

                #endregion
                #region Streams
                ENV.IO.FileReader _reader;

               
                #endregion


                public ImportBranch(ImportJson parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();
                }

                void InitializeDataViewAndUserFlow()
                {
                    


                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion

                    Execute();
                }

                protected override void OnLoad()
                {
                    _reader = new ENV.IO.FileReader(P_FilePath);
                    Streams.Add(_reader);
                    Exit(Firefly.Box.ExitTiming.BeforeRow, () => _reader.EndOfFile);

                    counter.Value = 0;
                    V_MainCounter.Value = 0;

                }

                protected override void OnStart()
                {
                    V_CounterStart.Value = 0;
                    V_EndOfFile.Value = false;
                    V_GroupStart.Value = false;
                    V_EndOfGroup.Value = false;
                    V_Problem.Value = false;
                    CounterWriteVar.Value = 0;

                }

                protected override void OnEnterRow()
                {
                    
                }

                protected override void OnLeaveRow()
                {

                    counter.Value = counter.Value + 1;
                    var line = _reader.ReadLine();

                    Debug.WriteLine(line.ToString());

                    tempNewLine.Value = (line.ToString()).Trim();
                    Ident.Value = tempNewLine.Substring(0, 4);

                    // Find Starting Point 
                    if (Ident.Value == "\"ID\"")
                    {
                      
                        V_GroupStart.Value = true;
                    }


                    if (V_GroupStart.Value == true )
                        {

                        CounterWriteVar.Value = CounterWriteVar.Value + 1;
                       // NewLine.Value = line.Replace("\"ID\":", "").Replace(",", "").Trim();

                        if (CounterWriteVar.Value == 1) // ID
                        {
                            NewLine.Value = line.Replace("\"ID\":", "").Replace(",", "").Trim();
                            Id.Value = Int32.Parse(NewLine.Value);
                            Debug.WriteLine(Id.Value.ToString());
                            //System.Windows.Forms.MessageBox.Show("ID- " + NewLine.ToString());

                        }


                        if (CounterWriteVar.Value == 2) // Name
                        {
                            NewLine.Value = line.Replace("\"Name\":", "").Replace("\"","").Replace(",", "").Trim();
                            Name.Value = NewLine.Value.ToString();
                            Debug.WriteLine(Name.Value.ToString());
                            //System.Windows.Forms.MessageBox.Show("Name- " + NewLine.ToString());
                        }


                        if (CounterWriteVar.Value == 3) // Telephone
                        {

                            IdentTelephone.Value = tempNewLine.Substring(1, 15);
                            TempIdentOpenDate.Value = IdentTelephone.Substring(0, 8);
                            Debug.WriteLine(IdentTelephone.Value.ToString());
                            if (IdentTelephone.Value == "TelephoneNumber")
                            {
                                NewLine.Value = line.Replace("\"TelephoneNumber\":", "").Replace("\"", "").Replace(",", "").Trim();


                                if (NewLine.Value == "")
                                {

                                    Telephone.Value = "";
                                    Debug.WriteLine(Telephone.Value.ToString());
                                }
                                else
                                {
                                    Telephone.Value = NewLine.Value.ToString();
                                    Debug.WriteLine(Telephone.Value.ToString());
                                }


                            }
                            else
                            {
                                Telephone.Value = "";
                                Debug.WriteLine(Telephone.Value.ToString() + "No Value");

                                // Line number mismatch
                                if (TempIdentOpenDate.Value == "OpenDate")
                                {

                                    //System.Windows.Forms.MessageBox.Show("Wokring");
                                    V_Problem.Value = true;
                                    NewLine.Value = line.Replace("\"OpenDate\":", "").Replace("\"", "").Replace(",", "").Trim();
                                    TempOpendate.Value = Date.Parse(NewLine.Value.ToString(), "YYYY/MM/DD");

                                }
                           
    
                               
                            }

                            
                        }


                        if (CounterWriteVar.Value == 4) // Opendate
                        {
                            IdentOpenDate.Value = tempNewLine.Substring(1, 8);
                            Debug.WriteLine(IdentOpenDate.Value.ToString());

                            if (IdentOpenDate.Value == "OpenDate")
                            {
                                NewLine.Value = line.Replace("\"OpenDate\":", "").Replace("\"", "").Replace(",", "").Trim();
                               

                                if (NewLine.Value == "")
                                {

                                    OpenDate.Value = Date.Parse("2000/01/01", "YYYY/MM/DD");
                                    Debug.WriteLine(OpenDate.Value.ToString());
                                }
                                else
                                {
                                     OpenDate.Value = Date.Parse(NewLine.Value.ToString(),"YYYY/MM/DD");
                                     Debug.WriteLine(OpenDate.Value.ToString());
                                }


                            }
                            else
                            {
                                OpenDate.Value = Date.Parse("2000/01/01", "YYYY/MM/DD");
                                Debug.WriteLine(OpenDate.Value.ToString());

                                if (V_Problem.Value == true)
                                {
                                    OpenDate.Value = TempOpendate.Value;
                                    Debug.WriteLine(OpenDate.Value.ToString());

                                    V_Problem.Value = false;

                                }
                            }


                           // NewLine.Value = line.Replace("\"OpenDate\":", "").Replace("\"", "").Replace(",", "").Trim();
                           // OpenDate.Value = Date.Parse(NewLine.Value.ToString(),"YYYY/MM/DD");
                           // Debug.WriteLine(OpenDate.Value.ToString());
                            //System.Windows.Forms.MessageBox.Show("Opendate- " + NewLine.ToString());
                        }


                        // Set End point for Loop 
                        if (CounterWriteVar.Value == 4)
                        {

                            CounterWriteVar.Value = 0;
                            V_GroupStart.Value = false;

                            // Write data to the database
                           new WriteData(this).Run();
                        }






                    }




                    // Write data to the database
                    //new WriteData(this).Run();

                }


                // Write Data Branch
                internal class WriteData : BusinessProcessBase
                {
                    #region Models
                    public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

                    #endregion

                    ImportBranch _parent;
                    public WriteData(ImportBranch parent)
                    {
                        _parent = parent;
                        Title = "Write Data";
                        InitializeDataView();
                    }
                    void InitializeDataView()
                    {
                        #region Relations
                        Relations.Add(Branch_, RelationType.InsertIfNotFound, Branch_.Id.IsEqualTo(_parent.Id), Branch_.SortByPkBranch);

                        #endregion

                        #region Column Selection and UserFlow 
                        Columns.Add(Branch_.Id);
                        Columns.Add(Branch_.Name);
                        Columns.Add(Branch_.TelephoneNumber);
                        Columns.Add(Branch_.OpenDate);
                        Columns.Add(Branch_.Status);


                        #endregion


                    }


                    public void Run()
                    {
                        Execute();
                    }
                    protected override void OnLoad()
                    {
                        Exit(ExitTiming.AfterRow);
                        RowLocking = LockingStrategy.OnRowLoading;
                        TransactionScope = TransactionScopes.Task;

                    }
                    protected override void OnLeaveRow()
                    {
                        // Save Data to table 
                        Branch_.Id.Value = _parent.Id.Value;
                        Branch_.Name.Value = _parent.Name.Value;
                        Branch_.TelephoneNumber.Value = _parent.Telephone.Value;
                        Branch_.OpenDate.Value = _parent.OpenDate;
                        Branch_.Status.Value = "A";


                    }
                }

            }

            // Import Product 
            internal class ImportProduct : BusinessProcessBase
            {
                ImportJson _parent;

                #region Models
                // Updated BranchModel to match your JSON structure
                #endregion
                #region Columns
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
                public readonly TextColumn P_FileType = new TextColumn("P_FileType");
                public readonly TextColumn P_Table = new TextColumn("P_Table");

                public readonly NumberColumn V_CounterStart = new NumberColumn("V_CounterStart");
                public readonly BoolColumn V_EndOfFile = new BoolColumn("V_EndOfFile");
                public readonly BoolColumn V_GroupStart = new BoolColumn("V_GroupStart");
                public readonly BoolColumn V_EndOfGroup = new BoolColumn("V_EndOfGroup");
                public readonly BoolColumn V_Problem = new BoolColumn("V_Problem");
                public readonly NumberColumn V_MainCounter = new NumberColumn("V_MainCounter");


                NumberColumn counter = new NumberColumn();
                NumberColumn Id = new NumberColumn();
                TextColumn Name = new TextColumn();
                TextColumn Weighted = new TextColumn();
                TextColumn Temp = new TextColumn();
                NumberColumn SuggestPrice = new NumberColumn("SuggestPrice", "12.2");
                TextColumn Status = new TextColumn();


                NumberColumn CounterWriteVar = new NumberColumn();

                TextColumn Ident = new TextColumn();
                TextColumn IdentOpenDate = new TextColumn();
                TextColumn IdentTelephone = new TextColumn();
                TextColumn TempIdentOpenDate = new TextColumn();
                TextColumn NewLine = new TextColumn();
                TextColumn tempNewLine = new TextColumn();
                DateColumn TempOpendate = new DateColumn();


                TextColumn IdentWeighted = new TextColumn();
                NumberColumn TempSuggestPrice = new NumberColumn();
                TextColumn TempIdentSuggestPrice = new TextColumn();
                TextColumn IdentSuggestPrice = new TextColumn();


                float TempSuggested;



                #endregion
                #region Streams
                ENV.IO.FileReader _reader;


                #endregion


                public ImportProduct(ImportJson parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();
                }

                void InitializeDataViewAndUserFlow()
                {



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion

                    Execute();
                }

                protected override void OnLoad()
                {
                    _reader = new ENV.IO.FileReader(P_FilePath);
                    Streams.Add(_reader);
                    Exit(Firefly.Box.ExitTiming.BeforeRow, () => _reader.EndOfFile);

                    counter.Value = 0;
                    V_MainCounter.Value = 0;

                }

                protected override void OnStart()
                {
                    V_CounterStart.Value = 0;
                    V_EndOfFile.Value = false;
                    V_GroupStart.Value = false;
                    V_EndOfGroup.Value = false;
                    V_Problem.Value = false;
                    CounterWriteVar.Value = 0;

                }

                protected override void OnEnterRow()
                {

                }

                protected override void OnLeaveRow()
                {

                    counter.Value = counter.Value + 1;
                    var line = _reader.ReadLine();

                    Debug.WriteLine(line.ToString());

                    tempNewLine.Value = (line.ToString()).Trim();
                    Ident.Value = tempNewLine.Substring(0, 4);

                    // Find Starting Point 
                    if (Ident.Value == "\"ID\"")
                    {

                        V_GroupStart.Value = true;
                    }


                    if (V_GroupStart.Value == true)
                    {

                        CounterWriteVar.Value = CounterWriteVar.Value + 1;
                        // NewLine.Value = line.Replace("\"ID\":", "").Replace(",", "").Trim();

                        if (CounterWriteVar.Value == 1) // ID
                        {
                            NewLine.Value = line.Replace("\"ID\":", "").Replace(",", "").Trim();
                            Id.Value = Int32.Parse(NewLine.Value);
                            Debug.WriteLine(Id.Value.ToString());
                            //System.Windows.Forms.MessageBox.Show("ID- " + NewLine.ToString());

                        }


                        if (CounterWriteVar.Value == 2) // Name
                        {
                            NewLine.Value = line.Replace("\"Name\":", "").Replace("\"", "").Replace(",", "").Trim();
                            Name.Value = NewLine.Value.ToString();
                            Debug.WriteLine(Name.Value.ToString());
                            //System.Windows.Forms.MessageBox.Show("Name- " + NewLine.ToString());
                        }


                        if (CounterWriteVar.Value == 3) // Weighted
                        {

                            IdentWeighted.Value = tempNewLine.Substring(1, 12);
                            TempIdentSuggestPrice.Value = IdentWeighted.Substring(0, 8);

                            Debug.WriteLine(IdentWeighted.Value.ToString());
                            if (IdentWeighted.Value == "WeightedItem")
                            {
                                NewLine.Value = line.Replace("\"WeightedItem\":", "").Replace("\"", "").Replace(",", "").Trim();


                                if (NewLine.Value == "")
                                {

                                    Weighted.Value = "N";
                                    Debug.WriteLine(Weighted.Value.ToString());
                                }
                                else
                                {
                                    Weighted.Value = NewLine.Value.ToString();
                                    Debug.WriteLine(Weighted.Value.ToString());
                                }

                                if (NewLine.Value.ToString() == "0")
                                {
                                    Weighted.Value = "N";
                                    Debug.WriteLine(Weighted.Value.ToString());
                                }

                                if (NewLine.Value.ToString() == "1")
                                {
                                    Weighted.Value = "Y";
                                    Debug.WriteLine(Weighted.Value.ToString());
                                }


                            }
                            else
                            {
                                Weighted.Value = "N";
                                Debug.WriteLine(Weighted.Value.ToString() + "No Value");

                                // Line number mismatch
                                if (TempIdentSuggestPrice.Value == "SuggestedSellingPrice")
                                {

                                    //System.Windows.Forms.MessageBox.Show("Wokring");
                                    V_Problem.Value = true;
                                    NewLine.Value = line.Replace("\"SuggestedSellingPrice\":", "").Replace("\"", "").Replace(",", "").Trim();
                                    


                                    // Convert value from file to Decimal 
                                    if (float.TryParse(NewLine.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out float parsedValue))
                                    {
                                        TempSuggested = parsedValue;
                                        Debug.WriteLine(TempSuggested.ToString("F2")); // Format to 2 decimal places
                                    }
                                    TempSuggestPrice.Value = TempSuggested;

                                }



                            }


                        }


                        if (CounterWriteVar.Value == 4) // SuggestSellingPrice
                        {
                            IdentSuggestPrice.Value = tempNewLine.Substring(1, 21);
                            Debug.WriteLine(IdentSuggestPrice.Value.ToString());

                            if (IdentSuggestPrice.Value == "SuggestedSellingPrice")
                            {
                                NewLine.Value = line.Replace("\"SuggestedSellingPrice\":", "").Replace("\"", "").Replace(",", "").Trim();


                                if (NewLine.Value == "")
                                {

                                    //OpenDate.Value = Date.Parse("2003/03/03", "YYYY/MM/DD");
                                    SuggestPrice.Value = float.Parse("0.00");
                                    Debug.WriteLine(SuggestPrice.Value.ToString());
                                }
                                else
                                {
                                    //OpenDate.Value = Date.Parse(NewLine.Value.ToString(), "YYYY/MM/DD");
                                    // SuggestPrice.Value = float.Parse(NewLine.Value.ToString("n2"));
                                     

                                    

                                    // Convert value from file to Decimal 
                                    if (float.TryParse(NewLine.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out float parsedValue))
                                    {
                                        TempSuggested = parsedValue;
                                        Debug.WriteLine(TempSuggested.ToString("F2")); // Format to 2 decimal places
                                    }
                                    SuggestPrice.Value = TempSuggested;
                                    Debug.WriteLine(SuggestPrice.Value.ToString());
                                }


                            }
                            else
                            {
                                //OpenDate.Value = Date.Parse("2000/01/01", "YYYY/MM/DD");
                                SuggestPrice.Value = 0.00;
                                Debug.WriteLine(SuggestPrice.Value.ToString());

                                if (V_Problem.Value == true)
                                {
                                    //OpenDate.Value = TempOpendate.Value;
                                    SuggestPrice.Value = TempSuggestPrice.Value;
                                    //Debug.WriteLine(SuggestPrice.Value.ToString());

                                    if (float.TryParse(NewLine.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out float parsedValue))
                                    {
                                        TempSuggested = parsedValue;
                                        Debug.WriteLine(TempSuggested.ToString("F2")); // Format to 2 decimal places
                                    }
                                    SuggestPrice.Value = TempSuggested;
                                    Debug.WriteLine(SuggestPrice.Value.ToString());



                                    V_Problem.Value = false;

                                }
                            }


                            // NewLine.Value = line.Replace("\"OpenDate\":", "").Replace("\"", "").Replace(",", "").Trim();
                            // OpenDate.Value = Date.Parse(NewLine.Value.ToString(),"YYYY/MM/DD");
                            // Debug.WriteLine(OpenDate.Value.ToString());
                            //System.Windows.Forms.MessageBox.Show("Opendate- " + NewLine.ToString());
                        }


                        // Set End point for Loop 
                        if (CounterWriteVar.Value == 4)
                        {

                            CounterWriteVar.Value = 0;
                            V_GroupStart.Value = false;

                            // Write data to the database
                            new WriteData(this).Run();
                        }






                    }




                    // Write data to the database
                    //new WriteData(this).Run();

                }


                // Write Data Branch
                internal class WriteData : BusinessProcessBase
                {
                    #region Models
                    public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();

                    #endregion

                    ImportProduct _parent;
                    public WriteData(ImportProduct parent)
                    {
                        _parent = parent;
                        Title = "Write Data";
                        InitializeDataView();
                    }
                    void InitializeDataView()
                    {
                        #region Relations
                        // Relations.Add(Branch_, RelationType.InsertIfNotFound, Branch_.Id.IsEqualTo(_parent.Id), Branch_.SortByPkBranch);
                        Relations.Add(Product_, RelationType.InsertIfNotFound, Product_.Id.IsEqualTo(_parent.Id), Product_.SortByPKProduct);

                        #endregion

                        #region Column Selection and UserFlow 
                        Columns.Add(Product_.Id);
                        Columns.Add(Product_.Name);
                        Columns.Add(Product_.WeightedItem);
                        Columns.Add(Product_.SuggestedSellingPrice);
                        Columns.Add(Product_.Status);


                        #endregion


                    }


                    public void Run()
                    {
                        Execute();
                    }
                    protected override void OnLoad()
                    {
                        Exit(ExitTiming.AfterRow);
                        RowLocking = LockingStrategy.OnRowLoading;
                        TransactionScope = TransactionScopes.Task;

                    }
                    protected override void OnLeaveRow()
                    {
                        // Save Data to table 
                        Product_.Id.Value = _parent.Id.Value;
                        Product_.Name.Value = _parent.Name.Value;
                        if (_parent.Weighted == "N")
                        {
                            Product_.WeightedItem.Value = false;
                        }
                        else
                        {
                            Product_.WeightedItem.Value = true;
                        }

                        Product_.SuggestedSellingPrice.Value = _parent.SuggestPrice;
                        Product_.Status.Value = "A";


                    }
                }

            }

            // Import Branch Product
            internal class ImportBranchProduct : BusinessProcessBase
            {
                ImportJson _parent;

                #region Models


                #endregion
                #region Columns
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
                public readonly TextColumn P_FileType = new TextColumn("P_FileType");
                public readonly TextColumn P_Table = new TextColumn("P_Table");

                public readonly NumberColumn V_CounterStart = new NumberColumn("V_CounterStart");
                public readonly BoolColumn V_EndOfFile = new BoolColumn("V_EndOfFile");
                public readonly BoolColumn V_GroupStart = new BoolColumn("V_GroupStart");
                public readonly BoolColumn V_EndOfGroup = new BoolColumn("V_EndOfGroup");
                public readonly BoolColumn V_Problem = new BoolColumn("V_Problem");
                public readonly NumberColumn V_MainCounter = new NumberColumn("V_MainCounter");

                NumberColumn counter = new NumberColumn();
                NumberColumn BranchId = new NumberColumn();
                NumberColumn ProductId = new NumberColumn();


                NumberColumn CounterWriteVar = new NumberColumn();

                TextColumn Ident = new TextColumn();
                TextColumn NewLine = new TextColumn();
                TextColumn tempNewLine = new TextColumn();
                TextColumn TempProduct = new TextColumn();
                

                #endregion
                #region Streams
                ENV.IO.FileReader _reader;


                #endregion


                public ImportBranchProduct(ImportJson parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();
                }

                void InitializeDataViewAndUserFlow()
                {



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion

                    Execute();
                }

                protected override void OnLoad()
                {
                    _reader = new ENV.IO.FileReader(P_FilePath);
                    Streams.Add(_reader);
                    Exit(Firefly.Box.ExitTiming.BeforeRow, () => _reader.EndOfFile);

                    counter.Value = 0;
                    

                }

                protected override void OnStart()
                {
                    V_CounterStart.Value = 0;
                    V_EndOfFile.Value = false;
                    V_GroupStart.Value = false;
                    V_EndOfGroup.Value = false;
                    V_Problem.Value = false;
                    CounterWriteVar.Value = 0;

                }

                protected override void OnEnterRow()
                {

                }

                protected override void OnLeaveRow()
                {

                    counter.Value = counter.Value + 1;
                    var line = _reader.ReadLine();

                    Debug.WriteLine(line.ToString());

                    tempNewLine.Value = (line.ToString()).Trim();
                    Ident.Value = tempNewLine.Substring(1, 8);
                    Debug.WriteLine(Ident.ToString());

                    // Find Starting Point 
                    if (Ident.Value == "BranchID")
                    {

                        V_GroupStart.Value = true;
                    }


                    if (V_GroupStart.Value == true)
                    {

                        CounterWriteVar.Value = CounterWriteVar.Value + 1;
                        

                        if (CounterWriteVar.Value == 1) // Branch ID
                        {
                            NewLine.Value = line.Replace("\"BranchID\":", "").Replace(",", "").Trim();
                            BranchId.Value = Int32.Parse(NewLine.Value);
                            Debug.WriteLine(BranchId.Value.ToString());
                            //System.Windows.Forms.MessageBox.Show("ID- " + NewLine.ToString());

                           

                        }


                        if (CounterWriteVar.Value == 2) // Product ID
                        {

                            NewLine.Value = line.Replace("\"ProductID\":", "").Replace("\"", "").Replace(",", "").Trim();
                            tempNewLine.Value = line.Replace("\"ProductID\":", "").Replace("\"", "").Trim();
                            Debug.WriteLine(tempNewLine.Value.ToString());
                            if (tempNewLine.Value == "},")
                            {

                                

                                ProductId.Value = 0;
                                Debug.WriteLine(ProductId.Value.ToString());


                            }
                            else
                            {
                                NewLine.Value = line.Replace("\"ProductID\":", "").Replace("\"", "").Replace(",", "").Trim();
                                ProductId.Value = Int32.Parse(NewLine.Value);
                                Debug.WriteLine(ProductId.Value.ToString());
                            }


                           
                        }



                        // Set End point for Loop 
                        if (CounterWriteVar.Value == 2)
                        {

                            CounterWriteVar.Value = 0;
                            V_GroupStart.Value = false;

                            // Write data to the database
                            new WriteData(this).Run();
                        }





                    }




                    // Write data to the database
                    //new WriteData(this).Run();

                }


                // Write Data Branch
                internal class WriteData : BusinessProcessBase
                {
                    #region Models
                    public readonly EMS.Models.MasterData.BranchProduct BranchProduct_ = new EMS.Models.MasterData.BranchProduct();
                    #endregion

                    ImportBranchProduct _parent;
                    public WriteData(ImportBranchProduct parent)
                    {
                        _parent = parent;
                        Title = "Write Data";
                        InitializeDataView();
                    }
                    void InitializeDataView()
                    {
                        #region Relations
                        Relations.Add(BranchProduct_, RelationType.InsertIfNotFound, BranchProduct_.BranchID.IsEqualTo(_parent.BranchId).And(BranchProduct_.ProductID.IsEqualTo(_parent.ProductId)), BranchProduct_.SortByPKBranch);

                        #endregion

                        #region Column Selection and UserFlow 
                        Columns.Add(BranchProduct_.BranchID);
                        Columns.Add(BranchProduct_.ProductID);
                        //Columns.Add(BranchProduct_.Status);


                        #endregion


                    }


                    public void Run()
                    {
                        Execute();
                    }
                    protected override void OnLoad()
                    {
                        Exit(ExitTiming.AfterRow);
                        RowLocking = LockingStrategy.OnRowLoading;
                        TransactionScope = TransactionScopes.Task;

                    }
                    protected override void OnLeaveRow()
                    {
                        // Save Data to table 
                        BranchProduct_.BranchID.Value = _parent.BranchId.Value;
                        BranchProduct_.ProductID.Value = _parent.ProductId.Value;

                        //BranchProduct_.Status.Value = _parent.Status;


                    }
                }

            }



        }

        //Import XML
        internal class ImportXML : BusinessProcessBase
        {
            CN010ImportData _parent;

            #region Models 
            // public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

            #endregion
            #region COlumns 
            public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
            public readonly TextColumn P_FileType = new TextColumn("P_FileType");
            public readonly TextColumn P_Table = new TextColumn("P_Table");

            #endregion


            public ImportXML(CN010ImportData parent)
            {
                _parent = parent;
                InitializeDataViewAndUserFlow();

            }
            void InitializeDataViewAndUserFlow()
            {


                #region Column Selection and UserFlow
                Columns.Add(P_Table);
                Columns.Add(P_FilePath);

                #endregion

            }

            public void Run(TextParameter pP_Table, TextParameter pP_FilePath)
            {
                #region BindParameter
                BindParameter(P_Table, pP_Table);
                BindParameter(P_FilePath, pP_FilePath);
                #endregion
                Execute();
            }

            protected override void OnLoad()
            {
                Exit(ExitTiming.AfterRow);
            }


            protected override void OnEnterRow()
            {

            }

            //Save data to Table 
            protected override void OnLeaveRow()
            {

                if (P_Table == "B") // Branch 
                {
                    Cached<ImportBranch>().Run(P_FilePath);
                }
                if (P_Table == "P") // Product
                {
                     Cached<ImportProduct>().Run(P_FilePath);
                }
                if (P_Table == "R") // Product Branch 
                {
                    Cached<ImportBranchProduct>().Run(P_FilePath);
                }

            }



            
            // Import Branch 
            internal class ImportBranch : BusinessProcessBase
            {
                ImportXML _parent;

                #region Models
                // Updated BranchModel to match your JSON structure
                
                #endregion

                #region Columns
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
                public readonly TextColumn P_FileType = new TextColumn("P_FileType");
                public readonly TextColumn P_Table = new TextColumn("P_Table");
                public readonly BoolColumn V_Lastvalue = new BoolColumn("V_Lastvalue");

                NumberColumn counter = new NumberColumn();
                NumberColumn Id = new NumberColumn();
                TextColumn Name = new TextColumn();
                TextColumn Telephone = new TextColumn();
                DateColumn OpenDate = new DateColumn();
                TextColumn Status = new TextColumn();
                #endregion

                #region Streams
                ENV.IO.FileReader _reader;

                
                #endregion

                public ImportBranch(ImportXML parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();
                }

                void InitializeDataViewAndUserFlow()
                {
                    //XmlSerializer serializer = new XmlSerializer(typeof(BranchModel1));

                    //FileStream stream = File.OpenRead(_parent.P_FilePath);

                  //  var result = (BranchModel1)(serializer.Deserialize(stream));


                    

                    



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion

                    Execute();
                }

                protected override void OnLoad()
                {
                    _reader = new ENV.IO.FileReader(P_FilePath);
                    Streams.Add(_reader);
                    Exit(Firefly.Box.ExitTiming.BeforeRow, () => _reader.EndOfFile);

                    counter.Value = 0;
                    V_Lastvalue.Value = false;
                }

                protected override void OnEnterRow()
                {
                    
                }

                protected override void OnLeaveRow()
                {

                    counter.Value = counter.Value + 1;
                    var line = _reader.ReadLine();

                    Debug.WriteLine(line.ToString());
                    if (line == "</Branches>")
                    {
                        V_Lastvalue.Value = true;
                    }

                    // XElement branchElement = XElement.Parse(line);
                    if (counter > 2 && V_Lastvalue.Value == false)
                    {
                        XElement branchElement = XElement.Parse(line);

                        string temp = branchElement.Attribute("Branches")?.Value;
                        Id.Value = Int32.Parse(branchElement.Attribute("ID")?.Value);
                        Name.Value = branchElement.Attribute("Name")?.Value;
                        Telephone.Value = branchElement.Attribute("TelephoneNumber")?.Value;
                        OpenDate.Value = Date.Parse(branchElement.Attribute("OpenDate")?.Value,"YYYY/MM/DD");

                        Debug.WriteLine(Id.Value.ToString() +" " + Name.Value + " " + Telephone.Value + " " + OpenDate.Value.ToString() );

                        if (OpenDate.Value.ToString() == "")
                        {
                            OpenDate.Value = Date.Parse("2000/01/01", "YYYY/MM/DD");
                        }

                       new WriteData(this).Run();

                    }
                   

                    //if (counter.Value > 1)
                    //{
                    //    var split = line.Split(',');
                    //    // branch.Value = Int32.Parse(split[0]);
                    //    BranchId.Value = Int32.Parse(split[0]);
                    //    ProductId.Value = Int32.Parse(split[1]);
                    //    Status.Value = "A";

                    //    // Write Data
                    //    new WriteData(this).Run();
                    //}

                    // Map values to columns

                    //Id.Value = branch.ID;
                    //Name.Value = branch.Name.Trim();
                    //Telephone.Value = branch.TelephoneNumber.Trim();
                    //OpenDate.Value = branch.OpenDate;
                    //Status.Value = "A"; // Default status

                    //System.Windows.Forms.MessageBox.Show(branch.ID.ToString() + branch.Name.ToString() + branch.TelephoneNumber.ToString());


                    // Write data to the database
                    //new WriteData(this).Run();
                }


                // Write Data Branch
                internal class WriteData : BusinessProcessBase
                {
                    #region Models
                    public readonly EMS.Models.MasterData.Branch Branch_ = new EMS.Models.MasterData.Branch();

                    #endregion

                    ImportBranch _parent;
                    public WriteData(ImportBranch parent)
                    {
                        _parent = parent;
                        Title = "Write Data";
                        InitializeDataView();
                    }
                    void InitializeDataView()
                    {
                        #region Relations
                        Relations.Add(Branch_, RelationType.InsertIfNotFound, Branch_.Id.IsEqualTo(_parent.Id), Branch_.SortByPkBranch);

                        #endregion

                        #region Column Selection and UserFlow 
                        Columns.Add(Branch_.Id);
                        Columns.Add(Branch_.Name);
                        Columns.Add(Branch_.TelephoneNumber);
                        Columns.Add(Branch_.OpenDate);
                        Columns.Add(Branch_.Status);


                        #endregion


                    }


                    public void Run()
                    {
                        Execute();
                    }
                    protected override void OnLoad()
                    {
                        Exit(ExitTiming.AfterRow);
                        RowLocking = LockingStrategy.OnRowLoading;
                        TransactionScope = TransactionScopes.Task;

                    }
                    protected override void OnLeaveRow()
                    {
                        // Save Data to table 
                        Branch_.Id.Value = _parent.Id.Value;
                        Branch_.Name.Value = _parent.Name.Value;
                        Branch_.TelephoneNumber.Value = _parent.Telephone.Value;
                        Branch_.OpenDate.Value = Date.Now;
                        Branch_.Status.Value = "A";


                    }
                }

            }

            // Import Product 
            internal class ImportProduct : BusinessProcessBase
            {
                ImportXML _parent;

                #region Models
                // Updated BranchModel to match your JSON structure
                #endregion
                #region Columns
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
                public readonly TextColumn P_FileType = new TextColumn("P_FileType");
                public readonly TextColumn P_Table = new TextColumn("P_Table");

                public readonly NumberColumn V_CounterStart = new NumberColumn("V_CounterStart");
                public readonly BoolColumn V_EndOfFile = new BoolColumn("V_EndOfFile");
                public readonly BoolColumn V_GroupStart = new BoolColumn("V_GroupStart");
                public readonly BoolColumn V_EndOfGroup = new BoolColumn("V_EndOfGroup");
                public readonly BoolColumn V_Lastvalue = new BoolColumn("V_Lastvalue");


                NumberColumn counter = new NumberColumn();
                NumberColumn Id = new NumberColumn();
                TextColumn Name = new TextColumn();
                TextColumn Weighted = new TextColumn();
                TextColumn Temp = new TextColumn();
                TextColumn TextSuggestPrice = new TextColumn();
                NumberColumn SuggestPrice = new NumberColumn("SuggestPrice", "12.2");
                TextColumn Status = new TextColumn();


                NumberColumn CounterWriteVar = new NumberColumn();

                TextColumn Ident = new TextColumn();



                TextColumn IdentWeighted = new TextColumn();
                NumberColumn TempSuggestPrice = new NumberColumn();
                TextColumn TempIdentSuggestPrice = new TextColumn();
                TextColumn IdentSuggestPrice = new TextColumn();


                float TempSuggested;



                #endregion
                #region Streams
                ENV.IO.FileReader _reader;


                #endregion


                public ImportProduct(ImportXML parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();
                }

                void InitializeDataViewAndUserFlow()
                {



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion

                    Execute();
                }

                protected override void OnLoad()
                {
                    _reader = new ENV.IO.FileReader(P_FilePath);
                    Streams.Add(_reader);
                    Exit(Firefly.Box.ExitTiming.BeforeRow, () => _reader.EndOfFile);

                    counter.Value = 0;
                  

                }

                protected override void OnStart()
                {
                    V_CounterStart.Value = 0;
                    V_EndOfFile.Value = false;
                    V_GroupStart.Value = false;
                    V_EndOfGroup.Value = false;
                    CounterWriteVar.Value = 0;

                }

                protected override void OnEnterRow()
                {

                }

                protected override void OnLeaveRow()
                {

                    counter.Value = counter.Value + 1;
                    var line = _reader.ReadLine();

                   // Debug.WriteLine(line.ToString());
                    if (line == "</Products>")
                    {
                        V_Lastvalue.Value = true;
                    }

                    // XElement branchElement = XElement.Parse(line);
                    if (counter > 2 && V_Lastvalue.Value == false)
                    {
                        XElement productElement = XElement.Parse(line);

                        
                        Id.Value = Int32.Parse(productElement.Attribute("ID")?.Value);
                        Name.Value = productElement.Attribute("Name")?.Value;
                        Weighted.Value = productElement.Attribute("WeightedItem")?.Value;
                        TextSuggestPrice.Value = productElement.Attribute("SuggestedSellingPrice")?.Value;

                        // Convert value from file to Decimal 
                        if (float.TryParse(TextSuggestPrice.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out float parsedValue))
                        {
                            TempSuggested = parsedValue;
                            //Debug.WriteLine(TempSuggested.ToString("F2")); // Format to 2 decimal places
                        }
                        SuggestPrice.Value = TempSuggested;

                        //SuggestPrice.Value = Date.Parse(branchElement.Attribute("OpenDate")?.Value, "YYYY/MM/DD");

                        if (Weighted == "")
                        {
                            Weighted.Value = "N";
                        }
                        if (Weighted == "0")
                        {
                            Weighted.Value = "N";
                        }
                        if (Weighted == "1")
                        {
                            Weighted.Value = "Y";
                        }
                        if (TextSuggestPrice.Value == "")
                        {
                            SuggestPrice.Value = 0;
                        }


                        

                        Debug.WriteLine(Id.Value.ToString() + " " + Name.Value + " " + Weighted + " " + SuggestPrice.Value.ToString());

                        //if (OpenDate.Value.ToString() == "")
                        //{
                         //   OpenDate.Value = Date.Parse("2000/01/01", "YYYY/MM/DD");
                       // }

                        new WriteData(this).Run();

                    }



                    // Write data to the database
                    //new WriteData(this).Run();

                }


                // Write Data Branch
                internal class WriteData : BusinessProcessBase
                {
                    #region Models
                    public readonly EMS.Models.MasterData.Product Product_ = new EMS.Models.MasterData.Product();

                    #endregion

                    ImportProduct _parent;
                    public WriteData(ImportProduct parent)
                    {
                        _parent = parent;
                        Title = "Write Data";
                        InitializeDataView();
                    }
                    void InitializeDataView()
                    {
                        #region Relations
                        // Relations.Add(Branch_, RelationType.InsertIfNotFound, Branch_.Id.IsEqualTo(_parent.Id), Branch_.SortByPkBranch);
                        Relations.Add(Product_, RelationType.InsertIfNotFound, Product_.Id.IsEqualTo(_parent.Id), Product_.SortByPKProduct);

                        #endregion

                        #region Column Selection and UserFlow 
                        Columns.Add(Product_.Id);
                        Columns.Add(Product_.Name);
                        Columns.Add(Product_.WeightedItem);
                        Columns.Add(Product_.SuggestedSellingPrice);
                        Columns.Add(Product_.Status);


                        #endregion


                    }


                    public void Run()
                    {
                        Execute();
                    }
                    protected override void OnLoad()
                    {
                        Exit(ExitTiming.AfterRow);
                        RowLocking = LockingStrategy.OnRowLoading;
                        TransactionScope = TransactionScopes.Task;

                    }
                    protected override void OnLeaveRow()
                    {
                        // Save Data to table 
                        Product_.Id.Value = _parent.Id.Value;
                        Product_.Name.Value = _parent.Name.Value;
                        if (_parent.Weighted == "N")
                        {
                            Product_.WeightedItem.Value = false;
                        }
                        else
                        {
                            Product_.WeightedItem.Value = true;
                        }

                        Product_.SuggestedSellingPrice.Value = _parent.SuggestPrice;
                        Product_.Status.Value = "A";


                    }
                }

            }

            // Import Branch Product
            internal class ImportBranchProduct : BusinessProcessBase
            {
                ImportXML _parent;

                #region Models


                #endregion
                #region Columns
                public readonly TextColumn P_FilePath = new TextColumn("P_FilePath");
                public readonly TextColumn P_FileType = new TextColumn("P_FileType");
                public readonly TextColumn P_Table = new TextColumn("P_Table");

                public readonly NumberColumn V_CounterStart = new NumberColumn("V_CounterStart");
                public readonly BoolColumn V_EndOfFile = new BoolColumn("V_EndOfFile");
                public readonly BoolColumn V_GroupStart = new BoolColumn("V_GroupStart");
                public readonly BoolColumn V_EndOfGroup = new BoolColumn("V_EndOfGroup");
                public readonly BoolColumn V_Lastvalue = new BoolColumn("V_Lastvalue");

                NumberColumn counter = new NumberColumn();
                NumberColumn BranchId = new NumberColumn();
                NumberColumn ProductId = new NumberColumn();


                NumberColumn CounterWriteVar = new NumberColumn();

                TextColumn Ident = new TextColumn();
                TextColumn NewLine = new TextColumn();
                TextColumn tempNewLine = new TextColumn();
                TextColumn TempProduct = new TextColumn();


                #endregion
                #region Streams
                ENV.IO.FileReader _reader;


                #endregion


                public ImportBranchProduct(ImportXML parent)
                {
                    _parent = parent;
                    InitializeDataViewAndUserFlow();
                }

                void InitializeDataViewAndUserFlow()
                {



                }

                public void Run(TextParameter pP_FilePath)
                {
                    #region BindParameter
                    BindParameter(P_FilePath, pP_FilePath);
                    #endregion

                    Execute();
                }

                protected override void OnLoad()
                {
                    _reader = new ENV.IO.FileReader(P_FilePath);
                    Streams.Add(_reader);
                    Exit(Firefly.Box.ExitTiming.BeforeRow, () => _reader.EndOfFile);

                    counter.Value = 0;


                }

                protected override void OnStart()
                {
                    V_CounterStart.Value = 0;
                    V_EndOfFile.Value = false;
                    V_GroupStart.Value = false;
                    V_EndOfGroup.Value = false;
                    
                    CounterWriteVar.Value = 0;

                }

                protected override void OnEnterRow()
                {

                }

                protected override void OnLeaveRow()
                {

                    counter.Value = counter.Value + 1;
                    var line = _reader.ReadLine();

                    Debug.WriteLine(line.ToString());
                    if (line == "</Mappings>")
                    {
                        V_Lastvalue.Value = true;
                    }

                    // XElement branchElement = XElement.Parse(line);
                    if (counter > 2 && V_Lastvalue.Value == false)
                    {
                        XElement branchElement = XElement.Parse(line);

                       // string temp = branchElement.Attribute("Branches")?.Value;
                        BranchId.Value = Int32.Parse(branchElement.Attribute("BranchID")?.Value);
                        ProductId.Value = Int32.Parse(branchElement.Attribute("ProductID")?.Value);
                       

                        Debug.WriteLine(BranchId.Value.ToString() + " " + ProductId.Value + " " );

                        

                        new WriteData(this).Run();

                    }

                }             


                // Write Data Branch
                internal class WriteData : BusinessProcessBase
                {
                    #region Models
                    public readonly EMS.Models.MasterData.BranchProduct BranchProduct_ = new EMS.Models.MasterData.BranchProduct();
                    #endregion

                    ImportBranchProduct _parent;
                    public WriteData(ImportBranchProduct parent)
                    {
                        _parent = parent;
                        Title = "Write Data";
                        InitializeDataView();
                    }
                    void InitializeDataView()
                    {
                        #region Relations
                        Relations.Add(BranchProduct_, RelationType.InsertIfNotFound, BranchProduct_.BranchID.IsEqualTo(_parent.BranchId).And(BranchProduct_.ProductID.IsEqualTo(_parent.ProductId)), BranchProduct_.SortByPKBranch);

                        #endregion

                        #region Column Selection and UserFlow 
                        Columns.Add(BranchProduct_.BranchID);
                        Columns.Add(BranchProduct_.ProductID);
                        //Columns.Add(BranchProduct_.Status);


                        #endregion


                    }


                    public void Run()
                    {
                        Execute();
                    }
                    protected override void OnLoad()
                    {
                        Exit(ExitTiming.AfterRow);
                        RowLocking = LockingStrategy.OnRowLoading;
                        TransactionScope = TransactionScopes.Task;

                    }
                    protected override void OnLeaveRow()
                    {
                        // Save Data to table 
                        BranchProduct_.BranchID.Value = _parent.BranchId.Value;
                        BranchProduct_.ProductID.Value = _parent.ProductId.Value;

                        //BranchProduct_.Status.Value = _parent.Status;


                    }
                }



            }




        }


    }
}
