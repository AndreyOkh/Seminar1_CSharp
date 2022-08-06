/*
Написать программу которая будет выдавать день недели по заданному номеру
*/
Console.Write("Введите номер дня недели: ");
string input = Console.ReadLine();

string monday = "Понедельник";
string tuesday = "Вторник";
string wednesday = "Среда";
string thursday = "Четверг";
string friday = "Пятница";
string saturday = "Суббота";
string sunday = "Воскресенье";

if (input == "1") {
    Console.WriteLine(monday);
}
else if (input == "2") {
    Console.WriteLine(tuesday);
}
else if (input == "3") {
    Console.WriteLine(wednesday);
}
else if (input == "4") {
    Console.WriteLine(thursday);
}
else if (input == "5") {
    Console.WriteLine(friday);
}
else if (input == "6") {
    Console.WriteLine(saturday);
}
else if (input == "7") {
    Console.WriteLine(sunday);
}
else {
    Console.WriteLine("Значение введено не верно! Попробуйте еще раз.");
}