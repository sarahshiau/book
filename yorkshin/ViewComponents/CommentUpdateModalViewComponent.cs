using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using yorkshin.Entities;
using yorkshin.Repos;
using yorkshin.ViewModels;
namespace yorkshin.ViewComponents;

public class CommentUpdateModalViewComponent:ViewComponent
{
    private readonly CommentRepository _commentRepository;
    public CommentUpdateModalViewComponent(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task<IViewComponentResult> InvokeAsync(int orderId)
    {
        var checkComment = await _commentRepository.CheckHaveCommentId(orderId);
        var orderList = await _commentRepository.GetOrderList(orderId);

        if (checkComment == null)
        {
            return View("_CommentUpdateModal", new CommentListViewModel
            {
                CommentId = null,
                BuyerReview = null,
                CommentDate = null,
                Ranking = null,
                BuyerUname = orderList?.Buyer?.UName,
                SellerUname = orderList?.Seller?.UName,
                BookName = orderList?.Book?.BName,
                BookAuthor = orderList?.Book?.Author,
                OrderId = orderId
            });
        }

        return View("_CommentUpdateModal", new CommentListViewModel
        {
            CommentId = checkComment.CommentId,
            BuyerReview = checkComment.BuyerReview,
            CommentDate = checkComment.CommentDate,
            Ranking = checkComment.Ranking,
            BuyerUname = checkComment.Order?.Buyer?.UName,
            SellerUname = checkComment.Order?.Seller?.UName,
            BookName = checkComment.Order?.Book?.BName,
            BookAuthor = checkComment.Order?.Book?.Author,
            OrderId = checkComment.OrderId
        });
    }

    public async Task<CommentListViewModel> GetTheComment(int commentId)
    {
        /*Get userId*/
        // 取得目前登入使用者的唯一識別代碼 (UserId)
        /*string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);*/
        var updateComment = await _commentRepository.GetUpdateComment(commentId);
        // lost classification
        // return bookViewModel.Price;
        // ViewBag.books = new (updateBook, "BookStatus");
        
        return new CommentListViewModel()
        {
            CommentId = updateComment?.CommentId,
            BuyerReview = updateComment?.BuyerReview,
            CommentDate = updateComment?.CommentDate,
            Ranking = updateComment?.Ranking,
            BuyerUname = updateComment?.Order.Buyer.UName, // 取得買家的 Uname
            SellerUname = updateComment?.Order.Seller.UName, // 取得賣家的 Uname
            BookName = updateComment?.Order.Book.BName, // 取得書籍的書名
            BookAuthor = updateComment?.Order.Book.Author, // 取得書籍的書名
            OrderId = updateComment?.OrderId
        };
    }
}