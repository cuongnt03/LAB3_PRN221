using LAB3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LAB3.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product product { get; set; }

        public List<Category> listCategory { get; set; }
        public Product listProduct { get; set; }

        protected readonly SE1710_DBContext dataContext;
        public EditModel(SE1710_DBContext dbContext)
        {
            dataContext = dbContext;
        }


        public IActionResult OnGet(int id)
        {
            if (HttpContext.Session.GetString("1") == null)
            {
                return RedirectToPage("/Index");
            }
            listCategory = dataContext.Categories.ToList();
            listProduct = dataContext.Products.FirstOrDefault(e=>e.ProductId == id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            

            Console.WriteLine(id);
            var data = dataContext.Products.FirstOrDefault(e => e.ProductId == id);
            if (data != null)
            {
                data.ProductName = product.ProductName;
                data.CategoryId = product.CategoryId;
                data.QuantityPerUnit = product.QuantityPerUnit;
                data.UnitPrice = product.UnitPrice;
                data.UnitsInStock = product.UnitsInStock;
                data.UnitsOnOrder = product.UnitsOnOrder;
                data.ReorderLevel = product.ReorderLevel;
                data.Discontinued = product.Discontinued;
                dataContext.Products.Update(data);
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
