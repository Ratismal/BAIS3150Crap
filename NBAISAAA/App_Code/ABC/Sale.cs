using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Sale
/// </summary>
[Table(Name = "Sale")]
public class Sale
{
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public string SalesPerson { get; set; }
    public int CustomerID { get; set; }
    public decimal SubTotal { get; set; }
    public decimal GST { get; set; }
    public decimal SaleTotal { get; set; }

    [Association(OtherKey = "SaleNumber")]
    public EntitySet<SaleItem> SaleItems { get; set; }
    [Association(OtherKey = "CustomerID")]
    public Customer Customer { get; set; }
}