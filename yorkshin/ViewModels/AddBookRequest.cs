namespace yorkshin.ViewModels;

public class AddBookRequest
{
   public int Bid { get; set; }
   public string Bname { get; set; }
   public string Author { get; set; }
   public int Price { get; set; }
   public string Isbn { get; set; }
   public string DepartmentList { get; set; }
   public string CourseList { get; set; }
   public string BookStatus { get; set; }
   public string Description { get; set; }
}