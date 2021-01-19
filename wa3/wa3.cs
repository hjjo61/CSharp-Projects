using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
            Write("Enter a number of three or more: ");
            int number = int.Parse(ReadLine());
            
            for(int numberBase = 2; numberBase < number; numberBase++)
            {
                int[] final = Convert(number, numberBase);
                for(int i = final.Length - 1; i >= 0; i--)
                {
                    if(i > 0 && final[i] < final[i-1]) break;
                   
                    if(i == 0)
                    {
                        Write($"The base-10 integer {number} expressed in base {numberBase} is ");
                        for(int j = final.Length - 1; j >= 0; j--)
                        {
                            if(numberBase > 10)
                            {
                                if(j == 0) Write(final[j]);
                                else       Write($"{final[j]},");
                            }
                            else           Write(final[j]);
                            if(j == 0)
                            {
                                WriteLine();
                            }
                        }
                    }
                }
                
            }
            
        }
        
        static int[] Convert(int number, int numberBase)
        {
            if(number < 0) throw new ArgumentOutOfRangeException( nameof(number),
                "The number must be nonnegative.");
            
            if(numberBase < 2) throw new ArgumentOutOfRangeException( nameof(numberBase),
                "The base must be two or more.");
            
            int counter = 0;
            
            for(int i = number; i > 0; i = i/numberBase) counter++;
            
            int[] result = new int[counter];
            
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = number % numberBase;
                number = number/numberBase;
            }
            return result;
        }
        
    }
}
