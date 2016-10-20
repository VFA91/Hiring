using System.Collections.Generic;
using System.Linq;

namespace FraudPrevention
{
    public class InfoPurchase
    {
        private string _emailAddress;
        private string _streetAddress;
        private string _city;
        private string _state;

        public int OrderId { get; set; }
        public int DealId { get; set; }
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = FormatEmailAddress(value); }
        }
        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = FormatStreetAddress(value); }
        }
        public string City
        {
            get { return _city; }
            set { _city = value.ToLower(); }
        }
        public string State
        {
            get { return _state; }
            set { _state = FormatState(value); }
        }
        public string ZipCode { get; set; }
        public string CreditCard { get; set; }

        public InfoPurchase()
        {

        }

        public string SearchFraudulent(List<InfoPurchase> purchases)
        {
            var queryEmail = DifferenceEmail(purchases);
            var queryAddress = DifferenceAddress(purchases);

            string result = GetOrderId(queryEmail) + GetOrderId(queryAddress);

            return FormatResult(result);
        }

        private string FormatResult(string result)
        {
            if (result.Length > 0)
                result = result.Substring(0, result.Length - 1);
            else
                result = "No se han encontrado fraudes.";
            return result;
        }

        private string GetOrderId(IEnumerable<InfoPurchase> query)
        {
            string result = "";
            if (query != null && query.Count() > 0)
            {
                foreach (var item in query)
                {
                    result += item.OrderId + ",";
                }
            }

            return result;
        }

        private IEnumerable<InfoPurchase> DifferenceEmail(List<InfoPurchase> purchases)
        {
            var queryEmail = from item in purchases
                             let dealId = item.DealId
                             let email = item.EmailAddress
                             group item by new { dealId, email } into g
                             where g.Count() > 1
                             select g;

            return queryEmail.FirstOrDefault();
        }

        private IEnumerable<InfoPurchase> DifferenceAddress(List<InfoPurchase> purchases)
        {
            var queryAddress = from item in purchases
                               let dealId = item.DealId
                               let street = item.StreetAddress
                               let city = item.City
                               let state = item.State
                               let zipCode = item.ZipCode
                               group item by new { dealId, street, city, state, zipCode } into g
                               where g.Count() > 1
                               select g;

            return queryAddress.FirstOrDefault();
        }

        private static string FormatEmailAddress(string email)
        {
            email = email.DefaultFormat();
            email = email.Split('@')[0].Replace(".", "") + "@" + email.Split('@')[1];
            int existPlus = email.IndexOf('+');
            if (existPlus > 0)
                email = email.Remove(existPlus, email.IndexOf('@') - existPlus);

            return email;
        }

        private string FormatStreetAddress(string street)
        {
            street = street.DefaultFormat();
            DictionaryStreetAddress dictionaryStreet = new DictionaryStreetAddress();
            street = dictionaryStreet.FormatString(street);

            return street;
        }

        private string FormatState(string state)
        {
            state = state.DefaultFormat();
            DictionaryState dictionaryState = new DictionaryState();
            state = dictionaryState.FormatString(state);

            return state;
        }
    }
}
