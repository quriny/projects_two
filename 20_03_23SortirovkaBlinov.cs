using System.Security.Cryptography;

namespace _200323.Homework.SortirovkaBlinov
{
    internal class Program
    {
        //договоримся, что слева лежит первый готовый блин(внизу стопки),
        //соответственно сортируем так, чтобы больший блин был внизу
        static void Main(string[] args)
        {
            List<int> pancakes1 = new List<int> { 4, 1, 7, 3, 2, 4, 8, 5, 6 };
            List<int> pancakes2 = new List<int> { 1, 2, 3, 4, 4, 5, 6, 7, 8 };
            List<int> pancakes3 = new List<int> { 8, 7, 6, 5, 4, 4, 3, 2, 1 };
            Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine("Тест 1:");
            Console.ResetColor();
            sort(pancakes1);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Тест 2:");
            Console.ResetColor();
            sort(pancakes2);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Тест 3:");
            Console.ResetColor();
            sort(pancakes3);
        }
        public static void sort(List<int> list) // сама сортировка
        {
            Print(list);
            for (int i = list.Count - 1; i >= 0; --i) // обходим с конца, ищем наибольший блинчик
            {
                int minSize = i;
                for (int j = 0; j < i; ++j)
                {
                    if (list[j] < list[minSize])
                    {
                        minSize = j;
                    }
                }
                if (minSize == i)
                {
                    continue;
                }
                if (minSize != 0)
                {
                    Flip(list, minSize);
                    Print(list);
                }
                Flip(list, i);
                Print(list);
            }

        }
        public static void Flip(List<int> list, int index) // функция для переворота элементов списка по указанному индексу
        {
            for (int i = 0; i < index; i++)
            {
                int tmp = list[index];
                list.RemoveAt(index);
                list.Insert(i, tmp);
            }
        }
        public static void Print(List<int> list) // вывод списка
        {
            for (int i=0;i<list.Count;++i)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
    }
}