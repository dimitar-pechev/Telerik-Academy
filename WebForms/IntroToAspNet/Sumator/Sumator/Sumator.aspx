<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="Sumator.Sumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sumator</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Sumator</h2>
        <label for="firstValue">First Value: </label>
        <input type="text" runat="server" id="firstValue" name="firstValue"/>
        <br />
        <label for="secondValue">Second Value: </label>
        <input type="text" runat="server" id="secondValue" name="secondValue"/>
        <br />
        <asp:Button Text="Get sum" runat="server" ID="BtnSubmit" OnClick="BtnSubmit_Click" />
        <br />
        <p runat="server" id="sum"></p>
    </div>
    </form>
</body>
</html>
