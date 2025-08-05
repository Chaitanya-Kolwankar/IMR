//document.getElementById("ddlfaculty").disabled = true;
var sessionid;
var sessionformid;
var oldstudid;
var Course = "";
var ddlcourse;
var ddlfaculty;
var ddlgroup;
var fyid;
var all_amt = "";
var transferflag = 0;
var newgroup = "";
var oldfees = "";
var paidfees = "";
var Category = "";
var sum = "";
$(document).ready(function () {

    //$.ajax({
    //    type: "POST",
    //    url: "NewStudent.aspx/getayidadm",
    //    data: '{}',
    //    contentType: "application/json; charset=utf-8",
    //    success: function (r) {
    //        //  $("[id*=ddlyear]").empty().append('<option selected="selected" value="0">--select--</option>');
    //        $.each(r.d, function () {
    //            $("[id*=ddlyear]").append($("<option></option>").val(this['Value']).html(this['Text']));
    //        });
    //    },
    //    error: function () {
    //        hasError = true;
    //        debugger;
    //        $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    //    }
    //});



    $("[id*=grid_studentadm]").empty();


    $.ajax({
        type: "POST",
        url: "NewStudent.aspx/getfaculty",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        async:false,
        success: function (r) {
            $("[id*=ddlfaculty]").empty().append('<option selected="selected" value="0">--select--</option>');
            $.each(r.d, function () {
                $("[id*=ddlfaculty]").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            hasError = true;
            debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });

    //var btcnf = document.getElementById('btn_confirm');
    //btcnf.style.visibility = 'visible';
    //btcnf.style.display = 'block';



    //var panel = document.getElementById('divbank');
    //panel.style.visibility = 'hidden';
    //panel.style.display = 'none';

    var panel2 = document.getElementById('divbank2');
    panel2.style.visibility = 'hidden';
    panel2.style.display = 'none';

    //  $("[id*='txt_formid']").focus();
    // $("[id*=txt_feespay]").prop('disabled', true);
    $("[id*=txt_receiptno]").prop('disabled', true);
    $("[id*=dobremark]").prop('disabled', true);
    $("[id*=txt_auth]").prop('disabled', true);

    $("[id*=chqdt]").prop('disabled', true);
    $("[id*=txt_bankname]").prop('disabled', true);
    $("[id*=txt_branchname]").prop('disabled', true);


    var gripanel = document.getElementById('gridpanel');
    gripanel.style.visibility = 'hidden';
    gripanel.style.display = 'none';


    var panel3 = document.getElementById('divbank');
    panel3.style.visibility = 'hidden';
    panel3.style.display = 'none';
    // }
    var panel1 = document.getElementById('divcard');
    panel1.style.visibility = 'hidden';
    panel1.style.display = 'none';

    jQuery('[id*=birthdate]').datetimepicker(
           {
               timepicker: false,
               format: 'd-M-Y h:m:s'
           });


    disable();
});
//$("[id*=divbank]").show();

$(document).ready(function () {
    if (stud_form_no != "") {
        $("[id*='txt_formid']").val(stud_form_no);
        $("[id*='ddlyear']").val(ayid);
        $("[id*='txt_formid']").trigger('change');
       
   
    }
    else {

    }
});



$("[id*='txt_formid']").change(function () {
    //$("[id*='txt_formid']").on('keydown', function (e) {
    // if (e.which === 13) {
    $("[id*=grid_studentadm]").empty();
    //  $("[id*='lblstudid']")[0].innerText = "";
    var sel = $("[id*='ddlfaculty']");
    sel[0].selectedIndex = 0;
    $('[data-toggle="tooltip"]').tooltip();

    var isValid = true;
    isValid = validate();
    //isValid2 = validate2();

    if (isValid == false) {

        $.notify("Please Enter valid Form ID !", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        clear();
        clearfee();

    }
    else {
        $("[id*='txt_formid']").css("border-color", "#ccc");
        $.ajax({
            type: "POST",
            url: "NewStudent.aspx/Admissionform",
            data: '{formid:"' + $("[id*='txt_formid']").val() + '",year:"' + $("[id*='ddlyear']").val() + '"}',  //{fid:"' + $("[id*='ddlfaculty']").val() + '"
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {

                sessionformid = $("[id*='txt_formid']").val();
                if (data.d.length > 0) {

                    $("[id*='txt_fname']").val(data.d[0].fname);
                    $("[id*='txt_mname']").val(data.d[0].mname);
                    $("[id*='txt_lname']").val(data.d[0].lname);
                    $("[id*='txt_fname']").val(data.d[0].fname);
                    $("[id*='birthdate']").val(data.d[0].dob);
                    $("[id*='ddlfaculty']").val(data.d[0].ddlfaculty);

                    $("[id*=txt_fname]").prop('disabled', true);
                    $("[id*=txt_mname]").prop('disabled', true);
                    $("[id*=txt_lname]").prop('disabled', true);
                    $("[id*=birthdate]").prop('disabled', true);
                    $("[id*=ddlfaculty]").prop('disabled', true);
                    Course = data.d[0].ddlcourse;
                    $.ajax({
                        type: "POST",
                        url: "NewStudent.aspx/getcourse",
                        data: '{fid:"' + $("[id*='ddlfaculty']").val() + '"}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (r) {
                            $("[id*=ddlcourse]").empty().append('<option selected="selected" value="0">--select--</option>');
                            $.each(r.d, function () {
                                $("[id*=ddlcourse]").append($("<option></option>").val(this['Value']).html(this['Text']));
                            });

                            var sel = $("[id*='ddlcourse']");
                          
                            for (var i = 0, j = sel[0].children.length; i < j; ++i) {
                                if (sel[0][i].value === data.d[0].ddlcourse) {
                                    sel[0].selectedIndex = i;
                                    $("[id*=ddlcourse]").prop('disabled', true);
                                    ddlcourse = data.d[0].ddlcourse;
                                    break;
                                }
                            }
                            $.ajax({
                                type: "POST",
                                url: "NewStudent.aspx/getsubcourse",
                                data: '{course:"' + $("[id*='ddlcourse']").val() + '"}',
                                contentType: "application/json; charset=utf-8",
                                async: false,
                                success: function (r) {
                                    $("[id*=ddlsubcourse]").empty().append('<option selected="selected" value="0">--select--</option>');
                                    $.each(r.d, function () {
                                        $("[id*=ddlsubcourse]").append($("<option></option>").val(this['Value']).html(this['Text']));
                                    });
                                    var sel1 = $("[id*='ddlsubcourse']");
                                    // var val = document.getElementById('AnimalToFind').value;
                                    for (var i = 0, j = sel1[0].children.length; i < j; ++i) {
                                        if (sel1[0][i].value === data.d[0].ddlsubcourse) {
                                            sel1[0].selectedIndex = i;
                                            $("[id*=ddlsubcourse]").prop('disabled', true);
                                            break;
                                        }
                                    }

                                    $.ajax({
                                        type: "POST",
                                        url: "NewStudent.aspx/getgroup",
                                        data: '{subcourse:"' + $("[id*='ddlsubcourse']").val() + '"}',
                                        contentType: "application/json; charset=utf-8",
                                        async: false,
                                        success: function (r) {
                                            $("[id*=ddlgroup]").empty().append('<option selected="selected" value="0">--select--</option>');
                                            $.each(r.d, function () {
                                                $("[id*=ddlgroup]").append($("<option></option>").val(this['Value']).html(this['Text']));
                                            });
                                            var sel12 = $("[id*='ddlgroup']");
                                            // var val = document.getElementById('AnimalToFind').value;
                                            for (var i = 0, j = sel12[0].children.length; i < j; ++i) {
                                                if (sel12[0][i].value === data.d[0].ddlgroup) {
                                                    sel12[0].selectedIndex = i;
                                                    $("[id*=ddlgroup]").prop('disabled', true);

                                                    break;
                                                }
                                            }
                                        },
                                        error: function () {
                                            //alert('Connection error, please retry');
                                            hasError = true;
                                            debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                        }
                                    });

                                },
                                error: function () {
                                    //alert('Connection error, please retry');
                                    hasError = true;
                                    debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                }
                            });

                        },
                        error: function () {
                            //alert('Connection error, please retry');
                            hasError = true;
                            debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    });

            

                //if (data.d[0].intakemessege != "") {
                if (data.d[0].intakemessege == "No seats are available do you want to continue") {
                    $.notify("No seats are available for this course.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    //$.confirm({
                    //    title: 'Intake',
                    //    text: "No seats are available do you want to continue",
                    //    content: 'No seats are available do you want to continue',
                    //    confirmButton: 'Yes',
                    //    cancelButton: 'No',
                    //    confirm: function () {
                    //        if (data.d[0].chkMeritListDate != "") {
                    //            $.notify(data.d[0].chkMeritListDate, { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                    //        }

                    //        //-----------------------------new add
                    //        $.ajax({
                    //            type: "POST",
                    //            url: "NewStudent.aspx/Admissiongrid",
                    //            data: '{formid:"' + $("[id*='txt_formid']").val() + '",year:"' + $("[id*='ddlyear']").val() + '",fname:"' + data.d[0].fname + '",mname:"' + data.d[0].mname + '",lname:"' + data.d[0].lname + '",dob:"' + data.d[0].dob + '"}',
                    //            contentType: "application/json; charset=utf-8",
                    //            async: false,
                    //            success: function (data) {
                    //                if (data.d.length > 0) {

                    //                    $("[id*=divbank]").show();
                    //                    if (data.d[0].messege != null) {


                    //                        var gripanel = document.getElementById('gridpanel');
                    //                        gripanel.style.visibility = 'visible';
                    //                        gripanel.style.display = 'block';
                    //                        $("[id*=grid_studentadm]").empty();
                    //                        //class='alert-info'

                    //                        $("[id*=grid_studentadm]").append("<thead><tr class='alert alert-info'> <th>Student Name</th><th>Subcourse Name</th><th>Course Name</th><th>Faculty Name</th><th>Group Title</th><th>Course Total Fees</th><th>Course Fees Paid</th><th> Student ID</th></tr></thead>");    //<th><input type=button Text=Edit'> Edit</th><th> Delete</th>
                    //                        $("[id*=grid_studentadm]").append("<tbody>");

                    //                        $("[id*=grid_studentadm]").append("<tr><td>" +

                    //                            data.d[0].name + "</td> <td>" +

                    //                            data.d[0].ddlsubcoursename + "</td> <td>" +

                    //                            data.d[0].ddlcoursename + "</td> <td>" +


                    //                           data.d[0].ddlfacultyname + "</td><td>" +


                    //                          data.d[0].ddlgroupname + "</td><td>" +

                    //                           data.d[0].Course_tot_fees + "</td><td> " +

                    //                          data.d[0].course_fee_paid + "</td><td>" +

                    //                         data.d[0].oldstud_id + "</td> </tr>");

                    //                        oldstudid = data.d[0].oldstud_id;
                    //                        oldfees = data.d[0].course_fee_paid;

                    //                        $("[id*=grid_studentadm]").append("</tbody>");
                    //                        $("[id*='messg']")[0].innerText = "Admission Already taken in  " + data.d[0].ddlgroupname + ". Do you want to cancel it and transfer this student to  " + $("[id*='ddlgroup'] :selected").text() + " ??";

                    //                        $("[id*=transfermodel]").modal();

                    //                    }
                    //                }

                    //            },
                    //            error: function () {
                    //                //alert('Connection error, please retry');
                    //                hasError = true;
                    //                debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    //            }
                    //        });



                    //        //  }



                    //    },
                    //    cancel: function () {

                    //        clear();
                    //        // $('#btn_transfer').attr("disabled", "disabled");
                    //        $("[id*=btn_transfer]").prop('disabled', true);

                    //        // $("a").each(function () {
                    //        //  $(this).attr("rel", $(this).attr("href"));
                    //        //  $(this).attr("href", "javascript:;");
                    //        // });
                    //        // do something when No is clicked.
                    //    }

                    //});


                }
          
                else {
                    if (data.d[0].intakemessege == " ") {

                    }
                    else {
                        $.notify(data.d[0].intakemessege, { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                    }
                    if (data.d[0].chkMeritListDate != " ") {
                        $.notify(data.d[0].chkMeritListDate, { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                    }
                    else {
                       
                    }
                    $.ajax({
                        type: "POST",
                        url: "NewStudent.aspx/Admissiongrid",
                        data: '{formid:"' + $("[id*='txt_formid']").val() + '",year:"' + $("[id*='ddlyear']").val() + '",fname:"' + data.d[0].fname + '",mname:"' + data.d[0].mname + '",lname:"' + data.d[0].lname + '",dob:"' + data.d[0].dob + '"}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (data) {
                            if (data.d.length > 0) {

                                $("[id*=divbank]").show();
                                if (data.d[0].messege != null) {


                                    var gripanel = document.getElementById('gridpanel');
                                    gripanel.style.visibility = 'visible';
                                    gripanel.style.display = 'block';
                                    $("[id*=grid_studentadm]").empty();
                                    //class='alert-info'

                                    $("[id*=grid_studentadm]").append("<thead><tr class='alert alert-info'> <th>Student Name</th><th>Subcourse Name</th><th>Course Name</th><th>Faculty Name</th><th>Group Title</th><th>Course Total Fees</th><th>Course Fees Paid</th><th> Student ID</th></tr></thead>");    //<th><input type=button Text=Edit'> Edit</th><th> Delete</th>
                                    $("[id*=grid_studentadm]").append("<tbody>");

                                    $("[id*=grid_studentadm]").append("<tr><td>" +

                                        data.d[0].name + "</td> <td>" +

                                        data.d[0].ddlsubcoursename + "</td> <td>" +

                                        data.d[0].ddlcoursename + "</td> <td>" +


                                       data.d[0].ddlfacultyname + "</td><td>" +


                                      data.d[0].ddlgroupname + "</td><td>" +

                                       data.d[0].Course_tot_fees + "</td><td> " +

                                      data.d[0].course_fee_paid + "</td><td>" +

                                     data.d[0].oldstud_id + "</td> </tr>");

                                    oldstudid = data.d[0].oldstud_id;
                                    oldfees = data.d[0].course_fee_paid;

                                    $("[id*=grid_studentadm]").append("</tbody>");
                                    $("[id*='messg']")[0].innerText = "Admission Already taken in  " + data.d[0].ddlgroupname + ". Do you want to cancel it and transfer this student to  " + $("[id*='ddlgroup'] :selected").text() + " ??";

                                    $("[id*=transfermodel]").modal();

                                    //$.confirm({

                                    //    title: 'ADMISSION',
                                    //    text: "Admission Already taken in  " + data.d[0].ddlgroupname + ". Do you want to cancel it and transfer this student to  " + $("[id*='ddlgroup'] :selected").text() + " ??  ",
                                    //    content: 'Admission Already taken in ().. Do you want to cancel it and transfer this student to () ??  ',
                                    //    confirmButton: 'Yes',
                                    //    cancelButton: 'No',
                                    //    confirm: function () {

                                    //        transferflag = 1;

                                    //        $("[id*=btn_confirm]").prop('disabled', true);
                                    //        // $("[id*=btn_confirm]").attr("disabled", "disabled");
                                    //        $("[id*=btn_transfer]").style.visibility = 'visible';

                                    //        //var panel = document.getElementById('btn_transfer');
                                    //        //panel.style.visibility = 'visible';
                                    //        //panel.style.display = 'block';
                                    //        //panel.style='100px';

                                    //        //var btcnf = document.getElementById('btn_confirm');
                                    //        //btcnf.style.visibility = 'hidden';
                                    //        //btcnf.style.display = 'none';
                                    //        $("[id*=btn_transfer]").focus();
                                    //        // });

                                    //    },
                                    //    cancel: function () {

                                    //        // $('#btn_transfer').attr("disabled", "disabled");
                                    //        $('#btn_transfer').prop('disabled', true);
                                    //        // do something when No is clicked.
                                    //    }
                                    //});

                                }
                            }

                        },
                        error: function () {
                            //alert('Connection error, please retry');
                            hasError = true;
                            debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    });

                }
                }

            },
            error: function () {


            }
        });

    }
    // }
});

$("[id*='btn_yes']").on("click", function () {
    transferflag = 1;

    $("[id*=btn_confirm]").prop('disabled', true);
    // $("[id*=btn_confirm]").attr("disabled", "disabled");
    //  $("[id*=btn_transfer]").style.visibility = 'visible';

    $("[id*=btn_transfer]").focus();
    $("[id*=transfermodel]").modal('hide');

});
$("[id*='btn_no']").on("click", function () {
    // $('#btn_transfer').attr("disabled", "disabled");
    $('#btn_transfer').prop('disabled', true);
    // do something when No is clicked.
    $("[id*=transfermodel]").modal('hide');
});

$("[id*='ddlfaculty']").change(function () {

    $.ajax({
        type: "POST",
        url: "NewStudent.aspx/getcourse",
        data: '{fid:"' + $("[id*='ddlfaculty']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (r) {
            $("[id*=ddlcourse]").empty().append('<option selected="selected" value="0">--select--</option>');
            $.each(r.d, function () {
                $("[id*=ddlcourse]").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            //alert('Connection error, please retry');
            hasError = true;
            debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });

});



$("[id*='ddlcourse']").change(function () {

    $.ajax({
        type: "POST",
        url: "NewStudent.aspx/getsubcourse",
        data: '{course:"' + $("[id*='ddlcourse']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (r) {
            $("[id*=ddlsubcourse]").empty().append('<option selected="selected" value="0">--select--</option>');
            $.each(r.d, function () {
                $("[id*=ddlsubcourse]").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            //alert('Connection error, please retry');
            hasError = true;
            //debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });

});


$("[id*='ddlsubcourse']").change(function () {

    $.ajax({
        type: "POST",
        url: "NewStudent.aspx/getgroup",
        data: '{subcourse:"' + $("[id*='ddlsubcourse']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (r) {
            $("[id*=ddlgroup]").empty().append('<option selected="selected" value="0">--select--</option>');
            $.each(r.d, function () {
                $("[id*=ddlgroup]").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            //alert('Connection error, please retry');
            hasError = true;
            //debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });

});
$("[id*='dobpaymode']").change(function () {

    if ($("[id*='dobpaymode']").val() == "Cash") {
        $("[id*=chqdt]").prop('disabled', true);
        $("[id*=txt_bankname]").prop('disabled', true);
        $("[id*=txt_branchname]").prop('disabled', true);
        // $("[id*=chq_date]").prop('disabled', true);
        //  $("[id*=chq_date]").show();
        // $("[id*=dddate]").show();


        var panel2 = document.getElementById('divbank2');
        panel2.style.visibility = 'hidden';
        panel2.style.display = 'none';
    }
    else if ($("[id*='dobpaymode']").val() == "Online Pay") {
        $("[id*=chqdt]").prop('disabled', true);
        $("[id*=txt_bankname]").prop('disabled', true);
        $("[id*=txt_branchname]").prop('disabled', true);
        // $("[id*=chq_date]").prop('disabled', true);
        //  $("[id*=chq_date]").show();
        // $("[id*=dddate]").show();


        var panel2 = document.getElementById('divbank2');
        panel2.style.visibility = 'hidden';
        panel2.style.display = 'none';
    }
    else if ($("[id*='dobpaymode']").val() == "Cheque") {
        jQuery('[id*=chq_date]').datetimepicker(
         {
             timepicker: false,
             format: 'd-M-Y h:m:s'
         });
        $("[id*=chqdt]").prop('disabled', false);
        $("[id*=txt_bankname]").prop('disabled', false);
        $("[id*=txt_branchname]").prop('disabled', false);
        // $("[id*=chq_date]").prop('disabled', false);

        var panel2 = document.getElementById('divbank2');
        panel2.style.visibility = 'hidden';
        panel2.style.display = 'none';

    }
    else if ($("[id*='dobpaymode']").val() == "NEFT") {
        $("[id*=divbank2]").show();
        jQuery('[id*=chq_date2]').datetimepicker(
         {
             timepicker: false,
             format: 'd-M-Y h:m:s'
         });
        $("[id*=chqdt2]").prop('disabled', false);
        $("[id*=txt_bankname2]").prop('disabled', false);
        $("[id*=txt_branchname2]").prop('disabled', false);
        var panel = document.getElementById('divcard');
        panel.style.visibility = 'hidden';
        panel.style.display = 'none';


        var panel12 = document.getElementById('divbank2');
        panel12.style.visibility = 'visible';
        panel12.style.display = 'block';
    }
    else {

        //jQuery('[id*=dddate]').datetimepicker(
        //{
        //    timepicker: false,
        //    format: 'd-M-Y'
        //});
        $("[id*=chqdt]").prop('disabled', false);

        $("[id*=txt_bankname]").prop('disabled', false);
        $("[id*=txt_branchname]").prop('disabled', false);
        // $("[id*=chq_date]").prop('disabled', false);
    }


});


$("[id*='btn_confirm']").on("click", function () {

    $("[id*='ddlgroup'] :selected").text();

    sum = ($("[id*='ddlyear']").val().substr(5, 7));
    sum = parseInt(sum) + 1
    $.ajax({
        type: "POST",
        url: "NewStudent.aspx/Confirm",
        data: '{formid:"' + $("[id*='txt_formid']").val() + '", year:"' + $("[id*='ddlyear']").val() + '",ddlfaculty:"' + $("[id*='ddlfaculty']").val() + '",ddlgroup:"' + $("[id*='ddlgroup']").val() + '",ddlsubcourse:"' + $("[id*='ddlsubcourse']").val() + '",ddlgroupname:"' + $("[id*='ddlgroup'] :selected").text() + '",ddlsubcoursename:"' + $("[id*='ddlsubcourse'] :selected").text() + '"}',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (data) {

            sessionid = data.d[0].stud_id;
            //  $("[id*=idmodel]").modal();
            $("[id*='stdid']")[0].innerText = "STUDENT ID  : " + data.d[0].stud_id;

            $.notify("STUDENT ID : " + data.d[0].stud_id + " ", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });

            //  $("[id*='lblstudid']")[0].innerText ="STUDENT ID  : " + data.d[0].stud_id;

            ddlfaculty = $("[id*='ddlfaculty']").val();
            ddlgroup = $("[id*='ddlgroup']").val();
            ddlsubcourse = $("[id*='ddlsubcourse']").val();

            $("[id*=myEditModal]").modal();
            $("[id*='lblstud_id']")[0].innerText = data.d[0].stud_id;
            $("[id*='lblsubcourse']")[0].innerText = data.d[0].ddlsubcoursename;
            $("[id*='lblstudname']")[0].innerText = data.d[0].name;
            $("[id*='lblgroup']")[0].innerText = data.d[0].ddlgroupname;
            $("[id*='lblcategory']")[0].innerText = data.d[0].category;
            Category = data.d[0].category;
            $("[id*='txt_amount']").val(data.d[0].amount);
            $("[id*='txt_receiptno']").val(data.d[0].stud_id + '/' + $("[id*='ddlyear']").val().substr(5, 7) + '-' + sum + '/' + data.d[0].feecount);
            paidfees = data.d[0].amount;
            ///new add=========================================================
            $.ajax({
                type: "POST",
                url: "NewStudent.aspx/parpayment",
                data: '{stud_id:"' + $("[id*='txt_formid']").val()+ '" ,ayid:"' + $("[id*='ddlyear']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                //   dataType: "json",
                async: false,
                success: function (data) {

                    if (data.d[0].allow_freeship == true) {
                        $("[id*=txt_amount]").prop('disabled', true);
                       // $("[id*=txt_feespay]").prop('disabled', false);
                        $("[id*=txt_auth]").val(Category);
                        //if ($("[id*='lblgroup']")[0].innerText.startsWith("T") == true) {
                        //    $("[id*=txt_feespay]").val('2965');
                        //}
                        //else if ($("[id*='lblgroup']")[0].innerText.startsWith("M") == true) {
                        //    $("[id*=txt_feespay]").val('3690');
                        //}
                        //else {
                        //    $("[id*=txt_feespay]").val('2690');//updated  on 14/05/2019
                        //}
                        $("[id*=txt_feespay]").val(data.d[0].allow_amt);
                        var dobremark = $("[id*='dobremark']");

                        for (var i = 0, j = dobremark[0].children.length; i < j; ++i) {
                            if (dobremark[0][i].innerText == "Freeship / Scholarship") {
                                dobremark[0].selectedIndex = i;
                                break;
                            }
                        }

                    }

                    else if (data.d[0].allow_amt != 0) {
                        //  $("[id*=txt_feespay]").prop('disabled', false);
                        $("[id*=txt_amount]").prop('disabled', true);
                        $("[id*=txt_feespay]").val(data.d[0].allow_amt);
                       // $("[id*=txt_feespay]").prop('disabled', false);
                        $("[id*=txt_auth]").val('Principal');
                        var dobremark = $("[id*='dobremark']");

                        for (var i = 0, j = dobremark[0].children.length; i < j; ++i) {
                            if (dobremark[0][i].innerText == "Admission Permission") {
                                dobremark[0].selectedIndex = i;
                                break;
                            }
                        }
                    }
                    else {

                        all_amt = "CourseFees";

                    }
                },
                error: function () {
                    alert('Connection error, please retry');
                    hasError = true;
                    debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }

            });
            $("[id*=txt_amount]").prop('disabled', true);
            $("[id*='dobpaymode']").val('Cash');
            if (all_amt == "CourseFees") {

                if (Course == "CRS017") {
                    $("[id*='txt_feespay']").val(paidfees);
                   // $("[id*=txt_feespay]").prop('disabled', false);
                    $("[id*=dobremark]").prop('disabled', false);
                    $("[id*=txt_auth]").prop('disabled', false);

                }
                else {
                    $("[id*='txt_feespay']").val(paidfees);
               //     $("[id*=txt_feespay]").prop('disabled', true);
                    $("[id*=dobremark]").prop('disabled', false);
                    $("[id*=txt_auth]").prop('disabled', false);
                }




                //$("[id*='txt_feespay']").val(paidfees);
                //$("[id*=txt_feespay]").prop('disabled', true);
                //$("[id*=dobremark]").prop('disabled', true);
                //$("[id*=txt_auth]").prop('disabled', true);

            }



            //=======================================================================================================


        },


        error: function () {
            //alert('Connection error, please retry');
            hasError = true;
            //debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });



});


$("[id*='btnfeesconfirm']").on("click", function () {
    var admission = {};

    if ($("[id*='txt_amount']").val() == "") {
        $.notify("please enter the fees amount.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        return;
    }

    if ($("[id*='txt_amount']").val() < 400) {
        $.notify("Enter amount more then the minimum amount .", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        return;
    }
    sessionid = $("[id*='lblstud_id']")[0].innerText;
    admission.stud_id = $("[id*='lblstud_id']")[0].innerText;
    admission.ddlsubcourse = $("[id*='ddlsubcourse']").val();
    admission.ddlgroup = $("[id*='ddlgroup']").val();
    admission.amount = $("[id*='txt_amount']").val();
    admission.Course_tot_fees = $("[id*='txt_feespay']").val();
    admission.Pay_date = "";


    //  $("#payDate").datepicker("option", "dateFormat", "d-M-Y" + getTime() + "");
    admission.reciptmode1 = $("[id*='dobpaymode']").val();
    admission.Recpt_Chq_dt1 = $("[id*='chq_date']").val();
    admission.Recpt_Chq_No1 = $("[id*='txtchequeno']").val();
    admission.Recpt_Bnk_Name1 = $("[id*='txt_bankname']").val();
    admission.Recpt_Bnk_Branch1 = $("[id*='txt_branchname']").val();

    if ($("[id*='dobpaymode']").val() == "NEFT") {

        admission.Recpt_Chq_dt1 = $("[id*='chq_date2']").val();
        admission.Recpt_Chq_No1 = $("[id*='txtchequeno2']").val();
        admission.Recpt_Bnk_Name1 = $("[id*='txt_bankname2']").val();
        admission.Recpt_Bnk_Branch1 = $("[id*='txt_branchname2']").val();

    }

    admission.Chq_status1 = $("[id*='dobpaymode']").val();
    admission.type1 = "Fee";

    admission.Remark1 = $("[id*='dobremark']").val();

    admission.Authorized_By1 = $("[id*='txt_auth']").val();
    admission.AYID1 = $("[id*='ddlyear']").val();
    admission.user_id1 = empId;
    admission.receiptno = $("[id*='txt_receiptno']").val();
    admission.card_no = $("[id*='txt_card_no']").val();





    $.ajax({
        type: "POST",
        url: "NewStudent.aspx/savefees",

        //   data: '{stud_id:"' + $("[id*='lblstud_id']")[0].innerText + '",ddlsubcourse:"' + $("[id*='ddlsubcourse']").val() + '",ddlgroup:"' + $("[id*='ddlgroup']").val() + '",amount:"' + $("[id*='txt_amount']").val() + '",Course_tot_fees:"' + $("[id*='txt_feespay']").val() + '",Course_fee_Bal:"' + $("[id*='txt_feespay']").val() + '",Pay_date:"' + $("[id*='payDate']").val() + '",reciptmode:"' + $("[id*='dobpaymode']").val() + '",reciptno:"' + $("[id*='txt_receiptno']").val() + '",Recpt_Chq_dt:"' + $("[id*='chq_date']").val() + '",Recpt_Chq_No:"' + $("[id*='txt_chequeno']").val() + '",Recpt_Bnk_Name:"' + $("[id*='txt_bankname']").val() + '",Recpt_Bnk_Branch:"' + $("[id*='txt_branchname']").val() + '",Chq_status:"' + $("[id*='dobpaymode']").val() + '",type:"Fees",Remark:"' + $("[id*='dobremark']").val() + '",Authorized_By:"' + $("[id*='txt_auth']").val() + '",Ayid:"' + $("[id*='ddlyear']").val() + '",user_id:"' + empId + '" }',

        data: '{admission: ' + JSON.stringify(admission) + '}',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (data) {

            $.notify("Student admission is confirmed.", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });

          //  $("[id*=myEditModal]").modal('hide');
            // $('#myEditModal').modal('hide');
          //  clear();



            if (Course != "CRS017") {
                $.confirm({

                    title: 'Fee Receipt',
                    text: "Do You want to Fee Receipt",
                    content: 'Do You want to Fee Receipt',
                    confirmButton: 'Yes',
                    cancelButton: 'No',
                    confirm: function () {
                        PageMethods.Setsession(sessionid);

                        window.open("fee_reciept_copy.aspx", "_blank");



                        $("[id*=myEditModal]").modal('hide');
                        clear();
                        clearfee();
                        clearcontrol();
                        disable();


                       
                       
                    },
                    cancel: function () {


                        $("[id*=myEditModal]").modal('hide');
                        clear();
                        clearfee();
                        clearcontrol();
                        disable();

                    }
                });

            }
            else {

                $.confirm({

                    title: 'Fee Receipt',
                    text: "Fee Receipt With Particulars Or Without Particulars",
                    content: 'Fee Receipt With Particulars Or Without Particulars',
                    confirmButton: 'With Particulars',
                    cancelButton: 'Without Particulars',
                    confirm: function () {


                        PageMethods.Setsession(sessionid);

                        window.open("fee_reciept_copy.aspx", "_blank");



                        $("[id*=myEditModal]").modal('hide');
                        clear();
                        clearfee();
                        clearcontrol();
                        disable();

                    },
                    cancel: function () {

                        PageMethods.Setsession(sessionid);

                        window.open("FeeReceipt_HM.aspx", "_blank");

                        $("[id*=myEditModal]").modal('hide');
                        clear();
                        clearfee();
                        clearcontrol();
                        disable();

                    }
                });
            }





        },

        error: function () {
            //alert('Connection error, please retry');
            hasError = true;
            debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });
});

$("[id*='btn_transfer']").on("click", function () {

  
    $("[id*=transfermodel]").modal('show');
    if (transferflag == 1) {
        $.ajax({
            type: "POST",
            url: "NewStudent.aspx/Confirm",
            data: '{formid:"' + $("[id*='txt_formid']").val() + '",year:"' + $("[id*='ddlyear']").val() + '",ddlfaculty:"' + $("[id*='ddlfaculty']").val() + '",ddlgroup:"' + $("[id*='ddlgroup']").val() + '",ddlsubcourse:"' + $("[id*='ddlsubcourse']").val() + '",ddlgroupname:"' + $("[id*='ddlgroup'] :selected").text() + '",ddlsubcoursename:"' + $("[id*='ddlsubcourse'] :selected").text() + '"}',
           
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {

                //    $("[id*='lblstudid']")[0].innerText = "STUDENT ID  : " + data.d[0].stud_id;

                sum = ($("[id*='ddlyear']").val().substr(5, 7));
                sum = parseInt(sum) + 1

                sessionid = data.d[0].stud_id;
                ddlfaculty = $("[id*='ddlfaculty']").val();
                ddlgroup = $("[id*='ddlgroup'] :selected").text();
                ddlsubcourse = $("[id*='ddlgroup'] :selected").text();

                fyid = data.d[0].fyid;

                $("[id*='lblstud_id']")[0].innerText = data.d[0].stud_id;
                $("[id*='lblsubcourse']")[0].innerText = data.d[0].ddlsubcoursename;
                $("[id*='lblstudname']")[0].innerText = data.d[0].name;
                $("[id*='lblgroup']")[0].innerText = data.d[0].ddlgroupname;
                $("[id*='lblcategory']")[0].innerText = data.d[0].category;
                Category = data.d[0].category;
                $("[id*='txt_amount']").val(data.d[0].amount);
                $("[id*='txt_receiptno']").val(data.d[0].stud_id + '/' + $("[id*='ddlyear']").val().substr(5, 7) + '-' + sum + '/' + (parseInt(data.d[0].feecount)+1));
                paidfees = data.d[0].amount;
                ///new add=========================================================
                $.ajax({
                    type: "POST",
                    url: "Student_Modify.aspx/parpayment",
                    data: '{stud_id:"' + $("[id*='txt_formid']").val() + '" ,ayid:"' + $("[id*='ddlyear']").val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    //   dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.d[0].allow_freeship == true) {
                            $("[id*=txt_amount]").prop('disabled', true);
                          //  $("[id*=txt_feespay]").prop('disabled', true);
                            $("[id*=txt_auth]").val(Category);
                            //if ($("[id*='lblgroup']")[0].innerText.startsWith("T") == true) {
                            //    $("[id*=txt_feespay]").val(data.d[0].allow_amt);
                            //}
                            //else if ($("[id*='lblgroup']")[0].innerText.startsWith("M") == true) {
                            //    $("[id*=txt_feespay]").val(data.d[0].allow_amt);
                            //}
                            //else {
                            //    $("[id*=txt_feespay]").val(data.d[0].allow_amt);
                            //}
                            $("[id*=txt_feespay]").val(data.d[0].allow_amt);
                            var dobremark = $("[id*='dobremark']");

                            for (var i = 0, j = dobremark[0].children.length; i < j; ++i) {
                                if (dobremark[0][i].innerText == "Freeship / Scholarship") {
                                    dobremark[0].selectedIndex = i;
                                    break;
                                }
                            }

                        }

                        else if (data.d[0].allow_amt != 0) {
                            //  $("[id*=txt_feespay]").prop('disabled', false);
                            $("[id*=txt_amount]").prop('disabled', true);
                            $("[id*=txt_feespay]").val(paidfees);
                        //    $("[id*=txt_feespay]").prop('disabled', true);
                            $("[id*=txt_auth]").val('Principal');
                            var dobremark = $("[id*='dobremark']");

                            for (var i = 0, j = dobremark[0].children.length; i < j; ++i) {
                                if (dobremark[0][i].innerText == "Admission Permission") {
                                    dobremark[0].selectedIndex = i;
                                    break;
                                }
                            }
                        }
                        else {

                            all_amt = "CourseFees";

                        }
                    },
                    error: function () {
                        alert('Connection error, please retry');
                        hasError = true;
                        debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }

                });
                $("[id*=txt_amount]").prop('disabled', true);
                $("[id*='dobpaymode']").val('Cash');
                if (all_amt == "CourseFees") {


                   // if (Course == "CRS017") {
                        $("[id*='txt_feespay']").val(paidfees);
                  //      $("[id*=txt_feespay]").prop('disabled', false);
                        $("[id*=dobremark]").prop('disabled', false);
                        $("[id*=txt_auth]").prop('disabled', false);

                   // }
                  //  else {
                  


                    //$("[id*='txt_feespay']").val();
                    //$("[id*=txt_feespay]").prop('disabled', false);
                    //$("[id*=dobremark]").prop('disabled', true);
                    //$("[id*=txt_auth]").prop('disabled', true);

                }


                //=======================================================================================================



                $.ajax({
                    type: "POST",
                    url: "NewStudent.aspx/transferfees",

                    data: '{oldstud_id:"' + oldstudid + '",formid:"' + $("[id*='txt_formid']").val() + '" ,stud_id:"' + sessionid + '",Ayid:"' + $("[id*='ddlyear']").val() + '",fyid:"' + fyid + '",userid:"' + empId + '"}',
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {


                        $.notify(" Student ID :" + sessionid + "  Transfer from  : " + data.d[0].ddlgroupname + " To " + data.d[0].ddloldgroupname + "", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });

                        if (oldfees != paidfees) {

                            if (oldfees == "400")
                            {


                                if (Course != "CRS017") {
                                    $.confirm({

                                        title: 'Fee Receipt',
                                        text: "Do You want to Fee Receipt",
                                        content: 'Do You want to Fee Receipt',
                                        confirmButton: 'Yes',
                                        cancelButton: 'No',
                                        confirm: function () {
                                            PageMethods.Setsession(sessionid);

                                            window.open("fee_reciept_copy.aspx", "_blank");

                                            //$("[id*=myEditModal]").modal('hide');
                                            clear();
                                            clearfee();
                                            clearcontrol();
                                            disable();




                                        },
                                        cancel: function () {


                                            $("[id*=myEditModal]").modal('hide');
                                            clear();
                                            clearfee();
                                            clearcontrol();
                                            disable();

                                        }
                                    });

                                }
                                else {

                                    $.confirm({

                                        title: 'Fee Receipt',
                                        text: "Fee Receipt With Particulars Or Without Particulars",
                                        content: 'Fee Receipt With Particulars Or Without Particulars',
                                        confirmButton: 'With Particulars',
                                        cancelButton: 'Without Particulars',
                                        confirm: function () {


                                            PageMethods.Setsession(sessionid);

                                            window.open("fee_reciept_copy.aspx", "_blank");



                                          //  $("[id*=myEditModal]").modal('hide');
                                            clear();
                                            clearfee();
                                            clearcontrol();
                                            disable();

                                        },
                                        cancel: function () {

                                            PageMethods.Setsession(sessionid);

                                            window.open("FeeReceipt_HM.aspx", "_blank");

                                            $("[id*=myEditModal]").modal('hide');
                                            clear();
                                            clearfee();
                                            clearcontrol();
                                            disable();

                                        }
                                    });
                                }






                                //clear();
                                //clearfee();
                                //clearcontrol();
                                //disable();
                            }
                            else {

                                if (parseInt(oldfees) >= parseInt(paidfees)) {

                                    if (Course != "CRS017") {
                                        $.confirm({

                                            title: 'Fee Receipt',
                                            text: "Do You want to Fee Receipt",
                                            content: 'Do You want to Fee Receipt',
                                            confirmButton: 'Yes',
                                            cancelButton: 'No',
                                            confirm: function () {
                                                PageMethods.Setsession(sessionid);

                                                window.open("fee_reciept_copy.aspx", "_blank");

                                                //$("[id*=myEditModal]").modal('hide');
                                                clear();
                                                clearfee();
                                                clearcontrol();
                                                disable();




                                            },
                                            cancel: function () {


                                                $("[id*=myEditModal]").modal('hide');
                                                clear();
                                                clearfee();
                                                clearcontrol();
                                                disable();

                                            }
                                        });

                                    }
                                    else {

                                        $.confirm({

                                            title: 'Fee Receipt',
                                            text: "Fee Receipt With Particulars Or Without Particulars",
                                            content: 'Fee Receipt With Particulars Or Without Particulars',
                                            confirmButton: 'With Particulars',
                                            cancelButton: 'Without Particulars',
                                            confirm: function () {


                                                PageMethods.Setsession(sessionid);

                                                window.open("fee_reciept_copy.aspx", "_blank");



                                                //  $("[id*=myEditModal]").modal('hide');
                                                clear();
                                                clearfee();
                                                clearcontrol();
                                                disable();

                                            },
                                            cancel: function () {

                                                PageMethods.Setsession(sessionid);

                                                window.open("FeeReceipt_HM.aspx", "_blank");

                                                $("[id*=myEditModal]").modal('hide');
                                                clear();
                                                clearfee();
                                                clearcontrol();
                                                disable();

                                            }
                                        });
                                    }





                                    clear();
                                    clearfee();
                                    clearcontrol();
                                    disable();

                                }
                                else {
                                    $("[id*=myEditModal]").modal();

                                }
                              

                        }
                           
                        }
                        else {
                            clear();
                            clearfee();
                            clearcontrol();
                            disable();
                        }
                       
                    },

                    error: function () {
                        //alert('Connection error, please retry');
                        hasError = true;
                        debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                });






            },

            error: function () {
                //alert('Connection error, please retry');
                hasError = true;
                //debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });
    }




});
$("[id*='btn_refresh']").on("click", function () {

    $("[id*=grid_studentadm]").empty();
    //  $("[id*='txt_formid']").css("border-color", "#ccc");
    function removeElements() {
        $("[id*=ddlyear]").html("");
    }


    $.ajax({
        type: "POST",
        url: "NewStudent.aspx/getfaculty",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            $("[id*=ddlfaculty]").empty().append('<option selected="selected" value="0">--select--</option>');
            $.each(r.d, function () {
                $("[id*=ddlfaculty]").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            hasError = true;
            debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });


    var panel = document.getElementById('divbank');
    panel.style.visibility = 'hidden';
    panel.style.display = 'none';

    // $("[id*=btn_transfer]").attr("enbled", "disabled");
    $("[id*=btn_transfer]").prop('disabled', false);
    //  $("[id*='txt_formid']").focus();
    // $("[id*=txt_feespay]").prop('disabled', true);
    $("[id*=txt_receiptno]").prop('disabled', true);
    $("[id*=dobremark]").prop('disabled', true);
    $("[id*=txt_auth]").prop('disabled', true);

    $("[id*=chqdt]").prop('disabled', true);
    $("[id*=txt_bankname]").prop('disabled', true);
    $("[id*=txt_branchname]").prop('disabled', true);


    var gripanel = document.getElementById('gridpanel');
    gripanel.style.visibility = 'hidden';
    gripanel.style.display = 'none';


    var panel = document.getElementById('divbank');
    panel.style.visibility = 'hidden';
    panel.style.display = 'none';
    // }
    var panel1 = document.getElementById('divcard');
    panel1.style.visibility = 'hidden';
    panel1.style.display = 'none';




    disable();
    clear();
    clearfee();

});

$("[id*='dobpaymode']").change(function () {

    if ($("[id*='dobpaymode']").val() == "Cash") {

        $("[id*=chqdt]").prop('disabled', true);
        //  $("[id*=txt_bankname]").prop('disabled', true);
        //  $("[id*=txt_branchname]").prop('disabled', true);
        $("[id*=txt_bankname]").val('');
        $("[id*=txt_branchname]").val('');
        $("[id*=chqdt]").val('');
        $("[id*=chq_date]").val('');
        var panel = document.getElementById('divbank');
        panel.style.visibility = 'hidden';
        panel.style.display = 'none';
        var panel1 = document.getElementById('divcard');
        panel1.style.visibility = 'hidden';
        panel1.style.display = 'none';
    }
    else if ($("[id*='dobpaymode']").val() == "Online Pay") {
        $("[id*=chqdt]").prop('disabled', true);
        //  $("[id*=txt_bankname]").prop('disabled', true);
        //  $("[id*=txt_branchname]").prop('disabled', true);
        $("[id*=txt_bankname]").val('');
        $("[id*=txt_branchname]").val('');
        $("[id*=chqdt]").val('');
        $("[id*=chq_date]").val('');
        var panel = document.getElementById('divbank');
        panel.style.visibility = 'hidden';
        panel.style.display = 'none';
        var panel1 = document.getElementById('divcard');
        panel1.style.visibility = 'hidden';
        panel1.style.display = 'none';
    }
    else if ($("[id*='dobpaymode']").val() == "Cheque") {
        $("[id*=divbank]").show();
        jQuery('[id*=chq_date]').datetimepicker(
         {
             timepicker: false,
             format: 'd-M-Y h:m:s'
         });
        $("[id*=chqdt]").prop('disabled', false);
        $("[id*=txt_bankname]").prop('disabled', false);
        $("[id*=txt_branchname]").prop('disabled', false);
        var panel = document.getElementById('divcard');
        panel.style.visibility = 'hidden';
        panel.style.display = 'none';


        var panel12 = document.getElementById('divbank');
        panel12.style.visibility = 'visible';
        panel12.style.display = 'block';

    }
    else if ($("[id*='dobpaymode']").val() == "Card Payment") {
        // $("[id*=divcard]").show();

        var panel = document.getElementById('divcard');
        panel.style.visibility = 'visible';
        panel.style.display = 'block';
        var panel1 = document.getElementById('divbank');
        panel1.style.visibility = 'hidden';
        panel1.style.display = 'none';
    }
    else {

        //jQuery('[id*=dddate]').datetimepicker(
        //{
        //    timepicker: false,
        //    format: 'd-M-Y'
        //});
        $("[id*=chqdt]").prop('disabled', false);

        $("[id*=txt_bankname]").prop('disabled', false);
        $("[id*=txt_branchname]").prop('disabled', false);
        // $("[id*=chq_date]").prop('disabled', false);
    }


});
function validate() {
    var retValue = true;

    if ($("[id*='txt_formid']").val().length > 8 || $("[id*='txt_formid']").val().length < 8) {
        $("[id*='txt_formid']").css("border-color", "red");
        retValue = false;
    }
    else {
        $("[id*='txt_formid']").css("border-color", "#ccc");
    }

    return retValue;
};
function clear() {
    $("[id*='txt_fname']").val('');
    $("[id*='txt_mname']").val('');
    $("[id*='txt_lname']").val('');
    $("[id*='birthdate']").val('');
    $("[id*='txt_formid']").val('');
   
    $("[id*='ddlcourse']").val('');
    $("[id*='ddlsubcourse']").val('');
    $("[id*='ddlfaculty']").val('');
    $("[id*='ddlgroup']").val('');
    $("[id*=grid_studentadm]").empty();
    sessionid = "";
    sessionformid = "";
    oldstudid = "";

    ddlcourse = "";
    ddlfaculty = "";
    ddlgroup = "";
    fyid = "";
    transferflag = 0;
    var gripanel = document.getElementById('gridpanel');
    gripanel.style.visibility = 'hidden';
    gripanel.style.display = 'none';
    Course = "";
    Category = "";
}
function clearfee() {


    $("[id*='lblstudname']")[0].innerText = "";
    $("[id*='lblsubcourse']")[0].innerText = "";
    $("[id*='lblstud_id']")[0].innerText = "";
    $("[id*='lblgroup']")[0].innerText = "";
    $("[id*='lblcategory']")[0].innerText = "";
 //   $("[id*='dobremark']").val('');
    // $("[id*=dobremark]")[0].selectedIndex = 0;
    var elmnt = $("[id*='dobremark']");

    for (var i = 0; i < elmnt[0].options.length; i++) {
        if (elmnt[0].options[i].text === "--Select--") {
            elmnt[0].selectedIndex = i;
            break;
        }
    }
    $("[id*='txt_feespay']").val('');
    $("[id*='txt_amount']").val('');
    $("[id*='txt_receiptno']").val('');
    $("[id*='txtchequeno']").val('');
    $("[id*='txt_card_no']").val('');
    $("[id*='txt_bankname']").val('');
    
    $("[id*='txt_auth']").val('');
    $("[id*='txt_branchname']").val('');
    
    all_amt = "";
    sum = "";
};

function disable() {
    $("[id*='txt_fname']").prop('disabled', true);
    $("[id*='txt_mname']").prop('disabled', true);
    $("[id*='txt_lname']").prop('disabled', true);
    $("[id*='birthdate']").prop('disabled', true);
    $("[id*='ddlcourse']").prop('disabled', true);
    $("[id*='ddlsubcourse']").prop('disabled', true);
    $("[id*=ddlfaculty]").prop('disabled', true);
    $("[id*=ddlgroup]").prop('disabled', true);


};


function enable() {
    $("[id*='txt_fname']").prop('disabled', false);
    $("[id*='txt_mname']").prop('disabled', false);
    $("[id*='txt_lname']").prop('disabled', false);
    $("[id*='birthdate']").prop('disabled', false);
    $("[id*='ddlcourse']").prop('disabled', false);
    $("[id*='ddlsubcourse']").prop('disabled', false);
    $("[id*=ddlfaculty]").prop('disabled', false);
    $("[id*=ddlgroup]").prop('disabled', false);
};


function clearcontrol() {
  
    admission.stud_id = "";
    admission.ddlsubcourse = "";
    admission.ddlgroup = "";
    admission.amount = "";
    admission.Course_tot_fees = "";
    admission.Pay_date = "";

    admission.reciptmode1 = "";
    admission.Recpt_Chq_dt1 = "";
    admission.Recpt_Chq_No1 = "";
    admission.Recpt_Bnk_Name1 = "";
    admission.Recpt_Bnk_Branch1 = "";
    admission.Chq_status1 = "";
    admission.type1 = "";

    admission.Remark1 = "";

    admission.Authorized_By1 = "";
    admission.AYID1 = "";
   
    admission.receiptno = "";
    admission.card_no = "";


};

$(function () {

    var bank = [];
    var auth = [];

    $.ajax({
        type: "POST",
        url: "NewStudent.aspx/fillbanknane",
        // data: '{condition:"' + donorid + '"}',
        //  data: '{mailer_id:""}',
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json",
        success: function (data) {
            debugger;

            for (var i = 0; i < data.d.length; i++) {
                // var val = item[i];
                var item = data.d[i];
                var mid = data.d[i];
                bank.push({ value: item, data: mid });
            }
            // setup autocomplete function pulling from currencies[] array

        },
        error: function () {

            debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });



    $.ajax({
        type: "POST",
        url: "NewStudent.aspx/fillAuthBy",
        // data: '{condition:"' + donorid + '"}',
        //  data: '{mailer_id:""}',
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json",
        success: function (data) {
            debugger;

            for (var i = 0; i < data.d.length; i++) {
                // var val = item[i];
                var item = data.d[i];
                var mid = data.d[i];
                auth.push({ value: item, data: mid });
            }
            // setup autocomplete function pulling from currencies[] array

        },
        error: function () {

            debugger;$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });


    //$('#txt_bankname').autocomplete({
    //    lookup: bank,
    //    onSelect: function (suggestion) {
    //        donorsearchchid = "";
    //        if (donorsearchchid == "") {
    //            donorsearchchid = suggestion.data;
    //            localStorage.setItem("donorsearchchid", donorsearchchid);

    //        }

    //    }
    //});



    //$('#txt_auth').autocomplete({
    //    lookup: auth,
    //    onSelect: function (suggestion) {
    //        donorsearchchid = "";
    //        if (donorsearchchid == "") {
    //            donorsearchchid = suggestion.data;
    //            localStorage.setItem("donorsearchchid", donorsearchchid);

    //        }

    //    }
    //});


});