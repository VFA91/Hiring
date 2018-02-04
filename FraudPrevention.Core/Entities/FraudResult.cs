namespace FraudPrevention.Core.Entities
{
    using FraudPrevention.Core.ValueObject;
    using System.Collections.Generic;

    public class FraudResult : ValueObject<FraudResult>
    {
        public bool IsFraudulent => true;

        public int OrderId { get; }

        private FraudResult(int orderId)
        {
            OrderId = orderId;
        }

        public static FraudResult Create(int orderId)
        {
            return new FraudResult(orderId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return OrderId;
        }
    }
}
