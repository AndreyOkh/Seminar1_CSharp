// 7. Написать функцию Shuffle, которая перемешивает элементы массива в случайном порядке.

int[] array = {1 ,2 ,4 ,6 ,7 ,8 ,5 ,3 ,2};

Shuffle(array);

foreach (int item in array)
{
    Console.Write($"{item} ");
}

void Shuffle (int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        int randomeIndex = new Random().Next(i, array.Length);

        int temp = array[i];
        array[i] = array[randomeIndex];
        array[randomeIndex] = temp;
    }
}