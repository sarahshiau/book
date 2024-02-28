using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using yorkshin.Entities;
using yorkshin.Repos;
using yorkshin.Requests;
using yorkshin.ViewModels;

namespace yorkshin.Controllers;

public class UserController : Controller
{
    private readonly UserRepository _userRepository;

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public IActionResult LoginPage()
    {
        return View("Login");
    }
    public IActionResult RegisterPage()
    {
        return View("Register");
    }

    public IActionResult EditUser(User user)
    {
        user.Identity = HttpContext.Session.GetString("Identity");
        user.Uid = int.Parse(HttpContext.Session.GetString("Uid"));
        var result = _userRepository.EditUser(user);
        if (result)
        {
            return Json(new { message = "success" });
        }

        return Json(new { message = "fail" });
    }

    public async Task<IActionResult> UserPage()
    {
        var userIdString = HttpContext.Session.GetString("Uid") ?? string.Empty;

        if (int.TryParse(userIdString, out var userId))
        {
            var result = await _userRepository.SelectUserId(userId);

            if (result != null)
            {
                // User found, return the corresponding view
                return View(result);
            }
        }

        // User not found or error occurred, redirect to a default page
        return RedirectToAction("UserPage", "User");
    }
    public IActionResult Register(RegisterRequest registerRequest)
    {
        var result = _userRepository.Register(registerRequest);
        if (result)
        {
            return new JsonResult(new { message = "success" })
            {
                StatusCode = 200
            };
        }
        return new JsonResult(new { message = "fail" })
        {
            StatusCode = 200
        };
    }
    public IActionResult Login(LoginRequest loginRequest)
    {
        var user = _userRepository.Login(loginRequest);
        if (user != null)
        {
            HttpContext.Session.SetString("Uid", user.Uid.ToString());
            HttpContext.Session.SetString("Identity", user.Identity);
            HttpContext.Session.SetString("UName", user.UName);
            return new JsonResult(new { message = "success" })
            {
                StatusCode = 200
            };
        }
        return new JsonResult(new { message = "fail" })
        {
            StatusCode = 200
        };
    }
    public IActionResult Logout()
    {
        HttpContext.Session.SetString("Uid", "");
        return RedirectToAction("LandingPage", "Home");
    }
    
}