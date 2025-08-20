using System;
using System.Buffers;
using System.Collections.Generic;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            char key = 'Q';
            int len = 0;
            int value = 0;
            int searchValue = 0;
            int index_1 = -1;
            int index_2 = -1;
            int value_1 = 0;
            int value_2 = 0;

            do
            {
                PrintMainScreen();

                key = GetKey();
                len = CalcLength(numbers);

                switch (key)
                {
                    case 'P':
                        PrintListOption(len, numbers);
                        break;

                    case 'A':
                        value = GetValue();
                        AddItem(value, numbers);
                        break;

                    case 'M':
                        PrintMeanOption(numbers);
                        break;

                    case 'S':
                        PrintSmallest(numbers);
                        break;

                    case 'L':
                        PrintLargest(numbers);
                        break;

                    case 'F':
                        searchValue = GetValue();
                        PrintSearchOption(numbers, searchValue);
                        break;

                    case 'T':
                        SortAsc(numbers);
                        break;

                    case 'W':
                        SortDes(numbers);
                        break;

                    case 'H':
                        (index_1, index_2) = GetIndexes();
                        SwapByIndex(numbers, index_1, index_2);
                        break;

                    case 'D':
                        (value_1, value_2) = GetValues();
                        SwapByValues(numbers, value_1, value_2);
                        break;

                    case 'C':
                        ClearList(numbers);
                        break;

                    case 'Q':
                        break;

                    default:
                        PrintMessage("\nInvalid Input...");
                        break;
                }

            } while (key != 'Q');
        }//end of main


        //special functions for console
        static void PrintResult(int value, string str)
        {
            Console.WriteLine($"{str} = {value}");
        }

        static void PrintSeparatedLine()
        {
            Console.WriteLine("\n=============================\n");
        }


        static void PrintMessage(string str)
        {
            Console.WriteLine($"{str}");
        }


        static void PrintMainScreen()
        {

            Console.WriteLine("\nP - Print numbers");
            Console.WriteLine("A - Add a number");
            Console.WriteLine("M - Display mean of the numbers");
            Console.WriteLine("S - Display the smallest number");
            Console.WriteLine("L - Display the largest number");
            Console.WriteLine("F - Find a number");
            Console.WriteLine("T - Sorting in ascending order");
            Console.WriteLine("W - Sorting in Descending order");
            Console.WriteLine("H - Swap by index");
            Console.WriteLine("D - Swap by values");
            Console.WriteLine("C - Clear the whole list");
            Console.WriteLine("Q - Quit\n");
        }

        static void PrintList(int len, List<int> numbers)
        {
            PrintSeparatedLine();
            Console.Write(" [ ");
            for (int i = 0; i < len; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.Write("]\n");
            PrintSeparatedLine();
        }

        static void PrintMsg_Found(int value)
        {
            Console.WriteLine($"\nFound {value} in list");
        }

        static void PrintMsg_Added(int value)
        {
            Console.WriteLine($"\n{value} added");
        }



        //functions used in any environment
        static char GetKey() => Convert.ToChar(Console.ReadLine().ToUpper());

        static int CalcLength(List<int> numbers) => numbers.Count;

        static void PrintListOption(int len, List<int> numbers)
        {
            if (len == 0)
            {
                PrintSeparatedLine();
                PrintMessage("[] - the list is empty");
                PrintSeparatedLine();
            }
            else
            {
                PrintList(len, numbers);
            }
        }

        static int GetValue()
        {
            PrintSeparatedLine();
            PrintMessage("Enter the number ==> ");
            int value = Convert.ToInt32(Console.ReadLine());
            return value;
        }

        static void AddItem(int value, List<int> numbers)
        {
            bool findValue = false;
            int len = CalcLength(numbers);
            for (int i = 0; i < len; i++)
            {
                if (numbers[i] == value)
                {
                    findValue = true;
                }
            }
            if (findValue)
            {
                PrintMsg_Found(value);
            }
            else
            {
                numbers.Add(value);
                PrintMsg_Added(value);
            }
            PrintSeparatedLine();
        }

        static void PrintMeanOption(List<int> numbers)
        {
            int len = CalcLength(numbers);
            //to avoid runtime error if len == 0
            if (len > 0)
            {
                int sumValue = 0;
                int meanValue = 0;
                for (int i = 0; i < len; i++)
                {
                    sumValue += numbers[i];
                }
                meanValue = sumValue / len;
                PrintSeparatedLine();
                PrintResult(meanValue, "Mean");
                PrintSeparatedLine();
            }
            else
            {
                PrintSeparatedLine();
                PrintMessage("[] - the list is empty");
                PrintSeparatedLine();
            }
        }

        static void PrintSmallest(List<int> numbers)
        {
            int len = CalcLength(numbers);
            if (len > 0)
            {
                int smallValue = 1000000000;
                for (int i = 0; i < len; i++)
                {
                    if (numbers[i] < smallValue)
                    {
                        smallValue = numbers[i];
                    }
                }
                PrintSeparatedLine();
                PrintResult(smallValue, "Smallest");
                PrintSeparatedLine();
            }
            else
            {
                PrintSeparatedLine();
                PrintMessage("[] - the list is empty");
                PrintSeparatedLine();
            }
        }

        static void PrintLargest(List<int> numbers)
        {
            int len = CalcLength(numbers);
            if (len > 0)
            {
                int largeValue = 0;
                for (int i = 0; i < len; i++)
                {
                    if (numbers[i] > largeValue)
                    {
                        largeValue = numbers[i];
                    }
                }
                PrintSeparatedLine();
                PrintResult(largeValue, "Largest");
                PrintSeparatedLine();
            }
            else
            {
                PrintSeparatedLine();
                PrintMessage("[] - the list is empty");
                PrintSeparatedLine();
            }
        }
        static void PrintSearchOption(List<int> numbers, int searchValue)
        {
            int len = CalcLength(numbers);
            bool findValue = false;
            int indexValue = -1;
            for (int i = 0; i < len; i++)
            {
                if (numbers[i] == searchValue)
                {
                    findValue = true;
                    indexValue = i;
                    break;
                }
            }
            if (findValue)
            {
                PrintResult(indexValue, "Found in index");
            }
            else
            {
                PrintResult(-1, "Not Found");
            }
            PrintSeparatedLine();
        }

        static void SortAsc(List<int> numbers)
        {
            int len = CalcLength(numbers);
            if (len > 1)
            {
                for (int i = 0; i < len - 1; i++)
                {
                    for (int j = i + 1; j < len; j++)
                    {
                        if (numbers[i] > numbers[j])
                        {
                            int temp = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = temp;
                        }
                    }
                }
                PrintSeparatedLine();
                PrintMessage("List sorted succeeded");
                PrintSeparatedLine();
            }
            else
            {
                PrintSeparatedLine();
                PrintMessage("The List has less than 2 Items");
                PrintSeparatedLine();
            }
        }

        static void SortDes(List<int> numbers)
        {
            int len = CalcLength(numbers);
            if (len > 1)
            {
                for (int i = 0; i < len - 1; i++)
                {
                    for (int j = i + 1; j < len; j++)
                    {
                        if (numbers[i] < numbers[j])
                        {
                            int temp = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = temp;
                        }
                    }
                }
                PrintSeparatedLine();
                PrintMessage("List sorted succeeded");
                PrintSeparatedLine();
            }
            else
            {
                PrintSeparatedLine();
                PrintMessage("The List has less than 2 Items");
                PrintSeparatedLine();
            }
        }


        static void ClearList(List<int> numbers)
        {
            numbers.Clear();
            PrintSeparatedLine();
            PrintMessage("List clear succeeded");
            PrintSeparatedLine();
        }



        static (int, int) GetIndexes()
        {
            PrintSeparatedLine();
            PrintMessage("Enter the first index ==> ");
            int index_1 = Convert.ToInt32(Console.ReadLine());
            PrintMessage("Enter the second index ==> ");
            int index_2 = Convert.ToInt32(Console.ReadLine());
            return (index_1, index_2);
        }

        static void SwapByIndex(List<int> numbers, int index_1, int index_2)
        {
            int len = CalcLength(numbers);
            if (index_1 > len - 1 || index_2 > len - 1)
            {
                PrintSeparatedLine();
                PrintMessage("The List has less than 2 Items");
                PrintSeparatedLine();
            }
            else
            {
                int temp = numbers[index_1];
                numbers[index_1] = numbers[index_2];
                numbers[index_2] = temp;
                PrintSeparatedLine();
                PrintMessage("Items have been swapped");
                PrintSeparatedLine();
            }
        }

        static (int, int) GetValues()
        {
            PrintSeparatedLine();
            PrintMessage("Enter the first value ==> ");
            int value_1 = Convert.ToInt32(Console.ReadLine());
            PrintMessage("Enter the second value ==> ");
            int value_2 = Convert.ToInt32(Console.ReadLine());
            return (value_1, value_2);
        }

        static void SwapByValues(List<int> numbers, int value_1, int value_2)
        {
            int len = CalcLength(numbers);
            int index_1 = default;
            int index_2 = default;
            for (int i = 0; i < len; i++)
            {
                if (numbers[i] == value_1)
                {
                    index_1 = i; break;
                }
            }
            for (int i = 0; i < len; i++)
            {
                if (numbers[i] == value_2)
                {
                    index_2 = i; break;
                }
            }

            int temp = numbers[index_1];
            numbers[index_1] = numbers[index_2];
            numbers[index_2] = temp;
            PrintSeparatedLine();
            PrintMessage("Items have been swapped");
            PrintSeparatedLine();
        }

    }
}
