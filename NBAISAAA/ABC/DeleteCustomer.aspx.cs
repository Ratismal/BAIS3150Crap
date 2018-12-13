using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABC_DeleteCustomer : System.Web.UI.Page
{
    ABCPos manager;
    List<Customer> customers;
    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new ABCPos();

        customers = manager.GetCustomers();

        if (!IsPostBack)
        {
            ItemsList.DataSource = customers;
            ItemsList.DataTextField = "Serialized";
            ItemsList.DataValueField = "CustomerID";
            ItemsList.DataBind();
        }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        var value = Convert.ToInt32(ItemsList.SelectedValue);
        if (manager.DeleteCustomer(value))
        {
            customers = manager.GetCustomers();
            ItemsList.DataSource = customers;
            ItemsList.DataBind();
            MessageLabel.InnerText = "Successfully deleted!";
        }
        else
        {
            MessageLabel.InnerText = "Could not delete!";
        }
    }
}