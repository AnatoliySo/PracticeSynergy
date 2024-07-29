using System;
using System.Collections.Generic;

namespace Lesson_31
{
    public class Inventar
    {
        private Dictionary<int, Tovar> _tovars = new Dictionary<int, Tovar>();

        public void AddTovar(Tovar tovar)
        {
            _tovars[tovar.Id] = tovar;
        }

        public Tovar GetTovar(int id) => _tovars.TryGetValue(id, out var tovar) ? tovar : null;

        public bool DeletTovar(int id) => _tovars.Remove(id);
        
        public IEnumerable<Tovar> GetAllProducts()
        {
            return _tovars.Values;
        }
    }
}