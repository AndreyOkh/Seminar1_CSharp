// 4. Продолжаем прокачивать приложение с командами. Добавить к программе, которая заканчивается, когда пишем exit 
// еще 4 команды (их можно придумать самому). Например:
// SetName – Установить имя
// Help – вывести список команд
// SetPassword – Установить пароль
// Exit – выход
// WriteName – вывести имя после ввода пароля

/*--------------------Объявляем переменные--------------------*/
string command = "";
string name = "";
string password = "";

/*--------------------Цикл ожидания команды--------------------*/
 while (command != "exit") {
    Console.Write("Введите команду: ");
    command =  Console.ReadLine().ToLower();

    switch(command)
    {
        /*--------------------Команда установит имя--------------------*/
        case ("setname"):
            Console.Write("Введите имя: ");
            name =  Console.ReadLine();
            continue;

        /*--------------------Команда установит пароль--------------------*/
        case ("setpassword"):
            Console.Write("Введите пароль: ");
            password =  Console.ReadLine();
            continue;

        /*--------------------Команда выводит имя если оно было установлено и пароль совпадает--------------------*/
        case ("writename"):
            if (name != "" && password != "")
            {
                Console.Write("Введите пароль: ");
                string passwordUser =  Console.ReadLine();
                if (passwordUser == password) 
                {
                    Console.WriteLine($"Привет {name}");
                }
                else
                {
                    Console.WriteLine("Пароль не верный");
                }
            }
            else 
            {
                Console.WriteLine("Не заданы имя или пароль");
            }
            continue;

        /*--------------------Команда выведет справку--------------------*/
        case ("help"):
            Console.WriteLine($"SetName – Установить имя\n" + 
            "Help – вывести список команд\n" +
            "SetPassword – Установить пароль\n" +
            "Exit – выход\n" +
            "WriteName – вывести имя после ввода пароля\n");
            continue;

        /*--------------------Команда прекратит выполнение программы--------------------*/
        case ("exit"):
            break;

        /*--------------------Если команды не существует буудет показана подсказка--------------------*/
        default:
            Console.WriteLine("Я не знаю таких команд, введите help что бы вызвать справку или exit что бы выйти.");
            continue;
    }
}