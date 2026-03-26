using System;
using System.IO;

namespace Task1
{
    public delegate string TextOperation(string text);

    class Program
    {
        static void Main()
        {
            string inputFile = "textPD25.txt";
            string outputFile = "resultPD25.txt";

            string sampleText = "C# doesn't just age; it matures with every new version.\nFrom LINQ to records and pattern matching, it keeps getting sharper.\nStay curious, keep coding, and let the compiler do the heavy lifting.";
            File.WriteAllText(inputFile, sampleText);
            
            File.WriteAllText(outputFile, "");


            ProcessFile(inputFile, outputFile, text => text.ToUpper());

            ProcessFile(inputFile, outputFile, text => $"Кількість символів: {text.Length}");

            ProcessFile(inputFile, outputFile, text => 
            {
                int wordCount = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                return $"Кількість слів: {wordCount}";
            });

            Console.WriteLine("Завдання 1 виконано. Перевірте файл resultPD25.txt");
        }

        static void ProcessFile(string inputFilePath, string outputFilePath, TextOperation operation)
        {
            string text = File.ReadAllText(inputFilePath);
            
            string result = operation(text);
            
            using (StreamWriter sw = new StreamWriter(outputFilePath, true))
            {
                sw.WriteLine("--- Результат операції ---");
                sw.WriteLine(result);
                sw.WriteLine();
            }
        }
    }
}