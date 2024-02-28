using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using yorkshin.Entities;
using Microsoft.EntityFrameworkCore;
using yorkshin.ViewComponents;
using yorkshin.ViewModels;

namespace yorkshin.Repos;

public class OrderRepository
{
    private readonly YorkshinDbContext _dbContext;
    private readonly ILogger<OrderRepository> _logger;

    public OrderRepository(YorkshinDbContext dbContext, ILogger<OrderRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    
    //按OrderPage(PlaceOrder)下單button
    public bool AddOrder(int bookID, int buyerID)
    {
        Console.WriteLine(bookID);
        Console.WriteLine(buyerID);
        //var existingOrder = _dbContext.Order.FirstOrDefault(o =>o.BookId == bookID);
        var findBook = _dbContext.Book.FirstOrDefault(b => b.Bid == bookID);
        //Console.WriteLine("--------------------------"+existingOrder.SellerId);
        try
        {
            var New_Order = new Order
            {
                BookId = bookID,
                BuyerId = buyerID,
                SellerId = findBook.SellerId,
                OrderStatus = "待接受",
                OrderDate = DateTime.Now,
                FinishDate = DateTime.Now,
                Price = findBook.Price,
                Book = findBook,
                Buyer = null,
                Seller = findBook.Seller,
            };
            
            _dbContext.Order.Add(New_Order);
            _dbContext.SaveChanges(); 
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"OrderRepository Register Error: {e.Message}");
            if (e.InnerException != null)
            {
                _logger.LogError($"Inner Exception: {e.InnerException.Message}");
            }
            return false;
        }
    }
    
    //no use
    public bool DeleteOrder(int OrderID)
    {
        //var order = _dbContext.Order.Find(OrderID);
        var order = _dbContext.Order.FirstOrDefault(o => o.OrderId == OrderID);
        if (order == null)
        {
            return false;
        }

        _dbContext.Order.Remove(order);
        _dbContext.SaveChanges();
        return true;
    }
    
    
    //WaitingAcceptList按接受button
    public bool AcceptOrder(int bookID)
    {
        try
        {
            var order = _dbContext.Order
                .Where(o => o.BookId == bookID && (o.OrderStatus == "已拒絕" || o.OrderStatus == "待接受"))
                .OrderBy(o => o.OrderId) // Change the OrderId to the appropriate property that defines the order
                .FirstOrDefault();

            if (order != null && order.OrderStatus == "已拒絕")
            {
                // Skip the current order and move to the next one
                order = _dbContext.Order
                    .Where(o => o.OrderId > order.OrderId && o.OrderStatus != "已拒絕")
                    .OrderBy(o => o.OrderId)
                    .FirstOrDefault();
            }
        
            if (order != null && (order.OrderStatus == "待接受" || order.OrderStatus == "已拒絕"))
            {
                order.OrderStatus = "已保留";
                order.OrderDate = DateTime.Now;
                _dbContext.SaveChanges();
                return true;
            /*var order = _dbContext.Order.FirstOrDefault(o => o.BookId == bookID);
            if (order != null && (order.OrderStatus=="待接受" || order.OrderStatus=="已拒絕"))
            {
                order.OrderStatus ="已保留";
                order.OrderDate = DateTime.Now;
                _dbContext.SaveChanges();
                return true;*/
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            _logger.LogError($"OrderRepository Register Error: {e.Message}");
            return false;
        }
    }
    
    //WaitingAcceptList按拒絕button
    public bool RejectOrder(int bookID)
    {
        try
        {
            Console.WriteLine("------------------------"+bookID);
            _logger.LogInformation($"RejectOrder method called with bookID: {bookID}");
            var order = _dbContext.Order.FirstOrDefault(o => o.BookId == bookID);
            if (order != null)
            {
                _logger.LogInformation($"Found order with ID: {bookID}. Order status: {order.OrderStatus}");
                if (order.OrderStatus == "待接受")//改待接受
                {
                    _logger.LogInformation($" Proceeding to reject order...");
                    order.OrderStatus = "已拒絕";
                    order.OrderDate = DateTime.Now;
                    _dbContext.SaveChanges();
                    _logger.LogInformation($"Order {bookID} has been rejected.");
                    return true;
                }
                else
                {
                    _logger.LogInformation($"Order {bookID} status is not '待接受'. Current status: {order.OrderStatus}");
                }
            }
            else
            {
                _logger.LogInformation($"No order found with ID: {bookID}");
            }
            return false;
        }
        catch (Exception e)
        {
            _logger.LogError($"Error rejecting order with ID {bookID}: {e.Message}");
            return false;
        }
    }
    
    //SoldedList按已完成button
    public bool FinishOrder(int orderID)
    {
        try
        {
            Console.WriteLine(orderID);
            var order = _dbContext.Order.FirstOrDefault(o => o.OrderId == orderID);
            if (order != null && order.OrderStatus=="已保留")
            {
                order.OrderStatus ="已售出";
                order.FinishDate = DateTime.Now;
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            _logger.LogError($"OrderRepository Register Error: {e.Message}");
            return false;
        }
    }

    /*public bool PlaceOrder(int orderId)
    {
        try
        {
            var order =GetOrderById(orderId);
            Console.WriteLine(orderId);
            if (order != null && order.OrderStatus == "待接受")
            {
                order.OrderStatus = "已保留";
                _dbContext.SaveChanges();
            }
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"OrderRepository Insert Error: {e.Message}");
            return false;
        }
    }*/

    public List<Order> CheckOrder(int buyerID)
    {
        var OrderList = _dbContext.Order.Where(o => o.BuyerId == buyerID).ToList();
        return OrderList;
    }
    
    public Order GetOrderById(int orderID)
    {
        // 透過訂單 ID 從資料庫中獲取特定訂單的資訊
        var order = _dbContext.Order.FirstOrDefault(o => o.OrderId == orderID);

        return order;
    }

    public List<(Order Order, Book Book)> OrderPage(int orderID)
    {
        var order = _dbContext.Order
            .Where(o => o.OrderId == orderID)
            .Include(o => o.Book)
            .Select(o => new { Order = o, Book = o.Book })
            .ToList()
            .Select(x => (x.Order, x.Book))
            .OrderByDescending(b => b.Order.OrderId) // 這裡以書籍的 ID 為例，你可以根據實際情況選擇其他屬性
            .ToList();
        return order;
    }
    //waitingAcceptOrder
    public List<(Order Order, Book Book)> GetWaitingOrders(int userId)
    {
        Console.WriteLine(userId);
        var waitingOrders = _dbContext.Order
            .Where(o => o.OrderStatus == "待接受" && o.SellerId==userId)
            .Include(o => o.Book)
            .Select(o => new { Order = o, Book = o.Book })
            .ToList()
            .Select(x => (x.Order, x.Book))
            .OrderByDescending(b => b.Order.OrderId) // 這裡以書籍的 ID 為例，你可以根據實際情況選擇其他屬性
            .ToList();
        
        return waitingOrders;

    }
    
    //AcceptedOrder
    public List<(Order Order, Book Book)> GetAcceptedOrders(int userId)
    {
        var acceptedOrders = _dbContext.Order
            .Where(o => o.OrderStatus == "已保留" && o.SellerId==userId)
            .Include(o => o.Book)
            .Select(o => new { Order = o, Book = o.Book })
            .ToList()
            .Select(x => (x.Order, x.Book))
            .OrderByDescending(b => b.Order.OrderId) // 這裡以書籍的 ID 為例，你可以根據實際情況選擇其他屬性
            .ToList();

        return acceptedOrders;
    }
    
    //SoldedOrder
    public List<(Order Order, Book Book)> GetSoldedOrders(int userId)
    {
        var soldedOrders = _dbContext.Order
            .Where(o => o.OrderStatus == "已售出" && o.SellerId==userId)
            .Include(o => o.Book)
            .Select(o => new { Order = o, Book = o.Book })
            .ToList()
            .Select(x => (x.Order, x.Book))
            .OrderByDescending(b => b.Order.OrderId) // 這裡以書籍的 ID 為例，你可以根據實際情況選擇其他屬性
            .ToList();

        return soldedOrders;
    }
    
    //FinishOrder
    public List<(Order Order, Book Book)> GetFinishedOrders(int buyerId)
    {
        var finishedOrders = _dbContext.Order
            .Where(o => o.OrderStatus == "已售出" && o.BuyerId==buyerId)//按已完成button
            .Include(o => o.Book)
            .Select(o => new { Order = o, Book = o.Book })
            .ToList()
            .Select(x => (x.Order, x.Book))
            .OrderByDescending(b => b.Order.OrderId) // 這裡以書籍的 ID 為例，你可以根據實際情況選擇其他屬性
            
            .ToList();

        return finishedOrders;
    }
    
    //OrderList
    public List<(Order Order, Book Book)> GetOrderList(int buyerID)
    {
        var orderList = _dbContext.Order
            .Where(o => o.BuyerId == buyerID)
            .Where(o=>o.OrderStatus!="已售出")
            .Include(o => o.Book)
            .Select(o => new { Order = o, Book = o.Book })
            .ToList()
            .Select(x => (x.Order, x.Book))
            .OrderByDescending(b => b.Order.OrderId) // 這裡以書籍的 ID 為例，你可以根據實際情況選擇其他屬性
            .ToList();
        return orderList;

    }

    
}