namespace Verivox.Controllers
{
    using Factories;
    using Factories.Tariffs;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Defines the <see cref="TariffsController" />
    /// </summary>
    [RoutePrefix("tariffs")]
    public class TariffsController : BaseController
    {
        /// <summary>
        /// The GetTariffs
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{string}}"/></returns>
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<string>> GetTariffsAsync()
        {
            return await Task.FromResult(Enum.GetNames(typeof(TariffType)));
        }

        /// <summary>
        /// The GetAllTariffCostAsync
        /// </summary>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        /// <returns>The <see cref="Task{IEnumerable{Tariff}}"/></returns>
        [HttpGet]
        [Route("consumption/{consumption:min(0)}")]
        public async Task<IEnumerable<Tariff>> GetAllTariffCostAsync(int consumption)
        {
            return await Task.FromResult(GetAllTariffCost(consumption));
        }

        /// <summary>
        /// The GetTariffCostAsync
        /// </summary>
        /// <param name="tariff_name">The tariff_name<see cref="string"/></param>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        /// <returns>The <see cref="Task{IHttpActionResult}"/></returns>
        [HttpGet]
        [Route("{tariff_name:regex(^(basic|package)$)}/consumption/{consumption:min(0)}")]
        public async Task<IHttpActionResult> GetTariffCostAsync(string tariff_name, int consumption)
        {
            return await Task.FromResult(GetTariffCost(tariff_name, consumption));
        }

        [HttpGet]
        [Route("consumption/perf/{calc_type:regex(^(original|suggestion)$)}/{consumption:min(0)}")]
        public async Task<TariffCalcMeasure> Perf(string calc_type, int consumption)
        {
            TariffCalcMeasure tm = new TariffCalcMeasure();
            var sw = Stopwatch.StartNew();
            tm.CalcName = calc_type;
            if (calc_type.ToLower().Equals("original"))
            {
                GetAllTariffCostPerfOriginal(consumption);
            }
            else
            {
                GetAllTariffCostPerfSuggestion(consumption);
            }
            sw.Stop();
            tm.ElapsedMilliseconds = sw.ElapsedMilliseconds;
            return await Task.FromResult(tm);
        }

        public IEnumerable<Tariff> GetAllTariffCostPerfOriginal(int consumption)
        {
            Random random = new Random();
            List<Tariff> tariffs = new List<Tariff>();
            while (consumption > 0)
            {
                foreach (TariffType tariff in Enum.GetValues(typeof(TariffType)))
                {
                    var t = TariffFactory.GetTariff(tariff).Calculate(consumption);
                    t.Cost += random.Next(0, 100000);
                    tariffs.Add(t);
                }
                consumption--;
            }
            tariffs.Sort((x, y) => (x.Cost > y.Cost) ? 1 : 0);
            return tariffs;
        }
        public IEnumerable<Tariff> GetAllTariffCostPerfSuggestion(int consumption)
        {
            Random random = new Random();
            SortedList<decimal, Tariff> tariffs = new SortedList<decimal, Tariff>();
            while (consumption > 0)
            {
                foreach (TariffType tariff in Enum.GetValues(typeof(TariffType)))
                {
                    var t = TariffFactory.GetTariff(tariff).Calculate(consumption);
                    t.Cost += random.Next(0, 100000);
                    tariffs[t.Cost] =  t;
                }
                consumption--;
            }
            return tariffs.Values;
        }

        public IEnumerable<Tariff> GetAllTariffCost(int consumption)
        {
            List<Tariff> tariffs = new List<Tariff>();
            foreach (TariffType tariff in Enum.GetValues(typeof(TariffType)))
            {
                var t = TariffFactory.GetTariff(tariff).Calculate(consumption);
                tariffs.Add(t);
            }
            tariffs.Sort((x, y) => (x.Cost > y.Cost) ? 1 : 0);
            return tariffs;
        }

        /// <summary>
        /// The GetTariffCost
        /// </summary>
        /// <param name="tariff_name">The tariff_name<see cref="string"/></param>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        /// <returns>The <see cref="IHttpActionResult"/></returns>
        public IHttpActionResult GetTariffCost(string tariff_name, int consumption)
        {
            var tariff = (TariffType)Enum.Parse(typeof(TariffType), tariff_name, true);
            return Ok(TariffFactory.GetTariff(tariff).Calculate(consumption));
        }
    }
}
