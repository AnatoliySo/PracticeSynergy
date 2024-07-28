using System;
using System.Collections.Generic;

namespace Lesson_31
{
    public class Adminca
    {
        private Mashin _vendingMachine;

        public Adminca(Mashin vendingMachin)
        {
            _vendingMachine = vendingMachin;
        }

        public void AddProduct(int id, string name, int price, int pointTovar)
        {
            _vendingMachine._inventar.AddTovar(new Tovar(id, name, price, pointTovar));
            DisplayInventory();
        }

        public void RemoveProduct(int id)
        {
            if (_vendingMachine._inventar.DeletTovar(id))
            {
                Console.WriteLine($"Товар с этим ID {id} удален.");
            }
            else
            {
                Console.WriteLine($"Товар с таким ID {id} не найден.");
            };
        }
        
        public void DisplayInventory()
        {
            foreach (var product in _vendingMachine._inventar.GetAllProducts())
            {
                Console.WriteLine($"ID: {product.Id}, Название: {product.Name}, Цена: {product.Prise}, Количество: {product.PointTovar}");
            }
        }
        
        public IEnumerable<Tovar> GetAllProducts()
        {
            return _vendingMachine._inventar.GetAllProducts();
        }
    }
}


        
        