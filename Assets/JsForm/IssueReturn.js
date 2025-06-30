
var type = "";
var date1 = "";
var date2 = "";
var booktype = "";
var accessiontype = "";
var return_date = "";
var gridbooklength = 0;
var gridpaymentlength = 0;
$("[id*='btn_return']")[0].innerText = "OK";
$("[id*='accessiontype']")[0].style.display = 'none';
var guest_id = "";

$(document).ready(function () {


    //Loader
    var x = document.getElementsByClassName("loader");
    x[0].style.display = "none";




    $("[id*='accessiontype']")[0].style.display = 'none';
    $.ajax({
        type: "POST",
        url: "IssueReturn.aspx/getayidadm",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            //  $("[id*=ddlyear]").empty().append('<option selected="selected" value="0">--select--</option>');
            $.each(r.d, function () {
                $("[id*=ddlyear]").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            hasError = true;
            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });

    //$('input[name="date"]').datetimepicker({
    //    changeMonth: false,
    //    changeYear: false,
    //    timepicker: false,
    //    format: 'd/MMM/YYYY',
    //    viewMode: "months",
    //    minViewMode: "months"
    //}
    //       );


    jQuery('[id*=issuedate]').datetimepicker(
        {
            changeMonth: false,
            changeYear: false,
            timepicker: false,
            format: 'd-M-Y h:m:s',
            viewMode: "months",
            minViewMode: "months",
            //  defaultDate: true
            //endDate: "+0m"
            //defaultDate: new Date
            //  defaultDate: new Date()

        });



    // $(".selector").datetimepicker({ defaultDate: new Date() });
    // var currentDate = new Date();
    // currentDate = moment().format('d/MMM/YYYY');
    //  $("#issuedate").datetimepicker("setDate", currentDate);
    //$("[id*='issuedate']").val('01/01/2017');
    //var $datepicker = $('#issuedate');
    //$datepicker.datetimepicker();
    //$datepicker.datetimepicker('setDate', new Date());

    jQuery('[id*=return_date]').datetimepicker(
        {
            changeMonth: false,
            changeYear: false,
            timepicker: false,
            format: 'd-M-Y h:m:s',
            viewMode: "months",
            minViewMode: "months"

            //endDate: "+0m"
        });



    jQuery('[id*=returndate]').datetimepicker(
        {
            changeMonth: false,
            changeYear: false,
            timepicker: false,
            format: 'd-M-Y h:m:s',
            viewMode: "months",
            minViewMode: "months"

            //endDate: "+0m"
        });
    jQuery('[id*=returnbookdate]').datetimepicker(
        {
            changeMonth: false,
            changeYear: false,
            timepicker: false,
            format: 'd-M-Y h:m:s',
            viewMode: "months",
            minViewMode: "months"

            //endDate: "+0m"
        });
    jQuery('[id*=renewdate]').datetimepicker(
        {
            changeMonth: false,
            changeYear: false,
            timepicker: false,
            format: 'd-M-Y h:m:s',
            viewMode: "months",
            minViewMode: "months"

            //endDate: "+0m"
        });





    //function DisableMonday(date) {

    //    var day = date.getDay();
    //    // If day == 1 then it is MOnday
    //    if (day == 1) {

    //        return [false] ; 

    //    } else { 

    //        return [true] ;
    //    }

    //}

    //$(function() {
    //    $( "#datepicker" ).datepicker({
    //        beforeShowDay: DisableMonday
    //    });
    //});















});

$("[id*='basicdetails']").on("click", function () {

    if ($("[id*='divbasic']")[0].style.display == 'none')  //.visibilityState == "visible"
    {
        $("#divbasic").show(500);

    }
    else {
        $("#divbasic").hide(500);
    }

});

$("[id*='bookdetails']").on("click", function () {

    // var div=document.getElementById("divpersonal");

    if ($("[id*='divbook']")[0].style.display == 'none')  //.visibilityState == "visible"
    {
        $("#divbook").show(500);

    }
    else {
        $("#divbook").hide(500);
    }

});

$("[id*='MakeIssue']").on("click", function () {

    // var div=document.getElementById("divpersonal");

    if ($("[id*='MkIssue']")[0].style.display == 'none')  //.visibilityState == "visible"
    {
        $("#MkIssue").show(500);

    }
    else {
        $("#MkIssue").hide(500);
    }

});

$("[id*='GuestDetails']").on("click", function () {

    // var div=document.getElementById("divpersonal");

    if ($("[id*='DivGuest']")[0].style.display == 'none')  //.visibilityState == "visible"
    {
        $("#DivGuest").show(500);

    }
    else {
        $("#DivGuest").hide(500);

    }

});

$("[id*='GuestMakeIssue']").on("click", function () {

    // var div=document.getElementById("divpersonal");

    if ($("[id*='DivGuestIssue']")[0].style.display == 'none')  //.visibilityState == "visible"
    {
        $("#DivGuestIssue").show(500);

    }
    else {
        $("#DivGuestIssue").hide(500);
    }

});

$("[id*='LibEployee']").on("click", function () {

    // var div=document.getElementById("divpersonal");

    if ($("[id*='DivStaff']")[0].style.display == 'none')  //.visibilityState == "visible"
    {
        $("#DivStaff").show(500);

    }
    else {
        $("#DivStaff").hide(500);
    }

});

$("[id*='LibIsue']").on("click", function () {

    // var div=document.getElementById("divpersonal");

    if ($("[id*='divlibissue']")[0].style.display == 'none')  //.visibilityState == "visible"
    {
        $("#divlibissue").show(500);

    }
    else {
        $("#divlibissue").hide(500);
    }

});

$("[id*='btn_forguest']").on("click", function () {
    // $("#Guestpanel").show(500);
    $("#issue").hide(500);// $("#bookissueforguest").hide(500);
    $("#guest").hide(500);
    $("#pay").hide(500);
    if ($("[id*='Guestpanel']")[0].style.display == 'none')  //.visibilityState == "visible"
    {
        $("#paneldetailsall").show(500);
        $("#Guestpanel").show(500);
        $("#paneldetails").hide(500);
        $("[id*='txtStudId']").val('');
        $("#assesion_panel_id").show(500);
        $("#gridpanel").show(500);

        $("#bookaccession").hide(500);
        $("#makeissue").hide(500);
        $("#btn").hide(500);
        $("#Employee").hide(500);

        Clear();
        GuestClear();

        // $("[id*='lblpending']")[0].innerText = "";
        $("#gridpendingpayments").hide(500);
        //$("[id*='lblpendingbook']")[0].innerText = "";
        $("#gridpending").hide(500);

    }
    else {
        $("#Guestpanel").hide(500);
        $("#paneldetailsall").hide(500);
        $("#Employee").hide(500);
        // $("#bookissueforguest").hide(500);
        // gridhideshow();
        // $("[id*='lblpending']")[0].innerText = "";
        $("#gridpendingpayments").hide(500);
        //  $("[id*='lblpendingbook']")[0].innerText = "";
        $("#gridpending").hide(500);
    }
});


$("[id*='btn_search']").on("click", function () {
    var x = document.getElementsByClassName("loader");
    x[0].style.display = "block";
    var std_id = $("[id*='txtStudId']").val();
    std_id = std_id.trim();
    $("[id*='txtStudId']").val(std_id);

    gridpaymentlength = 0;
    gridbooklength = 0;
    var numbers = /^[0-9]+$/;
    if ($("[id*='txtStudId']").val() != "") {

        if ($("[id*='txtStudId']").val().match(numbers)) {
            type = "student";
        }
        else {
            type = "employee";
        }


        $.ajax({
            type: "POST",
            url: "IssueReturn.aspx/studentbook",
            data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",type:"' + type + '",ayid:"' + $("[id*=ddlyear] :selected").val() + '",connect:"' + $("[id*='ddlselect']").val() + '",acc_id:""}',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d.length > 0) {

                    $("#reset").show(500);

                    if (type == "student") {

                        $("#guest").hide(500);
                        $("#paneldetailsall").show(500);
                        $("#Employee").hide(500);
                        $("#paneldetails").show(500);
                        $("#Guestpanel").hide(500);
                        $("#assesion_panel_id").show(500);
                        $("#gridpanel").show(500);
                        $("#bookaccession").hide(500);
                        // $("#makeissue").hide(500);
                        $("#btn").hide(500);
                        // $("#bookissueforguest").hide(500);
                        // $("[id*='lblguest']")[0].innerText = "";

                        Clear();
                        document.getElementById("imgstud").src = "data:image/png;base64," + data.d[0].stud_img;

                        $("[id*='txtStudName']")[0].innerText = (data.d[0].student_name);

                        if (data.d[0].stud_PermanantPhone == "" || data.d[0].stud_NativePhone == "") {
                            $("[id*='txtmobno']")[0].innerText = (data.d[0].stud_PermanantPhone) + (data.d[0].stud_NativePhone);
                        }
                        else {
                            $("[id*='txtmobno']")[0].innerText = (data.d[0].stud_PermanantPhone) + ' , ' + data.d[0].stud_NativePhone;
                        }
                        $("[id*='lblSubcourseId']")[0].innerText = (data.d[0].subcourse_id);
                        $("[id*='txtclass']")[0].innerText = (data.d[0].subcourse_name);
                        $("[id*='txtDiv']")[0].innerText = (data.d[0].Division);
                        $("[id*='txtRollNo']")[0].innerText = (data.d[0].Roll_no);
                        // $("[id*='imgstud']").val() = data.d[0].stud_img;
                        $("[id*='txtaddress']")[0].innerText = (data.d[0].stud_PermanantAdd);

                        loadpendingbook();
                        loadpendingpayments();
                        fillpastissue($("[id*='txtStudId']").val().trim());
                        gridhideshow();

                        $("[id*='txtday']")[0].value = '7';
                        ///  holi('');
                    }
                    else if (type == "employee") {
                        $("#guest").hide(500);
                        $("#paneldetailsall").show();
                        $("#paneldetails").hide(500);
                        $("#Guestpanel").hide(500);
                        $("[id*='Employee']").show();

                        // $("#Employee").show();
                        $("#assesion_panel_id").show();
                        $("#gridpanel").show();

                        $("#bookaccession").hide(500);
                        $("#makeissue").hide(500);
                        $("#btn").hide(500);


                        Clear();
                        document.getElementById("imgemployee").src = data.d[0].emp_photo;
                        $("[id*='txtempname']")[0].innerText = (data.d[0].emp_name);

                        if (data.d[0].emp_mobile1 == "" || data.d[0].emp_mobile2 == "") {
                            $("[id*='txtempmobno']")[0].innerText = (data.d[0].emp_mobile1) + (data.d[0].emp_mobile2);
                        }
                        else {
                            $("[id*='txtempmobno']")[0].innerText = (data.d[0].emp_mobile1) + ' , ' + data.d[0].emp_mobile2;
                        }

                        $("[id*='txtempdepart']")[0].innerText = (data.d[0].Department_name);
                        $("[id*='txtempdesing']")[0].innerText = (data.d[0].Designation_Title);

                        $("[id*='txtempaddress']")[0].innerText = (data.d[0].emp_address_curr);

                        loadpendingbook();
                        loadpendingpayments();
                        fillpastissue($("[id*='txtStudId']").val().trim());
                        gridhideshow();
                        $("[id*='txtday']")[0].value = '30';

                        // holi('');
                    }
                    var x = document.getElementsByClassName("loader");
                    x[0].style.display = "none";
                }
                else {
                    $.notify("Enter Proper ID", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $("#paneldetails").hide(500);
                }
            },
            error: function () {
                //alert('Connection error, please retry');
                hasError = true;
                //$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
            //}

        });

    }
    else {
        $.notify("Enter Proper ID", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        $("#paneldetails").hide(500);
    }

});

// for past Books issue of members --(vaidehi -24-04-2024)
function fillpastissue(stud_id) {

    $.ajax({
        type: "POST",
        url: "IssueReturn.aspx/getpastissue_rpt",
        data: '{stud_id:"' + stud_id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.d.length > 0) {
                $("[id*=rowgridd]")[0].style.display = "block";

                var Table = document.getElementById("tbltransactionbooks");

                Table.innerHTML = "";
                if (data.d[0] != undefined && data.d[0] != "" && data.d[0] != null) {
                    $("[id*=rowgridd]").slideDown('slow');

                    $("[id*=tbltransactionbooks]").append("<thead><tr><th>Sr.No</th><th>Accession ID</th><th>Title</th><th>Type</th><th>Issue Date</th><th >Return Date</th><th >Issued ON</th></tr></thead>");

                    for (var i = 0; i < data.d.length; i++) {
                        if (i == 0) {
                            $("[id*=tbltransactionbooks]").append("<tbody>");
                        }
                        var response = parseInt(i) + 1;

                        $("[id*=tbltransactionbooks]").append("<tr><td>" + response + "</td><td>" + data.d[i].accession_id_trans + "</td><td>" + data.d[i].TITLE_trans + "</td><td>" + data.d[i].accession_type_trans + "</td><td>" + data.d[i].issue_date_trans + "</td><td>" + data.d[i].return_date_trans + "</td><td>" + data.d[i].H_R_trans + "</td></tr>");

                        if (i == data.d.length - 1) {
                            $("[id*=tbltransactionbooks]").append("</tbody>");
                        }
                    }
                }
            }
            else {
                $("[id*=rowgridd]")[0].style.display = "none";
                //  $.notify("No data found", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        },
        error: function () {
            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });
}

$("[id*='btn_accessionsearch']").on("click", function () {


    if ($("[id*='txtAccessionNo']").val() == "") {
        $("#bookaccession").hide(500);
        $("#makeissue").hide(500);
        $("#btn").hide(500);
        accessionClear();
        $("[id*='lblissuedbook']")[0].innerText = "";

    }
    else {
        var x = document.getElementsByClassName("loader");
        x[0].style.display = "block";
        $.ajax({
            type: "POST",
            url: "IssueReturn.aspx/chk_if_acc_in_Book_CD_Serial",
            data: '{accession_id:"' + $("[id*='txtAccessionNo']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {


                if (data.d == "") {

                    $.notify("NO SUCH ACCESSION", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

                }
                else {
                    booktype = data.d;

                    getdate();
                    /// holi('');

                    $('#return_date').prop('disabled', true)
                    $.ajax({
                        type: "POST",
                        url: "IssueReturn.aspx/studentbook",
                        data: '{stud_id:"' + $("[id*='txtAccessionNo']").val() + '",type:"' + data.d + '",ayid:"",connect:"' + $("[id*='ddlselect']").val() + '",acc_id:""}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (data) {

                            //search already issued book/cd/serial
                            $.ajax({
                                type: "POST",
                                url: "IssueReturn.aspx/search_if_issued",
                                data: '{accession_id:"' + $("[id*='txtAccessionNo']").val() + '",accession_type:"' + booktype + '"}',
                                contentType: "application/json; charset=utf-8",
                                async: false,
                                success: function (data) {
                                    if (data.d.length > 0) {


                                        $("[id*='lblissuedbook']")[0].style.display = 'block';
                                        if (booktype == "BOOK") {

                                            if (data.d[0].H_R == "H") {
                                                $("[id*='lblissuedbook']")[0].innerText = "Book Already Issued To ID : " + data.d[0].member_id + " - " + data.d[0].student_of + " on Home Card ";
                                            }
                                            else if (data.d[0].H_R == "R") {
                                                $("[id*='lblissuedbook']")[0].innerText = "Book Already Issued To ID : " + data.d[0].member_id + " - " + data.d[0].student_of + " on Readers Card";
                                            }
                                        }
                                        else if (booktype == "CD") {
                                            if (data.d[0].H_R == "H") {
                                                $("[id*='lblissuedbook']")[0].innerText = "CD Already Issued To ID : " + data.d[0].member_id + " - " + data.d[0].student_of + " on Home Card ";
                                            }
                                            else if (data.d[0].H_R == "R") {
                                                $("[id*='lblissuedbook']")[0].innerText = "CD Already Issued To ID : " + data.d[0].member_id + " - " + data.d[0].student_of + " on Readers Card";
                                            }
                                        }
                                        else if (booktype == "SERIAL") {
                                            if (data.d[0].H_R == "H") {
                                                $("[id*='lblissuedbook']")[0].innerText = "Serial Already Issued To ID : " + data.d[0].member_id + " - " + data.d[0].student_of + " on Home Card ";
                                            }
                                            else if (data.d[0].H_R == "R") {
                                                $("[id*='lblissuedbook']")[0].innerText = "Serial Already Issued To ID : " + data.d[0].member_id + " - " + data.d[0].student_of + " on Readers Card";
                                            }
                                        }
                                        $("#makeissue").hide(500);
                                        $("#btn").hide(500);
                                        if ($("[id*='txtStudId']").val() == "") {
                                            $.ajax({
                                                type: "POST",
                                                url: "IssueReturn.aspx/guest_retrieve",
                                                data: '{search_string:"' + $("[id*='txtAccessionNo']").val() + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
                                                contentType: "application/json; charset=utf-8",
                                                async: false,
                                                success: function (data) {
                                                    $("#guest").show(500);
                                                    $("#reset").show(500);
                                                    loadguest();
                                                    ////$("[id*='txtguestnameee']").val(data.d[0].guest_name) ;
                                                    ////$("[id*='txtguestmobno']").val(data.d[0].guest_pn_no)  ;
                                                    ////$("[id*='txtGuestRemark']").val(data.d[0].remark) ;
                                                    ////$("[id*='txtguestAddress']").val(data.d[0].guest_add);
                                                    var x = document.getElementsByClassName("loader");
                                                    x[0].style.display = "none";

                                                },
                                                error: function () {
                                                    //alert('Connection error, please retry');
                                                    hasError = true;
                                                    $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                                }
                                            });
                                        }
                                        //}

                                    }


                                    else {
                                        $("#makeissue").show(500);
                                        $("#btn").show(500);
                                        $("[id*='lblissuedbook']")[0].style.display = 'none';
                                    }


                                },
                                error: function () {
                                    hasError = true;
                                    $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                }
                                //}

                            });
                            if (booktype == "BOOK") {

                                $("[id*='accessiontype']")[0].style.display = 'block';
                                $("[id*='accessiontype']")[0].innerText = "Type : " + (booktype);
                                $("#bookaccession").show(500);

                                $("[id*='txtbooktitle']")[0].innerText = (data.d[0].book_title);
                                $("[id*='txtauthor']")[0].innerText = (data.d[0].Author);
                                $("[id*='txtPublisher']")[0].innerText = (data.d[0].Publisher);

                            }
                            else if (booktype == "CD") {

                                $("[id*='accessiontype']")[0].style.display = 'block';
                                $("[id*='accessiontype']")[0].innerText = "Type : " + (booktype);
                                $("#bookaccession").hide(500);
                                $("#cdaccession").show(500);

                                $("[id*='txtcdtitle']")[0].innerText = (data.d[0].cd_name);
                                $("[id*='txtcdauthor']")[0].innerText = (data.d[0].cd_content_type);
                                $("[id*='txcdtPublisher']")[0].innerText = (data.d[0].general_name);
                            }
                            else if (booktype == "SERIAL") {

                                $("[id*='accessiontype']")[0].style.display = 'block';
                                $("[id*='accessiontype']")[0].innerText = "Type : " + (booktype);
                                $("#serialaccession").show(500);
                                $("#bookaccession").hide(500);
                                $("#cdaccession").hide(500);

                                $("[id*='txtbooktitle']")[0].innerText = (data.d[0].book_title);
                                $("[id*='txtauthor']")[0].innerText = (data.d[0].Author);
                                $("[id*='txtPublisher']")[0].innerText = (data.d[0].Publisher);

                            }

                            var x = document.getElementsByClassName("loader");
                            x[0].style.display = "none";

                        },
                        error: function () {                          
                            hasError = true;
                        }
                    });
                }
            },
            error: function () {
                hasError = true;
            }
            //}

        });

    }

});

$("[id*='txtAccessionNo']").change(function () {

    if ($("[id*='txtAccessionNo']").val() == "") {
        $("#bookaccession").hide(500);
        $("#makeissue").hide(500);
        $("#btn").hide(500);
        $("[id*='accessiontype']")[0].style.display = 'none';
        $("[id*='accessiontype']")[0].innerText = "";
        $("[id*='lblissuedbook']")[0].innerText = "";

    }


});

$("[id*='btn_guestsearch']").on("click", function () {
    var x = document.getElementsByClassName("loader");
    x[0].style.display = "block";
    $.ajax({
        type: "POST",
        url: "IssueReturn.aspx/guest_retrieve",
        data: '{search_string:"' + $("[id*='txtGuestID']").val() + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (data) {
            $("#guest").show(500);
            $("#reset").show(500);
            loadguest();
            ////$("[id*='txtguestnameee']").val(data.d[0].guest_name) ;
            ////$("[id*='txtguestmobno']").val(data.d[0].guest_pn_no)  ;
            ////$("[id*='txtGuestRemark']").val(data.d[0].remark) ;
            ////$("[id*='txtguestAddress']").val(data.d[0].guest_add);
            var x = document.getElementsByClassName("loader");
            x[0].style.display = "none";

        },
        error: function () {
            //alert('Connection error, please retry');
            hasError = true;
            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
        //}

    });



});


$("[id*='btn_homecard']").on("click", function () {

    var studentDetailbook = {};
    studentDetailbook.stud_id = $("[id*='txtStudId']").val();

    if (type == "student") {
        studentDetailbook.member_type = "S";
    }
    else if (type == "employee") {
        studentDetailbook.member_type = "E";
    }
    else {
        studentDetailbook.member_type = "G";
    }

    studentDetailbook.accession_no = $("[id*='txtAccessionNo']").val();
    studentDetailbook.accession_type = booktype;
    studentDetailbook.issue_date = $("[id*='issuedate']").Value;
    studentDetailbook.return_date = $("[id*='return_date']").val();
    studentDetailbook.return_date_given = $("[id*='returngivendate']").val();
    studentDetailbook.user_id = empId;
    studentDetailbook.H_R = "H";

    studentDetailbook.lab = "";


    if ($("[id*='txtguestnameee']").val() != "") {
        $.ajax({
            type: "POST",
            url: "IssueReturn.aspx/guest_insert",
            // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
            data: '{guest_name:"' + $("[id*='txtguestnameee']").val() + '",guest_add:"' + $("[id*='txtguestAddress']").val() + '",guest_pn_no:"' + $("[id*='txtguestmobno']").val() + '",remark:"' + $("[id*='txtGuestRemark']").val() + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + $("[id*='txtAccessionNo']").val() + '",accession_type:"' + booktype + '",issue_date:"' + $("[id*='issuedate']").val() + '",return_date_given:"null",return_date:"' + $("[id*='return_date']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1"}',  //insert_or_update,renew, is_lost, fne_applicable
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (response) {
                $.notify("Book Issued Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                loadpendingbook();
                loadpendingpayments();
                gridhideshow();
                accessionClear();
                GuestClear();
                $("#makeissue").hide(500);
                $("#btn").hide(500);
            },
            error: function () {
                //alert('Connection error, please retry');
                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });
    }
    else {
        $.ajax({
            type: "POST",
            url: "IssueReturn.aspx/chk_issue",
            // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
            data: '{studid:"' + $("[id*='txtStudId']").val() + '" ,type:"' + type + '"}',  //insert_or_update,renew, is_lost, fne_applicable
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                if (data.d[0].subcourse_name != "1") {
                    $.ajax({
                        type: "POST",
                        url: "IssueReturn.aspx/bookinsert",
                        // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
                        data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + $("[id*='txtAccessionNo']").val() + '",accession_type:"' + booktype + '",issue_date:"' + $("[id*='issuedate']").val() + '",return_date_given:"null",return_date:"' + $("[id*='return_date']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1",insert_or_update:"Insert",renew:"",is_lost:"",fne_applicable:"",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (response) {
                            $.notify("Book Issued Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                            loadpendingbook();
                            fillpastissue($("[id*='txtStudId']").val().trim());
                            loadpendingpayments();
                            gridhideshow();
                            accessionClear();
                            $("#makeissue").hide(500);
                            $("#btn").hide(500);
                        },
                        error: function () {
                            //alert('Connection error, please retry');
                            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    });
                }

                else {
                    $.notify("Book cannot be issued more than limits!!!.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
        });
    }



});

$("[id*='btn_readercard']").on("click", function () {

    var studentDetailbook = {};
    studentDetailbook.stud_id = $("[id*='txtStudId']").val();

    if (type == "student") {
        studentDetailbook.member_type = "S";
    }
    else if (type == "employee") {
        studentDetailbook.member_type = "E";
    }
    else {
        studentDetailbook.member_type = "G";
    }

    studentDetailbook.accession_no = $("[id*='txtAccessionNo']").val();
    studentDetailbook.accession_type = booktype;
    studentDetailbook.issue_date = $("[id*='issuedate']").val();
    studentDetailbook.return_date = $("[id*='return_date']").val();
    studentDetailbook.return_date_given = $("[id*='returngivendate']").val();
    studentDetailbook.user_id = empId;
    studentDetailbook.H_R = "R";

    studentDetailbook.lab = "";
    if ($("[id*='txtguestnameee']").val() != "") {
        $.ajax({
            type: "POST",
            url: "IssueReturn.aspx/guest_insert",
            // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
            data: '{guest_name:"' + $("[id*='txtguestnameee']").val() + '",guest_add:"' + $("[id*='txtguestAddress']").val() + '",guest_pn_no:"' + $("[id*='txtguestmobno']").val() + '",remark:"' + $("[id*='txtGuestRemark']").val() + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + $("[id*='txtAccessionNo']").val() + '",accession_type:"' + booktype + '",issue_date:"' + $("[id*='issuedate']").val() + '",return_date_given:"null",return_date:"' + $("[id*='return_date']").val() + '",user_id:"' + empId + '",H_R:"R",lab:"lab1"}',  //insert_or_update,renew, is_lost, fne_applicable
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (response) {
                $.notify("Book Issued Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                loadpendingbook();
                loadpendingpayments();
                gridhideshow();
                accessionClear();
                GuestClear();
                $("#makeissue").hide(500);
                $("#btn").hide(500);
            },
            error: function () {
                //alert('Connection error, please retry');
                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });
    }
    else {
        $.ajax({
            type: "POST",
            url: "IssueReturn.aspx/chk_issue",
            // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
            data: '{studid:"' + $("[id*='txtStudId']").val() + '" ,type:"' + type + '"}',  //insert_or_update,renew, is_lost, fne_applicable
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                if (data.d[0].subcourse_name != "1") {
                    if ($("[id*='return_date']").val() != $("[id*='issuedate']").val()) {
                        $.notify("Please check date for Readers Card", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                    else {
                        $.ajax({
                            type: "POST",
                            url: "IssueReturn.aspx/bookinsert",
                            // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
                            data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + $("[id*='txtAccessionNo']").val() + '",accession_type:"' + booktype + '",issue_date:"' + $("[id*='issuedate']").val() + '",return_date_given:"null",return_date:"' + $("[id*='return_date']").val() + '",user_id:"' + empId + '",H_R:"R",lab:"lab1",insert_or_update:"Insert",renew:"",is_lost:"",fne_applicable:"",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            success: function (response) {
                                $.notify("Book Issued Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                                loadpendingbook();
                                loadpendingpayments();
                                gridhideshow();
                                accessionClear();
                                $("#makeissue").hide(500);
                                $("#btn").hide(500);
                            },
                            error: function () {
                                //alert('Connection error, please retry');
                                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });
                    }

                }

                else {
                    $.notify("Book cannot be issued more than limits!!!.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
        });
    }


});

$("[id*='ddltransactions']").change(function () {
    //if ($("[id*='ddltransactions']").val() != "--Select--") {
    //    $("#transactions").show(500);
    //}
    if ($("[id*='ddltransactions']").val() == "Return This Book") {
        $("#transactions").show(500);

        $('#returndate').prop('disabled', true)
        $('#renewdate').prop('disabled', true)
        $('#returnbookdate').prop('disabled', false)
        $("[id*='btn_return']")[0].innerText = "Return";

    }
    else if ($("[id*='ddltransactions']").val() == "Change Return Date") {
        $("#transactions").show(500);
        $('#returndate').prop('disabled', false)
        $('#renewdate').prop('disabled', true)
        $('#returnbookdate').prop('disabled', true)
        $("[id*='btn_return']")[0].innerText = "Change";
    }
    else if ($("[id*='ddltransactions']").val() == "Renew This Book") {
        $("#transactions").show(500);
        $('#returndate').prop('disabled', true)
        $('#renewdate').prop('disabled', false)
        $('#returnbookdate').prop('disabled', false)
        $("[id*='btn_return']")[0].innerText = "Renew";
    }


    else {

        $("#transactions").hide(500);
    }

});


$("[id*='btn_can']").on("click", function () {

    /*$("[id*=transactionpayment]").modal('hide');*/
    $('#transactionpayment').modal('hide');
    /*$("#transactionpayment .close").click()*/

});

$("[id*='btn_cancel']").on("click", function () {

    transmodalclose();

});
$("[id*='btnclose']").on("click", function () {

    transmodalclose();
});


$("[id*='btn_reset']").on("click", function () {
    $("#reset").hide(500);
    $("#paneldetailsall").hide(500);
    $("#Guestpanel").hide(500);
    $("#paneldetails").hide(500);
    $("[id*='txtStudId']").val('');
    $("#assesion_panel_id").hide(500);
    $("[id*=rowgridd]")[0].style.display = "none";
    $("#gridpanel").hide(500);
    Clear();
    $("[id*='issue']").hide();
    $("[id*='pay']").hide();
    $("[id*='guest']").hide();
});


//start Datecalulation
function DateDifference(startdate, enddate) {
    var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
    var diffDays = Math.round(Math.abs((startdate - enddate) / (oneDay)));
    return diffDays;
    // alert(diffDays);
}



$("[id*='btn_return']").on("click", function () {
    if ($("[id*='txtStudId']").val() != "") {
        if (type == "student") {
            studentDetailbook.member_type = "S";
        }
        else if (type == "employee") {
            studentDetailbook.member_type = "E";
        }
        else {
            studentDetailbook.member_type = "G";
        }

        if ($("[id*='btn_return']")[0].innerText == "Renew Book") {
            $.ajax({
                type: "POST",
                url: "IssueReturn.aspx/get_renew_details",
                data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",accession_id:"' + accessiontype + '",date:"' + $("[id*='renewdate']").val() + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {


                    if (data.d > 3) {


                        $.ajax({
                            type: "POST",
                            url: "IssueReturn.aspx/bookinsert",
                            // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
                            data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",issue_date:"' + studentDetailbook.issue_date + '",return_date_given:"' + $("[id*='renewdate']").val() + '" , return_date:"' + $("[id*='returnbookdate']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1",insert_or_update:"Update",renew:"Yes",is_lost:"",fne_applicable:"",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            success: function (response) {

                                $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                                $("[id*=rowgridd]")[0].style.display = "none";
                                transmodalclose();
                                loadpendingpayments();
                                loadpendingbook();
                                gridhideshow();

                            },
                            error: function () {
                                //alert('Connection error, please retry');
                                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });

                    }


                    else {

                        $.ajax({
                            type: "POST",
                            url: "IssueReturn.aspx/bookinsert",
                            // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
                            data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",issue_date:"' + studentDetailbook.issue_date + '",return_date_given:"' + $("[id*='renewdate']").val() + '" , return_date:"' + $("[id*='returnbookdate']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1",insert_or_update:"Update",renew:"Yes",is_lost:"",fne_applicable:"",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            success: function (response) {

                                $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                                $("[id*=rowgridd]")[0].style.display = "none";
                                transmodalclose();
                                loadpendingbook();
                                loadpendingpayments();
                                gridhideshow();

                            },
                            error: function () {
                                //alert('Connection error, please retry');
                                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });
                    }


                    accessionClear();
                    gridpending.hide();
                    GuestClear();
                },
                error: function () {
                    //alert('Connection error, please retry');
                    hasError = true;
                    //$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
                //}

            });





        }
        else if ($("[id*='btn_return']")[0].innerText == "Change") {

            $.ajax({
                type: "POST",
                url: "IssueReturn.aspx/update_return_date_given",
                data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",return_date_given:"' + $("[id*='returndate']").val() + '" ,connect:"' + $("[id*='ddlselect']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                // async: false,
                success: function (response) {

                    $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                    $("[id*=rowgridd]")[0].style.display = "none";
                    transmodalclose();
                    loadpendingbook();
                    loadpendingpayments();
                    gridhideshow();

                },
                error: function () {
                    //alert('Connection error, please retry');
                    $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            });
        }
        else if ($("[id*='btn_return']")[0].innerText == "Return") {

            $.ajax({
                type: "POST",
                url: "IssueReturn.aspx/bookinsert",
                // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
                data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",issue_date:"' + studentDetailbook.issue_date + '",return_date_given:"' + $("[id*='renewdate']").val() + '" , return_date:"' + $("[id*='returnbookdate']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1",insert_or_update:"Update",renew:"",is_lost:"",fne_applicable:"",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (response) {

                    $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                    $("[id*=rowgridd]")[0].style.display = "none";
                    transmodalclose();
                    loadpendingbook();
                    loadpendingpayments();
                    gridhideshow();
                    GuestClear();
                    accessionClear();

                },
                error: function () {
                    //alert('Connection error, please retry');
                    $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            });
        }
    }

    else if (guest_id != "") {
        if (type == "student") {
            studentDetailbook.member_type = "S";
        }
        else {
            studentDetailbook.member_type = "E";
        }

        if ($("[id*='btn_return']")[0].innerText == "Renew Book") {
            $.ajax({
                type: "POST",
                url: "IssueReturn.aspx/get_renew_details",
                data: '{stud_id:"' + guest_id + '",accession_id:"' + accessiontype + '",date:"' + $("[id*='renewdate']").val() + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {


                    if (data.d > 3) {


                        $.ajax({
                            type: "POST",
                            url: "IssueReturn.aspx/bookinsert",
                            // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
                            data: '{stud_id:"' + guest_id + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",issue_date:"' + studentDetailbook.issue_date + '",return_date_given:"' + $("[id*='renewdate']").val() + '" , return_date:"' + $("[id*='returnbookdate']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1",insert_or_update:"Update",renew:"Yes",is_lost:"",fne_applicable:"",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            success: function (response) {

                                $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                                transmodalclose();
                                loadpendingpayments();
                                loadpendingbook();
                                gridhideshow();
                                fillpastissue($("[id*='txtStudId']").val().trim());
                            },
                            error: function () {
                                //alert('Connection error, please retry');
                                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });

                    }


                    else {

                        $.ajax({
                            type: "POST",
                            url: "IssueReturn.aspx/bookinsert",
                            // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
                            data: '{stud_id:"' + guest_id + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",issue_date:"' + studentDetailbook.issue_date + '",return_date_given:"' + $("[id*='renewdate']").val() + '" , return_date:"' + $("[id*='returnbookdate']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1",insert_or_update:"Update",renew:"Yes",is_lost:"",fne_applicable:"",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            success: function (response) {

                                $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                                transmodalclose();
                                loadpendingbook();
                                loadpendingpayments();
                                gridhideshow();
                            },
                            error: function () {
                                //alert('Connection error, please retry');
                                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });
                    }
                    accessionClear();
                    gridpending.hide();
                    GuestClear();
                },
                error: function () {
                    //alert('Connection error, please retry');
                    hasError = true;
                    //$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
                //}

            });





        }
        else if ($("[id*='btn_return']")[0].innerText == "Change") {

            $.ajax({
                type: "POST",
                url: "IssueReturn.aspx/update_return_date_given",
                data: '{stud_id:"' + guest_id + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",return_date_given:"' + $("[id*='returndate']").val() + '" ,connect:"' + $("[id*='ddlselect']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                // async: false,
                success: function (response) {

                    $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                    transmodalclose();
                    loadpendingbook();
                    loadpendingpayments();
                    gridhideshow();
                },
                error: function () {
                    //alert('Connection error, please retry');
                    $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            });
        }
        else if ($("[id*='btn_return']")[0].innerText == "Return") {

            $.ajax({
                type: "POST",
                url: "IssueReturn.aspx/bookinsert",
                // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
                data: '{stud_id:"' + guest_id + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",issue_date:"' + studentDetailbook.issue_date + '",return_date_given:"' + $("[id*='renewdate']").val() + '" , return_date:"' + $("[id*='returnbookdate']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1",insert_or_update:"Update",renew:"",is_lost:"",fne_applicable:"",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (response) {
                    $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                    transmodalclose();
                    loadpendingbook();
                    loadpendingpayments();
                    gridhideshow();
                },
                error: function () {
                    //alert('Connection error, please retry');
                    $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            });
        }
    }
});

$("[id*='btn_pay']").on("click", function () {

    if ($("[id*='txtamount']").val() == "" && $("[id*='txtremark']").val() == "") {
        $.notify("Please enter the amount you are paying", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
    else {

        $.ajax({
            type: "POST",
            url: "IssueReturn.aspx/update_payments",
            data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + studentDetailbook.accession_type + '",return_date:"' + return_date + '" ,fine_paid:"' + $("[id*='txtamount']").val() + '" ,fine_discount:"' + $("[id*='lbldisamount']")[0].innerText + '" ,remark:"' + $("[id*='txtremark']").val() + '" ,user_id:"' + empId + '" }',
            contentType: "application/json; charset=utf-8",
            // async: false,
            success: function (response) {

                $.notify("Payment Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                $('#transactionpayment').modal('hide');
                $("[id*='txtremark']").val() = "";
                $("[id*='txtamount']").val() = "";
                loadpendingpayments();

            },
            error: function () {
                //alert('Connection error, please retry');
                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });
    }





});


$("[id*='txtday']").change(function () {
    getdate();
    // holi('');
});

function loadpendingbook() {
    gridbooklength = "";
    $("[id*='gridpending']").jsGrid({

        width: "100%",

        editing: true,
        sorting: true,
        paging: false,
        autoload: true,

        pageSize: 15,
        pageButtonCount: 5,


        rowClick: function (args) {
            editing: true

            //  $("[id*=transaction]").modal();

            var date = new Date();

            date1 = new Date(date);

            date1.setDate(date1.getDate());

            //var date = new Date();

            //var date1 = new Date(date);

            //date1.setDate(date1.getDate());


            //DateCalculation




            //var dateString = args.item["issue_date"];
            //var dateParts = dateString.split(" ");
            //var date = dateParts[0].split("-");
            //var time = dateParts[1];
            //var meridian = dateParts[2];

            //var month = date[1];
            //var day = parseInt(date[0]);
            //var year = parseInt(date[2]);

            //var formattedDate = month + "/" + day + "/" + year + " " + time + " "; 

            var startDate = new Date(args.item["issue_date"]);


            var endDate = new Date();

            ///Date.parse(endDate);



            //calculate fine

            $.ajax({
                type: "POST",
                url: "IssueReturn.aspx/calculate_fine",
                data: '{subcourse_id:"' + $("[id*='lblSubcourseId']")[0].innerText + '",day_diff:"' + DateDifference(startDate, endDate) + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {

                    $("[id*='lblfin']")[0].innerText = data.d;

                },
                error: function () {
                    //alert('Connection error, please retry');
                    hasError = true;
                    $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }



            });

            //End


            var m_names = new Array("Jan", "Feb", "Mar",
                "Apr", "May", "Jun", "Jul", "Aug", "Sep",
                "Oct", "Nov", "Dec");



            var dd1 = date1.getDate();
            var mm1 = date1.getMonth();
            var y1 = date1.getFullYear();
            var hr1 = date1.getHours();
            var mi1 = date1.getMinutes();
            var mil1 = date1.getSeconds();

            var someFormattedDate1 = dd1 + '-' + m_names[mm1] + '-' + y1 + ' ' + hr1 + ':' + mi1 + ':' + mil1;
            //+ ' ' + hr1 + ':' + mi1 + ':' + mil1;

            document.getElementById('renewdate').value = someFormattedDate1;
            document.getElementById('returnbookdate').value = someFormattedDate1;

            var date2 = new Date(args.item.return_date_given);

            date2.setDate(date2.getDate());

            document.getElementById('returndate').value = date2.getDate() + '-' + m_names[date2.getMonth()] + '-' + date2.getFullYear() + ' ' + date2.getHours() + ':' + date2.getMinutes() + ':' + date2.getSeconds();

            $("[id*='txtbookname']")[0].innerText = args.item.accession_name;
            // $("[id*='returndate']").val(args.item.return_date_given).toLocaleString('en-GB');
            // $("[id*='returnbookdate']").val(date.toLocaleString('en-GB'));
            //  $("[id*='renewdate']").val(date.toLocaleString('en-GB'));

            accessiontype = args.item.accession_type;
            studentDetailbook.accession_no = args.item.accession_no;
            // studentDetailbook.issue_date = args.item.issue_date;
            ///holi('renew');
            startDate.setDate(startDate.getDate());
            studentDetailbook.issue_date = startDate.getDate() + '-' + m_names[startDate.getMonth()] + '-' + startDate.getFullYear() + ' ' + startDate.getHours() + ':' + startDate.getMinutes() + ':' + startDate.getSeconds();
            $("[id*=transaction]").show();

            //var modal = document.getElementById("transaction");
            //modal.style.display = "block";
            $('#returndate').prop('disabled', true)
            $('#renewdate').prop('disabled', true)
            $('#returnbookdate').prop('disabled', false)
            $("[id*='btn_return']")[0].innerText = "Return";

        },


        onItemDeleting: function (args) {

        },

        onItemUpdating: function (args) {

        },


        controller: {


            loadData: function () {
                var d = $.Deferred();
                if ($("[id*='txtStudId']").val() != "") {
                    $.ajax({
                        type: "POST",
                        url: "IssueReturn.aspx/studentbook",
                        data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",type:"issue",ayid:"' + $("[id*=ddlyear] :selected").val() + '",connect:"' + $("[id*='ddlselect']").val() + '",acc_id:""}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        dataType: "json"
                    }).done(function (response) {
                        gridbooklength = response.d.length;
                        d.resolve(response.d);
                    });
                }
                else {
                    var con = "";
                    if ($("[id*='txtAccessionNo']").val() == "") {
                        con = $("[id*='ddlselect']").val();
                    } else { con = $("[id*='txtAccessionNo']").val(); }
                    $.ajax({
                        type: "POST",
                        url: "IssueReturn.aspx/studentbook",
                        data: '{stud_id:"' + guest_id + '",type:"issue",ayid:"' + $("[id*=ddlyear] :selected").val() + '",connect:"' + con + '",acc_id:""}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        dataType: "json"
                    }).done(function (response) {
                        $("#gridpending").show();
                        gridbooklength = response.d.length;
                        d.resolve(response.d);
                    });
                }
                return d.promise();
            }
        },


        fields: [

            { name: "SrNo", width: 50, title: "Sr No ." },
            { name: "accession_no", width: 80, title: "Accession ID" },
            { name: "accession_name", width: 200, editable: true, title: "Title" },
            { name: "accession_type", width: 60, editable: true, title: "Issued Type" },

            { name: "issue_return", width: 80, editable: true, title: "Issued or Return", visible: false },
            { name: "issue_date", width: 100, editable: true, title: "Issue Date" },

            { name: "return_date_given", width: 100, editable: true, title: "Return Date Given" },

            { name: "H_R", width: 100, editable: true, title: "Issued On" }
            //,

            //           { name: "Add", width: 100, type: "select", valueField: "Id", textField: "name", title: "ADD"//, formatter: 'select', edittype: "select"
            //                       ,selectedIndex: 1,
            //    //items: stages
            //            items: [
            //{ name: "", Id: 0 },
            //{ name: "Return This Book", Id: 1 },
            //{ name: "Change Return Date", Id: 2 },
            //{ name: "Renew This Book", Id: 3 }

            //            ]  

            //        }

        ]





    });



}

function loadpendingpayments() {

    gridpaymentlength = "";


    $("[id*='gridpendingpayments']").jsGrid({

        width: "100%",

        editing: true,
        sorting: true,
        paging: false,
        autoload: true,

        pageSize: 15,
        pageButtonCount: 5,


        rowClick: function (args) {
            editing: false

            $('#transactionpayment').modal('show');

            $("[id*='lblfine']")[0].innerText = args.item.total_fine;
            $("[id*='lblfinepaid']")[0].innerText = args.item.fine_taken;
            $("[id*='lbldisamount']")[0].innerText = args.item.fine_discount;
            return_date = args.item.return_date;
            studentDetailbook.accession_no = args.item.accession_no
            studentDetailbook.accession_type = args.item.accession_type
        },


        onItemDeleting: function (args) {

        },

        onItemUpdating: function (args) {

        },


        controller: {


            loadData: function () {
                var d = $.Deferred();
                if ($("[id*='txtStudId']").val() != "") {

                    $.ajax({
                        type: "POST",
                        url: "IssueReturn.aspx/studentbook",
                        data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",type:"payments",ayid:"' + $("[id*=ddlyear] :selected").val() + '",connect:"' + $("[id*='ddlselect']").val() + '",acc_id:""}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        dataType: "json"
                    }).done(function (response) {
                        gridpaymentlength = response.d.length;
                        if (response.d.length != 0) {
                            studentDetailbook.total_fine = response.d[0].total_fine;
                        }
                        d.resolve(response.d);
                    });
                }
                else {

                    $.ajax({
                        type: "POST",
                        url: "IssueReturn.aspx/studentbook",
                        data: '{stud_id:"' + guest_id + '",type:"payments",ayid:"' + $("[id*=ddlyear] :selected").val() + '",connect:"' + $("[id*='ddlselect']").val() + '",acc_id:""}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        dataType: "json"
                    }).done(function (response) {
                        gridpaymentlength = response.d.length;
                        if (response.d.length != 0) {
                            studentDetailbook.total_fine = response.d[0].total_fine;
                        }
                        d.resolve(response.d);
                    });
                }
                return d.promise();
            }
        },


        fields: [

            { name: "SrNo", width: 50, title: "Sr No ." },
            { name: "accession_no", width: 80, title: "Accession ID" },

            { name: "accession_type", width: 80, editable: true, title: "Issued Type" },

            // { name: "issue_return", width: 80, editable: true, title: "Issued or Return" },
            { name: "return_date", width: 150, editable: true, title: "Return Date " },

            { name: "total_fine", width: 80, editable: true, title: "Total Fine" },

            { name: "fine_taken", width: 80, editable: true, title: "Fine Payment" },
            { name: "fine_discount", width: 80, editable: true, title: " Discount" }
            //,
            //{
            //    headerTemplate: function () {
            //        return $("<lable>").attr("type", "Text").text("VIEW")
            //                .on("click", function () {

            //                });
            //    },
            //    itemTemplate: function (_, item) {
            //        return $("<button class='alert-success'>").attr("type", "button").text("View")
            //              .on("click", function () {


            //              });
            //    },
            //    align: "center",
            //    width: 50
            //}

        ]





    });

}

function loadguest() {

    $("[id*='bookissueforguest']").jsGrid({

        width: "100%",

        editing: true,
        sorting: true,
        paging: false,
        autoload: true,

        pageSize: 15,
        pageButtonCount: 5,


        rowClick: function (args) {
            editing: true
            $("#guest").hide();
            guest_id = args.item.id;
            $("[id*='txtguestnameee']").val(args.item.guest_name);
            $("[id*='txtguestmobno']").val(args.item.guest_pn_no);
            $("[id*='txtGuestRemark']").val(args.item.remark);
            $("[id*='txtguestAddress']").val(args.item.guest_add);

            loadpendingbook();
            loadpendingpayments();

            gridhideshow();

        },


        onItemDeleting: function (args) {

        },

        onItemUpdating: function (args) {

        },


        controller: {

            loadData: function () {
                var d = $.Deferred();

                //$.ajax({
                //    type: "POST",
                //    url: "IssueReturn.aspx/guest_retrieve",
                //    data: '{search_string:"' + $("[id*='txtGuestID']").val() + '"}',
                //    contentType: "application/json; charset=utf-8",
                //    async: false,
                //    dataType: "json"
                //})
                var id = "";
                if ($("[id*='txtGuestID']").val() == "") {
                    id = $("[id*='txtAccessionNo']").val();
                    if (id.includes("imr") || id.includes("IMR")) {
                        $("[id*='ddlselect']").val('Viva IMR')
                    }
                    else if (id.includes("ims") || id.includes("IMS")) {
                        $("[id*='ddlselect']").val('Viva IMS')
                    }
                    else if (id.includes("b") || id.includes("B")) {
                        $("[id*='ddlselect']").val('Viva Engg')
                    }
                    else if (id.includes("mca") || id.includes("MCA")) {
                        $("[id*='ddlselect']").val('MCA')
                    }
                    else if (id.includes("pha") || id.includes("PHA")) {
                        $("[id*='ddlselect']").val('pharmacy')
                    }
                }
                else {
                    id = $("[id*='txtGuestID']").val();
                }
                $.ajax({
                    type: "POST",
                    url: "IssueReturn.aspx/guest_retrieve",
                    data: '{search_string:"' + id + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    dataType: "json"
                }).done(function (response) {
                    d.resolve(response.d);
                });

                return d.promise();
            }
        },

        fields: [

            { name: "id", width: 80, title: "ID" },
            { name: "guest_name", width: 150, title: "Guest Name" },
            { name: "guest_add", width: 150, title: "Guste Address" },
            { name: "guest_pn_no", width: 80, editable: true, title: "Guest Mobile No." },
            { name: "remark", width: 150, editable: true, title: "Remark" },




        ]


    });



}

function Clear() {
    $("[id*='txtAccessionNo']").val('');
    $("[id*='txtbooktitle']")[0].innerText = "";
    $("[id*='txtmobno']")[0].innerText = "";
    $("[id*='txtauthor']")[0].innerText = "";
    $("[id*='txtPublisher']")[0].innerText = "";
    $("[id*='txtclass']")[0].innerText = "";
    $("[id*='txtDiv']")[0].innerText = "";
    $("[id*='txtRollNo']")[0].innerText = "";
    $("[id*='txtaddress']")[0].innerText = "";
    $("[id*='txtempname']")[0].innerText = "";
    $("[id*='txtempdepart']")[0].innerText = "";
    $("[id*='txtempdesing']")[0].innerText = "";

    $("[id*='txtempaddress']")[0].innerText = "";
    $("[id*='txtempmobno']")[0].innerText = "";
    document.getElementById("imgstud").src = "";
    document.getElementById("imgemployee").src = "";

    $("[id*='issuedate']").val('');
    $("[id*='return_date']").val('');
    $("[id*='txtday']")[0].value = '0';


    $("[id*='btn_return']")[0].innerText = "OK";
    $("[id*='accessiontype']")[0].style.display = 'none';
    $("[id*='accessiontype']")[0].innerText = "";
    $("[id*='lblissuedbook']")[0].style.display = 'none';
    $("[id*='lblissuedbook']")[0].innerText = "";

    $("#gridpending").jsGrid("refresh");
    $("#gridpendingpayments").jsGrid("refresh");
    // $("#reset").hide(500);

}

function GuestClear() {
    $("[id*='txtguestnameee']").val('');
    $("[id*='txtguestmobno']").val('');
    $("[id*='txtGuestRemark']").val('');
    $("[id*='txtguestAddress']").val('');
    $("[id*='txtGuestID']").val('');

    // $("#bookissueforguest").jsGrid("refresh");
    // $("#bookissueforguest").hide(500);
    // $("[id*='lblguest']")[0].innerText = "";
}
function accessionClear() {
    $("[id*='txtAccessionNo']").val('');
    $("[id*='txtbooktitle']")[0].innerText = "";
    $("[id*='txtmobno']")[0].innerText = "";
    $("[id*='txtauthor']")[0].innerText = "";
    $("[id*='txtPublisher']")[0].innerText = "";
    $("[id*='accessiontype']")[0].style.display = 'none';
    $("[id*='accessiontype']")[0].innerText = "";
    $("[id*='lblissuedbook']")[0].style.display = 'none';
    $("[id*='lblissuedbook']")[0].innerText = "";
    $("[id*='bookaccession']").hide(500);

}
function getdate() {
    // var tt = document.getElementById('txtDate').value;
    var date = new Date();
    //date = date.toString("dd mm yyyy");
    // date = date.toLocaleString('en-GB');
    // $("[id*='issuedate']").val(date);

    //  date = Date($("[id*='issuedate']").val(date));

    var date1 = new Date(date);

    date1.setDate(date1.getDate());



    var m_names = new Array("Jan", "Feb", "Mar",
        "Apr", "May", "Jun", "Jul", "Aug", "Sep",
        "Oct", "Nov", "Dec");



    var dd1 = date1.getDate();
    var mm1 = date1.getMonth();
    var y1 = date1.getFullYear();
    var hr1 = date1.getHours();
    var mi1 = date1.getMinutes();
    var mil1 = date1.getSeconds();

    var someFormattedDate1 = dd1 + '-' + m_names[mm1] + '-' + y1 + ' ' + hr1 + ':' + mi1 + ':' + mil1;
    //+ ' ' + hr1 + ':' + mi1 + ':' + mil1;

    document.getElementById('issuedate').value = someFormattedDate1;

    var newdate = new Date(date);
    var days = $("[id*='txtday']").val();
    newdate.setDate(newdate.getDate() + parseInt(days));

    var dd = newdate.getDate();
    var mm = newdate.getMonth();
    var y = newdate.getFullYear();
    var hr = newdate.getHours();
    var mi = newdate.getMinutes();
    var mil = newdate.getSeconds();

    // var someFormattedDate = dd + '/' + mm + '/' + y + ' ' + hr + ':' + mi + ':' + mil;
    var someFormattedDate = dd + '-' + m_names[mm] + '-' + y + ' ' + hr + ':' + mi + ':' + mil;
    document.getElementById('return_date').value = someFormattedDate;
}

function transmodalclose() {
    $("[id*=transaction]").hide();

    $("[id*='btn_return']")[0].innerText = "OK";
    var trans = $("[id*='ddltransactions']");

    for (var i = 0, j = trans[0].children.length; i < j; ++i) {
        if (trans[0][i].innerText == '--Select--') {
            trans[0].selectedIndex = i;
            break;
        }
    }
    $("#transactions").hide(500);
    $("[id*='lblfin']")[0].innerText == "";
}



function gridhideshow() {
    if (gridpaymentlength == 0) {

        // $("[id*='lblpending']")[1].innerText = "";
        $("#pay").hide(500);
        $("[id*='lblfin']")[0].innerText = "0";
        $("[id*='finee']")[0].style.color = "#73879C";
        $("[id*='lblfin']")[0].style.color = "#73879C";

    }
    else {
        $("#pay").show(500);
        $("#lblpending").show(500);
        $("[id*='lblfin']")[0].innerText = studentDetailbook.total_fine;
        $("[id*='finee']")[0].style.color = "Red";
        $("[id*='lblfin']")[0].style.color = "Red";

        //if ($("[id*='lblpending']")[1].innerText == "") {
        //    $("[id*='lblpending']")[1].innerText = "Pending Payments";


        //}

    }
    if (gridbooklength == 0) {

        // $("[id*='lblpendingbook']")[0].innerText = "";
        $("#issue").hide(500);
    }
    else {
        $("#issue").show(500);
        $("#lblpendingbook").show(500);
        //if ($("[id*='lblpendingbook']")[0].innerText == "") {
        //    $("[id*='lblpendingbook']")[0].innerText = "Issued Items ";
        $("[id*='lblfin']")[0].innerText == "0";
        //}
    }
}

$("#txtStudId").on('keydown', function (e) {
    if (e.which == 13) {
        $("#btn_search").trigger('click');
        return false;
    }
});


$("#txtAccessionNo").on('keydown', function (e) {
    if (e.which == 13) {
        $("#btn_accessionsearch").trigger('click');
        return false;
    }
});


$("[id*=renewdate]").blur(function () {
    //  holi('renew');
});
function holi(str1) {
    if (str1 != "renew") {
        $.ajax({
            type: "POST",
            url: "issuereturn.aspx/grid_data_issue",
            data: '{ayid:"' + $("[id*=ddlyear]").val() + '",date_ret:"' + $("[id*=return_date]").val() + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.d.length > 0) {
                    if (data.d[0].count != "0") {
                        var i = $("[id*='txtday']").val();
                        i = parseInt(i) + parseInt(data.d[0].count);
                        $("[id*='txtday']").val(i);
                        getdate();
                    }

                }

                else {
                    //  $.notify("Error ! Error Occured , please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
        });
    }
    else {
        $.ajax({
            type: "POST",
            url: "issuereturn.aspx/grid_data_issue",
            data: '{ayid:"' + $("[id*=ddlyear]").val() + '",date_ret:"' + $("[id*=renewdate]").val() + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.d.length > 0) {
                    if (data.d[0].count != "0") {
                        $.notify("New return date for renewing book is an holiday.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                }

            }
        });
    }
}