// Задача 54. Задайте двумерный массив. Напишите программу, которая упорядочит по возрастанию элементы каждой строки двумерного массива.

//***********************
bool InputDannyh(string text, out int val1, out int val2)
{
    val1 = 0;
    val2 = 0;
    Console.Write($"{text} через пробел: ");
    int[] array = Console.ReadLine().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    if (array.Length < 2)
    {
        Console.WriteLine("Вводимые данные должны состоять из 2х чисел, разделенных пробелом!!!");
        Console.Write("Хотите повторно ввести данные? (y - да): ");
        string otvet = Console.ReadLine();
        if (otvet == "y" || otvet == "Y")
        { return InputDannyh(text, out val1, out val2); }

        return false;
    }
    val1 = array[0];
    val2 = array[1];
    return true;
}

//************************
void InputArray(int[,] arr, int minR, int maxR)
{
    Random rnd = new Random();

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        { arr[i, j] = new Random().Next(minR, maxR); }
    }
}

//************************
void PrintArray(int[,] arr, string text)
{
    Console.WriteLine(text);
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        { Console.Write(arr[i, j] + " "); }
        Console.WriteLine();
    }
}
//************************
void ArraySort(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 1; j < arr.GetLength(1);)
    {
        if (arr[i, j - 1] > arr[i, j])
        {
            int min = arr[i, j];
            arr[i, j] = arr[i, j - 1];
            arr[i, j - 1] = min;
            j = 1;
        }
        else
        { j++; }
    }
}
}

//***********************
Console.Write("Программа задает двумерный массив и упорядочивает по возрастанию элементы каждой строки двумерного массива.");
Console.WriteLine("");

int m, n, minR, maxR;

if (!InputDannyh("Введите размерность массива [m,n]", out m, out n)
    || !InputDannyh("Введите диапазон минимального и максимального значения для заполнения массива,", out minR, out maxR))
{ Console.WriteLine("Расчет прерван из-за отказа ввода данных"); }
else
{
    int[,] array = new int[m, n];
    InputArray(array, minR, maxR);
    PrintArray(array, "Исходный массив: ");
    ArraySort(array);
    PrintArray(array, "Новый массив: ");
}