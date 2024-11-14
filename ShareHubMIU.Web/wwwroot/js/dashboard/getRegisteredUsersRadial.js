﻿$(document).ready(function () {
    loadRegisteredusersRadialChart();
});

function loadRegisteredusersRadialChart(){
    $(".registereduser-chart-spinner").show();

    $.ajax({
        url: "/Dashboard/GetRegisteredUserRadialChartData",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            document.querySelector("#spanRegisteredUserCount").innerHTML = data.totalCount;

            var sectionCurrentCount = document.createElement("span");

            if (data.hasRatioIncreased) {
                sectionCurrentCount.className = "text-success me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-up-right-circle me-1"></i><span>' + data.countInCurrentMonth + '</span>';
            }
            else {
                sectionCurrentCount.className = "text-danger me-1";
                sectionCurrentCount.innerHTML = '<i class="bi bi-arrow-down-right-circle me-1"></i><span>' + data.countInCurrentMonth + '</span>';
            }

            document.querySelector("#sectionRegisteredUserCount").append(sectionCurrentCount);
            document.querySelector("#sectionRegisteredUserCount").append("since last month");

            loadRadialBarChart("registeredUsersRadialChart", data);

            $(".registereduser-chart-spinner").hide();
        }
    })
};

