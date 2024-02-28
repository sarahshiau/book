using Microsoft.EntityFrameworkCore;
using yorkshin.Entities;
using yorkshin.ViewModels;

namespace yorkshin.Repos;

public class BookRepository
{
    private readonly YorkshinDbContext _dbContext;
    private readonly ILogger<BookRepository> _logger;

    public BookRepository(YorkshinDbContext dbContext, ILogger<BookRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<bool> AddBook(Book book)
    {
        if (book != null)
        {
            _dbContext.Book.Add(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        _logger.LogError("Book is null");
        return false;
    }

    public async Task<List<Book>> GetBookListForSeller(int sellerId)
    {
        var filteredOrderIds = _dbContext.Order
            .Where(order => order.OrderStatus != "已拒絕")
            .Select(order => order.BookId)
            .ToArray();
        var filteredBookList = _dbContext.Book
            .Include(b => b.Seller) // 加入 Include 以載入 Seller 導覽屬性
            .Include(b => b.Order) // 加入 Include 以載入 Order 導覽屬性
            .Where(book => !filteredOrderIds.Contains(book.Bid))
            .OrderByDescending(b => b.Bid) // 這裡以書籍的 ID 為例，你可以根據實際情況選擇其他屬性
            .Where(b => b.SellerId == sellerId).
            ToList();
        return filteredBookList;
        // return _dbContext.Book.Where(b => b.SellerId == sellerId)
            // .Where(b => b.Orders.Count == 0).ToListAsync();
    }

    // get book for buyer, which contains seller name
    public Task<List<Book>> GetBookList()
    {
        var query = from book in _dbContext.Book
            join seller in _dbContext.User on book.SellerId equals seller.Uid
            select new Book
            {
                Bid = book.Bid,
                Author = book.Author,
                BName = book.BName,
                BookStatus = book.BookStatus,
                CategoryJson = book.CategoryJson,
                ImgUrl = book.ImgUrl,
                Price = book.Price,
                Seller = seller,
                Isbn = book.Isbn,
                Description = book.Description
            };
        return query.ToListAsync();
    }

    public List<Book> GetAllBookList()
    {
        var filteredOrderIds = _dbContext.Order
            .Where(order => order.OrderStatus != "已拒絕")
            .Select(order => order.BookId)
            .ToArray();
        var filteredBookList = _dbContext.Book
            .Include(b => b.Seller) // 加入 Include 以載入 Seller 導覽屬性
            .Include(b => b.Order) // 加入 Include 以載入 Order 導覽屬性
            .Where(book => !filteredOrderIds.Contains(book.Bid))
            .ToList();
        return filteredBookList;
    }

    public async Task<bool> DeleteBook(int bookId)
    {
        var book = await _dbContext.Book.FindAsync(bookId);
        if (book != null)
        {
            _dbContext.Book.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        _logger.LogError($"Book with ID {bookId} not found.");
        return false;
    }

    public async Task<Book?> GetUpdateBook(int bookId)
    {
        // return _dbContext.Book.SingleOrDefault(b => b.Bid == bookId)!;
        return await _dbContext.Book.SingleOrDefaultAsync(b => b.Bid == bookId)!;
    }


    public BookViewModel OrderPageGetBook(int bookId)
    {
        Console.WriteLine(bookId);
        var findBook = _dbContext.Book.Include(book => book.Seller).FirstOrDefault(b => b.Bid == bookId);
        //var GetBook = _dbContext.Book.Where(b =>b.Bid == bookId).ToList();
        if (findBook != null)
        {
            var Get_Book = new BookViewModel
            {
                Bid = findBook.Bid,
                BName = findBook.BName,
                Author = findBook.Author,
                Isbn = findBook.Isbn,
                Price = findBook.Price,
                BookStatus = findBook.BookStatus,
                Description = findBook.Description,
                ImgUrl = findBook.ImgUrl,
                CategoryJson = findBook.CategoryJson,
                Seller = findBook.Seller?.UName
            };
            return Get_Book;
        }

        return null;
    }

    public async Task<bool> UpdateBook(int bookId, Book book)
    {
        var bookToUpdate = _dbContext.Book.FirstOrDefault(b => b.Bid == bookId);
        if (bookToUpdate != null)
        {
            bookToUpdate.BName = book.BName;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Price = book.Price;
            bookToUpdate.Isbn = book.Isbn;
            bookToUpdate.CategoryJson = book.CategoryJson;
            bookToUpdate.BookStatus = book.BookStatus;
            if (book.ImgUrl != "")
            {
                bookToUpdate.ImgUrl = book.ImgUrl;
            }
        }

        await _dbContext.SaveChangesAsync();
        return true;
    }
}