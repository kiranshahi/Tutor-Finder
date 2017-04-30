/// <reference path="jquery-1.9.1.intellisense.js" />



//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();
});

//Load Data function
function loadData() {
    $.ajax({
        url: "/Timing/List",
        type: "GET",
        contentType: "json",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
              
                html += '<td>' + item.FromTime + '</td>';
                html += '<td>' + item.ToTime + '</td>';
              
                html += '<td><a href="#" onclick="return getbyID(' + item.ScheduleId + ')">Edit</a> | <a href="#" onclick="Delele(' + item.ScheduleId + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function 
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj =
        {
          
            FromTime: $('#FromTime').val(),
            ToTime: $('#ToTime').val(),
            TutorId: $('#TutorId').val(),
            Status: $('#Status').val()
        };
    $.ajax({
        url: "/Timing/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID
function getbyID(ID) {


    //$('#Name').css('border-color', 'lightgrey');
    //$('#Age').css('border-color', 'lightgrey');
    //$('#State').css('border-color', 'lightgrey');
    //$('#Country').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Timing/getbyID/" + ID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            debugger;
           
            $('#FromTime').val(result.FromTime);
            $('#ToTime').val(result.ToTime);
            $('#ScheduleId').val(result.ScheduleId);
           

            $('#myModal').modal('show')
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        ScheduleId: $('#ScheduleId').val(),
        FromTime: $('#FromTime').val(),
        ToTime: $('#ToTime').val(),
        TutorId: $('#TutorId').val(),
        Status: $('#Status').val()
    };
    $.ajax({
        url: "/Timing/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ScheduleId').val("");
            $('#FromTime').val("");
            $('#ToTime').val("");
          
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Timing/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes
function clearTextBox() {
   
    $('#FromTime').val("");
    $('#ToTime').val("");
   
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    //$('#Name').css('border-color', 'lightgrey');
    //$('#Age').css('border-color', 'lightgrey');
    //$('#State').css('border-color', 'lightgrey');
    //$('#Country').css('border-color', 'lightgrey');
}
//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#FromTime').val().trim() == "") {
        $('#FromTime').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FromTime').css('border-color', 'lightgrey');
    }
    if ($('#ToTime').val().trim() == "") {
        $('#ToTime').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ToTime').css('border-color', 'lightgrey');
    }
    
    return isValid;
}