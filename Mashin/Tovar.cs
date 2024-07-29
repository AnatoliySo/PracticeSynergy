namespace Lesson_31
{
    public class Tovar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Prise { get; set; }
        public int PointTovar { get; set; }

        public Tovar(int id, string name, int prise, int pointTovar)
        {
            Id = id;
            Name = name;
            Prise = prise;
            PointTovar = pointTovar;
        }

        public void QuantiUpdate(int count)
        {
            PointTovar += count ;
        }
    }
}