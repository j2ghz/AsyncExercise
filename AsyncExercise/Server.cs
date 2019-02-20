using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExercise
{
    public class Server
    {

        /* Return [amount] random numbers between [min] and [max] inclusive */
        public async Task<int[]> GetNumbers(int amount, int min, int max)
        {
            await Task.Delay(10000);
            int[] res = new int[amount];
            Random r = new Random();
            int count = 0;
            while (count < amount)
            {
                int x = r.Next(max - min + 1) + min;
                res[count++] = x;
            }
            return res;
        }
    }
}
