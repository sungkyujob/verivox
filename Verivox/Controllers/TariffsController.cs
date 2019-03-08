namespace Verivox.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using Models;
    using Factories;
    using Factories.Tariffs;

    [RoutePrefix("tariffs")]
    public class TariffsController : BaseController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTariffs()
        {
            var tariffs = Enum.GetNames(typeof(TariffType));
            return Ok(tariffs);
        }

        [HttpGet]
        [Route("consumption/{consumption:min(0)}")]
        public IHttpActionResult GetAllTariffCost(int consumption)
        {
            List<Tariff> tariffs = new List<Tariff>();
            foreach (TariffType tariff in (TariffType[])Enum.GetValues(typeof(TariffType)))
            {
                tariffs.Add(TariffFactory.GetTariff(tariff).Calculate(consumption));
            }
            tariffs.Sort((x, y) => (x.Cost > y.Cost) ? 1 : 0);
            return Ok(tariffs);
        }

        [HttpGet]
        [Route("{tariff_name:regex(^(basic|package)$)}/consumption/{consumption:min(0)}")]
        public IHttpActionResult GetTariffCost(string tariff_name, int consumption)
        {
            var tariff = (TariffType)Enum.Parse(typeof(TariffType), tariff_name, true);
            return Ok(TariffFactory.GetTariff(tariff).Calculate(consumption));
        }
    }
}
