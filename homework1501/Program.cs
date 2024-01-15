using System;
using System.Reflection;
using System.Xml.Linq;

namespace homework1501
{
    class Program
    {
        static void Main(string[] args)
        {
            Library store = new Library();
            string opt;
            do
            {
                Console.WriteLine("\n============Menu============\n");
                Console.WriteLine("1.Kitab əlavə et");
                Console.WriteLine("2.Kitab sil");
                Console.WriteLine("3.Bütün kitablara bax");
                Console.WriteLine("4.Secilmiş kitaba bax(ada görə)");
                Console.WriteLine("5.Ada görə axtarış et");
                Console.WriteLine("0.Əməliyyatı bitir");
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "1": //Kitab əlavə et
                    Console.Write("Kitabin adini qeyd edin: ");
                    string name = Console.ReadLine();
                    if (name.Length >= 3 && name.Length <= 20)
                    {
                    Console.Write("Kitabin qiymetini daxil edin: ");
                    if (double.TryParse(Console.ReadLine(), out double price) && price > 0)
                     {
                    if (store.FindBookByName(name) == null)
                     {
                     Book newBook = new Book(name, price);
                     store.AddBook(newBook);
                     Console.WriteLine($"Kitab '{name}' ugurla əlavə edildi!");
                     }
                    else
                    {
                    Console.WriteLine("Əməliyyat səhvdir");
                     }
                    }
                    else
                    {
                    Console.WriteLine("Əməliyyat səhvdir");
                    }
                        }
                        else
                        {
                            Console.WriteLine("Əməliyyat səhvdir");
                        }
                        break;

                    case "2":
                        Console.Write("Kitabin adini qeyd edin:");
                        string bookNameToDelete = Console.ReadLine();
                        Book bookToDelete = store.FindBookByName(bookNameToDelete);

                        if (bookToDelete != null)
                        {
                            store.RemoveBookbyName(bookToDelete);
                            Console.WriteLine($"Kitab '{bookToDelete.Name}' ugurla silindi!");
                        }
                        else
                        {
                            Console.WriteLine($"Kitab '{bookNameToDelete}' tapilmadi!");
                        }

                        break;

                    case "3":
                        for (int i = 0; i < store.Books.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}.{store.Books[i].Name}");
                        }

                        break;
                    case "4":
                        Console.WriteLine("Mehsul adi:");
                        string bsName = Console.ReadLine();
                        Book bs = store.FindBookByName(bsName);
                        break;
                    case "5":
                        Console.WriteLine("Adini daxil edin:");
                        string search = Console.ReadLine();
                        for (int i = 0; i < store.Books.Length; i++)
                        {
                            if (store.Books[i].Name.Contains(search))
                                Console.WriteLine(store.Books[i].Name + "-" + store.Books[i].Price);
                        }
                        break;
                    default:
                        Console.WriteLine("Əməliyyat yanlisdir!");
                        break;
                }
            }
            while (opt != "0");

        }


    }
}

