namespace _230323.Classwork.ObrabotkaElementovMassiva
{
    internal class Program
    {
        public static void CyclicShift(int[] arr, int count)
        {
            for (int i=0;i<count;++i) {
                int temp = arr[0];
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[arr.Length - 1] = temp;
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] {1, 2, 3, 4, 5}; //тестовый массив
            Console.WriteLine("Введите count...");
            int count = Convert.ToInt32(Console.ReadLine());
            CyclicShift(arr, count);
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write(arr[i] + " ");
            }
        }

    }
}