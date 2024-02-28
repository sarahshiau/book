using Microsoft.AspNetCore.Mvc;
using yorkshin.Repos;
using yorkshin.ViewModels;
namespace yorkshin.ViewComponents;

public class AcceptedListPartialViewComponent : ViewComponent
{
    private readonly OrderRepository _orderRepository;
    private readonly YorkshinDbContext _dbContext;
    public AcceptedListPartialViewComponent(OrderRepository orderRepository,YorkshinDbContext dbContext)
    {
        _orderRepository = orderRepository;
        _dbContext = dbContext;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = int.Parse(HttpContext.Session.GetString("Uid"));
        return View("_AcceptedListPartial",GetAcceptedList(userId));
    }
    
    public List<BookViewModel> GetAcceptedList(int userId)
    {
        var bookList = _orderRepository.GetAcceptedOrders(userId);
        return bookList.Where(book =>true)
            .Select(book => new BookViewModel
            {
                Author = book.Book.Author,
                BName = book.Book.BName,
                BookStatus = book.Book.BookStatus,
                CategoryJson = book.Book.CategoryJson,
                ImgUrl = book.Book.ImgUrl,
                Price = book.Book.Price,
                //Seller = book.Order.Seller?.UName,
                Seller= _dbContext.User.FirstOrDefault(u=>u.Uid==userId).UName,
                Buyer = _dbContext.User.FirstOrDefault(u=>u.Uid==book.Order.BuyerId).UName,
                OrderStatus = book.Order.OrderStatus,
                OrderId=book.Order.OrderId
            })
            .ToList();
    }
}