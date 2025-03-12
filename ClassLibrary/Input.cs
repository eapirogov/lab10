using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Input
    {
        public static int InputAllDigits(string message)
        {
            bool isCorrect = false;
            int answer = 0;
            do
            {
                Console.WriteLine(message);
                try
                {
                    answer = int.Parse(Console.ReadLine());
                    isCorrect = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите целое число");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return answer;
        }
        public static int IntegerInput(string message)
        {
            bool isCorerct = false;
            int answer = 0;
            do
            {
                Console.WriteLine();
                try
                {
                    answer = int.Parse(Console.ReadLine());
                    if (answer > 0)
                    {
                        isCorerct = true;
                    }
                    else
                    {
                        Console.WriteLine("Введите положителное число");
                        isCorerct = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите целое число");
                    isCorerct = false;
                }
            } while (!isCorerct);
            return answer;

        }
        public static int IntegerInputWithZero(string message)
        {
            bool isCorrect = false;
            int answer = 0;
            do
            {
                Console.WriteLine(message);
                try
                {
                    answer = int.Parse(Console.ReadLine());
                    if (answer >= 0)
                    {
                        isCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("Введите неотрицательное число");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите целое число");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return answer;
        }
        public static int IntegerInputFromMinToNax(string message, int min, int max)
        {
            bool isCorrect = false;
            int answer = 0;
            do
            {
                Console.WriteLine(message);
                try
                {
                    answer = int.Parse(Console.ReadLine());
                    if (answer > min && answer < max)
                    {
                        isCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine($"Введите целое число в пределах от {min} до {max}");
                        isCorrect = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите целое число");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return answer;
        }

        public static double DoubleInput(string message)
        {
            bool isCorrect = false;
            double answer = 0;
            do
            {
                Console.WriteLine(message);
                try
                {
                    answer = double.Parse(Console.ReadLine());
                    isCorrect = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Введите число");
                    isCorrect = false;
                }
            } while (!isCorrect);
            return answer;
        }

    }
}
