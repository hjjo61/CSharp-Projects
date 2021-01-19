using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {

            Write("Enter a number: ");
            int num = int.Parse(ReadLine());
            int storeNum = num;
            Write("Enter a base: ");
            int baseNum = int.Parse(ReadLine());
            int counter = 0;
            
            if(num < 0 || baseNum < 2)
            {
                WriteLine("Invalid entry.");
                return;
            }
            
            for(int i = num; i > 0; i = i/baseNum)
            {
                counter++;
            }
            
            int[] final = new int[counter];
            
            
            for(int i = counter - 1; i >= 0; i--)
            {
                final[i] = num % baseNum;
                num = num/baseNum;
            }
            
            Write($"{storeNum} in base {baseNum} is ");
            
            for(int i = 0; i < final.Length; i++)
            {
                if(baseNum > 9)
                {
                    if(i == final.Length-1)
                    {
                        Write(final[i]);
                    }
                    else
                    {
                        Write($"{final[i]},");
                    }
                }
                else
                {
                    Write(final[i]);
                }
                
            }
            
        }
    }
}
