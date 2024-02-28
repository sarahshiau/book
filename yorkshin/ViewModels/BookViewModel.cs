using Microsoft.AspNetCore.Mvc.Rendering;
using yorkshin.Entities;

namespace yorkshin.ViewModels;

// public class BookViewModel
// {
//     public required List<Book> BookList { get; set; }
// }

public class BookViewModel
{
    public int Bid { get; set; }
    public string? BName { get; set; } 
    public string? Author { get; set; }
    public int Price { get; set; }
    public string? BookStatus { get; set; }
    public string? CategoryJson { get; set; }
    public string? ImgUrl { get; set; }
    public string Isbn { get; set; }
    
    public string Description { get; set; }
    public string? Seller { get; set; }
    public string? Buyer { get; set; }

    public string? OrderStatus { get; set; }
    
    public int OrderId { get; set; }
    
    public List<string> selectedDep { get; set; }
    public List<string> selectedCourse { get; set; }

    public string? SearchWords { get; set; }


}