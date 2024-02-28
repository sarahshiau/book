using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using yorkshin.Entities;
using yorkshin.Repos;
using yorkshin.ViewModels;

namespace yorkshin.ViewComponents;

public class BookListPartialViewComponent : ViewComponent
{
    private readonly BookRepository _bookRepository;

    public BookListPartialViewComponent(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("_BookListPartial", await GetBookList());
    }

    public async Task<List<BookViewModel>> GetBookList()
    {
        var userId = int.Parse(HttpContext.Session.GetString(key: "Uid") ?? string.Empty);
        var bookList = await _bookRepository.GetBookListForSeller(userId);
        // var bookList = await _bookRepository.GetBookList();
        var depList = new List<string>();
        var courseList = new List<string>();
        List<BookViewModel> list = new List<BookViewModel>();
        foreach (var book in bookList)
        {
            var deserializeObject =
                JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(book.CategoryJson);
            if (deserializeObject != null)
            {
                foreach (var item in deserializeObject)
                {
                    if (item.ContainsKey("系所"))
                    {
                        depList.Add(item["系所"]);
                    }
                    else if (item.ContainsKey("課程"))
                    {
                        courseList.Add(item["課程"]);
                    }
                }
            }
            list.Add(new BookViewModel()
            {
                Bid = book.Bid,
                Author = book.Author,
                BName = book.BName,
                BookStatus = book.BookStatus,
                CategoryJson = book.CategoryJson,
                ImgUrl = book.ImgUrl,
                Price = book.Price,
                selectedCourse = courseList,
                selectedDep = depList
            });
            depList = new List<string>();
            courseList = new List<string>();
        }

        return list;
    }
}