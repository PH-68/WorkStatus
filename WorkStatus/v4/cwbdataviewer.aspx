<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cwbdataviewer.aspx.cs" Inherits="WorkStatus.v4.cwbdataviewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }

        .auto-style2 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="TextBox1" runat="server" AutoCompleteType="Disabled" CssClass="auto-style2" Width="463px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <p>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style1" Height="784px" TextMode="MultiLine" Width="1470px"></asp:TextBox>
        </p>
    </form>
</body>
</html>