using FraudPrevention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution
{
    private int allRegister;
    private StringBuilder textFile = new StringBuilder();
    static void Main(string[] args)
    {
        var a = Math.Round(0.0450m, 2); //importe
        var b = decimal.Round(0.0450m, 2); //importe editado
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        Solution solution = new Solution();
        solution.Start();
    }

    private void Start()
    {
        GetData();

        List<InfoPurchase> purchases = new List<InfoPurchase>();
        purchases = GetAllInfoPurchase(purchases);

        InfoPurchase purchase = new InfoPurchase();
        Console.WriteLine(purchase.SearchFraudulent(purchases));
        Console.ReadKey();
    }

    private void GetData()
    {
        //Initialize variables
        allRegister = 3;
        textFile.AppendLine("1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010");
        textFile.AppendLine("2,1,elmer@fudd.com,123 Sesame St.,New York,NY,10011,10987654321");
        textFile.AppendLine("3,2,bugs@bunny.com,123 Sesame St.,New York,IL,10011,12345689010");

        //Console
        //allRegister = int.Parse(Console.ReadLine());
        //for (int i = 0; i < allRegister; i++)
        //{
        //    textFile.AppendLine(Console.ReadLine());
        //}
    }

    private List<InfoPurchase> GetAllInfoPurchase(List<InfoPurchase> purchases)
    {
        string[] arrayRegisters = GetPurchase();

        for (int i = 0; i < allRegister; i++)
        {
            string[] register = arrayRegisters[i].Split(',');
            purchases.Add(NewInfoPurchase(register));
        }

        return purchases;
    }

    private string[] GetPurchase()
    {
        string[] stringSeparators = new string[] { "\r\n" };
        string[] arrayRegisters = textFile.ToString().Split(stringSeparators, StringSplitOptions.None);
        arrayRegisters = arrayRegisters.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        return arrayRegisters;
    }

    private InfoPurchase NewInfoPurchase(string[] register)
    {
        return new InfoPurchase
        {
            OrderId = int.Parse(register[0]),
            DealId = int.Parse(register[1]),
            EmailAddress = register[2],
            StreetAddress = register[3],
            City = register[4],
            State = register[5],
            ZipCode = register[6],
            CreditCard = register[7],
        };
    }
}
