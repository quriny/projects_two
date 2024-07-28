namespace _150223.Classwork.SummaDiagonalei
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //    int[,,] arrZ = {{{23, 30, 2},{4, 8, 12},{9, 11, 16} },
        //                   {{3, 21, 5},{14, 18, 9},{49, 33, 2}},
        //                   {{32, 32, 35},{71, 86, 74},{7, 1, 8}}};


        //}





        static void Main(string[] args)
        {
            int[,,] arrZ = {{ { 23, 30, 2 }, { 4, 8, 12 }, { 9, 11, 16 } },
                 { { 3, 21, 5 }, { 14, 18, 9 }, { 49, 33, 2 } },
                 { { 32, 32, 55 }, { 71, 86, 74 }, { 7, 1, 8 } }};
            int[,,] arrX = {{ { 23, 30, 2, 11}, { 4, 8, 12, 5 }, { 9, 11, 16, 7 }, {44, 46, 2, 8} },
                            { { 46, 31, 5, 31 }, { 30, 13, 41, 7 }, { 4, 25, 11, 60 }, {18, 44, 78, 41} },
                            { { 74, 24, 15, 64 }, { 77, 20, 59, 13 }, { 13, 3, 62, 78 }, {95, 34, 20, 67} },
                            { { 2, 4, 77, 50 }, { 7, 8, 54, 10 }, { 74, 21, 68, 9 }, {39, 14, 87, 58} }};
            int sum;
            Console.WriteLine(sumDiagonals(arrZ, out sum) ? sum + "" : "не куб");
            Console.WriteLine(sumDiagonals(arrX, out sum) ? sum + "" : "не куб");

            Console.ReadKey();
        }
        public static bool CheckCube(int[,,] arr)
        {
            int MaxInd;
            MaxInd = arr.GetUpperBound(0);
            return arr.Rank == 3 && MaxInd == arr.GetUpperBound(1) && MaxInd == arr.GetUpperBound(2);
        }
        public static int CountDiagonal(int[,,] arr, bool v1, bool v2)
        {
            int sum = 0, size = arr.GetUpperBound(0);
            for (int i = size; i >= 0; i--)
                sum += arr[i, (v1 ? i : size - i), (v2 ? i : size - i)];
            return sum;
        }
        public static bool sumDiagonals(int[,,] arr, out int sum)
        {
            bool b;
            sum = 0;
            if (b = CheckCube(arr))
            {
                int size = arr.GetUpperBound(0);

                for (int i = 0; i < 4; i++)
                    sum += CountDiagonal(arr, i / 2 == 0, i % 2 == 0);
                if (size % 2 == 0)
                {
                    int t = size / 2;
                    sum -= 3 * arr[t, t, t];
                }
            }
            return b;
        }
    }
}










static void Main(string[] args)
{
    int[,,] arrZ = {{ { 23, 30, 2 }, { 4, 8, 12 }, { 9, 11, 16 } },
                 { { 3, 21, 5 }, { 14, 18, 9 }, { 49, 33, 2 } },
                 { { 32, 32, 55 }, { 71, 86, 74 }, { 7, 1, 8 } }};
    int[,,] arrX = {{ { 23, 30, 2, 11}, { 4, 8, 12, 5 }, { 9, 11, 16, 7 }, {44, 46, 2, 8} },
                            { { 46, 31, 5, 31 }, { 30, 13, 41, 7 }, { 4, 25, 11, 60 }, {18, 44, 78, 41} },
                            { { 74, 24, 15, 64 }, { 77, 20, 59, 13 }, { 13, 3, 62, 78 }, {95, 34, 20, 67} },
                            { { 2, 4, 77, 50 }, { 7, 8, 54, 10 }, { 74, 21, 68, 9 }, {39, 14, 87, 58} }};
    int sum;
    Console.WriteLine(sumDiagonals(arrZ, out sum) ? sum + "" : "не куб");
    Console.WriteLine(sumDiagonals(arrX, out sum) ? sum + "" : "не куб");

    Console.ReadKey();
}
public static bool CheckCube(int[,,] arr)
{
    int MaxInd;
    MaxInd = arr.GetUpperBound(0);
    return arr.Rank == 3 && MaxInd == arr.GetUpperBound(1) && MaxInd == arr.GetUpperBound(2);
}
public static int CountDiagonal(int[,,] arr, bool v1, bool v2)
{
    int sum = 0, size = arr.GetUpperBound(0);
    for (int i = size; i >= 0; i--)
        sum += arr[i, (v1 ? i : size - i), (v2 ? i : size - i)];
    return sum;
}
public static bool sumDiagonals(int[,,] arr, out int sum)
{
    bool b;
    sum = 0;
    if (b = CheckCube(arr))
    {
        int size = arr.GetUpperBound(0);

        for (int i = 0; i < 4; i++)
            sum += CountDiagonal(arr, i / 2 == 0, i % 2 == 0);
        if (size % 2 == 0)
        {
            int t = size / 2;
            sum -= 3 * arr[t, t, t];
        }
    }
    return b;
}