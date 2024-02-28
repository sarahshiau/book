using Microsoft.AspNetCore.Mvc;
using yorkshin.Repos;
using yorkshin.ViewModels;
namespace yorkshin.ViewComponents;

public class FinishedListPartialViewComponent : ViewComponent
{
    private readonly OrderRepository _orderRepository;
    private readonly YorkshinDbContext _dbContext;
    public FinishedListPartialViewComponent(OrderRepository orderRepository,YorkshinDbContext dbContext)
    {
        _orderRepository = orderRepository;
        _dbContext = dbContext;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = int.Parse(HttpContext.Session.GetString("Uid"));
        return View("_FinishedListPartial",GetFinishedList(userId));
    }
    
    public List<BookViewModel> GetFinishedList(int userId)
    {
        var bookList = _orderRepository.GetFinishedOrders(userId);

        return bookList
            .Where(book => book.Book != null && book.Order != null)
            .Select(book => new BookViewModel
            {
                Author = book.Book.Author,
                BName = book.Book.BName,
                BookStatus = book.Book.BookStatus,
                CategoryJson = book.Book.CategoryJson,
                ImgUrl = book.Book.ImgUrl,
                Price = book.Book.Price,
                Seller = _dbContext.User.FirstOrDefault(u=>u.Uid==book.Order.SellerId).UName,   // Use null-conditional operator
                Buyer = _dbContext.User.FirstOrDefault(u=>u.Uid==userId).UName, // Use null-conditional operator
                OrderId = book.Order.OrderId,
                OrderStatus = book.Order.OrderStatus
            })
            .ToList();
    }

}