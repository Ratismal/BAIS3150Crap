<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>This site is very ugly, sorry.</h1>

            <h2>GetCustomersByCountry</h2>
            <asp:TextBox runat="server" ID="Country"></asp:TextBox>
            <asp:LinkButton runat="server" ID="RunCountry" Text="Do it!" OnClick="RunCountry_Click"></asp:LinkButton>

            <h2>BinaryToDecimal</h2>
            <asp:TextBox runat="server" ID="Binary"></asp:TextBox>
            <asp:LinkButton runat="server" ID="RunBinary" Text="Do it!" OnClick="RunBinary_Click"></asp:LinkButton>

            <h2>DecimalToBinary</h2>
            <asp:TextBox runat="server" ID="Decimal"></asp:TextBox>
            <asp:LinkButton runat="server" ID="RunDecimal" Text="Do it!" OnClick="RunDecimal_Click"></asp:LinkButton>

            <h2>IsItPrime</h2>
            <asp:TextBox runat="server" ID="Prime"></asp:TextBox>
            <asp:LinkButton runat="server" ID="RunPrime" Text="Do it!" OnClick="RunPrime_Click"></asp:LinkButton>

            <h2>RESULTS!</h2>
            <p>Your results go here!</p>
            <asp:Label runat="server" ID="ResultBox" CssClass="result-box"></asp:Label>
        </div>
        <style>
            .result-box {
                white-space: pre-wrap;
            }
        </style>
    </form>
</body>
</html>
