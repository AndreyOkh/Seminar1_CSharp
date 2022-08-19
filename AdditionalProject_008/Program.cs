// 8. Написать программу со следующими командами:
// - SetNumbers – пользователь вводит числа через пробел, а программа запоминает их в массив
// - AddNumbers – пользователь вводит числа, которые добавятся к уже существующему массиву
// - RemoveNumbers -  пользователь вводит числа, которые если  найдутся в массиве, то будут удалены
// - Numbers – ввывод текущего массива
// - Sum – найдется сумма всех элементов чисел

using System.Text.RegularExpressions;

Console.WriteLine("Здравствуйте, это программа по работе с массивами данных, что бы узнать что я умею введите Help");

int[] arrayNumbers = new int[0];
bool isWork = true;

while (isWork)
{
    string command = ReadUserCommad("Введите команду: ");

    switch(command)
    {
        case("setnumbers"):
            arrayNumbers = SetNumbers();
            Console.WriteLine("Значения сохранены.");
            break;
        
        case("addnumbers"):
            if(arrayNumbers.Length != 0)
            {
                arrayNumbers = AddNumbers(arrayNumbers);
                Console.WriteLine("Значения добавлены.");
            }
            else
            {
                Console.WriteLine("Массив пуст, сначала заполните массив выполнив команду SetNumbers.");
            }
            break;

        case("removenumbers"):
            
            if(arrayNumbers.Length != 0)
            {
                arrayNumbers = RemoveNumbers(arrayNumbers);
                Console.WriteLine("Значения удалены.");
            }
            else
            {
                Console.WriteLine("Массив пуст, сначала заполните массив выполнив команду SetNumbers.");
            }
            break;

        case("numbers"):
            Numbers(arrayNumbers);
            break;

        case("sum"):
            Sum(arrayNumbers);
            break;

        case("help"):
            Help();
            break;

        case("exit"):
            isWork = false;
            break;

        default:
            Console.WriteLine("Команда неопознана.");
            goto case "help";
    }
}

/*-------------------------Ввод чисел-------------------------*/
string[] InputNumbers ()
{
    Console.Write("Введите числа разделяя их пробелом: ");
    string[] numbers = Console.ReadLine()!.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    return numbers;
    
}

/*-------------------------Ввод команд-------------------------*/
string ReadUserCommad (string message)
{
    Console.Write(message);
    string? result = Console.ReadLine()!.ToLower();
    return result;
    
}

/*-------------------------Проверяем и считаем количество числовых значений в массиве-------------------------*/
int CountNumbers(string[] array)
{
    int countNumbers = 0;
    foreach (string i in array)
    {
        if(int.TryParse(i, out int number))
        {
            countNumbers++;
        }
    }
    return countNumbers;
}

/*-------------------------Перебор массива-------------------------*/
int[] RoundForArray(string[] array, int startIndex, int size)
{
    int[] arrayNew = new int[size];
    for (int i = 0; i < array.Length; i++)
    {
        if(int.TryParse(array[i], out int number))
        {
            arrayNew[startIndex] = Convert.ToInt32(array[i]);
            startIndex++;
        }
    }
    return arrayNew;
}

/*-------------------------Справка-------------------------*/
void Help()
{
    Console.WriteLine(@"
                        SetNumbers – пользователь вводит числа через пробел, а программа запоминает их в массив
                        AddNumbers – пользователь вводит числа, которые добавятся к уже существующему массиву
                        RemoveNumbers -  пользователь вводит числа, которые если  найдутся в массиве, то будут удалены
                        Numbers – ввывод текущего массива
                        Sum – найдется сумма всех элементов массива
                        Help - выведет справку
                        Exit - завершение работы");
}

/*-------------------------Numbers-------------------------*/
// Numbers – ввывод текущего массива
void Numbers(int[] array)
{

    if(array.Length != 0)
    {
        foreach (var number in array)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Массив пуст, сначала заполните массив выполнив команду SetNumbers.");
    }

}

/*-------------------------Sum-------------------------*/
// Sum – находит сумму всех элементов массива
void Sum(int[] array)
{
    if(array.Length != 0)
    {
        int sum = 0;

        foreach (int i in array)
        {
            sum += i;
        }

        Console.WriteLine($"Сумма всех чисел массива = {sum}");
    }
    else
    {
        Console.WriteLine("Массив пуст, сначала заполните массив выполнив команду SetNumbers.");
    }
}

/*-------------------------SetNumbers-------------------------*/
// SetNumbers – пользователь вводит числа через пробел, а программа запоминает их в массив
int[] SetNumbers()
{
    string[] numbersArray = InputNumbers(); // Запрашиваем значения у пользователя
    int numbersArraySize = CountNumbers(numbersArray); // Проверяем сколько из них являются числами
    int[] array = new int [numbersArraySize];

    // Сохраняем числа в массив
    array = RoundForArray(numbersArray, 0, numbersArraySize);
    return array;
}

/*-------------------------AddNumbers-------------------------*/
// AddNumbers – пользователь вводит числа, которые добавятся к уже существующему массиву
int[] AddNumbers(int[] arrayOld)
{
    if(arrayOld.Length != 0)
    {
        string[] numbersArray = InputNumbers();
        int numbersArraySize = CountNumbers(numbersArray);

        int arrayOldLength = arrayOld.Length;
        int [] arrayNew = new int [arrayOldLength + numbersArraySize];
        arrayOld.CopyTo(arrayNew, 0);
        RoundForArray(numbersArray, 0, numbersArraySize).CopyTo(arrayNew, arrayOldLength);
        return arrayNew;
    }
    else
    {
        return arrayOld;
    }
}

/*-------------------------RemoveNumbers-------------------------*/
// RemoveNumbers -  пользователь вводит числа, которые если  найдутся в массиве, то будут удалены
int[] RemoveNumbers(int [] arrayOld)
{
    if(arrayOld.Length != 0)
    {
        string[] numbersArray = InputNumbers();
        int numbersArraySize = CountNumbers(numbersArray);

        // Создаем массив чисел на удаление
        int[] numbersDelArray = new int[numbersArraySize];
        numbersDelArray = RoundForArray(numbersArray, 0, numbersArraySize);

        // Находим и помечаем на удаление значения массива
        int arrayOldDelCount = 0;
        for (int i = 0; i < arrayOld.Length; i++)
        {
            foreach (int number in numbersDelArray)
            {
                if (arrayOld[i] == number)
                {
                    arrayOld[i] = -1;
                    arrayOldDelCount++;
                }
            }
        }

        // Создаем новый массив и копируем значения исключая помеченные
        int[] arrayNew = new int[arrayOld.Length - arrayOldDelCount];
        int arrayNewIndex = 0;
        foreach (int item in arrayOld)
        {
            if (item != -1)
            {
                arrayNew[arrayNewIndex] = item;
                arrayNewIndex++;
            }
        }
        return arrayNew;
    }
    else
    {
        return arrayOld;
    }
}