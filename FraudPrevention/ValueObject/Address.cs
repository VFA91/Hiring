using System.Collections.Generic;

namespace FraudPrevention.ValueObject
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }

        private Address(string street, string city, string state, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public static Address Create(string street, string city, string state, string zipCode)
        {
            street = FormatStreet(street);
            state = FormatState(state);

            return new Address(street, city, state, zipCode);
        }

        private static string FormatState(string state) => States.FormatString(state.ToLower());

        private static string FormatStreet(string street) => Addresses.FormatString(street.ToLower());

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return ZipCode;
        }
    }
}
