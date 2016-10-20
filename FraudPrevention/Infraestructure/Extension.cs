namespace FraudPrevention
{
    public static class Extension
    {
        public static string DefaultFormat(this string str)
        {
            return str.Trim().ToLower();
        }
    }
}
