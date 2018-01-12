using _60321_Ganko.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _60321_Ganko.Models
{
    public class Cart
    {
        List<CartItem> items;

        public Cart()
        {
            items = new List<CartItem>();
        }

        // добавить в корзину
        public void AddItem(Car car)
        {
            var item = items.Find(i => i.Car.CarId == car.CarId);
            if (item == null)
            {
                items.Add(new CartItem { Car = car, Qauntity = 1 });
            }
            else item.Qauntity += 1;
        }

        // удалить из корзины
        public void RemoveItem(Car car)
        {
            var item = items.Find(i => i.Car.CarId == car.CarId);
            if (item.Qauntity == 1)
            {
                items.Remove(item);
            }
            else
                item.Qauntity -= 1;
        }

        // очистить корзину
        public void Clear()
        {
            items.Clear();
        }

        // получение суммарной стоимости покупок
        public decimal GetTotal()
        {
            return items.Sum(i => i.Car.Price * i.Qauntity);
        }

        // получение содержимого корзины
        public IEnumerable<CartItem> GetItems()
        {
            return items;
        }
    }
}