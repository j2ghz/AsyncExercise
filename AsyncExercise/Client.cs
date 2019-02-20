using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExercise
{
    public class Client
    {
        private readonly Server mServer;

        public Client(Server server)
        {
            mServer = server;
        }

        public void run()
        {
            while (true)
            {
                int number = GetNumber("How many numbers (0 for stop): ");
                if (number == 0) break;

                ThreadPool.QueueUserWorkItem(async _ =>
                {
                    var numbers = await mServer.GetNumbers(number, 1, 6);
                    Console.WriteLine("Here are the numbers from the server: ");
                    foreach (int x in numbers)
                    {
                        Console.WriteLine(x);
                    }
                });

            }
        }

        private int GetNumber(String text)
        {
            Console.WriteLine(text);
            return int.Parse(Console.ReadLine());
        }


    }
}
