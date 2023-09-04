// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, calcular cual es el resultado de su\r\ndivisión y el resto de esa división!");

int firtsNumber, secondNumber;
string response = string.Empty;

Console.Write("\nIngrese el primer número: ");
firtsNumber = Convert.ToInt32(Console.ReadLine());

Console.Write("\nIngrese el segundo número: ");
secondNumber = Convert.ToInt32(Console.ReadLine());

response = $"\nLa división es: {firtsNumber / secondNumber}\nEl residuo es: {firtsNumber % secondNumber}";

Console.WriteLine(response);