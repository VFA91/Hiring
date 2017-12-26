using FraudPrevention;
using System;
using System.Collections.Generic;

public class Solution
{
    static void Main(string[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        Solution solution = new Solution();
        solution.Start();
    }

    private void Start()
    {
        List<string> textFile = new List<string>();
        textFile.Add("3");
        textFile.Add("1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010");
        textFile.Add("2,1,elmer@fudd.com,123 Sesame St.,New York,NY,10011,10987654321");
        textFile.Add("3,2,bugs@bunny.com,123 Sesame St.,New York,IL,10011,12345689010");

        InfoPurchases infoPurchases = new InfoPurchases(textFile);
        Console.WriteLine(infoPurchases.GetOrderIdFraudulent());
        Console.ReadKey();
    }
}
