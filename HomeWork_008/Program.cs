/*
Задача 8: Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.
5 -> 2, 4
8 -> 2, 4, 6, 8
*/

Console.Write("Введите число: ");
string inputNum = Console.ReadLine();
int num = Convert.ToInt32(inputNum);
int count = 2;

while (count <= num) {
    Console.Write(count + " ");
    count += 2;
}