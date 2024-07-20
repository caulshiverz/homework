var library = new Library();

while (true)
{
    Console.WriteLine("Welcome to the library! Please select an action to perform from the menu below (1, 2, 3, 4):");
    Console.WriteLine("1. Add a book.");
    Console.WriteLine("2. Remove a book.");
    Console.WriteLine("3. List all books.");
    Console.WriteLine("4. Exit.");
    var selection = Console.ReadLine();

    switch (selection)
    {
        case "1":
            Console.WriteLine("Enter the title of the book:");
            var title = Console.ReadLine();
            Console.WriteLine("Enter the author of the book:");
            var author = Console.ReadLine();
            DateTime release = DateTime.Now; 
            try
            {
                Console.WriteLine("Enter the release date of the book (YYYY-MM-DD):");
                release = DateTime.TryParse(Console.ReadLine(), out var releaseDate) ? releaseDate : throw new Exception();
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid date format.");
            }
            var newBook = new Book(title, author, release);
            AddBook(newBook);
            break;

        case "2":
            Console.WriteLine("Enter the title of the book to remove:");
            var bookRemove = Console.ReadLine();
            RemoveBook(bookRemove);
            break;

        case "3":
            ListBooks();
            break;

        case "4":
            Console.WriteLine("Good luck!");
            return;

        default:
            Console.WriteLine("Invalid selection! Enter a valid selection (1, 2, 3, 4).");
            break;
    }
}

void AddBook(Book book)
{
    library.Books.Add(book);
    Console.WriteLine($"{book.Title} has been added to the library.");
}

void RemoveBook(string title)
{
    try
    {
        foreach (var book in library.Books)
        {
            if (book.Title == title)
            {
                library.Books.Remove(book);
                Console.WriteLine($"{title} has been removed from the library.");
                return;
            }
        }      
    }
    catch (Exception e)
    {
        Console.WriteLine($"{title} not found in the library.");
    }
}

void ListBooks()
{
    try
    {
        foreach (var book in library.Books)
        {
            Console.WriteLine($"Book: {book.Title}, Author: {book.Author}, Release Date: {book.ReleaseDate}");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("There are no books in the library.");
    }
}
public class Book
{
    private string _title;
    private string _author;
    private DateTime _releaseDate;

    public Book(string title, string author, DateTime releaseDate)
    {
        _title = title;
        _author = author;
        _releaseDate = releaseDate;
    }

    public string Title => _title;
    public string Author => _author;
    public DateTime ReleaseDate => _releaseDate;
}

public class Library
{
    public List<Book> Books { get; private set; }

    public Library()
    {
        Books = new List<Book>();
    } 
}