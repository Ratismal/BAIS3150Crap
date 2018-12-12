using System;
using System.Collections.Generic;
using System.Linq;
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

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        MessageLabel.InnerText = "a";
        var customer = new Customer();
       
        customer.Deleted = false;
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