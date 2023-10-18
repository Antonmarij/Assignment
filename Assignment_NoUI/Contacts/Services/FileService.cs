namespace Contacts.Services;

public class FileService
{
    //sparar till fil
    public static void SaveToFile(string filePath, string content)
    {
        //streamwriter append är true, vilket gör att contentet blir tillagt i slutet av filen.
        using StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine(content);
    }

    public static string ReadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        return null!;
    }

} 
