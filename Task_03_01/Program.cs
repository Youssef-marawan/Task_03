
        List<int> numbers = new List<int>();
        char key = 'Q';
        int len = 0;
        int value = 0;
        int meanValue = 0;
        int sumValue = 0;
        int smallValue = 1000000000;
        int largeValue = 0;
        bool findValue = false;
        int searchValue = 0;
        int indexValue = -1;
        int temp = 0;
        int index_1 = -1;
        int index_2 = -1;
        int value_1 = 0;
        int value_2 = 0;



        do
        {
            PrintMainScreen();

            key = GetKey();
            len = CalcLength();

            switch (key)
            {
                case 'P':
                    PrintList(len);
                    break;

                case 'A':
                    value = GetValue();
                    AddItem(value);
                    break;

                case 'M':
                    PrintMean();
                    break;

                case 'S':
                    PrintSmallest();
                    break;

                case 'L':
                    PrintLargest();
                    break;

                case 'F':
                    searchValue = GetValue();
                    PrintSearch();
                    break;

                case 'T':
                    SortAsc();
                    break;

                case 'W':
                    SortDes();
                    break;

                case 'H':
                    (index_1, index_2) = GetIndexes();
                    SwapByIndex();
                    break;

                case 'D':
                    (value_1, value_2) = GetValues();
                    SwapByValues();
                    break;

                case 'C':
                    ClearList();
                    break;

                case 'Q':
                    break;

                default:
                    PrintWarningScreen();
                    break;
            }

        } while (key != 'Q');
 

void PrintWarningScreen()
{
    Console.WriteLine("\nInvalid Input...");
}

void PrintMainScreen()
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

char GetKey() => Convert.ToChar(Console.ReadLine().ToUpper());

int CalcLength() => numbers.Count;

void PrintList(int len)
{
    if (len == 0)
    {
        Console.WriteLine("\n=============================\n");
        Console.WriteLine("[] - the list is empty");
        Console.WriteLine("\n=============================");
    }
    else
    {
        Console.WriteLine("\n=============================\n");
        Console.Write(" [ ");
        for (int i = 0; i < len; i++)
        {
            Console.Write($"{numbers[i]} ");
        }
        Console.Write("]");
        Console.WriteLine("\n\n=============================");
    }
}

int GetValue()
{
    Console.WriteLine("\n=============================\n");
    Console.Write("Enter the number ==> ");
    value = Convert.ToInt32(Console.ReadLine());
    return value;
}

void AddItem(int value)
{
    findValue = false;
    for (int i = 0; i < len; i++)
    {
        if (numbers[i] == value)
        {
            findValue = true;
        }
    }
    if (findValue)
    {
        Console.WriteLine($"\nFound {value} in list");
    }
    else
    {
        numbers.Add(value);
        Console.WriteLine($"\n{value} added");
    }
    Console.WriteLine("\n=============================");
}

void PrintMean()
{
    //to avoid runtime error if len == 0
    if (len > 0)
    {
        sumValue = 0;
        meanValue = 0;
        for (int i = 0; i < len; i++)
        {
            sumValue += numbers[i];
        }
        meanValue = sumValue / len;
        Console.WriteLine("\n=============================\n");
        Console.WriteLine($"Mean = {meanValue}");
        Console.WriteLine("\n=============================\n");
    }
    else
    {
        Console.WriteLine("\n=============================\n");
        Console.WriteLine("[] - the list is empty");
        Console.WriteLine("\n=============================");
    }
}

void PrintSmallest()
{
    if (len > 0)
    {
        smallValue = 1000000000;
        for (int i = 0; i < len; i++)
        {
            if (numbers[i] < smallValue)
            {
                smallValue = numbers[i];
            }
        }
        Console.WriteLine("\n=============================\n");
        Console.WriteLine($"The smallest number is  = {smallValue}");
        Console.WriteLine("\n=============================\n");
    }
    else
    {
        Console.WriteLine("\n=============================\n");
        Console.WriteLine("[] - the list is empty");
        Console.WriteLine("\n=============================");
    }
}

void PrintLargest()
{
    if (len > 0)
    {
        largeValue = 0;
        for (int i = 0; i < len; i++)
        {
            if (numbers[i] > largeValue)
            {
                largeValue = numbers[i];
            }
        }
        Console.WriteLine("\n=============================\n");
        Console.WriteLine($"The largest number is  = {largeValue}");
        Console.WriteLine("\n=============================\n");
    }
    else
    {
        Console.WriteLine("\n=============================\n");
        Console.WriteLine("[] - the list is empty");
        Console.WriteLine("\n=============================");
    }
}

void PrintSearch()
{
    findValue = false;
    indexValue = -1;
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
        Console.WriteLine($"\nNeeded number in index {indexValue} ");
    }
    else
    {
        Console.WriteLine("\nNeeded number not in the list");
    }
    Console.WriteLine("\n=============================\n");
}


void SortAsc()
{
    if (len > 1)
    {
        for (int i = 0; i < len - 1; i++)
        {
            for (int j = i + 1; j < len; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
        Console.WriteLine("\n=============================\n");
        Console.WriteLine("List sorted successed");
        Console.WriteLine("\n=============================\n");
    }
    else
    {
        Console.WriteLine("\n=============================\n");
        Console.WriteLine($"The List has {len} Items");
        Console.WriteLine("\n=============================\n");
    }
}

void SortDes()
{
    if (len > 1)
    {
        for (int i = 0; i < len - 1; i++)
        {
            for (int j = i + 1; j < len; j++)
            {
                if (numbers[i] < numbers[j])
                {
                    temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
        Console.WriteLine("\n=============================\n");
        Console.WriteLine("List sorted successed");
        Console.WriteLine("\n=============================\n");
    }
    else
    {
        Console.WriteLine("\n=============================\n");
        Console.WriteLine($"The List has {len} Items");
        Console.WriteLine("\n=============================\n");
    }
}


void ClearList()
{
    numbers.Clear();
    Console.WriteLine("\n=============================\n");
    Console.WriteLine("List clear successed");
    Console.WriteLine("\n=============================\n");
}

(int, int) GetIndexes()
{
    Console.WriteLine("\n=============================\n");
    Console.Write("Enter the first index ==> ");
    int index_1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the second index ==> ");
    int index_2 = Convert.ToInt32(Console.ReadLine());
    return (index_1, index_2);
}

void SwapByIndex()
{
    if (index_1 > len - 1 || index_2 > len - 1)
    {
        Console.WriteLine("\n=============================\n");
        Console.WriteLine($"The List has {len} Items");
        Console.WriteLine("\n=============================\n");
    }
    else
    {
        temp = numbers[index_1];
        numbers[index_1] = numbers[index_2];
        numbers[index_2] = temp;
        Console.WriteLine("\n=============================\n");
        Console.WriteLine("Items have been swapped");
        Console.WriteLine("\n=============================\n");
    }
}

(int, int) GetValues()
{
    Console.WriteLine("\n=============================\n");
    Console.Write("Enter the first value ==> ");
    int value_1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the second value ==> ");
    int value_2 = Convert.ToInt32(Console.ReadLine());
    return (value_1, value_2);
}

void SwapByValues()
{
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

    temp = numbers[index_1];
    numbers[index_1] = numbers[index_2];
    numbers[index_2] = temp;
    Console.WriteLine("\n=============================\n");
    Console.WriteLine("Items have been swapped");
    Console.WriteLine("\n=============================\n");
}