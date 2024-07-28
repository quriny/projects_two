using System.Diagnostics.Tracing;

namespace _230423.Homework.RabotaSoStrokami
{
    internal class Program
    {
        //поиск строки в списке
        public static bool SearchString(List<string> list, string element)
        {
            for (int i = 0; i < list.Count(); ++i)
            {
                if (list[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            string text = "Обратившись к действительности, Гнор пытался некоторое время" +
                          " превратить свои неполные двадцать лет в двадцать один. Вопрос о " +
                          "совершеннолетии стоял для него ребром: очень молодым людям, когда они" +
                          " думают жениться на очень молодой особе, принято чинить разные " +
                          "препятствия. Гнор обвел глазами прекрасную обстановку комнаты, в " +
                          "которой жил около месяца. Ее солидная роскошь по отношению к нему " +
                          "была чем - то вроде надписи, вывешенной над конторкой дельца: " +
                          "сутки имеют двадцать четыре часа. На языке Гнора это звучало так: " +
                          "у нее слишком много денег.";
            //вывод изначального текста
            Console.WriteLine(text);
            text = text.Replace(",", "");
            text = text.Replace(".", "");
            text = text.Replace(":", "");
            text = text.Replace(" - ", " ");
            //список введенных слов 
            List<string> inputStrings = new List<string>(text.Split(' '));
            //список неповторяющихся слов
            List<string> resStrings = new List<string>();
            //список введенных слов в нижнем регистре
            for (int i =0; i<inputStrings.Count();++i)
            {
                inputStrings[i]= inputStrings[i].ToLower();
            }
            //инициализация списка неповторяющихся слов
            for(int i = 0; i < inputStrings.Count(); ++i)
            {
                if(!SearchString(resStrings, inputStrings[i]))
                {
                    resStrings.Add(inputStrings[i]);
                }
            }
            //массив счетчиков
            int[] array=new int[resStrings.Count()];
            for (int i=0;i<array.Length;++i)
            {
                array[i] = 0;
            }
            //считаем сколько раз встречается каждое неповторяющееся слово в исходной строке
            for(int i = 0; i < resStrings.Count(); ++i)
            {
                for (int j=0;j<inputStrings.Count();++j)
                {
                    if (inputStrings[j].Equals(resStrings[i]))
                    {
                        array[i]++;
                    }
                }
            }
            //вывод
            for (int i=0;i<array.Length;++i)
            {
                Console.WriteLine(resStrings[i]+" - " + array[i]);
            }
            Console.WriteLine(array.Length);
        }
    }
}