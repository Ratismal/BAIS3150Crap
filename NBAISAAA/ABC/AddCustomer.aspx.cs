using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABC_AddCustomer : System.Web.UI.Page
{
    ABCPos manager;
    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new ABCPos();
    }
    private void validate(bool exp, string message)
    {
        if (!exp)
        {
            MessageLabel.InnerText += message + " \n";
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        var customer = new Customer()
        {
            CustomerName = CustomerName.Text,
            Address = Address.Text,
            City = City.Text,
            Province = Province.Text,
            PostalCode = PostalCode.Text,
            Deleted = false
        };

        MessageLabel.InnerText = customer.validate();

        if (!string.IsNullOrWhiteSpace(MessageLabel.InnerText))
        {
            return;
        }
        else if (manager.AddCustomer(customer))
        {
            ResetButton_Click(sender, e);
            MessageLabel.InnerText = "Successfully added customer.";
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ABC/Default.aspx");
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        CustomerName.Text = "";
        Address.Text = "";
        PostalCode.Text = "";
        City.Text = "";
        Province.Text = "";
    }
}