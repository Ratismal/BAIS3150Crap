<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Theme="Start" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Default Page</h2>
    <p>this is the default page wow so neat</p>

    <p>For ABC Hardware, see <asp:HyperLink runat="server" NavigateUrl="~/ABC/Default.aspx">here</asp:HyperLink>!</p>

    <br />
    <div class="marquee-wrap">
        <div class="marquee-content">
            <img src="https://media.tenor.com/images/e91c53238b99a8d90af183a40f8d3a46/tenor.gif" />
            <img src="https://media.tenor.com/images/e91c53238b99a8d90af183a40f8d3a46/tenor.gif" />
            <img src="https://media.tenor.com/images/e91c53238b99a8d90af183a40f8d3a46/tenor.gif" />
            <img src="https://media.tenor.com/images/e91c53238b99a8d90af183a40f8d3a46/tenor.gif" />
            <img src="https://media.tenor.com/images/e91c53238b99a8d90af183a40f8d3a46/tenor.gif" />
        </div>

    </div>
</asp:Content>

