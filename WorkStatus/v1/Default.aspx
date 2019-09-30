<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WorkStatus.v1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=WorkStatus.Properties.LanguageResource.ws %></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.slim.js" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
        integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
        integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="h-100 container table-responsive">
            <h2 class="h2 text-center">
                <%=WorkStatus.Properties.LanguageResource.ws %>
            </h2>
            <asp:Table runat="server" class="table table-hover" ID="Table">
                <asp:TableHeaderRow CssClass="thead-light">
                    <asp:TableHeaderCell>
                        #
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        <%=WorkStatus.Properties.LanguageResource.city%>
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        <%=WorkStatus.Properties.LanguageResource.status%>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                </asp:TableRow>
            </asp:Table>
            <br />
            <div class="alert alert-success alert-dismissible fade show" role="alert">
                Our data from <a href="https://www.dgpa.gov.tw/typh/daily/ndse.html">this</a> government website.
                <br />
                We update our data every 1 minute using Python on AWS
                <div class="d-flex align-content-center justify-content-center">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">❌</span>
                    </button>
                </div>
            </div>
            <div class="alert alert-danger fade show alert-dismissible" role="alert">
                The content may not be correct
                <div class="d-flex align-content-center justify-content-center">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">❌</span>
                    </button>
                </div>
            </div>
            <%--<asp:Button Text='<%=WorkStatus.Properties.LanguageResource.CL %>' runat="server" CssClass="btn btn-primary btn-lg btn-block" OnClick="CL1_Click" ID="CL1" />--%>
            <br />
            <a href="../v2/" class="btn btn-outline-success form-group">A beta version</a>
            <br />
        </div>
    </form>
</body>
</html>