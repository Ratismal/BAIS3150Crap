using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ABCPos
/// </summary>
public class ABCPos
{
    Items Items;

    public ABCPos()
    {
        Items = new Items();
    }

    public List<Item> GetItems()
    {
        return Items.GetItems();
    }

    public bool DeleteItem(string ItemCode)
    {
        return Items.DeleteItem(ItemCode);
    }

    public bool AddItem(Item item)
    {
        return Items.AddItem(item);
    }

    public bool UpdateItem(Item item)
    {
        return Items.UpdateItem(item);
    }

    public Item GetItem(string ItemCode)
    {
        return Items.GetItem(ItemCode);
    }
}