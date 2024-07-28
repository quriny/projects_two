using System.Linq.Expressions;

namespace FindFile
{


    internal class Program
    {
        public struct File
        {
            public string FullPath;

            public string Name;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя директории:");
            string directory = Console.ReadLine();
            List<File>[] hashtable;
            try
            {
                hashtable = IndexFiles(directory, out int count);

            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Директория не найдена!");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("error");
                Console.WriteLine(e.Message);
                return;
            }

            string nameToFind;
            do
            {
                Console.WriteLine("Введите имя файла:");
                nameToFind = Console.ReadLine();
            } while (String.IsNullOrEmpty(nameToFind));
            try
            {
                List<string> names = Find(nameToFind, hashtable);
                for (int i = 0; i < names.Count; i++)
                    Console.WriteLine(names[i]);
            }
            catch (Exception)
            {
                Console.WriteLine("Файл не найден");
            }
        }

        public static List<string> Find(string filename, List<File>[] hashtable)
        {
            List<string> files = new List<string>();
            filename = filename.ToLower();
            byte hashValue = CreateHashCode(filename);

            for (int i = 0; i < hashtable[hashValue].Count; i++)
            {
                File file = hashtable[hashValue][i];
                if (file.Name == filename)
                    files.Add(file.FullPath);
            }

            return files;
        }

        public static void WriteInHashTable(string path, List<File>[] hashtable, out int count)
        {
            byte hashValue;
            string fileName;
            count = 0;
            try
            {
                foreach (string file in Directory.EnumerateFiles(path))
                {
                    fileName = Path.GetFileName(file);
                    hashValue = CreateHashCode(fileName.ToLower());
                    if (hashtable[hashValue] == null) hashtable[hashValue] = new List<File>();
                    hashtable[hashValue].Add(new File() { FullPath = file, Name = fileName.ToLower() });
                    count++;
                }

                foreach (string folder in Directory.EnumerateDirectories(path))
                {
                    WriteInHashTable(folder, hashtable, out int countOther);
                    count += countOther;
                }
            }
            catch (UnauthorizedAccessException) { }

        }

        public static List<File>[] IndexFiles(string path, out int count)
        {
            List<File>[] hashtable = new List<File>[256];
            WriteInHashTable(path, hashtable, out count);
            return hashtable;
        }

        private static byte CreateHashCode(string str)
        {
            char[] chars = str.ToCharArray();
            int sum = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                sum += (byte)chars[i];
            }
            sum ^= str.Length;
            return (byte)sum;
        }
    }
}