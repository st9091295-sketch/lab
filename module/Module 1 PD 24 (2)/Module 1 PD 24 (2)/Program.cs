using Module_1_PD_24__2_;
using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "logPD24.txt";

            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger(file);

            logger.Subscribe(publisher);

            for (int i = 0; i < 4; i++)
            {
                Console.Write("Enter: ");
                string msg = Console.ReadLine();

                publisher.Send(msg);
            }

            Console.WriteLine("Saved to file");
        }
    }
}