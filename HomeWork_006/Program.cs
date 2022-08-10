/*
Задача 6: Напишите программу, которая на вход принимает число и выдаёт, является ли число чётным 
(делится ли оно на два без остатка).
4 -> да
-3 -> нет
7 -> нет
*/

Console.Write("Введите число: ");
string? inputNum = Console.ReadLine();
int num = Convert.ToInt32(inputNum);

if (num % 2 == 0) {
    Console.WriteLine("Число " + num + " чётное.");
}
else {
    Console.WriteLine("Число " + num + " не чётное.");
}