$(document).ready(function () {

    jQuery('[id*=datetimepicker1]').datetimepicker(
        {
            changeMonth: false,
            changeYear: false,
            timepicker: false,
            format: 'd-M-Y h:m:s',
            viewMode: "months",
            minViewMode: "months"
        });

    jQuery('[id*=datetimepicker2]').datetimepicker(
        {
            changeMonth: false,
            changeYear: false,
            timepicker: false,
            format: 'd-M-Y h:m:s',
            viewMode: "months",
            minViewMode: "months"

        });

});

$("[id*='btnclear']").on("click", function () {
    $("[id*='datetimepicker1']").val('');
    $("[id*='datetimepicker2']").val('');
    $("[id*='ddlMembertype']").val('--Select--');
    $("[id*='ddlIssuereturn']").val('--Select--');
    var Table = document.getElementById("tbl");
    $("[id*=btnExcel]")[0].style.display = "none";
    $("[id*=rowgridd]")[0].style.display = "none";
    Table.innerHTML = "";
});
var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,'
        , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="content-type" content="text/plain; charset=UTF-8"/></head><body><table>{table}</table></body></html>'
        , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
        , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
    return function (table, name) {
        if (!table.nodeType) table = document.getElementById(table)
        var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML }
        var blob = new Blob([format(template, ctx)]);
        var blobURL = window.URL.createObjectURL(blob);
        return blobURL;
    }
})()

$("[id*='btnsearch']").on("click", function () {

    fillgrid();
});

$("[id*='btnExcel']").on("click", function () {

    var blobURL = tableToExcel('tblfill', 'Issuereturnreport');
    $(this).attr('download', 'Issuereturnreport.xls');
    $(this).attr('href', blobURL);
});
function fillgrid() {

    var issue = "";

    if ($("[id*='ddlMembertype']").val() == '--Select--') {

        $.notify("Select the Member Type!!!", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
    else if ($("[id*='datetimepicker1']").val() == "") {

        $.notify("Select Date From!!!", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
    else if ($("[id*='datetimepicker2']").val() == "") {

        $.notify("Select Date To!!!", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
    else {
        if ($("[id*='ddlIssuereturn']").val() == "--Select--") {
            issue = "";
        }
        else {
            issue = $("[id*='ddlIssuereturn']").val();
        }

        $.ajax({
            type: "POST",
            url: "IssueReturnReport.aspx/GetIssuereturnReport",
            data: '{datetimepicker1:"' + $("[id*='datetimepicker1']").val() + '",datetimepicker2:"' + $("[id*='datetimepicker2']").val() + '",memberType:"' + $("[id*='ddlMembertype']").val() + '",isssueReturn:"' + issue + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d.length > 0) {

                    $("[id*=rowgridd]").show();

                    var Table = document.getElementById("tblfill");

                    $("[id*=btnExcel]").show();

                    Table.innerHTML = "";
                    if (response.d[0] != undefined && response.d[0] != "" && response.d[0] != null) {
                        $("[id*=rowgridd]").slideDown('slow');

                        //For Student
                        if ($("[id*='ddlMembertype']").val() == 'S') {

                            $("[id*=tblfill]").append("<thead style='position:sticky;top:0;'><tr class='alert alert-danger'><th colspan=7><center>Report</th></tr><tr class='alert-success'><th>Sr.No</th><th >Student Id</th><th >Student Name</th><th>Accession Number</th><th >Book Title</th></tr></thead>");

                            for (var i = 0; i < response.d.length; i++) {
                                if (i == 0) {
                                    $("[id*=tblfill]").append("<tbody>");
                                }
                                var data = parseInt(i) + 1;
                                $("[id*=tblfill]").append("<tr><td>" + data + "</td><td>" + response.d[i].StudentId + "</td><td>" + response.d[i].StudentName + "</td><td>" + response.d[i].Accssionno + "</td><td>" + response.d[i].Booktitle + "</td></tr>");

                                if (i == response.d.length - 1) {
                                    $("[id*=tblfill]").append("</tbody>");
                                }
                            }

                        }
                        //For Employee
                        else {
                            $("[id*=tblfill]").append("<thead><tr class='alert alert-danger'><th colspan=7><center>Daily Issue Report</th></tr><tr class='alert-success'><th>Sr.No</th><th >Employee Id</th><th >Employee Name</th><th>Accession Number</th><th>Title</th></tr></thead>");

                            for (var i = 0; i < response.d.length; i++) {
                                if (i == 0) {
                                    $("[id*=tblfill]").append("<tbody>");
                                }
                                var data = parseInt(i) + 1;
                                $("[id*=tblfill]").append("<tr><td>" + data + "</td><td>" + response.d[i].empId + "</td><td>" + response.d[i].empName + "</td><td>" + response.d[i].empAccessionno + "</td><td>" + response.d[i].empBooktitle + "</td></tr>");

                                if (i == response.d.length - 1) {
                                    $("[id*=tblfill]").append("</tbody>");
                                }
                            }
                        }
                    }
                }
                else {
                    $.notify("No Data Found.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $("[id*=rowgridd]")[0].style.display = "none";
                    var Table = document.getElementById("tblfill");
                    Table.innerHTML = "";
                }
            },
            error: function () {
                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });

    }


}
