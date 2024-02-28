using Microsoft.AspNetCore.Mvc;
using yorkshin.Repos;
using yorkshin.ViewModels;
namespace yorkshin.ViewComponents;

public class SoldListPartialViewComponent : ViewComponent
{
    private readonly OrderRepository _orderRepository;
    private readonly YorkshinDbContext _dbContext;
    public SoldListPartialViewComponent(OrderRepository orderRepository,YorkshinDbContext dbContext)
    {
        _orderRepository = orderRepository;
        _dbContext = dbContext;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = int.Parse(HttpContext.Session.GetString("Uid") ?? string.Empty);
        return View("_SoldListPartial",GetSoldedList(userId));
    }
    
    public List<BookViewModel> GetSoldedList(int userId)
    {
        var bookList = _orderRepository.GetSoldedOrders(userId);
        return bookList
        .Where(order => true)
        .Select(order => new BookViewModel()
        {
            Author = order.Book.Author,
            BName = order.Book.BName,
            BookStatus = order.Book.BookStatus,
            CategoryJson = order.Book.CategoryJson,
            ImgUrl = order.Book.ImgUrl,
            Price = order.Order.Price,
            Seller = _dbContext.User.FirstOrDefault(u=>u.Uid==userId).UName, // Use null-conditional operator
            Buyer =_dbContext.User.FirstOrDefault(u=>u.Uid==order.Order.BuyerId).UName,   // Use null-conditional operator
            OrderStatus = order.Order.OrderStatus,
            OrderId = order.Order.OrderId
        })
        .ToList();
    }
}