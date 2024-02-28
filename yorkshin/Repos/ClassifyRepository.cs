using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using yorkshin.Entities;
using yorkshin.ViewModels;
using yorkshin.Controllers;

namespace yorkshin.Repos;

public class ClassifyRepository
{
    private readonly YorkshinDbContext _dbContext;
    private readonly ILogger<ClassifyRepository> _logger;

    public ClassifyRepository(YorkshinDbContext dbContext,ILogger<ClassifyRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public bool AddCategory(BookCategory Cid)
    {
        try
        {
            _dbContext.BookCategory.Add(Cid);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"ClassificationRepository Register Error: {e.Message}");
            return false;
        }
        
    }
    public bool AddCategory2(BookCategory Cid)
    {
        try
        {
            _dbContext.BookCategory.Add(Cid);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"ClassificationRepository Register Error: {e.Message}");
            return false;
        }
        
    }
    public bool AddCategory3(BookCategory Cid)
    {
        try
        {
            _dbContext.BookCategory.Add(Cid);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"ClassificationRepository Register Error: {e.Message}");
            return false;
        }
        
    }
    public bool AddCategory4(BookCategory Cid)
    {
        try
        {
            _dbContext.BookCategory.Add(Cid);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"ClassificationRepository Register Error: {e.Message}");
            return false;
        }
        
    }
    public async Task<bool> DeleteCategory(int CId)
    {
        var category = await _dbContext.BookCategory.FindAsync(CId);
        if (category!=null)
        {
            _dbContext.BookCategory.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        _logger.LogError($"Book with ID {CId} not found.");
        return false;
    }
    // public bool DeleteCategory(int Cid)
    // {
    //     var category = _dbContext.BookCategory.Find(Cid);
    //     if (category == null)
    //     {
    //         return false;
    //     }
    //
    //     _dbContext.BookCategory.Remove(category);
    //     _dbContext.SaveChanges();
    //     return true;
    // }
    
    public List<BookCategory> SelectAll(string query)
    {
        List<BookCategory> categories = _dbContext.BookCategory
            .Where(bc => bc.Primary == query)
            .ToList();
        // var ClassifyList = _dbContext.BookCategory.ToList();
        return categories;
    }
    public BookCategory GetCategoryById(int Cid)
    {
        var category = _dbContext.BookCategory.FirstOrDefault(c => c.Cid == Cid);

        return category;
    }

    public async Task<List<string>> GetAllCategory(string query)
    {
        return await _dbContext.BookCategory.Where(bc => bc.Primary == query).Select(bc=>bc.Secondary).ToListAsync();
    }
}