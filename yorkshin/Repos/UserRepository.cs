using Microsoft.EntityFrameworkCore;
using yorkshin.Entities;
using yorkshin.Requests;
using yorkshin.ViewModels;

namespace yorkshin.Repos;

public class UserRepository
{
    private readonly YorkshinDbContext _dbContext;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(YorkshinDbContext dbContext,ILogger<UserRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public bool Register(RegisterRequest registerRequest)
    {
        var userEntity = new User
        {
            Account = registerRequest.Account,
            Pwd = registerRequest.Pwd,
            UName = registerRequest.UName,
            Identity = "normal",
            Email = registerRequest.Email,
            Phone = registerRequest.Phone,
        };
        try
        {
            var user = _dbContext.User.FirstOrDefault(u => u.Account == userEntity.Account);
            if (user == null)
            {
                _dbContext.User.Add(userEntity);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            _logger.LogError($"UserRepository Register Error: {e.Message}");
            return false;
        }
    }
    
    public User? Login(LoginRequest loginRequest)
    {
        try
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Account == loginRequest.Account);
            if (user == null)
                return null;
            if (user.Pwd != loginRequest.Pwd)
                return null;
            return user;
        }
        catch (Exception e)
        {
            _logger.LogError($"UserRepository Login Error: {e.Message}");
            return null;
        }
        
    }
    
    
    public async Task<UserViewModel> SelectUserId(int userId)
    {
        var userContent = await _dbContext.User.FirstOrDefaultAsync(u => u.Uid == userId);
        // 使用 LINQ 查詢資料庫，並將結果投影到 CommentViewModel
        // Create a single UserViewModel based on the found user entity
        var userViewModel = new UserViewModel
        {
            Uid = userContent.Uid,
            UName = userContent.UName,
            Pwd = userContent.Pwd,
            Account = userContent.Account,
            Identity = userContent.Identity,
            Email = userContent.Email,
            Phone = userContent.Phone,
        };

        return userViewModel;
    }
    public bool EditUser(User updateUser)
    {
        try
        {
            _dbContext.User.Update(updateUser);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"UserRepository Add User Error: {e.Message}");
            return false;
        }
    }
}