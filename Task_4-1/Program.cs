using System;

class Programm
{
    public static void Main(string[] args)
    {
        var arrString = new OneDimetionalArray<string>();
        var arrInt = new OneDimetionalArray<int>();
        string[] valString = { "ban", "school", "joke", "computer", "apple", "windows", "0_0", "-_-" };
        int[] valInt = { 4, 13, 67, 1337, 228, 666, 34, 25 };

        for (int i = 0; i < 8; i++)
        {
            arrString.Add(valString[i]);
            arrInt.Add(valInt[i]);
        }

        arrString.Print();
        arrInt.Print();

        string[] arrStringSorted = arrString.Sorted();
        int[] arrIntSorted = arrInt.Sorted();

        Print(arrStringSorted);
        Print(arrIntSorted);

        arrString.Sort();
        arrInt.Sort();

        arrString.Print();
        arrInt.Print();

        (string minString, string maxString) = arrString.GetMinAndMax();
        (int minInt, int maxInt) = arrInt.GetMinAndMax();

        Console.WriteLine($"arrString min: {minString}\narrString max: {maxString}");
        Console.WriteLine($"arrInt min: {minInt}\narrInt max: {maxInt}");
    }

    public static void Print<T>(T[] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
