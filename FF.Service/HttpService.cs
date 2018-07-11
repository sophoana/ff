using FF.Contracts.Service;
using System;
using NLog;


namespace FF.Service
{
    public class HttpService : IHttpService
    {
        private IWebClient _webClient;
        private ILogger _log;

        public HttpService(IWebClient webClient, ILogger log)
        {
            _webClient = webClient;
            _log = log;
        }

        public string GetResponse(string url)
        {
            _log.Debug("GetResponse for {0}", url);
            return _webClient.DownloadString(url);
        }

        public void GetResponse<T>(Uri uri, Action<T> callback, ISerialize serializer) 
            where T : class
        {
            _log.Debug("GetResponse<T> for {0}", uri.OriginalString);
            _webClient.OpenReadCompleted += (o, a) =>
            {
                if (callback == null) return;
                callback(serializer.ReadObject(a.Result) as T);
            };
            _webClient.OpenReadAsync(uri);
        }

    }
}
