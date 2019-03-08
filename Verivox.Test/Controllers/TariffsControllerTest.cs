namespace Verivox.Test.Controllers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Http.Results;
    using System.Collections.Generic;
    using Verivox.Controllers;
    using Factories.Tariffs;
    using Models;

    [TestClass]
    public class TariffsControllerTest
    {
        private TariffsController _controller;
        private Tariff _package3500;
        private Tariff _package4500;
        private Tariff _package6000;
        private Tariff _basic3500;
        private Tariff _basic4500;
        private Tariff _basic6000;
        private int _consumption3500 = 3500;
        private int _consumption4500 = 4500;
        private int _consumption6000 = 6000;
        public TariffsControllerTest()
        {
            _controller = new TariffsController();
            _package3500 = new Tariff()
            {
                Name = TariffType.Package.ToString(),
                Cost = 800.0M
            };
            _basic3500 = new Tariff()
            {
                Name = TariffType.Basic.ToString(),
                Cost = 830.0M
            };
            _package4500 = new Tariff()
            {
                Name = TariffType.Package.ToString(),
                Cost = 950.0M
            };
            _basic4500 = new Tariff()
            {
                Name = TariffType.Basic.ToString(),
                Cost = 1050.0M
            };
            _package6000 = new Tariff()
            {
                Name = TariffType.Package.ToString(),
                Cost = 1400.0M
            };
            _basic6000 = new Tariff()
            {
                Name = TariffType.Basic.ToString(),
                Cost = 1380.0M
            };
        }

        [TestMethod]
        public void GetTariffsTest()
        {
            var tariffs = Enum.GetNames(typeof(TariffType));
            var result = _controller.GetTariffs();
            var ok = result as OkNegotiatedContentResult<string[]>;
            CollectionAssert.AreEqual(tariffs, ok.Content);
        }

        [TestMethod]
        [DataRow(3500)]
        [DataRow(4500)]
        [DataRow(6000)]
        public void GetAllTariffCostTest(int consumption)
        {
            List<Tariff> expected = new List<Tariff>();
            List<Tariff> expectedOutputFor3500 = new List<Tariff>()
            {
                _package3500, _basic3500                
            };
            List<Tariff> expectedOutputFor4500 = new List<Tariff>()
            {
                _package4500, _basic4500
            };
            List<Tariff> expectedOutputFor6000 = new List<Tariff>()
            {
                _basic6000, _package6000
                
            };
            var result = _controller.GetAllTariffCost(consumption);
            var ok = result as OkNegotiatedContentResult<List<Tariff>>;
            if (consumption == _consumption3500)
            {
                expected = expectedOutputFor3500;
            }
            if (consumption == _consumption4500)
            {
                expected = expectedOutputFor4500;
            }
            if (consumption == _consumption6000)
            {
                expected = expectedOutputFor6000;
            }
            Assert.AreEqual(expected[0].Name, ok.Content[0].Name);
            Assert.AreEqual(expected[0].Cost, ok.Content[0].Cost);
            Assert.AreEqual(expected[1].Name, ok.Content[1].Name);
            Assert.AreEqual(expected[1].Cost, ok.Content[1].Cost);
        }
                
        [TestMethod]
        [DataRow("Basic", 3500)]
        [DataRow("Basic", 4500)]
        [DataRow("Basic", 6000)]
        [DataRow("Package", 3500)]
        [DataRow("Package", 4500)]
        [DataRow("Package", 6000)]
        public void GetTariffCostTest(string tariff_name, int consumption)
        {
            Tariff expected = new Tariff();
            var tariff = (TariffType)Enum.Parse(typeof(TariffType), tariff_name, true);
            switch(tariff)
            {
                case TariffType.Basic:
                    expected = _basic6000;
                    if (consumption == _consumption3500)
                    {
                        expected = _basic3500;
                    }
                    if (consumption == _consumption4500)
                    {
                        expected = _basic4500;
                    }
                    break;
                case TariffType.Package:
                    expected = _package6000;
                    if (consumption == _consumption3500)
                    {
                        expected = _package3500;
                    }
                    if (consumption == _consumption4500)
                    {
                        expected = _package4500;
                    }
                    break;
            }
            var result = _controller.GetTariffCost(tariff_name, consumption);
            var ok = result as OkNegotiatedContentResult<Tariff>;
            Assert.AreEqual(expected.Name, ok.Content.Name);
            Assert.AreEqual(expected.Cost, ok.Content.Cost);
        }
    }
}
