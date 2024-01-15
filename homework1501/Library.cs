using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace homework1501
{
	public class Library
	{
		public Library()
		{
		}
        public Book[] Books = new Book[0];
		public void AddBook(Book book)
        { 
            Array.Resize(ref Books, Books.Length + 1);

            Books[Books.Length - 1] = book;
        }
        
        public Book FindBookByName(string name)
        {
            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i].Name == name)
                    return Books[i];
                Console.WriteLine($"Kitab:{Books[i+1].Name} Price:{Books[i+1].Price}");
            }
            return null;

        }
        public void RemoveBookbyName(Book book)
        {
            int index = Array.IndexOf(Books, book);

            if (index != -1)
            {
                for (int i = index; i < Books.Length - 1; i++)
                {
                    Books[i] = Books[i + 1];
                }

                Array.Resize(ref Books, Books.Length - 1);
            }
        }


    }
}


