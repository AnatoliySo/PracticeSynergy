namespace Lesson_31
{
    public class Mashin
    {
        public Inventar _inventar;
        private int _balance;

        public Mashin(Inventar inventar)
        {
            _inventar = inventar;
            _balance = 0;
        }

        public void Money(int money)
        {
            _balance += money;
        }

        public int GetChan()
        {
            int change = _balance;
            _balance = 0;
            return change;
        }
        
        public string PurchaseProduct(int id, int count)
        {
            var product = _inventar.GetTovar(id);
            if (product == null)
                return "Не понятный товар";

            if (product.PointTovar < count)
                return "Нехватка товара на складе";

            if (_balance < product.Prise * count)
            {
                return "ДенЯг НЕТ";
            }
                
                
            _balance -= product.Prise * count;
            product.QuantiUpdate(-count);
            return $"Товар {product.Name} куплен в количестве {count}.";
        }
    }
}