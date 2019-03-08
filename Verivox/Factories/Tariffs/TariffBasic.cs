namespace Verivox.Factories.Tariffs
{
    using Models;
    public class TariffBasic : ITariff
    {
        private Tariff tariff;
        private string name;
        private int monthsPerYear;
        private decimal costPerKWh;
        private decimal baseCost;
        
        public TariffBasic() : base()
        {
            tariff = new Tariff(TariffType.Basic.ToString());
            name = TariffType.Basic.ToString();
            costPerKWh = 0.22M;
            baseCost = 5;
            monthsPerYear = 12;
        }
        private decimal BaseCost
        {
            get
            {
                return baseCost * monthsPerYear;
            }
        }

        public Tariff Calculate(int consumption)
        {
            tariff.Cost = BaseCost + (costPerKWh * consumption);
            return tariff;
        }
    }
}