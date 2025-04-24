using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Виберіть задачу:");
        Console.WriteLine("1. Сума елементів, кратних 9 (1D або 2D масив)");
        Console.WriteLine("2. Пошук максимального елемента в масиві");
        Console.WriteLine("3. Обмін парних стовпців у квадратному масиві");
        Console.WriteLine("4. Пошук перших від’ємних у рядках ступінчастого масиву");
        Console.Write("Ваш вибір: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1: ArraySumMenu(); break;
            case 2: MaxElementInArray(); break;
            case 3: SwapEvenColumns(); break;
            case 4: FirstNegativeInJaggedArray(); break;
            default: Console.WriteLine("Невірний вибір."); break;
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }

    static void ArraySumMenu()
    {
        Console.WriteLine("Оберіть тип масиву:");
        Console.WriteLine("1 – Одновимірний масив");
        Console.WriteLine("2 – Двовимірний масив");
        Console.Write("Ваш вибір: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1: OneDimensionalArray(); break;
            case 2: TwoDimensionalArray(); break;
            default: Console.WriteLine("Невірний вибір."); break;
        }
    }

    static void OneDimensionalArray()
    {
        Console.Write("Введіть кількість елементів у масиві: ");
        int size = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[size];
        int sum = 0;

        for (int i = 0; i < size; i++)
        {
            Console.Write($"Елемент [{i}]: ");
            array[i] = Convert.ToInt32(Console.ReadLine());
            if (array[i] % 9 == 0) sum += array[i];
        }

        Console.WriteLine($"Сума елементів, кратних 9: {sum}");
    }

    static void TwoDimensionalArray()
    {
        Console.Write("Введіть кількість рядків: ");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введіть кількість стовпців: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] array = new int[rows, cols];
        int sum = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Елемент [{i},{j}]: ");
                array[i, j] = Convert.ToInt32(Console.ReadLine());
                if (array[i, j] % 9 == 0) sum += array[i, j];
            }
        }

        Console.WriteLine($"Сума елементів, кратних 9: {sum}");
    }

    static void MaxElementInArray()
    {
        Console.Write("Введіть кількість елементів у масиві: ");
        int n = Convert.ToInt32(Console.ReadLine());
        double[] array = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Елемент [{i}]: ");
            array[i] = Convert.ToDouble(Console.ReadLine());
        }

        double max = array[0];
        int index = 0;

        for (int i = 1; i < n; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                index = i;
            }
        }

        Console.WriteLine($"Максимальний елемент: {max}");
        Console.WriteLine($"Його перший номер у масиві: {index}");
    }

    static void SwapEvenColumns()
    {
        Console.Write("Введіть розмірність квадратного масиву (n): ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] array = new int[n, n];

        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"[{i},{j}]: ");
                array[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("\nПочатковий масив:");
        PrintArray(array, n);

        if (n % 2 == 0)
        {
            for (int j = 0; j < n; j += 2)
            {
                for (int i = 0; i < n; i++)
                {
                    int temp = array[i, j];
                    array[i, j] = array[i, j + 1];
                    array[i, j + 1] = temp;
                }
            }

            Console.WriteLine("\nМасив після обміну стовпців:");
            PrintArray(array, n);
        }
        else
        {
            Console.WriteLine("\nКількість стовпців непарна — масив не змінено.");
        }
    }

    static void PrintArray(int[,] array, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void FirstNegativeInJaggedArray()
    {
        Console.Write("Введіть кількість рядків у східчастому масиві: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[][] jaggedArray = new int[n][];
        int[] negativeIndexes = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть кількість елементів у рядку [{i}]: ");
            int m = Convert.ToInt32(Console.ReadLine());
            jaggedArray[i] = new int[m];

            for (int j = 0; j < m; j++)
            {
                Console.Write($"Елемент [{i}][{j}]: ");
                jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
            }

            negativeIndexes[i] = -1;
            for (int j = 0; j < m; j++)
            {
                if (jaggedArray[i][j] < 0)
                {
                    negativeIndexes[i] = j;
                    break;
                }
            }
        }

        Console.WriteLine("\nНомери перших від’ємних елементів у кожному рядку:");
        for (int i = 0; i < n; i++)
        {
            if (negativeIndexes[i] != -1)
                Console.WriteLine($"Рядок {i}: індекс {negativeIndexes[i]}");
            else
                Console.WriteLine($"Рядок {i}: від’ємних елементів немає");
        }
    }
}
