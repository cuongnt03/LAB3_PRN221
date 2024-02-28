using LAB3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LAB3.Pages
{
    public class DashboardModel : PageModel
    {
        public List<Product> list { get; set; }
        public List<Category> listCate { get; set; }

        protected readonly SE1710_DBContext dataContext;
        public DashboardModel(SE1710_DBContext dbContext)
        {
            dataContext = dbContext;
            list = dataContext.Products.Include(p => p.Category).ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            string result = Request.Form["searchString"];
            list = dataContext.Products.Where(e => e.ProductName.ToLower().Contains(result.ToLower())).ToList();
            return Page();
        }
    }
}
