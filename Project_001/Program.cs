/*
Задача написать программу которая будет выводить в консоль квадрат числа
*/

Console.Write("Введите число: ");
string input = Console.ReadLine();
int num = Convert.ToInt32(input);
int sqrNum = num * num;

Console.WriteLine(num + " в квадрате равно " + sqrNum);
