namespace FF.Contracts.Service
{
    public interface IFileService
    {
        string[] ReadAllLines(string filePath);
    }
}
