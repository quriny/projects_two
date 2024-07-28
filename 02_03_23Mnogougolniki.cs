using System.Buffers;

namespace _020323.Classwork.Mnogougolniki
{
    internal class Program
    {
        public struct Point
        {
            public int x;
            public int y;
        }

        public struct SRect
        {
            public Point[]arrp;//массив с вершинами
            public int Thickness;//толщина линии в пикселях
            public ConsoleColor Color;//цвет линии
            public bool flag;//наличие заливки

        }

        static void CountRectangle(SRect[]arr, int min_square)
        {
            for (int i=0;i<arr.Length;++i)
            {
                int[] arr_cr = new int[4];
                //проверяем является ли четырехугольником
                int CheckFour = 0;
                if (arr[i].arrp.Length==4)
                {
                    CheckFour = 1;
                }
                //
       


                //if (CheckFour==1 && (arr[i].arrp[0].y == arr[i].arrp[1].y || arr[i].arrp[0].x == arr[i].arrp[1].x)&&)
                //{

                //}


            }
        }

        static void Main(string[] args)
        {

            


            //Console.WriteLine("Hello, World!");


            //-объявить структуру, описывающую многоугольник на плоскости
            //-сохранение координат вершин
            //-функция получает одномерный массив многоугольников 
            //-Srect[]arr
            //

        }
    }
}