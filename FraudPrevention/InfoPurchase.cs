using FraudPrevention.Entity;
using FraudPrevention.ValueObject;
using System.Collections.Generic;
using System.Linq;

namespace FraudPrevention
{
    public class InfoPurchases
    {
        public List<InfoPurchase> InfoPurchase { get; private set; } = new List<InfoPurchase>();
        public int Count { get; private set; }

        public InfoPurchases(List<string> register)
        {
            SetInfoPurchase(register);
        }

        public string GetOrderIdFraudulent()
        {
            List<int> results = new List<int>();
            results.AddRange(DifferenceEmail());
            results.AddRange(DifferenceAddress());

            return string.Join(",", results);
        }

        private void SetInfoPurchase(List<string> registers)
        {
            if (registers.Any())
            {
                Count = int.Parse(registers.FirstOrDefault());

                for (int i = 1; i <= Count; i++)
                {
                    string[] purchase = registers[i].Split(',');
                    InfoPurchase.Add(new InfoPurchase(int.Parse(purchase[0]), int.Parse(purchase[1]), Email.Create(purchase[2]),
                                                    Address.Create(purchase[3], purchase[4], purchase[5], purchase[6]), purchase[7]));
                }
            }
        }

        private IEnumerable<int> DifferenceEmail()
        {
            var query = InfoPurchase
                .GroupBy(p => new
                {
                    p.DealId,
                    p.Email
                }).Where(c => c.Count() > 1)
                .AsEnumerable()
                .FirstOrDefault();

            if (query != null)
                return query.Select(o => o.OrderId);

            return Enumerable.Empty<int>();
        }

        private IEnumerable<int> DifferenceAddress()
        {
            var query = InfoPurchase
                .GroupBy(p => new
                {
                    p.DealId,
                    p.Address
                }).Where(c => c.Count() > 1)
                .AsEnumerable()
                .FirstOrDefault();

            if (query != null)
                return query.Select(o => o.OrderId);

            return Enumerable.Empty<int>();
        }
    }
}
