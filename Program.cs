// 1. Given an array of n integers and a number k , perform k left rotations on the array.
// Example: 
// Input: arr[ ] = {1, 2, 3, 4, 5, 6, 7}, k = 2
// Output: 3 4 5 6 7 1 2

// Input: arr[ ] = {3, 4, 5, 6, 7, 1, 2}, k = 2
// Output: 5 6 7 1 2 3 4

// Solution 1, use a temp array
// store elements from position k to n - 1 into temp array
// then store elements from 0 to k - 1 into temp array
// copy temp array into original array

using System.Net.Security;

static void LeftRotation1(int[] arr, int k)
{
    int n = arr.Length;
    int[] temp = new int[n];

    // initialize index for temp array
    int j = 0;
    for (int i = k; i < n; i++)
    {
        temp[j] = arr[i];
        j++;
    }

    for (int i = 0; i < k; i++)
    {
        temp[j] = arr[i];
        j++;
    }

    for (int i = 0; i < n; i++)
    {
        arr[i] = temp[i];
        Console.Write(arr[i].ToString() + " ");
    }
}

// Solution 2: rotate each element
// rotate k times, at each rotation, shift 1st element to last position
static void LeftRotation2(int[] arr, int k)
{
    for (int i = 0; i < k; i++)
    {
        int temp = arr[0];
        for (int j = 0; j < arr.Length - 1; j++)
        {
            arr[j] = arr[j + 1];
        }
        arr[^1] = temp;
    }
    // print out array
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i].ToString() + " ");
    }
}

Console.WriteLine("1. Left rotation:");
int k = 2;
LeftRotation1([1, 2, 3, 4, 5, 6, 7], k);
Console.WriteLine("");
LeftRotation2([1, 2, 3, 4, 5, 6, 7], k);
Console.WriteLine("\n");

// 2. Given int n = 5, print multiplication table:
// 5 x 1 = 5
// 5 x 2 = 10
// ....
// 5 x 5 = 25
static void PrintMultiplicationTable(int n, int i = 1)
{
    if (i > n)
        return;
    Console.WriteLine($"{n} * {i} = {n * i}");
    i++;
    PrintMultiplicationTable(n, i);
}

Console.WriteLine("2. Print multiplication table:");
PrintMultiplicationTable(7);
Console.WriteLine("\n");

// 3. Find the sum of contiguous subarray within a one-dimensional array of numbers which has the largest sum.
// e.g. given an array [ -2, -3, -4, -1, -2, 1, 5, -3 ].
// 4 + (-1) + (-2) + 1 + 5 = 7 is the largest contiguos sum
static int MaximumSumSubArray(int[] arr)
{
    int max_so_far = arr[0];
    int max_current = 0;

    for (int i = 0; i < arr.Length; i++)
    {
        max_current += arr[i];

        // compare to max_so_far
        if (max_so_far < max_current) max_so_far = max_current;

        // reset max_current if it's negatie
        if (max_current < 0) max_current = 0;
    }

    return max_so_far;
}

Console.WriteLine("3. Maximum sum pf contiguos sub-array:");
Console.WriteLine("Given array: [ -2, -3, 4, -1, -2, 1, 5, -3 ]");
Console.WriteLine($"Maximum sum subarray is: {MaximumSumSubArray([ -2, -3, 4, -1, -2, 1, 5, -3 ])}");
Console.WriteLine("Given array: [ -2, 1, -3, 4, -1, 2, 1, -5, 4 ]");
Console.WriteLine($"Maximum sum subarray is: {MaximumSumSubArray([ -2, 1, -3, 4, -1, 2, 1, -5, 4 ])}");
Console.WriteLine("Given array: [ 1 ]");
Console.WriteLine($"Maximum sum subarray is: {MaximumSumSubArray([ 1 ])}");
Console.WriteLine("Given array: [ 5, 4, -1, 7, 8 ]");
Console.WriteLine($"Maximum sum subarray is: {MaximumSumSubArray([ 5, 4, -1, 7, 8 ])}");
Console.WriteLine("\n");

// 4. Given an int n, print out Fibonacci sequence up to n-th position
static int Fibonacci(int n)
{
    if (n <= 1) return 1;
    else 
    {
        // int num1 = 0;
        // int num2 = 1;

        // for (int i = 0; i < n; i++)
        // {
        //     int temp = num1;
        //     num1 = num2;
        //     num2 = temp + num2;
        // }
        // return num2;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}

int n = 8;
Console.WriteLine($"4. The Fibonacci series of {n} numbers is:");
for (int i = 0; i < n; i++)
{
    Console.Write(Fibonacci(i) + " ");
}
Console.WriteLine($"\nFibonacci at {n}th position is: {Fibonacci(n)}");
Console.WriteLine("\n");

// 5. Check if a string is a palindrome
static bool Palindrome(string text)
{
    string input = text.ToLower();
    string reverse = string.Empty;
    for (int i = text.Length - 1; i >= 0; i--)
    {
        reverse += input[i];
    }
    return string.Equals(input, reverse);
}

Console.WriteLine("5. Check Palindrome: ");
string word = "Racecar";
Console.WriteLine($"{word} is palindrome: {Palindrome(word)}");
Console.WriteLine("\n");

// 6. Given a string, find the longest subsequence consisting of a single character.
// e.g. "AABCDDDDBBBEAA" should return "DDDD"
static string LongestSubstring(string input)
{
    char char_max = input[0];
    char char_current = input[0];

    int count_max = 1;
    int count_current = 1;

    string output = string.Empty;

    for (int i = 1; i < input.Length; i++)
    {
        if (input[i] == input[i - 1])
        {
            count_current++;
            if (count_max < count_current)
            {
                count_max = count_current;
                char_max = input[i];
            } 
            
        } else 
        {
            char_current = input[i];
            count_current = 1;
        }
    }

    for (int i = 0; i < count_max; i++)
    {
        output += char_max;
    }
    return output;
}

string longText = "AABCDDDDBBEAA";
Console.WriteLine($"6. Longest subsequence in string {longText} is {LongestSubstring(longText)}");
Console.WriteLine("\n");

// 7. Insert an int item in a sorted linkedlist so that list remains sorted.
// assume that linked list is in increasing order

// if linked list is empty => return new node as head of linked list
// start from 1st node, if new node < 1st => add before, if not, move to next node until last node
static void InsertLinkedList(LinkedList<int> list, LinkedListNode<int> node)
{
    if (list.Count == 0)
    {
        list.AddFirst(node);
    } else 
    {
        LinkedListNode<int> current = list.First!;
        bool last = true;
        while (current != null)
        {
            if (node.Value < current.Value) 
            {
                list.AddBefore(current, node);
                last = false;
                break;
            }
            current = current.Next;
        }
        // if none of nodes in linked list < new node => new node should be inserted to last
        if (last) list.AddLast(node);
    }
}

int[] numbers = [2, 5, 7, 10, 13];
LinkedList<int> numLinkedList = new(numbers);
LinkedListNode<int> newNode = new(9);
static void DisplayLinkedList(LinkedList<int> nums)
{
    foreach (int num in nums)
    {
        Console.Write(num + " ");
    }
    Console.WriteLine();
}
Console.WriteLine($"7. Insert an int item in a sorted linked list and keep the list remains sorted");
Console.WriteLine($"Linked list before insert: ");
DisplayLinkedList(numLinkedList);
Console.WriteLine($"Insert new node: {newNode}");
InsertLinkedList(numLinkedList, newNode);
Console.WriteLine($"Linked list after insert: ");
DisplayLinkedList(numLinkedList);

Console.WriteLine("\n");

// 8. Remove duplicate ints from a sorted linkedlist
// traverse linked list from head. Compare each node to next node
// if equals, remove next node, move to next next node.
static void RemoveDuplicate(LinkedList<int> list)
{
    LinkedListNode<int> current = list.First;
    LinkedListNode<int> next = current.Next;
    // if linked list is empty, do nothing
    if (current == null) return;

    // traverse & compare
    while (current != null && next != null)
    {
        if (current.Value == next.Value)
        {
            list.Remove(next);
            
            // current is automatically pointing to next value is linked list
            // assign next to continue comparision
            next = current.Next;
        } else 
        {
            // move current to next node, move next to a node after current
            current = current.Next;
            next = current.Next;
        }
    }
}

int[] numbersDuplicate = [2, 2, 5, 7, 7, 9, 10, 10, 13, 13];
LinkedList<int> numbersLinkedListDuplicate = new(numbersDuplicate);
Console.WriteLine("8. Remove duplicate ints from a sorted linked list");
Console.WriteLine($"Linked list before remove duplicate: ");
DisplayLinkedList(numbersLinkedListDuplicate);
Console.WriteLine($"Linked list after remove duplicate: ");
RemoveDuplicate(numbersLinkedListDuplicate);
DisplayLinkedList(numbersLinkedListDuplicate);


// 9. Given a time in 12-hour AM/PM format, convert it to 24-hour format time.
// Midnight is 12:00:00AM on a 12-hour clock, and 00:00:00 on a 24-hour clock.
// Noon is 12:00:00PM on a 12-hour clock, and 12:00:00 on a 24-hour clock.
// e.g. input: "01:05:45AM", output should be: "01:05:45"
static string TimeConversion(string s)
{
    string[] time = s.Split(':').Select(x => x.Substring(0,2)).ToArray();
    var isPM = s.Remove(0,8) == "PM";
    var hours = int.Parse(time[0]);
    if(isPM && hours == 12)
        hours %= 24;
    if(isPM && hours < 12)
        hours += 12;

    time[0] = hours.ToString("00");
    return string.Join(":", time);    
}

Console.WriteLine("9. Convert time from 12-hour AM/PM format to 24-hour format");
Console.WriteLine(TimeConversion("01:05:45AM"));
Console.WriteLine("\n");

// 10. A University has a following grading policy:
// Students' grades are from 0 - 100. If grade < 40 is a fail
// Rounding grade policy:
// If the difference between grade and the next multiple of 5 is less than 3, round grade up to the next multiple of 5.
// If grade < 38, no rounding occurs as the result will still be a failing grade. 
// E.g. 84 will be rounded to 85
// E.g. 29 will not be rounded because the grade < 38
// Input: int[] grades
// Output: rounded int[] grades

static void RoundGrades(int[] grades)
{
    for (int i = 0; i < grades.Length; i++)
    {
        int grade = grades[i];
        if (grade < 38)
            continue;
        int difference = 5 - (grade % 5);
        if (difference < 3) 
        {
            grades[i] += difference;
        }
    }
}

static void DisplayGrades(int[] grades)
{
    foreach(int grade in grades)
    {
        Console.Write(grade + " ");
    }
    Console.WriteLine("");
}
int[] grades = [ 4, 73, 67, 38, 33 , 70 ];
Console.WriteLine("10. Rounding grades: ");
Console.WriteLine("Grades before rounding:");
DisplayGrades(grades);
Console.WriteLine("Grades after rounding:");
RoundGrades(grades);
DisplayGrades(grades);
