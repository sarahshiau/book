namespace yorkshin.Requests;

public class RegisterRequest
{
    public required string Account { get; set; }
    public required string Pwd { get; set; }

    public required string UName { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; }
}