global using System;

namespace CSharp_Net_module1_2_1_lab
{
    // 1) declare interface ILibraryUser
    // declare method's signature for methods of class LibraryUser
    interface ILibraryUser
    {


        // declare methods: 
        public void AddBook(string book);
        public void RemoveBook(string book);
        public void BookInfo(int index);
        public int BookCount();

    }
    // 2) declare class LibraryUser, it implements ILibraryUser

    public class LibraryUser : ILibraryUser
    // 3) declare properties: FirstName(read only), LastName(read only), 
    // Id (read only), Phone (get and set), BookLimit (read only)
    {
        public string FirstName;
        public string LastName;
        public int id;
        public string Phone { get; set; }
        public int BookLimit;
        // 4) declare field(bookList) as a string array
        public string[] booklist;
        // 5) declare indexer BookList for array bookList
        public string this[int i]
        {
            get { return booklist[i]; }
        }
        // 6) declare constructors: default and parameter
        public LibraryUser(string FirstName = "first neme - empty", string LastName = "second name - empty", string Phone = "no phone", int id = -1, int BookLimit = 20)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.id = id;
            this.Phone = Phone;
            this.BookLimit = BookLimit;
            this.booklist = new string[BookLimit];
        }

        public void AddBook(string book)
        {
            for (int i = 0; i < booklist.Length; i++)
            {
                if (booklist[i] == null)
                {
                    booklist[i] = book;
                    break;
                }
            }

        }
        public void RemoveBook(string book)
        {
           for (int i = 0; i < booklist.Length; i++)
            {
                if (booklist[i] == book)
                {
                    booklist[i] = null;
                    break;
                }  
            }
        }

        public void BookInfo(int index)
        {
            Console.WriteLine($"Book with index{index} - {booklist[index]}");
        }

        public int BookCount()
        {
            int count = 0;
            for (int i = 0; i < booklist.Length; i++)
            {
                if (booklist[i] != null)
                    count++;

            }
            return count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 8) declare 2 objects. Use default and paremeter constructors
            var user1 = new LibraryUser();
            var user2 = new LibraryUser("Maria", "Ivanenko", "+380447777777", 2);
            Console.WriteLine("User1 " + user1.FirstName + " " + user1.LastName);
            Console.WriteLine("User2 " + user2.FirstName + " " + user2.LastName);

            // 9) do operations with books for all users: run all methods for both objects
            Console.WriteLine("User 1: add Harry Potter");
            user1.AddBook("Harry Potter");
            Console.WriteLine("User 2: add Sherlock Holmes");
            user2.AddBook("Sherlock Holmes");
            Console.WriteLine("user1.BooksCount = " + user1.BookCount() + "; user2.BooksCount " + user2.BookCount());
            Console.WriteLine("user2 :");
            Console.WriteLine("Add Kobzar");
            user2.AddBook("Kobzar");
            Console.WriteLine("user2.BooksCount " + user2.BookCount());
            Console.WriteLine("Add Dorian Gray");
            user2.AddBook("Dorian Gray");
            Console.WriteLine("user2.BooksCount " + user2.BookCount());
            Console.WriteLine("user2 books " + user2[0] + "\n" + user2[1]);
            Console.WriteLine("Remove Sherlock Holmes");
            user2.RemoveBook("Sherlock Holmes");
            Console.WriteLine("user2.BooksCount " + user2.BookCount());

        }
    }
}
