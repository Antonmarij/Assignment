namespace Contacts.Services;

public class FileService
{
    public static async Task SaveToFileAsync(string filePath, string content)
    {
        using StreamWriter sw = new StreamWriter(filePath);
        await sw.WriteLineAsync(content);
    }

} 
