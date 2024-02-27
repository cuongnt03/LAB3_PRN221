using LAB3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Formats.Asn1.AsnWriter;

namespace LAB3.Pages.admin.products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }

        public List<Category> listCategory { get; set; }

        protected readonly SE1710_DBContext dataContext;
        public CreateModel(SE1710_DBContext dbContext)
        {
            dataContext = dbContext;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("1") == null)
            {
                return RedirectToPage("/Index");
            }
            listCategory = dataContext.Categories.ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            var data = dataContext.Products.FirstOrDefault(e => e.ProductId == product.ProductId);
            if (data == null)
            {
                dataContext.Products.Add(product);
                dataContext.SaveChanges();
                return RedirectToPage("/index");
            }
            else
            {
                return Page();
            }
        }
    }
}
