/// <reference path="jquery-1.9.1.intellisense.js" />



//Load Data in Table when documents is ready
//Load Data in Table when documents is ready
$(document).ready(function () {
    getbyID(ID);
});
function getbyID(ID) {
    $.ajax({
        url: "/Tutor/getbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result)
        {
         

            $('#FromTime').val(result.FromTime);
            $('#ToTime').val(result.ToTime);
            $('#ScheduleId').val(result.ScheduleId);


            $('#myModal').modal('show')
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}