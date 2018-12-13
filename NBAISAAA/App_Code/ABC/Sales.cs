using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Sales
/// </summary>
public class Sales
{
    public bool ProcessSale(string Salesperson, int CustomerID, List<SaleItem> sitems)
    {
        using (var db = DatabaseHelper.GetDataContext("KMorrill2"))
        {
            var items = db.GetTable<Item>();
            var saleItems = db.GetTable<SaleItem>();
            var sales = db.GetTable<Sale>();
            var customers = db.GetTable<Customer>();

            var sale = new Sale()
            {
                SalesPerson = Salesperson,
                CustomerID = CustomerID,
                SaleDate = DateTime.Now,
                SubTotal = 0,
                GST = 0,
                SaleTotal = 0,
                Customer = customers.Where(c => c.CustomerID == CustomerID).First()
            };
            var esItems = new EntitySet<SaleItem>();

            foreach (var sitem in sitems)
            {
                var item = items.Where(i => i.ItemCode == sitem.ItemCode).First();
                item.QuantityOnHand -= sitem.Quantity;
                sale.SubTotal+= sitem.ItemTotal;

                sitem.Sale = sale;
                sitem.Item = item;

                esItems.Add(sitem);
            }
            sale.GST = sale.SubTotal * 0.05m;
            sale.SaleTotal = sale.GST + sale.SubTotal;

            // sale.SaleItems = esItems;
            sales.InsertOnSubmit(sale);

            saleItems.InsertAllOnSubmit(sitems);

            db.SubmitChanges();
        }
        return true;
    }
}