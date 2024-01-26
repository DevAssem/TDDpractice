public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }
}

public interface ILibraryRepository
{
    void AddBook(Book book);
    void RemoveBook(Book book);
    IEnumerable<Book> FindBooksByAuthor(string author);
}

public class LibraryService
{
    private readonly ILibraryRepository _libraryRepository;

    public LibraryService(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public void AddBookToLibrary(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
        {
            throw new ArgumentException("Book title and author are required.");
        }

        if (book.YearPublished > DateTime.Now.Year)
        {
            throw new ArgumentException("Book cannot be published in the future.");
        }

        _libraryRepository.AddBook(book);
    }

    public void RemoveBookFromLibrary(Book book)
    {
        if (book == null)
        {
            throw new ArgumentException("Book cannot be null.");
        }

        _libraryRepository.RemoveBook(book);
    }

    public IEnumerable<Book> FindBooksByAuthorInLibrary(string author)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException("Author name is required.");
        }

        return _libraryRepository.FindBooksByAuthor(author);
    }
}
