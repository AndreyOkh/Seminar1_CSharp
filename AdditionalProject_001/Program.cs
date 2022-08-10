/*
1. В переменной string есть секретное сообщение, во второй есть пароль. 
Пользователю программы даётся 3 попытки ввести пароль и увидеть секретное сообщение.
*/

string message = "Top secret message";
string passwd = "passwd";
string? userPasswd;

int countPasswd = 0;

while (countPasswd < 3) {
    Console.Write("Введите пароль: ");
    userPasswd = Console.ReadLine();
    if (userPasswd == passwd) {
        Console.WriteLine("Сообщение: " + message);
        countPasswd = 999;
    }
    else {
        Console.WriteLine("Не верный пароль, попробуйте еще раз!");
        countPasswd++;
    }
}
if (countPasswd == 999) {
    Console.WriteLine("The end!");
}
else {
    Console.WriteLine("Попытки ввода пароля закончились!");
}