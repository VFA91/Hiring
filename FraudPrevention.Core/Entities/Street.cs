namespace FraudPrevention.Core.Entities
{
    using FraudPrevention.Core.ValueObject;
    using System.Collections.Generic;

    public class Street : ValueObject<Street>
    {
        public string Value { get; }

        private Street(string value)
        {
            Value = value;
        }

        public static Street Create(string street)
        {
            street = street.ToLower();

            street = street.Replace("st.", "street").Replace("rd.", "road");

            return new Street(street);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
