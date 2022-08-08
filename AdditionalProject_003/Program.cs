// 3. Игра угадайка. Программа загадывает случайное число. Пользователь его угадывает. Если пользователь дает неправильный ответ,
// то программа сообщает, больше загаданное число или меньше. На отгадывание дается 3 попытки.

int secretNumber = new Random().Next(1, 10);
int countUserTry = 0;
int maxUserTry = 3;

while (countUserTry < maxUserTry) {
    Console.Write("Введите число: ");
    int userNumber = Convert.ToInt32(Console.ReadLine());
    if (userNumber == secretNumber) {
        Console.WriteLine("You WIN!");
        break;
    }
    else if (userNumber < secretNumber) {
        Console.WriteLine("Ваше число меньше загаданного!");
        countUserTry++;
    }
    else if (userNumber > secretNumber) {
        Console.WriteLine("Ваше число больше загаданного!");
        countUserTry++;
    }
}
if (countUserTry == 3) {
    Console.WriteLine("Вы проиграли, было загадано число " + secretNumber);
}

