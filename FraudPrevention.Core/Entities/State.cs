namespace FraudPrevention.Core.Entities
{
    using FraudPrevention.Core.ValueObject;
    using System.Collections.Generic;

    public class State : ValueObject<State>
    {
        public string Value { get; }

        private State(string value)
        {
            Value = value;
        }

        public static State Create(string state)
        {
            state = state.ToLower();

            state = state.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");

            return new State(state);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
