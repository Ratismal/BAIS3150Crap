using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for SaleItem
/// </summary>
[Table(Name = "SaleItem")]
public class SaleItem
{
    [Column(IsPrimaryKey = true)]
    public int SaleNumber { get; set; }
    [Column(IsPrimaryKey = true)]
    public string ItemCode { get; set; }
    [Column]
    public int Quantity { get; set; }
    [Column]
    public decimal ItemTotal { get; set; }

    [Association(OtherKey = "ItemCode", ThisKey = "ItemCode", IsForeignKey = true)]
    public Item Item { get; set; }

    [Association(OtherKey = "SaleNumber", ThisKey = "SaleNumber", IsForeignKey = true)]
    public Sale Sale { get; set; }
}