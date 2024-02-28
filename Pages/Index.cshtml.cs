using LAB3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LAB3.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> list { get; set; }
        public List<Category> listCategory { get; set; }

        protected readonly SE1710_DBContext dataContext;
        public IndexModel(SE1710_DBContext dbContext)
        {
            dataContext = dbContext;

        }

        public IActionResult OnGet(int? id)
        {
            if (id != null)
                list = dataContext.Products.Include(p => p.Category).Where(p => p.CategoryId == id).ToList();
            else
                list = dataContext.Products.Include(p => p.Category).ToList();
            listCategory = dataContext.Categories.ToList();
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
