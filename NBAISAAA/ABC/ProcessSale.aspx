<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProcessSale.aspx.cs" Inherits="ABC_ProcessSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div runat="server" id="MessageLabel" class="message-label"></div>
    
    <asp:Label runat="server">Salesperson</asp:Label>
    <asp:TextBox runat="server" ID="Salesperson" MaxLength="60"></asp:TextBox>

    <asp:Label runat="server">Customer</asp:Label>
    <asp:DropDownList runat="server" ID="CustomerList"></asp:DropDownList>

    <h2>Items</h2>

    <asp:DropDownList runat="server" ID="ItemList"></asp:DropDownList>
    <asp:TextBox runat="server" ID="Quantity" TextMode="Number"></asp:TextBox>
    <asp:LinkButton runat="server" ID="AddItem" OnClick="AddItem_Click" CssClass="button submit">Add Item</asp:LinkButton>
    <br />
    <asp:Table runat="server" ID="ItemTable">

    </asp:Table>

    <div class="button-group">
        <asp:LinkButton runat="server" ID="CancelButton" CssClass="button delete" OnClick="CancelButton_Click">Cancel</asp:LinkButton>
        <asp:LinkButton runat="server" ID="ResetButton" CssClass="button delete" OnClick="ResetButton_Click">Reset</asp:LinkButton>
        <asp:LinkButton runat="server" ID="SubmitButton" CssClass="button submit" OnClick="SubmitButton_Click">Submit</asp:LinkButton>
    </div>

</asp:Content>

