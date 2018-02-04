namespace FraudPrevention.Test
{
    public static class MockFile
    {
        private const string FirstLine = "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010";
        private const string SecondLine = "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689011";
        private const string ThirdLine = "3,2,roger@rabbit.com,1234 Not Sesame St.,Colorado,CL,10012,12345689012";
        private const string FourLine = "4,2,roger@rabbit.com,1234 Not Sesame St.,Colorado,CL,10012,12345689014";

        public static string[] FourLines_MoreThanOneFraudulent => new string[] { FirstLine, SecondLine, ThirdLine, FourLine };

        public static string[] OneLineFile => new string[] { FirstLine };

        public static string[] ThreeLines_FraudulentSecond => new string[] { FirstLine, SecondLine, ThirdLine };

        public static string[] TwoLines_FraudulentSecond => new string[] { FirstLine, SecondLine };
    }
}
