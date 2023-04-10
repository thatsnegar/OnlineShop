function tip1() {
    document.querySelector(".tip-1").style.display = "block";
    document.querySelector(".tip-2").style.display = "none";
}
function tip2() {
    document.querySelector(".tip-2").style.display = "block";
    document.querySelector(".tip-1").style.display = "none";
}
function loading() {
    document.querySelector("#loading").classList.add("notactive");
}

// Clock
console.log("This is clock.js");

function updateClock() {
    // Get the current date
    let currentTime = new Date();

    // Extract hour, minute and seconds from the date
    let currentHour = currentTime.getHours();
    let currentMinutes = currentTime.getMinutes();
    let currentSeconds = currentTime.getSeconds();

    // Pad 0 if minute or second is less than 10 (single digit)
    currentMinutes = (currentMinutes < 10 ? "0" : "") + currentMinutes;
    currentSeconds = (currentSeconds < 10 ? "0" : "") + currentSeconds;

    // Choose AM/PM as per the time of the day
    let timeOfDay = currentHour < 12 ? "AM" : "PM";

    // Convert railway clock to AM/PM clock
    //   currentHour = currentHour > 12 ? currentHour - 12 : currentHour;
    //   currentHour = currentHour == 0 ? 12 : currentHour;

    // Prepare the time string from hours, minutes and seconds
    let currentTimeStr =
        currentHour + ":" + currentMinutes + ":" + currentSeconds + " ";

    // Insert the time string inside the DOM
    document.getElementById("clock").innerHTML = `<span>${currentTimeStr}</span>`;
}

setInterval(updateClock, 1000);


// Date
let today = new Date().toLocaleDateString('fa-IR');

document.getElementById("demo").innerHTML = today
    

//var sundte = new Date();
//var yeardte = sundte.getFullYear();
//var monthdte = sundte.getMonth();
//var dtedte = sundte.getDate();
//var daydte = sundte.getDay();
//var sunyear;
//switch (daydte) {
//    case 0:
//        var today = "يکشنبه";
//        break;
//    case 1:
//        var today = "دوشنبه";
//        break;
//    case 2:
//        var today = "سه شنبه";
//        break;
//    case 3:
//        var today = "چهارشنبه";
//        break;
//    case 4:
//        var today = "پنجشنبه";
//        break;
//    case 5:
//        var today = "جمعه";
//        break;
//    case 6:
//        var today = "شنبه";
//        break;
//}
//switch (monthdte) {
//    case 0:
//        sunyear = yeardte - 622;
//        if (dtedte <= 20) {
//            var sunmonth = "دي";
//            var daysun = dtedte + 10;
//        } else {
//            var sunmonth = "بهمن";
//            var daysun = dtedte - 20;
//        }
//        break;
//    case 1:
//        sunyear = yeardte - 622;
//        if (dtedte <= 19) {
//            var sunmonth = "بهمن";
//            var daysun = dtedte + 11;
//        } else {
//            var sunmonth = "اسفند";
//            var daysun = dtedte - 19;
//        }
//        break;
//    case 2:
//        {
//            if ((yeardte - 621) % 4 == 0) var i = 10;
//            else var i = 9;
//            if (dtedte <= 20) {
//                sunyear = yeardte - 622;
//                var sunmonth = "اسفند";
//                var daysun = dtedte + i;
//            } else {
//                sunyear = yeardte - 621;
//                var sunmonth = "فروردين";
//                var daysun = dtedte - 20;
//            }
//        }
//        break;
//    case 3:
//        sunyear = yeardte - 621;
//        if (dtedte <= 20) {
//            var sunmonth = "فروردين";
//            var daysun = dtedte + 11;
//        } else {
//            var sunmonth = "ارديبهشت";
//            var daysun = dtedte - 20;
//        }
//        break;
//    case 4:
//        sunyear = yeardte - 621;
//        if (dtedte <= 21) {
//            var sunmonth = "ارديبهشت";
//            var daysun = dtedte + 8;
//        } else {
//            var sunmonth = "خرداد";
//            var daysun = dtedte - 21;
//        }

//        break;
//    case 5:
//        sunyear = yeardte - 621;
//        if (dtedte <= 21) {
//            var sunmonth = "خرداد";
//            var daysun = dtedte + 8;
//        } else {
//            var sunmonth = "تير";
//            var daysun = dtedte - 21;
//        }
//        break;
//    case 6:
//        sunyear = yeardte - 621;
//        if (dtedte <= 22) {
//            var sunmonth = "تير";
//            var daysun = dtedte + 10;
//        } else {
//            var sunmonth = "مرداد";
//            var daysun = dtedte - 21;
//        }
//        break;
//    case 7:
//        sunyear = yeardte - 621;
//        if (dtedte <= 22) {
//            var sunmonth = "مرداد";
//            var daysun = dtedte + 8;
//        } else {
//            var sunmonth = "شهريور";
//            var daysun = dtedte - 21;
//        }
//        break;
//    case 8:
//        sunyear = yeardte - 621;
//        if (dtedte <= 22) {
//            var sunmonth = "شهريور";
//            var daysun = dtedte + 9;
//        } else {
//            var sunmonth = "مهر";
//            var daysun = dtedte + 22;
//        }
//        break;
//    case 9:
//        sunyear = yeardte - 621;
//        if (dtedte <= 22) {
//            var sunmonth = "مهر";
//            var daysun = dtedte + 8;
//        } else {
//            var sunmonth = "آبان";
//            var daysun = dtedte - 22;
//        }
//        break;
//    case 10:
//        sunyear = yeardte - 621;
//        if (dtedte <= 21) {
//            var sunmonth = "آبان";
//            var daysun = dtedte + 8;
//        } else {
//            var sunmonth = "آذر";
//            var daysun = dtedte - 21;
//        }

//        break;
//    case 11:
//        sunyear = yeardte - 621;
//        if (dtedte <= 19) {
//            var sunmonth = "آذر";
//            var daysun = dtedte + 9;
//        } else {
//            var sunmonth = "دي";
//            var daysun = dtedte + 21;
//        }
//        break;
//}
//document.getElementById("demo").innerHTML =
//    //   "امروز " +
//    today +
//    "&nbsp;" +
//    [daysun + 1] +
//    "&nbsp;" +
//    sunmonth +
//    "&nbsp;" +
//    sunyear;

/*****************************************************
*               File Pound JS                *
*****************************************************/
/*
We want to preview images, so we need to register the Image Preview plugin
*/

// Page Category
$('.option').click(function () {
    $(this).siblings('.option-list').toggleClass("active");
});

/* Function to check for any selected checkboxes and indicate
   this by highlighting the selected item's parents (in case
   the list isn't expanded to see something is selected within it)'*/
function updateParentFacets() {

    // NOTE: It would be better if this function removed the has-selected class first, and then just found each checked input, adding a has-selected class to their iossearchfacets li parents. Rather than doing a find on each parent.

    $(".iossearchfacets li").each(function (i) {

        if ($(this).find("input:checked").length > 0) {
            $(this).addClass("has-selected");
        }
        else {
            $(this).removeClass("has-selected");
        }
    });
}

/* Go through facets and identify those that have children */
$(".iossearchfacets li").each(function () {

    if ($(this).children("ul").length > 0) {
        $(this).addClass("has-children");
    }
});

/* When clicking a facet, identify whether the name or input checkbox has been clicked. If it's not the checkbox and it's an element with children -> toggle the open class. Otherwise, update the parent facets status. */
$(".iossearchfacets li").click(function (e) {

    e.stopPropagation();

    var target = $(e.target);
    if (!target.is("input") && $(this).hasClass("has-children")) {
        $(this).toggleClass("open")
    }
    else {
        updateParentFacets();
        $(document).trigger("MyEvent:SearchFacetsUpdated");
    }
});





// Event listener waiting for search facets to be updated before updating the markup for removeable support (Facets shown in 'Currently selected' list. 
$(document).on("MyEvent:SearchFacetsUpdated", {

}, function (event) {

    // clear currently selected html
    $("#removeableFacets").html("");

    // find each selected facet checkbox and append to 'currently selected' html
    $(".facetselector input:checked").each(function (i) {

        $("#removeableFacets").append("<span class='removeable-facet' data-value='" + $(this).val() + "'>" + $(this).parent(".facetselector").text() + "</span>")
    });

    /* On click of a removeable facet, we just simulate a click
       */
    $(".removeable-facet").click(function () {

        var facetValue = $(this).data("value");
        $(".facetselector input[value='" + facetValue + "']").click();
    });

    $('input[type="checkbox"]').on('change', function () {

        $(this).parent().parent().siblings().find('input[type="checkbox"]').prop('checked', false)
        $(this).prop('checked', !Boolean($(this).attr('checked')));
    })

});


function valueChanged() {
    if ($('.custom-check').is(":checked")) {
        $(".is-check-details").removeClass("d-none");
    }
    else
         $(".is-check-details").addClass("d-none");
}

/*repear*/


