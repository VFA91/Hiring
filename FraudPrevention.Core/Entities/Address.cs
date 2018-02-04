namespace FraudPrevention.Core.Entities
{
    using FraudPrevention.Core.ValueObject;
    using System.Collections.Generic;

    public class Address : ValueObject<Address>
    {
        public Street Street { get; }
        public string City { get; }
        public State State { get; }
        public string ZipCode { get; set; }

        private Address(Street street, string city, State state, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public static Address Create(Street street, string city, State state, string zipCode)
        {
            city = city.ToLower();

            return new Address(street, city, state, zipCode);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return ZipCode;
        }
    }
}
