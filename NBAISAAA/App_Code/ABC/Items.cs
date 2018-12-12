using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Items
/// </summary>
public class Items
{
    public Item GetItem(string ItemCode)
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var Items = db.GetTable<Item>();
            var existing = Items.Where(i => i.ItemCode == ItemCode).First();
            return existing;
        }
    }

    public bool AddItem(Item item)
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var Items = db.GetTable<Item>();
            Items.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        return true;
    }

    public bool UpdateItem(Item item)
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var Items = db.GetTable<Item>();
            var existing = Items.Where(i => i.ItemCode == item.ItemCode).First();
            existing.Description = item.Description;
            existing.QuantityOnHand = item.QuantityOnHand;
            existing.UnitPrice = item.UnitPrice;
            db.SubmitChanges();
        }

        return true;
    }

    public bool DeleteItem(string ItemCode)
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var Items = db.GetTable<Item>();
            var existing = Items.Where(i => i.ItemCode == ItemCode).First();
            existing.Deleted = true;
            db.SubmitChanges();
        }

        return true;
    }

    public List<Item> GetItems()
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var Items = db.GetTable<Item>();

            return Items.Where(i => !i.Deleted).ToList();
        }
    }
}