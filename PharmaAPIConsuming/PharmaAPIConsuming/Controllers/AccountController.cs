using Microsoft.AspNetCore.Mvc;
using PharmaAPIConsuming.DTO;
using PharmaAPIConsuming.Models;

public class AccountController : Controller
{
    private readonly HttpClient client;

    public AccountController(IHttpClientFactory factory)
    {
        client = factory.CreateClient();
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO1 login)
    {
        var response = await client.PostAsJsonAsync("https://localhost:7135/api/Auth/login", login);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
            HttpContext.Session.SetString("JWToken", result.token);
            return RedirectToAction("Index", "Customer");
        }

        ViewBag.Error = "Invalid login.";
        return View();
    }
}
