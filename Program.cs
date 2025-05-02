namespace TableLinQ;

class Program
{
    static Dictionary<string, DogOwnerData> MainDataSrc = new Dictionary<string, DogOwnerData>();
    static void Main(string[] args)
    {
        // In case of missing data files , launch datafile file selection procedure for ./data/*.csv
        if (args.Length < 1)
        {
            LocalFile show = new LocalFile(Environment.CurrentDirectory + "\\data");
            args = show.SelectFiles("*.csv").ToArray();
        }

        // Loop to charge each csv data file in a list of "DogOwnerData" dataSets called "MainDataSource"
        foreach (var file in args)
        {
            Console.WriteLine(file);
            DogOwnerData DOdata = new DogOwnerData(file);
            DOdata.Load(true); // pass true as param for debug
            MainDataSrc.Add(file, DOdata);
        }
    }
}
