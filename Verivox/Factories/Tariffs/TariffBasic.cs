namespace Verivox.Factories.Tariffs
{
    using Models;

    /// <summary>
    /// Defines the <see cref="TariffBasic" />
    /// </summary>
    public class TariffBasic : ITariff
    {
        /// <summary>
        /// Defines the tariff
        /// </summary>
        private Tariff tariff;

        /// <summary>
        /// Defines the name
        /// </summary>
        private string name;

        /// <summary>
        /// Defines the monthsPerYear
        /// </summary>
        private int monthsPerYear;

        /// <summary>
        /// Defines the costPerKWh
        /// </summary>
        private decimal costPerKWh;

        /// <summary>
        /// Defines the baseCost
        /// </summary>
        private decimal baseCost;

        /// <summary>
        /// Initializes a new instance of the <see cref="TariffBasic"/> class.
        /// </summary>
        public TariffBasic() : base()
        {
            tariff = new Tariff(TariffType.Basic.ToString());
            name = TariffType.Basic.ToString();
            costPerKWh = 0.22M;
            baseCost = 5;
            monthsPerYear = 12;
        }

        /// <summary>
        /// Gets the BaseCost
        /// </summary>
        private decimal BaseCost
        {
            get
            {
                return baseCost * monthsPerYear;
            }
        }

        /// <summary>
        /// The Calculate
        /// </summary>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        /// <returns>The <see cref="Tariff"/></returns>
        public Tariff Calculate(int consumption)
        {
            tariff.Cost = BaseCost + (costPerKWh * consumption);
            return tariff;
        }
    }
}
