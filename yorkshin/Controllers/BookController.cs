using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Newtonsoft.Json;
using yorkshin.Entities;
using yorkshin.Repos;
using yorkshin.ViewModels;

namespace yorkshin.Controllers;

public class BookController : Controller
{
    private readonly BookRepository _bookRepository;
    private readonly ClassifyRepository _classifyRepository;

    public BookController(BookRepository bookRepository, 
        ClassifyRepository classifyRepository)
    {
        _bookRepository = bookRepository;
        _classifyRepository = classifyRepository;
    }

    public async Task<IActionResult> BookListPage()
    {
        var departmentArray = await _classifyRepository.GetAllCategory("系所");
        var courseArray = await _classifyRepository.GetAllCategory("課程");
        var statusArray = await _classifyRepository.GetAllCategory("書籍狀況");
        // var professional = await _classifyRepository.GetAllCategory("專業領域");

        // 將陣列存入 ViewBag
        ViewBag.DepartmentArray = departmentArray;
        ViewBag.CourseArray = courseArray;
        ViewBag.statusArray = statusArray;
        return View("BookListPage");
    }

    public IActionResult OrderRecordPage()
    {
        return View("OrderRecordPage");
    }

    private string? fileName = "";

    public async Task<IActionResult> AddBook(AddBookRequest bookRequest, IFormFile Img)
    {
        UploadImg(Img);
        var insertBook = new Book
        {
            BName = bookRequest.Bname,
            Author = bookRequest.Author,
            Isbn = bookRequest.Isbn,
            Price = bookRequest.Price,
            BookStatus = bookRequest.BookStatus,
            ImgUrl = fileName,
            CategoryJson = ConvertToJson(bookRequest.DepartmentList, bookRequest.CourseList),
            Description = bookRequest.Description,
            SellerId = int.Parse(HttpContext.Session.GetString("Uid")!)
        };
        var result = await _bookRepository.AddBook(insertBook);
        return result ? RedirectToAction("BookListPage", "Book") : Redirect("/");
    }
    // public async Task<IActionResult> AddBook(Book book, IFormFile Img)
    // {
    //     var userId = int.Parse(HttpContext.Session.GetString("Uid")!);
    //
    //     // edit book attribute manually
    //     book.Description = "test";
    //     book.SellerId = userId;
    //     UploadImg(Img);
    //     book.ImgUrl = fileName;
    //     book.CategoryJson = "";
    //     var result = await _bookRepository.AddBook(book);
    //     return result ? RedirectToAction("BookListPage", "Book") : Redirect("/");
    // }

    public IActionResult UploadImg(IFormFile formFile)
    {
        if (formFile != null && formFile.Length > 0)
        {
            fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            var filePath = Path.Combine(@"wwwroot/images/Upload", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            return Ok();
        }

        return BadRequest();
    }

    public async Task<bool> DeleteBook(int bookId)
    {
        return await _bookRepository.DeleteBook(bookId);
    }

    public async Task<IActionResult> GetBookUpdateViewComponent(int bookId)
    {
        return ViewComponent("BookUpdateModal", new { bookId = bookId });
    }

    public async Task<IActionResult> UpdateBook(AddBookRequest bookRequest, IFormFile Img)
    {
        if (Img != null && Img.Length > 0)
        {
            UploadImg(Img);
        }
        else
        {
            fileName = "";
        }

        var resultDep = "";
        var resultCourse = "";
        var selectedDep = new List<string>();
        var selectedCourse = new List<string>();
        if (bookRequest.CourseList == null)
        {
            var updateBook = await _bookRepository.GetUpdateBook(bookRequest.Bid);
            var deserializeObject =
                JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(updateBook.CategoryJson);
            if (deserializeObject != null)
            {
                foreach (var item in deserializeObject)
                {
                    if (item.ContainsKey("課程"))
                    {
                        selectedCourse.Add(item["課程"]);
                    }
                }
            }

            resultCourse = string.Join(",", selectedCourse);
        }
        else
        {
            resultCourse = bookRequest.CourseList;
        }

        if (bookRequest.DepartmentList == null)
        {
            var updateBook = await _bookRepository.GetUpdateBook(bookRequest.Bid);
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
                }
            }

            resultDep = string.Join(",", selectedDep);
        }
        else
        {
            resultDep = bookRequest.DepartmentList;
        }

        var insertBook = new Book
        {
            BName = bookRequest.Bname,
            Author = bookRequest.Author,
            Isbn = bookRequest.Isbn,
            Price = bookRequest.Price,
            BookStatus = bookRequest.BookStatus,
            ImgUrl = fileName,
            CategoryJson = ConvertToJson(resultDep, resultCourse),
            Description = bookRequest.Description,
        };
        var result = await _bookRepository.UpdateBook(bookRequest.Bid, insertBook);
        return result ? RedirectToAction("BookListPage", "Book") : Redirect("/");
    }

    // public List<BookViewModel> GetBookList()
    // {
    //     var bookList = _bookRepository.GetBookList();
    //     return bookList.Select(book => new BookViewModel()
    //         {
    //             Bid = book.Bid,
    //             Author = book.Author,
    //             BName = book.BName,
    //             BookStatus = book.BookStatus,
    //             Classification = "test",
    //             ImgUrl = book.ImgUrl,
    //             Price = book.Price,
    //             Seller = book.SellerId
    //         })
    //         .ToList();
    // }

    public string ConvertToJson(string department, string course)
    {
        var result = new List<Dictionary<string, string>>();
        if (department != null)
        {
            var departmentArr = department.Split(",");
            foreach (var item in departmentArr)
            {
                var dictionary = new Dictionary<string, string>()
                {
                    { "系所", item }
                };
                result.Add(dictionary);
            }
        }
        else
        {
            var dictionary = new Dictionary<string, string>()
            {
                { "系所", "其他" }
            };
            result.Add(dictionary);
        }

        if (course != null)
        {
            var courseArr = course.Split(",");
            foreach (var item in courseArr)
            {
                var dictionary = new Dictionary<string, string>()
                {
                    { "課程", item }
                };
                result.Add(dictionary);
            }
        }
        else
        {
            var dictionary = new Dictionary<string, string>()
            {
                { "課程", "其他" }
            };
            result.Add(dictionary);
        }

        return JsonConvert.SerializeObject(result);
    }
}