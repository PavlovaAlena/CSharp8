// Задача 58. Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

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
int[,] ArrayСomposition(int[,] arr1, int[,] arr2)
{
    int[,] arrayNew = new int[arr1.GetLength(0), arr2.GetLength(1)];
    for (int i = 0; i < arr1.GetLength(0); i++)
    {
        for (int j = 0; j < arr1.GetLength(1); j++)
        { arrayNew[i, j] = arr1[i, j] * arr2[i, j]; }
    }
    return arrayNew;
}

//************************
int[,] ArrayСomposition2(int[,] arr1, int[,] arr2)
{
    int[,] arrayMat = new int[arr1.GetLength(0), arr2.GetLength(1)];
    for (int i = 0; i < arrayMat.GetLength(0); i++)
    {
        for (int j = 0; j < arrayMat.GetLength(1); j++)
        {
            int comp = 0;
            for (int k = 0; k < arr1.GetLength(1); k++)
            { comp = comp + arr1[i, k] * arr2[k, j]; }
            arrayMat[i, j] = comp;
        }
    }
    return arrayMat;
}
//***********************
Console.Write("Программа задает две матрицы и находит произведение двух матриц.");
Console.WriteLine("");

int m, n, minR, maxR;

if (!InputDannyh("Введите размерность матриц [m,n]", out m, out n)
    || !InputDannyh("Введите диапазон минимального и максимального значения для заполнения матриц,", out minR, out maxR))
{ Console.WriteLine("Расчет прерван из-за отказа ввода данных"); }
else
{
    int[,] array = new int[m, n];
    InputArray(array, minR, maxR);
    PrintArray(array, "Первая матрица: ");

    int[,] array2 = new int[m, n];
    InputArray(array2, minR, maxR);
    PrintArray(array2, "Вторая матрица: ");

    int[,] arrayComp = ArrayСomposition(array, array2);
    PrintArray(arrayComp, "Произведение двух матриц: ");

    int[,] array22 = new int[n, m];
    if (m != n)
    {
        Console.WriteLine("Для математического произведение двух матриц необходимо, что бы кол-во строк одной матрицы = кол-ву столбцов другой.");
        Console.WriteLine("Переворачиваем и перезаполняем вторую матрицу. Первую еще раз выведем для удобства");
        InputArray(array22, minR, maxR);

        PrintArray(array, "Первая матрица: ");
        PrintArray(array22, "Вторая матрица: ");
    }
    else
    { Array.Copy(array2, array22, array2.Length); }

    int[,] arrayComp2 = ArrayСomposition2(array, array22);
    PrintArray(arrayComp2, "Математическое произведение двух матриц: ");

}