using ENV.WebServices;
namespace EMS.Shared.WebServices
{
    public class HoffNET_WebService : WebService 
    {
        public HoffNET_WebService() : base(ENV.UserSettings.GetWebServiceInfo("Hoff NET Web Service"))
        {
        }
    }
}
