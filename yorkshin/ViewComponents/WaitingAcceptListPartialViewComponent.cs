using Microsoft.AspNetCore.Mvc;
using yorkshin.Repos;
using yorkshin.ViewModels;
namespace yorkshin.ViewComponents;

public class WaitingAcceptListPartialViewComponent: ViewComponent
{
    private readonly OrderRepository _orderRepository;
    private readonly YorkshinDbContext _dbContext;
    
    public WaitingAcceptListPartialViewComponent(OrderRepository orderRepository,YorkshinDbContext dbContext)
    {
        _orderRepository = orderRepository;
        _dbContext = dbContext;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = int.Parse(HttpContext.Session.GetString("Uid"));
        return View("_WaitingAcceptListPartial",GetWaitingList(userId));
    }
    public List<BookViewModel> GetWaitingList(int userId)
    {
        var bookList = _orderRepository.GetWaitingOrders(userId);
        return bookList.Where(order => order.Book != null && order.Order != null)
            .Select(book => new BookViewModel
            {
                Bid=book.Book.Bid,
                Author = book.Book.Author,
                BName = book.Book.BName,
                BookStatus = book.Book.BookStatus,
                CategoryJson = book.Book.CategoryJson,
                Isbn = book.Book.Isbn,
                ImgUrl = book.Book.ImgUrl,
                Price = book.Book.Price,
                Seller = _dbContext.User.FirstOrDefault(u=>u.Uid==userId).UName,
                Buyer= _dbContext.User.FirstOrDefault(u=>u.Uid==book.Order.BuyerId).UName
            })
            .ToList();
    }
}