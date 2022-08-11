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
HelpCommand();
while (command != "exit")
{
    command = ReadUserCommad("Введите команду: ");

    switch (command)
    {
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

        case ("rates"):
            foreach (var cost in costsCurrencys)
            {
                Console.WriteLine($"{cost.Key} = {cost.Value}");
            }
            continue;

        case ("balances"):
            foreach (var money in amountUserMoney)
            {
                Console.WriteLine(money.Key + " = " + money.Value);
            }
            continue;
        
        case ("help"):
            HelpCommand();
            continue;

        case ("exit"):
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
    Console.WriteLine($"{amount} {currencyCode.ToUpper()} это {Math.Round(value, 2)} в рублях.");
}

/*-------------------------Конвертация валюты в другую валюту-------------------------*/
void ConvertToCurrency (string firstCurrencyCode, double firstCostCurrency, string secondCurrencyCode, double secondCostCurrency, double amount)
{
    double firstCurrencyToRub = firstCostCurrency * amount;
    double rubToSecondCurrency = firstCurrencyToRub / secondCostCurrency;
    Console.WriteLine($"{amount} {firstCurrencyCode.ToUpper()} это {Math.Round(rubToSecondCurrency, 2)} в {secondCurrencyCode.ToUpper()}");
}

/*-------------------------Help-------------------------*/
void HelpCommand ()
{
    Console.WriteLine(@"
        Команды:
        ConvertToCurrency - конвертирует одну валюту в другую.
        ConverToRub - конвертирует выбранную валюту в рубли
        Rates - показывает курсы валют
        Balances - показывает баланс в разных валютах
        Help - выводит справку
        Exit - закрывает программу
        
        Коды валют:
        usd - Американский доллар
        eur - евро
        sek - Шведский крон
        chf - Швейцарский франк
        jpu - Японская иена"
    );
}