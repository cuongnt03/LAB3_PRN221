using LAB3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System.Text.Json;

namespace LAB3.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Account account { get; set; }

        public List<Account> list { get; set; }
        protected readonly SE1710_DBContext dataContext;
        public LoginModel(SE1710_DBContext dbContext)
        {
            dataContext = dbContext;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("1") == null || HttpContext.Session.GetString("2") == null)
                return Page();
            else
                return RedirectToPage("Index");

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var data = dataContext.Accounts.FirstOrDefault(e => e.Email == account.Email);
            if (data != null)
            {
                if (data.Email == account.Email && data.Password == account.Password)
                {
                    if (data.Role == 1)
                    {
                        HttpContext.Session.SetString("1", JsonSerializer.Serialize(account));
                        return RedirectToPage("Dashboard");

                    }
                    else
                    {
                        HttpContext.Session.SetString("2", JsonSerializer.Serialize(account));
                        return RedirectToPage("Index");
                    }
                }
                else
                {
                    Console.WriteLine("fuck");
                }
            }
            TempData["msg"] = "Email or password incorrect.";
            return Page();
        }
    }
}
