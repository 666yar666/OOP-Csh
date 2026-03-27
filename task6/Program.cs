using System;

namespace Task6
{
    public delegate bool Validator(string text);

    class Program
    {
        static Validator GetValidator(int minLength)
        {
            return text => text != null && text.Length >= minLength;
        }

        static void Main()
        {
            Validator loginValidator = GetValidator(3);
            Validator passwordValidator = GetValidator(8);

            Console.WriteLine("Перевірка логіна 'ab': " + loginValidator("ab"));
            Console.WriteLine("Перевірка логіна 'admin': " + loginValidator("admin"));

            Console.WriteLine("Перевірка пароля '123': " + passwordValidator("123"));
            Console.WriteLine("Перевірка пароля 'qwerty12345': " + passwordValidator("qwerty12345"));
        }
    }
}