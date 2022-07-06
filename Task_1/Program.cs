//  Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.

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

int[,] SortingElementsInRows(int[,] array)
{
    int temp = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int left = 0;
        int right = array.GetLength(1) - 1;
        while (left <= right)
        {
            for (int j = left; j < right; j++)
            {
                if (array[i, j] < array[i, j + 1])
                {
                    temp = array[i, j + 1];
                    array[i, j + 1] = array[i, j];
                    array[i, j] = temp;
                }
            }
            right--;
            for (int j = right; j > left; j--)
            {
                if (array[i, j] > array[i, j - 1])
                {
                    temp = array[i, j - 1];
                    array[i, j - 1] = array[i, j];
                    array[i, j] = temp;
                }
            }
            left++;
        }
    }
    return array;
}

int row = Promt("введите количесво строк: ");
int column = Promt("введите количесво столбцов: ");
int min = 0;
int max = 10;
int[,] array = GenerateArray(row, column, min, max);
PrintArray(array);
System.Console.WriteLine();
int[,] SortedElementsInRowsArray = SortingElementsInRows(array);
PrintArray(SortedElementsInRowsArray);