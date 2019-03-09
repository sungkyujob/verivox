namespace Verivox.Test.Controllers
{
    using Factories.Tariffs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestUtil;

    /// <summary>
    /// Defines the <see cref="TariffModelTest" />
    /// </summary>
    [TestClass]
    public class TariffModelTest
    {
        /// <summary>
        /// The BasicModelTest
        /// </summary>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        [DataRow(3500)]
        [DataRow(4500)]
        [DataRow(6000)]
        [TestMethod]
        public void BasicModelTest(int consumption)
        {
            var expected = Expected.GetExpectedTariffCost(TariffType.Basic.ToString(), consumption);
            var basic = new TariffBasic();
            var tariff = basic.Calculate(consumption);
            Assert.AreEqual(expected.Cost, tariff.Cost);
        }

        /// <summary>
        /// The PackageModelTest
        /// </summary>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        [DataRow(3500)]
        [DataRow(4500)]
        [DataRow(6000)]
        [TestMethod]
        public void PackageModelTest(int consumption)
        {
            var expected = Expected.GetExpectedTariffCost(TariffType.Package.ToString(), consumption);
            var package = new TariffPackage();
            var tariff = package.Calculate(consumption);
            Assert.AreEqual(expected.Cost, tariff.Cost);
        }
    }
}
