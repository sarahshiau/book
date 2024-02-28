namespace yorkshin.ViewModels;

public class CommentListViewModel 
{
    public int? CommentId { get; set; }
    public string? BuyerReview { get; init; } = "";
    public DateTime? CommentDate { get; init; }
    public int? Ranking { get; init; }
    /*public int OrderId { get; set; }*/
    
    public string? BuyerUname { get; init; }
    public string? SellerUname { get; set; }
    public string? BookName { get; init; }
    
    public string? BookAuthor { get; init; }
    
    public string ImgUrl { get; set; }

    public int? OrderId { get; init; }
}