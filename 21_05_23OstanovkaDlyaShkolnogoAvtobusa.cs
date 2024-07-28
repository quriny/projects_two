using System.Text;

namespace _210523.OstanovkaDlyaShkolnogoAvtobusa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\aklik\OneDrive\Изображения\data.bin"; //ссылка на бинарный файл

            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));            
            int houses = reader.ReadInt32(); // количество домов
            int[] children = new int[houses]; //массив с количеством детей для каждого дома
            for (int i=0; i<houses;++i)
            {
                children[i] = reader.ReadInt32();
            }
            Console.WriteLine("Количество домов: "+houses);
            Console.WriteLine("Количество детей в домах: ");
            for (int i = 0; i < houses; ++i)
            {
                Console.Write(children[i]+" ");
            }
            int totalChildren = 0; //переменная для общего количества детей
            for (int i = 0; i < houses; ++i)
            {
                totalChildren += children[i];
            }
            int bestValue = int.MaxValue; //дефолтное значение целевой функции
            int bestIndex = -1; //дефолтное значение искомого индекса
            for (int i=0; i<houses ;++i)
            {
                int currentValue = 0; //текущее значение 
                for (int j=0; j<houses;++j)
                {
                    int distance = Math.Min(Math.Abs(j-i), houses-Math.Abs(j-i)); //расстояние до остановки
                    currentValue += children[j] * distance;
                }
                //ищем наименьшую целевую функцию и нужный индекс
                if (currentValue<bestValue)
                {
                    bestValue= currentValue;
                    bestIndex= i;
                }
            }
            //выводим результат
            Console.WriteLine("Значение целевой функции: " + bestValue);
            Console.WriteLine("Индекс дома: " + bestIndex);
        }
    }
}