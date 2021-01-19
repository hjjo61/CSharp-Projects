using System;
using static System.Console;

namespace Bme121
{
    static partial class Program
    {
        class CauseOfDeathInfo
        {
            public string death;
            public string year;
            public string age;
            public string sex;
            public int numDeaths;
            public double percentDeaths;
            public double mortality;
            
            //Constructor
            public CauseOfDeathInfo(string death, string year, string age, string sex, int numDeaths, double percentDeaths, double mortality)
            {
                this.death = death;
                this.year = year;
                this.age = age;
                this.sex = sex;
                this.numDeaths = numDeaths;
                this.percentDeaths = percentDeaths;
                this.mortality = mortality;
            }
            
            public string GetCauseOfDeath()
            {
                return this.death;
            }
            
            public int GetNumberOfDeaths()
            {
                return this.numDeaths;
            }
            
            public string GetYear()
            {
                return this.year;
            }
            
            public string GetAgeRange()
            {
                return this.age;
            }
        }
        static void Main( )
        {
            // Load the array of CauseOfDeathInfo objects.
            CauseOfDeathInfo[ ] stats = MakeStatsArray( );
            WriteLine( "stats.Length={0}", stats.Length );
            
            //Getting and displaying total number of deaths from Salmonella infections.
            int salmonellaDeaths = 0;
            for(int i = 0; i < stats.Length; i++)
            {
                if(stats[i].GetCauseOfDeath() == "Salmonella infections")
                {
                    salmonellaDeaths += stats[i].GetNumberOfDeaths();
                }
            }
            WriteLine($"Total deaths due to Salmonella infections in 2009 to 2018 are {salmonellaDeaths}.");
            
            //Getting and displaying total number of deaths in 2017 from ages 15-24 years.
            int deathCounter = 0;
            for(int i = 0; i < stats.Length; i++)
            {
                if(stats[i].GetYear() == "2017" && stats[i].GetAgeRange() == "15-24 years")
                {
                    deathCounter += stats[i].GetNumberOfDeaths();
                }
            }
            WriteLine($"Total deaths for 2017 in the 15-24 years age range are {deathCounter}");
        }
    }
}
