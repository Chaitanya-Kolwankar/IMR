$(document).ready(function () {
    $('[id*=txtretire]').datetimepicker({
        timepicker: false,
        format: 'd/m/Y',
    });
    $('[id*=personal]').css("display", "none");
    $('[id*=tbldefined]').hide();
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
}

$("[id*='txt_empid']").keyup(function () {
    var emp_id = $("[id*='txt_empid']").val();
    if (emp_id.length == 8) {
        $('div.panel-primary').append(loader);
        var obj = {};
        obj.emp_id = emp_id;
        $.ajax({
            type: "POST",
            url: "salary_master.aspx/getdetails",
            data: '{obj:' + JSON.stringify(obj) + '}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d.emp_salary[0].process != "NO") {
                    localStorage.clear();
                    localStorage.setItem("r", JSON.stringify(r));
                    filltable(r,'');
                    $('[id*=txt_empid]').attr("disabled", "disabled");
                    $("div.panel-primary > div.overlay").remove();
                }
                else {
                    $("[id*='txtname']").val('');
                    $("[id*='txtdes']").val('');
                    $("[id*='txtjoining']").val('');
                    $('[id*=personal]').css("display", "none");
                    $('[id*=txt_empid]').removeAttr("disabled");
                    $.notify('Invalid Id', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $('[id*=tbldefined]').hide();
                    $("div.panel-primary > div.overlay").remove();
                }
            },
            error: function (xhr, status, error) {
                $.notify(error, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                $("div.panel-primary > div.overlay").remove();
            }
        });
    }
    else {
        $("[id*='txtname']").val('');
        $("[id*='txtdes']").val('');
        $("[id*='txtjoining']").val('');
        $('[id*=personal]').css("display", "none");
        $('[id*=txt_empid]').removeAttr("disabled");
        $('[id*=tbldefined]').hide();
        $("div.panel-primary > div.overlay").remove();
    }
});

$("[id*='txt_empid']").change(function () {
    var emp_id = $("[id*='txt_empid']").val();
    if (emp_id.length < 8) {
        $.notify('Invalid Id', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
});

$("[id*='ddlappyear']").change(function () {
    $('[id*=ddlappyear]').css("border-color", "");
});

$("[id*='ddlappmonth']").change(function () {
    $('[id*=ddlappmonth]').css("border-color", "");
});

$("[id*='ddlcategory']").change(function () {
    $('[id*=ddlcategory]').css("border-color", "");
});

$("[id*=btnclear]").click(function () {
    localStorage.clear();
    location.reload();
});

$("[id*=btnadd]").click(function () {
    var btntext = $("[id*=btnadd]").val();
    if (btntext.includes('Define') == true) {
        $('[id*=details]').css("display", "block");
        $('[id*=btnadd]').val('Save');
    }
    else if (btntext.includes('Save') == true) {
        var msg = validate();
        if (msg == "") {
            $('div.panel-primary').append(loader);
            var obj = {};
            obj.emp_id = $('[id*=txt_empid]').val().toUpperCase();
            obj.emp_type = $('[id*=ddlcategory]').val();
            obj.qualification = $('[id*=txtqual]').val();
            obj.scale = $('[id*=txtscale]').val();
            obj.joining = $('[id*=txtjoining]').val();
            obj.retirement = $('[id*=txtretire]').val();
            obj.month = $('[id*=ddlappmonth]').val();
            obj.year = $('[id*=ddlappyear]').val();
            obj.user_id = empId;
            obj.basic = $('[id*=txtbasic]').val();
            obj.agp = $('[id*=txtagp]').val();
            obj.total = $('[id*=lblbasictotal]').text();
            obj.da = $('[id*=txtda]').val();
            obj.hra = $('[id*=txthra]').val();
            obj.ta = $('[id*=txt_ta]').val();
            obj.oth_sp_allow = $('[id*=txtOSA]').val();
            obj.gross_salary = $('[id*=lblgross]').text();
            obj.arrears = $('[id*=txtarrears]').val();
            obj.total_salary = $('[id*=lblsalarytotal]').text();
            obj.pf_no = $('[id*=txtpfno]').val();
            obj.pf_emp = $('[id*=txtpfemp]').val();
            obj.pf_trust = $('[id*=txtpftrust]').val();
            obj.pt = $('[id*=txtpt]').val();
            obj.tds = $('[id*=txttds]').val();
            obj.oth_deduct = $('[id*=txtOD]').val();
            obj.total_deduct = $('[id*=lbldedtotal]').text();
            obj.net_salary = $('[id*=lblnet]').text();
            obj.total_pf = $('[id*=lblpftotal]').text();
            obj.total_salary_emp = $('[id*=lblfinal]').text();
            obj.remark = $('[id*=txtremark]').val();
            obj.acno = $('[id*=txtacno]').val();
            $.ajax({
                type: "POST",
                url: "salary_master.aspx/savesalary",
                data: '{obj:' + JSON.stringify(obj) + '}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (r) {
                    if (r.d.emp_salary[0].process != "NO") {
                        localStorage.clear();
                        localStorage.setItem("r", JSON.stringify(r));
                        filltable(r,'');
                        $('[id*=details]').css("display", "none");
                        $('[id*=btnadd]').val('Define');
                        $.notify('Saved Successfully', { color: "#fff", background: "#1EA55A", blur: 0.2, delay: 0 });
                        $("div.panel-primary > div.overlay").remove();
                    }
                    else {
                        $.notify('Data not Saved', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        $("div.panel-primary > div.overlay").remove();
                    }
                },
                error: function (xhr, status, error) {
                    $.notify(error, { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $("div.panel-primary > div.overlay").remove();
                }
            });
        }
        else if (msg == "amount") {
            $.notify('Provide all the salary particulars amount', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    }
    else if (btntext.includes('Update') == true) {
        $('div.panel-primary').append(loader);
        var obj = {};
        obj.emp_id = $('[id*=txt_empid]').val().toUpperCase();
        obj.emp_type = $('[id*=ddlcategory]').val();
        obj.qualification = $('[id*=txtqual]').val();
        obj.scale = $('[id*=txtscale]').val();
        obj.joining = $('[id*=txtjoining]').val();
        obj.retirement = $('[id*=txtretire]').val();
        obj.remark = $('[id*=txtremark]').val();
        obj.id = $('[id*=lblid]').text();
        obj.pf_no = $('[id*=txtpfno]').val();
        obj.acno = $('[id*=txtacno]').val();
        $.ajax({
            type: "POST",
            url: "salary_master.aspx/updatesalary",
            data: '{obj:' + JSON.stringify(obj) + '}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d.emp_salary[0].process != "NO") {
                    localStorage.clear();
                    localStorage.setItem("r", JSON.stringify(r));
                    filltable(r, '');
                    $('[id*=details]').css("display", "none");
                    $('[id*=btnadd]').val('Define');
                    $.notify('Updated Successfully', { color: "#fff", background: "#1EA55A", blur: 0.2, delay: 0 });
                    $("div.panel-primary > div.overlay").remove();
                }
                else {
                    $.notify('Data not updated', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
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

function calculate(input) {
    if ($('[id*=txtbasic]').val() != '' && $('[id*=txtagp]').val() != '') {
        var totalbasic = parseFloat($('[id*=txtbasic]').val()) + parseFloat($('[id*=txtagp]').val());
        $('[id*=lblbasictotal]').text(totalbasic);
        if ($('[id*=txtda]').val() != '' && $('[id*=txthra]').val() != '' && $('[id*=txt_ta]').val() != '' && $('[id*=txtOSA]').val() != '') {
            var totalgross = parseFloat(totalbasic) + parseFloat($('[id*=txtda]').val()) + parseFloat($('[id*=txthra]').val()) + parseFloat($('[id*=txt_ta]').val()) + parseFloat($('[id*=txtOSA]').val());
            $('[id*=lblgross]').text(totalgross);
            if ($('[id*=txtarrears]').val() != '') {
                var totalsalary = parseFloat(totalgross) + parseFloat($('[id*=txtarrears]').val());
                $('[id*=lblsalarytotal]').text(totalsalary);
            }
            else {
                $('[id*=lblsalarytotal]').text('');
            }
        }
        else {
            $('[id*=lblgross]').text('');
            $('[id*=lblsalarytotal]').text('');
        }
    }
    else {
        $('[id*=lblbasictotal]').text('');
        $('[id*=lblgross]').text('');
        $('[id*=lblsalarytotal]').text('');
    }
    if ($('[id*=txtpfemp]').val() != '' && $('[id*=txtpt]').val() != '' && $('[id*=txttds]').val() != '' && $('[id*=txtOD]').val() != '') {
        var totalded = parseFloat($('[id*=txtpfemp]').val()) + parseFloat($('[id*=txtpt]').val()) + parseFloat($('[id*=txttds]').val()) + parseFloat($('[id*=txtOD]').val());
        $('[id*=lbldedtotal]').text(totalded);
    }
    else {
        $('[id*=lbldedtotal]').text('');
    }
    if ($('[id*=lblsalarytotal]').text() != '' && $('[id*=lbldedtotal]').text() != '') {
        var netsalary = parseFloat($('[id*=lblsalarytotal]').text()) - parseFloat($('[id*=lbldedtotal]').text());
        $('[id*=lblnet]').text(netsalary);
    }
    else {
        $('[id*=lblnet]').text('');
    }
    if ($('[id*=txtpfemp]').val() != '' && $('[id*=txtpftrust]').val() != '') {
        var pftotal = parseFloat($('[id*=txtpfemp]').val()) + parseFloat($('[id*=txtpftrust]').val());
        $('[id*=lblpftotal]').text(pftotal);
    }
    else {
        $('[id*=lblpftotal]').text('');
    }
    if ($('[id*=lblgross]').text() != '' && $('[id*=txtpftrust]').val() != '') {
        var finalsalary = parseFloat($('[id*=lblgross]').text()) + parseFloat($('[id*=txtpftrust]').val());
        $('[id*=lblfinal]').text(finalsalary);
    }
    else {
        $('[id*=lblfinal]').text('');
    }
    $("[id*=" + input.id + "]").css("border-color", "");
}

function validate() {
    var msg = "";
    if ($('[id*=ddlappmonth]').val().includes('--Select--') == true) {
        $.notify('Select Month', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        $("[id*=ddlappmonth]").css("border-color", "red");
        msg = "error";
        return;
    }
    else if ($('[id*=ddlappyear]').val().includes('--Select--') == true) {
        $.notify('Select Year', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        $('[id*=ddlappyear]').css("border-color", "red");
        msg = "error";
        return;
    }
    else if ($('[id*=ddlcategory]').val().includes('--Select--') == true) {
        $.notify('Select Category', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        $('[id*=ddlcategory]').css("border-color", "red");
        msg = "error";
        return;
    }
    if (parseInt($('[id*=ddlappyear]').val()) == parseInt($('[id*=lblyear]').text())) {
        if (parseInt($('[id*=ddlappmonth]').val()) <= parseInt($('[id*=lblmonth]').text())) {
            $.notify('You can define salary only for the forthcoming months', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            $('[id*=ddlappyear]').css("border-color", "red");
            msg = "error";
        }
    }
    else if (parseInt($('[id*=ddlappyear]').val()) < parseInt($('[id*=lblyear]').text())) {
        $.notify('You can define salary only for the forthcoming months', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        $('[id*=ddlappyear]').css("border-color", "red");
        msg = "error";
    }
    if ($('[id*=txtbasic]').val() == '') {
        $('[id*=txtbasic]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txtagp]').val() == '') {
        $('[id*=txtagp]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txtda]').val() == '') {
        $('[id*=txtda]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txthra]').val() == '') {
        $('[id*=txthra]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txt_ta]').val() == '') {
        $('[id*=txt_ta]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txtOSA]').val() == '') {
        $('[id*=txtOSA]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txtarrears]').val() == '') {
        $('[id*=txtarrears]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txtpfemp]').val() == '') {
        $('[id*=txtpfemp]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txtpt]').val() == '') {
        $('[id*=txtpt]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txttds]').val() == '') {
        $('[id*=txttds]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txtOD]').val() == '') {
        $('[id*=txtOD]').css("border-color", "red");
        msg = "amount";
    }
    if ($('[id*=txtpftrust]').val() == '') {
        $('[id*=txtpftrust]').css("border-color", "red");
        msg = "amount";
    }
    return msg;
}

function filltable(r,k) {
    var status = false; var c = "";
    for (var j = 0; j < r.d.emp_salary.length; j++) {
        if (r.d.emp_salary[j].status == "True") {
            status = true;
            break;
        }
    }
    load();
    $('[id*=tbldefined]').empty();
    if (k == "") {
        c = r.d.emp_salary.length - 1;
    }
    else {
        c = k - 1;
        $('[id*=lblid]').text(r.d.emp_salary[c].id);
        $('[id*=ddlappmonth]').val(r.d.emp_salary[c].month);
        $('[id*=ddlappyear]').val(r.d.emp_salary[c].year);
    }

    $('[id*=personal]').css("display", "block");
    $("[id*='txtname']").val(r.d.emp_salary[c].emp_name);
    $("[id*='txtdes']").val(r.d.emp_salary[c].designation);
    $("[id*='txtjoining']").val(r.d.emp_salary[c].joining);
    $("[id*='txtqual']").val(r.d.emp_salary[c].qualification);
    $("[id*='txtscale']").val(r.d.emp_salary[c].scale);
    $("[id*='txtretire']").val(r.d.emp_salary[c].retirement);
    $("[id*='txtremark']").val(r.d.emp_salary[c].remark);
    $("[id*='txtacno']").val(r.d.emp_salary[c].acno);
    $("[id*='lblmonth']").text(r.d.emp_salary[c].month);
    $("[id*='lblyear']").text(r.d.emp_salary[c].year);
    $("[id*='lblcombined']").text(r.d.emp_salary[c].applicable);

    var table = "<thead><tr class='alert-info'><th style='text-align:center;display:none;'>DelFlag</th><th style='text-align:center;display:none;'>id</th><th style='text-align:center;'>Applicable From</th><th style='text-align:center;'>Gross Salary</th><th style='text-align:center;'>Total Deduction</th><th style='text-align:center;'>Net Salary</th><th style='text-align:center;'>Total PF</th><th style='text-align:center;'>Total Salary</th><th style='text-align:center;'>View</th><th style='text-align:center;'>Delete</th></tr></thead><tbody>";
    var id = false;
    for (var i = 0; i < r.d.emp_salary.length; i++) {
        if (r.d.emp_salary[i].id != '') { id = true }
        table += "<tr><td style='text-align:center;display:none;'>" + r.d.emp_salary[i].delete + "</td><td style='text-align:center;display:none;'>" + r.d.emp_salary[i].id + "</td><td style='text-align:center;'>" + r.d.emp_salary[i].applicable + "</td><td style='text-align:center;'>" + r.d.emp_salary[i].gross_salary + "</td><td style='text-align:center;'>" + r.d.emp_salary[i].total_deduct + "</td><td style='text-align:center;'>" + r.d.emp_salary[i].net_salary + "</td><td style='text-align:center;'>" + r.d.emp_salary[i].total_pf + "</td><td style='text-align:center;'>" + r.d.emp_salary[i].total_salary_emp + "</td>";
        if (status == true) {
            table += "<td style='text-align:center;'><a id='btnview" + i + "r'><span class='fa fa-edit'></span></a></td><td style='text-align:center;'><a id='btndel" + i + "r'><span class='fa fa-trash'></span></a></td>";
        }
        else {
            table += "<td style='text-align:center;'><a id='btnview" + i + "r' class='edit'><span class='fa fa-edit'></span></a></td><td style='text-align:center;'><a id='btndel" + i + "r' class='del'><span class='fa fa-trash'></span></a></td>";
        }
        table += "</tr>";
    }
    table += "</tbody>";
    $('[id*=tbldefined]').append(table);
    if (id == true) {
        $('[id*=tbldefined]').show();
        $('[id*=ddlcategory]').val(r.d.emp_salary[c].emp_type);
    }
    else {
        $('[id*=tbldefined]').hide();
    }
    
    $('[id*=tblstruct]').empty();
    var tbl = "<thead><tr class='alert-info'><th style='text-align:center;' colspan='10'>Details of Salary</th><th style='text-align:center;' rowspan='2'>P.F.NO.</th><th style='text-align:center;' colspan='5'>Deductions</th><th style='text-align:center;' rowspan='2'>NET SALARY</th><th style='text-align:center;' rowspan='2'>PF CONTRIBUTION OF TRUST</th><th style='text-align:center;' rowspan='2'>TOTAL CONTRIBUTION TO PF</th><th style='text-align:center;' rowspan='2'>Total Salary Of Employee</th></tr><tr class='alert-info'><th style='text-align:center;'>Basic</th><th style='text-align:center;'>AGP</th><th style='text-align:center;'>Total<br />(Basic + AGP)</th><th style='text-align:center;'>% D.A (56%)</th><th style='text-align:center;'>20% HRA</th><th style='text-align:center;'>T.A</th><th style='text-align:center;'>Others (Sp. Allow)</th><th style='text-align:center;'>Gross Salary</th><th style='text-align:center;'>Arrears</th><th style='text-align:center;'>Total Salary</th><th style='text-align:center;'>PF</th><th style='text-align:center;'>PT</th><th style='text-align:center;'>TDS</th><th style='text-align:center;'>OTHERS</th><th style='text-align:center;'>TOTAL DED.</th></tr></thead>";
    tbl += "<tbody><tr>";
    tbl += "<td><input type='number' id='txtbasic' onkeyup='calculate(this)' class='compwidth' value='" + r.d.emp_salary[c].basic + "'/></td>";
    tbl += "<td><input type='number' class='compwidth' id='txtagp' onkeyup='calculate(this)' class='compwidth' value='" + r.d.emp_salary[c].agp + "'/></td>";
    tbl += "<td><label id='lblbasictotal' class='compwidth' style='text-align:center;'></label></td>";
    tbl += "<td><input type='number' class='compwidth' id='txtda' onkeyup='calculate(this)' value='" + r.d.emp_salary[c].da + "'/></td>";
    tbl += "<td><input type='number' id='txthra' onkeyup='calculate(this)' class='compwidth' value='" + r.d.emp_salary[c].hra + "'/></td>";
    tbl += "<td><input type='number' class='compwidth' id='txt_ta' onkeyup='calculate(this)' value='" + r.d.emp_salary[c].ta + "'/></td>";
    tbl += "<td><input type='number' class='compwidth' id='txtOSA' onkeyup='calculate(this)' value='" + r.d.emp_salary[c].oth_sp_allow + "'/></td>";
    tbl += "<td><label id='lblgross' style='text-align:center;' class='compwidth'></label></td>";
    tbl += "<td><input type='number' class='compwidth' id='txtarrears' onkeyup='calculate(this)' value='" + r.d.emp_salary[c].arrears + "'/></td>";
    tbl += "<td><label id='lblsalarytotal' style='text-align:center;' class='compwidth'></label></td>";
    tbl += "<td><input type='text' id='txtpfno' class='compwidth' value='" + r.d.emp_salary[c].pf_no + "'/></td>";
    tbl += "<td><input type='number' class='compwidth' id='txtpfemp' onkeyup='calculate(this)' value='" + r.d.emp_salary[c].pf_emp + "'/></td>";
    tbl += "<td><input type='number' class='compwidth' id='txtpt' onkeyup='calculate(this)' value='" + r.d.emp_salary[c].pt + "'/></td>";
    tbl += "<td><input type='number' class='compwidth' id='txttds' onkeyup='calculate(this)' value='" + r.d.emp_salary[c].tds + "'/></td>";
    tbl += "<td><input type='number' class='compwidth' id='txtOD' onkeyup='calculate(this)' value='" + r.d.emp_salary[c].oth_deduct + "'/></td>";
    tbl += "<td><label id='lbldedtotal' style='text-align:center;' class='compwidth'></label></td>";
    tbl += "<td><label id='lblnet' style='text-align:center;' class='compwidth'></label></td>";
    tbl += "<td><input type='number' class='compwidth' id='txtpftrust' onkeyup='calculate(this)' value='" + r.d.emp_salary[c].pf_trust + "'/></td>";
    tbl += "<td><label id='lblpftotal' style='text-align:center;' class='compwidth'></label></td>";
    tbl += "<td><label id='lblfinal' style='text-align:center;' class='compwidth'></label></td>";
    tbl += "</tr></tbody>";
    $('[id*=tblstruct]').append(tbl);
    calculate(this);

    if (status == true) {
        $('[id*=btnadd]').attr("disabled", "disabled");
        $('[id*=btndelete]').val('Recover');
        $.notify('Employee marked as left', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
    else {
        $('[id*=btnadd]').removeAttr("disabled");
        $('[id*=btndelete]').val('Delete');
    }
    if (k != "") {
        $('[id*=ddlappyear]').attr("disabled", "disabled");
        $('[id*=ddlappmonth]').attr("disabled", "disabled");
        $('[id*=ddlcategory]').attr("disabled", "disabled");
        $('input[type=number]').attr("disabled", "disabled");
    }
    else {
        $('[id*=ddlappyear]').removeAttr("disabled");
        $('[id*=ddlappmonth]').removeAttr("disabled");
        $('[id*=ddlcategory]').removeAttr("disabled");
        $('input[type=number]').removeAttr("disabled");
    }
}

$('[id*=btndelete]').click(function () {
    if ($('[id*=btndelete]').val() == "Delete") {
        var msg = confirm('Employee will be marked as left, Do you want to continue?');
        if (msg == true) {
            $('div.panel-primary').append(loader);
            var obj = {};
            obj.emp_id = $('[id*=txt_empid]').val().toUpperCase();
            obj.process = "Delete";
            $.ajax({
                type: "POST",
                url: "salary_master.aspx/deleteuser",
                data: '{obj:' + JSON.stringify(obj) + '}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (r) {
                    if (r.d.emp_salary[0].process != "NO") {
                        localStorage.clear();
                        localStorage.setItem("r", JSON.stringify(r));
                        filltable(r, '');
                        $('[id*=details]').css("display", "none");
                        $('[id*=btnadd]').val('Define');
                        $.notify('Deleted Successfully', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
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
    }
    else if ($('[id*=btndelete]').val() == "Recover") {
        $('div.panel-primary').append(loader);
        var obj = {};
        obj.emp_id = $('[id*=txt_empid]').val().toUpperCase();
        obj.process = "Recover";
        $.ajax({
            type: "POST",
            url: "salary_master.aspx/deleteuser",
            data: '{obj:' + JSON.stringify(obj) + '}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d.emp_salary[0].process != "NO") {
                    localStorage.clear();
                    localStorage.setItem("r", JSON.stringify(r));
                    filltable(r, '');
                    $('[id*=details]').css("display", "none");
                    $('[id*=btnadd]').val('Define');
                    $.notify('Recoverd Successfully', { color: "#fff", background: "#1EA55A", blur: 0.2, delay: 0 });
                    $("div.panel-primary > div.overlay").remove();
                }
                else {
                    $.notify('Data not recovered', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
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

$("[id*=tbldefined]").on('click', 'td a.del', function () {
    var cells = $(this).closest("tr").children("td");
    var delflag = cells.eq(0).text();
    var id = cells.eq(1).text();
    if (delflag == 1) {
        $.notify('Salary already generated on this Scale', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
    else {
        $('div.panel-primary').append(loader);
        var obj = {};
        obj.emp_id = $('[id*=txt_empid]').val().toUpperCase();
        obj.id = id;
        $.ajax({
            type: "POST",
            url: "salary_master.aspx/deletesalary",
            data: '{obj:' + JSON.stringify(obj) + '}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d.emp_salary[0].process != "NO") {
                    localStorage.clear();
                    localStorage.setItem("r", JSON.stringify(r));
                    filltable(r,'');
                    $('[id*=details]').css("display", "none");
                    $('[id*=btnadd]').val('Define');
                    $.notify('Deleted Successfully', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $("div.panel-primary > div.overlay").remove();
                }
                else {
                    $.notify('Data not Saved', { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
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

$('[id*=tbldefined]').on('click', 'td a.edit', function () {
    var cells = $(this).closest("tr").children("td");
    var id = cells.eq(1).text();
    var r = JSON.parse(localStorage["r"]);
    for (var i = 0; i < r.d.emp_salary.length; i++) {
        if (id == r.d.emp_salary[i].id) {
            filltable(r, i + 1);
            $('[id*=btnadd]').val('Update');
            $('[id*=details]').css("display", "block");
            break
        }
    }
});