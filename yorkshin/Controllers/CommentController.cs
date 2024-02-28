using Microsoft.AspNetCore.Mvc;
using yorkshin.Entities;
using yorkshin.Repos;
using yorkshin.ViewModels;

namespace yorkshin.Controllers;

public class CommentController: Controller
{
    private readonly CommentRepository _commentRepository;
    
    public CommentController(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public List<CommentListViewModel> GetCommentList()
    {
        /*Get userId*/
        // 取得目前登入使用者的唯一識別代碼 (UserId)
        var userId = int.Parse(HttpContext.Session.GetString( key: "Uid")!);
        /*var userId = 1;*/
        return _commentRepository.GetCommentsWithDetails(userId);
    }
    public IActionResult CommentPage()
    {
        var comments = _commentRepository.GetCommentsWithDetails(2);
        return View(comments);
        /*return View("CommentPage", GetCommentList());*/
    }
    public IActionResult EditComment(Comment comment)
    {
        comment.CommentDate = DateTime.Now;
        var result = _commentRepository.EditComment(comment);
        Console.Write(comment.BuyerReview);
        return result ? Redirect("/Book/OrderRecordPage") : RedirectToAction("OrderRecordPage", "Book");
        /*return View(editComment);*/
    }
}

