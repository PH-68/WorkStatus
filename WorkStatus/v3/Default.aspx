<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WorkStatus.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=WorkStatus.Properties.LanguageResource.ws %> | V3 early access</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.slim.js" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
        integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
        integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <%--<div style="width: 99999999px; height: 99999999px; z-index: 4" class="bg-dark removeMe"></div>--%>
        <div class="h-100 container">
            <div class="text-center h2 form-group">
                <%=WorkStatus.Properties.LanguageResource.ws %>
            </div>
            <div class="table-responsive">
                <asp:Label Text="Oops....Something went wrong...." runat="server" ID="Label_1" CssClass="table-responsive-xl" />
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <div id="card"></div>
                        <div class="empty"></div>
                        <p class="emptyp"></p>
                    </asp:View>
                </asp:MultiView>
            </div>
            <div class="d-flex justify-content-center">
                <div class="justify-content-center form-group btn-group w-75 text-center">
                    <a class="btn btn-outline-danger form-group" href="../v2/"><%=WorkStatus.Properties.LanguageResource.GoToOlderVersion %></a>
                    <a href="?changetheme=true" class="btn btn-outline-info form-group"><%=WorkStatus.Properties.LanguageResource.SwitchTheTheme %></a>
                </div>
            </div>
        </div>
        <footer class="small text-center form-group"><small class="text-muted">Build : γ-0.0.2.2-Stable</small></footer>
    </form>
</body>
</html>