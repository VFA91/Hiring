using System.Collections.Generic;
using System.Linq;

namespace FraudPrevention
{
    public static class States
    {
        private readonly static Dictionary<string, string> _states;

        static States()
        {
            _states = new Dictionary<string, string>()
            {
                { "il", "illinois"},
                { "ca", "california"},
                { "ny", "new york"}
            };
        }

        public static string FormatString(string state)
        {
            return _states.Aggregate(state, (result, s) => result.Replace(s.Key, s.Value));
        }
    }
}
