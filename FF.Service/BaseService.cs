using System;
using NLog;
using System.Net.Http;
using FF.Contracts.Service;
using Newtonsoft.Json;

namespace FF.Service
{
    public abstract class BaseService
    {
        protected Logger Log { get; private set; }
        private static string _lastIpLookedUp = "";
        private ISecurityService _securityService;

        protected BaseService()
        {
            Log = LogManager.GetCurrentClassLogger();
            _securityService = SecurityService.Instance;
            LogUserInfo(_securityService.UserIpAddress());
        }

        private bool LogUserInfo(string ipAddress)
        {
            
            var url = "http://api.ipinfodb.com/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers
                    .MediaTypeWithQualityHeaderValue("application/json"));

                var response = "";
                try
                {
                    response =
                        client.GetStringAsync(
                            string.Format("v2/ip_query.php?key=1092938281209&ip={0}&timezone=false",
                            ipAddress)).ToString();

                    var info = JsonConvert.DeserializeObject<dynamic>(response);

                    if (info != null && info.loc != null && info.loc.ToString() != _lastIpLookedUp)
                    {
                        var dal = new FF.Data.InfoLoggerDal();
                        dal.SaveIpAddress(info.loc.ToString(), _securityService.CurrentUser());
                        _lastIpLookedUp = info.loc.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Log.Warn("The call to ipinfo faied");
                    throw new Exception("The call to ipinfo faied");
                }
            }
            return true;
        }


    }
}
