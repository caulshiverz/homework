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
            try
            {
                Console.WriteLine("Enter the release date of the book (YYYY-MM-DD):");
                DateTime.TryParse(Console.ReadLine(), out var releaseDate);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid date format.");
            }
            var newBook = new Book(title, author, releaseDate);
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

    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime ReleaseDate { get; set; }
}

public class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public List<Book> Books { get; set; }

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"{book.Title} has been added to the library.");
    }

    public void RemoveBook(string Title)
    {
        try
        {
            books.Remove(Book.Title);
            Console.WriteLine($"{Title} has been removed from the library.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"{Title} not found in the library.");
        }
    }

    public void ListBooks()
    {
        try
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("There are no books in the library.");
        }
    }
}