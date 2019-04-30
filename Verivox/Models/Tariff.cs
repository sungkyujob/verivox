using System.Collections.Generic;

namespace Verivox.Models
{
    /// <summary>
    /// Defines the <see cref="Tariff" />
    /// </summary>
    public class TariffCalcMeasure
    {
        public string CalcName { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Tariff"/> class.
        /// </summary>
        public long ElapsedMilliseconds { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Tariff"/> class.
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
    }
}
