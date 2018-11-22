<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModifyStudent.aspx.cs" Inherits="Content_ModifyStudent" Theme="Operation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Modify Student</h2>

    <asp:Label runat="server">Student ID</asp:Label>
    <asp:TextBox runat="server" ID="StudentID"></asp:TextBox>
    <asp:Label runat="server">First Name</asp:Label>
    <asp:TextBox runat="server" ID="FirstName"></asp:TextBox>
    <asp:Label runat="server">Last Name</asp:Label>
    <asp:TextBox runat="server" ID="LastName"></asp:TextBox>
    <asp:Label runat="server">Email</asp:Label>
    <asp:TextBox runat="server" ID="Email"></asp:TextBox>
    <asp:Label runat="server">Program Code</asp:Label>
    <asp:TextBox runat="server" ID="ProgramCode"></asp:TextBox>

    <asp:Button runat="server" ID="SubmitButton" Text="Submit" CssClass="button submit" OnClick="SubmitButton_Click" />

    <asp:Label runat="server" ID="ResultMessage"></asp:Label>
</asp:Content>

