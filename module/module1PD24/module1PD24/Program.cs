using System;
using System.IO;

namespace Task1
{
    internal class TextProcessor
    {
        public delegate string TextOperation(string text);

        public void ProcessFile(string inputPath, string outputPath, TextOperation operation)
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Файл " + inputPath + " не знайдено");
                return;
            }

            string text = File.ReadAllText(inputPath);
            string result = operation(text);
            File.AppendAllText(outputPath, result + "\n");
        }

        public string ToUpperCase(string text)
        {
            return "UPPER: " + text.ToUpper();
        }

        public string CountChars(string text)
        {
            return "Chars: " + text.Length;
        }

        public string CountWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return "Words: " + words.Length;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "textPD24.txt";
            string output = "resultPD24.txt";

            File.WriteAllText(output, "");

            TextProcessor processor = new TextProcessor();

            processor.ProcessFile(input, output, processor.ToUpperCase);
            processor.ProcessFile(input, output, processor.CountChars);
            processor.ProcessFile(input, output, processor.CountWords);

            Console.WriteLine("Done");
        }
    }
}