$(document).ready(function () {
    $.extend({
        replaceTag: function (currentElem, newTagObj, keepProps) {
            var $currentElem = $(currentElem);
            var i, $newTag = $(newTagObj).clone();
            if (keepProps) {//{{{
                newTag = $newTag[0];
                newTag.className = currentElem.className;
                $.extend(newTag.classList, currentElem.classList);
                $.extend(newTag.attributes, currentElem.attributes);
            }//}}}
            $currentElem.wrapAll($newTag);
            $currentElem.contents().unwrap();
            // return node; (Error spotted by Frank van Luijn)
            return this; // Suggested by ColeLawrence
        }
    });

    $.fn.extend({
        replaceTag: function (newTagObj, keepProps) {
            // "return" suggested by ColeLawrence
            return this.each(function () {
                jQuery.replaceTag(this, newTagObj, keepProps);
            });
        }
    });

    $("table").addClass("table table-hover table-light")
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
    $("td[colspan=1]").parent().append('<td><div class="d-flex align-items-center"><div class="spinner-grow spinner-grow-sm text-success" role="status"></div></div></td>')
    $('tbody:nth-child(1)').replaceWith($('<thead>' + $('tbody:nth-child(1)').html() + '</thead>'));
    $("tr td[colspan=3]").parent().remove()

    $(".color_Eggyolk").remove()
    $(".Table_Head").remove()
    $("tr").each(function () {
        var card = $(".empty").clone().removeClass("empty")
        $(this).children().children()[0].className = "card-title h5"
        $(this).children("td")[1].className = "card-text"
        if ($(this).children("td")[1].innerHTML.indexOf("No Work and Classes Cancelled。") == -1) {
            if ($(this).html().indexOf("#FF0000") != -1) {
                card.addClass("border border-warning")
            }
            else {
                card.addClass("border border-success")
            }
        }
        else {
            card.addClass("border border-success")
        }
        card.addClass("card form-group").append($(".empty").clone().removeClass("empty").addClass("card-body").append($(this).children()[0].innerHTML.replace("span", "h5")).append($(".emptyp").clone().removeClass("emptyp").addClass("card-text").append($(this).children("td")[1].innerHTML)))
        $("#card").append(card)
    });
    $("tr th").text("")
    $("tr.Table_Head td").text("")
    $("#city_Name").replaceWith("<th id='city_Name'>" + $("#city_Name").text() + "</th>")
    $("#StopWorkSchool_Info").replaceWith("<th id='StopWorkSchool_Info'>" + $("#StopWorkSchool_Info").text() + "</th>")
    $("thead tr").append("<th id='Status'></th>");
    $("span").removeAttr("color")
    $("font").removeAttr("color")
    $("table").remove()
});