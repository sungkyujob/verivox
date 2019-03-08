namespace Verivox.Factories.Tariffs
{
    using Models;
    public interface ITariff
    {
        Tariff Calculate(int consumption);
    }
}