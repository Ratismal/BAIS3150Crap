using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABC_ProcessSale : System.Web.UI.Page
{
    ABCPos manager;

    List<Item> allItems;
    List<SaleItem> items;
    List<Customer> customers;

    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new ABCPos();

        allItems = manager.GetItems();
        customers = manager.GetCustomers();

        if (!IsPostBack)
        {
            Session["items"] = new List<SaleItem>();
            ItemList.DataSource = allItems;
            ItemList.DataTextField = "Serialized";
            ItemList.DataValueField = "ItemCode";
            ItemList.DataBind();

            CustomerList.DataSource = customers;
            CustomerList.DataTextField = "Serialized";
            CustomerList.DataValueField = "CustomerID";
            CustomerList.DataBind();
        }

        items = GetItems();

        renderItemList();
    }

    private List<SaleItem> GetItems()
    {
        var items = (List<SaleItem>)Session["items"];
        if (items == null) items = new List<SaleItem>();
        return items;
    }

    private void renderItemList()
    {
        ItemTable.Rows.Clear();
        items = GetItems(); ;

        var hrow = new TableHeaderRow();
        hrow.Cells.Add(new TableHeaderCell() { Text = "ItemCode" });
        hrow.Cells.Add(new TableHeaderCell() { Text = "Quantity" });
        hrow.Cells.Add(new TableHeaderCell() { Text = "ItemTotal ($)" });
        hrow.Cells.Add(new TableHeaderCell() { Text = "" });
        ItemTable.Rows.Add(hrow);

        foreach (SaleItem s in items)
        {
            var row = new TableRow();
            row.Cells.Add(new TableCell() { Text = s.ItemCode });
            row.Cells.Add(new TableCell() { Text = s.Quantity.ToString() });
            row.Cells.Add(new TableCell() { Text = s.ItemTotal.ToString() });
            var deleteButtonCell = new TableCell();

            var btn = new LinkButton();
            btn.Attributes.Add("data-item-code", s.ItemCode);
            btn.Click += DeleteItem_Click;
            btn.CssClass = "button delete";
            btn.Text = "Delete";
            btn.ID = "DeleteBtn_" + s.ItemCode;
            deleteButtonCell.Controls.Add(btn);

            row.Cells.Add(deleteButtonCell);
            ItemTable.Rows.Add(row);
        }
    }

    protected void DeleteItem_Click(object sender, EventArgs e)
    {
        var btn = (LinkButton)sender;
        var it = GetItems();
        it = it.Where(i => i.ItemCode != btn.Attributes["data-item-code"]).ToList();
        Session["items"] = it;
        renderItemList();
    }

    protected void AddItem_Click(object sender, EventArgs e)
    {
        int quantity = 0;
        try
        {
            quantity = Convert.ToInt32(Quantity.Text);
        }
        catch
        {
            MessageLabel.InnerText = "Quantity must be an integer.";
            return;
        }
        var item = manager.GetItem(ItemList.SelectedValue);
        if (quantity >= item.QuantityOnHand)
        {
            MessageLabel.InnerText = "There is not enough stock on hand to fulfill this order.";
            return;
        } else if (quantity <= 0)
        {
            MessageLabel.InnerText = "Your quantity must be greater than 0";
            return;
        }
        var sitem = new SaleItem()
        {
            ItemCode = ItemList.SelectedValue,
            Quantity = quantity,
            ItemTotal = quantity * item.UnitPrice
        };
        var items = GetItems();

        if (items.Find(i => i.ItemCode == sitem.ItemCode) != null)
        {
            MessageLabel.InnerText = "That item has already been added.";
        }
        else
        {
            items.Add(sitem);
        }

        Session["items"] = items;

        renderItemList();
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        MessageLabel.InnerText = "";
        var item = new Item();

        int customerID = 0;
        try
        {
            customerID = Convert.ToInt32(CustomerList.SelectedValue);
        } catch
        {
            MessageLabel.InnerText += "A customer needs to be selected.\n";
        }

        if (Salesperson.Text.Length <= 0) MessageLabel.InnerText += "A salesperson must be provided.\n";
        var it = GetItems();
        if (it.Count() == 0) MessageLabel.InnerText += "Items must be purchased.";

        if (!string.IsNullOrWhiteSpace(MessageLabel.InnerText))
        {
            return;
        }
        else if (manager.ProcessSale(Salesperson.Text, customerID, it))
        {
            ResetButton_Click(sender, e);
            MessageLabel.InnerText = "Successfully processed sale.";
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ABC/Default.aspx");
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        Salesperson.Text = "";

        Session["items"] = new List<SaleItem>();
        ItemList.DataSource = allItems;
        ItemList.DataTextField = "Serialized";
        ItemList.DataValueField = "ItemCode";
        ItemList.DataBind();

        CustomerList.DataSource = customers;
        CustomerList.DataTextField = "Serialized";
        CustomerList.DataValueField = "CustomerID";
        CustomerList.DataBind();

        renderItemList();
    }
}