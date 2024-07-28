using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace _180223.Homework.PoiskVDvumernomMassive
{
    internal class Program
    {
        static void ElementSearch(int[,] arrES, int numES)
        {
            //объявление перемнных
            int RowIndex = -1; //индекс строки
            int ColIndex = -1; //индекс столбца
            int i = 0;
            int j = 0;
            //ищем строку с нужным элементом
            while (i <= arrES.GetUpperBound(0))
            {
                if (numES <= arrES[i, arrES.GetUpperBound(1)])
                {
                    RowIndex = i;
                    break;
                }
                ++i;
            }
            //ищем в найденной строке нужный элемент
            while (j < arrES.GetUpperBound(1))
            {
                if (arrES[RowIndex, j] == numES)
                {
                    ColIndex = j;
                    break;
                }
                ++j;
            }
            //выводим найденные индексы
            Console.WriteLine("[" + RowIndex + ", " + ColIndex + "]");
        }
        static void Main(string[] args)
        {
            //ввод числа, которое хотим найти в массиве
            Console.WriteLine("Введите элемент массива, индексы которого хотите узнать...");
            int num = Convert.ToInt32(Console.ReadLine());
            // двухмерный, отсортированный массив
            int[,] arr = { { 2, 6, 7, 9, 9, 14 }, { 18, 20, 26, 26, 29, 40 }, { 44, 47, 50, 51, 55, 62 } };
            //вызов функции поиска элемента
            ElementSearch(arr,num);
        }
    }
}