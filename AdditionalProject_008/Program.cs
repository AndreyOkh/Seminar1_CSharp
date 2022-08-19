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
            break;
        
        case("addnumbers"):
            if(arrayNumbers.Length != 0)
            {
                arrayNumbers = AddNumbers(arrayNumbers);
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


/*-------------------------Запрос команды-------------------------*/
string ReadUserCommad (string message)
{
    Console.Write(message);
    string? result = Console.ReadLine()!.ToLower();
    return result;
    
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

/*-------------------------SetNumbers-------------------------*/
// SetNumbers – пользователь вводит числа через пробел, а программа запоминает их в массив
int[] SetNumbers()
{
    Console.Write("Введите числа разделяя их пробелом: ");
    string inputNumbers = Console.ReadLine()!;

    Regex regex = new Regex(@"\b\d[0-9]{0,}\b");
    MatchCollection matches = regex.Matches(inputNumbers);
    int[] array = new int [matches.Count];
    if (matches.Count > 0)
    {
        int i = 0;
        foreach (Match match in matches)
        {
            array[i] = Convert.ToInt32(match.Value);
            i++;
        }
    }
    Console.WriteLine("Значения сохранены.");
    return array;
}

/*-------------------------AddNumbers-------------------------*/
// AddNumbers – пользователь вводит числа, которые добавятся к уже существующему массиву
int[] AddNumbers(int[] arrayOld)
{
    if(arrayOld.Length != 0)
    {
        Console.Write("Введите числа которые хотите добавить разделяя их пробелом: ");
        string inputNumbers = Console.ReadLine()!;

        Regex regex = new Regex(@"\b\d[0-9]{0,}\b");
        MatchCollection matches = regex.Matches(inputNumbers);

        int arrayOldLength = arrayOld.Length;
        int [] arrayNew = new int [arrayOldLength + matches.Count];
        arrayOld.CopyTo(arrayNew, 0);

        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                arrayNew[arrayOldLength] = Convert.ToInt32(match.Value);
                arrayOldLength++;
            }
        }
        Console.WriteLine("Значения добавлены.");
        return arrayNew;
    }
    else
    {
        Console.WriteLine("Массив пуст, сначала заполните массив выполнив команду SetNumbers.");
        return arrayOld;
    }
}

/*-------------------------RemoveNumbers-------------------------*/
// RemoveNumbers -  пользователь вводит числа, которые если  найдутся в массиве, то будут удалены
int[] RemoveNumbers(int [] arrayOld)
{
    if(arrayOld.Length != 0)
    {
        Console.Write("Введите числа которые хотите удалить из массива разделяя их пробелом: ");
        string inputNumbers = Console.ReadLine()!;

        Regex regex = new Regex(@"\b\d[0-9]{0,}\b");
        MatchCollection matches = regex.Matches(inputNumbers);
        int arrayOldDelCount = 0;
        for (int i = 0; i < arrayOld.Length; i++)
        {
            foreach (Match match in matches)
            {
                if (arrayOld[i] == Convert.ToInt32(match.Value))
                {
                    arrayOld[i] = -1;
                    arrayOldDelCount++;
                }
            }
        }
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

        Console.WriteLine("Значения удалены.");
        return arrayNew;
    }
    else
    {
        Console.WriteLine("Массив пуст, сначала заполните массив выполнив команду SetNumbers.");
        return arrayOld;
    }
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
