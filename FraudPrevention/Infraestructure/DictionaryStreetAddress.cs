using System.Collections.Generic;
using System.Linq;

namespace FraudPrevention
{
    class DictionaryStreetAddress
    {
        public Dictionary<string, string> DictionaryStreetsAddress { get; set; }
        public DictionaryStreetAddress()
        {
            DictionaryStreetsAddress = new Dictionary<string, string>()
            {
                { "st.", "street"},
                { "rd.", "road"}
            };
        }
        public string FormatString(string street)
        {
            return DictionaryStreetsAddress.Aggregate(street, (result, s) => result.Replace(s.Key, s.Value));
        }
    }
}
