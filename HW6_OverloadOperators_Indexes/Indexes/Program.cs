using System;
using System.Collections.Specialized;

namespace Indexes
{
    internal class Program
    {
        class Book
        {
            private string title;
            private string author;
            private double price;
            public string Title
            {
                get { return title; }
                set
                {
                    if (value != null)
                    {
                        title = value;
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
            }
            public string Author
            {
                get { return author; }
                set
                {
                    if (value != null)
                    {
                        author = value;
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
            }
            public double Price
            {
                get
                {
                    return price;
                }
                set
                {
                    if(value>0)
                    {
                        price = value;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
            public Book(string t, string a, double p)
            {
                Title = t;
                Author = a;
                Price = p;
            }
            public override string ToString()
            {
                return $"Title: {Title}\tAuthor: {Author}\tPrice: {Price}";
            }
        }
        class BookList
        {
            Book[] books;
            int count;
            public BookList(int size)
            {
                books = new Book[size];
            }
            public int Length { get { return books.Length; } }
            public Book this[int index]
            {
                get
                {
                    if(index>=0 && index < books.Length)
                    {
                        return books[index];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();                    
                    }
                }
                set
                {
                    if (index >= 0 && index < books.Length)
                    {
                        books[index] = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }
            public int FindByTitle(string title)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i].Title == title)
                    {
                        return i;
                    }
                }
                return -1;
            }
            public int FindByAuthor(string author)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i].Author == author)
                    {
                        return i;
                    }
                }
                return -1;
            }
            public int FindByPrice(double price)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i].Price == price)
                    {
                        return i;
                    }
                }
                return -1;
            }
            public Book this[string val]
            {
                get
                {
                    int indexT = FindByTitle(val);
                    int indexA = FindByAuthor(val);
                    if (indexT!=-1)
                    {
                        return books[indexT];
                    }
                    else if(indexA!=-1)
                    {
                        return books[indexA];
                    }
                    else
                    {
                        throw new Exception("Incorrect title or author");
                    }
                }
                set
                {
                    int indexT = FindByTitle(val);
                    int indexA = FindByAuthor(val);
                    if (indexT != -1)
                    {
                        books[indexT] = value;
                    }
                    else if (indexA != -1)
                    {
                        books[indexA] = value;
                    }
                    else
                    {
                        throw new Exception("Incorrect title or author");
                    }
                }
            }
            public Book this[double price]
            {
                get
                {
                    int index = FindByPrice(price);
                    if(index!=-1)
                    {
                        return books[index];
                    }
                    else
                    {
                        throw new Exception("Incorrect price");
                    }
                }
                set
                {
                    int index = FindByPrice(price);
                    if (index != -1)
                    {
                        books[index] = value;
                    }
                    else
                    {
                        throw new Exception("Incorrect price");
                    }
                }
            }
            public void AddBook(Book book)
            {
                if (count < books.Length)
                {
                    books[count] = book;
                    count++;
                }
                else
                {
                    throw new IndexOutOfRangeException("Booklist is full");
                }
            }
            public void DeleteBook(string title)
            {
                int index = FindByTitle(title);
                if (index != -1)
                {
                    for (int i = index; i < count-1; i++)
                    {
                        books[i] = books[i + 1];
                    }
                }
                else
                {
                    throw new Exception("Book not found");
                }
            }
            public bool Contains(string title)
            {
                return FindByTitle(title) != -1;
            }

        }
        static void Main(string[] args)
        {
            BookList bookList = new BookList(3);
            bookList.AddBook( new Book("The Foxhole Court", "Nora Sacavic",  520.00));
            bookList.AddBook( new Book("Harry Potter", "Joanne Rowling",  360.00));
            bookList.AddBook(new Book("The Poppy War", "Rebecca F. Kwan", 550.00));
            try
            {
                bookList.DeleteBook("Harry Potter");
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(bookList[i]);
                }
                Console.WriteLine(bookList.Contains("Harry Potter"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
    }
//    Створіть додаток «Список книг до прочитання». 
//Додаток має дозволяти додавати книги до списку, 
//видаляти книги зі списку, перевіряти чи є книга у списку.
//Використовуйте механізм властивостей,перевизначте всі види
//індексаторів, які можливі для масиву книг.
}