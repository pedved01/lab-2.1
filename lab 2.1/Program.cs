using System;

namespace CSharp_Net_module1_2_1_lab
{
    // 1) declare interface ILibraryUser
    // declare method's signature for methods of class LibraryUser
    interface ILibraryUser
    {
        // declare methods: 
        public void AddBook(ref string[] array)
        {
            //AddBook() – add new book to array bookList
            string[] NewArray = new string[array.Length + 1];
            for (int i = 0; i < array.Length && i < NewArray.Length; i++)
                NewArray[i] = array[i];
            NewArray = array;
        }
        public void RemoveBook(ref string[] array, int index)
        {
            //RemoveBook() – remove book from array bookList
            string[] NewArray = new string[(int)array.Length - 1];
            for (int i = 0; i < index; i++)
                NewArray[i] = array[i];
            for (int i = index + 1; i < NewArray.Length && i < array.Length; i++)
                NewArray[i - 1] = array[i];
            NewArray = array;
        }
        public string BookInfo(string[] array, int index)
        {
            //BookInfo() – returns book info by index
           
            return array[index];
        }
        public int BookCount(string[] array)
        {
            //BooksCout() – returns current count of books
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                ++count;
            }
            return count;
        }
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
        public LibraryUser(string FirstName = "empty", string LastName = "empty", string Phone = "000", int BookLimit = 20, int id = 0)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.id = id;
            this.Phone = Phone;
            this.BookLimit = BookLimit;
        }

    }

    class Program 
    {
        static void Main(string[] args)
        {
            // 8) declare 2 objects. Use default and paremeter constructors
            LibraryUser user1 = new LibraryUser(), user2 = new LibraryUser("Maria", "Ivanenko", "+380447777777", 2);
            Console.WriteLine("User1 " + user1.FirstName + " " + user1.LastName);
            Console.WriteLine("User2 " + user2.FirstName + " " + user2.LastName);

            // 9) do operations with books for all users: run all methods for both objects
            Console.WriteLine("User 1: add Harry Potter");
            user1.AddBook("Harry Potter");
            Console.WriteLine("User 2: add Sherlock Holmes");
            user2.AddBook("Sherlock Holmes");
            Console.WriteLine("user1.BooksCount = " + user1.BooksCount() + "; user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("user2 :");
            Console.WriteLine("Add Kobzar");
            user2.AddBook("Kobzar");
            Console.WriteLine("user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("Add Dorian Gray");
            user2.AddBook("Dorian Gray");
            Console.WriteLine("user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("user2 books " + user2[0] + "\n" + user2[1]);
            Console.WriteLine("Remove Sherlock Holmes");
            user2.RemoveBook("Sherlock Holmes");
            Console.WriteLine("user2.BooksCount " + user2.BooksCount());

        }
    }
}
