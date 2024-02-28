using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using yorkshin.Repos;
using yorkshin.ViewModels;

namespace yorkshin.ViewComponents;

public class BookUpdateModalViewComponent : ViewComponent
{
    private readonly BookRepository _bookRepository;
    private readonly ClassifyRepository _classifyRepository;

    public BookUpdateModalViewComponent(BookRepository bookRepository, ClassifyRepository classifyRepository)
    {
        _bookRepository = bookRepository;
        _classifyRepository = classifyRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(int bookId)
    {
        var updateBook = await GetUpdateBook(bookId);
        var departmentArray = await _classifyRepository.GetAllCategory("系所");
        var courseArray = await _classifyRepository.GetAllCategory("課程");
        var statusArray = await _classifyRepository.GetAllCategory("書籍狀況");
        // var professional = await _classifyRepository.GetAllCategory("專業領域");

        // 將陣列存入 ViewBag
        ViewBag.DepartmentArray = departmentArray;
        ViewBag.CourseArray = courseArray;
        ViewBag.statusArray = statusArray;
        // ViewBag.selectedDep = selectedDep;
        // ViewBag.selectedCourse = seletedCourse;
        return View("_BookUpdateModal", updateBook);
    }

    public async Task<BookViewModel> GetUpdateBook(int bookId)
    {
        var selectedDep = new List<string>();
        var selectedCourse = new List<string>();
        var updateBook = await _bookRepository.GetUpdateBook(bookId);
        var deserializeObject =
            JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(updateBook.CategoryJson);
        if (deserializeObject != null)
        {
            foreach (var item in deserializeObject)
            {
                if (item.ContainsKey("系所"))
                {
                    selectedDep.Add(item["系所"]);
                }
                else if (item.ContainsKey("課程"))
                {
                    selectedCourse.Add(item["課程"]);
                }
            }
        }

        return new BookViewModel
        {
            Bid = updateBook.Bid,
            Author = updateBook.Author,
            BName = updateBook.BName,
            BookStatus = updateBook.BookStatus,
            Isbn = updateBook.Isbn,
            Price = updateBook.Price,
            Description = updateBook.Description,
            selectedCourse = selectedCourse,
            selectedDep = selectedDep
        };
    }

// public BookViewModel GetUpdateBook(int bookId)
// {
//    var updateBook = _bookRepository.GetUpdateBook(bookId);
//    // lost classification
//    // return bookViewModel.Price;
//    return new BookViewModel()
//    {
//       Author = updateBook.Author,
//       BName = updateBook.BName,
//       BookStatus = updateBook.BookStatus,
//       Isbn = updateBook.Isbn,
//       Price = updateBook.Price
//    };
// }
}