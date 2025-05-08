using System.Numerics;

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
            DogOwnerData DOdata = new DogOwnerData();
            DOdata.Load(file); // pass true as param for debug
            MainDataSrc.Add(file, DOdata);
        }

        foreach (var DOD in MainDataSrc)
        {
            string? Input;
            Console.WriteLine($"Races in {DOD.Key} -->");
            DOD.Value.ShowRaces();
            Console.WriteLine("\n Input race to filter");
            Input = Console.ReadLine();
            DOD.Value.SelectRace(Input);
            DOD.Value.Print();

            Console.WriteLine("\n Input district to filter");
            Input = Console.ReadLine();
            DOD.Value.SelectDistrict(Input);
            DOD.Value.Print();
        }

    }
}
