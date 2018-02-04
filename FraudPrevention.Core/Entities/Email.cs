namespace FraudPrevention.Core.Entities
{
    using FraudPrevention.Core.ValueObject;
    using System;
    using System.Collections.Generic;

    public class Email : ValueObject<Email>
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string email)
        {
            email = email.ToLower();

            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            email = string.Join("@", new string[] { aux[0], aux[1] });

            return new Email(email);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
