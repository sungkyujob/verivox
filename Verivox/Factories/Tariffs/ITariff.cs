namespace Verivox.Factories.Tariffs
{
    using Models;

    /// <summary>
    /// Defines the <see cref="ITariff" />
    /// </summary>
    public interface ITariff
    {
        /// <summary>
        /// The Calculate
        /// </summary>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        /// <returns>The <see cref="Tariff"/></returns>
        Tariff Calculate(int consumption);
    }
}
