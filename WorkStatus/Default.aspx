<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WorkStatus.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=WorkStatus.Properties.LanguageResource.ws %> | v4</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.slim.min.js"></script>
    <script src="https://www.cwb.gov.tw/Data/js/typhoon/TY_NEWS-Data.js"></script>
    <script src="https://www.cwb.gov.tw/V8/assets/js/TY_NEWS.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.3.1/js/bootstrap.min.js"></script>
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
        if (getUrlVars()["notverify"] != undefined) {
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
            if (getUrlVars()["lon"] == undefined & getUrlVars()["lat"] == undefined & true == false) {
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
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="h-100 container w-100">
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
                        <canvas id="ChartCWB" runat="server"></canvas>
                    </div>
                    <div class=" justify-content-center form-group w-50 text-center d-flex align-content-center mx-auto">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="custom-select" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                </div>
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <div class="justify-content-center form-group btn-group w-100 text-center">
                <button class="btn btn-outline-warning form-group" type="button" data-toggle="collapse" data-target="#typhoonstatus" aria-expanded="false" aria-controls="collapseExample" id="tyinfobutton">
                    <%=WorkStatus.Properties.LanguageResource.Ty_info %></button>
                <a href="?changetheme=true" class="btn btn-outline-info form-group"><%=WorkStatus.Properties.LanguageResource.SwitchTheTheme %></a>
                <a href="https://github.com/Poyi-Hong/Work-Status" class="btn btn-outline-success form-group" target="_blank">Github <%=WorkStatus.Properties.LanguageResource.link %></a>
            </div>
            <div class="collapse" id="typhoonstatus">
                <div class="card" style="border-color: #ffc107">
                    <div class="card-body">
                        <div id="typhoonstatuscard" class="text-light">
                        </div>
                        <div class="text-center">
                            <img src="" id="tyimg" class="img-fluid" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <footer class="small text-center form-group"><small class="text-muted">Build : δ-0.2.1 Canary</small></footer>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>