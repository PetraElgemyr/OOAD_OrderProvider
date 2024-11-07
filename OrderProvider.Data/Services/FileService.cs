using OrderProvider.Data.Interfaces;

namespace OrderProvider.Data.Services;

public class FileService : IFileService
{
    public string GetContentFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using var sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }
            return null!;
        }
        catch (Exception ex)
        {
            return null!;
        }
    }

    public bool SaveToFile(string content, string filePath)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);

            return true;

        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
