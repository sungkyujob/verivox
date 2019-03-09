namespace Verivox.Factories.Tariffs
{
    using Models;

    /// <summary>
    /// Defines the <see cref="TariffPackage" />
    /// </summary>
    public class TariffPackage : ITariff
    {
        /// <summary>
        /// Defines the tariff
        /// </summary>
        private Tariff tariff;

        /// <summary>
        /// Defines the costPerKWh
        /// </summary>
        private decimal costPerKWh;

        /// <summary>
        /// Defines the baseCost
        /// </summary>
        private decimal baseCost;

        /// <summary>
        /// Defines the baseKWhPerYear
        /// </summary>
        private decimal baseKWhPerYear;

        /// <summary>
        /// Initializes a new instance of the <see cref="TariffPackage"/> class.
        /// </summary>
        public TariffPackage()
        {
            tariff = new Tariff(TariffType.Package.ToString());
            costPerKWh = 0.3M;
            baseCost = 800;
            baseKWhPerYear = 4000;
        }

        /// <summary>
        /// Gets the BaseCost
        /// </summary>
        private decimal BaseCost
        {
            get
            {
                return baseCost;
            }
        }

        /// <summary>
        /// The Calculate
        /// </summary>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        /// <returns>The <see cref="Tariff"/></returns>
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
