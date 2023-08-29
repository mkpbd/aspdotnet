<<<<<<< Updated upstream
﻿// A $( document ).ready() block.
$(document).ready(function () {
    $("#btnAdd").click(function () {
        // debugger;
        $.ajax({
            type: "POST",
            url: "Customer/OnPostAdd",
            data: $('form').serialize(),
            contentType: 'application/x-www-form-urlencoded',
            dataType: "json",

            success: function (msg) {
                if ($('#btnAdd').hasClass('btn-update')) {
                    $('table#CustomerTable tr#' + msg.id).find("td").eq(1).html(msg.name);
                    $('table#CustomerTable tr#' + msg.id).find("td").eq(2).html(msg.email);
                    $('table#CustomerTable tr#' + msg.id).find("td").eq(3).html(msg.mobileNumber);

                    $("#btnAdd").removeClass('btn-update');
                }

                else {
                    loadCustomerRecords(); //refresh the table
                }
            }



        });
    });


    //    $("#btnAdd").click(function () {
    //        debugger;

    //        $.ajax({
    //            type: "POST",
    //            url: "/customer/OnPostAdd",
    //            data: $('form').serialize(),
    //            contentType: 'application/x-www-form-urlencoded',
    //            dataType: "json",
    //            headers:
    //            {
    //                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
    //            },
    //            success: function (msg) {

    //                if ($('#btnAdd').hasClass('btn-update')) {
    //                    $('table#CustomerTable tr#' + msg.id).find("td").eq(1).html(msg.name);
    //                    $('table#CustomerTable tr#' + msg.id).find("td").eq(2).html(msg.email);
    //                    $('table#CustomerTable tr#' + msg.id).find("td").eq(3).html(msg.mobileNumber);

    //                    $("#btnAdd").removeClass('btn-update');
    //                }

    //                else {
    //                    loadCustomerRecords(); //refresh the table
    //                }
    //                $('#customerModel').modal('hide'); //hide the modal
    //            }
    //        });



    function loadCustomerRecords() {
        $.ajax({
            type: "GET",
            url: "Customer/OnGetRecord",
            contentType: 'application/x-www-form-urlencoded',
            dataType: "json",
            headers:
            {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            success: function (msg) {
                DrawTable(msg);
            }
        });

    }


            function DrawTable(response) {
                $.each(response, function (i, item) {
                    var $tr = $('<tr id="' + item.id + '">').append(
                        $('<td>').text(item.name),
                        $('<td>').text(item.email),
                        $('<td>').text(item.mobileNumber),
                        $('<td>').html('<button type="button" args="' + item.id + '" class="btn-edit btn btn-success">Edit</button>'),
                        $('<td>').html('<button type="button" args="' + item.id + '" class="btn-delete btn btn-danger">Delete</button>')
                    ).appendTo('#CustomerTable');
                });
            }



            $(document).on('click', '.btn-edit', function () {
                var id = $(this).attr('args');

                $.ajax({
                    type: "GET",
                    url: "Customer/OnGetById",
                    data: { "id": id },
                    contentType: 'application/x-www-form-urlencoded',
                    dataType: "json",
                    headers:
                    {
                        "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
                    },
                    success: function (msg) {
                        $("#name").val(msg.name);
                        $("#email").val(msg.email);
                        $("#mobileNumber").val(msg.mobileNumber);
                        $("#id").val(msg.id);
                        $("#btnAdd").addClass("btn-update"); //add the btn-update class to modal save button so that we can make diferrent between add or update action

                        $('#customerModel').modal('show');
                    }
                });

            });

            $(document).on('click', '.btn-delete', function () {
                var id = $(this).attr('args');
                $.ajax({
                    type: "POST",
                    url: "Customer/OnPostDelete",
                    data: { "id": id },
                    contentType: 'application/x-www-form-urlencoded',
                    dataType: "json",
                    headers:
                    {
                        "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
                    },
                    success: function (msg) {
                        $('table#CustomerTable tr#' + id).remove();
                    }
                });
            });

    loadCustomerRecords();
});
