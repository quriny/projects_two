namespace _090523.Homework_PoiskPalindroma
{
    internal class Program
    {
        public static bool isPalindrome(string input)
        {
            string checkInput = "";
            for (int i=input.Length-1; i>=0;i--)
            {
                checkInput += input[i];
            }
            if (checkInput.Equals(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку. . .");
            string input = Console.ReadLine();
            string palindrome = "";
            for (int i=0; i<input.Length;++i)
            {
                string mb = "" + input[i]; 
                for (int j=i+1; j<input.Length;++j)
                {
                    mb += input[j];
                    if (isPalindrome(mb) && mb.Length>palindrome.Length)
                    {
                        palindrome = mb;
                    }
                }
            }

            Console.WriteLine(palindrome);

        }
    }
}