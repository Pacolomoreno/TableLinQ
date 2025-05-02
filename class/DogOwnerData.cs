
public class DogOwnerData(string path)
{
    public string filePath = path;
    public List<DogOwner> DogOwnerList = new List<DogOwner>();
    public void Load(Boolean debug = false)
    {
        LocalFile DogsStringArray = new LocalFile(filePath);
        if (DogsStringArray.Exist())
        {
            string[] lines = DogsStringArray.Read();
            string[] fields = new string[13];

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

    }

}