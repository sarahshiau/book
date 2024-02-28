using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using yorkshin.Entities;
using yorkshin.ViewModels;
using yorkshin.Repos;

namespace yorkshin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private BookRepository _bookRepository;

    public HomeController(ILogger<HomeController> logger, BookRepository bookRepository)
    {
        _logger = logger;
        _bookRepository = bookRepository;
    }
    public IActionResult LandingPage(string searchWords = "")
    {
        var userId = HttpContext.Session.GetString("Uid");
        ViewBag.UseBsi = string.IsNullOrEmpty(userId);
        var bookList = _bookRepository.GetAllBookList();

        var bookViewModelList = bookList
            .Where(book =>
                searchWords == "" ||
                book.BName.Contains(searchWords) ||
                book.Author.Contains(searchWords) ||
                book.Seller.UName.Contains(searchWords) ||
                book.CategoryJson.Contains(searchWords) ||
                book.BookStatus.Contains(searchWords)
            )
            .Select(book => new BookViewModel
            {
                Bid = book.Bid,
                BName = book.BName,
                Author = book.Author,
                Price = book.Price,
                BookStatus = book.BookStatus,
                CategoryJson = book.CategoryJson,
                ImgUrl = book.ImgUrl,
                Isbn = book.Isbn,
                Description = book.Description,
                Seller = book.Seller?.UName,
                Buyer = book.Order?.Buyer?.UName,
                OrderStatus = book.Order?.OrderStatus,
                OrderId = book.Order?.OrderId ?? 0,
                SearchWords = searchWords,
            })
            .ToList();

        return View(bookViewModelList);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}