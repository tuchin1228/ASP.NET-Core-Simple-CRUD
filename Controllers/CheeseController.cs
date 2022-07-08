using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelationTest.Data;
using RelationTest.Models;
using RelationTest.ViewModel;

namespace RelationTest.Controllers
{
    public class CheeseController : Controller
    {

        private readonly DataContext _context;

        public CheeseController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IList<Product> products = _context.Products.Include(c => c.Category).ToList();
            return View(products);
        }

        public IActionResult Category()
        {
            IList<CheeseCategory> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult AddProduct()
        {
            ViewData["categories"] = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public IActionResult AddCategory()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult AddCategory(CheeseCategory category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Category");
            }

            return View(category);
        }

        public IActionResult EditCategoryView(int Id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(CheeseCategory category)
        {
            if (ModelState.IsValid)
            {
                int categoryId = category.Id;
                var temp = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
                temp.Name = category.Name;
                _context.SaveChanges();
                return RedirectToAction("Category");

            }

            return RedirectToAction("EditCategoryView", category);
        }

        public IActionResult EditProductView(int Id)
        {

            ViewData["categories"] = _context.Categories.ToList();
            var product = _context.Products.FirstOrDefault(c => c.Id == Id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                int productId = product.Id;
                var temp = _context.Products.FirstOrDefault(c => c.Id == productId);
                temp.Name = product.Name;
                temp.Description = product.Description;
                temp.CategoryId = product.CategoryId;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            return RedirectToAction("EditProductView" , product);
        }
        

        [Route("DeleteCategory/{Id}")]
        public IActionResult DeleteCategory(int Id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == Id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("Category"); 

        }

        [Route("DeleteProduct/{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            var product = _context.Products.FirstOrDefault(c => c.Id == Id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }

    }
}
