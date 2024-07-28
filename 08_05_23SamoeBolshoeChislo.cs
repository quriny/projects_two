namespace _080523.Homework.SamoeBolshoeChislo
{
    internal class Program
    {
        public static double SplitterMax(string str)
        {
            if (str.Contains(',')) {
                if (str.Length == 0)
                {
                    return 0;
                }

                string[] array = str.Split(',');
                double max = 0;

                for (int i = 0; i < array.Length - 1; ++i)
                {
                    double temp = Convert.ToDouble(array[i] + "," + array[i + 1]);
                    max = max > temp ? max : temp;
                }

                return max;
            }
            else if(str.Length>0)
            {
                return Convert.ToDouble(str);
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку. . .");
            string input=Console.ReadLine();
            input += '$';
            double result = 0;
            string toMathod = "";
            foreach (char symbol in input)
            {
                
                if (char.IsNumber(symbol) || symbol.Equals(','))
                {
                    toMathod += symbol;
                }
                else
                {
                    result = result>SplitterMax(toMathod) ? result : SplitterMax(toMathod);
                    toMathod = "";
                }
            }
            Console.WriteLine(result);
        }
    }
}