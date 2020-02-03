$(document).ready(function () {
    $("table").addClass("table table-hover")
    $("table").removeAttr("rules")
    $("tr").removeAttr("style")
    $("th").removeAttr("width")
    $("td").removeAttr("width")
    $("td").removeAttr("align")
    $("td").removeAttr("valign")
    $('h2').replaceWith($('h2').text());
    $("td[colspan=2] span br").remove()
    $("td[colspan=2]").attr("colspan", "1")
    $("td[colspan=1]").before("<td class='whole-taiwan'></td>")
    $("td[colspan=1]").parent().append('<td><div class="d-flex align-items-center"><div class="bg-success rounded-circle" style="width:13px;height:13px"></div></div></div></td>')
    $('tbody:nth-child(1)').replaceWith($('<thead>' + $('tbody:nth-child(1)').html() + '</thead>'));
    $("tr td[colspan=3]").parent().remove()
    $("tr th").text("")
    $("tr.Table_Head td").text("")
    $("#city_Name").replaceWith("<th id='city_Name'>" + $("#city_Name").text() + "</th>")
    $("#StopWorkSchool_Info").replaceWith("<th id='StopWorkSchool_Info'>" + $("#StopWorkSchool_Info").text() + "</th>")
    $("thead tr").append("<th id='Status'></th>");
    $("td[headers=StopWorkSchool_Info]").each(function () {
        if ($(this).html().indexOf("#FF0000") != -1) {
            var i = 0
            if ($(this).parent().children().length != 3) {
                i = i + 1
                $(this).parent().append('<td><div class="d-flex align-items-center"><div class="spinner-grow spinner-grow-sm text-warning" role="status"></div></div></td>')
            }
        }
        else {
            $(this).parent().append('<td><div class="d-flex align-items-center"><div class="bg-success rounded-circle" style="width:13px;height:13px"></div></div></div></td>')
        }
    });
    $("span").removeAttr("color")
    $("font").removeAttr("color")
});
//if ($(this).children("td")[1].innerHTML.indexOf("Work and Classes Cancelled") != -1 |
//    $(this).children("td")[1].innerHTML.indexOf("Criteria Met for Cancellation of Work and Classes") != -1 |
//    $(this).children("td")[1].innerHTML.indexOf("已達") != -1) {
//    var i = 0
//    if ($(this).parent().parent().children().length != 3) {
//        i = i + 1
//        $(this).parent().parent().append('<td><div class="d-flex align-items-center"><div class="spinner-grow spinner-grow-sm text-warning" role="status"></div></div></td>')
//    }
//}
//else {
//    $(this).parent().parent().append('<td><div class="d-flex align-items-center"><div class="bg-success rounded-circle" style="width:13px;height:13px"></div></div></div></td>')
//}

    //$('tr').each(function (index, value) {
    //    console.log($(this).attr('color'));
    //    $('font:nth-child(' + String(index) + ')').replaceWith($('<span'+ index+'>' + $('font:nth-child(' + String(index) + ')').text() + '</span>'));
    //});
    //$.extend({
    //    replaceTag: function (element, tagName, withDataAndEvents, deepWithDataAndEvents) {
    //        var newTag = $("<" + tagName + ">")[0];
    //        // From [Stackoverflow: Copy all Attributes](http://stackoverflow.com/a/6753486/2096729)
    //        $.each(element.attributes, function () {
    //            newTag.setAttribute(this.name, this.value);
    //        });
    //        $(element).children().clone(withDataAndEvents, deepWithDataAndEvents).appendTo(newTag);
    //        return newTag;
    //    }
    //})
    //$.fn.extend({
    //    replaceTag: function (tagName, withDataAndEvents, deepWithDataAndEvents) {
    //        // Use map to reconstruct the selector with newly created elements
    //        return this.map(function () {
    //            return jQuery.replaceTag(this, tagName, withDataAndEvents, deepWithDataAndEvents);
    //        })
    //    }
    //})
    //$("font").each(function () {
    //    $(this).clone().replaceTag("span").appendTo($(this).parent()).text(this.innerText).removeAttr("color");
    //});
    //if ($("td[headers=StopWorkSchool_Info] span").count() != 1) {
    //    $(this).text($(this).text() + "<br />")
    //}
    //$("td[headers=StopWorkSchool_Info] span").each(function () {
    //    if ($(this).length != 1) {
    //        $(this).clone().replaceTag("span").appendTo($(this).parent()).text(this.innerText).removeAttr("color");
    //    }
    //});
    //$("font").remove()