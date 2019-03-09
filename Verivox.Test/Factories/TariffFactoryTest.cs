namespace Verivox.Test.Controllers
{
    using Factories;
    using Factories.Tariffs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines the <see cref="TariffFactoryTest" />
    /// </summary>
    [TestClass]
    public class TariffFactoryTest
    {
        /// <summary>
        /// The GetTariffTest
        /// </summary>
        /// <param name="tariff">The tariff<see cref="TariffType"/></param>
        [TestMethod]
        [DataRow(TariffType.Basic)]
        [DataRow(TariffType.Package)]
        public void GetTariffTest(TariffType tariff)
        {
            var result = TariffFactory.GetTariff(tariff);
            if (tariff == TariffType.Basic)
            {
                Assert.IsInstanceOfType(result, typeof(TariffBasic));
            }
            if (tariff == TariffType.Package)
            {
                Assert.IsInstanceOfType(result, typeof(TariffPackage));
            }
        }
    }
}
