namespace yorkshin.Entities;

public class Order
{
    public int OrderId { get; set; }
    
    public required int BookId { get; set; }
    
    public required int BuyerId { get; set; }
    
    public required int SellerId { get; set; }
    
    public required string? OrderStatus { get; set; }
    
    public required DateTime OrderDate { get; set; }
    
    public required DateTime FinishDate { get; set; }
    
    public required int Price { get; set; }
    
    // 導覽屬性，表示 Order 參考的 Book 實體
    public  Book Book { get; set; }

    // 導覽屬性，表示 Order 參考的 Buyer 實體
    public  User Buyer { get; set; }

    // 導覽屬性，表示 Order 參考的 Seller 實體
    public  User Seller { get; set; }
    
   
}