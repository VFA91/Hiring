namespace FraudPrevention.Core
{
    using FraudPrevention.Core.Entities;
    using System;

    public class Order
    {
        public int OrderId { get; set; }

        public int DealId { get; set; }

        public Email Email { get; set; }

        public Address Address { get; set; }

        public string CreditCard { get; set; }

        public Order(int orderId, int dealdId, Email email, Address address, string creditCard)
        {
            OrderId = orderId;
            DealId = dealdId;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            CreditCard = creditCard;
        }
    }
}
