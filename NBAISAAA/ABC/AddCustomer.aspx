<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddCustomer.aspx.cs" Inherits="ABC_AddCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div runat="server" id="MessageLabel" class="message-label"></div>

    <asp:Label runat="server">CustomerName</asp:Label>
    <asp:TextBox runat="server" ID="CustomerName" MaxLength="60"></asp:TextBox>
    <asp:Label runat="server">Address</asp:Label>
    <asp:TextBox runat="server" ID="Address" MaxLength="100"></asp:TextBox>
    <asp:Label runat="server">City</asp:Label>
    <asp:TextBox runat="server" ID="City" MaxLength="50"></asp:TextBox>
    <asp:Label runat="server">Province</asp:Label>
    <asp:TextBox runat="server" ID="Province" MaxLength="30"></asp:TextBox>
    <asp:Label runat="server">PostalCode</asp:Label>
    <asp:TextBox runat="server" ID="PostalCode" MaxLength="7"></asp:TextBox>

    <div class="button-group">
        <asp:LinkButton runat="server" ID="CancelButton" CssClass="button delete" OnClick="CancelButton_Click">Cancel</asp:LinkButton>
        <asp:LinkButton runat="server" ID="ResetButton" CssClass="button delete" OnClick="ResetButton_Click">Reset</asp:LinkButton>
        <asp:LinkButton runat="server" ID="SubmitButton" CssClass="button submit" OnClick="SubmitButton_Click">Submit</asp:LinkButton>
    </div>
</asp:Content>

