// Конвертер валют. У пользователя есть баланс в каждой из представленных валют. 
// С помощью команд он может попросить сконвертировать одну валюту в другую. 
// Курс конвертации просто описать в программе. 
// Программа заканчивает свою работу в тот момент, когда решит пользователь.

/*-------------------------Куры валют-------------------------*/
var costsCurrencys = new Dictionary<string, double>()
{
    {"usd", 60.45},
    {"eur", 61.70},
    {"sek", 5.94},
    {"chf", 63.53},
    {"jpu", 0.45},
    {"rub", 1}
};

/*-------------------------Баланс пользователя-------------------------*/
var amountUserMoney = new Dictionary<string, double>()
{
    {"usd", 534},
    {"eur", 624},
    {"sek", 4645},
    {"chf", 435},
    {"jpu", 344},
    {"rub", 85734}
};

/*-------------------------Help-------------------------*/
void HelpCommand ()
{
    Console.WriteLine(@"
    Команды:
        Converter - конвертирует одну валюту в другую.
        Rates - показывает курсы валют
        Balances - показывает баланс в разных валютах
        Help - выводит справку
        Exit - закрывает программу"
    );
}

/*-------------------------CodesCurrencys-------------------------*/
void CodesCurrencysCommand ()
{
    Console.WriteLine(@"
    Коды валют:
        USD - Американский доллар
        EUR - Евро
        SEK - Шведский крон
        CHF - Швейцарский франк
        JPU - Японская иена
        RUB - Рубль"
    );
}


/*-------------------------Команды пользователя-------------------------*/
string? command = "";
bool isWork = false;
HelpCommand();
while (!isWork)
{
    command = ReadUserCommad("Введите команду: ");

    switch (command)
    {
        /*-------------------------Команда конвертирует одну валюту в другую-------------------------*/
        case ("converter"):
            CodesCurrencysCommand();
            string firstСurrencyCode = ReadUserCommad("Введите код валюты которую вы хотите конвертировать: ");
            if (costsCurrencys.ContainsKey(firstСurrencyCode))
            {
                string amountToConvert = ReadUserCommad("Введите сумму для конвертации или ALL если хотите конвертировать всё: ");
                bool amountToConvertTry = double.TryParse(amountToConvert, out double amountToConvertDouble);
                if (amountToConvert == "all")
                {
                    amountToConvertDouble = amountUserMoney[firstСurrencyCode];
                    ConvertAndTransferMoney(costsCurrencys, amountUserMoney, amountToConvert, firstСurrencyCode, amountToConvertDouble);
                }
                else if (amountToConvertTry)
                {
                    ConvertAndTransferMoney(costsCurrencys, amountUserMoney, amountToConvert, firstСurrencyCode, amountToConvertDouble);
                }
                else
                {
                    Console.WriteLine("Введена неизвестная команда.");
                    continue;
                }

            }
            else
            {
                Console.WriteLine("Введенный код валюты не найден!");
                CodesCurrencysCommand();
            }
            continue;

        /*-------------------------Команда выводит курсы валют-------------------------*/
        case ("rates"):
            Console.WriteLine("Курсы валют: ");
            foreach (var cost in costsCurrencys)
            {
                Console.WriteLine($"{cost.Key.ToUpper()} = {cost.Value}");
            }
            continue;

        /*-------------------------Команда выводит балансы пользователя в каждой валюте-------------------------*/
        case ("balances"):
            Console.WriteLine("Баланс: ");
            foreach (var money in amountUserMoney)
            {
                Console.WriteLine($"{money.Key.ToUpper()} = {money.Value}");
            }
            continue;
        
        /*-------------------------Команда вызывает справку-------------------------*/
        case ("help"):
            HelpCommand();
            CodesCurrencysCommand();
            continue;

        /*-------------------------Команда прерывает выполнение программы-------------------------*/
        case ("exit"):
            isWork = true;
            break;

        default:
            Console.WriteLine("Я не знаю такую команду.");
            HelpCommand();
            continue;

    }

}


/*-------------------------Функции-------------------------*/

/*-------------------------Запрос кода валют-------------------------*/
string ReadUserCommad (string message)
{
    Console.Write(message);
    string? result = Console.ReadLine()!.ToLower();
    return result;
    
}

/*-------------------------Конвертация валюты-------------------------*/
double ConvertToCurrency (string firstCurrencyCode, double firstCostCurrency, string secondCurrencyCode, double secondCostCurrency, double amount)
{
    double firstCurrencyToRub = firstCostCurrency * amount;
    double rubToSecondCurrency = firstCurrencyToRub / secondCostCurrency;
    Console.WriteLine($"{amount} {firstCurrencyCode.ToUpper()} = {Math.Round(rubToSecondCurrency, 2)} {secondCurrencyCode.ToUpper()}");
    return rubToSecondCurrency;
}

/*-------------------------Перевод валюты-------------------------*/
void TransferCurrency (Dictionary<string, double> amountUserMoney, string firstСurrencyCode, string secondCurrencyCode, double amountToConvert, double amountSecondCurrency)
{
    amountUserMoney[firstСurrencyCode] = Math.Round(amountUserMoney[firstСurrencyCode] - amountToConvert, 2);
    amountUserMoney[secondCurrencyCode] = Math.Round(amountUserMoney[secondCurrencyCode] + amountSecondCurrency, 2);
    Console.WriteLine("Готово!");
}

/*-------------------------Конвертация и перевод валюты-------------------------*/
void ConvertAndTransferMoney (Dictionary<string, double> costsCurrencys, Dictionary<string, double> amountUserMoney, string amountToConvert, string firstСurrencyCode, double amountToConvertDouble)
{
    string secondCurrencyCode = ReadUserCommad($"Введите код валюты в которую вы хотите конвертировать {amountToConvert} {firstСurrencyCode.ToUpper()}: ");
    if (costsCurrencys.ContainsKey(firstСurrencyCode) && costsCurrencys.ContainsKey(secondCurrencyCode))
    {
        double amountSecondCurrency = ConvertToCurrency(firstСurrencyCode, costsCurrencys[firstСurrencyCode],secondCurrencyCode , costsCurrencys[secondCurrencyCode], amountToConvertDouble);
        
        /*-------------------------Перевод валюты на счет после конвертации-------------------------*/
        if (amountToConvertDouble <= amountUserMoney[firstСurrencyCode])
        {
            string transferCommand = ReadUserCommad($"Хотите перевести {amountToConvertDouble} {firstСurrencyCode.ToUpper()} на счет {secondCurrencyCode.ToUpper()}? Введите YES или NO: ");
            if (transferCommand == "yes" || transferCommand == "y")
            {
                TransferCurrency(amountUserMoney, firstСurrencyCode, secondCurrencyCode, amountToConvertDouble, amountSecondCurrency);
            }
        }
        else
        {
            Console.WriteLine($"У вас на балансе {amountUserMoney[firstСurrencyCode]} {firstСurrencyCode.ToUpper()}. Этого не достаточно что бы перевести {amountToConvertDouble} {firstСurrencyCode.ToUpper()} в {secondCurrencyCode.ToUpper()}");
        }
    }
    else
    {
        Console.WriteLine("Введенный код валюты не найден!");
        CodesCurrencysCommand();
    }
}