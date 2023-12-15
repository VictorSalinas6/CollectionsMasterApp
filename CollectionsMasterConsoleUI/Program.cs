using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50

            var numbers = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50

            Populater(numbers);

            //TODO: Print the first number of the array

            Console.WriteLine($"First number: {numbers[0]}\n");

            //TODO: Print the last number of the array

            Console.WriteLine($"Last number: {numbers[numbers.Length - 1]}\n");

            Console.WriteLine("All Numbers Original\n");
            //UNCOMMENT this method to print out your numbers from arrays or lists

            NumberPrinter(numbers);

            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");

            var reversedNumbers = numbers.Reverse();

            foreach (int number in reversedNumbers)
                Console.WriteLine(number);

            Console.WriteLine("---------REVERSE CUSTOM------------");

            ReverseArray(numbers);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");

            ThreeKiller(numbers);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */

            Array.Sort(numbers);

            Console.WriteLine("Sorted numbers:");

            foreach (int number in numbers)
                Console.WriteLine(number);


            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List

            var numberList = new List<int>();

            //TODO: Print the capacity of the list to the console

            Console.WriteLine($"\nCapacity before the Populater: {numberList.Capacity}");

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            
            Populater(numberList);

            //TODO: Print the new capacity

            Console.WriteLine($"\nCapacity after the Populater: {numberList.Capacity}");

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            //Console.WriteLine("What number will you search for in the number list?");
            
            //string answer = Console.ReadLine();

            bool notNumber = false;

            int numberAnswer;

            do
            {
                Console.WriteLine("What number will you search for in the number list?");
                string answer = Console.ReadLine();

                if (int.TryParse(answer, out numberAnswer))
                    { NumberChecker(numberList, numberAnswer); notNumber = false;}
                else
                    { Console.WriteLine("Please use a number next time!\n"); notNumber = true; }
            }while(notNumber);


            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists

            NumberPrinter(numberList);

            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");

            OddKiller(numberList);
            
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");

            numberList.Sort();

            foreach (int number in numberList)
                Console.WriteLine(number);

            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable

            var lastArray = numberList.ToArray();

            //TODO: Clear the list
            
            numberList.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            int counter = 0;
            foreach (int number in numbers)
            {
                if (number % 3 == 0)
                    numbers[counter] = 0;
                Console.WriteLine(numbers[counter]);
                counter++;
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            for (int i = numberList.Count - 1; i >= 0; i--)
            {
                if (numberList[i] % 2 != 0)
                    numberList[i] = -1;
            }

            for (int i = numberList.Count - 1; i > 0; i--)
                numberList.Remove(-1);

            foreach(int number in numberList)
                Console.WriteLine(number);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
                Console.WriteLine($"The number : {searchNumber} is on the list!");
            else
                Console.WriteLine($"The numbers : {searchNumber} is not the list, sorry.");
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
                numberList.Add(rng.Next(0, 50));
        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for(int i = 0; i < numbers.Length;i++)
                numbers[i] = rng.Next(0,50);
        }        

        private static void ReverseArray(int[] array)
        {
            var newArray = array.Reverse();

            foreach(int number in  newArray)
                Console.WriteLine(number);
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
