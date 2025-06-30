$(document).ready(function () {
    load();
});

var loader = "<div class='overlay'><img src='../../../assets/img/dropinring.gif' class='loaderimg'></div>";

function load() {

    var year = new Date().getFullYear();
    var month = new Date().getMonth();
    $('[id*=ddlappyear]').empty().append('<option selected="selected">--Select--</option>');
    for (var i = 2021; i <= year + 1; i++) {
        $('[id*=ddlappyear]').append($("<option></option>").val(i).html(i))
    }
    $('[id*=ddlappyear]').val(year);
    $('[id*=ddlappmonth]').val(month + 1);

    $.ajax({
        type: "POST",
        url: "salary_monthly_entry.aspx/getdept",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            if (r.d.emp_salary[0].process != "NO") {
                $('[id*=ddldept]').empty().append('<option selected="selected">--Select--</option>');
                for (var i = 0; i <= r.d.emp_salary.length - 1 ; i++) {
                    $('[id*=ddldept]').append($("<option></option>").val(r.d.emp_salary[i].emp_id).html(r.d.emp_salary[i].emp_name))
                }
            }
        },
        error: function (xhr, status, error) {
            $.notify(error, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });
}

$("[id*=btnclear]").click(function () {
    localStorage.clear();
    location.reload();
});

function validateload() {
    var msg = "";
    if ($('[id*=ddldept]').val().includes("--Select--") == true) {
        $.notify('Select Department', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        $("[id*=ddldept]").css("border-color", "red");
        msg = "error";
        return
    }
    else if ($('[id*=ddlcategory]').val().includes("--Select--") == true) {
        $.notify('Select Category', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        $("[id*=ddlcategory]").css("border-color", "red");
        msg = "error";
        return
    }
    else if ($('[id*=ddlappmonth]').val().includes("--Select--") == true) {
        $.notify('Select Month', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        $("[id*=ddlappmonth]").css("border-color", "red");
        msg = "error";
        return
    }
    else if ($('[id*=ddlappyear]').val().includes("--Select--") == true) {
        $.notify('Select Year', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        $("[id*=ddlappyear]").css("border-color", "red");
        msg = "error";
        return
    }
    return msg;
}

$('.drop').change(function () {
    $(this).css("border-color", "");
    $('[id*=tblstruct]').empty();
    $('[id*=btngetdata]').val('New')
});

$('[id*=tblstruct]').on("click", "input[type='checkbox']", function () {
    if ($(this).attr("id") == "chksal") {
        if ($(this)[0].checked == true) {
            $(".selectall").prop("checked", true)
        }
        else {
            $(".selectall").prop("checked", false)
        }
    }
});

function calculate(input) {
    var obj = [];
    obj = input.id.split('_');
    var i = obj[obj.length - 1];
    var max = $(input).attr("value");
    var curr = $(input).val();

    if ($("[id*='txtbasic_" + i + "']").val() != '' && $("[id*='txtagp_" + i + "']").val() != '') {
        var totalbasic = parseFloat($("[id*='txtbasic_" + i + "']").val()) + parseFloat($("[id*='txtagp_" + i + "']").val());
        $("[id*='lblbasictotal_" + i + "']").text(totalbasic);
        if ($("[id*='txtda_" + i + "']").val() != '' && $("[id*='txthra_" + i + "']").val() != '' && $("[id*='txt_ta_" + i + "']").val() != '' && $("[id*='txtOSA_" + i + "']").val() != '') {
            var totalgross = parseFloat(totalbasic) + parseFloat($("[id*='txtda_" + i + "']").val()) + parseFloat($("[id*='txthra_" + i + "']").val()) + parseFloat($("[id*='txt_ta_" + i + "']").val()) + parseFloat($("[id*='txtOSA_" + i + "']").val());
            $("[id*='lblgross_" + i + "']").text(totalgross);
            if ($("[id*='txtarrears_" + i + "']").val() != '') {
                var totalsalary = parseFloat(totalgross) + parseFloat($("[id*='txtarrears_" + i + "']").val());
                $("[id*='lblsalarytotal_" + i + "']").text(totalsalary);
            }
            else {
                $("[id*='lblsalarytotal_" + i + "']").text('');
            }
        }
        else {
            $("[id*='lblgross_" + i + "']").text('');
            $("[id*='lblsalarytotal_" + i + "']").text('');
        }
    }
    else {
        $("[id*='lblbasictotal_" + i + "']").text('');
        $("[id*='lblgross_" + i + "']").text('');
        $("[id*='lblsalarytotal_" + i + "']").text('');
    }
    if ($("[id*='txtpfemp_" + i + "']").val() != '' && $("[id*='txtpt_" + i + "']").val() != '' && $("[id*='txttds_" + i + "']").val() != '' && $("[id*='txtOD_" + i + "']").val() != '') {
        var totalded = parseFloat($("[id*='txtpfemp_" + i + "']").val()) + parseFloat($("[id*='txtpt_" + i + "']").val()) + parseFloat($("[id*='txttds_" + i + "']").val()) + parseFloat($("[id*='txtOD_" + i + "']").val());
        $("[id*='lbldedtotal_" + i + "']").text(totalded);
    }
    else {
        $("[id*='lbldedtotal_" + i + "']").text('');
    }
    if ($("[id*='lblsalarytotal_" + i + "']").text() != '' && $("[id*='lbldedtotal_" + i + "']").text() != '') {
        var netsalary = parseFloat($("[id*='lblsalarytotal_" + i + "']").text()) - parseFloat($("[id*='lbldedtotal_" + i + "']").text());
        $("[id*='lblnet_" + i + "']").text(netsalary);
    }
    else {
        $("[id*='lblnet_" + i + "']").text('');
    }
    if ($("[id*='txtpfemp_" + i + "']").val() != '' && $("[id*='txtpftrust_" + i + "']").val() != '') {
        var pftotal = parseFloat($("[id*='txtpfemp_" + i + "']").val()) + parseFloat($("[id*='txtpftrust_" + i + "']").val());
        $("[id*='lblpftotal_" + i + "']").text(pftotal);
    }
    else {
        $("[id*='lblpftotal_" + i + "']").text('');
    }
    if ($("[id*='lblgross_" + i + "']").text() != '' && $("[id*='txtpftrust_" + i + "']").val() != '') {
        var finalsalary = parseFloat($("[id*='lblgross_" + i + "']").text()) + parseFloat($("[id*='txtpftrust_" + i + "']").val());
        $("[id*='lblfinal_" + i + "']").text(finalsalary);
    }
    else {
        $("[id*='lblfinal_" + i + "']").text('');
    }
    if (curr != "") {
        if (parseFloat(curr) > parseFloat(max) && $(input).attr('calculate').indexOf('1') != -1) {
            $("[id*=" + input.id + "]").css("border-color", "red");
            $("[id*=" + input.id + "]").val('');
            calculate(input);
            $.notify("Amount cannot be greater than " + max + "", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
        else {
            $("[id*=" + input.id + "]").css("border-color", "");
        }
    }
}

function filltable() {
    $('[id*=tblstruct]').empty();
    var msg = validateload();
    if (msg == "") {
        $('div.panel-primary').append(loader);
        var obj = {};
        obj.department = $('[id*=ddldept]').val();
        obj.emp_type = $('[id*=ddlcategory]').val();
        obj.month = $('[id*=ddlappmonth]').val();
        obj.year = $('[id*=ddlappyear]').val();
        obj.process = "New";
        $.ajax({
            type: "POST",
            url: "salary_monthly_entry.aspx/getmonthly",
            data: '{obj:' + JSON.stringify(obj) + '}',
            contentType: "application/json; charset=utf-8",
            success: function (r) {
                if (r.d.emp_salary.length > 0) {
                    if (r.d.emp_salary[0].process != "NO") {   
                        $('[id*=tblstruct]').empty();
                        var tbl = "<thead><tr class='alert-info'><th rowspan='2' style='text-align:center;'><input type='checkbox' id='chksal'><label for='chksal'>All</label></th><th rowspan='2' style='text-align:center;'>Employee Id</th><th rowspan='2' style='text-align:center;'>Employee Name</th><th rowspan='2' style='text-align:center;display: none;'>Struct Id</th><th rowspan='2' style='text-align:center;'>Pay Scale</th><th style='text-align:center;' colspan='10'>Details of Salary</th><th style='text-align:center;' rowspan='2'>P.F.NO.</th><th style='text-align:center;' colspan='5'>Deductions</th><th style='text-align:center;' rowspan='2'>NET SALARY</th><th style='text-align:center;' rowspan='2'>PF CONTRIBUTION OF TRUST</th><th style='text-align:center;' rowspan='2'>TOTAL CONTRIBUTION TO PF</th><th style='text-align:center;' rowspan='2'>Total Salary Of Employee</th><th style='text-align:center;' rowspan='2'>Remark</th></tr><tr class='alert-info'><th style='text-align:center;'>Basic</th><th style='text-align:center;'>AGP</th><th style='text-align:center;'>Total<br />(Basic + AGP)</th><th style='text-align:center;'>% D.A (56%)</th><th style='text-align:center;'>20% HRA</th><th style='text-align:center;'>T.A</th><th style='text-align:center;'>Others (Sp. Allow)</th><th style='text-align:center;'>Gross Salary</th><th style='text-align:center;'>Arrears</th><th style='text-align:center;'>Total Salary</th><th style='text-align:center;'>PF</th><th style='text-align:center;'>PT</th><th style='text-align:center;'>TDS</th><th style='text-align:center;'>OTHERS</th><th style='text-align:center;'>TOTAL DED.</th></tr></thead>";
                        tbl += "<tbody>";
                        $.each(r.d.emp_salary, function (i) {
                            tbl += "<tr>";
                            tbl += "<td><input type='checkbox' id='chkrow" + i + "r' class='selectall'></td>";
                            tbl += "<td><label id='lblempid" + i + "r' class='compwidth' style='text-align:center;'>" + this.emp_id + "</label></td>";
                            tbl += "<td><label id='lblempname" + i + "r' class='compwidth' style='text-align:center;'>" + this.emp_name + "</label></td>";
                            tbl += "<td style='display: none;'><label id='lblstructid" + i + "r' class='compwidth' style='text-align:center;'>" + this.id + "</label></td>";
                            tbl += "<td><label id='lblscale" + i + "r' class='compwidth' style='text-align:center;'>" + this.scale + "</label></td>";
                            tbl += "<td><input type='number' id='txtbasic_" + i + "r' onkeyup='calculate(this)' class='compwidth' value='" + this.basic + "' max='" + this.basic + "' calculate='1'/></td>";
                            tbl += "<td><input type='number' class='compwidth' id='txtagp_" + i + "r' onkeyup='calculate(this)' class='compwidth' value='" + this.agp + "' calculate='1'/></td>";
                            tbl += "<td><label id='lblbasictotal_" + i + "r' class='compwidth' style='text-align:center;'>" + this.total + "</label></td>";
                            tbl += "<td><input type='number' class='compwidth' id='txtda_" + i + "r' onkeyup='calculate(this)' value='" + this.da + "' calculate='1'/></td>";
                            tbl += "<td><input type='number' id='txthra_" + i + "r' onkeyup='calculate(this)' class='compwidth' value='" + this.hra + "' calculate='1'/></td>";
                            tbl += "<td><input type='number' class='compwidth' id='txt_ta_" + i + "r' onkeyup='calculate(this)' value='" + this.ta + "' calculate='1'/></td>";
                            tbl += "<td><input type='number' class='compwidth' id='txtOSA_" + i + "r' onkeyup='calculate(this)' value='" + this.oth_sp_allow + "' calculate='0'/></td>";
                            tbl += "<td><label id='lblgross_" + i + "r' style='text-align:center;' class='compwidth'>" + this.gross_salary + "</label></td>";
                            tbl += "<td><input type='number' class='compwidth' id='txtarrears_" + i + "r' onkeyup='calculate(this)' value='" + this.arrears + "' calculate='0'/></td>";
                            tbl += "<td><label id='lblsalarytotal_" + i + "r' style='text-align:center;' class='compwidth'>" + this.total_salary + "</label></td>";
                            tbl += "<td><label id='lblpfno_" + i + "r' style='text-align:center;' class='compwidth'>" + this.pf_no + "</label></td>";
                            tbl += "<td><input type='number' class='compwidth' id='txtpfemp_" + i + "r' onkeyup='calculate(this)' value='" + this.pf_emp + "' calculate='1'/></td>";
                            tbl += "<td><input type='number' class='compwidth' id='txtpt_" + i + "r' onkeyup='calculate(this)' value='" + this.pt + "' calculate='0'/></td>";
                            tbl += "<td><input type='number' class='compwidth' id='txttds_" + i + "r' onkeyup='calculate(this)' value='" + this.tds + "' calculate='0'/></td>";
                            tbl += "<td><input type='number' class='compwidth' id='txtOD_" + i + "r' onkeyup='calculate(this)' value='" + this.oth_deduct + "' calculate='0'/></td>";
                            tbl += "<td><label id='lbldedtotal_" + i + "r' style='text-align:center;' class='compwidth'>" + this.total_deduct + "</label></td>";
                            tbl += "<td><label id='lblnet_" + i + "r' style='text-align:center;' class='compwidth'>" + this.net_salary + "</label></td>";
                            tbl += "<td><input type='number' class='compwidth' id='txtpftrust_" + i + "r' onkeyup='calculate(this)' value='" + this.pf_trust + "' calculate='1'/></td>";
                            tbl += "<td><label id='lblpftotal_" + i + "r' style='text-align:center;' class='compwidth'>" + this.total_pf + "</label></td>";
                            tbl += "<td><label id='lblfinal_" + i + "r' style='text-align:center;' class='compwidth'>" + this.total_salary_emp + "</label></td>";
                            tbl += "<td><textarea style='width:120px;' id='txtremark" + i + "r'/></textarea></td>";
                            tbl += "</tr>";
                        });
                        tbl += "</tbody>";
                        $('[id*=tblstruct]').append(tbl);
                        $('[id*=tblstruct]').fixedTableHeader();
                        $('[id*=btngetdata]').val('Save')
                        $("div.panel-primary > div.overlay").remove();
                    }
                    else {
                        $.notify('Employee data not found or salary already generated', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        $("div.panel-primary > div.overlay").remove();
                    }
                }
                else {
                    $.notify('Employee data not defined for selected month', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $("div.panel-primary > div.overlay").remove();
                }
            },
            error: function (xhr, status, error) {
                $.notify(error, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                $("div.panel-primary > div.overlay").remove();
            }
        });
    }
}

$('[id*=btngetdata]').click(function () {
    if ($('[id*=btngetdata]').val() == "New") {
        filltable();
    }
    else if ($('[id*=btngetdata]').val() == "Save") {
        var msg = validate();
        if (msg == "") {
            $('div.panel-primary').append(loader);
            var obj = {};
            var s = [];
            $.each($('[id*=tblstruct] tbody tr input[type=checkbox]:checked'), function (r) {
                var row = $(this).closest("tr")[0];
                s.push({
                    'emp_id': row.cells[1].innerText,
                    'id': row.cells[3].innerText,
                    'basic': row.cells[5].firstChild.value,
                    'agp': row.cells[6].firstChild.value,
                    'total': row.cells[7].innerText,
                    'da': row.cells[8].firstChild.value,
                    'hra': row.cells[9].firstChild.value,
                    'ta': row.cells[10].firstChild.value,
                    'oth_sp_allow': row.cells[11].firstChild.value,
                    'gross_salary': row.cells[12].innerText,
                    'arrears': row.cells[13].firstChild.value,
                    'total_salary': row.cells[14].innerText,
                    'pf_no': row.cells[15].innerText,
                    'pf_emp': row.cells[16].firstChild.value,
                    'pt': row.cells[17].firstChild.value,
                    'tds': row.cells[18].firstChild.value,
                    'oth_deduct': row.cells[19].firstChild.value,
                    'total_deduct': row.cells[20].innerText,
                    'net_salary': row.cells[21].innerText,
                    'pf_trust': row.cells[22].firstChild.value,
                    'total_pf': row.cells[23].innerText,
                    'total_salary_emp': row.cells[24].innerText,
                    'remark': row.cells[25].firstChild.value,
                    'user_id': empId,
                    'month': $('[id*=ddlappmonth]').val(),
                    'year': $('[id*=ddlappyear]').val(),
                });
            });
            obj.emp_salary = s;
            $.ajax({
                type: "POST",
                url: "salary_monthly_entry.aspx/savemonthly",
                data: '{obj:' + JSON.stringify(obj) + '}',
                contentType: "application/json; charset=utf-8",
                success: function (r) {
                    if (r.d == "saved") {
                        $.notify('Saved Successfully', { color: "#fff", background: "#1EA55A", blur: 0.2, delay: 0 });
                        $('[id*=btngetdata]').val('New');
                        $('[id*=tblstruct]').empty();
                        $("div.panel-primary > div.overlay").remove();
                    }
                    else if (r.d == "failed") {
                        $.notify('Data not saved', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        $("div.panel-primary > div.overlay").remove();
                    }
                },
                error: function (xhr, status, error) {
                    $.notify(error, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $("div.panel-primary > div.overlay").remove();
                }
            });
        }
        else if(msg=="error"){
            $.notify('Fill all the details of selected employees', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            $("div.panel-primary > div.overlay").remove();
        }
        else if (msg == "No") {
            $.notify('Select employees to generate salary', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            $("div.panel-primary > div.overlay").remove();
        }
    }
});

function validate() {
    var msg = "";
    var count = 0;
    $.each($('[id*=tblstruct] tbody tr input[type=checkbox]:checked'), function (r) {
        count++;
        var row = $(this).closest("tr")[0];
        $.each($(row).find("input[type='number']"), function (c) {
            if ($(this)[0].value == "") {
                $(this).css('border-color', 'red');
                msg = "error";
            }
        });
    });
    if (count == 0) {msg="No"}
    return msg;
}

$('[id*=btnedit]').click(function () {
    $('[id*=btngetdata]').val('New');
    $('[id*=tblstruct]').empty();
    filledit();
});

function filledit() {
    $('[id*=tblstruct]').empty();
    var msg = validateload();
    if (msg == "") {
        $('div.panel-primary').append(loader);
        var obj = {};
        obj.department = $('[id*=ddldept]').val();
        obj.emp_type = $('[id*=ddlcategory]').val();
        obj.month = $('[id*=ddlappmonth]').val();
        obj.year = $('[id*=ddlappyear]').val();
        obj.process = "Edit";
        $.ajax({
            type: "POST",
            url: "salary_monthly_entry.aspx/getmonthly",
            data: '{obj:' + JSON.stringify(obj) + '}',
            contentType: "application/json; charset=utf-8",
            success: function (r) {
                if (r.d.emp_salary.length > 0) {
                    if (r.d.emp_salary[0].process != "NO") {
                        $('[id*=tblstruct]').empty();
                        var tbl = "<thead><tr class='alert-info'><th style='text-align:center;display:none;'>DelFlag</th><th style='text-align:center;'>Employee Id</th><th style='text-align:center;'>Employee Name</th><th style='text-align:center;'>Gross Salary</th><th style='text-align:center;'>Arrears</th><th style='text-align:center;'>Total Deduction</th><th style='text-align:center;'>Net Salary</th><th style='text-align:center;'>Total PF</th><th style='text-align:center;'>Total Salary</th><th style='text-align:center;'>Delete</th></tr></thead>";
                        tbl += "<tbody>";
                        $.each(r.d.emp_salary, function (i) {
                            tbl += "<tr>";
                            tbl += "<tr><td style='text-align:center;display:none;'>" + r.d.emp_salary[i].delete + "</td>";
                            tbl += "<td style='text-align:center;'>" + r.d.emp_salary[i].emp_id + "</td>";
                            tbl += "<td style='text-align:center;'>" + r.d.emp_salary[i].emp_name + "</td>";
                            tbl += "<td style='text-align:center;'>" + r.d.emp_salary[i].gross_salary + "</td>";
                            tbl += "<td style='text-align:center;'>" + r.d.emp_salary[i].arrears + "</td>";
                            tbl += "<td style='text-align:center;'>" + r.d.emp_salary[i].total_deduct + "</td>";
                            tbl += "<td style='text-align:center;'>" + r.d.emp_salary[i].net_salary + "</td>";
                            tbl += "<td style='text-align:center;'>" + r.d.emp_salary[i].total_pf + "</td>";
                            tbl += "<td style='text-align:center;'>" + r.d.emp_salary[i].total_salary_emp + "</td>";
                            tbl += "<td style='text-align:center;'><a id='btndel" + i + "r' class='del'><span class='fa fa-trash'></span></a></td>";
                            tbl += "</tr>";
                        });
                        tbl += "</tbody>";
                        $('[id*=tblstruct]').append(tbl);
                        $('[id*=tblstruct]').fixedTableHeader();
                        $("div.panel-primary > div.overlay").remove();
                    }
                    else {
                        $.notify('Salaries for selected month not generated', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        $("div.panel-primary > div.overlay").remove();
                    }
                }
                else {
                    $.notify('Employee data not found', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $("div.panel-primary > div.overlay").remove();
                }
            },
            error: function (xhr, status, error) {
                $.notify(error, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                $("div.panel-primary > div.overlay").remove();
            }
        });
    }
}

$('[id*=tblstruct]').on('click', 'td a.del', function () {
    var cells = $(this).closest("tr").children("td");
    var delflag = cells.eq(0).text();
    var emp_id = cells.eq(1).text();
    if (delflag > 0) {
        $.notify('Salary for next months are already generated', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
    else {
        $('div.panel-primary').append(loader);
        var obj = {};
        obj.emp_id = emp_id;
        obj.department = $('[id*=ddldept]').val();
        obj.emp_type = $('[id*=ddlcategory]').val();
        obj.month = $('[id*=ddlappmonth]').val();
        obj.year = $('[id*=ddlappyear]').val();
        obj.process = "Edit";
        $.ajax({
            type: "POST",
            url: "salary_monthly_entry.aspx/deletemonthly",
            data: '{obj:' + JSON.stringify(obj) + '}',
            contentType: "application/json; charset=utf-8",
            success: function (r) {
                if (r.d == "deleted") {
                    $.notify('Deleted Successfully', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    filledit();
                    $("div.panel-primary > div.overlay").remove();
                }
                else {
                    $.notify('Data not deleted', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $("div.panel-primary > div.overlay").remove();
                }
            },
            error: function (xhr, status, error) {
                $.notify(error, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                $("div.panel-primary > div.overlay").remove();
            }
        });
    }
});