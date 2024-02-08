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