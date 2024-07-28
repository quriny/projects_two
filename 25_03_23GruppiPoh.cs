namespace _250323.Homework.GrubbiPohozih
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        public struct SHuman
        {
            public string Surname;          // фамилия
            public string Firstname;        // имя
            public string Patronymic;       // отчество
            public int Year;                // год рождения
            public SHuman(string surname, string firstname, string patronymic, int year)
            {
                this.Surname = surname;
                this.Firstname = firstname;
                this.Patronymic = patronymic;
                this.Year = year;
            }

        }
        public static List<List<SHuman>> CreateGroups(SHuman[] l) //функия распределения по группам
        {
            List<SHuman> list = new List<SHuman>(); //запись полученных значений массива в список
            foreach (SHuman human in l)
            {
                list.Add(human);
            }
            List<List<SHuman>> lists = new List<List<SHuman>>(list.Count); //создание списка списков
            for (int i = 0; i < list.Count; i++)
            {
                lists.Add(new List<SHuman>());
            }
            for (int i=0;i<lists.Count;++i) {
                lists[i].Add(list[0]);
                list.Remove(list[0]);
                for (int j = 0; j < lists[i].Count; ++j) {
                    for (int k = 0; k < list.Count; ++k)
                    {
                        if (String.Equals(list[k].Surname, lists[i][j].Surname) ||
                            String.Equals(list[k].Firstname, lists[i][j].Firstname) ||
                            String.Equals(list[k].Patronymic, lists[i][j].Patronymic) ||
                            list[k].Year == lists[i][j].Year)
                        {
                            lists[i].Add(list[k]);
                            list.Remove(list[k]);

                        }
                    }
                }
                if (list.Count == 0)
                {
                    break;
                }
            }
            return lists;
        }
        public static void PrintStruct(SHuman obj) //вывод данных структуры
        {
            Console.Write(obj.Surname+" "+obj.Firstname+" "+obj.Patronymic+", "+obj.Year);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //тестовый массив 
            SHuman[] group = {
                new SHuman("Пушкин", "Александр", "Сергеевич", 1799),
                new SHuman("Ломоносов", "Михаил", "Васильевич", 1711),
                new SHuman("Тютчев", "Фёдор", "Иванович", 1803),
                new SHuman("Суворов", "Александр", "Васильевич", 1729),
                new SHuman("Менделеев", "Дмитрий", "Иванович", 1834),
                new SHuman("Ахматова", "Анна", "Андреевна", 1889),
                new SHuman("Володин", "Александр", "Моисеевич", 1919),
                new SHuman("Мухина", "Вера", "Игнатьевна", 1889),
                new SHuman("Верещагин", "Петр", "Петрович", 1834)
            };
            List<List<SHuman>> lists = CreateGroups(group); //переменная для возвращаемого значения
            //проверка
            foreach (SHuman human in lists[0])
            {
                PrintStruct(human);
            }
            Console.WriteLine();
            foreach (SHuman human in lists[1])
            {
                PrintStruct(human);
            }
            Console.WriteLine();
            foreach (SHuman human in lists[2])
            {
                PrintStruct(human);
            }
        }
    }
}
