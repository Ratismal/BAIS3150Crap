using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Item
/// </summary>
[Table(Name = "Item")]
public class Item
{
    private EntitySet<SaleItem> _SaleItems;
    public Item()
    {
        this._SaleItems = new EntitySet<SaleItem>();
    }
    [Column(IsPrimaryKey = true)]
    public string ItemCode { get; set; }
    [Column()]
    public string Description { get; set; }
    [Column()]
    public decimal UnitPrice { get; set; }
    [Column()]
    public int QuantityOnHand { get; set; }
    [Column()]
    public bool Deleted { get; set; }

    public string Serialized
    {
        get
        {
            return ItemCode + " - " + Description;
        }
    }
}