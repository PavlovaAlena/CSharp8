// Задача 62. Заполните спирально массив 4 на 4.

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
    int n = arr.GetLength(0);
    for (int num = 1, p = 0; p < n / 2; p++)
    {
        for (int j = p; j < n - p; j++)
        {
            arr[p, j] = num;
            num = num + 1;
        }
        for (int i = p + 1; i < n - p - 1; i++)
        {
            arr[i, n - p - 1] = num;
            num = num + 1;
        }
        for (int j = n - p - 1; j >= p; j--)
        {
            arr[n - p - 1, j] = num;
            num = num + 1;
        }
        for (int i = n - p - 2; i > p + 1; i--)
        {
            arr[i, p] = num;
            num = num + 1;
        }
        if (num <= n * n)
        {
            arr[p + 1, p] = num;
            num = num + 1;
        }
    }

    if (n % 2 != 0 && arr[n / 2, n / 2] == 0)
    { arr[n / 2, n / 2] = arr[n / 2, n / 2 - 1] + 1; }

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

//***********************
Console.Write("Программа заполняет спирально массив n x n.");
Console.WriteLine("");

int n;

if (!InputDannyh("Введите размерность двумерного массива [n]]", out n))
{ Console.WriteLine("Расчет прерван из-за отказа ввода данных"); }
else
{
    int[,] array = new int[n, n];
    InputArray(array);
    PrintArray(array, "Спиральная матрица: ");
}