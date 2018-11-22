<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WritingAndReadingXML.aspx.cs" Inherits="WritingAndReadingXML" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label runat="server">XML Elements File Name</asp:Label>
    <asp:TextBox runat="server" ID="ElementsFilename" CssClass="input-box"></asp:TextBox>
    <asp:Label runat="server">XML Attributes File Name</asp:Label>
    <asp:TextBox runat="server" ID="AttributesFilename" CssClass="input-box"></asp:TextBox>

    <div class="button-group">
        <asp:Button runat="server" ID="WriteButton" Text="Write XML" CssClass="button" OnClick="WriteButton_Click" />
        <asp:Button runat="server" ID="ReadButton" Text="Read XML" CssClass="button" OnClick="ReadButton_Click" />
    </div>

    <asp:Label runat="server" ID="ElementLabel"></asp:Label>
    <asp:Table runat="server" ID="ElementTable"></asp:Table>
    <asp:Label runat="server" ID="AttributeLabel"></asp:Label>
    <asp:Table runat="server" ID="AttributeTable"></asp:Table>
</asp:Content>

