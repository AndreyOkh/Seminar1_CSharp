/*
Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает последнюю цифру этого числа.
*/
Console.Write("Введите трехзначное число: ");
string input = Console.ReadLine();
int number = Convert.ToInt32(input);

int result = number % 10;

Console.WriteLine(result);