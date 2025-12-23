using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myFirstapp.Data;
using myFirstapp.Models;


namespace myFirstapp.Controllers
{
    public class ProductsController(AppDBContext context) : Controller

    {
        private readonly AppDBContext _contxt = context;

        public IActionResult Index()
        {
            var result = _contxt.Products.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(Product product)
        {
            if (ModelState.IsValid)
            {
                _contxt.Products.Add(product);
                _contxt.SaveChanges();
                TempData["success"] = "<div class=\"position-fixed bottom-0 end-0 p-3\" style=\"z-index: 1100;\">\r\n <div id=\"successToast\" class=\"toast text-bg-success border-0 toast-glow\" role=\"alert\">\r\n    <div class=\"d-flex\">\r\n      <div class=\"toast-body\">\r\n        ✨ Successfully Added!\r\n      </div>\r\n      <button class=\"btn-close btn-close-white me-2 m-auto\" data-bs-dismiss=\"toast\"></button>\r\n    </div>\r\n  </div>\r\n</div>";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var p = _contxt.Products.FirstOrDefault(I => I.Id == id);
            if (p == null){
                return NotFound();
            }

            _contxt.Products.Remove(p);
            _contxt.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var p = _contxt.Products.Find(id);
            if (p == null){
                return NotFound();
            }
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var a = _contxt.Products.Find(model.Id);
            if (a == null)
            {
                return NotFound();
            }
            a.Name = model.Name;
            a.Category = model.Category;
            a.Quantity = model.Quantity;
            a.Price = model.Price;
            _contxt.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
