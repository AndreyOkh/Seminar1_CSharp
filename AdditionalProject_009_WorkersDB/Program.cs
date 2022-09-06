// 9. Программа для ведения досье работников. Есть 3 массива: фио, должность и зарплата. В программе должна быть возможность 
// добавить досье, вывести все досье в формате фио-должность-зп (Иванов Иван Иванович – кассир – 25 000),
// удалить досье по номеру (номера начинаются с 1), поиск досье по фамилии. 
// Дополнительно: вывод всех досье с зп меньше или больше указанной, вывод всех 
// досье с указанной должностью. Можно придумать еще свои команды.

string[] user = new string[0];
string[] position = new string[0];
string[] income = new string[0];

bool isWork = true;

while (isWork)
{
    string command = ReadUserCommad("Введите команду: ");

    switch (command)
    {
        case ("generatedossiers"):
            GenerateProfile(ref user, ref position, ref income, Convert.ToInt32(ReadUserCommad("Введите количество генерируемых профилей: ")));
            break;

        case ("editdossier"):
            Array.Resize(ref user, user.Length + 1);
            Array.Resize(ref position, position.Length + 1);
            Array.Resize(ref income, income.Length + 1);
            
            user[user.Length - 1] = ReadUserCommad("Введите ФИО работника: ");
            position[position.Length - 1] = ReadUserCommad("Введите должность работника: ");
            income[income.Length - 1] = ReadUserCommad("Введите доход работника: ");
            break;

        case ("removedossier"):
            int idRemoveUser = Convert.ToInt32(ReadUserCommad("Введите ID пользователя которого необходимо удалить: "));
            user = RemoveRowArray(user, idRemoveUser);
            position = RemoveRowArray(position, idRemoveUser);
            income = RemoveRowArray(income, idRemoveUser);

            break;

        case ("dossiers"):
            if(user.Length != 0)
            {
                for (int i = 0; i < user.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {user[i]} - {position[i]} - {income[i]}р.");
                }
            }
            else Console.WriteLine("Досье отсутствуют!");
            break;

        case ("dossieronposition"):
            if(user.Length != 0)
            {
                string getUserOnPosition = ReadUserCommad("Введите название должности что бы вывести список нужных работников: ");
                PrintSearchDossier(user, position, income, position, getUserOnPosition);
            }
            else Console.WriteLine("Досье отсутствуют!");
            break;

        case ("dossieronincome"):
            if(user.Length != 0)
            {
                int getUserOnIncome = Convert.ToInt32(ReadUserCommad("Что бы вывести список сотрудников с определенным доходом укажите сумму (Например: -10000 выведет всех сотрудников с доходом меньше или равному 10000р, или 10000 выведет всех сотрудников с доходом больше или равному 10000р): "));

                PrintUserOnIncome(user, position, income, getUserOnIncome);
            }
            else Console.WriteLine("Досье отсутствуют!");
            break;

        case ("getdossier"):
            if (user.Length != 0)
            {
                string getSurName = ReadUserCommad("Введите фамилию работника: ");
                PrintSearchDossier(user, position, income, user, getSurName);
            }
            else Console.WriteLine("Досье отсутствуют!");
            break;

        case ("help"):
            Help();
            break;

        case ("exit"):
            isWork = false;
            break;

        default:
            Console.WriteLine("Команда неопознана.");
            goto case "help";
    }
}

/*-------------------------Ввод команд-------------------------*/
string ReadUserCommad(string message)
{
    Console.Write(message);
    string? result = Console.ReadLine()!.ToLower();
    return result;

}

/*-------------------------Справка-------------------------*/
void Help()
{
    Console.WriteLine(@"
                        GenerateDossiers - генерирует случайные досье (для тестов)
                        EditDossier – добавляет досье на работника
                        RemoveDossier -  удаляет досье пользователя
                        Dossiers – выводит все досье
                        DossierOnPosition - выводит все досье с указанное должностью
                        DossierOnIncome - выводит досье с ЗП выше или ниже указанной
                        GetDossier – поиск досье
                        Help - выведет справку
                        Exit - завершение работы");
}

/*-------------------------Справка-------------------------*/
string[] RemoveRowArray(string[] array, int index)
{
    try
    {
        string[] newArray = new string[array.Length - 1];
        Array.Copy(array, 0, newArray, 0, index - 1);
        Array.Copy(array, index, newArray, index - 1, array.Length - index);
        return newArray;
    }
    catch
    {
        Console.WriteLine("Не удалось выполнить команду RemoveRowArray.");
        return array;
    }

}

/*-------------------------Генератор досье пользователей (Только для теста)-------------------------*/
void GenerateProfile(ref string[] user, ref string[] position, ref string[] income, int amount)
{
    // Объявляем массивы данных
    string[] userFirstNameForGenerate = { "Андрей", "Иван", "Сергей", "Дмитрий", "Евгений", "Олег", "Николай", "Александр", "Владислав", "Владимир" };
    string[] userSurnameForGenerate = { "Иванов", "Петров", "Сидоров", "Зверев", "Конев", "Лосев", "Кошкин", "Матрешкин", "Какойтов", "Николаев" };
    string[] userPatronymicForGenerate = { "Иванович", "Сергеевич", "Андреевич", "Дмитриевич", "Олегович", "Николаевич", "Александрович", "Владимирович", "Владиславович", "Евгениевич" };
    string[] userPositionForGenerate = { "Аптекарь", "Президент", "Психолог", "Уборщик", "Администратор", "Продавец", "Кассир", "Директор", "Программист", "Аналитик" };

    int userLength = user.Length;

    // Увеличиваем массивы с досье
    Array.Resize(ref user, user.Length + amount);
    Array.Resize(ref position, position.Length + amount);
    Array.Resize(ref income, income.Length + amount);

    // Заполняем массивы новыми данным
    Random rand = new Random();
    for (int i = userLength; i < user.Length; i++)
    {
        // Генерируем рандомное досье
        int userFirstNameIndex = rand.Next(0, userFirstNameForGenerate.Length);
        int userSurnameIndex = rand.Next(0, userSurnameForGenerate.Length);
        int userPatronymicIndex = rand.Next(0, userPatronymicForGenerate.Length);
        int userPositionIndex = rand.Next(0, userPositionForGenerate.Length);
        string userIncome = rand.Next(10000, 100000).ToString();

        string userNameGenerate = $"{userSurnameForGenerate[userSurnameIndex]} {userFirstNameForGenerate[userFirstNameIndex]} {userPatronymicForGenerate[userPatronymicIndex]}";
        string userPositionGenerate = userPositionForGenerate[userPositionIndex];

        // Добавляем сгенерированное досье в массивы
        user[i] = userNameGenerate;
        position[i] = userPositionGenerate;
        income[i] = userIncome;

    }
}

void PrintUserOnIncome(string[] user, string[] position, string[] income, int getIncome)
{
    bool searchDirection = getIncome < 0 ? false : true;
    if (!searchDirection) getIncome *= -1;
    int count = 0;
    for (int i = 0; i < user.Length; i++)
    {
        bool validValue = Convert.ToInt32(income[i]) < getIncome ? false: true;
        if(validValue == searchDirection)
        {
            Console.WriteLine($"{count + 1}. {user[i]} - {position[i]} - {income[i]}р.");
            count++;
        }
    }
    if(count == 0) Console.WriteLine("Досье отсутствуют!");
}

void PrintSearchDossier(string[] user, string[] position, string[] income, string[] researchedArray, string getValue)
{
    int count = 0;
    for (int i = 0; i < researchedArray.Length; i++)
    {
        if( researchedArray[i].Contains(getValue, StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine($"{count + 1}. {user[i]} - {position[i]} - {income[i]}р.");
            count++;
        }
    }
    if(count == 0) Console.WriteLine("Досье отсутствуют!");
}