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
    Customers Customers;
    Sales Sales;

    public ABCPos()
    {
        Items = new Items();
        Customers = new Customers();
        Sales = new Sales();
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

    public List<Customer> GetCustomers()
    {
        return Customers.GetCustomers();
    }

    public bool DeleteCustomer(int CustomerID)
    {
        return Customers.DeleteCustomer(CustomerID);
    }

    public bool AddCustomer(Customer customer)
    {
        return Customers.AddCustomer(customer);
    }

    public bool UpdateCustomer(Customer customer)
    {
        return Customers.UpdateCustomer(customer);
    }

    public Customer GetCustomer(int CustomerID)
    {
        return Customers.GetCustomer(CustomerID);
    }

    public bool ProcessSale(string Salesperson, int CustomerID, List<SaleItem> items)
    {
        return Sales.ProcessSale(Salesperson, CustomerID, items);
    }
}