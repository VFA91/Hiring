namespace FraudPrevention.Core
{
    using FraudPrevention.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FraudRadar
    {
        private readonly List<Order> orders = new List<Order>();

        public FraudRadar(string[] lines)
        {
            foreach (var line in lines)
            {
                var items = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var order = new Order(
                    int.Parse(items[0]),
                    int.Parse(items[1]),
                    Email.Create(items[2]),
                    Address.Create(Street.Create(items[3]), items[4],
                                            State.Create(items[5]), items[6]),
                    items[7]);

                orders.Add(order);
            }
        }

        public IEnumerable<FraudResult> Check()
        {
            HashSet<FraudResult> results = new HashSet<FraudResult>();
            results.UnionWith(DifferenceEmail());
            results.UnionWith(DifferenceAddress());

            return results;
        }

        private IEnumerable<FraudResult> DifferenceEmail()
        {
            return orders.GroupBy(p => new { p.DealId, p.Email })
                        .Where(c => c.Count() > 1)
                        .SelectMany(x => x.Skip(1))
                        .Select(o => FraudResult.Create(o.OrderId));
        }

        private IEnumerable<FraudResult> DifferenceAddress()
        {
            return orders.GroupBy(p => new { p.DealId, p.Address })
                        .Where(c => c.Count() > 1)
                        .SelectMany(x => x.Skip(1))
                        .Select(o => FraudResult.Create(o.OrderId));
        }
    }
}
