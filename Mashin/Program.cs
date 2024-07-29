using System;

namespace Lesson_31
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           Inventar inventory = new Inventar();
           inventory.AddTovar(new Tovar(1, "Coca-Cola", 50, 10));
           inventory.AddTovar(new Tovar(2, "Pepsi", 45, 15));
           inventory.AddTovar(new Tovar(3, "Snack", 30, 20));

           Mashin vendingMachine = new Mashin(inventory);
           Adminca adminPanel = new Adminca(vendingMachine);
       
           while (true)
           {
               Console.WriteLine("Здравствуйте вставьте деньги для покупки товара:");
               int moneyInserted = Convert.ToInt32(Console.ReadLine());
               vendingMachine.Money(moneyInserted);
       
               Console.WriteLine("Выберите товар по ID из списка ниже :");
               adminPanel.DisplayInventory();
               int productId = Convert.ToInt32(Console.ReadLine());
       
               Console.WriteLine("Введите количество товара для покупки:");
               int productCount = Convert.ToInt32(Console.ReadLine());
       
               string result = vendingMachine.PurchaseProduct(productId, productCount);
               Console.WriteLine(result);
       
               int change = vendingMachine.GetChan();
               Console.WriteLine($"Ваша сдача: {change} рублей.");
               
               Console.WriteLine("Введите пароль для доступа к админ-панели:");
               string password = Console.ReadLine();
               if (password == "admin")
               {
                   Console.WriteLine("Доступ в админ-панель предоставлен.");
                   
                   bool exitAdminPanel = false;
                   while (!exitAdminPanel)
                   {
                       Console.WriteLine("Выберите действие: \n1. Добавить товар \n2. Удалить товар \n3. Показать инвентарь \n4. Выход");
                       int action = Convert.ToInt32(Console.ReadLine());
                       switch (action)
                       {
                           case 1:
                               Console.WriteLine("Введите ID товара:");
                               int id = Convert.ToInt32(Console.ReadLine());
                               Console.WriteLine("Введите название товара:");
                               string name = Console.ReadLine();
                               Console.WriteLine("Введите цену товара:");
                               int price = Convert.ToInt32(Console.ReadLine());
                               Console.WriteLine("Введите количество товара:");
                               int quantity = Convert.ToInt32(Console.ReadLine());
                               adminPanel.AddProduct(id, name, price, quantity);
                               break;
                           case 2:
                               Console.WriteLine("Введите ID товара для удаления:");
                               int removeId = Convert.ToInt32(Console.ReadLine());
                               adminPanel.RemoveProduct(removeId);
                               break;
                           case 3:
                               adminPanel.DisplayInventory();
                               break;
                           case 4:
                               exitAdminPanel = true;
                               Console.WriteLine("Выход из админ-панели.");
                               break;
                           default:
                               Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                               break;
                       }
                   }
               }
               else
               {
                   Console.WriteLine("Неверный пароль. Доступ к админ-панели запрещен.");
               }

               Console.WriteLine("Хотите завершить работу? (да/нет)");
               string exit = Console.ReadLine();
               if (exit.ToLower() == "да")
               {
                   break;
               }
           }
        }
    }
}