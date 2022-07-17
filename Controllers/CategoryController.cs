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
    }
}

