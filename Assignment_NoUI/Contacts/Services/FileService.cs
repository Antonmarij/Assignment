namespace Contacts.Services;

public class FileService
{
    //sparar till fil
    public static void SaveToFile(string filePath, string content)
    {
        //streamwriter append är true, vilket gör att contentet blir tillagt i slutet av filen.
        using StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLineAsync(content);
    }

} 
