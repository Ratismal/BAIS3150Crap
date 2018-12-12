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
        MessageLabel.InnerText = "";
        var item = new Item();
        if (ItemCode.Text.Length != 6)
        {
            MessageLabel.InnerText += "ItemCode must be 6 characters long. ";
        }
        item.ItemCode = ItemCode.Text;
        if (Description.Text.Length <= 0)
        {
            MessageLabel.InnerText += "Description is required. ";
        }
        item.Description = Description.Text;
        try
        {
            decimal price = Convert.ToDecimal(UnitPrice.Text);
            item.UnitPrice = price;
        }
        catch
        {
            MessageLabel.InnerText += "UnitPrice must be a decimal. ";
        }
        try
        {
            int quant = Convert.ToInt32(QuantityOnHand.Text);
            if (quant < 0)
            {
                MessageLabel.InnerText += "QuantityOnHand must be positive or 0. ";
            }
            else item.QuantityOnHand = quant;
        }
        catch
        {
            MessageLabel.InnerText += "QuantityOnHand must be an integer. ";
        }
        item.Deleted = false;
        if (!string.IsNullOrWhiteSpace(MessageLabel.InnerText))
        {
            return;
        }
        else if (manager.AddItem(item))
        {
            ResetButton_Click(sender, e);
            MessageLabel.InnerText = "Successfully added item.";
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ABC/Default.aspx");
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        ItemCode.Text = "";
        Description.Text = "";
        UnitPrice.Text = "";
        QuantityOnHand.Text = "";
    }
}