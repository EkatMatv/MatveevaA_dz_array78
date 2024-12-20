//Дан массив размера N. Заменить каждый элемент массива на среднее
//арифметическое этого элемента и его соседей.
using System;
using System.Linq;
using static System.Console;

// Задаем массив и его размер
int n = 0;

begin:
Write("Введите размерность > 0: ");
try
{
    n = Convert.ToInt32(ReadLine());
    if (n <= 0)
        throw new FormatException();
}
catch (FormatException e)
{
    Beep();
    ForegroundColor = ConsoleColor.Red;
    WriteLine("Просили положительное число !");
    WriteLine(e.Message);
    ForegroundColor = ConsoleColor.White;
    goto begin;
}

int[] array = new int[n];
Random r = new();
for (int i = 0; i < n; i++)
{
    array[i] = r.Next(100);
}
WriteLine();
WriteLine("Исходный массив: " + String.Join("  ", array));

// Обновляем массив
double[] newArray = NewArray(array);
WriteLine("Обновленный массив: " + String.Join("  ", newArray));

static double[] NewArray(int[] array)
{
    // Создаем новый массив для хранения обновленных значений
    double[] res = new double[array.Length];

    for (int i = 0; i < array.Length; i++)
    {
        // Получаем соседние элементы
        var neighbors = new[]
        {
                array[i],
                (i > 0) ? array[i - 1] : 0, // Левый сосед
                (i < array.Length - 1) ? array[i + 1] : 0 // Правый сосед
        };
        // Вычисляем среднее арифметическое и округляем до 2 цифр после запятой
        res[i] = Math.Round(neighbors.Average(), 2);
    }
    return res;
}