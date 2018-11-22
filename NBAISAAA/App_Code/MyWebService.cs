using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for MyWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/", Description = "My First Web Service", Name = "KMorrill2BAIS3150Service")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class MyWebService : System.Web.Services.WebService
{

    public MyWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public DataSet GetCustomersByCountry(string Country)
    {

        var conn = DatabaseHelper.GetDatabaseConnection("Northwind");
        conn.Open();
        var comm = DatabaseHelper.GetDatabaseProcedure("KMorrill2GetCustomersByCountry", conn);
        DatabaseHelper.GetDatabaseParameter("Country", Country, comm);
        var ds = new DataSet();
        var adapter = new SqlDataAdapter(comm);
        adapter.Fill(ds);
        conn.Close();
        ds.DataSetName = "Northwind";
        ds.Tables[0].TableName = "Customers";
        return ds;
    }

    [WebMethod]
    public string BinaryToDecimal(string binary)
    {
        int total = 0;
        char[] bleugh = binary.ToCharArray().Reverse().ToArray();
        for (int i = 0; i < bleugh.Length; i++)
        {
            int thing = bleugh[i] == '0' ? 0 : bleugh[i] == '1' ? 1 : -1;
            if (thing == -1) throw new SoapException("A binary number was not provided.", SoapException.ClientFaultCode);
            int diff = (int)Math.Pow(2, i);
            if (thing == 1)
                total += diff;
        }
        return total.ToString();
    }

    [WebMethod]
    public string DecimalToBinary(string number)
    {
        try
        {
            int num = int.Parse(number);
            int remainder = 0;
            string result = "";
            while (num > 0)
            {
                remainder = num % 2;
                num /= 2;
                result = remainder.ToString() + result;
            }
            
            return result;
        }
        catch
        {
            throw new SoapException("A decimal number was not provided.", SoapException.ClientFaultCode);
        }
    }

    [WebMethod]
    public bool IsItPrime(uint number)
    {
        bool prime = true;

        // courtesy of https://stackoverflow.com/questions/1801391/what-is-the-best-algorithm-for-checking-if-a-number-is-prime
        // for my own (slow, unoptimized) code, see below
        if (number == 1 || number == 2 || number == 3) return true;
        if (number % 2 == 0 || number % 3 == 0) return false;

        int i = 5, w = 2;
        while (i * i <= number)
        {
            if (number % i == 0)
            {
                prime = false;
                break;
            }

            i += w;
            w = 6 - w;
        }

        /*
        // old code, scrapped because of slow speed
        for (var i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                prime = false;
                break;
            }
        }
        */

        return prime;
    }

}
