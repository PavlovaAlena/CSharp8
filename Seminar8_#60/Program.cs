// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

//***********************
bool InputDannyhMat(string text, out int val1, out int val2, out int val3)
{
    val1 = 0;
    val2 = 0;
    val3 = 0;
    Console.Write($"{text} через пробел: ");
    int[] array = Console.ReadLine().Split(' ', 3, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    if (array.Length < 3)
    {
        Console.WriteLine("Вводимые данные должны состоять из 3х чисел, разделенных пробелом!!!");
        Console.Write("Хотите повторно ввести данные? (y - да): ");
        string otvet = Console.ReadLine();
        if (otvet == "y" || otvet == "Y")
        { return InputDannyhMat(text, out val1, out val2, out val3); }

        return false;
    }
    val1 = array[0];
    val2 = array[1];
    val3 = array[2];
    return true;
}

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
void InputArray(int[,,] arr, int minR, int maxR)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int y = 0; y < arr.GetLength(2); y++)
            {
                bool Cont;
                int temp;
                do
                {
                    temp = new Random().Next(minR, maxR);
                    Cont = false;
                    foreach (int item in arr)
                    {
                        if (item == temp)
                        {
                            Cont = true;
                            break;
                        }
                    }
                } while (Cont);
                arr[i, j, y] = temp;
            }
        }
    }
}

//************************
void PrintArray(int[,,] arr, string text)
{
    Console.WriteLine(text);
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int y = 0; y < arr.GetLength(2); y++)
            { Console.Write(arr[i, j, y] + "(" + i + "," + j + "," + y + ") "); }
        }
        Console.WriteLine();
    }
}

//***********************
Console.Write("Программа формирует трёхмерный массив из неповторяющихся двузначных чисел и построчно выводит его, добавляя индексы каждого элемента.");
Console.WriteLine("");

int m, n, k, minR, maxR;

if (!InputDannyhMat("Введите размерность массива [m,n,k]", out m, out n, out k)
    || !InputDannyh("Введите диапазон минимального и максимального значения для заполнения массива,", out minR, out maxR))
{ Console.WriteLine("Расчет прерван из-за отказа ввода данных"); }
else
{
    int[,,] array = new int[m, n, k];
    InputArray(array, minR, maxR);
    PrintArray(array, "Сформирована матрица: ");
}