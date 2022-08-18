// Задача 61. Вывести первые N строк треугольника Паскаля. Сделать вывод в виде равнобедренного треугольника.

//***********************
bool InputDannyh(string text, out int val1)
{
    val1 = 0;
    Console.Write($"{text} : ");
    bool KrivoyVvod = false;
    if (!int.TryParse(Console.ReadLine(), out int itemp))
    { KrivoyVvod = true; }
    if (Convert.ToInt32(itemp) < 2)
    { KrivoyVvod = true; }
    if (KrivoyVvod)
    {
        Console.WriteLine("Вводимые данные должны быть числовыми и больше 1!!!");
        Console.Write("Хотите повторно ввести данные? (y - да): ");
        string otvet = Console.ReadLine();
        if (otvet == "y" || otvet == "Y")
        { return InputDannyh(text, out val1); }

        return false;
    }

    val1 = Convert.ToInt32(itemp);
    return true;
}

//************************
void InputArray(int[,] arr)
{
    for (int k = 0; k < arr.GetLength(0); k++)
    {
        arr[k, 0] = 1;
    }
    for (int i = 1; i < arr.GetLength(0); i++)
    {
        for (int j = 1; j < arr.GetLength(1); j++)
        {
            arr[i, j] = arr[i - 1, j] + arr[i - 1, j - 1];
        }
    }
}

//************************
void PrintArray(int[,] arr, string text)
{
    Console.WriteLine(text);
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] != 0)
            { Console.Write($"{arr[i, j]} "); }
            else { Console.Write("  "); }
        }
        Console.WriteLine();
    }
}
//************************
void ConvertArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int count = 0;
        for (int j = array.GetLength(1) - 1; j >= 0; j--)
        {
            if (array[i, j] != 0)
            {
                array[i, array.GetLength(1) / 2 + j - count] = array[i, j];
                array[i, j] = 0;
                count++;
            }
        }
    }
    array[array.GetLength(0) - 1, 0] = 1;
}

//***********************
Console.Write("Программа выводит первые N строк треугольника Паскаля в виде равнобедренного треугольника.");
Console.WriteLine("");

int n;

if (!InputDannyh("Введите желаемое количество строк", out n))
{ Console.WriteLine("Расчет прерван из-за отказа ввода данных"); }
else
{
    int[,] arrTP = new int[n + 1, 2 * n + 1];
    InputArray(arrTP);
    ConvertArray(arrTP);
    PrintArray(arrTP, "Треугольник Паскаля: ");
}