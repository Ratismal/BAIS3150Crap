using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
[Table(Name = "Customer")]
public class Customer
{
    [Column(IsPrimaryKey = true)]
    public int CustomerID { get; set; }
    [Column()]
    public string Customername { get; set; }
    [Column()]
    public string Address { get; set; }
    [Column()]
    public string City { get; set; }
    [Column()]
    public string Province { get; set; }
    [Column()]
    public string PostalCode { get; set; }
    [Column()]
    public bool Deleted { get; set; }

    [Association(OtherKey ="CustomerID")]
    public EntitySet<Sale> Sales { get; set; }
}