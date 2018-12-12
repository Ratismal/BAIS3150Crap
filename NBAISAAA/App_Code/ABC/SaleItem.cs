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
    public int SaleNumber { get; set; }
    public string ItemCode { get; set; }
    public int Quantity { get; set; }
    public decimal ItemTotal { get; set; }

    [Association(OtherKey = "ItemCode")]
    public Item Item { get; set; }

    [Association(OtherKey = "SaleNumber")]
    public Sale Sale { get; set; }
}