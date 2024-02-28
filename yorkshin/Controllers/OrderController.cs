using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using yorkshin.Repos;
using yorkshin.Entities;


namespace yorkshin.Controllers;
//[Route("api/order")]


public class OrderController : Controller
{
    private readonly OrderRepository _orderRepository;
    private readonly BookRepository _bookRepository;


    public OrderController(OrderRepository orderRepository,YorkshinDbContext dbContext, BookRepository bookRepository)
    {
        _orderRepository = orderRepository;
        _bookRepository = bookRepository;
    }
   
    public IActionResult OrderPage(int bookId)
    {
        var bookInfo = _bookRepository.OrderPageGetBook(bookId);
        Console.WriteLine("do dynamic");
        Console.WriteLine(bookId);
        int buyerId = int.Parse(HttpContext.Session.GetString("Uid"));
        HttpContext.Session.SetInt32("BuyerId", buyerId);
        ViewBag.BuyerId = HttpContext.Session.GetInt32("BuyerId");
        //return RedirectToAction("OrderPage", bookInfo);
        var selectedDep = new List<string>();
        var selectedCourse = new List<string>();
        var deserializeObject = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(bookInfo.CategoryJson);
        if (deserializeObject!=null)
        {
            foreach (var item in deserializeObject)
            {
                if (item.ContainsKey("系所"))
                {
                    selectedDep.Add(item["系所"]);
                }

                if (item.ContainsKey("課程"))
                {
                    selectedCourse.Add(item["課程"]);
                }
            }
        }
        bookInfo.selectedCourse = selectedCourse;
        bookInfo.selectedDep = selectedDep;
        return View("OrderPage", bookInfo);
    }
    
    
    
    [HttpPost("/AddOrder")]
    public IActionResult AddOrder(int bookID, int buyerID)
    {
        
        try
        {
            Console.WriteLine("BId:"+bookID);
            Console.WriteLine("buyerId"+buyerID);
            var result = _orderRepository.AddOrder(bookID,buyerID);
            return  new JsonResult(new { message = "success" })
            {
                StatusCode = 200
            };

        }
        catch (Exception e)
        {
            return  new JsonResult(new { message = "fail" })
            {
                StatusCode = 200
            };
        }
        
    }
    
    [HttpDelete("/DeleteOrder")]
    public IActionResult DeleteOrder(int OrderID)
    {
        _orderRepository.DeleteOrder(OrderID);
        return Ok("Order Delete Successfully");
    }

    [HttpGet("CheckOrder/{buyerID}")]
    public IActionResult CheckOrder(int buyerID)
    {
        _orderRepository.CheckOrder(buyerID);
        return Ok("OK");
    }

    [HttpPost("/AcceptOrder")]
    public IActionResult AcceptOrder(int bookID)
    {
        bool isAccepted = _orderRepository.AcceptOrder(bookID);
        if (isAccepted)
        {
            return RedirectToAction("BookListPage", "Book");
        }
        else
        {
            // Handle failure scenario, such as displaying an error message
            return View("Error");
        }
    }

    [HttpPost("/RejectOrder")]
    public IActionResult RejectOrder(int bookId)
    {
        if (bookId <= 0)
        {
            // 錯誤的 BookID，進行錯誤處理或返回錯誤訊息
            return BadRequest("無效的 BookId");
        }

        _orderRepository.RejectOrder(bookId);
        //return Ok("reject succeed");;
        return RedirectToAction("BookListPage", "Book");

    }

    [HttpPost("/FinishOrder")]
    public IActionResult FinishOrder(int orderID)
    {
        _orderRepository.FinishOrder(orderID);
        return RedirectToAction("BookListPage", "Book");
    }

    /*[HttpPost("/PlaceOrder")]
    public IActionResult PlaceOrder(int orderId)
    {
        _orderRepository.PlaceOrder(orderId);
        return RedirectToAction("OrderPage");
    }*/
    
}