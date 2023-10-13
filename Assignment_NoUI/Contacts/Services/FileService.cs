namespace Contacts.Services;

public class FileService
{
    public static void SaveToFile(string filePath, string content)
    {
        using StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLineAsync(content);
    }

} 
