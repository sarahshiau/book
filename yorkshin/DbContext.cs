using Microsoft.EntityFrameworkCore;
using yorkshin.Entities;
using yorkshin.ViewModels;

namespace yorkshin;

public class YorkshinDbContext : DbContext
{
    public YorkshinDbContext(DbContextOptions<YorkshinDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Book> Book { get; set; }

    public DbSet<BookCategory> BookCategory { get; set; }
    public DbSet<Comment?> Comment { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(user => user.Uid).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(user => user.Account).HasMaxLength(20);
            entity.Property(user => user.Pwd).HasMaxLength(80);
            entity.Property(user => user.UName).HasMaxLength(50);
            entity.Property(user => user.Identity).HasMaxLength(20);
            entity.Property(user => user.Email).HasMaxLength(80);
            entity.Property(user => user.Phone).HasMaxLength(80);
        });
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(book => book.Bid).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(book => book.BName).HasMaxLength(300);
            entity.Property(book => book.Author).HasMaxLength(50);
            entity.Property(book => book.Isbn).HasMaxLength(13);
            entity.Property(book => book.Price).HasColumnType("int");
            entity.Property(book => book.BookStatus).HasMaxLength(50);
            entity.Property(book => book.Description).HasMaxLength(100);
            entity.Property(book => book.ImgUrl).HasMaxLength(300);
            entity.Property(book => book.CategoryJson).HasMaxLength(500);

            // foreign key setting
            // entity.HasOne(b => b.User).WithMany(u => u.Books).IsRequired();
        });
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Seller)
            .WithMany(u => u.Books)
            .HasForeignKey(b => b.SellerId)
            .IsRequired();

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(comment => comment.CommentId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(comment => comment.OrderId).HasColumnType("int");
            entity.Property(comment => comment.BuyerReview).HasMaxLength(100);
            entity.Property(comment => comment.Ranking).HasColumnType("int");
            entity.Property(comment => comment.CommentDate).HasColumnType("datetime");

            // foreign key setting
            //entity.HasOne(b => b.OrderId).HasOne(u => u.Order).IsRequired();
        });
        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.Property(bookCategory => bookCategory.Cid).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(bookCategory => bookCategory.Primary).HasMaxLength(100);
            entity.Property(bookCategory => bookCategory.Secondary).HasMaxLength(100);
        });
        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(order => order.OrderId).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(order => order.BookId).HasColumnType("int");
            entity.Property(order => order.BuyerId).HasColumnType("int");
            entity.Property(order => order.SellerId).HasColumnType("int");
            entity.Property(order => order.OrderStatus).HasMaxLength(100);
            entity.Property(order => order.OrderDate).HasColumnType("datetime");
            entity.Property(order => order.FinishDate).HasColumnType("datetime");
            entity.Property(order => order.Price).HasColumnType("int");
        });
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Book)
            .WithMany(b=>b.Orders)
            .HasForeignKey(o => o.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Buyer)
            .WithMany()
            .HasForeignKey(o => o.BuyerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Seller)
            .WithMany()
            .HasForeignKey(o => o.SellerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}