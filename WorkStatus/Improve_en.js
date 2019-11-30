$("#typhoonstatuscard").append(TY_LIST_1["E"])
$('.accordion-toggle').replaceWith('<div>' + $(".accordion-toggle").html() + '</div>')
$('h4').replaceWith('<h5 class="card-title">' + $("h4").html() + '</h5>').addClass("card-title")
$('.panel-collapse').replaceWith('<div>' + $(".panel-collapse").html() + '</div>')
$("#tyimg").attr('src', 'https://www.cwb.gov.tw/' + '/Data/' + DataPath + 'Download_PTA_' + TY_DataTime + '_enus.png');