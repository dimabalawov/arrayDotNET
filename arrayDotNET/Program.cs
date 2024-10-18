
const int N = 5;
const int M = 6;
void swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}
void task1()
{
    Random rnd = new Random();
    int[] arr = new int[10];

    for (int i = 0; i < arr.Length; i++)
        arr[i] = rnd.Next(0, 5);

    Console.Write("Array: ");
    foreach (int i in arr)
        Console.Write($"{i} ");
    Console.WriteLine();

    int lastNonZeroIndex = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] != 0)
        {
            swap(ref arr[i], ref arr[lastNonZeroIndex]);
            lastNonZeroIndex++;
        }
    }
    Console.Write("New Array: ");
    foreach (int i in arr)
        Console.Write($"{i} ");
    Console.WriteLine();
}



void task2(int thread)
{
    int N = 5; 
    int[,] arr = new int[N, N];
    for (int i = 0; i < N; i++)
        for (int j = 0; j < N; j++)
            arr[i, j] = 0;

    int number = 1;
    int move = 1;
    int a = (N - 1) / 2;
    int z = (N - 1) / 2;
    Console.CursorVisible = false;
    PrintArray(arr, N);
    arr[a, z] = number;
    UpdatePosition(a, z, number); 
    Thread.Sleep(300); 

    while (number < N * N)
    {
        if (move == 1 && z > 0 && arr[a, z - 1] == 0)
        {
            move = 2;
            arr[a, --z] = ++number;
        }
        else if (move == 2 && a < N - 1 && arr[a + 1, z] == 0)
        {
            move = 3;
            arr[++a, z] = ++number;
        }
        else if (move == 3 && z < N - 1 && arr[a, z + 1] == 0)
        {
            move = 4;
            arr[a, ++z] = ++number;
        }
        else if (move == 4 && a > 0 && arr[a - 1, z] == 0)
        {
            move = 1;
            arr[--a, z] = ++number;
        }
        else
        {
            if (move > 1) move--;
            else move = 4;
        }

        UpdatePosition(a, z, number);
        Thread.Sleep(thread);
    }
    Console.SetCursorPosition(0, 12);
    Console.CursorVisible = true;
    Console.WriteLine("\n");
}

void UpdatePosition(int a, int z, int number)
{
    Console.SetCursorPosition(z * 4+3, a*2+3);
    if (number != 0)
        Console.Write($"{number,3} ");
}

void PrintArray(int[,] arr, int N)
{
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
        {
            if (arr[i, j] != 0)
                Console.Write($"{arr[i, j],3} ");
            else
                Console.Write("    ");
        }
        Console.WriteLine("\n");
    }
}

void task3()
{
    Random rnd = new Random();
    int[,] arr = new int[N, M];
    for (int i = 0; i < N; i++)
        for (int j = 0; j < M; j++)
            arr[i, j] = rnd.Next(0, 100);

    Console.WriteLine("Array: \n");
    PrintArray2(arr, N, M);

    Console.WriteLine("0 - Vertical Shift");
    Console.WriteLine("1 - Horizontal Shift");
    Console.Write("Choose your shift direction: ");
    int choice = int.Parse(Console.ReadLine());
    if (choice != 0 && choice != 1) throw new Exception("Wrong Choice!");

    Console.Write("Enter shift amount: ");
    int shiftAmount = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 0:
            {
                VerticalShift(arr, N, M, shiftAmount);
                break;
            }
        case 1:
            {
                HorizontalShift(arr, N, M, shiftAmount);
                break;
            }
    }

    Console.WriteLine("\nArray after shift: \n");
    PrintArray2(arr, N, M);
}

void VerticalShift(int[,] arr, int N, int M, int shiftAmount)
{
    shiftAmount = shiftAmount % N;
    int[] temp = new int[M];

    for (int shift = 0; shift < shiftAmount; shift++)
    {
        for (int j = 0; j < M; j++)
            temp[j] = arr[N - 1, j];

        for (int i = N - 1; i > 0; i--)
            for (int j = 0; j < M; j++)
                arr[i, j] = arr[i - 1, j];

        for (int j = 0; j < M; j++)
            arr[0, j] = temp[j];
    }
}

void HorizontalShift(int[,] arr, int N, int M, int shiftAmount)
{
    shiftAmount = shiftAmount % M; 
    int[] temp = new int[N]; 

    for (int shift = 0; shift < shiftAmount; shift++)
    {

        for (int i = 0; i < N; i++)
            temp[i] = arr[i, M - 1];

        for (int j = M - 1; j > 0; j--)
            for (int i = 0; i < N; i++)
                arr[i, j] = arr[i, j - 1];

        for (int i = 0; i < N; i++)
            arr[i, 0] = temp[i];
    }
}

void PrintArray2(int[,] arr, int N, int M)
{
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
            Console.Write($"{arr[i, j],3} ");
        Console.WriteLine("\n");
    }
}
task1();
task2(150);
task3();

