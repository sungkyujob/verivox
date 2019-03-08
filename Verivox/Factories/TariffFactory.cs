namespace Verivox.Factories
{
    using Tariffs;
    public class TariffFactory
    {
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