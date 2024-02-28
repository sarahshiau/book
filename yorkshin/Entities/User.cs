using System.ComponentModel.DataAnnotations;

namespace yorkshin.Entities;

public class User
{
    [Key] public int Uid { get; set; }
    public required string Account { get; set; }
    public required string Pwd { get; set; }

    public required string? UName { get; set; }

    public required string Identity { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; }
    
    // 導覽屬性，表示 User 所有賣出的訂單
    public List<Order> SoldOrders { get; set; }
    
    public ICollection<Book> Books { get; set; }
}