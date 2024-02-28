using System.ComponentModel.DataAnnotations;
namespace yorkshin.Entities;

public class Comment
{
    [Key] public int CommentId { get; set; }
    public required string BuyerReview { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public required DateTime CommentDate { get; set; }

    public required int Ranking { get; set; }

    // foreign key for User
    public required int OrderId { get; set; }
    
    // 導覽屬性，表示 Comment 參考的 Order 實體
    public required Order Order { get; set; }
}
