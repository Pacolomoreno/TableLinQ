namespace TableLinQ;

class Program
{
    static void Main(string[] args)
    {
        const string PathDog2015 = "./data/dogs2015.csv";
        const string PathDog2016 = "./data/dogs2016.csv";
        const string PathDog2017 = "./data/dogs2017.csv";
        const string PathDogSample = "./data/dogSample.csv";

        var Data2015 = new DogOwnerData(PathDogSample);
        Data2015.Load(true);
        // Console.WriteLine(Data2015.GetHashCode());
    }
}
