<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateProgram.aspx.cs" Inherits="Content_CreateProgram" Theme="Operation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Create Program</h2>

    <asp:Label runat="server" ID="ProgramCodeLabel">Program Code</asp:Label>
    <asp:TextBox runat="server" ID="ProgramCode"></asp:TextBox>

    <asp:Label runat="server" ID="DescriptionLabel">Description</asp:Label>
    <asp:TextBox runat="server" ID="Description"></asp:TextBox>


    <asp:Button runat="server" ID="SubmitButton" Text="Submit" CssClass="button submit" OnClick="SubmitButton_Click" />

    <asp:Label runat="server" ID="ResultMessage"></asp:Label>

</asp:Content>

