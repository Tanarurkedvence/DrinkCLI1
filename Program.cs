namespace DrinkCLI1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            using(StreamReader o = new StreamReader("../../../forras/drink.txt"))
            {
                o.ReadLine();
                while (!o.EndOfStream)
                {
                    string line = o.ReadLine();
                    citizens.Add(new Citizen(line));
                }
            }
            Console.WriteLine("5. feladat");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(citizens[i].ToString());
            }

            Console.WriteLine("6. feladat");
            var f6 = citizens.Where(x => x.Drinking == "Yes"
            && x.Nationality.NationalityName == "Birthright citizen"
            && x.State == "Florida"
            && x.Gender == "Male"
            //&& !x.NetIncome.Contains("Unknown")
            //&& !x.NetIncome.Contains("Refused")
            //&& !x.NetIncome.Contains("Above")
            //&& !x.NetIncome.Contains("Under"))
            && x.NetIncome.Contains(" to "));

            if (f6.Any())
            {
                foreach (var asd in f6)
                {
                    Console.WriteLine(asd);
                }
                int kisebb = f6.Select(x => int.Parse(x.NetIncome.Split(" to ")[0])).Min();
                Console.WriteLine($"A kiválogatott állampolgárok lehető legkisebb jövedelme USA dollárban: {kisebb}");
                
            }
            Console.WriteLine();
            Console.WriteLine("7. feladat: Fájlba írás");

            var f7 = citizens.Where(x => x.Age >= 18 && x.Age <= 65
            && x.PopulationGroup.PopulationGroupName == "Asian"
            && x.Drinking == "Yes").OrderBy(x => x.State);

            using(StreamWriter i = new StreamWriter("../../../forras/asian.txt"))
            {
                foreach(var asd in f7)
                {
                    i.WriteLine($"{asd.Age},{asd.State},{asd.SchoolDropout}");
                }
            }
    }
}
    }