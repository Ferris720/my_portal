using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom.Models;

namespace Diplom.Models
{
    public class Cart
    {

        private List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines { get { return lineCollection; } }
        public void AddItem(Equipment equipment, int quantity)
        {
            CartLine line = lineCollection
                .Where(b => b.Equipment.Id == equipment.Id)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Equipment = equipment, Quantuty = quantity });
            }
            else
            {
                line.Quantuty += quantity;
            }
        }
        public void RemoveLine(Equipment equipment)
        {
            lineCollection.RemoveAll(l => l.Equipment.Id == equipment.Id);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Equipment.Price * e.Quantuty);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
    }

    public class CartLine
    {
        public Equipment Equipment;
        public int Quantuty;
    }
}