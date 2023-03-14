using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace CommonTools
{
    public partial class Alg
    {
        public static Random rand;
        static Alg()
        {
            rand = new Random();
        }
        public static int ToIntParse(string num)
        {
            return int.Parse(num);
        }
        public static float ToFloatParse(string num)
        {
            return float.Parse(num);
        }
        public static int AskUserInt(string message = "")
        {
            while (true)
            {
                Console.WriteLine(message);
                string readAge = Console.ReadLine();

                if (readAge != string.Empty)
                {
                    if (int.TryParse(readAge, out int value))
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine("Не число");
                    }
                }
            }
        }
        public static float AskUserFloat(string message = "")
        {
            while (true)
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
        }

        public static void Swap<T>(ref T first, ref T second)
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

        public static string RandString(int cnt, bool isUpperRegister = false, bool firstSymbolInUpper = true)
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
        public static bool IsPointInFigure(List<Point> vertices,int x, int y, float Scale = 1f)
        {
            bool result = false;

            for (int i = 0, j = vertices.Count - 1; i < vertices.Count; j = i++)
            {

                Point temp1 = new Point((int)(vertices[i].X * Scale), (int)(vertices[i].Y * Scale));
                Point temp2 = new Point((int)(vertices[j].X * Scale), (int)(vertices[j].Y * Scale));

                bool isYInRange1 = (temp1.Y < temp2.Y) && (temp1.Y <= y) && (y < temp2.Y);
                bool isYInRange2 = (temp1.Y > temp2.Y) && (temp2.Y <= y) && (y < temp1.Y);

                float lenghtY = (temp2.Y - temp1.Y);
                float DifferenceByX = x - temp1.X;
                float MultiplingPart1 = DifferenceByX * lenghtY;
                float lengthX = (temp2.X - temp1.X);
                float DifferenceByY = (y - temp1.Y);
                float MultiplingPart2 = lengthX * DifferenceByY;


                if ((isYInRange1 && (MultiplingPart1 >=MultiplingPart2))||(isYInRange2 && (MultiplingPart1 <= MultiplingPart2)))
                {
                    result = !result;
                }
            }
            return result;
        }

        public static bool IsPointInFigure(List<Vector2> vertices, int x, int y, float Scale = 1f)
        {
            bool result = false;

            for (int i = 0, j = vertices.Count - 1; i < vertices.Count; j = i++)
            {

                Vector2 temp1 = new Vector2(vertices[i].X * Scale, vertices[i].Y * Scale);
                Vector2 temp2 = new Vector2(vertices[j].X * Scale, vertices[j].Y * Scale);

                bool isYInRange1 = (temp1.Y < temp2.Y) && (temp1.Y <= y) && (y < temp2.Y);
                bool isYInRange2 = (temp1.Y > temp2.Y) && (temp2.Y <= y) && (y < temp1.Y);

                float lenghtY = (temp2.Y - temp1.Y);
                float DifferenceByX = x - temp1.X;
                float MultiplingPart1 = DifferenceByX * lenghtY;
                float lengthX = (temp2.X - temp1.X);
                float DifferenceByY = (y - temp1.Y);
                float MultiplingPart2 = lengthX * DifferenceByY;


                if ((isYInRange1 && (MultiplingPart1 >=MultiplingPart2))||(isYInRange2 && (MultiplingPart1 <= MultiplingPart2)))
                {
                    result = !result;
                }
            }
            return result;
        }
    }

    public partial class ConsoleProperties
    {
        // Define the SetConsoleFullScreen function from kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static void SetConsoleFullScreen()
        {
            // Get the handle to the console window
            IntPtr hWndConsole = GetConsoleWindow();

            // Get the size of the desktop
            RECT desktopRect;
            GetWindowRect(GetDesktopWindow(), out desktopRect);

            // Set the console window to fullscreen
            SetWindowPos(hWndConsole, IntPtr.Zero, desktopRect.Left, desktopRect.Top, desktopRect.Right, desktopRect.Bottom, 0x0040);

        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
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
}
