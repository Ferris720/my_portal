using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom.Models;

namespace Diplom.Controllers
{
    public class AdminCompabilityController : Controller
    {
        private EquipmentContext equipmentContext = new EquipmentContext();
        // GET: Admin

        public ActionResult IndexAdmComp()
        {
            IEnumerable<Compability> compabilities = equipmentContext.Compability;
            ViewBag.Compabilities = compabilities;
            return View();
        }
        public ActionResult Details(int id)
        {
            ViewBag.Id = id;
            IEnumerable<Compability> compabilities = equipmentContext.Compability;
            ViewBag.Compabilities = compabilities;
            return View();
        }
        public ActionResult Create()
        {
            Compability newCompability = new Compability();
            return View(newCompability);
        }
        [HttpPost]
        public ActionResult Create(Compability newCompability)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    equipmentContext.Compability.Add(newCompability);
                    equipmentContext.SaveChanges();
                    return RedirectToAction("IndexAdmComp");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Ошибка ввода", ex);
            }
            return View(newCompability);
        }
        public ActionResult Edit(int id)
        {
            IEnumerable<Compability> compabilities = equipmentContext.Compability;
            var editcompability = (from Compability in compabilities where Compability.CompabilityId == id select Compability).First();
            return View(editcompability);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            IEnumerable<Compability> compabilities = equipmentContext.Compability;
            var editcompability = (from Compability in compabilities where Compability.CompabilityId == id select Compability).First();
            try
            {
                UpdateModel(editcompability);
                equipmentContext.SaveChanges();
                return RedirectToAction("IndexAdmComp");
            }
            catch
            {
                return View(editcompability);
            }
        }
        public ActionResult Delete(int id)
        {
            IEnumerable<Compability> compabilities = equipmentContext.Compability;
            var deletecompability = (from Compability in compabilities where Compability.CompabilityId == id select Compability).First();
            return View(deletecompability);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            IEnumerable<Compability> compabilities = equipmentContext.Compability;
            var deletecompability = (from Compability in compabilities where Compability.CompabilityId == id select Compability).First();

            try
            {
                equipmentContext.Compability.Remove(deletecompability);
                equipmentContext.SaveChanges();
                return RedirectToAction("IndexAdmComp");
            }
            catch
            {
                return View(deletecompability);
            }
        }

    }
}