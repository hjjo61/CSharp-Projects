using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
            
            Write("Name: ");
            string name = ReadLine();
           
            Write("Age (years): ");
            double age = double.Parse(ReadLine());
            
            Write("Height (cm): ");
            double height = double.Parse(ReadLine());
            
            Write("Weight (kg): ");
            double weight = double.Parse(ReadLine());
            
            Write("Sex (F/M): ");
            string sex = ReadLine();
            
            double energy = 0;
            
            if(sex == "F")
            {
                energy = (10 * weight) + (6.25 * height) - (5 * age) - 161;
            }
            else
            {
                energy = (10 * weight) + (6.25 * height) - (5 * age) + 5;

            }
            
            WriteLine("Resting energy expenditure (cal/day): " + energy);
            
        }
    }
}
