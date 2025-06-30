$(document).ready(function () {
    //  $.noConflict(true);

    //jQuery('[id*=chq_date]').datetimepicker(
    //        {
    //            timepicker: false,
    //            format: 'd-M-Y h:m:s'
    //        });

    //jQuery('[id*=payDate]').datetimepicker(
    //       {
    //           timepicker: false,
    //           format: 'd-M-Y h:m:s'
    //       });

    jQuery('[id*=chk_date]').datetimepicker(
          {
              timepicker: false,
              format: 'd-M-Y'
          });


    jQuery('[id*=txtpaydate]').datetimepicker(
          {
              timepicker: false,
              format: 'd-M-Y'
          });

    filldata();
    fillremark();
    //$("[id*='divcard']").hide(100);
    //$("[id*='divbank']").hide(100);
    //$("[id*='feepanel']").hide(100);
});


$("[id*='btn_search']").on("click", function () {
    clear();
    filldata();
});

$("#txt_studid").on('keydown', function (e) {
    if (e.which == 13) {
        $("#btn_search").trigger('click');
        return false;
    }
});

$("[id*=ddlnarryear]").change(function () {
    if ($("[id*=ddlnarryear] :selected").text() != "--Select--") {
        $("[id*=txtautho]").val($("[id*=ddlnarryear] :selected").text().split("-")[0].split("/")[2] + "-" + $("[id*=ddlnarryear] :selected").text().split("-")[1].split("/")[2]);
    }
    else {
        $("[id*=txtautho]").val('');
    }


});

//----issue in double time fee entry difference not showing , total course fees not showing, balance fees pending....



function clear() {
    $("[id*=tbldata]").empty();
    $('#newstud').modal("hide");
    $("[id*=tbltransaction]").empty();
    $("[id*=fees]").hide();
    $("[id*=tblfees]").empty();
    $("[id*='refundiv']").hide();
    $("[id*='txtrefund']")[0].innerText = "";
   // $("[id*='txtrefdet']")[0].innerText = "";
    Group_Name = "";
    studname = "";
    Group_Id = "";
    year = "";
    Course = "";
    caste = "";
    $("[id*=divcaste]").hide();
   // $("[id*='totaltxt']").val('');
    $("[id*='feediv']").hide();
    $("[id*='txtrecipt']")[0].innerText = "";
    $("[id*=ddlstructure]")[0].selectedIndex = 0;
    $("[id*=ddlremark]")[0].selectedIndex = 0;
    $("[id*=ddlpaymode]")[0].selectedIndex = 0;
    $("[id*='lblgroup']")[0].innerText = "";
    $("[id*='ddlauthorize']")[0].selectedIndex = 0;
    $("[id*='lblstudname']")[0].innerText = "";
    $("[id*='lblclass']")[0].innerText = "";
    $("[id*='lblsubcourse']")[0].innerText = "";
    $("[id*='lbl_academicyear']")[0].innerText = "";
    $("[id*='lblCaste']")[0].innerText = "";
}

function filldata() {

    if ($("[id*='txt_studid']").val() != "") {
        var stud_id = $("[id*='txt_studid']").val();
        if (stud_id.length == 8) {
            $.ajax({
                type: "POST",
                url: "FeeEntry_New.aspx/searchstudentfee",
                data: '{stud_id:"' + $("[id*='txt_studid']").val() + '",empid:"' + empId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    if (response.d.length > 0) {
                        $("[id*=tbldata]").empty();
                        $('#newstud').modal("show");
                        $("[id*=tbldata]").append("<thead><tr class='alert alert-danger'><th colspan=10><center>Select Class To Pay Fees</th></tr><tr class='alert-success'><th style='display:none'><center>GROUPID</center></th><th><center>Group</center></th><th ><center>Student ID</center></th><th ><center>Name</center></th><th ><center>Course</center></th><th ><center>Class</center><th style='display:none'><center>Year</center></th><th ><center>Academic Year</center></th><th ><center>View</center></th></tr></thead>");

                        for (var i = 0; i < response.d.length; i++) {
                            if (i == 0) {
                                $("[id*=tbldata]").append("<tbody>");
                            }

                            $("[id*=tbldata]").append("<tr><td style='display:none'>" + response.d[i].Group_Id + "</td><td>" + response.d[i].Group_Name + "</td><td>" + response.d[i].stud_id + "</td><td>" + response.d[i].name + "</td><td>" + response.d[i].Course + "</td><td>" + response.d[i].Class + "</td><td style='display:none'>" + response.d[i].year + "</td><td>" + response.d[i].Duration + "</td><td style='display:none'>" + response.d[i].stud_Category + "</td> <td style='display:none'>" + response.d[i].course_fee_paid + "</td> <td><a class='edit' href='#'>View</a></td></tr>");

                            if (i == response.d.length - 1) {
                                $("[id*=tbldata]").append("</tbody>");
                            }
                        }
                    }
                    else {
                        $.notify("No Data Found.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                }
            });
        }
        else {
            $.notify("Please Enter Proper Student Id.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    }
}

var Group_Name = "";
var studname = "";
var Group_Id = "";
var year = "";
var Course = "";
var caste = "";

$("[id*=tbldata]").on('click', 'td a.edit', function () {
    $('#newstud').modal("hide");
    var $td = $(this).closest('tr').children('td');

    Group_Name = $td.eq(1).text();
    studname = $td.eq(3).text();
    Group_Id = $td.eq(0).text();


    year = $td.eq(6).text();
    $("[id*='lblgroup']")[0].innerText = Group_Name;
    $("[id*='lblstudname']")[0].innerText = studname;
    $("[id*='lblclass']")[0].innerText = $td.eq(5).text();
    $("[id*='lblsubcourse']")[0].innerText = $td.eq(4).text();
    $("[id*='lbl_academicyear']")[0].innerText = $td.eq(7).text();
    $("[id*='lblCaste']")[0].innerText = $td.eq(8).text();
    $("[id*='lblcoursefees']")[0].innerText = $td.eq(9).text();
    caste = $td.eq(8).text();
    $("[id*='feediv']").show();
    fillreceipt();
});

function fillreceipt() {
    $.ajax({
        type: "POST",
        url: "FeeEntry_New.aspx/StrudentFeeDetails",
        data: '{stud_id:"' + $("[id*='txt_studid']").val() + '" , year:"' + year + '",group_id:"' + Group_Id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            if (response.d.length > 0) {//&& response.d[0].message == "") {

                var tbltranscat = document.getElementById("tbltransaction");
                tbltranscat.innerHTML = "";
                $("[id*=tbltransaction]").empty();
                $("[id*=transaction]").show();
                Course = response.d[0].Courseid;
                $("[id*=tbltransaction]").append("<thead style='text-transform:capitalise'><tr class='alert alert-danger'><th colspan=9><center>PAYMENT DETAILS</th></tr><tr class='alert-success'><th><center>Receipt No.</center></th><th><center>Receipt Type</center></th><th><center>Amount</center></th><th ><center>Pay Mode</center></th><th ><center>Pay Date</center></th><th ><center>Remarks</center></th><th><center>Receipt</center></th><th><center>Edit</center></th><th><center>Delete</center></th></tr></thead>");
                var totalamt = 0;
                for (var i = 0; i < response.d.length; i++) {
                    if (i == 0) {
                        $("[id*=tbltransaction]").append("<tbody>");
                    }
                    if (response.d[i].RECIPTNO.startsWith("R")) {
                        $("[id*=tbltransaction]").append("<tr ><td>" + response.d[i].RECIPTNO + "</td><td>" + response.d[i].structype + "</td><td>" + response.d[i].AMOUNT + "</td><td>" + response.d[i].RECIPTMODE + "</td><td>" + response.d[i].PAYDATE + "</td><td>" + response.d[i].REMARK + "</td><td><a  href='#' id='gdvfees" + i + "' class ='btn btn-success' >Receipt</a></td><td><a  href='#' id='gdvedit" + i + "' class ='btn btn-success'>Edit</a></td><td><a href='#' id='gdvdelete' class ='delete btn btn-success'>Delete</a></td></tr>");
                    }
                    else {
                        $("[id*=tbltransaction]").append("<tr ><td>" + response.d[i].RECIPTNO + "</td><td>" + response.d[i].structype + "</td><td>" + response.d[i].AMOUNT + "</td><td>" + response.d[i].RECIPTMODE + "</td><td>" + response.d[i].PAYDATE + "</td><td>" + response.d[i].REMARK + "</td><td><a  href='#' id='gdvfees" + i + "' class ='btn btn-success' >Receipt</a></td><td><a  href='#' id='gdvedit" + i + "' class ='btn btn-success'>Edit</a></td><td><a href='#' id='gdvdelete' class ='delete btn btn-success'>Delete</a></td></tr>");
                        totalamt = totalamt + parseInt( response.d[i].AMOUNT);
                    }
                    if (i == response.d.length - 1) {
                        $("[id*=tbltransaction]").append("</tbody>");
                    }
                }

                $("[id*='lblcoursefees']")[0].innerText = response.d[0].CRSAMOUNT;

                if (response.d[0].balanceamt=="0") {
                    $("[id*='lbl_balanceamount']")[0].innerText = "0";
                }
                else {
                    $("[id*='lbl_balanceamount']")[0].innerText = response.d[0].balanceamt;
                }

                //$("[id*='lbl_preamount']")[0].innerText = response.d[0].PAID;
                $("[id*='lbl_preamount']")[0].innerText = totalamt;
                if (response.d[0].REFUNDED != "0") {
                    $("[id*='lbl_refundedamount']")[0].innerText = response.d[0].REFUNDED;
                }
                else {
                    $("[id*='lbl_refundedamount']")[0].innerText = "0";
                }
                
                if (response.d[0].REFUND != "" && response.d[0].REFUNDED=="0") {
                    $("[id*='lbl_refundableamount']")[0].innerText = response.d[0].REFUND;
                }
                else {
                    $("[id*='lbl_refundableamount']")[0].innerText = "0";
                }

                for (var i = 0; i <= $("[id^='gdvedit']").length - 1; i++) {
                    var str = String(response.d[i].RECIPTNO);
                    $("[id^='gdvedit']")[i].setAttribute("onclick", 'editrec("' + str + '")');
                }

                for (var i = 0; i <= $("[id^='gdvfees']").length - 1; i++) {
                    var str1 = String(response.d[i].RECIPTNO);
                    $("[id^='gdvfees']")[i].setAttribute("onclick", 'getreceipt("' + str1 + '","' + response.d[i].structype + '")');
                }
            }
            else {
                $("[id*=transaction]").hide();
                if (response.d.length > 0 && response.d[0].message == "course Fees") {
                    $("[id*='lblcoursefees']")[0].innerText = response.d[0].CRSAMOUNT;
                }
                else {
                }
            }
        },
        error: function () {
            //alert('Connection error, please retry');
            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });
};

function getreceipt(receptno,type) {
    if (receptno != "") {

        $.confirm({

            title: 'Fee Receipt',
            text: "Do You want to Fee Receipt",
            content: 'Do You want to Fee Receipt',
            buttons: {
                confirm: function () {
                    //  var type = "";
                    if (type == "") {
                        $.ajax({
                            type: "POST",
                            url: "FeeEntry_New.aspx/receipt_type",
                            data: '{stud_id:"' + $("[id*='txt_studid']").val() + '" , year:"' + year + '",recipt_no:"' + receptno + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (r) {
                                if (r.d == true) {
                                    type = "Other";
                                }
                                else {
                                    type = "";
                                }
                            }
                        });
                    }
                    else {
                    }



                    PageMethods.Setsession(receptno + '|' + $("[id*='txt_studid']").val() + '|' + year);


                    if (type.startsWith("Other")) {
                        window.open("../../Staff/Fee/FeeReceiptOtherFees.aspx", "_blank");
                    }
                    else {
                        window.open("../../Staff/Fee/FeeReceiptTutionFees.aspx", "_blank");
                    }
                }, cancel: function () {
                    //$.alert('Canceled!');
                },
                //confirmButton: 'Yes',
                //cancelButton: 'No',
                //confirm: function () {
                // //  var type = "";
                //    if (type == "") {
                //        $.ajax({
                //            type: "POST",
                //            url: "FeeEntry_New.aspx/receipt_type",
                //            data: '{stud_id:"' + $("[id*='txt_studid']").val() + '" , year:"' + year + '",recipt_no:"' + receptno + '"}',
                //            contentType: "application/json; charset=utf-8",
                //            dataType: "json",
                //            async: false,
                //            success: function (r) {
                //                if (r.d == true) {
                //                    type = "Other";
                //                }
                //                else {
                //                    type = "";
                //                }
                //            }
                //        });
                //    }
                //    else {
                //    }



                //    PageMethods.Setsession(receptno + '|' + $("[id*='txt_studid']").val() + '|' + year);


                //    if (type.startsWith("Other")) {
                //        window.open("FeeReceiptOtherFees.aspx", "_blank");
                //    }
                //    else {
                //        window.open("FeeReceiptTutionFees.aspx", "_blank");
                //    }
                //},
                //cancel: function () {
                //    window.open("FeeReceiptTutionFees.aspx", "_blank");
                //}
            }
        });

    }
}


function editrec(receptno) {
    if (receptno != "") {
        $.ajax({
            type: "POST",
            url: "FeeEntry_New.aspx/getFeeDetails",
            data: '{stud_id:"' + $("[id*='txt_studid']").val() + '" , year:"' + year + '",recipt_no:"' + receptno + '",caste:"' + $("[id*='lblCaste']")[0].innerText + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                fillyear();
                if (response.d.length > 0 && response.d[0].message == "") {
                    
                    if (response.d[0].structype == "Refund") {
                        $("[id*='divtbl']").hide();
                        $("[id*='fees']").show();
                        $("[id*=tblfees]").empty();
                        $("[id*='refundiv']").show();
                        $("[id*='txtrefund']").val(response.d[0].PAID);
                        $("[id*='txtrefdet']").val(response.d[0].refdet);
                    }
                    else if (response.d[0].structype == "Narration") {

                        $("[id*=fees]").show();
                        $("[id*=divtbl]").hide();
                        $("[id*=refundiv]").show();
                        $("[id*=tblfees]").empty();
                        $("[id*='txtautho']").val('');
                        $("[id*='txtrefund']")[0].innerText = "";
                        $("[id*=ddlauthorize]")[0].selectedIndex = 0;
                        $("[id*=ddlcaste]")[0].selectedIndex = 0;
                        //$("[id*='txtrefdet']")[0].innerText = "";
                        $("[id*=authodiv]").hide();
                        $("[id*=divauth]").hide();
                        $("[id*=divcaste]").hide();
                        
                        //$("[id*=ddlnarryear]").val(response.d[0].narryear);
                        $("[id*=ddlnarryear]").val(response.d[0].narryear);
                        //$("[id*=ddlnarryear] :selected").text(response.d[0].narryear);
                        $('[id*=ddlremark]').empty();
                        $('[id*=ddlremark]').append($('<option> </option>').val("BALANCED FEES").html("BALANCED FEES"));
                        $("[id*='txtautho']").val(response.d[0].AUTHORIZEDBY);
                        $("[id*='txtrefund']").val(response.d[0].PAID);
                        //$("[id*='txtrefdet']").val(response.d[0].refdet);
                    }
                    else {
                        $("[id*=fees]").show();
                        $("[id*=tblfees]").empty();
                        $("[id*=divtbl]").show();
                        for (var i = 0; i < response.d.length; i++) {
                            if (i == 0) {
                                $("[id*=tblfees]").append("<thead><tr class='alert alert-danger'><th colspan=9><center>Select Structure To Pay Fees</th></tr><tr class='alert-success'><th><center><div class='form-inline'><span style='padding-right:5px'><input type='checkbox' style='height:15px;width:15px' id='chkAll'/>Is Check</span></div></center></th><th ><center>Structure</center></th><th ><center>Amount</center></th><th ><center>Paid</center></th><th ><center>Difference</center><th ><center>Pay</center></th></tr></thead>");
                                $("[id*='tblfees']").append("<tbody>");
                            }
                            if (response.d[0].structype == "All") {
                                if (response.d[i].flagchk == "1") {
                                    $("[id*='tblfees']").append("<tr><td><input type='checkbox' disabled checked  style='height:20px' id='chkfees_" + i + "' /></td><td>" + response.d[i].STRUCTURE + "</td><td>" + response.d[i].AMOUNT + "</td><td><center>" + response.d[i].PAID + "</center></td><td><center>" + response.d[i].DIFFERNCE + "</center></td><td><center><input type='text' class='form-control' id='txtamt_" + i + "' value=" + response.d[i].PAID + " style='width: 150px;color:black;height:24px;' onkeypress='return isNumber(event)'></center></td></tr>");
                                }
                                else {
                                    $("[id*='tblfees']").append("<tr><td><input type='checkbox'  style='height:20px' id='chkfees_" + i + "' /></td><td>" + response.d[i].STRUCTURE + "</td><td>" + response.d[i].AMOUNT + "</td><td><center>" + response.d[i].PAID + "</center></td><td><center>" + response.d[i].DIFFERNCE + "</center></td><td><center><input type='text' class='form-control' id='txtamt_" + i + "' disabled style='width: 150px;color:black;height:24px;'  onkeypress='return isNumber(event)'></center></td></tr>");
                                }
                            }
                            else {

                                if (response.d[i].flagchk == "1") {
                                    $("[id*='tblfees']").append("<tr><td><input type='checkbox' disabled checked  style='height:20px' id='chkfees_" + i + "' /></td><td>" + response.d[i].STRUCTURE + "</td><td>" + response.d[i].AMOUNT + "</td><td><center>" + response.d[i].PAID + "</center></td><td><center>" + response.d[i].DIFFERNCE + "</center></td><td><center><input type='text' class='form-control' id='txtamt_" + i + "' value=" + response.d[i].PAID + " style='width: 150px;color:black;height:24px;' onkeypress='return isNumber(event)'></center></td></tr>");
                                }
                                else {
                                    $("[id*='tblfees']").append("<tr><td><input type='checkbox'  style='height:20px' id='chkfees_" + i + "' /></td><td>" + response.d[i].STRUCTURE + "</td><td>" + response.d[i].AMOUNT + "</td><td><center>" + response.d[i].PAID + "</center></td><td><center>" + response.d[i].DIFFERNCE + "</center></td><td><center><input type='text' class='form-control' id='txtamt_" + i + "' disabled style='width: 150px;color:black;height:24px;' onkeypress='return isNumber(event)'></center></td></tr>");
                                }
                            }

                            if (i == response.d.length - 1) {
                                $("[id*='tblfees']").append("</tbody>");
                                $("[id*='tblfees']").append("<tfoot><tr><td></td><td></td><td></td><td></td><td><center>Total</center></td><td><center><input type='text' disabled  class='form-control' style='width: 150px;color:black;height:24px;' id='totaltxt' value='' /></center></td></tr></tfoot>");
                            }
                        }
                    }

                    if (response.d[0].structype == "All") {
                        $("[id*=ddlstructure]")[0].selectedIndex = 1;
                    }
                    else if (response.d[0].structype == "Refund") {
                      //  $("[id*=ddlstructure]")[0].selectedIndex = 6;
                    }
                    else if (response.d[0].structype == "Narration") {
                        $("[id*=ddlstructure]")[0].selectedIndex = 2;
                    }
                    else {
                        $("[id*=ddlstructure]")[0].selectedIndex = 1;
                    }

                    if (response.d[0].REMARK == "") {
                        $("[id*=ddlremark]")[0].selectedIndex = 0;
                    }
                    else {
                        $("[id*=ddlremark]").val(response.d[0].REMARK);
                    }

                    $("[id*=ddlremark]").attr("disabled", "disabled");

                    $("[id*=btnsave]")[0].innerText = "Update";

                    if ($("[id*=ddlremark] :selected").text().includes("Drop Student")) {
                        $('[id*=ddlauthorize]').empty();
                        $("[id*=divauth]").hide();
                        $("[id*=txtautho]").val('');
                        $("[id*=authodiv]").show();
                        $("[id*=divcaste]").show();
                        $('[id*=ddlauthorize]').append($('<option selected="selected" value="0">--Select--</option>'));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2010-2011").html("2010-2011"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2011-2012").html("2011-2012"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2012-2013").html("2012-2013"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2013-2014").html("2013-2014"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2014-2015").html("2014-2015"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2015-2016").html("2015-2016"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2016-2017").html("2016-2017"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2017-2018").html("2017-2018"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2018-2019").html("2018-2019"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2019-2020").html("2019-2020"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("2020-2021").html("2020-2021"));
                        //$('#ddlauthorize').append($('<option> </option>').val("2019-2020").html("2019-2020"));

                        if (response.d[0].authcaste != "") {
                            $("[id*=ddlcaste]").val(response.d[0].authcaste);
                        }
                        else {
                            $("[id*=ddlcaste]")[0].selectedIndex = 0;
                        }
                    }
                    else if ($("[id*=ddlremark] :selected").text().includes("Freeship / Scholarship")) {
                        $('[id*=ddlauthorize]').empty();
                        $("[id*=divauth]").hide();
                        $("[id*=txtautho]").val('');
                        $("[id*=authodiv]").show();
                        $("[id*=divcaste]").hide();
                        $("[id*=ddlcaste]")[0].selectedIndex = 0;
                        $('[id*=ddlauthorize]').append($('<option selected="selected" value="0">--Select--</option>'));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("EBC").html("EBC"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("EWS").html("EWS"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("NT-1 (NT-B)").html("NT-1 (NT-B)"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("NT-2 (NT-C)").html("NT-2 (NT-C)"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("NT-3 (NT-D)").html("NT-3 (NT-D)"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("OBC").html("OBC"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("SBC").html("SBC"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("SC").html("SC"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("SEBC").html("SEBC"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("ST").html("ST"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("TWFS").html("TWFS"));
                        $('[id*=ddlauthorize]').append($('<option> </option>').val("VJ/DT(A)").html("VJ/DT(A)"));
                    }
                    else {
                        
                            $('[id*=ddlauthorize]').empty();
                            $('[id*=ddlauthorize]').append($('<option selected="selected" value="0">--Select--</option>'));
                            $("[id*=divauth]").show();
                            if (response.d[0].structype == "Narration") {

                            }
                            else {
                                if (response.d[0].authcaste != "") {
                                    $("[id*=txtautho]").val(response.d[0].authcaste);
                                }
                                else {
                                    $("[id*=txtautho]").val(response.d[0].AUTHORIZEDBY);
                                }
                            }

                            $("[id*=authodiv]").hide();
                            $("[id*=divcaste]").hide();
                        
                    }

                    $("[id*=ddlauthorize]").attr("disabled", "disabled");

                    if (response.d[0].AUTHORIZEDBY == "") {
                        $("[id*='ddlauthorize']")[0].selectedIndex = 0;
                    }
                    else {
                        $("[id*='ddlauthorize']").val(response.d[0].AUTHORIZEDBY);
                    }

                    $("[id*='txtpaydate']").val(response.d[0].PAYDATE);

                    if (response.d[0].paymode == "Cash" || response.d[0].paymode == "Online Pay" ) {
                        $("[id*='chqddiv']").hide();
                        $("[id*='statusdiv']").hide();
                        $("[id*=ddlpaymode]")[0].selectedIndex = 1;
                        $("[id*='txtrecipt']")[0].innerText = response.d[0].RECIPTNO;
                        if (response.d[0].paymode == "Online Pay") {
                            $("[id*=ddlpaymode]")[0].selectedIndex = 5;
                        }
                    }
                    else if (response.d[0].paymode == "Cheque") {
                        $("[id*='chqddiv']").show();
                        $("[id*='txt_bnk_name']").val(response.d[0].Recpt_Bnk_Name);
                        $("[id*='txt_bran_name']").val(response.d[0].Recpt_Bnk_Branch);
                        $("[id*='chk_date']").val(response.d[0].Recpt_Chq_dt);
                        $("[id*='chk_no']").val(response.d[0].Recpt_Chq_No);
                        $("[id*='txtrecipt']")[0].innerText = response.d[0].RECIPTNO;
                        $("[id*=ddlpaymode]")[0].selectedIndex = 2;
                        $("[id*='statusdiv']").show();
                        if (response.d[0].chqstatus == "Clear") {
                            $("[id*=ddlstatus]")[0].selectedIndex = 1;
                        }
                        else if (response.d[0].chqstatus == "Bounce") {
                            $("[id*=ddlstatus]")[0].selectedIndex = 3;
                        }
                        else {
                            $("[id*=ddlstatus]")[0].selectedIndex = 2;
                        }
                    }
                    else if (response.d[0].paymode == "DD") {
                        $("[id*='chqddiv']").show();
                        $("[id*='statusdiv']").hide();
                        $("[id*='txt_bnk_name']").val(response.d[0].Recpt_Bnk_Name);
                        $("[id*='txt_bran_name']").val(response.d[0].Recpt_Bnk_Branch);
                        $("[id*='chk_date']").val(response.d[0].Recpt_Chq_dt);
                        $("[id*='chk_no']").val(response.d[0].Recpt_Chq_No);
                        $("[id*='txtrecipt']")[0].innerText = response.d[0].RECIPTNO;
                        $("[id*=ddlpaymode]")[0].selectedIndex = 3;
                    }
                    else if (response.d[0].paymode.includes("NEFT")) {
                        $("[id*='chqddiv']").show();
                        $("[id*='txt_bnk_name']").val(response.d[0].Recpt_Bnk_Name);
                        $("[id*='txt_bran_name']").val(response.d[0].Recpt_Bnk_Branch);
                        $("[id*='chk_date']").val(response.d[0].Recpt_Chq_dt);
                        $("[id*='chk_no']").val(response.d[0].Recpt_Chq_No);
                        $("[id*='txtrecipt']")[0].innerText = response.d[0].RECIPTNO;
                        $("[id*=ddlpaymode]")[0].selectedIndex = 4;
                        $("[id*='statusdiv']").show();
                        if (response.d[0].chqstatus == "Clear") {
                            $("[id*=ddlstatus]")[0].selectedIndex = 1;
                        }
                        else if (response.d[0].chqstatus == "Bounce") {
                            $("[id*=ddlstatus]")[0].selectedIndex = 3;
                        }
                        else {
                            $("[id*=ddlstatus]")[0].selectedIndex = 2;
                        }
                    }
                    else {
                        $("[id*='chqddiv']").hide();
                        $("[id*='statusdiv']").hide();
                        $("[id*=ddlpaymode]")[0].selectedIndex = 0;
                    }
                }
                else {
                    $.notify("No Data Found to Edit.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
        });
    }
};

$("[id*=tblfees]").on('click', 'input[type="checkbox"]', function () {

    if ($(this).attr("id") == 'chkAll') {
        
        if ($(this).prop("checked") == true) {
            $('[id*=tblfees] tbody tr td input[type="checkbox"]').each(function () {
                
                if ($(this).prop('disabled')) {
                    $(this).prop('checked', true);
                }
                else {
                    $(this).prop('checked', true);
                }

                var id = $(this)[0].id;
                var sp = id.split('_');
                if ($("[id*=tblfees]")[0].innerHTML != "") {
                    var tds = document.querySelectorAll('[id*=tblfees] tbody tr');
                    var tr = $(tds).eq(sp[1]).find('td');
                    if (id.startsWith('chkfees_')) {
                        var textamt = "txtamt_" + sp[1];
                        if (document.getElementById(id).checked == true && !$(this).prop('disabled')) {
                            document.getElementById(textamt).disabled = false;
                            if ($(tr)[2].innerHTML != "" && $(tr)[4].innerText == "0") {
                                document.getElementById(textamt).value = $(tr)[2].innerHTML;
                            }
                            else if ($(tr)[4].innerText != "0") {
                                document.getElementById(textamt).value = $(tr)[4].innerText;
                            }
                            else {
                            }

                            //if ($(this).prop('disabled')) {
                            //    $(this).prop('checked', false);
                            //}
                            //else {
                            //    $(this).prop('checked', true);
                            //}
                        }
                        else {
                            if ($(this).prop('disabled')) {

                            }
                            else {
                                document.getElementById(textamt).disabled = true;
                                document.getElementById(textamt).value = "";
                            }
                        }
                    }
                    if (tds.length > 0) {
                        var total = 0;
                        for (var i = 0; i < tds.length; i++) {
                            var tr = $(tds).eq(i).find('td');
                            if ($(tr)[5].firstChild.firstChild.value != "") {
                                total = total + parseInt($(tr)[5].firstChild.firstChild.value);
                            }
                            else {
                                total = total + 0;
                            }
                        }

                        
                        document.getElementById('totaltxt').value = "";
                        document.getElementById('totaltxt').value = parseInt(total);
                    }
                }
                // $(this).closest('tr').removeClass();
                //$(this).closest('tr').addClass('alert-success');
            });
        }
        else {
            $('[id*=tblfees] tbody tr td input[type="checkbox"]').each(function () {
                if ($(this).prop('disabled')) {
                    $(this).prop('checked', true);
                }
                else {
                    $(this).prop('checked', false);
                }

                var id = $(this)[0].id;
                var sp = id.split('_');
                if ($("[id*=tblfees]")[0].innerHTML != "") {
                    var tds = document.querySelectorAll('[id*=tblfees] tbody tr');
                    var tr = $(tds).eq(sp[1]).find('td');
                    if (id.startsWith('chkfees_')) {
                        var textamt = "txtamt_" + sp[1];
                        if (document.getElementById(id).checked == true) {
                            
                        }
                        else {
                            document.getElementById(textamt).disabled = true;
                            document.getElementById(textamt).value = "";
                        }
                    }
                    if (tds.length > 0) {
                        document.getElementById('totaltxt').value = "";
                        document.getElementById('totaltxt').value = 0;
                    }
                }
                // $(this).closest('tr').removeClass();
                // $(this).closest('tr').addClass('alert-danger');
            });
        }
    }
    else {
        $(this).closest('tr').removeClass();
        if ($(this).prop("checked") == true) {
            $(this).closest('tr').addClass('alert-default');
        }
        else {
            $(this).closest('tr').addClass('alert-default');
        }
    }
});


$("[id*=tbltransaction]").on('click', 'td a.delete', function () {
    var $td = $(this).closest('tr').children('td');

    var receiptno = $td.eq(0).text();

    var query = "delete from m_feeentry where Recpt_no='" + receiptno + "' and stud_id='" + $("[id*='txt_studid']").val() + "' and ayid='" + year + "'";
    $.ajax({
        type: "POST",
        url: "FeeEntry_New.aspx/saveData",
        data: '{qry:"' + query + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (r) {
            if (r.d == true) {
                $.notify("Deleted successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                $("[id*=tbltransaction]").empty();
                $("[id*=ddlstructure]")[0].selectedIndex = 0;
                $("[id*=ddlremark]")[0].selectedIndex = 0;
                $("[id*=ddlpaymode]")[0].selectedIndex = 0;
                $("[id*='chqddiv']").hide();
                $("[id*='statusdiv']").hide();
                $("[id*='fees']").hide();
                $("[id*=divtbl]").hide();
                $("[id*='txt_bnk_name']").val('');
                $("[id*='txt_bran_name']").val('');
                $("[id*='chk_date']").val('');
                $("[id*='chk_no']").val('');
                $("[id*='txtrecipt']")[0].innerText = "";
                $("[id*='lbl_preamount']")[0].innerText = "";
                $("[id*=btnsave]")[0].innerText = "Save";
                $("[id*='ddlauthorize']")[0].selectedIndex = 0;
                $("[id*='ddlcaste']")[0].selectedIndex = 0;
                fillreceipt();
            }
            else {
                $.notify("Data Not Deleted.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        }
    });

});


$("#txt_studid").on('keydown', function (e) {
    if (e.which == 13) {
        $("#btn_search").trigger('click');
        return false;
    }
});

$("[id*=ddlstructure]").change(function () {
    $("[id*='totaltxt']").val('');
    $("[id*=ddlremark]")[0].selectedIndex = 0;
    $("[id*=ddlpaymode]")[0].selectedIndex = 0;
    $("[id*='chqddiv']").hide();
    $("[id*='statusdiv']").hide();
    $("[id*='txtrecipt']")[0].innerText = "";
    $("[id*=btnsave]")[0].innerText = "Save";
    $("[id*='ddlauthorize']")[0].selectedIndex = 0;
    //$("[id*='txt_auth']").val('');
    $("[id*='txt_bnk_name']").val('');
    $("[id*='txt_bran_name']").val('');
    $("[id*='chk_date']").val('');
    $("[id*='chk_no']").val('');
    $("[id*='txtrecipt']")[0].innerText = "";
    $("[id*='txtrefund']")[0].innerText = "";
    $("[id*='txtrefund']").val('');
   // $("[id*='txtrefdet']")[0].innerText = "";
    $("[id*=refundiv]").hide();
    $("[id*=ddlremark]").removeAttr("disabled");
    $("[id*=ddlauthorize]").removeAttr("disabled");
    fillreceipt();
    if ($("[id*=ddlstructure]")[0].selectedIndex == 0) {
        $("[id*=fees]").hide();
        $("[id*=divtbl]").hide();
        fillreceipt();
    }
    else {
        //if (caste != "" || $("[id*='lblCaste']").val() != "") {
            if (Group_Id != "") {
                $.ajax({
                    type: "POST",
                    url: "FeeEntry_New.aspx/getstudentfee",
                    data: '{stud_id:"' + $("[id*='txt_studid']").val() + '",group_id:"' + Group_Id + '",caste:"' + $("[id*='lblCaste']")[0].innerText+'",year:"' + year + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        if (response.d.length > 0 && response.d[0].message == "") {
                            fillremark();
                            if ($("[id*=ddlstructure] :selected").text() == "Refund Fees") {
                                $("[id*=fees]").show();
                                $("[id*=divtbl]").hide();
                                $("[id*=refundiv]").show();
                                $("[id*=tblfees]").empty();
                                $("[id*='txtrefund']")[0].innerText = "";
                               // $("[id*='txtrefdet']")[0].innerText = "";
                            }
                            else if ($("[id*=ddlstructure] :selected").text() == "Narration Fees") {
                                $("[id*=fees]").show();
                                $("[id*=divtbl]").hide();
                                $("[id*=refundiv]").show();
                                $("[id*=tblfees]").empty();
                                $("[id*='txtautho']").val('');
                                $("[id*='txtrefund']")[0].innerText = "";
                                $("[id*=ddlauthorize]")[0].selectedIndex = 0;
                                $("[id*=ddlcaste]")[0].selectedIndex = 0;
                                //$("[id*='txtrefdet']")[0].innerText = "";
                                $("[id*=authodiv]").hide();
                                $("[id*=divauth]").show(); 
                                $("[id*=divcaste]").hide();
                                
                                fillyear();
                            }
                            else {
                                $("[id*=fees]").show();
                                $("[id*=tblfees]").empty();
                                $("[id*=divtbl]").show();
                                var totalamt = 0;
                                for (var i = 0; i < response.d.length; i++) {
                                    if (i == 0) {
                                        $("[id*=tblfees]").append("<thead><tr class='alert alert-danger'><th colspan=9><center>Select Structure To Pay Fees</th></tr><tr class='alert-success'><th><center><div class='form-inline'><span style='padding-right:5px'><input type='checkbox' style='height:15px;width:15px' id='chkAll'/>Is Check</span></div></center></th><th ><center>Structure</center></th><th ><center>Amount</center></th><th ><center>Paid</center></th><th ><center>Difference</center><th ><center>PAY</center></th></tr></thead>");
                                        $("[id*='tblfees']").append("<tbody>");
                                    }
                                    if ($("[id*=ddlstructure] :selected").text() == "All Fees") {
                                        totalamt = totalamt + parseInt(response.d[i].CRSAMOUNT);
                                        $("[id*='tblfees']").append("<tr><td><input type='checkbox'  style='height:20px' id='chkfees_" + i + "' /></td><td>" + response.d[i].STRUCTURE + "</td><td>" + response.d[i].CRSAMOUNT + "</td><td><center>" + response.d[i].PAID + "</center></td><td><center>" + response.d[i].DIFFERNCE + "</center></td><td><center><input type='text' class='form-control' id='txtamt_" + i + "' disabled style='width: 150px;color:black;height:24px;' onkeypress='return isNumber(event)' onchange='calculate(event)'></center></td></tr>");
                                    }
                                    if (i == response.d.length - 1) {
                                        $("[id*='tblfees']").append("</tbody>");
                                        $("[id*='tblfees']").append("<tfoot><tr><td></td><td></td><td></td><td></td><td><center>Total</center></td><td><center><input type='text' disabled  class='form-control' style='width: 150px;color:black;height:24px;' id='totaltxt' value='' /></center></td></tr></tfoot>");
                                    }
                                }
                                $("[id*=lblcoursefees]").val(totalamt);
                                $("[id*='lblcoursefees']")[0].innerText = totalamt;
                            }
                        }
                        else {
                            $.notify("Fee Structure Not Define.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    }
                });
            }
        //}
    }
});

$("[id*=ddlauthorize]").change(function () {
    $("[id*='totaltxt']").val('');
   
    if ($("[id*=ddlauthorize]")[0].selectedIndex == 0) {
        
    }
    else {
//        var valuese = $("[id*=ddlremark]").find("option:selected").text();
        if ($("[id*=ddlremark]").find("option:selected").text() == "Freeship / Scholarship") {
            
                if (Group_Id != "") {
                    $.ajax({
                        type: "POST",
                        url: "FeeEntry_New.aspx/getstudentfee",
                        data: '{stud_id:"' + $("[id*='txt_studid']").val() + '",group_id:"' + Group_Id + '",caste:"' + $("[id*=ddlauthorize]").find("option:selected").text() + '",year:"' + year + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (response) {
                            if (response.d.length > 0 && response.d[0].message == "") {

                                if ($("[id*=ddlstructure] :selected").text() == "Refund Fees") {
                                    $("[id*=fees]").show();
                                    $("[id*=divtbl]").hide();
                                    $("[id*=refundiv]").show();
                                    $("[id*=tblfees]").empty();
                                    $("[id*='txtrefund']")[0].innerText = "";
                                    $("[id*='txtrefdet']")[0].innerText = "";
                                }
                                else {
                                    $("[id*=fees]").show();
                                    $("[id*=tblfees]").empty();
                                    $("[id*=divtbl]").show();
                                    var totalamt = 0;
                                    for (var i = 0; i < response.d.length; i++) {
                                        if (i == 0) {
                                            $("[id*=tblfees]").append("<thead><tr class='alert alert-danger'><th colspan=9><center>Select Structure To Pay Fees</th></tr><tr class='alert-success'><th><center><div class='form-inline'><span style='padding-right:5px'><input type='checkbox' style='height:15px;width:15px' id='chkAll'/>Is Check</span></div></center></th><th ><center>STUCTURE</center></th><th ><center>AMOUNT</center></th><th ><center>PAID</center></th><th ><center>DIFFERNCE</center><th ><center>PAY</center></th></tr></thead>");
                                            $("[id*='tblfees']").append("<tbody>");
                                        }

                                        if ($("[id*=ddlstructure] :selected").text() == "All Fees") {
                                            totalamt = totalamt + parseInt(response.d[i].CRSAMOUNT);
                                            $("[id*='tblfees']").append("<tr><td><input type='checkbox'  style='height:20px' id='chkfees_" + i + "' /></td><td>" + response.d[i].STRUCTURE + "</td><td>" + response.d[i].CRSAMOUNT + "</td><td><center>" + response.d[i].PAID + "</center></td><td><center>" + response.d[i].DIFFERNCE + "</center></td><td><center><input type='text' class='form-control' id='txtamt_" + i + "' disabled style='width: 150px;color:black;height:24px;' onkeypress='return isNumber(event)' onchange='calculate(event)'></center></td></tr>");
                                        }

                                        if (i == response.d.length - 1) {
                                            // $("[id*='tblfees']").append("<tr><td></td><td></td><td></td><td></td><td><center>Total</center></td><td><center><input type='text' disabled  class='form-control' style='width: 150px;color:black;height:24px;' id='totaltxt' value='" + totalamt + "' /></ccenter></td></tr>");
                                            $("[id*='tblfees']").append("</tbody>");
                                            $("[id*='tblfees']").append("<tfoot><tr><td></td><td></td><td></td><td></td><td><center>Total</center></td><td><center><input type='text' disabled  class='form-control' style='width: 150px;color:black;height:24px;' id='totaltxt' value='' /></ccenter></td></tr></tfoot>");
                                        }
                                    }
                                    $("[id*='lblcoursefees']")[0].innerText = totalamt;
                                }
                            }
                            else {
                                $.notify("Fee Structure Not Define.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        }
                    });
                }
            
        }
        else if ($("[id*=ddlremark]").find("option:selected").text() == "Drop Student") {
            $("[id*=divcaste]").show();
            var castedrop = "";
            if ($("[id*=ddlcaste]").find("option:selected").text() == "--Select--") {
                castedrop = "OPEN";
            }
            else {
                castedrop = $("[id*=ddlcaste]").find("option:selected").text();
            }

            if (Group_Id != "") {
                $.ajax({
                    type: "POST",
                    url: "FeeEntry_New.aspx/getdropstudentfee",
                    data: '{stud_id:"' + $("[id*='txt_studid']").val() + '",group_id:"' + Group_Id + '",caste:"' + castedrop + '",year:"' + year + '",dropyear:"' + $("[id*=ddlauthorize]").find("option:selected").text() + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        if (response.d.length > 0 && response.d[0].message == "") {

                            if ($("[id*=ddlstructure] :selected").text() == "Refund Fees") {
                                $("[id*=fees]").show();
                                $("[id*=divtbl]").hide();
                                $("[id*=refundiv]").show();
                                $("[id*=tblfees]").empty();
                                $("[id*=divcaste]").hide();
                                $("[id*='txtrefund']")[0].innerText = "";
                                $("[id*='txtrefdet']")[0].innerText = "";
                            }
                            else {
                                $("[id*=fees]").show();
                                $("[id*=tblfees]").empty();
                                $("[id*=divtbl]").show();
                                var totalamt = 0;
                                for (var i = 0; i < response.d.length; i++) {
                                    if (i == 0) {
                                        $("[id*=tblfees]").append("<thead><tr class='alert alert-danger'><th colspan=9><center>Select Structure To Pay Fees</th></tr><tr class='alert-success'><th><center><div class='form-inline'><span style='padding-right:5px'><input type='checkbox' style='height:15px;width:15px' id='chkAll'/>Is Check</span></div></center></th><th ><center>STUCTURE</center></th><th ><center>AMOUNT</center></th><th ><center>PAID</center></th><th ><center>DIFFERNCE</center><th ><center>PAY</center></th></tr></thead>");
                                        $("[id*='tblfees']").append("<tbody>");
                                    }

                                    if ($("[id*=ddlstructure] :selected").text() == "All Fees") {
                                        totalamt = totalamt + parseInt(response.d[i].CRSAMOUNT);
                                        $("[id*='tblfees']").append("<tr><td><input type='checkbox'  style='height:20px' id='chkfees_" + i + "' /></td><td>" + response.d[i].STRUCTURE + "</td><td>" + response.d[i].CRSAMOUNT + "</td><td><center>" + response.d[i].PAID + "</center></td><td><center>" + response.d[i].DIFFERNCE + "</center></td><td><center><input type='text' class='form-control' id='txtamt_" + i + "' disabled style='width: 150px;color:black;height:24px;' onkeypress='return isNumber(event)' onchange='calculate(event)'></center></td></tr>");
                                    }

                                    if (i == response.d.length - 1) {
                                        // $("[id*='tblfees']").append("<tr><td></td><td></td><td></td><td></td><td><center>Total</center></td><td><center><input type='text' disabled  class='form-control' style='width: 150px;color:black;height:24px;' id='totaltxt' value='" + totalamt + "' /></ccenter></td></tr>");
                                        $("[id*='tblfees']").append("</tbody>");
                                        $("[id*='tblfees']").append("<tfoot><tr><td></td><td></td><td></td><td></td><td><center>Total</center></td><td><center><input type='text' disabled  class='form-control' style='width: 150px;color:black;height:24px;' id='totaltxt' value='' /></ccenter></td></tr></tfoot>");
                                    }
                                }
                                $("[id*='lblcoursefees']")[0].innerText = totalamt;
                            }
                        }
                        else {
                            $.notify("Fee Structure Not Define.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    }
                });
            }
        }
    }
});

$("[id*=ddlcaste]").change(function () {

    if ($("[id*=btnsave]")[0].innerText == "Save") {

        if ($("[id*=ddlremark]").find("option:selected").text() == "Drop Student") {
            $("[id*=divcaste]").show();
            var castedrop = "";
            if ($("[id*=ddlcaste]").find("option:selected").text() == "--Select--") {
                castedrop = "OPEN";
            }
            else {
                castedrop = $("[id*=ddlcaste]").find("option:selected").text();
            }

            if (Group_Id != "") {
                $.ajax({
                    type: "POST",
                    url: "FeeEntry_New.aspx/getdropstudentfee",
                    data: '{stud_id:"' + $("[id*='txt_studid']").val() + '",group_id:"' + Group_Id + '",caste:"' + castedrop + '",year:"' + year + '",dropyear:"' + $("[id*=ddlauthorize]").find("option:selected").text() + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        if (response.d.length > 0 && response.d[0].message == "") {

                            if ($("[id*=ddlstructure] :selected").text() == "Refund Fees") {
                                $("[id*=fees]").show();
                                $("[id*=divtbl]").hide();
                                $("[id*=refundiv]").show();
                                $("[id*=tblfees]").empty();
                                $("[id*=divcaste]").hide();
                                $("[id*='txtrefund']")[0].innerText = "";
                                $("[id*='txtrefdet']")[0].innerText = "";
                            }
                            else {
                                $("[id*=fees]").show();
                                $("[id*=tblfees]").empty();
                                $("[id*=divtbl]").show();
                                var totalamt = 0;
                                for (var i = 0; i < response.d.length; i++) {
                                    if (i == 0) {
                                        $("[id*=tblfees]").append("<thead><tr class='alert alert-danger'><th colspan=9><center>Select Structure To Pay Fees</th></tr><tr class='alert-success'><th><center><div class='form-inline'><span style='padding-right:5px'><input type='checkbox' style='height:15px;width:15px' id='chkAll'/>Is Check</span></div></center></th><th ><center>STUCTURE</center></th><th ><center>AMOUNT</center></th><th ><center>PAID</center></th><th ><center>DIFFERNCE</center><th ><center>PAY</center></th></tr></thead>");
                                        $("[id*='tblfees']").append("<tbody>");
                                    }

                                    if ($("[id*=ddlstructure] :selected").text() == "All Fees") {
                                        totalamt = totalamt + parseInt(response.d[i].CRSAMOUNT);
                                        $("[id*='tblfees']").append("<tr><td><input type='checkbox'  style='height:20px' id='chkfees_" + i + "' /></td><td>" + response.d[i].STRUCTURE + "</td><td>" + response.d[i].CRSAMOUNT + "</td><td><center>" + response.d[i].PAID + "</center></td><td><center>" + response.d[i].DIFFERNCE + "</center></td><td><center><input type='text' class='form-control' id='txtamt_" + i + "' disabled style='width: 150px;color:black;height:24px;' onkeypress='return isNumber(event)' onchange='calculate(event)'></center></td></tr>");
                                    }

                                    if (i == response.d.length - 1) {
                                        // $("[id*='tblfees']").append("<tr><td></td><td></td><td></td><td></td><td><center>Total</center></td><td><center><input type='text' disabled  class='form-control' style='width: 150px;color:black;height:24px;' id='totaltxt' value='" + totalamt + "' /></ccenter></td></tr>");
                                        $("[id*='tblfees']").append("</tbody>");
                                        $("[id*='tblfees']").append("<tfoot><tr><td></td><td></td><td></td><td></td><td><center>Total</center></td><td><center><input type='text' disabled  class='form-control' style='width: 150px;color:black;height:24px;' id='totaltxt' value='' /></ccenter></td></tr></tfoot>");
                                    }
                                }
                                $("[id*='lblcoursefees']")[0].innerText = totalamt;
                            }
                        }
                        else {
                            $.notify("Fee Structure Not Define.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    }
                });
            }
        }
    }
    else {

    }
});

$("[id*=ddlremark]").change(function () {

    if ($("[id*=ddlremark] :selected").text() == "Drop Student") {
        $('[id*=ddlauthorize]').empty();
        $("[id*=divauth]").hide();
        $("[id*=txtautho]").val('');
        $("[id*=authodiv]").show();
        $("[id*=divcaste]").show();
        $('[id*=ddlauthorize]').append($('<option selected="selected" value="0">--Select--</option>'));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("2010-2011").html("2010-2011"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("2011-2012").html("2011-2012"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("2012-2013").html("2012-2013"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("2013-2014").html("2013-2014"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("2014-2015").html("2014-2015"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("2015-2016").html("2015-2016"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("2016-2017").html("2016-2017"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("2017-2018").html("2017-2018"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("2018-2019").html("2018-2019"));
        //$('#ddlauthorize').append($('<option> </option>').val("2019-2020").html("2019-2020"));
    }
    else if ($("[id*=ddlremark] :selected").text() == "Freeship / Scholarship") {
        $('[id*=ddlauthorize]').empty();
        $("[id*=divauth]").hide();
        $("[id*=txtautho]").val('');
        $("[id*=authodiv]").show();
        $("[id*=divcaste]").hide();
        $('[id*=ddlauthorize]').append($('<option selected="selected" value="0">--Select--</option>'));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("EBC").html("EBC"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("EWS").html("EWS"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("NT-1 (NT-B)").html("NT-1 (NT-B)"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("NT-2 (NT-C)").html("NT-2 (NT-C)"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("NT-3 (NT-D)").html("NT-3 (NT-D)"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("OBC").html("OBC"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("SBC").html("SBC"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("SC").html("SC"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("SEBC").html("SEBC"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("ST").html("ST"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("TWFS").html("TWFS"));
        $('[id*=ddlauthorize]').append($('<option> </option>').val("VJ/DT(A)").html("VJ/DT(A)"));
    }
    else {
        $('[id*=ddlauthorize]').empty();
        $('[id*=ddlauthorize]').append($('<option selected="selected" value="0">--Select--</option>'));
        $("[id*=divauth]").show();
        $("[id*=txtautho]").val('');
        $("[id*=authodiv]").hide();
        $("[id*=divcaste]").hide();
    }

    if (Group_Id != "") {
        $.ajax({
            type: "POST",
            url: "FeeEntry_New.aspx/getstudentfee",
            data: '{stud_id:"' + $("[id*='txt_studid']").val() + '",group_id:"' + Group_Id + '",caste:"OPEN",year:"' + year + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                if (response.d.length > 0 && response.d[0].message == "") {

                    if ($("[id*=ddlstructure] :selected").text() == "Refund Fees") {
                        $("[id*=fees]").show();
                        $("[id*=divtbl]").hide();
                        $("[id*=refundiv]").show();
                        $("[id*=tblfees]").empty();
                        $("[id*='txtrefund']")[0].innerText = "";
                        $("[id*='txtrefdet']")[0].innerText = "";
                    }
                    else {
                        $("[id*=fees]").show();
                        $("[id*=tblfees]").empty();
                        $("[id*=divtbl]").show();
                        var totalamt = 0;
                        for (var i = 0; i < response.d.length; i++) {
                            if (i == 0) {
                                $("[id*=tblfees]").append("<thead><tr class='alert alert-danger'><th colspan=9><center>Select Structure To Pay Fees</th></tr><tr class='alert-success'><th><center><div class='form-inline'><span style='padding-right:5px'><input type='checkbox' style='height:15px;width:15px' id='chkAll'/>Is Check</span></div></center></th><th ><center>STUCTURE</center></th><th ><center>AMOUNT</center></th><th ><center>PAID</center></th><th ><center>DIFFERNCE</center><th ><center>PAY</center></th></tr></thead>");
                                $("[id*='tblfees']").append("<tbody>");
                            }

                            if ($("[id*=ddlstructure] :selected").text() == "All Fees") {
                                totalamt = totalamt + parseInt(response.d[i].CRSAMOUNT);
                                $("[id*='tblfees']").append("<tr><td><input type='checkbox'  style='height:20px' id='chkfees_" + i + "' /></td><td>" + response.d[i].STRUCTURE + "</td><td>" + response.d[i].CRSAMOUNT + "</td><td><center>" + response.d[i].PAID + "</center></td><td><center>" + response.d[i].DIFFERNCE + "</center></td><td><center><input type='text' class='form-control' id='txtamt_" + i + "' disabled style='width: 150px;color:black;height:24px;' onkeypress='return isNumber(event)' onchange='calculate(event)'></center></td></tr>");
                            }

                            if (i == response.d.length - 1) {
                                $("[id*='tblfees']").append("</tbody>");
                                $("[id*='tblfees']").append("<tfoot><tr><td></td><td></td><td></td><td></td><td><center>Total</center></td><td><center><input type='text' disabled  class='form-control' style='width: 150px;color:black;height:24px;' id='totaltxt' value='' /></ccenter></td></tr></tfoot>");
                            }
                        }
                        $("[id*='lblcoursefees']")[0].innerText = totalamt;
                    }
                }
                else {
                    $.notify("Fee Structure Not Define.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
        });
    }
});

function fillremark() {
    var ddl = $("[id*=ddlremark]");
    if ($("[id*=ddlstructure] :selected").text() == "Narration Fees") {
        ddl.empty();
        $('[id*=ddlremark]').append($('<option> </option>').val("BALANCED FEES").html("BALANCED FEES"));
    }
    else {
        $.ajax({
            type: "POST",
            url: "FeeEntry_New.aspx/fillremark",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            success: function (r) {
                ddl.empty().append('<option selected="selected" value="0">--Select--</option>');
                $.each(r.d, function () {
                    ddl.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
        });
    }
};

function fillyear() {
    var ddl = $("[id*=ddlnarryear]");

    $.ajax({
        type: "POST",
        url: "FeeEntry_New.aspx/getayidadm",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        async:false,
        success: function (r) {
            ddl.empty().append('<option value="0">--Select--</option>');
            $.each(r.d, function () {
                ddl.append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        }
    });
};

$("[id*=tblfees]").on('click', 'input[type="checkbox"]', function (e) {
    var id = e.currentTarget.id;
    var sp = id.split('_');
    if ($("[id*=tblfees]")[0].innerHTML != "") {
        var tds = document.querySelectorAll('[id*=tblfees] tbody tr');
        var tr = $(tds).eq(sp[1]).find('td');
        if (id.startsWith('chkfees_')) {
            var textamt = "txtamt_" + sp[1];
            if (document.getElementById(id).checked == true) {
                document.getElementById(textamt).disabled = false;
                if ($(tr)[2].innerHTML != "" && $(tr)[4].innerText == "0") {
                    document.getElementById(textamt).value = $(tr)[2].innerHTML;
                }
                else if ($(tr)[4].innerText != "0") {
                    document.getElementById(textamt).value = $(tr)[4].innerText;
                }
                else {
                }
            }
            else {
                document.getElementById(textamt).disabled = true;
                document.getElementById(textamt).value = "";
            }
        }
        if (tds.length > 0) {
            var total = 0;
            for (var i = 0; i < tds.length; i++) {
                var tr = $(tds).eq(i).find('td');
                if ($(tr)[5].firstChild.firstChild.value != "") {
                    total = total + parseInt($(tr)[5].firstChild.firstChild.value);
                }
                else {
                    total = total + 0;
                }
            }
            document.getElementById('totaltxt').value = "";
            document.getElementById('totaltxt').value = parseInt(total);
        }
    }
});

function calculate(e) {
    var tds = document.querySelectorAll('[id*=tblfees] tbody tr');
    if (tds.length > 0) {
        var total = 0;
        for (var i = 0; i < tds.length; i++) {
            var tr = $(tds).eq(i).find('td');
            if ($(tr)[5].firstChild.firstChild.value != "") {
                total = total + parseInt($(tr)[5].firstChild.firstChild.value);
            }
            else {
                total = total + 0;
            }
        }
        document.getElementById('totaltxt').value = "";
        document.getElementById('totaltxt').value = parseInt(total);
    }
};

$("[id*=ddlremark]").change(function () {

    if ($("[id*=ddlremark]:selected").text() == "--Select--") {

    }
    else if ($("[id*=ddlremark]:selected").text() == "Drop Student") {

    }
    else if ($("[id*=ddlremark]:selected").text() == "Freeship / Scholarship") {

    }
});


$("[id*=ddlpaymode]").change(function () {

    if ($("[id*=btnsave]")[0].innerText == "Save") {
        $("[id*=ddlremark]")[0].selectedIndex = 0;
        $("[id*=btnsave]")[0].innerText = "Save";
        $("[id*=ddlauthorize]")[0].selectedIndex = 0;
        $("[id*='chqddiv']").hide();
        $("[id*='statusdiv']").hide();
        $("[id*='txt_bnk_name']").val('');
        $("[id*='txt_bran_name']").val('');
        $("[id*='chk_date']").val('');
        $("[id*='chk_no']").val('');
        //$("[id*='txt_auth']")[0].innerText = "";
        $("[id*='txtrecipt']")[0].innerText = "";
        $("[id*=divcaste]").hide();

        var type = "";
        if ($("[id*=ddlpaymode]:selected").text() == "--Select--") {

        }
        else {
            if ($("[id*=ddlstructure] :selected").text() == "All Fees") {
                type = "G";
            }
                //else if ($("[id*=ddlstructure] :selected").text() == "NASA FUND") {
                //    type = "N";
                //}
                //else if ($("[id*=ddlstructure] :selected").text() == "ICHH Fees") {
                //    type = "C";
                //}
            else if ($("[id*=ddlstructure] :selected").text() == "Refund Fees") {
                type = "R";
            }
            else {
                type = "G";
            }

            if (type != "") {
                $.ajax({
                    type: "POST",
                    url: "FeeEntry_New.aspx/getreceiptno",
                    data: '{year:"' + year + '",type:"' + type + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        $("[id*='txtrecipt']")[0].innerText = response.d[0].RECIPTNO;
                        if ($("[id*=ddlpaymode]")[0].value == "Cheque") {
                            $("[id*=ddlstatus]")[0].selectedIndex = 2;
                        }
                    }
                });
            }
        }
    }
    else {

    }

    if ($("[id*=ddlpaymode] :selected").text() == "Cash" || $("[id*=ddlpaymode] :selected").text() == "Online Pay") {
        $("[id*='chqddiv']").hide();
        $("[id*='statusdiv']").hide();
    }
    else if ($("[id*=ddlpaymode] :selected").text() == "Cheque") {
        $("[id*=ddlstatus]")[0].selectedIndex = 2;
        $("[id*='chqddiv']").show();
        $("[id*='statusdiv']").show();
    }
    else if ($("[id*=ddlpaymode] :selected").text() == "DD") {
        $("[id*='chqddiv']").show();
        $("[id*='statusdiv']").hide();
    }
    else if ($("[id*=ddlpaymode] :selected").text().includes("NEFT")) {
        $("[id*='chqddiv']").show();
        $("[id*='statusdiv']").show();
    }
    else {
        $("[id*='chqddiv']").hide();
        $("[id*='statusdiv']").hide();
    }

});


function isNumber(evt) {

    if (evt.which == 13) {
        evt.preventDefault();
    }
    else {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;
    }
};

$("[id*='btnsave']").on("click", function () {
    var tds = document.querySelectorAll('[id*=tblfees] tbody tr');
    var remark = "";
    var authorizedby = "";
    if ($("[id*=ddlremark] :selected").text() == "--Select--") {
        if ($("[id*=ddlstructure] :selected").text() == "Refund Fees") {
            if ($("[id*='txtrefdet']").val() != "") {
                remark = remark + '|' + $("[id*='txtrefdet']").val();
            }
            else {
                remark = remark + '|' + "";
            }
        }
        else {
            remark = "";
        }
    }
    else {
        if ($("[id*=ddlstructure] :selected").text() == "Refund Fees") {
            //if ($("[id*='txtrefdet']").val() != "") {
            //    remark = $("[id*=ddlremark]").val() + '|' + $("[id*='txtrefdet']").val();
            //}
            //else {
            //    remark = $("[id*=ddlremark]").val() + '|' + "";
            //}
        }
        else {
            if ($("[id*=ddlstructure] :selected").text() == "Narration Fees") {
                if ($("[id*=ddlnarryear]")[0].selectedIndex > 0) {
                    var yearnr = $("[id*=ddlnarryear] :selected").text().split('-');
                    var acdyr = yearnr[0].split('/');
                    var narryear = acdyr[2].substring(2, 4);
                    remark = $("[id*=ddlremark]").val() + ' : ' + narryear + '-' + (parseInt(narryear) + 1);
                }
            }
            else {
                remark = $("[id*=ddlremark]").val();
            }
        }
    }

    if ($("[id*=txtautho]").val() != "") {
        authorizedby = $("[id*=txtautho]").val();
    }
    else if ($("[id*=ddlcaste]").val() != "" || $("[id*=ddlcaste] :selected").text() != "--Select--") {
        if ($("[id*=ddlauthorize]").val() == "0") {
            authorizedby = $("[id*=ddlcaste]").val();
        }
        else {
            if ($("[id*=ddlcaste]")[0].selectedIndex > 0) {
                authorizedby = $("[id*=ddlauthorize]").val() + ":" + $("[id*=ddlcaste]").val();
            }
            else {
                authorizedby = $("[id*=ddlauthorize]").val();
            }
        }
    }
    else if ($("[id*=ddlauthorize]").val() != "" || $("[id*=ddlauthorize] :selected").text() != "--Select--") {
        authorizedby = $("[id*=ddlauthorize]").val();
    }
    else {
        authorizedby = "";
    }

    var status = "";

    if ($("[id*=ddlstatus] :selected").text() == "--Select--") {
        status = "Pending";
    }
    else {
        status = $("[id*=ddlstatus] :selected").text();
    }

    if ($("[id*=ddlpaymode] :selected").text() == "--Select--") {
        $.notify("Please select Payment mode.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
    else {
        if ($("[id*=ddlstructure] :selected").text() == "Refund Fees") {
            $("[id*=divcaste]").hide();
            if ($("[id*='txtrefund']")[0].value != "") {
                var strqry = "";
                var errflag = false;
                if ($("[id*=btnsave]")[0].innerText == "Save") {
                    strqry = "insert into m_feeentry ";
                    
                    if ($("[id*=ddlpaymode] :selected").text() == "Cash" || $("[id*=ddlpaymode] :selected").text() == "Online Pay") {
                        if ($("[id*='txtpaydate']").val() != "") {
                            strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $("[id*=ddlstructure] :selected").text() + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                        }
                        else {
                            strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "',getdate(),'" + $("[id*=ddlstructure] :selected").text() + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                        }
                    }
                    else {

                        if ($("[id*='txt_bnk_name']").val() != "" && $("[id*='chk_date']").val() != "" && $("[id*='chk_no']").val() != "" && $("[id*='txt_bran_name']").val() != "") {
                            if ($("[id*=ddlpaymode] :selected").text() == "DD") {
                                if ($("[id*='txtpaydate']").val() != "") {
                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $("[id*=ddlstructure] :selected").text() + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                                }
                                else {
                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "',getdate(),'" + $("[id*=ddlstructure] :selected").text() + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                                }
                            }
                            else {
                                if ($("[id*='txtpaydate']").val() != "") {
                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $("[id*=ddlstructure] :selected").text() + "','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                                }
                                else {
                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "',getdate(),'" + $("[id*=ddlstructure] :selected").text() + "','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                                }
                            }
                        }
                        else {
                            errflag = true;
                        }
                    }
                }
                else {
                    if ($("[id*=ddlpaymode] :selected").text() == "Cash" || $("[id*=ddlpaymode] :selected").text() == "Online Pay") {
                        if ($("[id*='txtpaydate']").val() != "") {
                            strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text() + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',pay_date='" + $("[id*='txtpaydate']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' and ayid='" + year + "'  and struct_name='" + $("[id*=ddlstructure] :selected").text() + "'";
                        }
                        else {
                            strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text() + "',remark='" + remark + "',Authorized_By='" + authorizedby + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' and ayid='" + year + "'  and struct_name='" + $("[id*=ddlstructure] :selected").text() + "'";
                        }
                    }
                    else {

                        if ($("[id*='txt_bnk_name']").val() != "" && $("[id*='chk_date']").val() != "" && $("[id*='chk_no']").val() != "" && $("[id*='txt_bran_name']").val() != "") {
                            if ($("[id*=ddlpaymode] :selected").text() == "DD") {
                                if ($("[id*='txtpaydate']").val() != "") {
                                    strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text() + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',chq_status='Clear',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "',pay_date='" + $("[id*='txtpaydate']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and ayid='" + year + "' and struct_name='" + $("[id*=ddlstructure] :selected").text() + "'  and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' ";
                                }
                                else {
                                    strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text() + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',chq_status='Clear',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and ayid='" + year + "' and struct_name='" + $("[id*=ddlstructure] :selected").text() + "'  and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' ";
                                }
                            }
                            else {
                                if ($("[id*='txtpaydate']").val() != "") {
                                    strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',chq_status='" + status + "',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "',pay_date='" + $("[id*='txtpaydate']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and ayid='" + year + "' and struct_name='" + $("[id*=ddlstructure] :selected").text() + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' ";
                                }
                                else {
                                    strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',chq_status='" + status + "',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and ayid='" + year + "' and struct_name='" + $("[id*=ddlstructure] :selected").text() + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' ";
                                }
                            }
                        }
                        else {
                            errflag = true;
                        }
                    }
                }

                if (errflag == false) {
                    $.ajax({
                        type: "POST",
                        url: "FeeEntry_New.aspx/saveData",
                        data: '{qry:"' + strqry + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (r) {
                            if (r.d == true) {
                                $.notify("Saved successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                                $("[id*=ddlstructure]")[0].selectedIndex = 0;
                                $("[id*=ddlremark]")[0].selectedIndex = 0;
                                $("[id*=ddlpaymode]")[0].selectedIndex = 0;
                                $("[id*='chqddiv']").hide();
                                $("[id*='statusdiv']").hide();
                                $("[id*='fees']").hide();
                                $("[id*=divcaste]").hide();
                                $("[id*=divtbl]").hide();
                                $("[id*='txt_bnk_name']").val('');
                                $("[id*='txt_bran_name']").val('');
                                $("[id*='chk_date']").val('');
                                $("[id*='chk_no']").val('');
                                $("[id*='txtrecipt']")[0].innerText = "";
                                $("[id*='ddlauthorize']")[0].selectedIndex = 0;
                                $("[id*='ddlcaste']")[0].selectedIndex = 0;
                                $("[id*='txtrefund']")[0].innerText = "";
                               // $("[id*='txtrefdet']")[0].innerText = "";
                                $("[id*=refundiv]").hide();
                                $("[id*=txtautho]").val('');
                                fillreceipt();
                            }
                            else {
                                $.notify("Data Not Saved.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        }
                    });
                }
                else {
                    $.notify("Please fill all Required Details.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
            else {
                $.notify("Please Enter Amount.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        }
        else if ($("[id*=ddlstructure] :selected").text() == "Narration Fees") {

            if ($("[id*='txtrefund']")[0].value != "") {
                var strqry = "";
                var errflag = false;
                if ($("[id*=ddlnarryear]")[0].selectedIndex > 0) {
                    if ($("[id*=btnsave]")[0].innerText == "Save") {
                        strqry = "insert into m_feeentry ";

                        if ($("[id*=ddlpaymode] :selected").text() == "Cash" || $("[id*=ddlpaymode] :selected").text() == "Online Pay") {
                            if ($("[id*='txtpaydate']").val() != "") {
                                strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','TUTION FEES','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                            }
                            else {
                                strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "',getdate(),'TUTION FEES','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                            }
                        }
                        else {

                            if ($("[id*='txt_bnk_name']").val() != "" && $("[id*='chk_date']").val() != "" && $("[id*='chk_no']").val() != "" && $("[id*='txt_bran_name']").val() != "") {
                                if ($("[id*=ddlpaymode] :selected").text() == "DD") {
                                    if ($("[id*='txtpaydate']").val() != "") {
                                        strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','TUTION FEES','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                                    }
                                    else {
                                        strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "',getdate(),'TUTION FEES','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                                    }
                                }
                                else {
                                    if ($("[id*='txtpaydate']").val() != "") {
                                        strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','TUTION FEES','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                                    }
                                    else {
                                        strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $("[id*='txtrefund']")[0].value + "','" + year + "',getdate(),'TUTION FEES','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL ";
                                    }
                                }
                            }
                            else {
                                errflag = true;
                            }
                        }
                    }
                    else {
                        if ($("[id*=ddlpaymode] :selected").text() == "Cash" || $("[id*=ddlpaymode] :selected").text() == "Online Pay") {
                            if ($("[id*='txtpaydate']").val() != "") {
                                strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text() + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',pay_date='" + $("[id*='txtpaydate']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' and ayid='" + year + "'  and struct_name='TUTION FEES'";
                            }
                            else {
                                strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text() + "',remark='" + remark + "',Authorized_By='" + authorizedby + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' and ayid='" + year + "'  and struct_name='TUTION FEES'";
                            }
                        }
                        else {

                            if ($("[id*='txt_bnk_name']").val() != "" && $("[id*='chk_date']").val() != "" && $("[id*='chk_no']").val() != "" && $("[id*='txt_bran_name']").val() != "") {
                                if ($("[id*=ddlpaymode] :selected").text() == "DD") {
                                    if ($("[id*='txtpaydate']").val() != "") {
                                        strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text() + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',chq_status='Clear',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "',pay_date='" + $("[id*='txtpaydate']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and ayid='" + year + "' and struct_name='TUTION FEES'  and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' ";
                                    }
                                    else {
                                        strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text() + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',chq_status='Clear',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and ayid='" + year + "' and struct_name='TUTION FEES'  and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' ";
                                    }
                                }
                                else {
                                    if ($("[id*='txtpaydate']").val() != "") {
                                        strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',chq_status='" + status + "',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "',pay_date='" + $("[id*='txtpaydate']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and ayid='" + year + "' and struct_name='TUTION FEES' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' ";
                                    }
                                    else {
                                        strqry = strqry + " update m_feeentry set Amount='" + $("[id*='txtrefund']")[0].value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',chq_status='" + status + "',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and ayid='" + year + "' and struct_name='TUTION FEES' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "' ";
                                    }
                                }
                            }
                            else {
                                errflag = true;
                            }
                        }
                    }

                    if (errflag == false) {
                        $.ajax({
                            type: "POST",
                            url: "FeeEntry_New.aspx/saveData",
                            data: '{qry:"' + strqry + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            success: function (r) {
                                if (r.d == true) {
                                    $.notify("Saved successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                                    $("[id*=ddlstructure]")[0].selectedIndex = 0;
                                    $("[id*=ddlremark]")[0].selectedIndex = 0;
                                    $("[id*=ddlpaymode]")[0].selectedIndex = 0;
                                    $("[id*='chqddiv']").hide();
                                    $("[id*='statusdiv']").hide();
                                    $("[id*='fees']").hide();
                                    $("[id*=divcaste]").hide();
                                    $("[id*=divtbl]").hide();
                                    $("[id*='txt_bnk_name']").val('');
                                    $("[id*='txt_bran_name']").val('');
                                    $("[id*='chk_date']").val('');
                                    $("[id*='chk_no']").val('');
                                    $("[id*='txtrecipt']")[0].innerText = "";
                                    $("[id*='ddlauthorize']")[0].selectedIndex = 0;
                                    $("[id*='ddlcaste']")[0].selectedIndex = 0;
                                    $("[id*='txtrefund']")[0].innerText = "";
                                    // $("[id*='txtrefdet']")[0].innerText = "";
                                    $("[id*=refundiv]").hide();
                                    $("[id*=txtautho]").val('');
                                    fillreceipt();
                                }
                                else {
                                    $.notify("Data Not Saved.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                }
                            }
                        });
                    }
                    else {
                        $.notify("Please fill all Required Details.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                }
                else {
                    $.notify("Please select Year.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
            else {
                $.notify("Please Enter Amount.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }

        }
        else {
            if (tds.length > 0) {
                if ($("[id*=btnsave]")[0].innerText == "Save") {
                    var nocheckflag = false;
                    var flagerr = false;
                    var marksflag = false;
                    var strqry = "insert into m_feeentry ";
                    for (var i = 0; i < tds.length; i++) {
                        var tr = $(tds).eq(i).find('td');

                        if ($("[id*='chkfees_" + i + "']").prop("checked") == true) {
                            if ($(tr)[5].firstChild.firstChild.value != "") {


                                if ($("[id*=ddlpaymode] :selected").text() == "Cash" || $("[id*=ddlpaymode] :selected").text() == "Online Pay") {
                                    if ($("[id*='txtpaydate']").val() != "") {
                                        if (i == tds.length - 1) {
                                            strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL ";
                                        }
                                        else {
                                            strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL union all ";
                                        }
                                    }
                                    else {
                                        if (i == tds.length - 1) {
                                            strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "',getdate(),'" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL ";
                                        }
                                        else {
                                            strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "',getdate(),'" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL union all ";
                                        }
                                    }
                                }
                                else {

                                    if ($("[id*='txt_bnk_name']").val() != "" && $("[id*='chk_date']").val() != "" && $("[id*='chk_no']").val() != "" && $("[id*='txt_bran_name']").val() != "") {
                                        if ($("[id*=ddlpaymode] :selected").text() == "DD") {
                                            if ($("[id*='txtpaydate']").val() != "") {
                                                if (i == tds.length - 1) {
                                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','Clear','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL ";
                                                }
                                                else {
                                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','Clear','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL union all ";
                                                }
                                            }
                                            else {
                                                if (i == tds.length - 1) {
                                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "',getdate(),'" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','Clear','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL ";
                                                }
                                                else {
                                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "',getdate(),'" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','Clear','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL union all ";
                                                }
                                            }
                                        }
                                        else {
                                            if ($("[id*='txtpaydate']").val() != "") {
                                                if (i == tds.length - 1) {
                                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL ";
                                                }
                                                else {
                                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL union all ";
                                                }
                                            }
                                            else {
                                                if (i == tds.length - 1) {
                                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "',getdate(),'" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL ";
                                                }
                                                else {
                                                    strqry = strqry + " select '" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "',getdate(),'" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId + "',getdate(),NULL,0,NULL union all ";
                                                }
                                            }
                                        }
                                    }
                                    else {
                                        flagerr = true;
                                    }
                                }
                            }
                            else {
                                marksflag = true;
                            }
                        }
                        else {

                        }
                    }

                    if (strqry.endsWith('union all ')) {
                        var ind = strqry.lastIndexOf('union all');
                        if (ind != undefined && ind != -1) {
                            strqry = strqry.substring(0, ind);
                        }
                    }

                    if (marksflag == false) {
                        if (flagerr == false) {
                            if (strqry != "insert into m_feeentry ") {
                                $.ajax({
                                    type: "POST",
                                    url: "FeeEntry_New.aspx/saveData",
                                    data: '{qry:"' + strqry + '"}',
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    async: false,
                                    success: function (r) {
                                        if (r.d == true) {
                                            $.notify("Saved successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                                            $("[id*=ddlstructure]")[0].selectedIndex = 0;
                                            $("[id*=ddlremark]")[0].selectedIndex = 0;
                                            $("[id*=ddlpaymode]")[0].selectedIndex = 0;
                                            $("[id*='chqddiv']").hide();
                                            $("[id*='statusdiv']").hide();
                                            $("[id*='fees']").hide();
                                            $("[id*=divtbl]").hide();
                                            $("[id*='txt_bnk_name']").val('');
                                            $("[id*='txt_bran_name']").val('');
                                            $("[id*='chk_date']").val('');
                                            $("[id*='chk_no']").val('');
                                            $("[id*=divcaste]").hide();
                                            $("[id*='txtrecipt']")[0].innerText = "";
                                            $("[id*='ddlauthorize']")[0].selectedIndex = 0;
                                            $("[id*='ddlcaste']")[0].selectedIndex = 0;
                                            $("[id*='txtrefund']")[0].innerText = "";
                                            // $("[id*='txtrefdet']")[0].innerText = "";
                                            $("[id*=txtautho]").val('');
                                            fillreceipt();
                                        }
                                        else {
                                            $.notify("Data Not Saved.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                        }
                                    }
                                });
                            }
                            else {
                                $.notify("Please Provide amount Paid by student.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        }
                        else {
                            $.notify("Please fill all fields Required for Cheque/DD/NEFT.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    }
                    else {
                        $.notify("Please Enter Amount.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                }
                else {
                    var flagerr = false;
                    var marksflag = false;
                    var strqry = "";
                    for (var i = 0; i < tds.length; i++) {
                        var tr = $(tds).eq(i).find('td');

                        if ($("[id*='chkfees_" + i + "']").prop("checked") == true) {

                            if ($(tr)[5].firstChild.firstChild.value != "") {
                                if ($("[id*='chkfees_" + i + "']")[0].disabled == true) {
                                    if ($("[id*=ddlpaymode] :selected").text() == "Cash" || $("[id*=ddlpaymode] :selected").text() == "Online Pay") {
                                        if ($("[id*='txtpaydate']").val() != "") {
                                            if (i == tds.length - 1) {
                                                strqry = strqry + "update m_feeentry set Amount='" + $(tr)[5].firstChild.firstChild.value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='',Recpt_Bnk_Name='',Recpt_Bnk_Branch='',Recpt_Chq_dt='',pay_date='" + $("[id*='txtpaydate']").val() + "'  where stud_id='" + $("[id*='txt_studid']").val() + "' and Struct_name='" + $(tr).eq(1).text() + "' and ayid='" + year + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "'";
                                            }
                                            else {
                                                strqry = strqry + "update m_feeentry set Amount='" + $(tr)[5].firstChild.firstChild.value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='',Recpt_Bnk_Name='',Recpt_Bnk_Branch='',Recpt_Chq_dt='',pay_date='" + $("[id*='txtpaydate']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and Struct_name='" + $(tr).eq(1).text() + "' and ayid='" + year + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "';  ";
                                            }
                                        }
                                        else {
                                            if (i == tds.length - 1) {
                                                strqry = strqry + "update m_feeentry set Amount='" + $(tr)[5].firstChild.firstChild.value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='',Recpt_Bnk_Name='',Recpt_Bnk_Branch='',Recpt_Chq_dt=''  where stud_id='" + $("[id*='txt_studid']").val() + "' and Struct_name='" + $(tr).eq(1).text() + "' and ayid='" + year + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "'";
                                            }
                                            else {
                                                strqry = strqry + "update m_feeentry set Amount='" + $(tr)[5].firstChild.firstChild.value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='',Recpt_Bnk_Name='',Recpt_Bnk_Branch='',Recpt_Chq_dt='' where stud_id='" + $("[id*='txt_studid']").val() + "' and Struct_name='" + $(tr).eq(1).text() + "' and ayid='" + year + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "';  ";
                                            }
                                        }
                                    }
                                    else {
                                        if ($("[id*='txt_bnk_name']").val() != "" && $("[id*='chk_date']").val() != "" && $("[id*='chk_no']").val() != "" && $("[id*='txt_bran_name']").val() != "") {
                                            if ($("[id*='txtpaydate']").val() != "") {
                                                if (i == tds.length - 1) {
                                                    strqry = strqry + "update m_feeentry set Amount='" + $(tr)[5].firstChild.firstChild.value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "',chq_status='" + status + "',pay_date='" + $("[id*='txtpaydate']").val() + "'  where stud_id='" + $("[id*='txt_studid']").val() + "' and Struct_name='" + $(tr).eq(1).text().replace(/\'/g, "\''") + "' and ayid='" + year + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "'";
                                                }
                                                else {
                                                    strqry = strqry + "update m_feeentry set Amount='" + $(tr)[5].firstChild.firstChild.value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "',chq_status='" + status + "',pay_date='" + $("[id*='txtpaydate']").val() + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and Struct_name='" + $(tr).eq(1).text().replace(/\'/g, "\''") + "' and ayid='" + year + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "'; ";
                                                }
                                            }
                                            else {
                                                if (i == tds.length - 1) {
                                                    strqry = strqry + "update m_feeentry set Amount='" + $(tr)[5].firstChild.firstChild.value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "',chq_status='" + status + "'  where stud_id='" + $("[id*='txt_studid']").val() + "' and Struct_name='" + $(tr).eq(1).text().replace(/\'/g, "\''") + "' and ayid='" + year + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "'";
                                                }
                                                else {
                                                    strqry = strqry + "update m_feeentry set Amount='" + $(tr)[5].firstChild.firstChild.value + "',mod_dt=getdate(),user_id='"+empId+"',recpt_mode='" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "',remark='" + remark + "',Authorized_By='" + authorizedby + "',Recpt_Chq_No='" + $("[id*='chk_no']").val() + "',Recpt_Bnk_Name='" + $("[id*='txt_bnk_name']").val() + "',Recpt_Bnk_Branch='" + $("[id*='txt_bran_name']").val() + "',Recpt_Chq_dt='" + $("[id*='chk_date']").val() + "',chq_status='" + status + "' where stud_id='" + $("[id*='txt_studid']").val() + "' and Struct_name='" + $(tr).eq(1).text().replace(/\'/g, "\''") + "' and ayid='" + year + "' and recpt_no='" + $("[id*='txtrecipt']")[0].innerText + "'; ";
                                                }
                                            }
                                        }
                                        else {
                                            flagerr = true;
                                        }
                                    }
                                }
                                else {
                                    if ($("[id*=ddlpaymode] :selected").text() == "Cash" || $("[id*=ddlpaymode] :selected").text() == "Online Pay") {
                                        if ($("[id*='txtpaydate']").val() != "") {
                                            if (i == tds.length - 1) {
                                                strqry = strqry + "insert into m_feeentry values ('" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL) ";
                                            }
                                            else {
                                                strqry = strqry + "insert into m_feeentry values ('" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL) ;  ";
                                            }
                                        }
                                        else {
                                            if (i == tds.length - 1) {
                                                strqry = strqry + "insert into m_feeentry values ('" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "',getdate(),'" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL) ";
                                            }
                                            else {
                                                strqry = strqry + "insert into m_feeentry values ('" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "',getdate(),'" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text() + "','" + $("[id*='txtrecipt']")[0].innerText + "',NULL,NULL,NULL,NULL,'Clear','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL) ;  ";
                                            }
                                        }
                                    }
                                    else {
                                        if ($("[id*='txt_bnk_name']").val() != "" && $("[id*='chk_date']").val() != "" && $("[id*='chk_no']").val() != "" && $("[id*='txt_bran_name']").val() != "") {
                                            if ($("[id*='txtpaydate']").val() != "") {
                                                if (i == tds.length - 1) {
                                                    strqry = strqry + "insert into m_feeentry values ('" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL) ";
                                                }
                                                else {
                                                    strqry = strqry + "insert into m_feeentry values ('" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "','" + $("[id*='txtpaydate']").val() + "','" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL) ; ";
                                                }
                                            }
                                            else {
                                                if (i == tds.length - 1) {
                                                    strqry = strqry + "insert into m_feeentry values ('" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "',getdate(),'" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL) ";
                                                }
                                                else {
                                                    strqry = strqry + "insert into m_feeentry values ('" + $("[id*='txt_studid']").val() + "','" + $(tr)[5].firstChild.firstChild.value + "','" + year + "',getdate(),'" + $(tr).eq(1).text().replace(/\'/g, "\''") + "','" + $("[id*=ddlpaymode] :selected").text().replace(/\\/g, "\\\\") + "','" + $("[id*='txtrecipt']")[0].innerText + "','" + $("[id*='chk_date']").val() + "','" + $("[id*='chk_no']").val() + "','" + $("[id*='txt_bnk_name']").val() + "','" + $("[id*='txt_bran_name']").val() + "','" + status + "','Fee','" + remark + "','" + authorizedby + "','" + empId+"',getdate(),NULL,0,NULL) ; ";
                                                }
                                            }
                                        }
                                        else {
                                            flagerr = true;
                                        }
                                    }
                                }
                            }
                            else {
                                marksflag = true;
                            }
                        }
                    }

                    if (strqry.endsWith('; '))
                        var ind = strqry.lastIndexOf(';');
                    if (ind != undefined && ind != -1) {
                        strqry = strqry.substring(0, ind);
                    }

                    if (marksflag == false) {
                        if (flagerr == false) {
                            if (strqry != "") {
                                $.ajax({
                                    type: "POST",
                                    url: "FeeEntry_New.aspx/saveData",
                                    data: '{qry:"' + strqry + '"}',
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    async: false,
                                    success: function (r) {
                                        if (r.d == true) {
                                            $.notify("Updated successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                                            $("[id*=ddlstructure]")[0].selectedIndex = 0;
                                            $("[id*=ddlremark]")[0].selectedIndex = 0;
                                            $("[id*=ddlpaymode]")[0].selectedIndex = 0;
                                            $("[id*='chqddiv']").hide();
                                            $("[id*='statusdiv']").hide();
                                            $("[id*='fees']").hide();
                                            $("[id*=divtbl]").hide();
                                            $("[id*='txt_bnk_name']").val('');
                                            $("[id*='txt_bran_name']").val('');
                                            $("[id*='chk_date']").val('');
                                            $("[id*='chk_no']").val('');
                                            $("[id*='txtrecipt']")[0].innerText = "";
                                            $("[id*=btnsave]")[0].innerText = "Save";
                                            $("[id*='ddlauthorize']")[0].selectedIndex = 0;
                                            $("[id*='ddlcaste']")[0].selectedIndex = 0;
                                            $("[id*=txtautho]").val('');
                                            fillreceipt();
                                        }
                                        else {
                                            $.notify("Data Not Saved.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                        }
                                    }
                                });
                            }
                            else {

                            }
                        }
                        else {
                            $.notify("Please fill all fields Required for Cheque/DD/NEFT.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    }
                    else {
                        $.notify("Please Enter Amount.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                }
            }
            else {
                $.notify("No Data Found To Save.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        }
    }
});

$("[id*='btnclear']").on("click", function () {
    $("[id*=ddlstructure]")[0].selectedIndex = 0;
    $("[id*=ddlremark]")[0].selectedIndex = 0;
    $("[id*=ddlpaymode]")[0].selectedIndex = 0;
    $("[id*='chqddiv']").hide();
    $("[id*='statusdiv']").hide();
    $("[id*='fees']").hide();
    $("[id*=divtbl]").hide();
    $("[id*='txt_bnk_name']").val('');
    $("[id*='txt_bran_name']").val('');
    $("[id*='chk_date']").val('');
    $("[id*='chk_no']").val('');
    $("[id*='txtrecipt']")[0].innerText = "";
  //  $("[id*='txtrefdet']")[0].innerText = "";
    $("[id*='txtrefund']")[0].innerText = "";
    $("[id*='refundiv']").hide();
    $("[id*='divcaste']").hide();
    $("[id*='txtpaydate']").val('');
    $("[id*=ddlcaste]")[0].selectedIndex = 0;
    $("[id*=txtautho]").val('');
    fillreceipt();
    $("[id*=btnsave]")[0].innerText = "Save";
});

$("[id*=tbltransaction]").on('click', 'td a.edit', function () {
    $('#newstud').modal("hide");
    var $td = $(this).closest('tr').children('td');

    Group_Name = $td.eq(1).text();
    studname = $td.eq(3).text();
    Group_Id = $td.eq(0).text();

});


$("[id*='btn_refresh']").on("click", function () {
    clear();
    $("[id*=divcaste]").hide();
    $("[id*=ddlstructure]")[0].selectedIndex = 0;
    $("[id*=ddlremark]")[0].selectedIndex = 0;
    $("[id*=ddlpaymode]")[0].selectedIndex = 0;
    $("[id*='chqddiv']").hide();
    $("[id*='statusdiv']").hide();
    $("[id*='fees']").hide();
    $("[id*=divtbl]").hide();
    $("[id*='txt_bnk_name']").val('');
    $("[id*='txt_bran_name']").val('');
    $("[id*='txt_studid']").val('');
    $("[id*='chk_date']").val('');
    $("[id*='chk_no']").val('');
    //$("[id*='totaltxt']").val('');
    $("[id*='txtrecipt']")[0].innerText = "";
    $("[id*=btnsave]")[0].innerText = "Save";
});