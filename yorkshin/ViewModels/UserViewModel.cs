using yorkshin.Entities;

namespace yorkshin.ViewModels;

public class UserViewModel
{
    public int Uid { get; set; }
    public string? UName { get; set; }
    public string? Account { get; set; }
    public string? Pwd { get; set; }
    public string? Identity { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}