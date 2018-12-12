using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABC_UpdateItem : System.Web.UI.Page
{
    ABCPos manager;
    List<Item> items;
    string itemcode;

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
        items = manager.GetItems();

        ItemsList.DataSource = items;
        ItemsList.DataTextField = "Serialized";
        ItemsList.DataValueField = "ItemCode";
        ItemsList.DataBind();

    }

    private void populate()
    {
        items = manager.GetItems();
        var i = ItemsList.SelectedIndex;
        if (i >= 0 && i < items.Count())
        {
            var item = items[i];
            itemcode = item.ItemCode;
            Description.Text = item.Description;
            UnitPrice.Text = item.UnitPrice.ToString();
            QuantityOnHand.Text = item.QuantityOnHand.ToString();
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        MessageLabel.InnerText = "";
        var item = new Item();
        items = manager.GetItems();

        item.ItemCode = items[ItemsList.SelectedIndex].ItemCode;

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
        else if (manager.UpdateItem(item))
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
        Description.Text = "";
        UnitPrice.Text = "";
        QuantityOnHand.Text = "";
        bind();
        populate();
    }

    protected void ItemsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        populate();  
    }
}