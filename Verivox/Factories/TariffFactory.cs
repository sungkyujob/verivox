namespace Verivox.Factories
{
    using Tariffs;

    /// <summary>
    /// Defines the <see cref="TariffFactory" />
    /// </summary>
    public class TariffFactory
    {
        /// <summary>
        /// The GetTariff
        /// </summary>
        /// <param name="tariff">The tariff<see cref="TariffType"/></param>
        /// <returns>The <see cref="ITariff"/></returns>
        public static ITariff GetTariff(TariffType tariff)
        {
            switch (tariff)
            {
                case TariffType.Basic:
                    return new TariffBasic();
                default:
                    return new TariffPackage();
            }
        }
    }
}
