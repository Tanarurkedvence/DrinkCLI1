using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkCLI1
{
    internal class Citizen
    {
        static int counter = 1;
        public Citizen(string l)
        {
            var r = l.Split(";");
            Age = int.Parse(r[0]);
            CitizenId = counter++;
            Drinking = r[1];
            DrinkingWeekdays = r[2] == "NO" ? 0 : int.Parse(r[2]);
            DrinkingWeekends = r[3] == "NO" ? 0 : int.Parse(r[3]);
            Gender = r[4];
            Nationality = new Nationality()
            {
                NationalityID = int.Parse(r[5]),
                NationalityName = r[6] 
            };
            NetIncome = r[7];
            PopulationGroup = new PopulationGroup()
            {
                PopulationGroupID = int.Parse(r[8]),
                PopulationGroupName = r[9]
            };
            SchoolDropout = r[10];
            State = r[11];
            Treatment = int.Parse(r[12]) == 1;
        }

        public int Age { get; set; }
        public int CitizenId { get; set; }
        public string Drinking { get; set; }
        public int DrinkingWeekdays { get; set; }
        public int DrinkingWeekends { get; set; }
        public string Gender { get; set; }
        public Nationality Nationality { get; set; }
        public string NetIncome { get; set; }
        public PopulationGroup PopulationGroup { get; set; }
        public string SchoolDropout { get; set; }
        public string State { get; set; }
        public bool Treatment { get; set; }

        public double Average()
        {
            if(Drinking == "No")
            {
                return double.NaN;
            }
            else
            {
                return Math.Round(((double)DrinkingWeekdays * 5 + DrinkingWeekends * 2) / 7, 2);
            }
           
        }
        public override string ToString()
        {
            return $"\t Citizen Id: {CitizenId}\n" +
                   $"\t Age: {Age}\n" +
                   $"\t Drinking: {Drinking}\n" +
                   $"\t Drinking on weekdays: {(DrinkingWeekdays == 0 ? "NO" : DrinkingWeekdays.ToString())} \n" +
                   $"\t Drinking on weekends: {(DrinkingWeekends == 0 ? "NO" : DrinkingWeekends.ToString())} \n" +
                   $"\t Gender: {Gender} \n" +
                   $"\t Nationality: {Nationality.NationalityName} \n" +
                   $"\t Net income: {NetIncome} USD\n" +
                   $"\t Population Group: {PopulationGroup.PopulationGroupName} \n" +
                   $"\t Drop out from school: {SchoolDropout} \n" +
                   $"\t State: {State} \n" +
                   $"\t Treatment: {Treatment} \n" +
                   $"\t Avarage drinking: {Average()}\n";
        }
    }
}
