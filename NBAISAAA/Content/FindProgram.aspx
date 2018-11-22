<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FindProgram.aspx.cs" Inherits="Content_FindProgram" Theme="Query" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Find Program</h2>
    <asp:Label runat="server" ID="ProgramCodeLabel">Program Code</asp:Label>
    <asp:TextBox runat="server" ID="ProgramCode"></asp:TextBox>

    <asp:Button runat="server" ID="SubmitButton" Text="Submit" CssClass="button submit" OnClick="SubmitButton_Click"/>
    
    <asp:Label runat="server" ID="ResultMessage"></asp:Label>
</asp:Content>

