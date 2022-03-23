using System;

namespace CoureConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 15, 25, 35 };
            int[] array3 = { 8, 8 };
            Console.WriteLine($"Output: {AddNumbers(array1)}");
            Console.WriteLine($"Output: {AddNumbers(array2)}");
            Console.WriteLine($"Output: {AddNumbers(array3)}");
        }


        public static int AddNumbers(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)  // Even number check
                {
                    sum++;
                }
                if (array[i] % 2 != 0)  // Odd number check
                {
                    sum += 3;
                }
                if (array[i] == 8) // When 8 is encountered
                {
                    sum += 5;
                }
            }
            return sum;
        }
    }
}
