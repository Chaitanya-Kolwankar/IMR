
$(document).ready(function () {

    $("[id*='divShow']").hide(1000);
    $("[id*='divnote']").hide(1000);
   // $("[id*='buttons']").hide(1000);

    
  //  $("[id*='divAdmission']").hide(1000);

    clear();
});

$("[id*='txtcanceldate']").on("change", function () {
    var days = daysdiff(new Date($("[id*='txtadmdate']")[0].value), new Date($("[id*='txtcanceldate']")[0].value));
    $("[id*='txtdaydiff']")[0].value = days.toString();
    $.ajax({
        type: "POST",
        url: "AdmissionCancellation.aspx/calcDeduction",
        data: '{crsid:"' + localStorage.getItem('crsid').toString() + '",totfees:"' + localStorage.getItem('totfees').toString() + '",dayspast:"' + $("[id*='txtdaydiff']")[0].value + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {


            if (response.d.length > 0) {
                var deduct = response.d[0].Deduction_percentage;
                var refund_fees = response.d[0].refund_fees;
                localStorage.setItem('refund_fees', refund_fees);

                $("[id*='deduction']")[0].innerText = 'Deduction in Percentage: ' + deduct + '%';
                $("[id*='refundamt']")[0].innerText = 'Refundable Amount: ' + refund_fees;

                $("[id*='divnote']").show(1000);
                $("[id*='buttons']").show(1000);
            }
            else {

                $.notify("No Cancellation criteria defined for the Course.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                $("[id*='buttons']").hide(1000);
            }
        },
        error: function () {
            //alert('Connection error, please retry');
            $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });
});
function daysdiff (date1, date2) {
    //Get 1 day in milliseconds
    var one_day = 1000 * 60 * 60 * 24;

    // Convert both dates to milliseconds
    var date1_ms = date1.getTime();
    var date2_ms = date2.getTime();

    // Calculate the difference in milliseconds
    var difference_ms = date2_ms - date1_ms;

    // Convert back to days and return
    return Math.round(difference_ms / one_day);
};

$("[id*='ddlreason']").on("change", function () {

    if ($("[id*='ddlreason'] :selected").text() == 'WRONG ENTRY') {
        $("[id*='divnote']").hide(1000);
    }
    else {
        $("[id*='divnote']").show(1000);
    }
});

$("[id*='btnCanceladm']").on("click", function () {
    if ($("[id*='ddlreason'] :selected").text() != "--SELECT--")
    { 
      //  $.confirm({
      //      text: "Are you sure you want to cancel Admission for student ID:" + $("[id*='txt_studid']").val() + "?",
      //confirm: function () {
          var year = localStorage.getItem('ayid').toString();
          var Group_Id = localStorage.getItem('groupid').toString();

          $.ajax({
              type: "POST",
              url: "AdmissionCancellation.aspx/StrudentFeeDetails",
              data: '{stud_id:"' + $("[id*='txt_studid']").val() + '" , year:"' + year + '",group_id:"' + Group_Id + '" }',
              async:false,
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (response) {
                  // studentmodify.stud_id = $("[id*='txt_studid']").val();
                  if (response.d.length > 0) {
                      //    feecount
                     
                      var sum = (year.substr(5, 7));
                      sum = parseInt(sum) + 1;
                  var reciptno=$("[id*='txt_studid']").val() + '/' + year.substr(5, 7) + '-' + sum + '/' + response.d[0].feecount;
                     
                      
                  $.ajax({
                      type: "POST",
                      url: "AdmissionCancellation.aspx/CancelAdmission",
                      data: '{id:"' + $("[id*='txt_studid']").val() + '" , ayid:"' + year + '",fyid:"' + localStorage.getItem('fyid').toString() + '",remark:"' + $("[id*='ddlreason'] :selected").text() + '" }',
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (response) {


                          if (response.d == true)
                          {

                              if ($("[id*='ddlreason'] :selected").text() != 'WRONG ENTRY') {
                                  var insert_query = "insert into m_FeeEntry values ('" + $("[id*='txt_studid']").val() + "'," + localStorage.getItem('refund_fees').toString() + ",'" + year + "',getdate(),'Fees','Cheque','" + reciptno + "'"
                                  insert_query += ",NULL,NULL,NULL,NULL,'Clear','Refund','Refund',NULL,'" + empId + "',getdate(),NULL,0,NULL)";
                                  $.ajax({
                                      type: "POST",
                                      url: "AdmissionCancellation.aspx/InsertFeeEntry",

                                      data: '{insert_query:"' + insert_query + '"}',
                                      contentType: "application/json; charset=utf-8",
                                      dataType: "json",
                                      success: function (response) {

                                          if (response.d == true) {
                                              clear();
                                              $("[id*='txt_studid']")[0].value = '';

                                              $.notify("ADMISSION CANCELLED SUCCESSFULLY!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                                          }
                                      }
                                  });
                              }
                              else {
                                  clear();
                                  $("[id*='txt_studid']")[0].value = '';

                                  $.notify("ADMISSION CANCELLED SUCCESSFULLY!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                              }
                          }
                      }
                  });
                  }
              }
          });
        //    },
        //    cancel: function () {
         
        //    }
        //});
    }
    else {
        $.notify("Error ! Select reason for admission cancellation", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

    }
});

$("[id*='btn_search']").on("click", function () {

    if ($("[id*='txt_studid']").val() != '') {
        clear();
        $.ajax({
            type: "POST",
            url: "AdmissionCancellation.aspx/searchsCanceltudent",
            data: '{id:"' + $("[id*='txt_studid']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {


                if (response.d.length > 0) {


                    localStorage.setItem('crsid', response.d[0].Course_id);
                    localStorage.setItem('totfees', response.d[0].course_tot_fees);
                    localStorage.setItem('ayid', response.d[0].ayid);
                    localStorage.setItem('groupid', response.d[0].group_id);
                    localStorage.setItem('fyid', response.d[0].fyid);

                    $("[id*='lblstudname']")[0].innerText = response.d[0].stud_name;
                    //$("[id*='lblfaculty']")[0].innerText =response.d[0].faculty_name;
                    //$("[id*='lblcourse']")[0].innerText = response.d[0].course_name;

                    $("[id*='lblsubcourse']")[0].innerText = response.d[0].subcourse_name;
                    $("[id*='lblgroup']")[0].innerText = response.d[0].group_title;

                    $("[id*='lblcourseamt']")[0].innerText = response.d[0].course_tot_fees;
                    $("[id*='lblpaidamt']")[0].innerText = response.d[0].course_fee_paid;
                    $("[id*='txtadmdate']")[0].value = response.d[0].admission_date;
                    $("[id*='lblfeesstatus']")[0].innerText = response.d[0].feesstatus;

                    $("[id*='divShow']").show(1000);
                    // $("[id*='divAdmission']").show(1000);
                }
                else {
                    clear();
                    $("[id*='txt_studid']")[0].value = '';

                    $("[id*='divShow']").hide(1000);
                    //$.notify("Error ! No Data Found.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $.notify("Admission already cancelled", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

                }
            },
            error: function () {
                //alert('Connection error, please retry');
                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });
    }
    else {

        $.notify("Student ID is Missing.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

    }

});

$("[id*='btnClear']").on("click", function () {

    clear();
    $("[id*='txt_studid']")[0].value = '';


});

function clear()
{
    $("[id*='lblstudname']")[0].innerText = '';
   
    $("[id*='txtadmdate']")[0].value = '';
    $("[id*='txtcanceldate']")[0].value = '';
    $("[id*='txtdaydiff']")[0].value = '';

    $("[id*='lblfeesstatus']")[0].innerText ='';
    $("[id*='lblsubcourse']")[0].innerText = '';
    $("[id*='lblgroup']")[0].innerText = '';

    $("[id*='lblcourseamt']")[0].innerText = '';
    $("[id*='lblpaidamt']")[0].innerText = '';
    $("[id*='divShow']").hide(1000);
    $("[id*='divShow']").hide(1000);
    $("[id*='divnote']").hide(1000);
    $("[id*='deduction']")[0].innerText ='';
    $("[id*='refundamt']")[0].innerText = '';
    $("[id*='ddlreason']")[0].selectedIndex = 0;
    $("[id*='divnote']").hide(1000);
    $("[id*='buttons']").hide(1000);
    localStorage.clear();
    
};