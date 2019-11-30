<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WorkStatus.v2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" runat="server" id="html">
<head runat="server">
    <title><%=WorkStatus.Properties.LanguageResource.ws %> | Beta version☢</title>
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
        <asp:Panel runat="server">
            <asp:Label CssClass="text-center d-flex justify-content-center h2" runat="server">
                <%=WorkStatus.Properties.LanguageResource.ws %>
            </asp:Label>
            <div class="h100 container">
                <div class="table-responsive-xl">
                    <asp:Table runat="server" class="table table-hover table-light" ID="Table">
                        <asp:TableHeaderRow CssClass="thead-light">
                            <asp:TableHeaderCell>
                        <%=WorkStatus.Properties.LanguageResource.city%>
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                        <%=WorkStatus.Properties.LanguageResource.status%>
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                        <%=WorkStatus.Properties.LanguageResource.status%>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table runat="server" class="table table-hover" ID="Table1">
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
                    <button type="button" class="btn btn-outline-danger form-group" data-toggle="modal" data-target="#exampleModal">
                        Go to older version.
                    </button>
                    <a href="?changetheme=true" class="btn btn-outline-info form-group">Switch the theme</a>
                    <a href="../v3/" class="btn btn-outline-success form-group">Try the new version!</a>
                    <!-- Modal -->
                    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Warning! The content may not be correct.☢</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    Warning! The content may not be correct 'cause some issue.
                                <br />
                                    We recommend you to stay at beta version.
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-success" data-dismiss="modal">V1 is no longer available.</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <footer class="small text-center form-group"><small class="text-muted">Build : β-0.2.0.11</small></footer>
                </div>
            </div>
        </asp:Panel>
    </form>
</body>
</html>