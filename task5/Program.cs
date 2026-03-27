using System;

namespace Task5
{
    class Logger
    {
        public Action<string> LogHandler;

        public void Log(string message)
        {
            if (LogHandler != null)
            {
                LogHandler(message);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Logger logger = new Logger();

            // Спочатку виводимо просто в консоль
            logger.LogHandler = message => Console.WriteLine(message);
            logger.Log("Перше повідомлення системи");

            // Змінюємо поведінку "на льоту" - тепер у верхньому регістрі
            logger.LogHandler = message => Console.WriteLine(message.ToUpper());
            logger.Log("Друге повідомлення системи (великими літерами)");
        }
    }
}