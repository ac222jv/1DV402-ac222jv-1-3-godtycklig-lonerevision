using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            int numberOfSalaries;
            numberOfSalaries = 0;

            do
            {
                while (numberOfSalaries < 2)
                {
                    numberOfSalaries = ReadInt("Ange antalet löner att beräkna:");


                    if (numberOfSalaries < 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Antalet löner som matas in måste vara mer än 2");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }

                processSalaries(numberOfSalaries); //Kör metoden processSalaries.

                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tryck på valfri tangent för att genomgöra en ny beräkning - Esc kommer att avsluta");
                Console.ResetColor();
                ConsoleKeyInfo turnOF; turnOF = Console.ReadKey(true);
                if (turnOF.Key == ConsoleKey.Escape)

                {
                    return;
                }

                numberOfSalaries = 0;
            }

            while (!exit); 
        }


        static void processSalaries(int count)
        {

            int countSalaries;
            int totalSalary;
            int medianSalary;
            int highestSalary;
            int lowestSalary;
            
            int[] salaries;
            int[] salariesSorted;
            totalSalary = 0;
            salaries = new int[count];
            salariesSorted = new int[count];
            for (int i = 0; i < count; i++)
            {
                salaries[i] = ReadInt("Ange lön nr " + (i + 1) + " :" );
                //Kopierar den sorterade arrayen till den osorterade.
                totalSalary += salaries[i];
                salariesSorted[i] = salaries[i];
            }
            //Sorterar Arreyen , lägsta lön, högsta lön och lönespridningen
            Array.Sort(salariesSorted);
            highestSalary = salariesSorted.Max();
            lowestSalary = salariesSorted.Min();
            countSalaries = salariesSorted.Count();

            //Räknar ut medianen
            int median = salariesSorted.Count() / 2;
            if (countSalaries % 2 == 0)
            {
                medianSalary = (salariesSorted[median - 1] + salariesSorted[median] / 2); //medianen för ett jämt antal löner.
            }

            else
            {
                medianSalary = salariesSorted[median];//medianen för ett ojämt antal löner.
            }


            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Medianlön:             {0:c0}", medianSalary);
            Console.WriteLine("Medellön:              {0:c0}", salariesSorted.Average());
            Console.WriteLine("Lönespridning:         {0:c0}", salariesSorted.Max() - salariesSorted.Min());
            Console.WriteLine("------------------------------");
            Console.WriteLine();

             for (int i = 1; i <= count; i++)
                        {
                                Console.Write("{0, 5}   ", salaries[i - 1]);
 
                                if (i % 3 == 0)
                                {
                                        Console.WriteLine();
                                }
                        }
                }
               
        static int ReadInt(string prompt) //Läser in värden från användaren
        {
            string input;
            int ReadInt;
            input = null;
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    input = Console.ReadLine();
                    ReadInt = int.Parse(input);

                    if (ReadInt < 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Du måste skriva in ett värde som är större än 1");
                        Console.ResetColor();
                    }
                    else
                    {

                        break;
                    }
                }

                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("OBS! {0} är inte större än 1.", input);
                    Console.ResetColor();
                }

            }

            return ReadInt;
            

    

        }
    }
}
