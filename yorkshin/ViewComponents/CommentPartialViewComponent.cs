using Microsoft.AspNetCore.Mvc;
using yorkshin.Repos;
using yorkshin.ViewModels;

namespace yorkshin.ViewComponents;

public class CommentPartialViewComponent : ViewComponent
{
    private readonly CommentRepository _commentRepository;

    public CommentPartialViewComponent(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("_CommentPartial",GetCommentList());
    }
    public List<CommentListViewModel> GetCommentList()
    {
        /*Get userId*/
        // 取得目前登入使用者的唯一識別代碼 (UserId)
        /*string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);*/
        /*int userId = (int)HttpContext.Session.GetInt32("Uid");*/
        var userId = int.Parse(HttpContext.Session.GetString( key: "Uid") ?? string.Empty);
        return _commentRepository.GetCommentsWithDetails(userId);
    }
}