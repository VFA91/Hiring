using System.Collections.Generic;
using System.Linq;

namespace FraudPrevention.ValueObject
{
    public class Email : ValueObject<Email>
    {
        private const char AT = '@';

        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string email)
        {
            email = email.ToLower();
            email = ClearDotsEmail(email);
            email = ClearPlusEmail(email);

            return new Email(email);
        }

        private static string ClearDotsEmail(string email)
        {
            string[] mail = email.Split(AT);
            return mail.ElementAt(0).Replace(".", "") + AT + mail.ElementAt(1);
        }

        private static string ClearPlusEmail(string email)
        {
            int existPlus = email.IndexOf('+');
            if (existPlus > 0)
                return email.Remove(existPlus, email.IndexOf(AT) - existPlus);
            return email;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
