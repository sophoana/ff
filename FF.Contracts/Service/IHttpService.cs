using System;

namespace FF.Contracts.Service
{
    public interface IHttpService
    {
        void GetResponse<T>(Uri uri, Action<T> callback, ISerialize serializer) where T : class;

        string GetResponse(string url);

    }

}
