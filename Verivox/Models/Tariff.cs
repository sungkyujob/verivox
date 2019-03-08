namespace Verivox.Models
{
    public class Tariff
    {
        public Tariff() { }
        public Tariff(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
     }
}