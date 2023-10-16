using FirstApplicaton_Web.Data;
using FirstApplicaton_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace FirstApplicaton_Web.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly DBContextApplication db;
        public CatagoryController(DBContextApplication db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Catagory> CatagoryList = db.Catagories;
            return View(CatagoryList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }

        /// Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagory catagory)
        {
            if(catagory.DisplayOrder.ToString() == catagory.Name)
            {
                ModelState.AddModelError("Name", "The Display Order match the name");
            }
            if (ModelState.IsValid)
            {
                db.Catagories.Add(catagory);
                db.SaveChanges();
                TempData["Success"] = "Category is Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(catagory);
            }
        }
        //Get
        public IActionResult Edit(int ? id)
        {
            if(id==null || id <= 0)
            {
                return NotFound();
            }

            //var catagoryFromDbSingle = db.Catagories.Single(u => u.Id == id);
            //var catagoryFromDbSingleOrDefault = db.Catagories.SingleOrDefault(u => u.Id == id);
            //var catagoryFromDbFirst = db.Catagories.FirstOrDefault(u => u.Id == id);
            var catagoryFromDb = db.Catagories.Find(id);
            if(catagoryFromDb == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);
        }

        /// Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catagory catagory)
        {
            if (catagory.DisplayOrder.ToString() == catagory.Name)
            {
                ModelState.AddModelError("Name", "The Display Order match the name");
            }
            if (ModelState.IsValid)
            {
                db.Catagories.Update(catagory);
                db.SaveChanges();
                TempData["Success"] = "Category is Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(catagory);
            }
        }

        /// Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            //var catagoryFromDbSingle = db.Catagories.Single(u => u.Id == id);
            //var catagoryFromDbSingleOrDefault = db.Catagories.SingleOrDefault(u => u.Id == id);
            //var catagoryFromDbFirst = db.Catagories.FirstOrDefault(u => u.Id == id);
            var catagoryFromDb = db.Catagories.Find(id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);
        }

        /// Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int ? Id)
        {
                var catagory = db.Catagories.Find(Id);
                if (catagory == null)
                    return NotFound();
                db.Catagories.Remove(catagory);
                db.SaveChanges();
                TempData["Success"] = "Category is Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
