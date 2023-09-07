using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();

            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name ==  obj.DisplayOrder.ToString()) //Model Validation
            //{
            //    ModelState.AddModelError("name", "The display order cannot exactly match the name");
            //}
            
            //if (obj.Name.ToLower() == "test") //Property Validation
            //{
            //    ModelState.AddModelError("", "test is an invalid option");
            //}

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
