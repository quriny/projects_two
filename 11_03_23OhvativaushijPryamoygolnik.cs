using System.Numerics;

namespace _110323.Homework.OhvativayshiPryamoygolnik
{
    internal class Program
    {
        public struct Point //структура вершины прямоугольника
        {
            public double x; //координата x
            public double y; //координата y
        }

        public struct Rectangle //структура прямоугольника
        {
            public Point[] corners; //координаты всех вершин прямоугольника
        }

        public static double Max(double n1, double n2, double n3, double n4) //нахождение максимальной координаты
        {
            return Math.Max(Math.Max(n1,n2),Math.Max(n3,n4));
        }

        public static double Min(double n1, double n2, double n3, double n4) //нахождение минимальной координаты
        {
            return Math.Min(Math.Min(n1, n2), Math.Min(n3, n4));
        }
        
        public static void RoyalRectangle(Rectangle[]arr) //нахождение и вывод координат искомого прямоугольника
        {
            double maxX = Max(arr[0].corners[0].x, arr[0].corners[1].x, arr[0].corners[2].x, arr[0].corners[3].x); 
            double minX = Min(arr[0].corners[0].x, arr[0].corners[1].x, arr[0].corners[2].x, arr[0].corners[3].x); 
            double maxY = Max(arr[0].corners[0].y, arr[0].corners[1].y, arr[0].corners[2].y, arr[0].corners[3].y);
            double minY = Min(arr[0].corners[0].y, arr[0].corners[1].y, arr[0].corners[2].y, arr[0].corners[3].y);
            
            for (int i=1;i<arr.Length;++i)
            {
                if (Max(arr[i].corners[0].x, arr[i].corners[1].x, arr[i].corners[2].x, arr[i].corners[3].x)>maxX)
                {
                    maxX = Max(arr[i].corners[0].x, arr[i].corners[1].x, arr[i].corners[2].x, arr[i].corners[3].x);
                }
                if (Min(arr[i].corners[0].x, arr[i].corners[1].x, arr[i].corners[2].x, arr[i].corners[3].x)<minX)
                {
                    minX = Min(arr[i].corners[0].x, arr[i].corners[1].x, arr[i].corners[2].x, arr[i].corners[3].x);
                }
                if (Max(arr[i].corners[0].y, arr[i].corners[1].y, arr[i].corners[2].y, arr[i].corners[3].y)>maxY)
                {
                    maxY = Max(arr[i].corners[0].y, arr[i].corners[1].y, arr[i].corners[2].y, arr[i].corners[3].y);
                }
                if (Min(arr[i].corners[0].y, arr[i].corners[1].y, arr[i].corners[2].y, arr[i].corners[3].y)<minY)
                {
                    minY = Min(arr[i].corners[0].y, arr[i].corners[1].y, arr[i].corners[2].y, arr[i].corners[3].y);
                }

            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Координаты искомого прямоугольника: ");
            Console.ResetColor();
            Console.WriteLine("Левый нижний угол: [" + minX + ", " + minY + "]");
            Console.WriteLine("Левый верхний угол: [" + minX + ", " + maxY + "]");
            Console.WriteLine("Правый верхний угол: [" + maxX + ", " + maxY + "]");
            Console.WriteLine("Правый нижний угол: [" + maxX + ", " + minY + "]");
        }

        static void Main(string[] args)
        {
            //Rectangle[] arr= new Rectangle[3];
            //arr[0].corners = new Point[4];
            //arr[1].corners = new Point[4];
            //arr[2].corners = new Point[4];

            //arr[0].corners[0].x = -3;
            //arr[0].corners[0].y = 1;
            //arr[0].corners[1].x = -3;
            //arr[0].corners[1].y = 3;
            //arr[0].corners[2].x = 0;
            //arr[0].corners[2].y = 3;
            //arr[0].corners[3].x = 0;
            //arr[0].corners[3].y = 1;

            //arr[1].corners[0].x = -1;
            //arr[1].corners[0].y = -2;
            //arr[1].corners[1].x = -1;
            //arr[1].corners[1].y = 2;
            //arr[1].corners[2].x = 4;
            //arr[1].corners[2].y = 2;
            //arr[1].corners[3].x = 4;
            //arr[1].corners[3].y = -2;

            //arr[2].corners[0].x = 1;
            //arr[2].corners[0].y = -1;
            //arr[2].corners[1].x = 3;
            //arr[2].corners[1].y = -1;
            //arr[2].corners[2].x = 3;
            //arr[2].corners[2].y = -5;
            //arr[2].corners[3].x = 1;
            //arr[2].corners[3].y = -5;

            //RoyalRectangle(arr);

        }
    }
}