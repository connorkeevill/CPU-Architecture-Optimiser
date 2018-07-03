using System;

namespace CPU_Architecture_Optimiser
{
    internal class Program
    {
        public static void Main(string[] args) {
            int arrayLength = 100000000;
            int[] unsorted = createOrderedArray(arrayLength);
            int[] sorted = createOrderedArray(arrayLength);

            unsorted = shuffleArray(unsorted);

            Console.WriteLine("Unsorted Array starting now:");
            DateTime unsortedTimeBefore = DateTime.Now;
            int unsortedSum = addEvens(unsorted);
            DateTime unsortedTimeAfter = DateTime.Now;
            TimeSpan unsortedTimeTaken = unsortedTimeAfter - unsortedTimeBefore;

            Console.WriteLine("Time taken for unsorted array: " + unsortedTimeTaken.TotalMilliseconds.ToString());

            Console.WriteLine("Sorted Array starting now: ");
            DateTime sortedTimeBefore = DateTime.Now;
            int sortedSum = addEvens(sorted);
            DateTime sortedTimeAfter = DateTime.Now;
            TimeSpan sortedTimeTaken = sortedTimeAfter - sortedTimeBefore;

            Console.WriteLine("Time taken for sorted array: " + sortedTimeTaken.TotalMilliseconds.ToString());
        }

        private static bool isEven(int number) {
            return (number % 2 == 0);
        }

        private static int addEvens(int[] numbers) {
            int total = 0;

            foreach (int number in numbers) {
                if (isEven(number)) {
                    total += number;
                }
            }
            return total;
        }

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

        private static int[] createOrderedArray(int arraySize) {
            int[] array = new int[arraySize];

            for (int i = 0; i < arraySize; i++) {
                array[i] = i;
            }

            return array;
        }

        private static void printArray(int[] array) {
            foreach (int item in array) {
                Console.WriteLine(item.ToString());
            }
        }

        private static int[] createRandomArray() {
            int arraySize = 100000000;
            int[] array = new int[arraySize];

            Random randSeed = new Random();

            for (int i = 0; i < arraySize; i++) {
                array[i] = randSeed.Next(arraySize);
            }

            return array;
        }

    }
}
