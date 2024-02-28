using System.ComponentModel.DataAnnotations;

namespace yorkshin.Entities;

public class Book
{
    [Key] public int Bid { get; set; }
    public required string? BName { get; set; }
    public required string? Author { get; set; }
    public required string Isbn { get; set; }
    public required int Price { get; set; }
    public required string? BookStatus { get; set; }
    public required string? ImgUrl { get; set; }
    public required string? CategoryJson { get; set; }
    public required string Description { get; set; }

    // foreign key for User
    public int SellerId { get; set; }

    //public User Buyer { get; set; }
    public User? Seller { get; set; }

    // 導覽屬性，表示 Book 所有的訂單
    public Order? Order { get; set; }
    public ICollection<Order> Orders { get; set; }
}