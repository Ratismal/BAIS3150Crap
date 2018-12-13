using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABC_DeleteItem : System.Web.UI.Page
{
    ABCPos manager;
    List<Item> items;
    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new ABCPos();

        items = manager.GetItems();

        if (!IsPostBack)
        {
            ItemsList.DataSource = items;
            ItemsList.DataTextField = "Serialized";
            ItemsList.DataValueField = "ItemCode";
            ItemsList.DataBind();
        }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        var value = ItemsList.SelectedValue;
        if (manager.DeleteItem(value))
        {
            items = manager.GetItems();
            ItemsList.DataSource = items;
            ItemsList.DataBind();
            MessageLabel.InnerText = "Successfully deleted!";
        } else
        {
            MessageLabel.InnerText = "Could not delete!";
        }
    }
}