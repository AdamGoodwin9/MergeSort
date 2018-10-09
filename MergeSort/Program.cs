using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] arr = new int[r.Next(20,41)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(1, 101);
            }
            Array.ForEach(arr, (num) => { Console.Write(num + " "); });
            Console.WriteLine();
            MergeSort(arr);
            Array.ForEach(arr, (num) => { Console.Write(num + " "); });
            Console.ReadKey();
        }

        static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }
            
            int halfLength = arr.Length / 2;

            int[] lower = new int[arr.Length / 2];
            int[] higher = new int[arr.Length % 2 == 0 ? halfLength : halfLength + 1];

            for (int i = 0; i < lower.Length; i++)
            {
                lower[i] = arr[i];
            }

            for (int i = 0; i < higher.Length; i++)
            {
                higher[i] = arr[i + lower.Length];
            }

            lower = MergeSort(lower);
            higher = MergeSort(higher);
            
            for (int i = 0, j = 0, k = 0; i < arr.Length; i++)
            {
                if(k >= higher.Length)
                {
                    arr[i] = lower[j++];
                }
                else if(j >= lower.Length)
                {
                    arr[i] = higher[k++];
                }
                else if(lower[j] <= higher[k])
                {
                    arr[i] = lower[j++];
                }
                else
                {
                    arr[i] = higher[k++];
                }
            }
            
            return arr;
        }
    }
}