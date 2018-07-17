using System;

namespace CPU_Architecture_Optimiser
{
    internal class Program
    {
        public static void Main() {
            // | The length for the arrays to be
            int arrayLength = 100000000;

            Console.WriteLine("Generating arrays...");

            // | Create the arrays
            int[] unsorted = createOrderedArray(arrayLength);
            int[] sorted = createOrderedArray(arrayLength);

            // | Shuffle the array to be 'unsorted'
            unsorted = shuffleArray(unsorted);

            Console.WriteLine("Arrays generated.");

            // | Begin adding the numbers in the unsorted array
            Console.WriteLine();
            Console.WriteLine("Unsorted Array starting now...");
            DateTime unsortedTimeBefore = DateTime.Now;
            int unsortedSum = addEvens(unsorted);
            DateTime unsortedTimeAfter = DateTime.Now;
            TimeSpan unsortedTimeTaken = unsortedTimeAfter - unsortedTimeBefore;


            // | Output time taken to process the unsorted array
            Console.WriteLine("Time taken for unsorted array: " + unsortedTimeTaken.TotalMilliseconds.ToString());

            // | Begin adding the numbers in the sorted array
            Console.WriteLine();
            Console.WriteLine("Sorted Array starting now...");
            DateTime sortedTimeBefore = DateTime.Now;
            int sortedSum = addEvens(sorted);
            DateTime sortedTimeAfter = DateTime.Now;
            TimeSpan sortedTimeTaken = sortedTimeAfter - sortedTimeBefore;

            // | Output the time taken to process the sorted array
            Console.WriteLine("Time taken for sorted array: " + sortedTimeTaken.TotalMilliseconds.ToString());

            // | Read to prevent the application closing instantly
            Console.ReadLine();
        }

        // | isEven()
        // |-------------------------------------------------------------
        // | Returns a flag indicating whether or not a number is even.
        // |--------------------------------------------------------
        private static bool isEven(int number) {
            return (number % 2 == 0);
        }

        // | addEvens()
        // |---------------------------------------------------
        // | Iterates through the passed array and calculates
        // | the sum of all the even numbers in the array.
        // |-------------------------------------------
        private static int addEvens(int[] numbers) {
            int total = 0;

            foreach (int number in numbers) {
                if (isEven(number)) {
                    total += number;
                }
            }
            return total;
        }

        // | shuffleArray()
        // |----------------------------------
        // | Mixes up an array of integers.
        // |---------------------------
        private static int[] shuffleArray(int[] array)
        {
            Random r = new Random();
            for (int item = array.Length; item > 0; item--)
            {
                int randomIndex = r.Next(item);
                int placeHolder = array[randomIndex];
                array[randomIndex] = array[item - 1];
                array[item - 1]  = placeHolder;
            }
            return array;
        }

        // | createOrderedArray()
        // |----------------------------------------------------------
        // | Creates an array of a specified size, which is ordered.
        // |----------------------------------------------------
        private static int[] createOrderedArray(int arraySize) {
            int[] array = new int[arraySize];

            for (int i = 0; i < arraySize; i++) {
                array[i] = i;
            }

            return array;
        }

        // | printArray()
        // |---------------------------------------
        // | Iterates through an array an outputs
        // | each item's value to the console.
        // |-------------------------------
        private static void printArray(int[] array) {
            foreach (int item in array) {
                Console.WriteLine(item.ToString());
            }
        }

        // | createRandomArray()
        // |-------------------------------------------------------------
        // | Creates an array of random numbers, of a specified amount.
        // |-------------------------------------------------------
        private static int[] createRandomArray(int arraySize) {
            int[] array = new int[arraySize];

            Random randSeed = new Random();

            for (int i = 0; i < arraySize; i++) {
                array[i] = randSeed.Next(arraySize);
            }

            return array;
        }

    }
}
