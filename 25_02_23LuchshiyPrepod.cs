namespace _250223.Homework.LuchshiyPrepodovatel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //array[rows, cols]
            //rows-строки
            //cols-стобцы

            //ввод с клавиатуры 
            double n, m;
            Console.WriteLine("Введите количество преподавателей (значение N)");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n>1000)
                {
                    Console.WriteLine("Введено некорректное значение. Попробуйте снова...");
                }

            } while (n>1000);
            Console.WriteLine("Введите количество учеников (значение M)");
            do
            {
                m = Convert.ToInt32(Console.ReadLine());
                if (m > 1000)
                {
                    Console.WriteLine("Введено некорректное значение. Попробуйте снова...");
                }

            } while (m > 1000);
            //массив для тестирования
            double[,] arrMarks = {{3.6, 3.1, 2.8, 1, 4, 3.3, 3.2, 3 },
                                    {3.5, 3.6, 4.1, 3.9, 3.5, 5, 4, 5 },
                                    {2.2, 2.7, 3.1, 3, 4.5, 2.2, 3.1, 3.7},
                                    {4.2, 3.4, 3, 4.3, 4.1, 4.6, 4.4, 4.5},
                                    {4.7, 4.1, 3.6, 2.1, 2.7, 2, 2.5, 2.7}};

            double MinInRow, MaxInRow, SumOfRow;
            double MaxRating = 0;
            double AverageRating;
            int Ind=0;

            for (int i=0;i<n;++i)
            {
                SumOfRow = 0;
                MaxInRow = arrMarks[i,0];
                MinInRow = arrMarks[i, 0];
                
                for (int j=0;j<m;++j)
                {
                    if (arrMarks[i,j]>MaxInRow){
                        //максимальное в строке 
                        MaxInRow=arrMarks[i,j];
                    }
                    if (arrMarks[i, j] < MinInRow)
                    {
                        //минимальное в строке
                        MinInRow=arrMarks[i,j];
                    }
                    //сумма строки
                    SumOfRow+=arrMarks[i,j];
                }
                //среднее значение строки
                AverageRating = (SumOfRow - (MaxInRow + MinInRow)) / (m - 2);
                //поиск индекса строки с максимальной средней оценкой
                if (AverageRating>MaxRating)
                {
                    MaxRating = AverageRating;
                    Ind = i;
                }

            }
            //вывод
            Console.WriteLine(Ind);
            Console.WriteLine(MaxRating);
        }
    }
}