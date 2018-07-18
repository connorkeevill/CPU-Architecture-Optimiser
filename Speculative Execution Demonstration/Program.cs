using System;

namespace CPU_Architecture_Optimiser
{
    internal class Program
    {
        public static void Main() {
            // | Get the length of the arrays
            int arrayLength = getUserArrayLength();

            // | Create the arrays
            Console.WriteLine("Generating arrays...");
            Console.WriteLine();

            // | The unsorted array
            int[] unsorted = createOrderedArray(arrayLength);
            unsorted = shuffleArray(unsorted); // | Shuffle it
            Console.WriteLine("First (unsorted) array created.");

            // | The sorted array
            int[] sorted = createOrderedArray(arrayLength);
            Console.WriteLine("Second (sorted) array created.");
            Console.WriteLine();

            Console.WriteLine("Both arrays generated.");
            Console.WriteLine();

            // | Begin adding the numbers in the unsorted array
            Console.WriteLine("Unsorted Array starting now...");
            TimeSpan unsortedTimeTaken = getTimeSpanOfArraysEvens(unsorted);
            // | Output time taken to process the unsorted array
            Console.WriteLine("Time taken for unsorted array: " + unsortedTimeTaken.TotalMilliseconds.ToString());
            Console.WriteLine();

            // | Begin adding the numbers in the sorted array
            Console.WriteLine("Sorted Array starting now...");
            TimeSpan sortedTimeTaken = getTimeSpanOfArraysEvens(sorted);
            // | Output the time taken to process the sorted array
            Console.WriteLine("Time taken for sorted array: " + sortedTimeTaken.TotalMilliseconds.ToString());
            Console.WriteLine();

            // | Read to prevent the application closing instantly
            Console.ReadLine();
        }

        // | getTimeSpanOfArraysEvens()
        // |----------------------------------------------------
        // | Takes an array as a parameter and records the time
        // | it takes to calulate the sum of its even numbers.
        // |------------------------------------------------
        private static TimeSpan getTimeSpanOfArraysEvens(int[] array) {
            DateTime timeBefore = DateTime.Now;
            int sum = calculateSumOfEvens(array);
            DateTime timeAfter = DateTime.Now;
            TimeSpan timeTaken = timeAfter - timeBefore;
            return timeTaken;
        }

        // | getUserArrayLength()
        // |-----------------------------------------------------------
        // | Gets user input for the length of the arrays to be used.
        // |------------------------------------------------------
        private static int getUserArrayLength() {
            int arrayLength = -1; // | Initialised as -1 to make loop run

            // | While/Try loop to catch any error from the input not being in a number form.
            do {
                try {
                    Console.Write("Enter a (large) positive integer to define the length of the arrays: ");
                    arrayLength = Convert.ToInt32(Console.ReadLine());
                }
                catch {
                    Console.WriteLine("Something went wrong, try again. Please ensure that you type an integer.");
                }
            } while (arrayLength < 0);

            return arrayLength;
        }

        // | isEven()
        // |-------------------------------------------------------------
        // | Returns a flag indicating whether or not a number is even.
        // |--------------------------------------------------------
        private static bool isEven(int number) {
            return number % 2 == 0;
        }

        // | calculateSumOfEvens()
        // |---------------------------------------------------
        // | Iterates through the passed array and calculates
        // | the sum of all the even numbers in the array.
        // |-------------------------------------------
        private static int calculateSumOfEvens(int[] numbers) {
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
