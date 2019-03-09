namespace Verivox.Test.TestUtil
{
    using Factories.Tariffs;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    /// <summary>
    /// Defines the <see cref="Expected" />
    /// </summary>
    public class Expected
    {
        /// <summary>
        /// Gets the WelCome
        /// </summary>
        public static string WelCome
        {
            get
            {
                return "Welcome to Verivox API";
            }
        }

        /// <summary>
        /// Gets the RequestID
        /// </summary>
        public static string RequestID
        {
            get
            {
                return "d56ee953";
            }
        }

        /// <summary>
        /// Gets the RequestHeader
        /// </summary>
        public static NameValueCollection RequestHeader
        {
            get
            {
                return new NameValueCollection()
                {
                    {"request-id", RequestID}
                };
            }
        }

        /// <summary>
        /// Gets the IpAddress
        /// </summary>
        public static string IpAddress
        {
            get
            {
                return "127.0.0.1";
            }
        }

        /// <summary>
        /// Gets the Uri
        /// </summary>
        public static Uri Uri
        {
            get
            {
                return new Uri("https://www.verivox.de/");
            }
        }

        /// <summary>
        /// Defines the Consumption3500
        /// </summary>
        public static int Consumption3500 = 3500;

        /// <summary>
        /// Defines the Consumption4500
        /// </summary>
        public static int Consumption4500 = 4500;

        /// <summary>
        /// Defines the Consumption6000
        /// </summary>
        public static int Consumption6000 = 6000;

        /// <summary>
        /// Gets the Package3500
        /// </summary>
        public static Tariff Package3500
        {
            get
            {
                return new Tariff()
                {
                    Name = TariffType.Package.ToString(),
                    Cost = 800.0M
                };
            }
        }

        /// <summary>
        /// Gets the Package4500
        /// </summary>
        public static Tariff Package4500
        {
            get
            {
                return new Tariff()
                {
                    Name = TariffType.Package.ToString(),
                    Cost = 950.0M
                };
            }
        }

        /// <summary>
        /// Gets the Package6000
        /// </summary>
        public static Tariff Package6000
        {
            get
            {
                return new Tariff()
                {
                    Name = TariffType.Package.ToString(),
                    Cost = 1400.0M
                };
            }
        }

        /// <summary>
        /// Gets the Basic3500
        /// </summary>
        public static Tariff Basic3500
        {
            get
            {
                return new Tariff()
                {
                    Name = TariffType.Basic.ToString(),
                    Cost = 830.0M
                };
            }
        }

        /// <summary>
        /// Gets the Basic4500
        /// </summary>
        public static Tariff Basic4500
        {
            get
            {
                return new Tariff()
                {
                    Name = TariffType.Basic.ToString(),
                    Cost = 1050.0M
                };
            }
        }

        /// <summary>
        /// Gets the Basic6000
        /// </summary>
        public static Tariff Basic6000
        {
            get
            {
                return new Tariff()
                {
                    Name = TariffType.Basic.ToString(),
                    Cost = 1380.0M
                };
            }
        }

        /// <summary>
        /// The GetExpectedTariffCost
        /// </summary>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        /// <returns>The <see cref="List{Tariff}"/></returns>
        public static List<Tariff> GetExpectedTariffCost(int consumption)
        {
            List<Tariff> expected = new List<Tariff>();
            List<Tariff> expectedOutputFor3500 = new List<Tariff>()
            {
                Package3500, Basic3500
            };
            List<Tariff> expectedOutputFor4500 = new List<Tariff>()
            {
                Package4500, Basic4500
            };
            List<Tariff> expectedOutputFor6000 = new List<Tariff>()
            {
                Basic6000, Package6000

            };
            if (consumption == Consumption3500)
            {
                expected = expectedOutputFor3500;
            }
            if (consumption == Consumption4500)
            {
                expected = expectedOutputFor4500;
            }
            if (consumption == Consumption6000)
            {
                expected = expectedOutputFor6000;
            }
            return expected;
        }

        /// <summary>
        /// The GetExpectedTariffCost
        /// </summary>
        /// <param name="tariff_name">The tariff_name<see cref="string"/></param>
        /// <param name="consumption">The consumption<see cref="int"/></param>
        /// <returns>The <see cref="Tariff"/></returns>
        public static Tariff GetExpectedTariffCost(string tariff_name, int consumption)
        {
            Tariff expected = new Tariff();
            var tariff = (TariffType)Enum.Parse(typeof(TariffType), tariff_name, true);
            switch (tariff)
            {
                case TariffType.Basic:
                    expected = Basic6000;
                    if (consumption == Consumption3500)
                    {
                        expected = Basic3500;
                    }
                    if (consumption == Consumption4500)
                    {
                        expected = Basic4500;
                    }
                    break;
                case TariffType.Package:
                    expected = Package6000;
                    if (consumption == Consumption3500)
                    {
                        expected = Package3500;
                    }
                    if (consumption == Consumption4500)
                    {
                        expected = Package4500;
                    }
                    break;
            }
            return expected;
        }
    }
}
