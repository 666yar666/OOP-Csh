using System;

namespace Task2
{
    public delegate void NotificationHandler(string message);

    class Program
    {
        static void SendEmail(string message)
        {
            Console.WriteLine("Email sent: " + message);
        }

        static void SendSMS(string message)
        {
            Console.WriteLine("SMS sent: " + message);
        }

        static void Main()
        {
            NotificationHandler handler = SendEmail;
            handler += SendSMS;

            handler("Hello, this is a test notification!");
        }
    }
}