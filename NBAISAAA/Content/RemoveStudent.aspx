<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RemoveStudent.aspx.cs" Inherits="Content_RemoveStudent" Theme="Operation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Remove Student</h2>

    <asp:Label runat="server">Student ID</asp:Label>
    <asp:TextBox runat="server" ID="StudentID"></asp:TextBox>

    <asp:Button runat="server" ID="SubmitButton" Text="Submit" CssClass="button submit" OnClick="SubmitButton_Click"/>
    
    <asp:Label runat="server" ID="ResultMessage"></asp:Label>
</asp:Content>

