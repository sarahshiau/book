namespace yorkshin.Requests;

public class LoginRequest
{
    public required string Account { get; set; }
    public required string Pwd { get; set; }
}