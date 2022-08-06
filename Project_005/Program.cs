/*
Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает последнюю цифру этого числа.
*/
Console.Write("Введите трехзначное число: ");
string input = Console.ReadLine();
int number = Convert.ToInt32(input);

if (number > 99 && number < 1000) {
    int result = number % 10;
    Console.WriteLine(result);
}
