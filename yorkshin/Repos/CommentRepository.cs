using Microsoft.EntityFrameworkCore;
using yorkshin.Entities;
using yorkshin.ViewModels;

namespace yorkshin.Repos;

public class CommentRepository
{
    private readonly YorkshinDbContext _dbContext;
    private readonly ILogger<CommentRepository> _logger;

    public CommentRepository(YorkshinDbContext dbContext, ILogger<CommentRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Comment?> CheckHaveCommentId(int orderId)
    {
        var comment = _dbContext.Comment
            .FirstOrDefault(c => c.OrderId == orderId);

        return comment;
    }

    public async Task<Order?> GetOrderList(int orderId)
    {
        // return _dbContext.Book.SingleOrDefault(b => b.Bid == bookId)!;
        return await _dbContext.Order.SingleOrDefaultAsync(c => c.OrderId == orderId)!;
    }

    public List<CommentListViewModel> GetCommentsWithDetails(int userId)
    {
        // 使用 LINQ 查詢資料庫，並將結果投影到 CommentViewModel
        var commentsWithDetails = _dbContext.Comment
            .Include(c => c.Order)
            .ThenInclude(o => o.Seller)
            .Include(c => c.Order.Book)
            .Where(c => c.Order.Seller.Uid == userId)
            .OrderByDescending(c=>c.CommentId)
            .Select(c => new CommentListViewModel
            {
                CommentId = c.CommentId,
                BuyerReview = c.BuyerReview,
                CommentDate = c.CommentDate,
                Ranking = c.Ranking,
                BuyerUname = c.Order.Buyer.UName,
                SellerUname = c.Order.Seller.UName,
                BookName = c.Order.Book.BName,
                BookAuthor = c.Order.Book.Author,
                ImgUrl = c.Order.Book.ImgUrl, // 新增這一行，取得書籍的 ImgUrl
                OrderId = c.OrderId
            })
            .ToList();

        return commentsWithDetails;
    }
    public List<CommentListViewModel> GetCommentsforBuyer(int userId)
    {
        // 使用 LINQ 查詢資料庫，並將結果投影到 CommentViewModel
        var commentsWithDetails = _dbContext.Comment
            .Include(c => c.Order)
            .ThenInclude(o => o.Buyer)
            .Include(c => c.Order.Book)
            .Where(c => c.Order.Buyer.Uid == userId)
            .OrderByDescending(c=>c.CommentId)
            .Select(c => new CommentListViewModel
            {
                CommentId = c.CommentId,
                BuyerReview = c.BuyerReview,
                CommentDate = c.CommentDate,
                Ranking = c.Ranking,
                BuyerUname = c.Order.Buyer.UName,
                SellerUname = c.Order.Seller.UName,
                BookName = c.Order.Book.BName,
                BookAuthor = c.Order.Book.Author,
                ImgUrl = c.Order.Book.ImgUrl, // 新增這一行，取得書籍的 ImgUrl
                OrderId = c.OrderId
            })
            .ToList();

        return commentsWithDetails;
    }
    /*Edit Comment*/
    public bool EditComment(Comment updateComment)
    {
        try
        {
            _dbContext.Comment.Update(updateComment);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"CommentRepository Add Comment Error: {e.Message}");
            return false;
        }
    }
    public async Task<Comment?> GetUpdateComment(int commentId)
    {
        // return _dbContext.Book.SingleOrDefault(b => b.Bid == bookId)!;
        return await _dbContext.Comment.SingleOrDefaultAsync(c => c.CommentId == commentId)!;
    }
}


