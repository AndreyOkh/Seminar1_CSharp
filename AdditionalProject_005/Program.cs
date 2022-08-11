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
    {"jpu", 0.45}
};

/*-------------------------Баланс пользователя-------------------------*/
var amountUserMoney = new Dictionary<string, double>()
{
    {"usd", 53425},
    {"eur", 64524},
    {"sek", 34645},
    {"chf", 43245},
    {"jpu", 46344}
};

/*-------------------------Команды пользователя-------------------------*/
string? command = "";
bool exit = false;
HelpCommand();
while (exit != true)
{
    command = ReadUserCommad("Введите команду: ");

    switch (command)
    {
        /*-------------------------Команда конвертирует одну валюту в другую-------------------------*/
        case ("converttocurrency"):
            string firstСurrencyCode = ReadUserCommad("Введите код валюты которую вы хотите конвертировать: ");
            if (costsCurrencys.ContainsKey(firstСurrencyCode))
            {
                string secondCurrencyCode = ReadUserCommad($"У вас {amountUserMoney[firstСurrencyCode]} {firstСurrencyCode.ToUpper()}, введите код валюты в которую вы хотите их конвертировать: ");
                if (costsCurrencys.ContainsKey(firstСurrencyCode) && costsCurrencys.ContainsKey(secondCurrencyCode))
                {
                    ConvertToCurrency(firstСurrencyCode, costsCurrencys[firstСurrencyCode],secondCurrencyCode , costsCurrencys[secondCurrencyCode], amountUserMoney[firstСurrencyCode]);
                }
                else
                {
                    Console.WriteLine("Введенный код валюты не найден! Введите help что бы вызвать справку.");
                }
            }
            else
            {
                Console.WriteLine("Введенный код валюты не найден! Введите help что бы вызвать справку.");
            }
            continue;

        /*-------------------------Команда конвертирует валюту в рубли-------------------------*/
        case ("converttorub"):
            string currencyCode = ReadUserCommad("Введите код валюты что бы конвертировать ее в рубли: ");
            if (costsCurrencys.ContainsKey(currencyCode))
            {
                ConvertToRub(currencyCode, costsCurrencys[currencyCode], amountUserMoney[currencyCode]);
            }
            else
            {
                Console.WriteLine("Введенный код валюты не найден! Введите help что бы вызвать справку.");
            }
            continue;

        /*-------------------------Команда выводит курсы валют-------------------------*/
        case ("rates"):
            foreach (var cost in costsCurrencys)
            {
                Console.WriteLine($"{cost.Key.ToUpper()} = {cost.Value}");
            }
            continue;

        /*-------------------------Команда выводит балансы пользователя в каждой валюте-------------------------*/
        case ("balances"):
            foreach (var money in amountUserMoney)
            {
                Console.WriteLine($"{money.Key.ToUpper()} = {money.Value}");
            }
            continue;
        
        /*-------------------------Команда вызывает справку-------------------------*/
        case ("help"):
            HelpCommand();
            continue;

        /*-------------------------Команда прерывает выполнение программы-------------------------*/
        case ("exit"):
            exit = true;
            break;

        default:
            Console.WriteLine("Я не знаю таких команд, введите help что бы вызвать справку или exit что бы выйти.");
            continue;

    }

}


/*-------------------------Функции-------------------------*/

/*-------------------------Запрос кода валют-------------------------*/
string ReadUserCommad (string message)
{
    Console.Write(message);
    string? result = Console.ReadLine().ToLower();
    return result;
}

/*-------------------------Концертация валюты в рубли-------------------------*/
void ConvertToRub (string currencyCode,double costsCurrency, double amount)
{
    double value = costsCurrency * amount;
    Console.WriteLine($"{amount} {currencyCode.ToUpper()} = {Math.Round(value, 2)} RUB.");
}

/*-------------------------Конвертация валюты в другую валюту-------------------------*/
void ConvertToCurrency (string firstCurrencyCode, double firstCostCurrency, string secondCurrencyCode, double secondCostCurrency, double amount)
{
    double firstCurrencyToRub = firstCostCurrency * amount;
    double rubToSecondCurrency = firstCurrencyToRub / secondCostCurrency;
    Console.WriteLine($"{amount} {firstCurrencyCode.ToUpper()} = {Math.Round(rubToSecondCurrency, 2)} {secondCurrencyCode.ToUpper()}");
}

/*-------------------------Help-------------------------*/
void HelpCommand ()
{
    Console.WriteLine(@"
    Команды:
        ConvertToCurrency - конвертирует одну валюту в другую.
        ConvertToRub - конвертирует выбранную валюту в рубли
        Rates - показывает курсы валют
        Balances - показывает баланс в разных валютах
        Help - выводит справку
        Exit - закрывает программу
        
    Коды валют:
        USD - Американский доллар
        EUR - евро
        SEK - Шведский крон
        CHF - Швейцарский франк
        JPU - Японская иена"
    );
}