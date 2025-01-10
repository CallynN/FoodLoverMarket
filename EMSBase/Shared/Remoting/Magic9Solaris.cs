using ENV.Remoting;
namespace EMS.Shared.Remoting
{
    public class Magic9Solaris : HttpApplication 
    {
        public Magic9Solaris() : base(ENV.UserSettings.GetApplicationServerUrl("Magic9Solaris"))
        {
        }
    }
}
