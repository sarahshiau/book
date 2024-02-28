using Microsoft.AspNetCore.Mvc;
using yorkshin.Repos;
using yorkshin.ViewModels;

namespace yorkshin.ViewComponents;
public class CommentPartialforBuyerViewComponent:  ViewComponent
{
    private readonly CommentRepository _commentRepository;

    public CommentPartialforBuyerViewComponent(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("_CommentPartialforBuyer",GetCommentList());
    }
    public List<CommentListViewModel> GetCommentList()
    {
        /*Get userId*/
        // 取得目前登入使用者的唯一識別代碼 (UserId)
        /*string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);*/
        /*int userId = (int)HttpContext.Session.GetInt32("Uid");*/
        var userId = int.Parse(HttpContext.Session.GetString( key: "Uid") ?? string.Empty);
        return _commentRepository.GetCommentsforBuyer(userId);
    }
}