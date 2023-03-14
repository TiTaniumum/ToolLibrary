using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTools
{
    public class Alg
    {
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
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = RAND(min, max);
            }

        }
        public static int RAND(int min, int max)
        {
            Random rand = new Random();
            return min + rand.Next() % (max - (min) + 1);
        }
        public static double RAND(double min, double max)
        {
            Random rand = new Random();
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
    namespace ConsoleOut
    {
        public partial class C
        {
            public static void Out(string str)
            {
                Console.WriteLine(str);
            }
        }
    }
}
