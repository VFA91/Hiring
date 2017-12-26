using System.Collections.Generic;
using System.Linq;

namespace FraudPrevention
{
    public static class Addresses
    {
        private readonly static Dictionary<string, string> _addresses;

        static Addresses()
        {
            _addresses = new Dictionary<string, string>()
            {
                { "st.", "street"},
                { "rd.", "road"}
            };
        }

        public static string FormatString(string street)
        {
            return _addresses.Aggregate(street, (result, s) => result.Replace(s.Key, s.Value));
        }
    }
}
