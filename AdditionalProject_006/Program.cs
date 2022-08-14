using System;
// 6. Написать 2 функции для работы с массивом: AddToArray И RemoveFromArray – первая добавляет к числовому массиву значение,
// тем самым увеличивая массив, а вторая удаляет элемент под нужным индексом и уменьшает массив на 1.

int[] array = { 1, 2, 3, 4, 5};    //Объявляем массив
int value = 6;                      // Значение которое будем добавлять в массив
int indexToRemove = 0;              // Индекс элемента который будем удалять 

Console.WriteLine($"Изначальный массив {String.Join(",", array)}");

array = WorkingWithArray.AddToArray(array, value);
Console.WriteLine($"Массив после добавления значения {String.Join(",", array)}");

array = WorkingWithArray.RemoveFromArray(array, indexToRemove);
Console.WriteLine($"Массив после удалени значения {String.Join(",", array)}");

public static class WorkingWithArray
{
    /*-------------------------Добавить значение в массив-------------------------*/
    public static T[] AddToArray<T> (T[] array, T value)
    {
        if (array == null)
        {
            return new T[] {value};
        }
        T[] result = new T[array.Length + 1];
        array.CopyTo(result, 0);
        result[array.Length] = value;
        return result;
    }

    /*-------------------------Удалить значение из массива-------------------------*/
    public static T[] RemoveFromArray<T> (T[] array, int indexToRemove)
    {
        T[] result = new T[array.Length - 1];
        Array.Copy(array, result, indexToRemove);
        Array.Copy(array, indexToRemove + 1, result, indexToRemove, result.Length - indexToRemove);
        return result;
    }
}
