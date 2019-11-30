$(document).ready(function () {
    $(".Table_Head").addClass("thead-light")
    $("tbody:nth-child(1) tr").addClass("thead-light")
    $("table").removeAttr("table-light")
    //$("tr").attr("style","background-color:#f8f9fa")
    $("#card").children().addClass("bg-light")
});