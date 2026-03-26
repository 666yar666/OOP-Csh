using System.IO;
using System;

namespace task1
{
    public delegate string TextOperation(string input);
    
    class Programm
    {
        static void Main()
        {
            string inputFile = "textPD25.txt";
            string outputFile = "resultPD25.txt"; 

            File.WriteAllText(outputFile, "");

            if (!File.Exists(inputFile)) 
            {
                File.WriteAllText(inputFile, "C# is awesome. Good luck on the exam.");
            }

            ProcessFile(inputFile, outputFile, text => text.ToUpper());
            ProcessFile(inputFile, outputFile, text => $"Кількість символів: {text.Length}");
            ProcessFile(inputFile, outputFile, text => 
            {
                int wordCount = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                return $"Кількість слів: {wordCount}";
            });
            
            Console.WriteLine("Успішно, результат записаний в файл resultPD25.txt"); 
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