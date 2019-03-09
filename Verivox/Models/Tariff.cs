namespace Verivox.Models
{
    /// <summary>
    /// Defines the <see cref="Tariff" />
    /// </summary>
    public class Tariff
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tariff"/> class.
        /// </summary>
        public Tariff()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tariff"/> class.
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        public Tariff(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Cost
        /// </summary>
        public decimal Cost { get; set; }
    }
}
