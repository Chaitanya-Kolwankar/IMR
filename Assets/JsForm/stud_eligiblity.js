$(document).ready(function () {
    academicyear();
    course(group_ids);
    var x = document.getElementsByClassName("loader");
    x[0].style.display = "none";
    $("[id*=lst_maping]").multiselect("clearSelection");
});

function academicyear() {  
    $.ajax({
        type: "POST",
        url: "stud_eligiblity.aspx/fillyear",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (r) {
            $.each(r.d, function () {
                //$("[id*=ddl_fromyear]").append($("<option></option>").val(this['Value']).html(this['Text']));
                $("[id*=ddltoyear]").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function () {
            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }       
    });
};
function course(group_ids) {
    $.ajax({
        type: "POST",
        url: "stud_eligiblity.aspx/fillcourse",
        data: '{group_ids:"'+group_ids+'"}',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (r) {
            $.each(r.d, function () {
                $("[id*=ddlcourse]").append($("<option></option>").val(this['Value']).html(this['Text']));                
            });
        },
        error: function () {
            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });
};

$("[id*='ddltoyear']").change(function () {
    if (from_yr == $("[id*='ddltoyear']").val()) {
        $.notify("FROM YEAR and TO YEAR cannot be same", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        $("[id*=ddltoyear]")[0].selectedIndex = 0;
    }
    // var toyear = $("[id*=ddltoyear]")[0].selectedIndex;
    //if ($("[id*='ddltoyear'] :selected").text() == '--Select--')
    // {
        //=========================
        //  $("[id*=ddlcourse]").empty();
        // $("[id*=ddlsubgrp]").empty();
        // $("[id*=ddltogroup]").empty();
        
   // }
});

$("[id*='ddltogroup']").change(function () {
    $("[id*=show]")[0].style.display = "none";
});

$("[id*='ddlcourse']").change(function () {

    $.ajax({
        type: "POST",
        url: "stud_eligiblity.aspx/fillsubcourse",
        data: '{course_id:"' + $("[id*='ddlcourse']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (r) {
            $("[id*=ddlsubgrp]").empty().append('<option selected="selected" value="0">--Select--</option>');
            $("[id*=ddltogroup]").empty();
            //$("[id*=ddltogroup]").empty().append('<option selected="selected" value="0">--Select--</option>');
            $.each(r.d, function () {
                $("[id*=ddlsubgrp]").append($("<option></option>").val(this['Value']).html(this['Text']));
            });

        }


    });

    $("[id*='ddlsubgrp']").change(function () {

        $.ajax({
            type: "POST",
            url: "stud_eligiblity.aspx/filltogroup",
            data: '{subcourse_id:"' + $("[id*='ddlsubgrp']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                $("[id*=ddltogroup]").empty().append('<option selected="selected" value="0">--Select--</option>');
                $.each(r.d, function () {
                    $("[id*=ddltogroup]").append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
        });

    });

    $("[id*='ddltogroup']").change(function () {
        //togroup = $("[id*='ddltogroup']").val();
        ////branch = $("[id*='ddl_branch']").val();
        ////semid = $("[id*='ddl_sem']").val();
        //if (togroup == "--Select--") {
        //    $.notify("Select Appropriate Course. ", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        //}
        //else {
        //    $.ajax({
        //        type: "POST",
        //        url: "stud_eligiblity.aspx/fillfromgroup",
        //        data: '{togroup:"' + togroup + '"}',
        //        contentType: "application/json; charset=utf-8",
        //        async: false,
        //        success: function (r) {
        //            $("[id*=ddlfromgroup]").empty().append('<option selected="selected" value="0">--Select--</option>');
        //            $.each(r.d, function () {
        //                $("[id*=ddlfromgroup]").append($("<option></option>").val(this['Value']).html(this['Text']));
        //            });
        //        }
        //    });
        //}   
    });

    $("[id*=dgv_load]").on('click', 'input[type="checkbox"]', function () {

        if ($(this).attr("id") == 'chkAll') {

            if ($(this).prop("checked") == true) {
                $('[id*=dgv_load] tbody tr td input[type="checkbox"]').each(function () {
                    if ($(this).prop('disabled')) {
                        $(this).prop('checked', true);
                    }
                    else {
                        $(this).prop('checked', true);
                    }

                });
            }
            else {
                $('[id*=dgv_load] tbody tr td input[type="checkbox"]').each(function () {
                    if ($(this).prop('disabled')) {
                        $(this).prop('checked', true);
                    }
                    else {
                        $(this).prop('checked', false);
                    }

                });
            }
        }
        //else {
        //    $(this).closest('tr').removeClass();
        //    if ($(this).prop("checked") == true) {
        //        $(this).closest('tr').addClass('alert-default');
        //    }
        //    else {
        //        $(this).closest('tr').addClass('alert-default');
        //    }
        //}
    });

    $("[id*='btn_get']").on('click', function () {
        get_griddata();
    });

    function get_griddata() {
        if (validate()) {
            $("[id*=lst_maping]").multiselect("clearSelection");
            var ayid = $("[id*=ddlyear]").val();
            var toyear = $("[id*=ddltoyear]").val();
            var subcourse = $("[id*=ddlsubgrp]").val();
            var group_id = $("[id*=ddltogroup]").val();
            var list = $("[id*=lst_maping]");

            var from_rollno = $("[id*=txt_from]").val();
            var to_rollno = $("[id*=txt_to]").val();

            $("[id*=show]")[0].style.display = "block";
            list.empty();
            list.multiselect('rebuild');
            $("[id*=divgrid]").hide();
            $("[id*=dgv_load]").empty();
            var subcourse_text = $("[id*=ddlsubgrp] :selected").text();
            if ($("[id*=ddltogroup] :selected").text() == "--select--") {
                $("[id*=dgv_load]").empty();
                list.empty();
                list.multiselect('rebuild');
                $("[id*=btn_excel]")[0].style.display = "none";
                $("[id*=divgrid]").hide();
            }
            else {

                var x = document.getElementsByClassName("loader");
                x[0].style.display = "block";

                $.ajax({
                    type: "POST",
                    url: "stud_eligiblity.aspx/subgroup",
                    data: '{grp_id:"' + $("[id*='ddltogroup']").val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    success: function (r) {
                        list.empty();
                        $.each(r.d, function () {
                            if (this['Text'].endsWith('(2016)') == true || this['Text'].endsWith('2015') == true || this['Text'].endsWith('2014') == true || this['Text'].endsWith('(OLD)') == true) {
                                list.append($("<option  ></option>").val(this['Value']).html(this['Text']));
                                // $("[id*=lst_maping]").multiselect('rebuild');
                            }
                            else {
                                list.append($("<option selected='selected' ></option>").val(this['Value']).html(this['Text']));
                                // $("[id*=lst_maping]").multiselect('rebuild');
                            }
                        });

                        list.append($("<option></option>").val($("[id*=ddltogroup]").val()).html($("[id*=ddltogroup] :selected")[0].innerText));
                        $("[id*=lst_maping]").multiselect('rebuild');

                        //fill grid
                        //$("[id*='ddltogroup']").css("border-color", "#ccc");

                        $.ajax({
                            type: "POST",
                            url: "stud_eligiblity.aspx/changesubgroup_new",
                            data: '{ayid:"' + ayid + '",group_id:"' + group_id + '",subcourse_id:"' + subcourse + '",subcrs_text:"' + subcourse_text + '",stud_Id:"",frm_rol:"' + from_rollno + '",to_rol:"' + to_rollno + '",to_yr:"' + toyear + '"}',
                            contentType: "application/json; charset=utf-8",
                            //async:false,
                            success: function (data) {


                                if (data.d.length > 0) {
                                    $("[id*=divgrid]").show(1000);
                                    $("[id*=dgv_load]").empty();

                                    $("[id*=btn_excel]")[0].style.display = "block";

                                    var thead = "<thead><tr class='alert-info'><th><div class='form-inline'><span style='padding-right:5px'><input type='checkbox' style='height:15px;width:15px' id='chkAll'/></span></div></th><th>Roll No</th><th>Student ID</th><th>Student Name</th>"
                                    if ($("[id*=ddltogroup] :selected").text().startsWith("F") == true || $("[id*=ddltogroup] :selected").text().endsWith("-I") == true || $("[id*=ddltogroup] :selected").text().endsWith(" I") == true || $("[id*=ddlsubgrp] :selected").text().endsWith("Part I") == true) {
                                        // thead += "SEM-1 CE</th><th>SEM-1 CG</th><th>SEM-1 SGPI</th><th>Sem1 KT Count</th><th>SEM-2 CE</th><th>SEM-2 CG</th><th>SEM-2 SGPI</th><th>Sem2 KT Count</th>"

                                    }
                                    else if ($("[id*=ddltogroup] :selected").text().startsWith("S") == true || $("[id*=ddltogroup] :selected").text().endsWith("II") == true || $("[id*=ddltogroup] :selected").text().startsWith("PHY") == true || $("[id*=ddltogroup] :selected").text().startsWith("CHEM") == true || $("[id*=ddltogroup] :selected").text().startsWith("BOT") == true) {
                                        //thead += "SEM-1 CE</th><th>SEM-1 CG</th><th>SEM-1 SGPI</th><th>Sem1 KT Count</th><th>SEM-2 CE</th><th>SEM-2 CG</th><th>SEM-2 SGPI</th><th>Sem2 KT Count</th><th>SEM-3 CE</th><th>SEM-3 CG</th><th>SEM-3 SGPI</th><th>Sem3 KT Count</th><th>SEM-4 CE</th><th>SEM-4 CG</th><th>SEM-4 SGPI</th><th>Sem4 KT Count</th>"

                                    }
                                    else if ($("[id*=ddltogroup] :selected").text().startsWith("T") == true) {
                                        //thead += "SEM-1 CE</th><th>SEM-1 CG</th><th>SEM-1 SGPI</th><th>Sem1 KT Count</th><th>SEM-2 CE</th><th>SEM-2 CG</th><th>SEM-2 SGPI</th><th>Sem2 KT Count</th><th>SEM-3 CE</th><th>SEM-3 CG</th><th>SEM-3 SGPI</th><th>Sem3_KT_Count</th><th>SEM-4 CE</th><th>SEM-4 CG</th><th>SEM-4 SGPI</th><th>Sem4 KT Count</th><th>SEM-5 CE</th><th>SEM-5 CG</th><th>SEM-5 SGPI</th><th>Sem5 KT Count</th><th>SEM-6 CE</th><th>SEM-6 CG</th><th>SEM-6 SGPI</th><th>Sem6 KT Count</th>"
                                    }
                                    else {
                                        //thead += "SEM-1 CE</th><th>SEM-1 CG</th><th>SEM-1 SGPI</th><th>Sem1 KT Count</th><th>SEM-2 CE</th><th>SEM-2 CG</th><th>SEM-2 SGPI</th><th>Sem2 KT Count</th><th>SEM-3 CE</th><th>SEM-3 CG</th><th>SEM-3 SGPI</th><th>Sem3 KT Count</th><th>SEM-4 CE</th><th>SEM-4 CG</th><th>SEM-4 SGPI</th><th>Sem4 KT Count</th><th>SEM-5 CE</th><th>SEM-5 CG</th><th>SEM-5 SGPI</th><th>Sem5 KT Count</th><th>SEM-6 CE</th><th>SEM-6 CG</th><th>SEM-6 SGPI</th><th>Sem6 KT Count</th>"
                                    }
                                    thead += "<th>Status</th></tr></thead>";
                                    $("[id*=dgv_load]").append(thead);

                                    for (var i = 0; i < data.d.length; i++) {
                                        if (i == 0) {
                                            $("[id*=dgv_load]").append("<tbody>");
                                        }
                                        $("[id*=dmltype]")[0].innerText = data.d[i].type;
                                        //to insert
                                        if (data.d[i].type == "insert") {

                                            if ($("[id*=ddltogroup] :selected").text().startsWith("F") == true || $("[id*=ddltogroup] :selected").text().endsWith("-I") == true || $("[id*=ddltogroup] :selected").text().endsWith(" I") == true || $("[id*=ddlsubgrp] :selected").text().endsWith("Part I") == true) {

                                                if (data.d[i].formfilled == "1") {
                                                    if (data.d[i].exist == "True") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' disabled checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].exist == "True") {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                    else {
                                                        if (data.d[i].Status == "Not Eligible") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg != "") {
                                                                if (data.d[i].Status == "Admitted") {
                                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' disabled style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                                else {
                                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else if ($("[id*=ddltogroup] :selected").text().startsWith("S") == true || $("[id*=ddltogroup] :selected").text().endsWith("II") == true || $("[id*=ddltogroup] :selected").text().startsWith("PHY") == true || $("[id*=ddltogroup] :selected").text().startsWith("CHEM") == true || $("[id*=ddltogroup] :selected").text().startsWith("BOT") == true) {

                                                if (data.d[i].formfilled == "1") {
                                                    if (data.d[i].exist == "True") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].exist == "True") {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                    else {
                                                        if (data.d[i].Status == "Not Eligible") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg != "") {
                                                                if (data.d[i].Status == "Admitted") {
                                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' disabled style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                                else {
                                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else if ($("[id*=ddltogroup] :selected").text().startsWith("T") == true) {
                                                $("[id*=lst_maping]").multiselect('rebuild');
                                                if (data.d[i].formfilled == "1") {
                                                    if (data.d[i].exist == "True") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].exist == "True") {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                    else {
                                                        if (data.d[i].Status == "Not Eligible") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                                if (data.d[i].Status == "Admitted") {
                                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox' checked='true' disabled class='form-control' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                } else {
                                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else {
                                                $("[id*=lst_maping]").multiselect('rebuild');
                                                if (data.d[i].formfilled == "1") {
                                                    if (data.d[i].exist == "True") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].exist == "True") {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                    else {
                                                        if (data.d[i].Status == "Not Eligible") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  class='form-control' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                                if (data.d[i].Status == "Admitted") {
                                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox' checked='true' disabled class='form-control' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                                else {
                                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }//To update
                                        else {
                                            if ($("[id*=ddltogroup] :selected").text().startsWith("F") == true || $("[id*=ddltogroup] :selected").text().endsWith("-I") == true || $("[id*=ddltogroup] :selected").text().endsWith(" I") == true || $("[id*=ddlsubgrp] :selected").text().endsWith("Part I") == true) {

                                                if (data.d[i].formfilled == "1") {
                                                    if (data.d[i].exist == "True") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px'  checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].exist == "True") {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].Status == "Admitted") {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' checked='true' disabled id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                    else {
                                                        if (data.d[i].Status == "Not Eligible") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  class='form-control' style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg != "") {
                                                                if (data.d[i].Status == "Admitted") {
                                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox' checked='true' disabled class='form-control' style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                } else {
                                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");

                                                                }
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else if ($("[id*=ddltogroup] :selected").text().startsWith("S") == true || $("[id*=ddltogroup] :selected").text().endsWith("II") == true || $("[id*=ddltogroup] :selected").text().startsWith("PHY") == true || $("[id*=ddltogroup] :selected").text().startsWith("CHEM") == true || $("[id*=ddltogroup] :selected").text().startsWith("BOT") == true) {

                                                if (data.d[i].formfilled == "1") {
                                                    if (data.d[i].exist == "True") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].exist == "True") {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].Status == "Admitted") {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' disabled style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                    else {
                                                        if (data.d[i].Status == "Not Eligible") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'   style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg != "") {
                                                                if (data.d[i].Status == "Admitted") {
                                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox' checked='true' disabled class='form-control' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                                else {
                                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else if ($("[id*=ddltogroup] :selected").text().startsWith("T") == true) {
                                                $("[id*=lst_maping]").multiselect('rebuild');
                                                if (data.d[i].formfilled == "1") {
                                                    if (data.d[i].exist == "True") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].exist == "True") {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].Status == "Admitted") {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' disabled style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                    else {
                                                        if (data.d[i].Status == "Not Eligible") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  class='form-control' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                                if (data.d[i].Status == "Admitted") {
                                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox' checked='true' disabled class='form-control' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                                else {
                                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");

                                                                }
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else {
                                                $("[id*=lst_maping]").multiselect('rebuild');
                                                if (data.d[i].formfilled == "1") {
                                                    if (data.d[i].exist == "True") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].exist == "True") {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].Status == "Admitted") {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' disabled style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            } else {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                    else {
                                                        if (data.d[i].Status == "Not Eligible") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'   style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                                if (data.d[i].Status == "Admitted") {
                                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' disabled style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                                else {
                                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                                }
                                                            }
                                                            else {
                                                                $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (i == data.d.length - 1) {
                                            $("[id*=dgv_load]").append("</tbody>");
                                        }
                                    }
                                }
                                else {
                                    $.notify("No Data Found!!", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                }

                                var x = document.getElementsByClassName("loader");
                                x[0].style.display = "none";
                                $("#btn_excel").removeAttr("disabled");
                            },
                            error: function () {
                                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });


                    },
                    error: function () {
                        //alert('Connection error, please retry');
                        hasError = true;
                        //$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                });
            }
        }
    }

    $("[id*='chk_search']").on("click", function () {
        $("[id*=lst_maping]").multiselect('rebuild');
        $("[id*=ddlcourse]")[0].selectedIndex = 0;
        $("[id*=ddltoyear]")[0].selectedIndex = 0;
        $("[id*=ddlsubgrp]")[0].selectedIndex = 0;
        $("[id*=ddltogroup]")[0].selectedIndex = 0;

        $("[id*=ddltogroup]").attr("disabled", "disabled");
        $("[id*=ddlcourse]").attr("disabled", "disabled");
        $("[id*=ddltoyear]").attr("disabled", "disabled");
        $("[id*=ddlsubgrp]").attr("disabled", "disabled");
        $("[id*=btn_get]").attr("disabled", "disabled");

        $("[id*=divgrid]").hide();
        $("[id*=dgv_load]").empty();

        if ($("[id*='chk_search']").is(":checked")) {
            $("#txt_search").removeAttr("disabled");
            $("#btn_IDsearch").removeAttr("disabled");
            $("#txt_search").focus();
            
            if ($("[id*='chk_roll']").is(":checked")) {
                $("[id*='chk_roll']").prop('checked', false);
                document.getElementById('txt_from').value = '';
                document.getElementById('txt_to').value = '';

                $("[id*=rollfrom]").hide();
                $("[id*=rollto]").hide();
            }
        }
        else {
            cleardata();
        }
    });

    $("[id*='chk_roll']").on("click", function () {
        if ($("[id*='chk_roll']").is(":checked")) {
            $("[id*=rollfrom]").show();
            $("[id*=rollto]").show();
            if ($("[id*='chk_search']").is(":checked")) {
                $("[id*='chk_search']").prop('checked', false);
                $("[id*='txt_search']").attr("disabled", "disabled");
                $("[id*='btn_IDsearch']").attr("disabled", "disabled");
            }
        }
        else {
            //$("[id*=txt_from]").value = '';
            //$("[id*=txt_to]").value = '';

            document.getElementById('txt_from').value = '';
            document.getElementById('txt_to').value = '';

            $("[id*=rollfrom]").hide();
            $("[id*=rollto]").hide();
        }

    });

    $("[id*='btn_IDsearch']").on("click", function () {
        var stud_id = $("#txt_search").val();

        if (stud_id == "") {
            $.notify("Please Enter Student ID !", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

        }
        else {
            $.ajax({
                type: "POST",
                url: "stud_eligiblity.aspx/Modal_grid",
                data: '{stud_id:"' + stud_id + '"}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {


                    $("[id*=gv_modal]").empty();

                    if (data.d.length > 0) {
                        if (data.d[0].msg != "") {
                            $.notify("no data found", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            $("#txt_search").attr("disabled", "disabled");
                            $("#btn_IDsearch").attr("disabled", "disabled");
                            $("[id*='chk_search']")[0].checked = false;
                            $("[id*='txt_search']").val("");
                        }
                        else {
                            $('#searchModal').modal("show");
                            var thead = "<thead><tr class='alert-info'><th>Roll No</th><th>Student ID</th><th>Student Name</th><th style='display:none'>AYID</th><th>Duration</th><th>Subcourse</th><th style='display:none'>Subcourse_Id</th><th>Group_Title</th><th style='display:none'>Group_Id</th><th style='display:none'>Course_id</th><th>Select</th></thead>";
                            $("[id*=gv_modal]").append(thead);

                            for (var i = 0; i < data.d.length; i++) {
                                if (i == 0) {
                                    $("[id*=gv_modal]").append("<tbody>");
                                }
                                $("[id*=gv_modal]").append("<tr><td>" + data.d[i].roll_no + "</td><td>" + stud_id + "</td><td>" + data.d[i].Name + "</td><td style='display:none'>" + data.d[i].ayid + "</td><td>" + data.d[i].duration + "</td><td>" + data.d[i].subcourse + "</td><td style='display:none'>" + data.d[i].sub_crs_id + "</td><td>" + data.d[i].group_title + "</td><td style='display:none'>" + data.d[i].grp_id + "</td><td style='display:none'>" + data.d[i].course + "</td><td><a href='#' class='Select'>SELECT</a></td></tr>");
                                if (i == data.d.length - 1) {
                                    $("[id*=gv_modal]").append("</tbody>");
                                }
                            }
                        }
                    }
                    else {
                        $.notify("Error ! Error Occured , please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                }
            });
        }
    });

    $("[id*=gv_modal]").on('click', 'td a.Select', function () {

        var $td = $(this).closest('tr').children('td');
        var id = $td.eq(1).text();
        var name = $td.eq(2).text();
        var ayid = $td.eq(3).text();
        var sub_txt = $td.eq(5).text();
        var sub_crs_id = $td.eq(6).text();
        var grp_txt = $td.eq(7).text();
        var grp_id = $td.eq(8).text();
        var course_id = $td.eq(9).text();
        var query = "";

        //$("[id*='ddltoyear']").val(ayid);
        $("[id*='ddlyear']").val(ayid)
        $("[id*='ddlcourse']").val(course_id);

        //current ayid
        $.ajax({
            type: "POST",
            url: "stud_eligiblity.aspx/curr_year",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d != "NO") {
                    $("[id*='ddltoyear']").val(r.d);
                }
                else {
                    $.notify("Current year not defined", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    return;
                }
            }
        });

        //course change
        $.ajax({
            type: "POST",
            url: "stud_eligiblity.aspx/courseChange",
            data: '{courseID:"' + course_id + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                //$("[id*=ddlSubcrs]").empty().append('<option selected="selected" value="0">--select--</option>');
                $.each(r.d, function () {
                    if (this['Value'] == sub_crs_id) {
                        $("[id*=ddlsubgrp]").append($("<option selected='selected'></option>").val(this['Value']).html(this['Text']));
                    }
                    else {
                        $("[id*=ddlsubgrp]").append($("<option></option>").val(this['Value']).html(this['Text']));
                    }
                });
            }
        });


        //on subcourse change

        $.ajax({
            type: "POST",
            url: "stud_eligiblity.aspx/subcourseChange",
            data: '{subcourseID:"' + sub_crs_id + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {

                $.each(r.d, function () {
                    //to check modal group id match with ddlsubGrp group id ----if equal then show that
                    if (this['Value'] == grp_id) {
                        $("[id*=ddltogroup]").append($("<option selected='selected'></option>").val(this['Value']).html(this['Text']));
                    }
                    else {
                        $("[id*=ddltogroup]").append($("<option></option>").val(this['Value']).html(this['Text']));
                    }
                });
            }
        });

        $('#searchModal').modal("hide");

        $("[id*='ddlSubcrs']").val(sub_crs_id);
        var frm_roll_no = "";
        //to 
        var to_roll_no = "";

        //sub_grp change change
        var list = $("[id*=lst_maping]");
        if ($("[id*=ddlsubgrp] :selected").text() == "--select--") {
            $("[id*=dgv_load]").empty();
            list.empty();
            list.multiselect('rebuild');
        }
        else {
            var x = document.getElementsByClassName("loader");
            x[0].style.display = "block";
            $("[id*=show]")[0].style.display = "block";
            //to fill next year option
            $.ajax({
                type: "POST",
                url: "stud_eligiblity.aspx/subgroup",
                data: '{grp_id:"' + grp_id + '"}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (r) {
                    list.empty();
                    $.each(r.d, function () {
                        if (this['Text'].endsWith('(2016)') == true || this['Text'].endsWith('2016') == true || this['Text'].endsWith('2015') == true || this['Text'].endsWith('2014') == true || this['Text'].endsWith('(OLD)') == true) {
                            list.append($("<option  ></option>").val(this['Value']).html(this['Text']));
                            $("[id*=lst_maping]").multiselect('rebuild');
                        }
                        else {
                            list.append($("<option selected='selected' ></option>").val(this['Value']).html(this['Text']));
                            $("[id*=lst_maping]").multiselect('rebuild');
                        }
                    });
                    list.append($("<option></option>").val($("[id*=ddlsubgrp]").val()).html($("[id*=ddlsubgrp] :selected")[0].innerText));
                    $("[id*=lst_maping]").multiselect('rebuild');


                    //fill grid
                    $.ajax({
                        type: "POST",
                        url: "stud_eligiblity.aspx/changesubgroup_new",
                        data: '{ayid:"' + ayid + '",group_id:"' + grp_id + '",subcourse_id:"' + sub_crs_id + '",subcrs_text:"' + sub_txt + '",stud_Id:"' + id + '",frm_rol:"",to_rol:"",to_yr:""}',
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            if (data.d.length > 0) {
                                $("[id*=divgrid]").show(1000);
                                $("[id*=dgv_load]").empty();


                                $("[id*=btn_excel]")[0].style.display = "block";

                                var thead = "<thead><tr class='alert-info'><th><div class='form-inline'><span style='padding-right:5px'><input type='checkbox' style='height:15px;width:15px' id='chkAll'/></span></div></th><th>Roll No</th><th>Student ID</th><th>Student Name</th><th>Status</th></tr></thead>"
                                if ($("[id*=ddltogroup] :selected").text().startsWith("F") == true || $("[id*=ddltogroup] :selected").text().endsWith("-I") == true || $("[id*=ddltogroup] :selected").text().endsWith(" I") == true || $("[id*=ddlsubgrp] :selected").text().endsWith("Part I") == true) {
                                    //thead += "SEM-1 CE</th><th>SEM-1 CG</th><th>SEM-1 SGPI</th><th>Sem1 KT Count</th><th>SEM-2 CE</th><th>SEM-2 CG</th><th>SEM-2 SGPI</th><th>Sem2 KT Count</th>"

                                }
                                else if ($("[id*=ddltogroup] :selected").text().startsWith("S") == true || $("[id*=ddltogroup] :selected").text().endsWith("II") == true || $("[id*=ddltogroup] :selected").text().startsWith("PHY") == true || $("[id*=ddltogroup] :selected").text().startsWith("CHEM") == true || $("[id*=ddltogroup] :selected").text().startsWith("BOT") == true) {
                                    //thead += "SEM-1 CE</th><th>SEM-1 CG</th><th>SEM-1 SGPI</th><th>Sem1 KT Count</th><th>SEM-2 CE</th><th>SEM-2 CG</th><th>SEM-2 SGPI</th><th>Sem2 KT Count</th><th>SEM-3 CE</th><th>SEM-3 CG</th><th>SEM-3 SGPI</th><th>Sem3 KT Count</th><th>SEM-4 CE</th><th>SEM-4 CG</th><th>SEM-4 SGPI</th><th>Sem4 KT Count</th>"

                                }
                                else if ($("[id*=ddltogroup] :selected").text().startsWith("T") == true) {
                                    //thead += "SEM-1 CE</th><th>SEM-1 CG</th><th>SEM-1 SGPI</th><th>Sem1 KT Count</th><th>SEM-2 CE</th><th>SEM-2 CG</th><th>SEM-2 SGPI</th><th>Sem2 KT Count</th><th>SEM-3 CE</th><th>SEM-3 CG</th><th>SEM-3 SGPI</th><th>Sem3_KT_Count</th><th>SEM-4 CE</th><th>SEM-4 CG</th><th>SEM-4 SGPI</th><th>Sem4 KT Count</th><th>SEM-5 CE</th><th>SEM-5 CG</th><th>SEM-5 SGPI</th><th>Sem5 KT Count</th><th>SEM-6 CE</th><th>SEM-6 CG</th><th>SEM-6 SGPI</th><th>Sem6 KT Count</th>"
                                }
                                else {
                                    //thead += "SEM-1 CE</th><th>SEM-1 CG</th><th>SEM-1 SGPI</th><th>Sem1 KT Count</th><th>SEM-2 CE</th><th>SEM-2 CG</th><th>SEM-2 SGPI</th><th>Sem2 KT Count</th><th>SEM-3 CE</th><th>SEM-3 CG</th><th>SEM-3 SGPI</th><th>Sem3 KT Count</th><th>SEM-4 CE</th><th>SEM-4 CG</th><th>SEM-4 SGPI</th><th>Sem4 KT Count</th><th>SEM-5 CE</th><th>SEM-5 CG</th><th>SEM-5 SGPI</th><th>Sem5 KT Count</th><th>SEM-6 CE</th><th>SEM-6 CG</th><th>SEM-6 SGPI</th><th>Sem6 KT Count</th>"
                                }
                                //thead += "";
                                $("[id*=dgv_load]").append(thead);

                                for (var i = 0; i < data.d.length; i++) {
                                    if (i == 0) {
                                        $("[id*=dgv_load]").append("<tbody>");
                                    }
                                    $("[id*=dmltype]")[0].innerText = data.d[i].type;
                                    //to insert
                                    if (data.d[i].type == "insert") {

                                        if ($("[id*=ddltogroup] :selected").text().startsWith("F") == true || $("[id*=ddltogroup] :selected").text().endsWith("-I") == true || $("[id*=ddltogroup] :selected").text().endsWith(" I") == true || $("[id*=ddlsubgrp] :selected").text().endsWith("Part I") == true) {

                                            if (data.d[i].formfilled == "1") {
                                                if (data.d[i].exist == "True") {
                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px'  checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                }
                                            }
                                            else {
                                                if (data.d[i].exist == "True") {
                                                    if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg != "") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].Status == "Not Eligible") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if ($("[id*=ddltogroup] :selected").text().startsWith("S") == true || $("[id*=ddltogroup] :selected").text().endsWith("II") == true || $("[id*=ddltogroup] :selected").text().startsWith("PHY") == true || $("[id*=ddltogroup] :selected").text().startsWith("CHEM") == true || $("[id*=ddltogroup] :selected").text().startsWith("BOT") == true) {

                                            if (data.d[i].formfilled == "1") {
                                                if (data.d[i].exist == "True") {
                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                }
                                            }
                                            else {
                                                if (data.d[i].exist == "True") {
                                                    if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg != "") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].Status == "Not Eligible") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if ($("[id*=ddltogroup] :selected").text().startsWith("T") == true) {
                                            $("[id*=lst_maping]").multiselect('rebuild');
                                            if (data.d[i].formfilled == "1") {
                                                if (data.d[i].exist == "True") {
                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                }
                                            }
                                            else {
                                                if (data.d[i].exist == "True") {
                                                    if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].Status == "Not Eligible") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else {
                                            $("[id*=lst_maping]").multiselect('rebuild');
                                            if (data.d[i].formfilled == "1") {
                                                if (data.d[i].exist == "True") {
                                                    $("[id*=dgv_load]").append("<tr><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                }
                                            }
                                            else {
                                                if (data.d[i].exist == "True") {
                                                    if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].Status == "Not Eligible") {
                                                        $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  class='form-control' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }//To update
                                    else {
                                        if ($("[id*=ddltogroup] :selected").text().startsWith("F") == true || $("[id*=ddltogroup] :selected").text().endsWith("-I") == true || $("[id*=ddltogroup] :selected").text().endsWith(" I") == true || $("[id*=ddlsubgrp] :selected").text().endsWith("Part I") == true) {

                                            if (data.d[i].formfilled == "1") {
                                                if (data.d[i].exist == "True") {
                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px'  checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                }
                                            }
                                            else {
                                                if (data.d[i].exist == "True") {
                                                    if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg != "") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' checked='true' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].Status == "Not Eligible") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  class='form-control' style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px'  id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if ($("[id*=ddltogroup] :selected").text().startsWith("S") == true || $("[id*=ddltogroup] :selected").text().endsWith("II") == true || $("[id*=ddltogroup] :selected").text().startsWith("PHY") == true || $("[id*=ddltogroup] :selected").text().startsWith("CHEM") == true || $("[id*=ddltogroup] :selected").text().startsWith("BOT") == true) {

                                            if (data.d[i].formfilled == "1") {
                                                if (data.d[i].exist == "True") {
                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                }
                                            }
                                            else {
                                                if (data.d[i].exist == "True") {
                                                    if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg != "") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].Status == "Not Eligible") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'   style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if ($("[id*=ddltogroup] :selected").text().startsWith("T") == true) {
                                            $("[id*=lst_maping]").multiselect('rebuild');
                                            if (data.d[i].formfilled == "1") {
                                                if (data.d[i].exist == "True") {
                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                }
                                            }
                                            else {
                                                if (data.d[i].exist == "True") {
                                                    if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].Status == "Not Eligible") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  class='form-control' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else {
                                            $("[id*=lst_maping]").multiselect('rebuild');
                                            if (data.d[i].formfilled == "1") {
                                                if (data.d[i].exist == "True") {
                                                    $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'   checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                }
                                            }
                                            else {
                                                if (data.d[i].exist == "True") {
                                                    if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  checked='true' style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                }
                                                else {
                                                    if (data.d[i].Status == "Not Eligible") {
                                                        $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'   style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                    }
                                                    else {
                                                        if (data.d[i].sem1_cg == "" && data.d[i].sem2_cg == "" && data.d[i].sem3_cg == "" && data.d[i].sem4_cg == "" && data.d[i].sem5_cg != "") {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                        else {
                                                            $("[id*=dgv_load]").append("<tr ><td><input type='checkbox'  style='height:20px' id='chk_single" + i + "' /></td><td>" + data.d[i].roll_no + "</td><td>" + data.d[i].studid + "</td><td>" + data.d[i].name + "</td><td>" + data.d[i].Status + "</td></tr>");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (i == data.d.length - 1) {
                                        $("[id*=dgv_load]").append("</tbody>");
                                    }
                                }
                            }
                            else {
                                $.notify("No Data Found!!", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }

                            var x = document.getElementsByClassName("loader");
                            x[0].style.display = "none";
                            $("#btn_excel").removeAttr("disabled");
                        },
                        error: function () {
                            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    });
                },
                error: function () {
                    //alert('Connection error, please retry');
                    hasError = true;
                    //$.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            });
        }

        $("[id*='ddlsubGrp']").val(grp_id);
    });

    var from_year_final = "";

    $("[id*='btnsave']").on("click", function () {
        //ddltogroup
        var map = "";
        $("[id*='lst_maping'] :selected").each(function (i, selected) {
            if (i == 0) {
                map = $(selected).val();
            }
            else {
                map += "," + $(selected).val();
            }
        });


        if ($("[id*='chk_search']").is(":checked")) {
            from_year_final = $("[id*='ddlyear']").val();
        }
        else {
            from_year_final = from_yr;
        }

        var group_id_old = $("[id*='ddltogroup']").val();
        var to_yr = $("[id*='ddltoyear']").val();

        var final_qry = "";
        var str1 = "", str = "";
        var group_id_new = map;
        var stud_id = $("#txt_search").val();
        //from roll no
        var frm_roll_no = "";
        //to 
        var to_roll_no = "";
        var subcourse = $("[id*=ddlsubgrp]").val();
        var subcourse_text = $("[id*=ddlsubgrp] :selected").text();
        if (empId != "") {
            if (validate()) {

                var tds = document.querySelectorAll('[id*=dgv_load] tbody tr');
                //update cre_stud_academic
                var status_updt_save = false;
                // var nodatacnt = 0;
                //if ($("[id*=dmltype]")[0].innerText == "insert") {
                //  var str = "insert into www_Eligibility ";
                var tds = document.querySelectorAll('[id*=dgv_load] tbody tr');
                var studArray = [];

                for (var i = 0; i < tds.length; i++) {
                    var check_id = "";
                    var un_check_id = "";
                    var tr = $(tds).eq(i).find('td')
                    //$(tr).eq(2).text()
                    // if (tr[0].parentElement.className == "alert-default") {
                    if ($("[id*='chk_single" + i + "']").prop("checked") == true) {
                        check_id = $(tr).eq(2).text();
                    }
                    else {
                        un_check_id = $(tr).eq(2).text();
                    }

                    $.ajax({
                        type: "POST",
                        url: "stud_eligiblity.aspx/check_ins_updt",
                        data: '{ayid:"' + to_yr + '",from_yr:"' + from_year_final + '",group_id:"' + group_id_old + '",subcourse_id:"' + subcourse + '",subcrs_text:"' + subcourse_text + '",stud_Id:"' + check_id + '",emp_id:"' + empId + '",to_group:"' + group_id_new + '",unchk_id:"' + un_check_id + '"}',
                        contentType: "application/json; charset=utf-8",
                        success: function (r) {
                            if (r.d == true) {
                                status_updt_save = true;
                            }
                            else {
                                status_updt_save = false;
                            }
                        }
                    });
                }
                if (status_updt_save = true) {
                    $.notify("Data Saved successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                    cleardata();
                }
                else {
                    $.notify("Error ! Error Occured , please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
        }
    });


    function cleardata() {
        //$("[id*=ddl_fromyear]")[0].selectedIndex = 0;
        $("[id*=ddltoyear]")[0].selectedIndex = 0;
        $("[id*=ddlcourse]")[0].selectedIndex = 0;
        $("[id*=ddlsubgrp]")[0].selectedIndex = 0;
        $("[id*=ddltogroup]")[0].selectedIndex = 0;
        $("[id*=show]")[0].style.display = "none";
        $("[id*=divgrid]").hide(950);
        $("[id*=dgv_load]").empty();
        $('#chk_roll').prop('checked', false); // Unchecks it
        document.getElementById('txt_search').value = '';

        $("[id*=btn_excel]")[0].style.display = "none";
        var x = document.getElementsByClassName("loader");
        x[0].style.display = "none";
        $("[id*='chk_search']")[0].checked = false;
        $("[id*=lst_maping]").multiselect("clearSelection");
        $("[id*=lst_maping]").multiselect('refresh');

        //$("[id*='ddlyear']").val(from_yr);

        $("#txt_search").attr("disabled", "disabled");
        $("#btn_IDsearch").attr("disabled", "disabled");
        $("#ddltoyear").removeAttr("disabled");
        $("#ddlcourse").removeAttr("disabled");
        $("#ddlsubgrp").removeAttr("disabled");
        $("#ddltogroup").removeAttr("disabled");
        $("#btn_get").removeAttr("disabled");
    }


    function getdate() {

    }

    $("[id*='btnreset']").on("click", function () {
        cleardata();
    });


    $("[id*='btn_excel']").on("click", function () {
        //var form = document.getElementById('dgv_load'),
        //exportForm = form.cloneNode(true),
        //elementsToRemove = exportForm.querySelectorAll('.form-control');

        //for (var i = elementsToRemove.length; i--;) {
        //    var td = elementsToRemove[i].parentElement;
        //    if (td) td.parentElement.removeChild(td);
        //}


        var tble = document.getElementById('dgv_load');

        // Getting the rows in table.
        var row = tble.rows;//[0].columns;

        // Removing the column at index(1).  
        var i = 0;
        for (var j = 0; j < row.length; j++) {

            // Deleting the ith cell of each row.
            // row[j].deleteCell(i);
            tble.rows[j].cells[i].remove();
        }

        var blobURL = tableToExcel('dgv_load', 'Eligible Student');
        $(this).attr('download', from_yr + ' Group-' + $("[id*='ddlsubgrp'] :selected").text() + '.xls')
        $(this).attr('href', blobURL);
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


    function validate() {
        if ($("[id*=ddltoyear] :selected").text() == "--Select--" || $("[id*=ddlcourse] :selected").text() == "--Select--" || $("[id*=ddlsubgrp] :selected").text() == "--Select--" || $("[id*=ddltogroup] :selected").text() == "--Select--") {
            $.notify("Please fill all details.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            return false;
        }
        else if (from_year_final == $("[id*='ddltoyear']").val()) {
            $.notify("FROM YEAR and TO YEAR cannot be same", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            return false;
        }
            //else if ($("[id*='chk_roll']").is(":checked")) {
            //    if ($("[id*=txt_from]").val() >= $("[id*=txt_to]").val()) {
            //        $.notify("From Roll no should not be lower then To Roll", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            //        return false;
            //    } else if ($("[id*=txt_from]").val() == 0 || $("[id*=txt_from]").val() == 0) {
            //        $.notify("Roll No. Cannot be Zero", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            //        return false;
            //    }

            //}
        else {
            return true;
        }
    }
});