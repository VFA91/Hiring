using FraudPrevention.ValueObject;
using System;

namespace FraudPrevention.Entity
{
    public class InfoPurchase
    {
        public int OrderId { get; }
        public int DealId { get; }
        public Email Email { get; }
        public Address Address { get; }
        public string CreditCard { get; }

        public InfoPurchase(int orderId, int dealdId, Email email, Address address, string creditCard)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));
            if (address == null) throw new ArgumentNullException(nameof(address));
            
            OrderId = orderId;
            DealId = dealdId;
            Email = email;
            Address = address;
            CreditCard = creditCard;
        }
    }
}
