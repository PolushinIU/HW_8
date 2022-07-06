// Задайте прямоугольный двумерный массив. Напишите программу,
// которая будет находить строку с наименьшей суммой элементов.

int Promt(string message)
{
    System.Console.Write(message);
    return int.Parse(System.Console.ReadLine());
}

int[,] GenerateArray(int row, int column, int min, int max)
{
    var array = new int[row, column];
    var rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(min, max + 1);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write(array[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

int[] SumOfElementsInRow(int[,] array)
{
    int[] sum = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int answer = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            answer += array[i, j];
        }
        sum[i] = answer;
    }
    return sum;
}

int SearchMinSumInRows(int[] array)
{
    int min = array[0];
    int index = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (min > array[i])
        {
            min = array[i];
            index = i;
        }
    }
    return index;
}

int row = Promt("введите количесво строк: ");
int column = Promt("введите количесво столбцов: ");
int min = 0;
int max = 10;
int[,] array = GenerateArray(row, column, min, max);
PrintArray(array);
System.Console.WriteLine();
int[] sumInRowArray = SumOfElementsInRow(array);
int minSumInRows = SearchMinSumInRows(sumInRowArray);
System.Console.WriteLine($"Строка с наименьшей суммой элементов => {minSumInRows + 1}");