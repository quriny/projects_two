using System;
using System.Collections.Generic;
using System.IO;

namespace program
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите название директории. . .");
            string path;
            DirectoryIndex index = new DirectoryIndex();

            while (true)
            {
                try
                {
                    path = Console.ReadLine();
                    index = new DirectoryIndex(path);
                    break;
                }
                catch (DirectoryNotFoundException) { 
                    Console.WriteLine("Директива не найдена. . ."); 
                }
                catch (UnauthorizedAccessException) {
                    Console.WriteLine("Директива не доступна. . ."); 
                }
                catch (Exception e) { 
                    Console.WriteLine("Ошибка. Попробуйте еще раз. . ."); 
                }
            }

            while (true)
            {
                Console.WriteLine("1 – найти файл, 2 – выйти из программы");
                string file = Console.ReadLine(); 
                bool isFound;
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine();
                //выход из программы
                if (file == "2")
                {
                    break;
                }
                //если выбрали поиск файла
                else if (file == "1") {
                    Console.WriteLine("Введите имя искомого файла. . . "); 
                    file = Console.ReadLine(); 
                }
                //ввыбрали не 1 и не 2 
                else {
                    Console.WriteLine("Ошибка. . .");
                    Console.ReadKey(); 
                    break; 
                }
                //ищем
                List<string> s = null;

                try { 
                    isFound = index.Find(file, out s); 
                }
                catch (NullReferenceException) { 
                    isFound = false; 
                }
                //если нашлось
                if (isFound)
                {
                    Console.WriteLine("Искомые файлы:");
                    foreach (var q in s)
                    {
                        Console.WriteLine(q);
                    }
                }
                //если не нашлось
                else Console.WriteLine("Файл не найден. . .");
            }
        }
    }
    struct DirectoryIndex
    {
        public bool flag;
        public List<File>[] table;
        private List<string> directories;

        public DirectoryIndex(string path)
        {
            flag = true;
            table = new List<File>[256];
            directories = new List<string>();
            directories = FindDirectories(path);
            AddFiles(directories);
            Console.WriteLine();
        }
        //добавление директорий
        public List<string> FindDirectories(string path)
        {
            List<string> tmp = new List<string>(), tmp2 = new List<string>();

            if (flag) {
                tmp2.Add(path); 
                flag = false; 
            }
            try
            {
                tmp.AddRange(Directory.GetDirectories(path));
                tmp2.AddRange(tmp);
                foreach (var directory in tmp)
                {
                    tmp2.AddRange(FindDirectories(directory));
                }
            }
            catch (UnauthorizedAccessException) { }
            return tmp2;
        }

        public void AddFiles(List<string> paths)
        {
            foreach (var path in paths)
            {
                string[] tmp = new string[0];
                try { 
                    tmp = Directory.GetFiles(path); 
                }
                catch (UnauthorizedAccessException) { }
                foreach (var file in tmp)
                {
                    Add(file);
                }
            }
        }

        public void Add(string path)
        {
            File file = new File(path);
            byte hash = file.GetHash();

            try { 
                table[hash].Add(file); 
            }
            catch (NullReferenceException) { 
                table[hash] = new List<File>(); 
                table[hash].Add(file); 
            }
        }
        //поиск нужного файла
        public bool Find(string name, out List<string> result)
        {
            byte b = 0;
            result = new List<string>();

            foreach (char c in name.ToLower())
            {
                b += (byte)c;
            }
            foreach (File f in table[b])
            {
                if (f.EqualsName(name.ToLower()))
                {
                    result.Add(f.path);
                }
            }

            return result.Count > 0;
        }
        public List<File> GetList(byte b) { 
            return table[b];
        }
        //структура файла
        public struct File
        {
            public string fileName, path;
            public File(string path) { 
                this.path = path; fileName = Path.GetFileName(path); 
            }
            public byte GetHash()
            {
                byte b = 0;
                foreach (char c in fileName.ToLower())
                {
                    b += (byte)c;
                }
                return b;
            }
            //сравнение имен
            public bool EqualsName(string name) { 
                return name.Equals(fileName); 
            }
        }
    }
}