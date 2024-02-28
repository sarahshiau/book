using Microsoft.AspNetCore.Mvc;
using yorkshin.Repos;
using yorkshin.ViewModels;
namespace yorkshin.ViewComponents;

public class OrderedListPartialViewComponent: ViewComponent
{
    private readonly OrderRepository _orderRepository;
    private readonly YorkshinDbContext _dbContext;
    public OrderedListPartialViewComponent(OrderRepository orderRepository,YorkshinDbContext dbContext)
    {
        _orderRepository = orderRepository;
        _dbContext = dbContext;
    }
    //public async Task<IViewComponentResult> InvokeAsync(int buyerID)
    public async Task<IViewComponentResult> InvokeAsync()
    {
        //var buyerID = 2 test   
        var userId = int.Parse(HttpContext.Session.GetString("Uid"));
        return View("_OrderedListPartial",GetBookList(userId));
    }
    
    public List<BookViewModel> GetBookList(int buyerID)
    {
        //var buyerID=User.FindFirstValue(ClaimTypes.NameIdentifier)
        var bookList = _orderRepository.GetOrderList(buyerID);
        return bookList
        .Where(order => order.Book != null && order.Order != null) // Check for null
        .Select(order => new BookViewModel()
        {
            Author = order.Book?.Author,
            BName = order.Book?.BName,
            BookStatus = order.Book?.BookStatus,
            CategoryJson = order.Book?.CategoryJson,
            ImgUrl = order.Book?.ImgUrl,
            Price = order.Order?.Price ?? 0, // Default value if Price is null
            Seller = _dbContext.User.FirstOrDefault(u=>u.Uid==order.Order.SellerId).UName,
            OrderStatus = order.Order?.OrderStatus,
            OrderId = order.Order?.OrderId ?? 0, // Default value if OrderId is null
        })
        .ToList();
    }
}