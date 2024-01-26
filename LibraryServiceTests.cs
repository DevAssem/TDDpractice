using Xunit;

public class LibraryServiceTests
{
    private readonly Mock<ILibraryRepository> _mockRepo;
    private readonly LibraryService _libraryService;

    public LibraryServiceTests()
    {
        _mockRepo = new Mock<ILibraryRepository>();
        _libraryService = new LibraryService(_mockRepo.Object);
    }

    [Fact]
    public void AddBookToLibrary_WithValidBook_ShouldCallAddBookOnce()
    {
        // Arrange
        var book = new Book
        {
            Title = "1984",
            Author = "George Orwell",
            YearPublished = 1949
        };

        // Act
        _libraryService.AddBookToLibrary(book);              //The "Act" here involves calling the AddBookToLibrary method on the LibraryService instance (_libraryService). The method is expected to add the book to the library if it's valid.

        // Assert
        _mockRepo.Verify(repo => repo.AddBook(It.IsAny<Book>()), Times.Once());
    }

    [Fact]
    public void AddBookToLibrary_WithInvalidTitle_ShouldThrowArgumentException()
    {
        // Arrange
        var book = new Book
        {
            Title = "", // Invalid title
            Author = "George Orwell",
            YearPublished = 1949
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _libraryService.AddBookToLibrary(book));
    }

    [Fact]
    public void RemoveBookFromLibrary_WithValidBook_ShouldCallRemoveBookOnce()
    {
        // Arrange
        var book = new Book
        {
            Title = "1984",
            Author = "George Orwell",
            YearPublished = 1949
        };

        // Act
        _libraryService.RemoveBookFromLibrary(book);

        // Assert
        _mockRepo.Verify(repo => repo.RemoveBook(It.IsAny<Book>()), Times.Once());
    }

    [Fact]
    public void RemoveBookFromLibrary_WithNullBook_ShouldThrowArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _libraryService.RemoveBookFromLibrary(null));
    }

    [Fact]
    public void FindBooksByAuthorInLibrary_WithValidAuthor_ShouldReturnBooks()
    {
        // Arrange
        var author = "George Orwell";
        var books = new List<Book>
        {
            new Book { Title = "1984", Author = "George Orwell", YearPublished = 1949 },
            new Book { Title = "Animal Farm", Author = "George Orwell", YearPublished = 1945 }
        };
        _mockRepo.Setup(repo => repo.FindBooksByAuthor(author)).Returns(books);

        // Act
        var result = _libraryService.FindBooksByAuthorInLibrary(author);

        // Assert
        Assert.Equal(books, result);
    }

    [Fact]
    public void FindBooksByAuthorInLibrary_WithEmptyAuthor_ShouldThrowArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _libraryService.FindBooksByAuthorInLibrary(""));
    }
}
