$(document).ready(function () {

    $.ajax({
        type: "POST",
        url: "NewStudent.aspx/getayidadm",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            //  $("[id*=ddl_year]").empty().append('<option selected="selected" value="0">--select--</option>');
            $.each(r.d, function () {
                $("[id*=ddl_year]").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            hasError = true;
            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });
    $("[id*=ddl_year]")[0].selectedIndex = 1;
});

$("[id*='txt_stud_id']").keypress(function (e) {
    //if ($("[id*='txt_stud_id']").val() !="") {
    //    load_data();
    //}
    var key = e.which;
    if (key == 13)  // the enter key code
    {
        e.preventDefault();
        if ($("[id*='txt_stud_id']").val() != "") {
            load_data();
        }
    }
});


function load_data() {
    $.ajax({
        type: "POST",
        url: "Student_transfer_payment.aspx/load_data",
        data: '{ayid:"' + $("[id*=ddl_year]").val() + '",stud_id:"' + $("[id*='txt_stud_id']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            if (r.d.length > 0 && r.d[0].message == "Found") {
                $("[id*=gridpanel]").show(900);
                var gripanel = document.getElementById('gridpanel');
                gripanel.style.visibility = 'visible';
                gripanel.style.display = 'block';
                $("[id*=grid_studentadm]").empty();
                $("[id*=grid_studentadm]").append("<thead><tr class='alert alert-info'> <th>Student ID</th><th>Student Name</th><th style='display:none'>Group ID</th><th>Group Title</th><th>Transfer And Cancel</th><th>Fees</th></tr></thead>");    //<th><input type=button Text=Edit'> Edit</th><th> Delete</th>
                $("[id*=grid_studentadm]").append("<tbody>");
                for (var j = 0; j < r.d.length; j++) {
                    var btn_name = "Transfer Admission";
                    if (r.d[j].Transfer != "") {
                        btn_name = "Cancel Admission"
                    }
                    if (btn_name == "Cancel Admission") { $("[id*=grid_studentadm]").append("<tr><td>" + r.d[j].stud_id + "</td><td>" + r.d[j].Name + "</td><td style='display:none'>" + r.d[j].group_id + "</td><td>" + r.d[j].group_name + "</td><td><input type='button' class='btn btn-success' id='btnadd_" + j + "' Value='" + btn_name + "' style='width:100%'></td><td><input style='display:none' type='button' class='btn btn-warning' style='width:100%' id='btnfee_" + j + "' Value='Pay Fees'></td></tr>")}
                    else { $("[id*=grid_studentadm]").append("<tr><td>" + r.d[j].stud_id + "</td><td>" + r.d[j].Name + "</td><td style='display:none'>" + r.d[j].group_id + "</td><td>" + r.d[j].group_name + "</td><td><input type='button' class='btn btn-success' id='btnadd_" + j + "' Value='" + btn_name + "' style='width:100%'></td><td><input type='button' class='btn btn-warning' style='width:100%' id='btnfee_" + j + "' Value='Pay Fees'></td></tr>")}
                    
                }
                $("[id*=grid_studentadm]").append("</tbody>");
            }
            else {
                $("[id*=grid_studentadm]").remove();
                $.notify(r.d[0].message, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        },
        error: function (r) {

        }
    });
}



$("[id*=grid_studentadm]").on('click', 'input[type="button"]', function () {
    if ($(this).attr("id").startsWith('btnadd')) {
        var $td = $(this).closest('tr').children('td');
        var exec = false;
        var stud_id = $td.eq(0).text();
        var group_id = $td.eq(2).text();
        var btntext = $("[id*=" + $(this).attr("id") + "]").val();
        var mode = "";
        $.ajax({
            type: "POST",
            url: "Student_transfer_payment.aspx/check_seats",
            data: '{ayid:"' + $("[id*=ddl_year]").val() + '",group_id:"' + group_id + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (r) {
                if (btntext.includes("Transfer")) {
                    mode = "transfer";
                    if (r.d.length > 0) {
                        if (r.d == 'available') {
                            exec = true;
                        }
                        else if (r.d == 'full') {
                            var prompt = confirm("Intake for following Group is full. Do you want to Continue?");
                            if (prompt == true) {
                                exec = true;
                            } else {
                                exec = false;
                            }
                        }
                        else if (r.d.includes("Intake") == true) {
                            $.notify(r.d, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            exec = false;
                        }
                        else {
                            exec = false;
                        }
                    }
                    else {
                        exec = false;
                    }

                }
                else {
                    mode = "Cancel";
                    exec = true;
                }


                if (exec == true) {
                    $.ajax({
                        type: "POST",
                        url: "Student_transfer_payment.aspx/save_data",
                        data: '{ayid:"' + $("[id*=ddl_year]").val() + '",stud_id:"' + stud_id + '",group_id:"' + group_id + '",mode:"' + mode + '",emp_id:"' + empId + '"}',
                        contentType: "application/json; charset=utf-8",
                        success: function (r) {
                            if (r.d.length > 0 && r.d[0].message != "") {
                                if (r.d[0].message.includes("not")) {
                                    $.notify(r.d[0].message, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

                                }
                                else {
                                    $.notify(r.d[0].message, { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                                }
                            }
                            //load_data();
                            $("[id*=grid_studentadm]").remove();

                        },
                        error: function (r) {
                            $.notify(r.d[0].message, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

                        }
                    });
                }
            },
            error: function (r) {
                $.notify(r.d[0].message, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });

    }
    else {
        var $td = $(this).closest('tr').children('td');
        var sessionid = $td.eq(0).text();
        PageMethods.Setsession(sessionid);
        window.open("../../Staff/Fee/FeeEntry_New.aspx", "_blank");
    }
});