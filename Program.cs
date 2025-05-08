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
            Console.WriteLine($"Working into the {DOD.Value.DogOwnerList.Count()} data records in file {DOD.Key} -->");

            Console.WriteLine("\n Input race to filter or enter to skip or h to show race posibilities");
            Input = Console.ReadLine();
            if (Input == "h")
            {
                DOD.Value.ShowRaces();
                Console.WriteLine("\n Input race to filter or enter to skip");
                Input = Console.ReadLine();
            }
            if (!(Input == ""))
            {
                DOD.Value.SelectRace(Input);
                Console.WriteLine($"{DOD.Value.DogOwnerList.Count()} Dogs from the race {Input} where selected");
            }

            Console.WriteLine("\n Input district to filter or enter to skip");
            Input = Console.ReadLine();
            if (!(Input == ""))
            {
                DOD.Value.SelectDistrict(Input);
                Console.WriteLine($"{DOD.Value.DogOwnerList.Count()} Dogs from the district {Input} where selected");
            }
            DOD.Value.Print();
            DOD.Value.GroupingRPT();
        }

    }
}
