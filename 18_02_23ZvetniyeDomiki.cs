using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace _180223.Homework.CvetniyeDomiki
{
    internal class Program
    {
        static void ColorCounter(int n1, int m1, int c1)
        {
            int[]arr=new int[c1];
            for (int i=0;i<n1;++i)
            {
                for (int j=0;j<m1;++j)
                {
                    ++arr[(i + j) % c1];
                }
            }
            for (int i=0;i<arr.Length;++i)
            {
                Console.WriteLine(i+1+" color: "+ + arr[i]);
            }
        }
        static void Main(string[] args)
        {
            //ввод с клавиатуры
            Console.WriteLine("Создание массива [n,m]...");
            Console.WriteLine("Введите значение n");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение m");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество цветов");
            int c = Convert.ToInt32(Console.ReadLine());
            //вызов счетчика цветов
            ColorCounter(n, m, c);
        }
    }
}