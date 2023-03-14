using System;

public interface iAlg
{
    //This method takes a string parameter and returns an integer parsed from the string.
    public static int toIntParse(string num);

    //This method takes a string parameter and returns a float parsed from the string.
    public static float toFloatPatse(string num);

    //This method returns an integer, with a message parameter that is optional.
    //It continues to ask the user to input a number until a valid integer is inputted.
    public static int toIntTryParse(string message = " ");

    //This method returns a float, with a message parameter that is optional.
    //It continues to ask the user to input a number until a valid float is inputted.
    public static float toFloatTryParse(string message = " ");

    //This method takes two generic parameters and swaps their values.
    public static void swap<T>(ref T first, ref T second);

    //This method takes an array and prints all its elements.
    public static void PrintArr<T>(T[] array);

    //This method takes an integer array, a minimum value, and a maximum value.
    //It fills the array with random integers between the minimum and maximum values.
    public static void RandFillArray(int[] array, int min, int max);

    //This method takes a minimum and maximum value and returns a random integer between them.
    public static int RAND(int min, int max);

    //This method takes a minimum and maximum value and returns a random double between them.
    public static double RAND(double min, double max);

    //This method takes a count, an optional boolean for whether to use upper-case letters,
    //and a boolean for whether the first letter should be capitalized.
    //It returns a random string with the given length and capitalization specifications.
    public static string randString(int cnt, bool isUpperRegister = false, bool firstSymbolInUpper = true);

    //This method takes an array, a number, and a chance.It fills the array with the given number at a chance of 1/chance.
    public static void FillNumber<T>(T[] array, T num, int chance = 1);
}
