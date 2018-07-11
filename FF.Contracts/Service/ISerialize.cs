using System.IO;

namespace FF.Contracts.Service
{
    public interface ISerialize
    {
        object ReadObject(Stream stream);
    }
}
