using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom.Models;

namespace Diplom.Controllers
{
    public class AdminController : Controller
    {
        private EquipmentContext equipmentContext = new EquipmentContext();
        // GET: Admin
        public ActionResult IndexAdm()
        {
            IEnumerable<Category> categories = equipmentContext.Categories;
            ViewBag.Categories = categories;
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Id = id;
            IEnumerable<Category> categories = equipmentContext.Categories;
            ViewBag.Categories = categories;
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            Category newCategory = new Category();
            return View(newCategory);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Category newCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    equipmentContext.Categories.Add(newCategory);
                    equipmentContext.SaveChanges();
             
                    return RedirectToAction("IndexAdm");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Ошибка ввода", ex);
            }
            return View(newCategory);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Category> categories = equipmentContext.Categories;
            var editcategory = (from Category in categories where Category.Id == id select Category).First();
            return View(editcategory);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            IEnumerable<Category> categories = equipmentContext.Categories;
            var editcategory = (from Category in categories where Category.Id == id select Category).First();
            try
            {
                UpdateModel(editcategory);
                equipmentContext.SaveChanges();
                return RedirectToAction("IndexAdm");
            }
            catch
            {
                return View(editcategory);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<Category> categories = equipmentContext.Categories;
            var deletecategory = (from Category in categories where Category.Id == id select Category).First();
            return View(deletecategory);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            IEnumerable<Category> categories = equipmentContext.Categories;
            var deletecategory = (from Category in categories where Category.Id == id select Category).First();

            try
            {
                equipmentContext.Categories.Remove(deletecategory);
                equipmentContext.SaveChanges();
                return RedirectToAction("IndexAdm");
            }
            catch
            {
                return View(deletecategory);
            }
        }
        private static readonly HttpCookieFactory cookieFactory = new HttpCookieFactory();
        public ActionResult LayoutToShow()
        {
            IEnumerable<User> users = equipmentContext.Users;
            ViewBag.User = GetUser();
            return View("LayoutToShow");
        }
        public void SetUser(string login, bool isAdmin)
        {
            var context = System.Web.HttpContext.Current;
            context.Response.Cookies.Add(cookieFactory.Create(login, isAdmin));
        }

        public string[] GetUser()
        {
            var context = System.Web.HttpContext.Current;
            var cookies = context.Request.Cookies["Diplom"];
            string[] arrUser = new[] { cookies["UserLogin"], cookies["IsAdmin"] };
            return arrUser;
        }
    }
}
