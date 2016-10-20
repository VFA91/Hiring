using System.Collections.Generic;
using System.Linq;

namespace FraudPrevention
{
    class DictionaryState
    {
        public Dictionary<string, string> DictionaryStates { get; set; }
        public DictionaryState()
        {
            DictionaryStates = new Dictionary<string, string>()
            {
                { "il", "illinois"},
                { "ca", "california"},
                { "ny", "york"}
            };
        }

        public string FormatString(string state)
        {
            return DictionaryStates.Aggregate(state, (result, s) => result.Replace(s.Key, s.Value));
        }
    }
}
