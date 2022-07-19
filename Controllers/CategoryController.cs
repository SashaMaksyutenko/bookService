using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookService.Data;
using bookService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookService.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Category>objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //get method
        public IActionResult Create()
        { 
            return View();
        }
        //post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "the name and display order cannot be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category was created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //get method
        public IActionResult Edit(int ?Id)
        {
            if (Id==null || Id==0)
            {
                return NotFound();
            }
            var CategoryFromDB = _db.Categories.Find(Id);
            if (CategoryFromDB == null)
            {
                return NotFound();
            }
            return View(CategoryFromDB);
        }
        //post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "the name and display order cannot be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category was updated successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //get method
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var CategoryFromDB = _db.Categories.Find(Id);
            if (CategoryFromDB == null)
            {
                return NotFound();
            }
            return View(CategoryFromDB);
        }
        //post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Id)
        {
            var obj = _db.Categories.Find(Id);
            if(obj==null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category was deleted successfully";
            return RedirectToAction("Index"); 
        }
    }
}

