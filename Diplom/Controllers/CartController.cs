using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom.Models;

namespace Diplom.Controllers
{
    public class CartController : Controller
    {
        static private EquipmentContext equipmentContext = new EquipmentContext();
        IEnumerable<Equipment> equipments = equipmentContext.Equipments;
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }


        public ActionResult AddToCart (int eqId)
        {
            Equipment equipment = equipments
                .FirstOrDefault(x => x.Id == eqId);
            if (equipment != null)
            {
                GetCart().AddItem(equipment, 1);
            }
            return RedirectToAction("CartIndex");
        }
        public RedirectToRouteResult RemoveFromCart(int eqId, string returnUrl)
        {
            Equipment equipment = equipments
                .FirstOrDefault(x => x.Id == eqId);
            if (equipment != null)
            {
                GetCart().RemoveLine(equipment);
            }
            return RedirectToAction("CartIndex", new { returnUrl });
        }
        public ViewResult CartIndex(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
            
        }
    }
}