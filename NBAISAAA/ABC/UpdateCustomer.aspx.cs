using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABC_UpdateCustomer : System.Web.UI.Page
{
    ABCPos manager;
    List<Customer> customers;
    int customerid;

    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new ABCPos();

        if (!IsPostBack)
        {
            bind();
            populate();
        }
    }

    private void bind()
    {
        customers= manager.GetCustomers();

        ItemsList.DataSource = customers;
        ItemsList.DataTextField = "Serialized";
        ItemsList.DataValueField = "CustomerID";
        ItemsList.DataBind();

    }

    private void populate()
    {
        customers = manager.GetCustomers();
        var i = ItemsList.SelectedIndex;
        if (i >= 0 && i < customers.Count())
        {
            var item = customers[i];
            customerid = item.CustomerID;
            CustomerName.Text = item.CustomerName;
            Address.Text = item.Address;
            PostalCode.Text = item.PostalCode;
            City.Text = item.City;
            Province.Text = item.Province;
        }
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

        customers = manager.GetCustomers();

        customer.CustomerID = customers[ItemsList.SelectedIndex].CustomerID;

       
        if (!string.IsNullOrWhiteSpace(MessageLabel.InnerText))
        {
            return;
        }
        else if (manager.UpdateCustomer(customer))
        {
            ResetButton_Click(sender, e);
            MessageLabel.InnerText = "Successfully updated item.";
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
        bind();
        populate();
    }

    protected void ItemsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        populate();
    }
}