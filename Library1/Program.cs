using System;
using CommonTools.ConsoleOut;

namespace CommonTools
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            char ch = ' ';
            C.In(ref ch);
            C.Out(ch);
            string str = "";
            C.In(ref str);
            C.Out(str);
        }
    }
}