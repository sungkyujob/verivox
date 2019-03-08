namespace Verivox.Test.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Factories.Tariffs;
    using Factories;

    [TestClass]
    public class TariffFactoryTest
    {
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
