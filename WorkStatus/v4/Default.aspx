<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WorkStatus.v4.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=WorkStatus.Properties.LanguageResource.ws %> | v4</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.slim.js" crossorigin="anonymous"></script>
    <script>
        $(".form1").addClass("bg-dark")
    </script>
    <script src="https://www.cwb.gov.tw/Data/js/typhoon/TY_NEWS-Data.js"></script>
    <script src="https://www.cwb.gov.tw/V8/assets/js/TY_NEWS.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
        integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
        integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js"></script>
    <script src="https://www.google.com/recaptcha/api.js?render=6Lc_o3cUAAAAAEIBgyRh74kK7xQwJfguRoG27rcT"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script>
        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }
        if (getUrlVars()["v"] == undefined) {
            grecaptcha.ready(function () {
                grecaptcha.execute('6Lc_o3cUAAAAAEIBgyRh74kK7xQwJfguRoG27rcT', { action: 'homepage' }).then(function (token) {
                    window.location.href = "?token=" + token
                });
            });

        }
    </script>
    <script type="text/javascript">
        window.onload = function () {
            //防呆

            function getUrlVars() {
                var vars = [], hash;
                var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < hashes.length; i++) {
                    hash = hashes[i].split('=');
                    vars.push(hash[0]);
                    vars[hash[0]] = hash[1];
                }
                return vars;
            }
            if (getUrlVars()["lon"] == undefined & getUrlVars()["lat"] == undefined) {
                if (window.navigator.geolocation) {
                    window.navigator.geolocation.getCurrentPosition(success, error,
                        {
                            enableHighAccuracy: true, //取得高精確度的位置資訊
                            maximumAge: 0//馬上取得位置資訊
                        });

                } else {
                    alert("瀏覽器不支援Html5的Geolocation API");
                    window.location.href = "?d=t";
                }
            }

            function success(position) {
                //alert("緯度：" + position.coords.latitude + ",經度：" + position.coords.longitude);
                if (getUrlVars()["v"] != undefined) {
                    //window.location.href = "?v=t&lat=" + position.coords.latitude + "&lon=" + position.coords.longitude
                }
                else {
                    //window.location.href = "?lat=" + position.coords.latitude + "&lon=" + position.coords.longitude
                }
            }
            function error(e) {
                console.log(e.message);
            }
            if (TY_COUNT[1] == 0) {
                //document.getElementById("tyinfobutton").enable = false
                $("#tyinfobutton").remove()
            }
        }
    </script>

    <%--<script src="Improve_Table_dark.js"></script>--%>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <%--<div style="width: 99999999px; height: 99999999px; z-index: 4" class="bg-dark removeMe"></div>--%>
        <div class="h-100 container">
            <div class="text-center h2">
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

            <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist" hidden="hidden">
                <li class="nav-item">
                    <a class="nav-link" id="pills-cwb-tab" data-toggle="pill" href="#pills-cwb" role="tab" aria-controls="pills-cwb" aria-selected="false">CWB's weather data</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-home-tab" data-toggle="pill" href="#pills-home" role="tab" aria-controls="pills-weatherbit">Forecast(Legacy)</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-profile-tab" data-toggle="pill" href="#pills-openweathermap" role="tab" aria-controls="pills-openweathermap" aria-selected="false">OpenWeatherMap's api(Legacy)</a>
                </li>
            </ul>

            <div class="tab-content" id="pills-tabContent">
                <div class="tab-pane fade show active" id="pills-cwb" role="tabpanel" aria-labelledby="pills-cwb-tab">
                    <div class=" form-group" style="height: 300px; width: 100%" visible="false" runat="server" id="ChartCWBDiv">
                <%--        <small>**They(Central Weather Bureau) update their data every 6 hours. Yep 6 hours, I tried to report it to let it upate every 3 hours,but nothing happened...😥**</small>--%>
                        <canvas id="ChartCWB" runat="server"></canvas>
                    </div>
                    <div class=" justify-content-center form-group w-50 text-center d-flex align-content-center mx-auto">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="custom-select" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="tab-pane fade" id="pills-weatherbit" role="tabpanel" aria-labelledby="pills-weatherbit-tab">
                    <div class="card d-flex align-items-lg-center justify-content-center form-group" style="border-color: transparent">
                        <h1 class="card-title h1" style="margin: 0px">
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                        </h1>
                        <div class="card-text h5">
                            <asp:Label ID="Label5" runat="server" Text="">
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="pills-openweathermap" role="tabpanel" aria-labelledby="pills-openweathermap-tab">
                    <div class=" form-group" style="height: 300px; width: 100%">
                        <canvas id="ChartLegacy"></canvas>
                    </div>
                </div>
            </div>
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <div class="justify-content-center form-group btn-group w-100 text-center">
                <a class="btn btn-outline-danger form-group" href="../v3/"><%=WorkStatus.Properties.LanguageResource.GoToOlderVersion %></a>
                <button class="btn btn-outline-success form-group" type="button" data-toggle="collapse" data-target="#typhoonstatus" aria-expanded="false" aria-controls="collapseExample" id="tyinfobutton">
                    <%=WorkStatus.Properties.LanguageResource.Ty_info %></button>
                <a href="?changetheme=true" class="btn btn-outline-info form-group"><%=WorkStatus.Properties.LanguageResource.SwitchTheTheme %></a>
            </div>
            <div class="collapse" id="typhoonstatus">
                <div class="card" style="border-color: #ffc107">
                    <div class="card-body">
                        <div id="typhoonstatuscard" class="text-light">
                        </div>
                        <div class="text-center">
                            <img src="https://fonts.gstatic.com/s/i/materialiconsoutlined/report_problem/v1/24px.svg" id="tyimg" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <footer class="small text-center form-group"><small class="text-muted">Build : δ-0.1.1 Canary</small></footer>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <script>
            $(".grecaptcha-badge").remove()</script>
    </form>
</body>
</html>