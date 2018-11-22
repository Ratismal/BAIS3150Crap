using System;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Schema;

public partial class WritingAndReadingXML : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void UseRaw_Click(object sender, EventArgs e)
    {
        using (var conn = DatabaseHelper.GetDatabaseConnection("Northwind"))
        {
            conn.Open();
            var comm = DatabaseHelper.GetDatabaseProcedure("KMorrill2ForXmlRaw", conn);
            var reader = comm.ExecuteXmlReader();
            var doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Northwind");
            doc.AppendChild(root);
            XmlNode n;
            while ((n = doc.ReadNode(reader)) != null)
                root.AppendChild(n);

            OutputDocumentAttributes(doc);
        }
    }
    protected void UseAuto_Click(object sender, EventArgs e)
    {
        using (var conn = DatabaseHelper.GetDatabaseConnection("Northwind"))
        {
            conn.Open();
            var comm = DatabaseHelper.GetDatabaseProcedure("KMorrill2ForXmlAuto", conn);
            DatabaseHelper.GetDatabaseParameter("Country", Country.Text, comm);
            var reader = comm.ExecuteXmlReader();
            var doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Northwind");
            doc.AppendChild(root);
            XmlNode n;
            while ((n = doc.ReadNode(reader)) != null)
                root.AppendChild(n);

            OutputDocumentAttributes(doc);
        }
    }
    protected void UseElements_Click(object sender, EventArgs e)
    {
        using (var conn = DatabaseHelper.GetDatabaseConnection("Northwind"))
        {
            conn.Open();
            var comm = DatabaseHelper.GetDatabaseProcedure("KMorrill2ForXmlElements", conn);
            DatabaseHelper.GetDatabaseParameter("Country", Country.Text, comm);
            DatabaseHelper.GetDatabaseParameter("City", City.Text, comm);
            var reader = comm.ExecuteXmlReader();
            var doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Northwind");
            doc.AppendChild(root);
            XmlNode n;
            while ((n = doc.ReadNode(reader)) != null)
                root.AppendChild(n);

            OutputDocumentElements(doc);
        }
    }
    protected void UsePath_Click(object sender, EventArgs e)
    {
        using (var conn = DatabaseHelper.GetDatabaseConnection("Northwind"))
        {
            conn.Open();
            var comm = DatabaseHelper.GetDatabaseProcedure("KMorrill2ForXmlPath", conn);
            DatabaseHelper.GetDatabaseParameter("Country", Country.Text, comm);
            DatabaseHelper.GetDatabaseParameter("City", City.Text, comm);
            var reader = comm.ExecuteXmlReader();
            var doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Northwind");
            doc.AppendChild(root);
            XmlNode n;
            while ((n = doc.ReadNode(reader)) != null)
                root.AppendChild(n);

            OutputDocumentElements(doc);
        }
    }

    protected void SchemaAndXml_Click(object sender, EventArgs e)
    {
        using (var conn = DatabaseHelper.GetDatabaseConnection("Northwind"))
        {
            conn.Open();
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            var comm = DatabaseHelper.GetDatabaseProcedure("KMorrill2ForXmlContact", conn);
            DatabaseHelper.GetDatabaseParameter("ContactTitle", ContactTitle.Text, comm);
            var reader = comm.ExecuteXmlReader();
            if (reader.Read())
            {
                var subReader = reader.ReadSubtree();
                var sdoc = new XmlDocument();
                sdoc.Load(subReader);


                var writer = XmlWriter.Create(Server.MapPath("~/CustomersXMLSchema.xsd"), settings);
                sdoc.Save(writer);
                writer.Close();
            }
            var doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Northwind");
            doc.AppendChild(root);
            if (reader.Read())
            {
                XmlNode n;
                while ((n = doc.ReadNode(reader)) != null)
                    root.AppendChild(n);

                var writer = XmlWriter.Create(Server.MapPath("~/CustomersXMLData.xml"), settings);
                doc.Save(writer);
                writer.Close();
            }
        }
    }
    protected void ValidateXml_Click(object sender, EventArgs e)
    {
        var settings = new XmlReaderSettings();
        settings.Schemas.Add("urn:schemas-microsoft-com:sql:SqlRowSet1", Server.MapPath("~/CustomersXMLSchema.xsd"));
        settings.ValidationType = ValidationType.Schema;
        
        using (var reader = XmlReader.Create(Server.MapPath("~/CustomersXMLData.xml"), settings))
        {
            var doc = new XmlDocument();
            doc.Load(reader);

            OutputDocumentAttributes(doc);
        }
    }
    protected void OutputDocumentElements(XmlDocument doc)
    {

        var northwind = doc.LastChild;

        var def = northwind.FirstChild;
        var header = new TableHeaderRow();

        foreach (XmlElement child in def.ChildNodes)
        {
            var cell = new TableHeaderCell();
            cell.Text = child.Name;
            header.Cells.Add(cell);
        }
        XmlTable.Rows.Add(header);

        foreach (XmlElement child in northwind.ChildNodes)
        {
            var row = new TableRow();
            foreach (XmlElement prop in child.ChildNodes)
            {
                var cell = new TableCell();
                cell.Text = prop.InnerText;
                row.Cells.Add(cell);
            }
            XmlTable.Rows.Add(row);
        }
    }

    protected void OutputDocumentAttributes(XmlDocument doc)
    {

        var northwind = doc.LastChild;

        var def = northwind.FirstChild;
        var header = new TableHeaderRow();

        foreach (XmlAttribute child in def.Attributes)
        {
            var cell = new TableHeaderCell();
            cell.Text = child.Name;
            header.Cells.Add(cell);
        }
        XmlTable.Rows.Add(header);

        foreach (XmlElement child in northwind.ChildNodes)
        {
            var row = new TableRow();
            foreach (XmlAttribute prop in child.Attributes)
            {
                var cell = new TableCell();
                cell.Text = prop.InnerText;
                row.Cells.Add(cell);
            }
            XmlTable.Rows.Add(row);
        }
    }
}