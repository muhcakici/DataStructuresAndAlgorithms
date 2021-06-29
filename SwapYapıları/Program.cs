using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapYapıları
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> randomNumbers = new List<int>();
            List<int> userNumbers = new List<int>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                randomNumbers.Add(random.Next(1, 101));
            }
            while (!userNumbers.Contains(-1))
            {
                userNumbers.Add(Convert.ToInt32(Console.ReadLine()));
            }
            userNumbers.Sort();
            int[] array = new int[userNumbers.Count];
            int[] array2 = new int[randomNumbers.Count];
            array = userNumbers.ToArray();
            array2 = randomNumbers.ToArray();

            var uniqueUser = array.Distinct();
            IEnumerable<int> uniqueRandom = array2.Distinct();
            var Elist = randomNumbers.Except(userNumbers);
            var Flist = userNumbers.Intersect(randomNumbers);
            var GList = uniqueUser.Intersect(uniqueRandom);

            foreach (var item in uniqueUser)
            {
                Console.WriteLine(item);
            }
        }
    }
}
