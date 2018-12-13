<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteCustomer.aspx.cs" Inherits="ABC_DeleteCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div runat="server" id="MessageLabel" class="message-label"></div>

    <asp:DropDownList runat="server" ID="ItemsList" />

    <asp:LinkButton runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" CssClass="button delete">Delete</asp:LinkButton>
</asp:Content>

