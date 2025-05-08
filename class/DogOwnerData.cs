
public class DogOwnerData()
{
    public List<DogOwner> DogOwnerList = new List<DogOwner>();
    public void Load(string filePath, Boolean debug = false)
    {
        LocalFile DogsStringArray = new LocalFile(filePath);
        if (DogsStringArray.Exist())
        {
            string[] lines = DogsStringArray.Read(debug);
            string[] fields = new string[13];
            if (debug)
            {
                Console.WriteLine("Fetching data...");
                Console.WriteLine("| OwnID | OwnAge | Sex | Dist | Quart | DgMom | DgMom2 | DgDad | DgDad2 | DgType | BirthYear | DgGender | DgColor "); Console.WriteLine("====================================================================================================================");
            }

            foreach (string line in lines)
            {
                fields = line.Split(",");

                // DEBUGGING LIST OF CONTENT
                if (debug)
                {

                    foreach (string field in fields)
                    {
                        Console.Write($" | {field}");
                    }
                    Console.WriteLine("\n____________________________________________________________________________________________________________________");
                }

                // FETCHING LINE II OBJECT
                var DO = new DogOwner()
                {
                    // isNaN(numero) ? valorPorDefecto : numero;
                    OwnerId = Int32.Parse(fields[0]),
                    OwnerAgeRange = fields[1],
                    OwnerGender = fields[2] == "" ? '?' : fields[2][0],
                    CityDistrict = fields[3] == "" ? 0 : Int32.Parse(fields[3]),
                    CityQuarter = fields[4] == "" ? 0 : Int32.Parse(fields[4].Replace("\"", "")),
                    Breed1 = fields[5],
                    Breed1Mix = fields[6],
                    Breed2 = fields[7],
                    Breed2Mix = fields[8],
                    Breed_Type = fields[9] == "" ? '?' : fields[9][0],
                    DogBirthYear = fields[10] == "" ? 0 : Int32.Parse(fields[10]),
                    DogGender = fields[11] == "" ? '?' : fields[11][0],
                    DogColor = fields[12],
                };

                // Adding to Object list DogOwnerList
                DogOwnerList.Add(DO);
            }

        }
        else
        {
            Console.WriteLine($"File not found {filePath} !!");
        }


    }
    public void ShowRaces()
    {
        var DogRaceList = DogOwnerList.Select(DO => DO.Breed1);
        foreach (var race in DogRaceList)
        {
            Console.Write(race + "\t");
        }

    }
    public void SelectRace(string RaceSelected)
    {
        var DogRaceList = DogOwnerList.Where(DO => DO.Breed1 == RaceSelected);
        DogOwnerList = DogRaceList.ToList();
    }
    public void Print()
    {
        Console.WriteLine("| OwnID | OwnAge | Sex | Dist | Quart | DgMom | DgMom2 | DgDad | DgDad2 | DgType | BirthYear | DgGender | DgColor ");
        Console.WriteLine("====================================================================================================================");
        foreach (var line in DogOwnerList)
        {

            Console.WriteLine($" | {line.OwnerId} | {line.OwnerAgeRange} | {line.OwnerGender} | {line.CityDistrict} | {line.CityQuarter} | {line.Breed1} | {line.Breed1Mix} | {line.Breed2} | {line.Breed2Mix} | {line.Breed_Type} | {line.DogBirthYear} | {line.DogGender} | {line.DogColor} ");
            Console.WriteLine("____________________________________________________________________________________________________________________");
        }

    }
    public void SelectDistrict(String District)
    {
        Console.WriteLine($"Selction of records in district {District}");
        var FilteredList = from DO in DogOwnerList

                           where DO.CityDistrict == Int32.Parse(District)

                           select DO;
        DogOwnerList = FilteredList.ToList();
    }

    public void GroupingRPT()
    {
        string? Input;
        Console.WriteLine("INSERT GROUP FIELD FROM THE FOLLOWING : \n 1 - OwnerId \n 2 - OwnerAgeRange \n 3 - OwnerGender \n 4 - CityDistrict \n 5 - Breed1 \n 6 - Breed_Type \n 7 - DogBirthYear \n 8 - DogGender \n 9 - DogColor ");
        Input = Console.ReadLine();
        switch (Input)
        {
            case "1":
                var ListGrp = DogOwnerList.GroupBy(DO => DO.OwnerId);
                foreach (var item in ListGrp)
                    Console.WriteLine($"After the grouping {item.Key} has {item.Count()} items");
                break;
            case "2":
                var ListGrp2 = DogOwnerList.GroupBy(DO => DO.OwnerAgeRange);
                foreach (var item in ListGrp2)
                    Console.WriteLine($"After the grouping {item.Key} has {item.Count()} items");
                break;
            case "3":
                var ListGrp3 = DogOwnerList.GroupBy(DO => DO.OwnerGender);
                foreach (var item in ListGrp3)
                    Console.WriteLine($"After the grouping {item.Key} has {item.Count()} items");
                break;
            case "4":
                var ListGrp4 = DogOwnerList.GroupBy(DO => DO.CityDistrict);
                foreach (var item in ListGrp4)
                    Console.WriteLine($"After the grouping {item.Key} has {item.Count()} items");
                break;
            case "5":
                var ListGrp5 = DogOwnerList.GroupBy(DO => DO.Breed1);
                foreach (var item in ListGrp5)
                    Console.WriteLine($"After the grouping {item.Key} has {item.Count()} items");
                break;
            case "6":
                var ListGrp6 = DogOwnerList.GroupBy(DO => DO.Breed_Type);
                foreach (var item in ListGrp6)
                    Console.WriteLine($"After the grouping {item.Key} has {item.Count()} items");
                break;
            case "7":
                var ListGrp7 = DogOwnerList.GroupBy(DO => DO.DogBirthYear);
                foreach (var item in ListGrp7)
                    Console.WriteLine($"After the grouping {item.Key} has {item.Count()} items");
                break;
            case "8":
                var ListGrp8 = DogOwnerList.GroupBy(DO => DO.DogGender);
                foreach (var item in ListGrp8)
                    Console.WriteLine($"After the grouping {item.Key} has {item.Count()} items");
                break;
            case "9":
                var ListGrp9 = DogOwnerList.GroupBy(DO => DO.DogColor);
                foreach (var item in ListGrp9)
                    Console.WriteLine($"After the grouping {item.Key} has {item.Count()} items");
                break;
            default:
                break;


        }


    }

}
