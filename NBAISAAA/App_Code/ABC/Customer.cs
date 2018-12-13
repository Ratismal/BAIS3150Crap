using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
[Table(Name = "Customer")]
public class Customer
{
    public Customer()
    {
        Sales = new EntitySet<Sale>();
    }

    [Column(IsPrimaryKey = true, IsDbGenerated = true)]
    public int CustomerID { get; set; }
    [Column()]
    public string CustomerName { get; set; }
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

    [Association(OtherKey = "CustomerID", ThisKey = "CustomerID", IsForeignKey = true)]
    public EntitySet<Sale> Sales { get; set; }

    public string Serialized
    {
        get
        {
            return CustomerID.ToString() + " - " + CustomerName;
        }
    }
    private string _error = "";
    private void _validate(bool exp, string message)
    {
        if (!exp)
        {
            _error += message + "\n";
        }
    }
    public string validate()
    {
        _error = "";

        _validate(this.CustomerName.Length > 0, "CustomerName must be provided.");
        _validate(this.Address.Length > 0, "Address must be provided.");
        _validate(this.City.Length > 0, "City must be provided.");
        _validate(this.Province.Length > 0, "Province must be provided.");
        _validate(this.PostalCode.Length > 0, "PostalCode must be provided.");
        _validate(Regex.IsMatch(this.PostalCode, "[A-Z][0-9][A-Z] [0-9][A-Z][0-9]"), "PostalCode must be of format 'A1A 1A1'.");

        return _error;
    }
}