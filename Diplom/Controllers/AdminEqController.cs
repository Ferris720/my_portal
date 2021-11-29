using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom.Models;

namespace Diplom.Controllers
{
    public class AdminEqController : Controller
    {
        private EquipmentContext equipmentContext = new EquipmentContext();

        public ActionResult IndexAdmEq()
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            ViewBag.Equipments = equipments;
            return View();
        }

        // GET: AdminEq/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminEq/Create
        // GET: Admin/Create
        public ActionResult Create()
        {
            Equipment newEquipment = new Equipment();
            return View(newEquipment);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Equipment newEquipment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    equipmentContext.Equipments.Add(newEquipment);
                    equipmentContext.SaveChanges();
                    return RedirectToAction("IndexAdmEq");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Ошибка ввода", ex);
            }
            return View(newEquipment);
        }

        // GET: AdminEq/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            var editequipment = (from Equipment in equipments where Equipment.Id == id select Equipment).First();
            return View(editequipment);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            var editequipment = (from Equipment in equipments where Equipment.Id == id select Equipment).First();
            try
            {
                UpdateModel(editequipment);
                equipmentContext.SaveChanges();
                return RedirectToAction("IndexAdmEq");
            }
            catch
            {
                return View(editequipment);
            }
        }

        // GET: AdminEq/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            var deleteequipment = (from Equipment in equipments where Equipment.Id == id select Equipment).First();
            return View(deleteequipment);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            var deleteequipment = (from Equipment in equipments where Equipment.Id == id select Equipment).First();

            try
            {
                equipmentContext.Equipments.Remove(deleteequipment);
                equipmentContext.SaveChanges();
                return RedirectToAction("IndexAdmEq");
            }
            catch
            {
                return View(deleteequipment);
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
