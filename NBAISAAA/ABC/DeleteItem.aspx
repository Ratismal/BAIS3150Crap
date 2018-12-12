<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteItem.aspx.cs" Inherits="ABC_DeleteItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label runat="server" ID="MessageLabel"/>
    <asp:DropDownList runat="server" ID="ItemsList" />

    <asp:LinkButton runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" CssClass="button delete">Delete</asp:LinkButton>
</asp:Content>

