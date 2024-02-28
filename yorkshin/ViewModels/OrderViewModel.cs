using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using yorkshin.Entities;

namespace yorkshin.ViewModels;

public class OrderViewModel
{
    public class Order
    {
        public int OrderId { get; set; }
    
        public int BookId { get; set; }
    
        public int BuyerId { get; set; }
    
        public int SellerId { get; set; }
    
        public string OrderStatus { get; set; }
    
        public DateTime OrderDate { get; set; }
    
        public DateTime FinishDate { get; set; }
    
        public int Price { get; set; }

        public Book Book { get; set; }
        public User Buyer{get; set; }
        public User Seller { get; set; }


    }
    /*public class User
    {
        public int Uid { get; set; }

        public ICollection<Order> OrdersAsBuyer { get; set; }
        public ICollection<Order> OrdersAsSeller { get; set; }
    }

    public class Book
    {
        public int bookId { get; set; }

        public ICollection<Order> Orders { get; set; }
    }

    protected  void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Book)
            .WithMany(b => b.Orders)
            .HasForeignKey(o => o.BookId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Buyer)
            .WithMany(u => u.OrdersAsBuyer)
            .HasForeignKey(o => o.BuyerId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Seller)
            .WithMany(u => u.OrdersAsSeller)
            .HasForeignKey(o => o.SellerId);
    }*/
}