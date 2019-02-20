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

                mServer.GetNumbers(number, 1, 6).ContinueWith(async r =>
                {
                    var numbers = await r;
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
