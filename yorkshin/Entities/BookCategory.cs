using System.ComponentModel.DataAnnotations;

namespace yorkshin.Entities;

public class BookCategory
{
    [Key]public int Cid { get; set; }
    
    
    public required string Primary { get; set; }
    
    public required string Secondary { get; set; }
}