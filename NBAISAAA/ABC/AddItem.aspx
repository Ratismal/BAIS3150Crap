<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddItem.aspx.cs" Inherits="ABC_AddItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div runat="server" id="MessageLabel"></div>

    <asp:Label runat="server">ItemCode</asp:Label>
    <asp:TextBox runat="server" ID="ItemCode" MaxLength="6"></asp:TextBox>
    <asp:Label runat="server">Description</asp:Label>
    <asp:TextBox runat="server" ID="Description" MaxLength="100"></asp:TextBox>
    <asp:Label runat="server">UnitPrice</asp:Label>
    <asp:TextBox runat="server" ID="UnitPrice" TextMode="Number"></asp:TextBox>
    <asp:Label runat="server">QuantityOnHand</asp:Label>
    <asp:TextBox runat="server" ID="QuantityOnHand" TextMode="Number"></asp:TextBox>

    <div class="button-group">
        <asp:LinkButton runat="server" ID="CancelButton" CssClass="button delete" OnClick="CancelButton_Click">Cancel</asp:LinkButton>
        <asp:LinkButton runat="server" ID="ResetButton" CssClass="button delete" OnClick="ResetButton_Click">Reset</asp:LinkButton>
        <asp:LinkButton runat="server" ID="SubmitButton" CssClass="button submit" OnClick="SubmitButton_Click">Submit</asp:LinkButton>
    </div>

</asp:Content>

