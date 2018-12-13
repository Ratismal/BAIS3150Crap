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
    public Sale()
    {
        SaleItems = new EntitySet<SaleItem>();
    }

    [Column(IsPrimaryKey = true, IsDbGenerated = true)]
    public int SaleNumber { get; set; }
    [Column]
    public DateTime SaleDate { get; set; }
    [Column]
    public string SalesPerson { get; set; }
    [Column]
    public int CustomerID { get; set; }
    [Column]
    public decimal SubTotal { get; set; }
    [Column]
    public decimal GST { get; set; }
    [Column]
    public decimal SaleTotal { get; set; }

    [Association(OtherKey = "SaleNumber", ThisKey="SaleNumber", IsForeignKey = true)]
    public EntitySet<SaleItem> SaleItems { get; set; }
    [Association(OtherKey = "CustomerID", ThisKey="CustomerID", IsForeignKey = true)]
    public Customer Customer { get; set; }
}