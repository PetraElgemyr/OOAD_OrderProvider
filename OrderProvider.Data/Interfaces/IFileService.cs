namespace OrderProvider.Data.Interfaces;

public interface IFileService
{
    public bool SaveToFile(string content, string filePath);
    public string GetContentFromFile(string filePath);
}
