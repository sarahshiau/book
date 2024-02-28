using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using yorkshin.Entities;
using yorkshin.Repos;
using yorkshin.ViewModels;

namespace yorkshin.Controllers;

public class ClassificationController : Controller
{
    private readonly ClassifyRepository _classifyRepository;
    public ClassificationController(ClassifyRepository classifyRepository)
    {
        _classifyRepository = classifyRepository;
    }
    public IActionResult ClassifyByManager()
    {
        return View();
    }
    public IActionResult ClassifyByUser()
    {
        return View();
    }
    public IActionResult DepartmentClassify()
    {
        return View(SelectAll("系所"));
    }
    public IActionResult CourseClassify()
    {
        return View(SelectAll("課程"));
    }
    public IActionResult BookClassify()
    {
        return View(SelectAll("書籍狀況"));
    }
    public IActionResult ProfessionClassify()
    {
        return View(SelectAll("專業領域"));
    }
    public IActionResult EditClassify()
    {
        
        return View(SelectAll("系所"));
    }

    public IActionResult EditCourse()
    {
        return View(SelectAll("課程"));
    }

    public IActionResult EditBook()
    {
        return View(SelectAll("書籍狀況"));
    }
    public IActionResult EditProfession()
    {
        return View(SelectAll("專業領域"));
    }
    [HttpPost]
    public IActionResult AddCategory(BookCategory Cid)
    {
        try
        {
            // var result = _classifyRepository.AddCategory(cidCategory);
            // if (!string.IsNullOrEmpty(secondary))
            // {
                // _classifyRepository.AddCategory(Cid);
                Cid.Primary = "系所";
                var result = _classifyRepository.AddCategory(Cid);
                return RedirectToAction("EditClassify", "Classification");
            // }
            // else
            // {
            //     TempData["ErrorMessage"] = "分類新增失敗";
            //     return NoContent();
            // }
            
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "發生未預期的錯誤，請稍後再試";
            return NoContent();
        }
        
    }
    public IActionResult AddCategory2(BookCategory Cid)
    {
        try
        {
            Cid.Primary = "課程";
            var result = _classifyRepository.AddCategory(Cid);
            return RedirectToAction("EditCourse", "Classification");
            
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "發生未預期的錯誤，請稍後再試";
            return NoContent();
        }
        
    }
    public IActionResult AddCategory3(BookCategory Cid)
    {
        try
        {
            Cid.Primary = "書籍狀況";
            var result = _classifyRepository.AddCategory(Cid);
            return RedirectToAction("EditBook", "Classification");
            
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "發生未預期的錯誤，請稍後再試";
            return NoContent();
        }
        
    }
    public IActionResult AddCategory4(BookCategory Cid)
    {
        try
        {
            Cid.Primary = "專業領域";
            var result = _classifyRepository.AddCategory(Cid);
            return RedirectToAction("EditProfession", "Classification");
            
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "發生未預期的錯誤，請稍後再試";
            return NoContent();
        }
        
    }
    // [HttpPost("DeleteCategory")]
    // public IActionResult DeleteCategory(int Cid)
    // {
    //     _classifyRepository.DeleteCategory(Cid);
    //     return RedirectToAction("EditClassify", "Classification");
    // }
    public async Task<bool> DeleteCategory(int CId)
    {
        return await _classifyRepository.DeleteCategory(CId);
    }
    public List<ClassifyViewModel> SelectAll(string query)
    {
        var bookCategories = _classifyRepository.SelectAll(query);
        // var categories = _dbContext.BookCategory.ToList();
        var classifyViewModels = new List<ClassifyViewModel>();
        // Console.WriteLine(categories);
        foreach (var category in bookCategories)
        {
            var classifyViewModel = new ClassifyViewModel()
            {
                CId = category.Cid,
                Primary = category.Primary,
                Secondary = category.Secondary
            };
            classifyViewModels.Add(classifyViewModel);
        }

        return classifyViewModels;
        // return categories;
    }
}