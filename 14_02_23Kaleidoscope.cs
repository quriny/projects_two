using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first
{
    internal class Program
    {
        public static Random randomGen = new Random();
        static void Main(string[] args)
        {
            //получаем данные, вводимые пользователем
            int n;
            Console.WriteLine("Введите размер калейдоскопа (половина стороны). Допустимые значения от 3 до 20 включительно");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n < 3 || n > 20)
                {
                    Console.WriteLine("Введено некорректное значение. Попробуйте снова");
                }
            } while (n < 3 || n > 20);

            int[,] Arr = ArrayGen(n);
            //выводим массив с нужными для симметрии цветами, по ранее присвоенным индексам
            for (int i = 0; i < n * 2; i++)
            {
                for (int j = 0; j < n * 2; j++)
                {
                    Console.BackgroundColor = (ConsoleColor)Arr[i, j];
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.ReadKey();
        }
        //генерируем массив, присваеваем ячейкам индексы цветов
        static int[,] ArrayGen(int n)
        {
            int[,] ArrayG = new int[n * 2, n * 2];
            int ColRange = Enum.GetValues(typeof(ConsoleColor)).Length;
            int Max = 2 * n - 1;
            for (int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                {
                    int Ind = randomGen.Next(ColRange);
                    AssignInd(ArrayG, i, j, Ind);
                    AssignInd(ArrayG, Max - i, j, Ind);
                    AssignInd(ArrayG, i, Max - j, Ind);
                    AssignInd(ArrayG, Max - i, Max - j, Ind);
                }
            return ArrayG;
        }
        //присваивает индексы двум ячейкам по диагонали
        static void AssignInd(int[,] array, int x, int y, int color)
        {
            array[x, y] = color;
            array[y, x] = color;
        }
    }
}
