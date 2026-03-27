using System;

namespace Task1
{
    public delegate double MathOperation(double a, double b);

    class Program
    {
        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b) => a / b;

        static void Main()
        {
            MathOperation operation;

            operation = Add;
            Console.WriteLine("Додавання: " + operation(10, 5));

            operation = Subtract;
            Console.WriteLine("Віднімання: " + operation(10, 5));

            operation = Multiply;
            Console.WriteLine("Множення: " + operation(10, 5));

            operation = Divide;
            Console.WriteLine("Ділення: " + operation(10, 5));
        }
    }
}