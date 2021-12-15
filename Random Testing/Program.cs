using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace Random_Testing
{
    class Program
    {

        static void Main(string[] args)
        {
            Random randomNumber = new Random();

            #region First Array
            //Creates an array with all one value.
            Console.WriteLine("All One Value: \n");
            int[] sameValueArray = new int[50];

            for (int i = 0; i < sameValueArray.Length; i++)
            {
                sameValueArray[i] = 1;
                Console.WriteLine(sameValueArray[i]);
            }
            Console.WriteLine();
            #endregion

            #region Second Array
            //Creates an array with all of the values sorted.
            Console.WriteLine("Already Sorted: \n");
            int[] alreadySortedArray = new int[50];

            for (int i = 0; i < alreadySortedArray.Length; i++)
            {
                alreadySortedArray[i] = i;
                Console.WriteLine(alreadySortedArray[i]);
            }
            Console.WriteLine();
            #endregion

            #region Third Array
            //Creates an array with all of the values sorted.
            Console.WriteLine("Reverse Sort: \n");
            int[] reverseSortedArray = new int[50];

            for (int i = reverseSortedArray.Length - 1; i > 0; i--)
            {
                reverseSortedArray[i] = i;
                Console.WriteLine(reverseSortedArray[i]);
            }
            Console.WriteLine();
            #endregion

            #region Fourth Array
            //Creates an array with random values.
            Console.WriteLine("Random Values: \n");
            int[] notSortedArray = new int[50];

            for (int i = 0; i < notSortedArray.Length; i++)
            {
                notSortedArray[i] = randomNumber.Next(1, 100);
                Console.WriteLine(notSortedArray[i]);
            }
            Console.ReadLine();
            #endregion

            #region All first part sorting
            int[] sortedArrayOne = SortNumbers(sameValueArray);

            for (int i = 0; i < sortedArrayOne.Length; i++)
            {
                Console.WriteLine(sortedArrayOne[i]);
            }
            Console.ReadLine();

            int[] sortedArrayTwo = SortNumbers(alreadySortedArray);

            for (int i = 0; i < sortedArrayTwo.Length; i++)
            {
                Console.WriteLine(sortedArrayTwo[i]);
            }
            Console.ReadLine();

            int[] sortedArrayThree = SortNumbers(reverseSortedArray);

            for (int i = 0; i < sortedArrayThree.Length; i++)
            {
                Console.WriteLine(sortedArrayThree[i]);
            }
            Console.ReadLine();

            int[] sortedArrayFour = SortNumbers(notSortedArray);

            for (int i = 0; i < sortedArrayFour.Length; i++)
            {
                Console.WriteLine(sortedArrayFour[i]);
            }
            Console.ReadLine();
            #endregion

            #region Large Array Size Test
            for (int i = 0; i < 1001; i++)
            {
                int[] longArray = new int[100000];
                for(int j = 0; j < longArray.Length; j++)
                {
                    longArray[j] = randomNumber.Next(1, 10000);
                }

                int[] sortedLongArray = SortNumbers(longArray);

                for (int j = 0; j < sortedLongArray.Length; j++)
                {
                    Console.WriteLine(sortedLongArray[j]);
                }
            }
            #endregion
        }


        //The method used to sort the different arrays. Takes in an array, and outputs the array sorted.
        public static int[] SortNumbers(int[] arrayToSort)
        {
            int[] sortedArray = new int[arrayToSort.Length];
            int smallestNumber = 0;
            int largestNumber = 100;

            try
            {
                for (int i = 1; i < arrayToSort.Length; i++)
                {
                    if (arrayToSort[i] < smallestNumber)
                    {
                        smallestNumber = arrayToSort[i];
                    }
                    else if (arrayToSort[i] > largestNumber)
                    {
                        largestNumber = arrayToSort[i];
                    }
                }
                
                //the counts stores the numbers of items and then stores the place where each should be put.
                int[] counts = new int[largestNumber - smallestNumber + 1];


                for (int i = 0; i < arrayToSort.Length; i++)
                {
                    counts[arrayToSort[i] - smallestNumber] += 1;
                }

                counts[0] = counts[0] - 1;

                for (int i = 1; i < counts.Length; i++)
                {
                    counts[i] = counts[i] + counts[i - 1];
                }


                for (int i = arrayToSort.Length - 1; i >= 0; i--)
                {
                    //not sure why, but for some reason this line throws an error when it is typed like 
                    //sortedArray[counts[arrayToSort[i] - smallestNumber] -= 1] = arrayToSort[i];

                    //but not when typed like this. The difference is -= 1 vs just --. Honestly, I thought they were the same.
                    sortedArray[counts[arrayToSort[i] - smallestNumber]--] = arrayToSort[i];
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error here");
            }

            return sortedArray;
        }
    }
}
