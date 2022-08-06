/*
Задача написать программу которая на вход принимает 2 числа и проверяет явзляется ли второе квадратом первого
*/
Console.Write("Введите первое число: ");
string inputFirstNum = Console.ReadLine();
Console.Write("Введите второе число: ");
string inputSecondNum = Console.ReadLine();
int firstNum = Convert.ToInt32(inputFirstNum);
int secondNum = Convert.ToInt32(inputSecondNum);

int sqrFirstNum = firstNum * firstNum;

if (sqrFirstNum == secondNum) {
    Console.WriteLine("Число " + secondNum + " является квадратом числа " + firstNum);
}
else {
    Console.WriteLine("Число " + secondNum + " не является квадратом числа " + firstNum);
}