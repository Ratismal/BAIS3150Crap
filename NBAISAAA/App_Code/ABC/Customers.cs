using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customers
/// </summary>
public class Customers
{
    public Customer GetCustomer(int CustomerID)
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var Customers = db.GetTable<Customer>();
            var existing = Customers.Where(c => c.CustomerID == CustomerID).First();
            return existing;
        }
    }

    public bool AddCustomer(Customer customer)
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var Customers = db.GetTable<Customer>();
            Customers.InsertOnSubmit(customer);
            db.SubmitChanges();
        }

        return true;
    }

    public bool UpdateCustomer(Customer customer)
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var Customers= db.GetTable<Customer>();
            var existing = Customers.Where(c => customer.CustomerID == c.CustomerID).First();
            existing.Customername = customer.Customername;
            existing.Address = customer.Address;
            existing.City = customer.City;
            existing.Province = customer.Province;
            existing.PostalCode = customer.PostalCode;
            db.SubmitChanges();
        }

        return true;
    }

    public bool DeleteCustomer(int CustomerID)
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var Customers = db.GetTable<Customer>();
            var existing = Customers.Where(c => c.CustomerID == CustomerID).First();
            existing.Deleted = true;
            db.SubmitChanges();
        }

        return true;
    }

    public List<Customer> GetCustomers()
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var Customers = db.GetTable<Customer>();

            return Customers.Where(i => !i.Deleted).ToList();
        }
    }
}