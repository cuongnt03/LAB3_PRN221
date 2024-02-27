using LAB3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LAB3.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }

        protected readonly SE1710_DBContext dataContext;
        public DeleteModel(SE1710_DBContext dBContext)
        {
            dataContext = dBContext;
        }
        public IActionResult OnGet(int id)
        {
            var data = dataContext.Products.Find(id);
            if (data != null)
            {
                dataContext.Products.Remove(data);
                dataContext.SaveChanges();
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
