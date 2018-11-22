using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class WritingAndReadingXML : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ElementsFilename.Text = "ShippersElementsWriter.xml";
            AttributesFilename.Text = "ShippersAttributesWriter.xml";
        }
    }

    private XmlElement AddElement(XmlElement parent, string name)
    {
        var inner = parent.OwnerDocument.CreateElement(name);
        parent.AppendChild(inner);
        return inner;
    }

    private XmlElement AddElement(XmlElement parent, string name, string value)
    {
        var inner = AddElement(parent, name);
        inner.InnerText = value;
        return inner;
    }

    private XmlAttribute AddAttribute(XmlElement parent, string name, string value)
    {
        var attr = parent.OwnerDocument.CreateAttribute(name);
        attr.Value = value;
        parent.Attributes.Append(attr);
        return attr;
    }

    protected void WriteButton_Click(object sender, EventArgs e)
    {
        var settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "\t";

        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<Northwind></Northwind>");

        var shipper1 = AddElement(doc.DocumentElement, "Shippers");
        AddElement(shipper1, "ShipperID", "1");
        AddElement(shipper1, "CompanyName", "Speedy Express");
        AddElement(shipper1, "Phone", "(503) 555-9831");

        var shipper2 = AddElement(doc.DocumentElement, "Shippers");
        AddElement(shipper2, "ShipperID", "2");
        AddElement(shipper2, "CompanyName", "United Package");
        AddElement(shipper2, "Phone", "(503) 555-3199");

        var shipper3 = AddElement(doc.DocumentElement, "Shippers");
        AddElement(shipper3, "ShipperID", "3");
        AddElement(shipper3, "CompanyName", "Federal Shipping");
        AddElement(shipper3, "Phone", "(503) 555-9931");

        var writer = XmlWriter.Create(Server.MapPath("~/" + ElementsFilename.Text), settings);
        doc.Save(writer);

        doc = new XmlDocument();
        doc.LoadXml("<Northwind></Northwind>");
        writer.Close();

        shipper1 = AddElement(doc.DocumentElement, "Shippers");
        AddAttribute(shipper1, "ShipperID", "1");
        AddAttribute(shipper1, "CompanyName", "Speedy Express");
        AddAttribute(shipper1, "Phone", "(503) 555-9831");

        shipper2 = AddElement(doc.DocumentElement, "Shippers");
        AddAttribute(shipper2, "ShipperID", "2");
        AddAttribute(shipper2, "CompanyName", "United Package");
        AddAttribute(shipper2, "Phone", "(503) 555-3199");

        shipper3 = AddElement(doc.DocumentElement, "Shippers");
        AddAttribute(shipper3, "ShipperID", "3");
        AddAttribute(shipper3, "CompanyName", "Federal Shipping");
        AddAttribute(shipper3, "Phone", "(503) 555-9931");

        writer = XmlWriter.Create(Server.MapPath("~/" + AttributesFilename.Text), settings);
        doc.Save(writer);
        writer.Close();
    }

    protected void ReadButton_Click(object sender, EventArgs e)
    {
        var settings = new XmlReaderSettings();

        using (var reader = XmlReader.Create(Server.MapPath("~/" + ElementsFilename.Text), settings))
        {
            var doc = new XmlDocument();
            doc.Load(reader);

            var northwind = doc.LastChild;

            var def = northwind.FirstChild;
            var header = new TableHeaderRow();

            foreach (XmlElement child in def.ChildNodes)
            {
                var cell = new TableHeaderCell();
                cell.Text = child.Name;
                header.Cells.Add(cell);
            }
            ElementTable.Rows.Add(header);

            foreach (XmlElement child in northwind.ChildNodes)
            {
                var row = new TableRow();
                foreach (XmlElement prop in child.ChildNodes)
                {
                    var cell = new TableCell();
                    cell.Text = prop.InnerText;
                    row.Cells.Add(cell);
                }
                ElementTable.Rows.Add(row);
            }
            ElementLabel.Text = "Read from " + ElementsFilename.Text;
        }

        using (var reader = XmlReader.Create(Server.MapPath("~/" + AttributesFilename.Text), settings))
        {
            var doc = new XmlDocument();
            doc.Load(reader);

            var northwind = doc.LastChild;

            var def = northwind.FirstChild;
            var header = new TableHeaderRow();

            foreach (XmlAttribute child in def.Attributes)
            {
                var cell = new TableHeaderCell();
                cell.Text = child.Name;
                header.Cells.Add(cell);
            }
            AttributeTable.Rows.Add(header);

            foreach (XmlElement child in northwind.ChildNodes)
            {
                var row = new TableRow();
                foreach (XmlAttribute prop in child.Attributes)
                {
                    var cell = new TableCell();
                    cell.Text = prop.InnerText;
                    row.Cells.Add(cell);
                }
                AttributeTable.Rows.Add(row);
            }
            AttributeLabel.Text = "Read from " + AttributesFilename.Text;
        }
    }
}