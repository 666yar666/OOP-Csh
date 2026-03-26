using System;
using System.IO;

namespace Task2
{
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }

    public class MessagePublisher
    {
        public event EventHandler<MessageEventArgs> MessageSent;

        public void Send(string message)
        {
            MessageSent?.Invoke(this, new MessageEventArgs(message));
        }
    }

    public class FileLogger
    {
        private string _filePath = "logPD25.txt";

        public void HandleMessageSent(object sender, MessageEventArgs e)
        {
            string logEntry = $"[{DateTime.Now:HH:mm:ss}] {e.Message}";
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                sw.WriteLine(logEntry);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger();

            publisher.MessageSent += logger.HandleMessageSent;

            Console.WriteLine("Введіть текст 4 рази:");

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Ввід {i + 1}: ");
                string input = Console.ReadLine();
                publisher.Send(input);
            }

            Console.WriteLine("Завдання 2 виконано. Перевірте файл logPD25.txt");
        }
    }
}