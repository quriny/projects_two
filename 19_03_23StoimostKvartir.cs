using static _190323.Homework.PoschetStoimistiKvartir.Program;

namespace _190323.Homework.PoschetStoimistiKvartir
{
    internal class Program
    {
        // площади различных помещений могут быть и целыми,
        // но для универсальности выбран тип double

        public struct Flat //структура квартиры
        {
            public double[] rooms; //в каждой ячейке площадь отдельной комнаты
            public double kitchen; 
            public double otherSpaces;
            public double price;

            public Flat(double[] rooms, double kitchen, double otherSpaces, double price) //конструктор структуры 
            {
                this.rooms = rooms;
                this.kitchen = kitchen;
                this.otherSpaces = otherSpaces;
                this.price = price; 
            }
            
            public double GetSquare() //подсчет площади квартиры
            {
                return rooms.Sum() + kitchen + otherSpaces;
            }
        }
        public static void Mediana(List<Flat> FlatsOld, int Rooms, double TotalSquare) //поиск медианы
        {
            //удаляем из списка квартиры, которые на подходят по условиям
            List<Flat>Flats=new List<Flat>();
            for (int i=0;i<FlatsOld.Count;++i)
            {
                if (FlatsOld[i].rooms.Length==Rooms && FlatsOld[i].GetSquare()>TotalSquare)
                {
                    Flats.Add(FlatsOld[i]);
                }
            }
            //сортируем список по возрастанию цены
            bool isSorted = false;
            while (!isSorted)
            {
                for (int i=0;i<Flats.Count-1;++i)
                {
                    isSorted = true;
                    if (Flats[i].price > Flats[i+1].price)
                    {
                        isSorted = false;
                        Flat tmp = Flats[i];
                        Flats[i]=Flats[i+1];
                        Flats[i+1]=tmp;
                    }
                }
            }
            //ищем медиану
            double mediana;
            if (Flats.Count%2==0)
            {
                mediana = Flats[Flats.Count / 2-1].price;
            }
            else
            {
                mediana = Flats[Flats.Count / 2].price;
            }
            Console.Write(mediana);

        }


        //проверка
        static void Main(string[] args)
        {
            //комнаты
            double[] rooms1={2.5, 4, 5.6};
            double[] rooms2 = {2, 4.3};
            double[] rooms3 = {4};
            double[] rooms4 = { 2.5, 4, 5.6, 5.4 };
            double[] rooms5 = {2, 4.6, 5};
            //квартиры
            Flat flat1=new Flat(rooms1,5,7,25000000);
            Flat flat2 = new Flat(rooms2, 10, 5, 20000000);
            Flat flat3 = new Flat(rooms3, 5, 7, 25000000);
            Flat flat4 = new Flat(rooms4, 20, 25, 76000000);
            Flat flat5 = new Flat(rooms5, 3, 10, 23000000);
            //формирование списка
            List<Flat>flats=new List<Flat>();
            flats.Add(flat1);
            flats.Add(flat2);
            flats.Add(flat3);
            flats.Add(flat4);
            flats.Add(flat5);
            //проверка функции Mediana
            Mediana(flats, 3, 5);


        }
    }
}