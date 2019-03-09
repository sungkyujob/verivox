namespace Verivox.Test.Controllers
{
    using Factories.Tariffs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Results;
    using TestUtil;
    using Verivox.Controllers;

    /// <summary>
    /// Defines the <see cref="TariffsControllerTest" />
    /// </summary>
    [TestClass]
    public class TariffsControllerTest
    {
        /// <summary>
        /// Defines the _controller
        /// </summary>
        private TariffsController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="TariffsControllerTest"/> class.
        /// </summary>
        public TariffsControllerTest()
        {
            _controller = new TariffsController();
        }

        /// <summary>
        /// The GetTariffsAsyncTest
        /// </summary>
        [TestMethod]
        public void GetTariffsAsyncTest()
        {
            var tariffs = Enum.GetNames(typeof(TariffType));
            var result = _controller.GetTariffs().Result as string[];
            CollectionAssert.AreEqual(tariffs, result);
        }

        /// <summary>
        /// The GetAllTariffCostTestAsync
        /// </summary>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        [TestMethod]
        [DataRow(3500)]
        [DataRow(4500)]
        [DataRow(6000)]
        public void GetAllTariffCostTestAsync(int consumption)
        {
            var expected = Expected.GetExpectedTariffCost(consumption);
            var result = _controller.GetAllTariffCostAsync(consumption).Result as List<Tariff>;
            Assert.AreEqual(expected[0].Name, result[0].Name);
            Assert.AreEqual(expected[0].Cost, result[0].Cost);
            Assert.AreEqual(expected[1].Name, result[1].Name);
            Assert.AreEqual(expected[1].Cost, result[1].Cost);
        }

        /// <summary>
        /// The GetAllTariffCostTest
        /// </summary>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        [TestMethod]
        [DataRow(3500)]
        [DataRow(4500)]
        [DataRow(6000)]
        public void GetAllTariffCostTest(int consumption)
        {
            var expected = Expected.GetExpectedTariffCost(consumption);
            var result = _controller.GetAllTariffCost(consumption) as List<Tariff>;
            Assert.AreEqual(expected[0].Name, result[0].Name);
            Assert.AreEqual(expected[0].Cost, result[0].Cost);
            Assert.AreEqual(expected[1].Name, result[1].Name);
            Assert.AreEqual(expected[1].Cost, result[1].Cost);
        }

        /// <summary>
        /// The GetTariffCostTestAsync
        /// </summary>
        /// <param name="tariff_name">The tariff_name<see cref="string"/></param>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        [TestMethod]
        [DataRow("Basic", 3500)]
        [DataRow("Basic", 4500)]
        [DataRow("Basic", 6000)]
        [DataRow("Package", 3500)]
        [DataRow("Package", 4500)]
        [DataRow("Package", 6000)]
        public void GetTariffCostTestAsync(string tariff_name, int consumption)
        {
            var expected = Expected.GetExpectedTariffCost(tariff_name, consumption);
            var result = _controller.GetTariffCostAsync(tariff_name, consumption).Result;
            var ok = result as OkNegotiatedContentResult<Tariff>;
            Assert.AreEqual(expected.Name, ok.Content.Name);
            Assert.AreEqual(expected.Cost, ok.Content.Cost);
        }

        /// <summary>
        /// The GetTariffCostTest
        /// </summary>
        /// <param name="tariff_name">The tariff_name<see cref="string"/></param>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        [TestMethod]
        [DataRow("Basic", 3500)]
        [DataRow("Basic", 4500)]
        [DataRow("Basic", 6000)]
        [DataRow("Package", 3500)]
        [DataRow("Package", 4500)]
        [DataRow("Package", 6000)]
        public void GetTariffCostTest(string tariff_name, int consumption)
        {
            var expected = Expected.GetExpectedTariffCost(tariff_name, consumption);
            var result = _controller.GetTariffCost(tariff_name, consumption);
            var ok = result as OkNegotiatedContentResult<Tariff>;
            Assert.AreEqual(expected.Name, ok.Content.Name);
            Assert.AreEqual(expected.Cost, ok.Content.Cost);
        }
    }
}
