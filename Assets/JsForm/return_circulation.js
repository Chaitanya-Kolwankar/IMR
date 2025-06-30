
var type = "";
var date1 = "";
var date2 = "";
var booktype = "";
var accessiontype = "";
var return_date = "";
var fine_val = "";
var gridbooklength = 0;
var gridpaymentlength = 0;
$(document).ready(function () {
    var x = document.getElementsByClassName("loader");
    x[0].style.display = "none";



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

});


$("#txt_accession_ret").on('keydown', function (e) {
    if (e.which == 13) {
        $("#btn_accession_ret").trigger('click');
        return false;
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
        $("[id*='btn_return']")[0].innerText = "Renew Book";
    }


    else {

        $("#transactions").hide(500);
    }

});

$("[id*='btn_accession_ret']").on("click", function () {
    $.ajax({
        type: "POST",
        url: "return_circulation.aspx/search_accession",
        data: '{accession_id:"' + $("[id*='txt_accession_ret']").val().trim() + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d.length > 0) {
                $("[id*='txtStudId']").val(data.d[0].stud_id);
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
                        url: "return_circulation.aspx/studentbook",
                        data: '{stud_id:"' + $("[id*='txtStudId']").val().trim() + '",type:"' + type + '",ayid:"' + $("[id*='ddlyear']").val() + '",connect:"' + $("[id*='ddlselect']").val() + '",acc_id:"' + $("[id*='txt_accession_ret']").val().trim()+'"}',
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
                                    $("#makeissue").hide(500);
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

                                    gridhideshow();

                                    //    $("[id*='txtday']")[0].value = '7';

                                }
                                else if (type == "employee") {
                                    $("#guest").hide(500);
                                    $("#paneldetailsall").show(500);
                                    $("#paneldetails").hide(500);
                                    $("#Guestpanel").hide(500);
                                    $("#Employee").show(500);
                                    $("#assesion_panel_id").show(500);
                                    $("#gridpanel").show(500);

                                    $("#bookaccession").hide(500);
                                    $("#makeissue").hide(500);
                                    $("#btn").hide(500);


                                    Clear();
                                    if (data.d[0].emp_photo != "") {
                                        document.getElementById("imgemployee").src = "data:image/png;base64," + data.d[0].emp_photo;
                                    }
                                    else {
                                        //document.getElementById("imgemployee").src ="http://localhost:7325/staff/images/user.png";
                                    }
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
                                    gridhideshow();
                                    // $("[id*='txtday']")[0].value = '30';


                                }


                                var x = document.getElementsByClassName("loader");
                                x[0].style.display = "none";
                                //   document.getElementById("txtAccessionNo").focus();
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
            }
            else {
                $.notify("Book not Issued !!!", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        }
        });
});

function loadpendingbook() {
    $.ajax({
        type: "POST",
        url: "return_circulation.aspx/studentbook",
        data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",type:"issue",ayid:"' + $("[id*='ddlyear']").val() + '",connect:"' + $("[id*='ddlselect']").val() + '",acc_id:"' + $("[id*='txt_accession_ret']").val().trim() +'"}',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (data) {
            // gridbooklength = response.d.length;
            // d.resolve(response.d);
            var date = new Date();

            date1 = new Date(date);

            date1.setDate(date1.getDate());

            //var date = new Date();

            //var date1 = new Date(date);

            //date1.setDate(date1.getDate());


            //DateCalculation

            var startDate = new Date(data.d[0].issue_date);
            var endDate = new Date();



            //calculate fine

            $.ajax({
                type: "POST",
                url: "return_circulation.aspx/calculate_fine",
                data: '{subcourse_id:"' + $("[id*='lblSubcourseId']")[0].innerText + '",day_diff:"' + DateDifference(startDate, endDate) + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    if (data.d != "0" && data.d != null) {
                        fine_val = data.d;
                    }
                    else {
                        fine_val = "";
                    }
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

            var date2 = new Date(data.d[0].return_date_given);

            date2.setDate(date2.getDate());

            document.getElementById('returndate').value = date2.getDate() + '-' + m_names[date2.getMonth()] + '-' + date2.getFullYear() + ' ' + date2.getHours() + ':' + date2.getMinutes() + ':' + date2.getSeconds();

            $("[id*='txtbookname']")[0].innerText = data.d[0].accession_name;
            // $("[id*='returndate']").val(args.item.return_date_given).toLocaleString('en-GB');
            // $("[id*='returnbookdate']").val(date.toLocaleString('en-GB'));
            //  $("[id*='renewdate']").val(date.toLocaleString('en-GB'));

            accessiontype = data.d[0].accession_type;
            studentDetailbook.accession_no = data.d[0].accession_no;
           //studentDetailbook.issue_date = data.d[0].issue_date;
            startDate.setDate(startDate.getDate());
            studentDetailbook.issue_date = startDate.getDate() + '-' + m_names[startDate.getMonth()] + '-' + startDate.getFullYear() + ' ' + startDate.getHours() + ':' + startDate.getMinutes() + ':' + startDate.getSeconds();


            $('#transaction').modal('show');
            $("#transactions").show(500);

            $('#returndate').prop('disabled', true)
            $('#renewdate').prop('disabled', true)
            $('#returnbookdate').prop('disabled', false)
            $("[id*='btn_return']")[0].innerText = "Return";

        }
    });
   

//    gridbooklength = "";
//    $("[id*='gridpending']").jsGrid({

//        width: "100%",

//        editing: true,
//        sorting: true,
//        paging: false,
//        autoload: true,

//        pageSize: 15,
//        pageButtonCount: 5,


//        rowClick: function (args) {
//            editing: true

//            //  $("[id*=transaction]").modal();
//            var date = new Date();

//            date1 = new Date(date);

//            date1.setDate(date1.getDate());

//            //var date = new Date();

//            //var date1 = new Date(date);

//            //date1.setDate(date1.getDate());


//            //DateCalculation

//            var startDate = new Date(args.item["issue_date"]);
//            var endDate = new Date();



//            //calculate fine

//            $.ajax({
//                type: "POST",
//                url: "return_circulation.aspx/calculate_fine",
//                data: '{subcourse_id:"' + $("[id*='lblSubcourseId']")[0].innerText + '",day_diff:"' + DateDifference(startDate, endDate) + '"}',
//                contentType: "application/json; charset=utf-8",
//                async: false,
//                success: function (data) {
//                    if (data.d != "0" && data.d != null) {
//                        fine_val = data.d;
//                    }
//                    else {
//                        fine_val = "";
//                    }
//                    $("[id*='lblfin']")[0].innerText = data.d;

//                },
//                error: function () {
//                    //alert('Connection error, please retry');
//                    hasError = true;
//                    $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
//                }



//            });

//            //End


//            var m_names = new Array("Jan", "Feb", "Mar",
//        "Apr", "May", "Jun", "Jul", "Aug", "Sep",
//        "Oct", "Nov", "Dec");



//            var dd1 = date1.getDate();
//            var mm1 = date1.getMonth();
//            var y1 = date1.getFullYear();
//            var hr1 = date1.getHours();
//            var mi1 = date1.getMinutes();
//            var mil1 = date1.getSeconds();

//            var someFormattedDate1 = dd1 + '-' + m_names[mm1] + '-' + y1 + ' ' + hr1 + ':' + mi1 + ':' + mil1;
//            //+ ' ' + hr1 + ':' + mi1 + ':' + mil1;

//            document.getElementById('renewdate').value = someFormattedDate1;
//            document.getElementById('returnbookdate').value = someFormattedDate1;

//            var date2 = new Date(args.item.return_date_given);

//            date2.setDate(date2.getDate());

//            document.getElementById('returndate').value = date2.getDate() + '-' + m_names[date2.getMonth()] + '-' + date2.getFullYear() + ' ' + date2.getHours() + ':' + date2.getMinutes() + ':' + date2.getSeconds();

//            $("[id*='txtbookname']")[0].innerText = args.item.accession_name;
//            // $("[id*='returndate']").val(args.item.return_date_given).toLocaleString('en-GB');
//            // $("[id*='returnbookdate']").val(date.toLocaleString('en-GB'));
//            //  $("[id*='renewdate']").val(date.toLocaleString('en-GB'));

//            accessiontype = args.item.accession_type;
//            studentDetailbook.accession_no = args.item.accession_no;
//            studentDetailbook.issue_date = args.item.issue_date;

//            $('#transaction').modal('show');
//            $("#transactions").show(500);

//            $('#returndate').prop('disabled', true)
//            $('#renewdate').prop('disabled', true)
//            $('#returnbookdate').prop('disabled', false)
//            $("[id*='btn_return']")[0].innerText = "Return";
           
//        },


//        onItemDeleting: function (args) {

//        },

//        onItemUpdating: function (args) {

//        },


//        controller: {


//            loadData: function () {
//                var d = $.Deferred();


//                $.ajax({
//                    type: "POST",
//                    url: "return_circulation.aspx/studentbook",
//                    data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",type:"issue",ayid:"' + $("[id*='ddlyear']").val() + '"}',
//                    contentType: "application/json; charset=utf-8",
//                    async: false,
//                    dataType: "json"
//                }).done(function (response) {
//                    gridbooklength = response.d.length;
//                    d.resolve(response.d);
//                });

//                return d.promise();
//            }
//        },


//        fields: [

//                { name: "SrNo", width: 50, title: "Sr No ." },
//                 { name: "accession_no", width: 80, title: "Accession ID" },
//                 { name: "accession_name", width: 200, editable: true, title: "Title" },
//                 { name: "accession_type", width: 60, editable: true, title: "Issued Type" },

//                  { name: "issue_return", width: 80, editable: true, title: "Issued or Return", visible: false },
//                 { name: "issue_date", width: 100, editable: true, title: "Issue Date" },

//                { name: "return_date_given", width: 100, editable: true, title: "Return Date Given" },

//                  { name: "H_R", width: 100, editable: true, title: "Issued On" }
//                //,

////           { name: "Add", width: 100, type: "select", valueField: "Id", textField: "name", title: "ADD"//, formatter: 'select', edittype: "select"
////                       ,selectedIndex: 1,
////    //items: stages
////            items: [
////{ name: "", Id: 0 },
////{ name: "Return This Book", Id: 1 },
////{ name: "Change Return Date", Id: 2 },
////{ name: "Renew This Book", Id: 3 }

////            ]  

////        }

//        ]





//    });



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


                $.ajax({
                    type: "POST",
                    url: "return_circulation.aspx/studentbook",
                    data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",type:"payments",ayid:"' + $("[id*='ddlyear']").val() + '",connect:"' + $("[id*='ddlselect']").val() + '",acc_id:"' + $("[id*='txt_accession_ret']").val().trim() +'"}',
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    dataType: "json"
                }).done(function (response) {
                    gridpaymentlength = response.d.length;
                    if (response.d.length != 0) {
                        studentDetailbook.total_fine = response.d[0].total_fine;
                        $("#pay").show(500);
                        $("#lblpending").show(500);
                    }
                    else {
                        $("#pay").hide(500);
                        $("#lblpending").hide(500);
                    }
                    d.resolve(response.d);
                });

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


function Clear() {
    $("[id*='txtAccessionNo']").val('');
  //  $("[id*='txtbooktitle']")[0].innerText = "";
    $("[id*='txtmobno']")[0].innerText = "";
    //$("[id*='txtauthor']")[0].innerText = "";
    //$("[id*='txtPublisher']")[0].innerText = "";
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

   // $("[id*=paneldetails]").modal('hide');
    //$("[id*='issuedate']").val('');
    //$("[id*='return_date']").val('');
    //$("[id*='txtday']")[0].value = '0'; paneldetails


    //$("[id*='btn_return']")[0].innerText = "OK";
    //$("[id*='accessiontype']")[0].style.display = 'none';
    //$("[id*='accessiontype']")[0].innerText = "";
    //$("[id*='lblissuedbook']")[0].style.display = 'none';
    //$("[id*='lblissuedbook']")[0].innerText = "";
    //$("#gridpending").jsGrid("refresh"); txt_accession_ret
    $("#gridpendingpayments").jsGrid("refresh"); 
    // $("#reset").hide(500);

}

$("[id*='btn_reset']").on("click", function () {

    $("[id*='txtAccessionNo']").val('');
    $("[id*='txtmobno']")[0].innerText = "";
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
    $("#paneldetails").hide();
    $("#gridpendingpayments").jsGrid("refresh");
    $("#txt_accession_ret").val('');

    transmodalclose();

});

function DateDifference(startdate, enddate) {
    var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
    var diffDays = Math.round(Math.abs((startdate - enddate) / (oneDay)));
    return diffDays;
    // alert(diffDays);
}

$("[id*='btn_return']").on("click", function () {
    var if_fi_app = "";
    if (fine_val != "") {
        if_fi_app = "Yes";
    }
    else {
        if_fi_app = "";
        fine_val = "";
    }
    if (type == "student") {
        studentDetailbook.member_type = "S";
    }
    else if (type == "employee") {

        studentDetailbook.member_type = "E";
        if_fi_app = "";
        fine_val = "";
    }
    if ($("[id*='btn_return']")[0].innerText == "Renew Book") {
        $.ajax({
            type: "POST",
            url: "return_circulation.aspx/get_renew_details",
            data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",accession_id:"' + accessiontype + '",date:"' + $("[id*='renewdate']").val() + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {


                if (data.d > 3) {


                    $.ajax({
                        type: "POST",
                        url: "return_circulation.aspx/bookinsert",
                        // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
                        data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",issue_date:"' + studentDetailbook.issue_date + '",return_date_given:"' + $("[id*='renewdate']").val() + '" , return_date:"' + $("[id*='returnbookdate']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1",insert_or_update:"Update",renew:"Yes",is_lost:"",fne_applicable:"' + if_fi_app + '",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (response) {

                            $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                           transmodalclose();
                            loadpendingpayments();
                            //loadpendingbook();
                           // gridhideshow();
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
                        url: "return_circulation.aspx/bookinsert",
                        // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
                        data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",issue_date:"' + studentDetailbook.issue_date + '",return_date_given:"' + $("[id*='renewdate']").val() + '" , return_date:"' + $("[id*='returnbookdate']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1",insert_or_update:"Update",renew:"Yes",is_lost:"",fne_applicable:"' + if_fi_app + '",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (response) {

                            $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                           transmodalclose();
                            //loadpendingbook();
                            loadpendingpayments();
                           // gridhideshow();
                        },
                        error: function () {
                            //alert('Connection error, please retry');
                            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    });
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
    else if ($("[id*='btn_return']")[0].innerText == "Change") {

        $.ajax({
            type: "POST",
            url: "return_circulation.aspx/update_return_date_given",
            data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",return_date_given:"' + $("[id*='returndate']").val() + '",connect:"' + $("[id*='ddlselect']").val() + '" }',
            contentType: "application/json; charset=utf-8",
            // async: false,
            success: function (response) {

                $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                transmodalclose();
             //   loadpendingbook();
                loadpendingpayments();
               // gridhideshow();
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
            url: "return_circulation.aspx/bookinsert",
            // data: '{studentDetailbook: ' + JSON.stringify(studentDetailbook) + '}',
            data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",member_type:"' + studentDetailbook.member_type + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + accessiontype + '",issue_date:"' + studentDetailbook.issue_date + '",return_date_given:"' + $("[id*='renewdate']").val() + '" , return_date:"' + $("[id*='returnbookdate']").val() + '",user_id:"' + empId + '",H_R:"H",lab:"lab1",insert_or_update:"Update",renew:"",is_lost:"",fne_applicable:"' + if_fi_app + '",connect:"' + $("[id*='ddlselect']").val() + '"}',  //insert_or_update,renew, is_lost, fne_applicable
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (response) {
                $.notify("Data Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                  transmodalclose();
              //  loadpendingbook();
                loadpendingpayments();
              //  gridhideshow();
               // clear();
            },
            error: function () {
                //alert('Connection error, please retry');
                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });
    }

});
function gridhideshow() {
    //if (gridpaymentlength == 0) {

    //    // $("[id*='lblpending']")[1].innerText = "";
    //    $("#pay").hide(500);
    //    $("[id*='lblfin']")[0].innerText = "0";
    //    $("[id*='finee']")[0].style.color = "#73879C";
    //    $("[id*='lblfin']")[0].style.color = "#73879C";

    //}
    //else {
    //    $("#pay").show(500);
    //    $("#lblpending").show(500);
    //    $("[id*='lblfin']")[0].innerText = studentDetailbook.total_fine;
    //    $("[id*='finee']")[0].style.color = "Red";
    //    $("[id*='lblfin']")[0].style.color = "Red";

    //    //if ($("[id*='lblpending']")[1].innerText == "") {
    //    //    $("[id*='lblpending']")[1].innerText = "Pending Payments";


    //    //}

    //}
    //if (gridbooklength == 0) {

    //    // $("[id*='lblpendingbook']")[0].innerText = "";
    //    $("#issue").hide(500);
    //}
    //else {
    //    $("#issue").show(500);
    //    $("#lblpendingbook").show(500);
    //    //if ($("[id*='lblpendingbook']")[0].innerText == "") {
    //    //    $("[id*='lblpendingbook']")[0].innerText = "Issued Items ";
    //    $("[id*='lblfin']")[0].innerText == "0";
    //    //}
    //}
}

$("[id*='btn_pay']").on("click", function () {

    if ($("[id*='txtamount']").val() == "" && $("[id*='txtremark']").val() == "") {
        $.notify("Please enter the amount you are paying", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
    else {

        $.ajax({
            type: "POST",
            url: "return_circulation.aspx/update_payments",
            data: '{stud_id:"' + $("[id*='txtStudId']").val() + '",accession_no:"' + studentDetailbook.accession_no + '",accession_type:"' + studentDetailbook.accession_type + '",return_date:"' + return_date + '" ,fine_paid:"' + $("[id*='txtamount']").val() + '" ,fine_discount:"' + $("[id*='lbldisamount']")[0].innerText + '" ,remark:"' + $("[id*='txtremark']").val() + '" ,user_id:"' + empId + '",connect:"' + $("[id*='ddlselect']").val() + '" }',
            contentType: "application/json; charset=utf-8",
            // async: false,
            success: function (response) {

                $.notify("Payment Updated Successfully !!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                $('#transactionpayment').modal('hide');
                $("[id*='txtremark']").val('');
                $("[id*='txtamount']").val('');
                loadpendingpayments();
              
            },
            error: function () {
                //alert('Connection error, please retry');
                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });
    }





});

$("[id*='btn_can']").on("click", function () {

    $("[id*=transactionpayment]").modal('hide');

});
$("[id*='btn_cancel']").on("click", function () {

    transmodalclose();

});

function transmodalclose() {
    $("[id*=transaction]").modal('hide');

    //$("[id*='btn_return']")[0].innerText = "OK";
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