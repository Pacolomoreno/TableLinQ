
public class LocalFile(string filePath)
{
    public string FilePath = filePath;
    public int Lines = 0;

    public Boolean Exist()
    {
        return File.Exists(FilePath);
    }
    public string[] Read(Boolean debug = false)
    {
        string[] contents = File.ReadAllLines(FilePath);
        Lines = contents.Length;

        Console.WriteLine($" File {FilePath} was readed, we got {Lines}  Lines ");

        //  LOG FOR DEBUGGING 
        if (debug)
        {
            Console.WriteLine($"Showing Strings fra content....");
            foreach (string content in contents)
            {
                Console.WriteLine(content);
            }

        }
        return contents;
    }
}