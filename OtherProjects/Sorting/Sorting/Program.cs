using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] nums = new int[30];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rand.Next(10);
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();



            for (int x = 0; x < nums.Length-1; x++)
            {
                bool isSorted = true;
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        int hodnota = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = hodnota;
                        isSorted = false;
                    }
                }
                if (isSorted)
                    break;

                PrintArr(nums);
            }

            // -------VYPIS


            Console.ReadLine();
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

        }

        public static void PrintArr(int[] Arr)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                //[i] = rand.Next(10);
                Console.Write(Arr[i] + " ");

            }
            Console.WriteLine();
        }
    }
}
