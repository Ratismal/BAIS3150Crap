<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomersXML.aspx.cs" Inherits="WritingAndReadingXML" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label runat="server">Country</asp:Label>
    <asp:TextBox runat="server" ID="Country" CssClass="input-box">UK</asp:TextBox>
    <asp:Label runat="server">City</asp:Label>
    <asp:TextBox runat="server" ID="City" CssClass="input-box">London</asp:TextBox>
      <asp:Label runat="server">Contact Title</asp:Label>
    <asp:TextBox runat="server" ID="ContactTitle" CssClass="input-box">Sales Agent</asp:TextBox>

    <div class="button-group">
        <asp:Button runat="server" ID="UseRaw" Text="Use Raw" CssClass="button" OnClick="UseRaw_Click" />
        <asp:Button runat="server" ID="UseAuto" Text="Use Auto" CssClass="button" OnClick="UseAuto_Click" />
        <asp:Button runat="server" ID="UseElements" Text="Use Elements Auto" CssClass="button" OnClick="UseElements_Click" />
        <asp:Button runat="server" ID="UsePath" Text="Use Path" CssClass="button" OnClick="UsePath_Click" />
    </div>
    <div class="button-group">
        <asp:Button runat="server" ID="SchemaAndXml" Text="Schema And Xml" CssClass="button" OnClick="SchemaAndXml_Click" />
        <asp:Button runat="server" ID="ValidateXml" Text="Validate Xml" CssClass="button" OnClick="ValidateXml_Click" />
    </div>

    <asp:Table runat="server" ID="XmlTable"></asp:Table>
</asp:Content>

