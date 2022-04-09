

// ZADANIE 1


//using System;
//using System.IO;
//
//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Czy chcesz odtworzyć plik?");
//            if(Console.ReadKey().Key == ConsoleKey.Y)
//            {
//                Console.WriteLine("Plik otwarty");
//                var path = @"nazwa.txt";
//                if (!File.Exists(path)){
//                    Console.WriteLine("File doesn't exists");
//                }
//                else
//                {
//                    string text = File.ReadAllText(@"nazwa.txt");
//                    Console.WriteLine(text);
//                }
//            }
//        }
//    }
//}


// ZADANIE 2


//using System;
//using System.IO;
//
//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Wprowadź tekst który chcesz zapisać do pliku");
//            var text = Console.ReadLine();
//
//            var path = @"nazwa.txt";
//            if (!File.Exists(path))
//            {
//                File.Create(path);
//                File.WriteAllText(path, text);
//
//            }
//            else
//            {
//                File.WriteAllText(path, text);
//            }
//        }
//    }
//}


// ZADANIE 5


using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime localTime = DateTime.Today;
            DateTime globalTime = DateTime.UtcNow;
            
            Console.WriteLine("Aktualny lokalny czas: {0}", localTime.ToString("yyyy-MM-dd hh:mm:ss"));
            Console.WriteLine("Aktualny globalny czas: {0}", globalTime.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}


// ZADANIE 7


//using System;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//
//namespace ConsoleApp1
//{
//    public class Book
//    {
//        public string Author { get; set; }
//        public string Title { get; set; }
//        public int YearOfPublish { get; set; }
//        public string publishingHouse { get; set; }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var book = new Book
//            {
//                Author = "Steve Alens",
//                Title = "Title",
//                YearOfPublish = 2022,
//                publishingHouse = "publish"
//            };
//            string jsonString = JsonSerializer.Serialize(book);
//            Console.WriteLine(jsonString);
//        }
//    }
//}


// ZADANIE 8


//using System;
//using System.Text.Json;
//
//namespace ConsoleApp1
//{
//    public class Book
//    {
//        public string Author { get; set; }
//        public string Title { get; set; }
//        public int YearOfPublish { get; set; }
//        public string publishingHouse { get; set; }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//
//            string jsonString = @"{ ""Author"":""Steve Alens"",""Title"":""Title"",""YearOfPublish"":2022,""publishingHouse"":""publish""}";
//            Book? book = JsonSerializer.Deserialize<Book>(jsonString);
//            Console.WriteLine($"Author: {book.Author}");
//            Console.WriteLine($"Title: {book.Title}");
//            Console.WriteLine($"Year: {book.YearOfPublish}");
//            Console.WriteLine($"Publish  house: {book.publishingHouse}");
//        }
//    }
//}
