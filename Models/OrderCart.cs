using System;
using System.Collections.Generic;
using System.Linq;

namespace Course_Project.Models
{
    public static class OrderCart
    {
        public static readonly List<OrderCartItem> Items = new List<OrderCartItem>();

        public static event Action Changed;

        private static void Notify()
        {
            if (Changed != null) Changed();
        }

        public static void Clear()
        {
            Items.Clear();
            Notify();
        }

        public static decimal Total()
        {
            return Items.Sum(i => i.price * i.quantity);
        }

        public static void AddOrUpdate(int productId, string name, decimal price, int quantity, int available)
        {
            var item = Items.FirstOrDefault(i => i.productId == productId);
            if (item == null)
            {
                Items.Add(new OrderCartItem
                {
                    productId = productId,
                    name = name,
                    price = price,
                    quantity = quantity,
                    available = available
                });
                Notify();
                return;
            }

            int newQty = item.quantity + quantity;
            if (newQty > item.available) newQty = item.available;
            item.quantity = newQty;
            Notify();
        }

        public static void Remove(int productId)
        {
            Items.RemoveAll(i => i.productId == productId);
            Notify();
        }
    }

    public class OrderCartItem
    {
        public int productId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int available { get; set; }
    }
}
