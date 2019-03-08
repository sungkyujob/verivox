namespace Verivox.Factories.Tariffs
{
    using Models;
    public class TariffPackage : ITariff
    {
        private Tariff tariff;
        private decimal costPerKWh;
        private decimal baseCost;
        private decimal baseKWhPerYear;
        public TariffPackage()
        {
            tariff = new Tariff(TariffType.Package.ToString());
            costPerKWh = 0.3M;
            baseCost = 800;
            baseKWhPerYear = 4000;
        }

        private decimal BaseCost
        {
            get
            {
                return baseCost;
            }
        }

        public Tariff Calculate(int consumption)
        {
            if (consumption <= baseKWhPerYear)
            {
                tariff.Cost = BaseCost;
            }
            else
            {
                var exceededKWh = consumption - baseKWhPerYear;
                tariff.Cost = BaseCost + (costPerKWh * exceededKWh);
            }
            return tariff;
        }
    }
}