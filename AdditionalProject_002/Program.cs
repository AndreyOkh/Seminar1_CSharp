/*
2. Есть программа с бесконечным циклом. Когда пользователь вводит exit программа заканчивается
*/

string command = "";
int i = 0;

 while (command != "exit") {
    Console.WriteLine(i + " ");
    i++;
    Console.Write("Введите команду exit что бы прекратить: ");
    command = Console.ReadLine();
}