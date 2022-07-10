// // Задайте двумерный массив. 
// Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

int Prompt(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine());
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
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

int[,] SortElementsInRows(int[,] array)
{
    int n = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int max = j;
            for (n = j; n < array.GetLength(1); n++)
            {
                if (array[i, max] < array[i, n])
                {
                    max = n;
                }
            }
            var temp = array[i, max];
            array[i, max] = array[i, j];
            array[i, j] = temp;
        }
    }
    return array;
}

int row = Prompt("Введите количество строк: ");
int column = Prompt("Введите количество столбцов: ");
int min = 1;
int max = 10;
int[,] array = GenerateArray(row, column, min, max);
PrintArray(array);
System.Console.WriteLine();
int[,] NewArray = SortElementsInRows(array);
PrintArray(NewArray);