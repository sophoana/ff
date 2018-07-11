using System;
using System.Net;

namespace FF.Contracts.Service
{
    public interface IWebClient
    {
        string DownloadString(string url);

        event OpenReadCompletedEventHandler OpenReadCompleted;

        void OpenReadAsync(Uri address);

    }
}
