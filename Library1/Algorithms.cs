﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonTools
{
    public class Alg
    {
        public static Random rand;

        static Alg()
        {
            rand = new Random();
        }
        public static int toIntParse(string num)
        {
            return int.Parse(num);
        }
        public static float toFloatParse(string num)
        {
            return float.Parse(num);
        }
        public static int toIntTryParse(string message = "")
        {
            float temp = -1.1f;

            while (temp!=(int)temp) { temp = toFloatTryParse(message); }

            return (int)temp;
        }
        public static float toFloatTryParse(string message = "")
        {
            bool trueValue = false;

            while (!trueValue)
            {
                Console.WriteLine(message);
                string readAge = Console.ReadLine();

                if (readAge != string.Empty)
                {
                    if (float.TryParse(readAge, out float value))
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine("Не число");
                    }
                }
            }

            return -1.0f;
        }

        public static void swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        public static void PrintArr<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public static void RandFillArray(int[] array, int min, int max)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = RAND(min, max);
            }

        }
        public static int RAND(int min, int max)
        {
            
            return min + rand.Next() % (max - (min) + 1);
        }
        public static double RAND(double min, double max)
        {
            return min + rand.NextDouble() % (max - (min) + 1);
        }

        public static string randString(int cnt, bool isUpperRegister = false, bool firstSymbolInUpper = true)
        {
            string str = string.Empty;
            if (firstSymbolInUpper)
            {
                str += (char)RAND('A', 'Z');
                cnt--;
            }
            for (int i = 0; i < cnt; i++)
            {
                if (isUpperRegister)
                {

                }
                else
                {
                    str += (char)RAND('a', 'z');
                }
            }
            return str;
        }
        public static void FillNumber<T>(T[] array, T num, int chance = 1) //Заполение массива значениям num, с шансом 1/chance
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (RAND(1, chance) == chance) { array[i] = num; }
            }
        }
    }
    namespace ConsoleShortCuts
    {
        public partial class C
        {
            public static void Out<T>(T obj)
            {
                Console.Write(obj);
            }
            public static void OutLine<T>(T obj)
            {
                Console.WriteLine(obj);
            }
            public static void Endl()
            {
                Console.WriteLine();
            }
            public static void In(ref int item) {
                string str = string.Empty;
                bool isExit = false;
                while (!isExit)
                {
                    Console.WriteLine("type in int value:");
                    str = Console.ReadLine();
                    if (str == "EXIT")
                    {
                        isExit = true;
                    }
                    else if (str != string.Empty)
                    {
                        if (int.TryParse(str, out item))
                        {
                            isExit = true;
                        }
                        else
                        {
                            Console.WriteLine("wrong input! try again!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong input! try again!");
                    }
                }
            }
            public static void In(ref float item)
            {
                string str = string.Empty;
                bool isExit = false;
                while (!isExit)
                {
                    Console.WriteLine("type in float value:");
                    str = Console.ReadLine();
                    if (str == "EXIT")
                    {
                        isExit = true;
                    }
                    else if (str != string.Empty)
                    {
                        if (float.TryParse(str, out item))
                        {
                            isExit = true;
                        }
                        else
                        {
                            Console.WriteLine("wrong input! try again!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong input! try again!");
                    }
                }
            }
            public static void In(ref double item)
            {
                string str = string.Empty;
                bool isExit = false;
                while (!isExit)
                {
                    Console.WriteLine("type in double value:");
                    str = Console.ReadLine();
                    if (str == "EXIT")
                    {
                        isExit = true;
                    }
                    else if (str != string.Empty)
                    {
                        if (double.TryParse(str, out item))
                        {
                            isExit = true;
                        }
                        else
                        {
                            Console.WriteLine("wrong input! try again!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong input! try again!");
                    }
                }
            }
            public static void In(ref bool item)
            {
                string str = string.Empty;
                bool isExit = false;
                while (!isExit)
                {
                    Console.WriteLine("type in bool value:");
                    str = Console.ReadLine();
                    if (str == "EXIT")
                    {
                        isExit = true;
                    }
                    else if (str != string.Empty)
                    {
                        if (bool.TryParse(str, out item))
                        {
                            isExit = true;
                        }
                        else
                        {
                            Console.WriteLine("wrong input! try again!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong input! try again!");
                    }
                }
            }
            public static void In(ref long item)
            {
                string str = string.Empty;
                bool isExit = false;
                while (!isExit)
                {
                    Console.WriteLine("type in long value:");
                    str = Console.ReadLine();
                    if (str == "EXIT")
                    {
                        isExit = true;
                    }
                    else if (str != string.Empty)
                    {
                        if (long.TryParse(str, out item))
                        {
                            isExit = true;
                        }
                        else
                        {
                            Console.WriteLine("wrong input! try again!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong input! try again!");
                    }
                }
            }
            public static void In(ref short item)
            {
                string str = string.Empty;
                bool isExit = false;
                while (!isExit)
                {
                    Console.WriteLine("type in short value:");
                    str = Console.ReadLine();
                    if (str == "EXIT")
                    {
                        isExit = true;
                    }
                    else if (str != string.Empty)
                    {
                        if (short.TryParse(str, out item))
                        {
                            isExit = true;
                        }
                        else
                        {
                            Console.WriteLine("wrong input! try again!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong input! try again!");
                    }
                }
            }
            public static void In(ref char item)
            {
                string str = "";
                Console.WriteLine("type in char");
                str = Console.ReadLine();
                item = str[0];
            }
            public static void In(ref string item)
            {
                Console.WriteLine("type in string");
                item = Console.ReadLine();
            }
        }
    }
    namespace Patterns
    {
        //some patterns will be written here
    }
}
