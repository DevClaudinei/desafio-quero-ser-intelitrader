using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a number greater than or equal to ten for the size of the array:");
        string num = Console.ReadLine();
        while (int.Parse(num) < 10)
        {
            Console.WriteLine("Please enter a number greater than or equal to ten for the size of the array: ");
            num = Console.ReadLine();
        }

        var number = int.Parse(num);

        int[] array1 = GenerateRandomArray(number, -100, 10000);
        int[] array2 = GenerateRandomArray(number, -100, 10000);

        Console.WriteLine("Array1: " + string.Join(", ", array1));
        Console.WriteLine("Array2: " + string.Join(", ", array2));

        int smallestDistance = FindTheSmallestDistance(array1, array2);

        Console.WriteLine("The smallest distance is: " + smallestDistance);
    }

    static int[] GenerateRandomArray(int size, int minimum, int maximum)
    {
        int[] array = new int[size];
        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(minimum, maximum + 1);
        }

        return array;
    }

    static int FindTheSmallestDistance(int[] array1, int[] array2)
    {
        var smallestDistance = int.MaxValue;

        for (int i = 0; i < array1.Length; i++)
        {
            for (int j = 0; j < array2.Length; j++)
            {
                var difference = Math.Abs(array1[i] - array2[j]);

                if (difference < smallestDistance)
                    smallestDistance = difference;
            }
        }

        return smallestDistance;
    }
}