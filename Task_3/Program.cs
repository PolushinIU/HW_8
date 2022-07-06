// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

int[,] GenerateMatrix(string message)
{
    System.Console.Write($"Введите количество строк в матрице {message}: ");
    int row = int.Parse(System.Console.ReadLine());
    System.Console.Write($"Введите количество столбцов в матрице {message}: ");
    int column = int.Parse(System.Console.ReadLine());
    int min = 0;
    int max = 10;
    int[,] array = GenerateArray(row, column, min, max);
    return array;
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

int[,] MultiplicationTwoMatrix(int[,] array1, int[,] array2)
{
    int[,] array3 = new int[array1.GetLength(0), array2.GetLength(1)];
    for (int i = 0; i < array3.GetLength(0); i++)
    {
        for (int j = 0; j < array3.GetLength(1); j++)
        {
            array3[i, j] = MultiplicationElements(array1, array2, i, j);
        }
    }
    return array3;
}

int MultiplicationElements(int[,] array1, int[,] array2, int rowInMatrix1, int columnInMatrix2)
{
    int answer = 0;
    for (int i = 0; i < array1.GetLength(1); i++)
    {
        answer += array1[rowInMatrix1, i] * array2[i, columnInMatrix2];
    }
    return answer;
}


int[,] matrix1 = GenerateMatrix("1");
int[,] matrix2 = GenerateMatrix("2");
System.Console.WriteLine("Матрица 1:");
PrintArray(matrix1);
System.Console.WriteLine();
System.Console.WriteLine("Матрица 2:");
PrintArray(matrix2);
if (matrix1.GetLength(1) != matrix2.GetLength(0))
{
    System.Console.WriteLine();
    System.Console.WriteLine("Умножение матриц невозможно!!! Количество столбцов в первой матрице должно быть равно количеству строк во второй матрице.");
    Environment.Exit(0);
}
int[,] matrix3 = MultiplicationTwoMatrix(matrix1, matrix2);
System.Console.WriteLine("Произведение матриц");
PrintArray(matrix3);