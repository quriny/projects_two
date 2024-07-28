using System.Xml.Linq;

namespace _080423.Homework.RazborArifmeticheskihVirazheniy
{
    internal class Program
    {
        //класс стек для string
        public class StringStack
        {
            public int StackSize = 10;
            public const int Empty = -1;
            private string[] items;

            //индекс последнего добавленного элемента
            private int top = Empty;

            public StringStack(int StackSize)
            {
                this.StackSize = StackSize;
                items = new string[StackSize];
                top = Empty;
            }
            //Проверка пустоты
            public bool IsEmpty()
            {
                if (top==-1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //Добавить новый элемент в стек
            public void Push(string value)
            {
                items[top + 1] = value;
                top++;
            }
            //Извлечь элемент из стека
            public string Pop()
            {
                string value = items[top];
                top--;
                return value;
            }
            //Взять элемент из стека, не удаляя              
            public string Peek()
            {
                string value = items[top];
                return value;
            }
            //Удаление элементов стека
            public void Clear()
            {
                top = Empty;
            }
            //Количество элементов стека
            public int Count()
            {
                return top + 1;
            }
        }
        //класс стек для double
        public class DoubleStack
        {
            public int StackSize = 10;
            public const int Empty = -1;
            private double[] items;

            //индекс последнего добавленного элемента
            private int top = Empty;

            public DoubleStack(int StackSize)
            {
                this.StackSize = StackSize;
                items = new double[StackSize];
                top = Empty;
            }
            //Проверка пустоты
            public bool IsEmpty()
            {
                if (top == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //Добавить новый элемент в стек
            public void Push(double value)
            {
                items[top+1] = value;
                top++;
            }
            //Извлечь элемент из стека
            public double Pop()
            {
                double value=items[top];
                top--;
                return value;
            }
            //Взять элемент из стека, не удаляя            
            public double Peek()
            {
                double value = items[top];
                return value;
            }
            //Удаление элементов стека
            public void Clear()
            {
                top = Empty;
            }
            //Количество элементов стека
            public int Count()
            {
                return top+1;
            }
        }
        //Разбивает элементы строки на два стека, согласну алгоритму Бауэра и Замельзона
        public static string Parser(string s, ref int index, out bool flag)
        {

            flag = false;
            if (char.IsNumber(s[index])) {
                string buffer = "";
                while (index < s.Length && (s[index].Equals(',') || char.IsNumber(s[index])))
                {
                    buffer += s[index];
                    ++index;
                }
                --index;
                flag = true;
                return buffer;
            }
            else
            {
                string buffer= Char.ToString(s[index]);
                return buffer;
            }
        }
        //Обработка операций
        public static double Operation(double a, double b, string s)
        {
            switch (s)
            {
                case "+": return a + b; break;
                case "-": return a - b; break;
                case "*": return a * b; break;
                case "/": return a / b; break;
                default: return -100000;
            }
        }
        //Обработка индексов таблицы
        public static int ConvertToTable(string element)
        {
            switch (element)
            {
                case "(": return 1; break;
                case "+": return 2; break;
                case "-": return 3; break;
                case "*": return 4; break;
                case "/": return 5; break;
                case ")": return 6; break;
                default: return 0;
            }
        }
        //Таблица перехода
        public static int Table(string rowString, string colString)
        {
            int row=ConvertToTable(rowString);
            int col = ConvertToTable(colString);
            int[,] table = new int[,] { { 6, 1, 1, 1, 1, 1, 5 },
                                    { 5, 1, 1, 1, 1, 1, 3 },
                                    { 4, 1, 2, 2, 1, 1, 4 },
                                    { 4, 1, 2, 2, 1, 1, 4 },
                                    { 4, 1, 4, 4, 2, 2, 4 },
                                    { 4, 1, 4, 4, 2, 2, 4 }};
            return table[row, col];
        }
        //Действие по таблице
        public static void Step(string element, StringStack T, DoubleStack E)
        {
            int x=T.IsEmpty() ? Table("0", element) : Table(T.Peek(), element);
            switch (x)
            {
                case 1:
                    T.Push(element);
                    break;
                case 2:
                    E.Push(Operation(E.Pop(), E.Pop(), T.Pop()));
                    break;
                case 3:
                    T.Pop();
                    break;
                case 4:
                    E.Push(Operation(E.Pop(), E.Pop(), T.Pop()));
                    Step(element, T, E);
                    break;
                case 5:
                    Console.WriteLine("Произошла ошибка...");
                    break;
                default: break;

            }
        }
        //Алгоритм Бауэра и Замельзона
        public static string BauerAndZamelzon(string s)
        {
            StringStack T = new StringStack(10);//стек для записи операций и скобок 
            DoubleStack E = new DoubleStack(10);//стек для записи операндов 
            bool flag;
            for (int i=0;i<s.Length;++i)
            {
                string element = Parser(s, ref i, out flag);
                if (flag)
                {
                    E.Push(Convert.ToDouble(element));
                }else
                {
                    Step(element, T, E);
                }
            }
            Console.WriteLine(E.Peek());





            //for (int i=0;i<s.Length;++i)
            //{
            //    string element=Parser(s, ref i, out flag);
            //    if (flag)
            //    {
            //        E.Push(Convert.ToDouble(element));
            //    }
            //    else
            //    {
            //        T.Push(element);
            //    }
            //}
            return "";
        }
        static void Main(string[] args)
        {
            //string s = "2,3+(34,1+3)/7,5";
            Console.WriteLine("Введите выражение. . .");
            string input=Console.ReadLine();
            Console.WriteLine(BauerAndZamelzon(input));




            //for (int index=0; index<input.Length;++index)
            //{
            //    Console.WriteLine(Parser(input, ref index));
            //}




            
            
            
            
            

        }
    }
}