using System;
using System.Net;
using FF.Contracts.Service;

namespace FF.Service
{
    public class WebClient : IWebClient
    {
        public string DownloadString(string url)
        {
            using (var client = new System.Net.WebClient())
            {
                return client.DownloadString(url);
            }
        }

        public event OpenReadCompletedEventHandler OpenReadCompleted;
        public void OpenReadAsync(Uri address)
        {
            throw new NotImplementedException();
        }
    }
}
