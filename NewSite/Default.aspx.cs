using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    BAISTServices.KMorrill2BAIS3150Service services;
    protected void Page_Load(object sender, EventArgs e)
    {
        services = new BAISTServices.KMorrill2BAIS3150Service();
    }

    protected void RunCountry_Click(object sender, EventArgs e)
    {
        DataSet res = services.GetCustomersByCountry(Country.Text);
        string output = "";

        foreach (DataRow row in res.Tables["Customers"].Rows)
        {
            foreach (DataColumn col in res.Tables["Customers"].Columns)
            {
                output += (row[col] as string ?? string.Empty) + ", ";
            }
            output += "\n";
        }

        ResultBox.Text = output;

    }

    protected void RunBinary_Click(object sender, EventArgs e)
    {
        try
        {
            string converted = services.BinaryToDecimal(Binary.Text);
            ResultBox.Text = converted;
        }
        catch (SoapException ex)
        {
            ResultBox.Text = ex.Message;
        }
    }

    protected void RunDecimal_Click(object sender, EventArgs e)
    {
        try
        {
            string converted = services.DecimalToBinary(Decimal.Text);
            ResultBox.Text = converted;
        } catch (SoapException ex)
        {
            ResultBox.Text = ex.Message;
        }
    }

    protected void RunPrime_Click(object sender, EventArgs e)
    {
        try
        {

            uint num = Convert.ToUInt32(Prime.Text);
            bool res = services.IsItPrime(num);
            ResultBox.Text = res ? "It's prime!" : "It's not prime.";
        }
        catch (SoapException ex)
        {
            ResultBox.Text = ex.Message;
        } catch 
        {
            ResultBox.Text = "You didn't provide a number.";
        }
    }
}