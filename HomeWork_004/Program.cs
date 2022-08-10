/*
Задача 4. Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.
2 3 7 -> 7
44 5 78 -> 78
22 3 9 -> 22
*/

Console.Write("Введите первое число: ");
string? inputNum1 = Console.ReadLine();
int num1 = Convert.ToInt32(inputNum1);

Console.Write("Введите второе число: ");
string? inputNum2 = Console.ReadLine();
int num2 = Convert.ToInt32(inputNum2);

Console.Write("Введите третье число: ");
string? inputNum3 = Console.ReadLine();
int num3 = Convert.ToInt32(inputNum3);

int max = num1;

if (max < num2) {
    max = num2;
}
if (max < num3) {
    max = num3;
}

Console.WriteLine("Максимальное число: " + max);