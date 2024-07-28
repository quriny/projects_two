//вариант 2
namespace _040323.Homework.ObyavlenieStruktur
{
    //объект загородной недвижимости
    public enum StatusOfObject
    {
        Used, Sold, UnderConstruction, Abandoned
    }
    public struct Estate
    {
        public string name; //владелец
        public int landArea; //площадь земельного учатка (м^2)
        public int livingArea; //жилая площадь(квартиры, дома и тд) (м^2)
        public float price; //рыночная стоимость объекта (рубли)
        public StatusOfObject status; //статус объекта
    }


    //информация об акте нарушения пожарной безопасности
    public enum TitleOfArticle
    {
        title1, title2, title3
    }
    public struct Intruder
    {
        public string name; //имя нарушителя
        public bool buisiness; //является ли предпринимателем
        public bool education; //имеет ли юридическое образование 
    }
    public struct Act
    {
        public TitleOfArticle title; //название статьи по которой обвиняется нарушитель
        public Intruder theIntruder; //нарушитель
        public DateTime date; //когда нарушение произошло 
        public float fine; //размер штрафа (рубли)
    }



    //информация о музыкальном коллективе
    public enum MusicGenre
    {
        Rock, HipHop, Pop, Jazz, Classical, Country, Dance
    }
    public struct Band
    {
        public string name; // название группы
        public DateTime dateOfCreation; // дата создания группы
        public string manager; // имя менеджера группы
        public string[] members; // имена участников группы(за исключением лидера)
        public MusicGenre musicGenre; // наиболее популярный у группы жанр
        public DateTime concert; //дата ближайшего концерта
        public float price; //средняя цена за билет на ближайший концерт
    }
    

    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}