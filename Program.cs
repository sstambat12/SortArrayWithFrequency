using System;
using System.Collections.Generic;

namespace SortArrayWithFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {2, 5, 2, 8, 5, 6, 8, 8};
            SortArray(arr);
            Console.Read();
        }

        private static void SortArray(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            int[] frequencyArray = new int[arr.Length];
            List<int> sortFrequency = new List<int>();
            List<int> uniqueNumbers = new List<int>();

            //Make dictionary of key as number and value as frequencies
            for(int i =0; i<arr.Length;i++)
            {
                if(! dict.ContainsKey(arr[i]))
                {
                    dict.Add(arr[i], 1);
                }
                else
                {
                    dict[arr[i]] += 1;

                }
            }

            //Make array of Frequencies
            for (int i = 0; i < arr.Length; i++)
            {
                frequencyArray[i] = dict[arr[i]];
            }

            //Make Dictionary of visited

            foreach (var key in dict.Keys)
            {
                visited.Add(key, false);
            }

            //make Arrays

            for (int i = 0; i < frequencyArray.Length; i++)
            {
                if(visited[arr[i]]==false)
                {
                    int j;
                    for (j = sortFrequency.Count - 1 ; j >=0 ; j--)
                    {
                        if(frequencyArray[i] <= sortFrequency[j])
                        {
                            break;
                        }
                    }
                    sortFrequency.Insert(j + 1, frequencyArray[i]);
                    uniqueNumbers.Insert(j + 1, arr[i]);
                    visited[arr[i]] = true;
                }
            }

            //Print final sorted array

            for (int i = 0; i < uniqueNumbers.Count; i++)
            {
                for (int j = 0; j < dict[uniqueNumbers[i]]; j++)
                {
                    Console.WriteLine($"{uniqueNumbers[i]} ,");
                }
            }
            
        }
    }
}
