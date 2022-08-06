/*
Задача 2. Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее, а какое меньшее.
a = 5; b = 7 ->  max = 7
a = 2; b = 10 -> max = 10
a = -9; b = -3 -> max = -3
*/
Console.Write("Введи первое число: ");
string firstNumberInput = Console.ReadLine();
Console.Write("Введи второе число: ");
string secondNumberInput = Console.ReadLine();

int firstNumber = Convert.ToInt32(firstNumberInput);
int secondNumber = Convert.ToInt32(secondNumberInput);

if (firstNumber > secondNumber) {
    Console.WriteLine(firstNumber);
}
else if (firstNumber < secondNumber) {
    Console.WriteLine(secondNumber);
}
else {
    Console.WriteLine("Значеения равны");
}