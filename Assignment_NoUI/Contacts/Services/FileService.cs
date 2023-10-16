namespace Contacts.Services;

public class FileService
{
    //sparar till fil som den ska men skriver över varje gång, kanske inte spelar roll?
    public static void SaveToFile(string filePath, string content)
    {
        using StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLineAsync(content);
    }

} 
