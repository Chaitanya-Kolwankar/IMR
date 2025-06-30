
$('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
    clear();
    adv_clear();
    localStorage.setItem('activeTab', $(e.target).attr('href'));
});


var activeTab = localStorage.getItem('activeTab');


$(document).ready(function () {
    document.getElementById("txtTitle").disabled = true;
    document.getElementById("txtAuthor").disabled = true;
    document.getElementById("txtPublisher").disabled = true;
    clear();
    adv_clear();

    console.log(activeTab);
    if (activeTab) {
        clear();
        adv_clear();
        $('a[href="' + activeTab + '"]').tab('show');
    }
   
    var x = document.getElementsByClassName("loader");
    x[0].style.display = "none";
    var y = document.getElementById("loadss");
    y.style.display = "none";
});

$("[id*='btn_cancel']").on("click", function () {

    $('#searchModal').modal('hide');

});

$("[id*='btn_cancel1']").on("click", function () {

    $('#Advance_searchModal_1').modal('hide');

});

$("[id*='btnclose']").on("click", function () {

    $('#searchModal').modal('hide');
});

$("[id*='btnclose1']").on("click", function () {

    $('#Advance_searchModal_1').modal('hide');
});


$(window).load(function () {
    $('.loader').fadeOut();
});

$("[id*=ddl_selectcat]").change(function () {
    if ($("[id*='ddl_selectcat'] :selected").text() == "Book") {

        var select = document.getElementById("ddl_search");
        var option = document.createElement('option');
        option.text = option.value = "Accession No";
        select.remove(6);
        select.add(option, 6);
    }
    else {

        var x = document.getElementById("ddl_search");
        x.remove(6);
    }

});


$("[id*=keyword1]").change(function () {
    if ($("[id*='keyword1'] :selected").text() == "--Keyword--") {
        $("[id*='txtTitle']").val("");
        document.getElementById("txtTitle").disabled = true;
       
    }
    else {
        
        $("[id*='txtTitle']").val("");
        document.getElementById("txtTitle").disabled = false;
        $("[id*=ddl_selectcat]")[0].selectedIndex = 0;
    }
});


$("[id*=keyword2]").change(function () {
    if ($("[id*='keyword2'] :selected").text() == "--Keyword--") {
        $("[id*='txtAuthor']").val("");

        document.getElementById("txtAuthor").disabled = true;
        document.getElementById('rdbAND').checked = false
        document.getElementById('rdbOR').checked = false
        document.getElementById('rdbNOT').checked = false
       
    }
    else {
        $("[id*='txtAuthor']").val("");
        document.getElementById("txtAuthor").disabled = false;
        $("[id*=ddl_selectcat]")[0].selectedIndex = 0;
    }

});

$("[id*=keyword3]").change(function () {
    if ($("[id*='keyword3'] :selected").text() == "--Keyword--") {
        $("[id*='txtPublisher']").val("");
        document.getElementById("txtPublisher").disabled = true;
        document.getElementById('rdbAND1').checked = false
        document.getElementById('rdbOR1').checked = false
        document.getElementById('rdbNOT1').checked = false
       
    }
    else {
       
        $("[id*='txtPublisher']").val("");
        document.getElementById("txtPublisher").disabled = false;
        $("[id*=ddl_selectcat]")[0].selectedIndex = 0;
    }

});


$("[id*='brn_refresh']").on("click", function () {

    $("#ddl_selectcat").val('--Select--');
    $("#ddl_search").val('--Select--');
    $("#ddlselect").val('--Select--');
    $("[id*='TBL_BK_SR']").hide();
    $("[id*='Text1']").val('');
    clear();

});

$("[id*='btnSave']").on("click", function () {

    var cat_val = "";
    //if (e.which == 13) 
    {
        var x = document.getElementsByClassName("loader");
        x[0].style.display = "block";
        if ($("[id*='ddl_selectcat']").val() == "Book") {
            cat_val = "Book";
        }
        else if ($("[id*='ddl_selectcat']").val() == "CD") { }
        else if ($("[id*='ddl_selectcat']").val() == "Map") { }
        else if ($("[id*='ddl_selectcat']").val() == "Periodical") { }
        //else if(){}
        if ($("[id*='ddl_search']").val() == "Title") {


            if ($("[id*='ddl_selectcat']").val() == "Book") {
                book_search(cat_val, $("[id*='Text1']").val(), '', '', '', '','');
            }
            else if ($("[id*='ddl_selectcat']").val() == "CD") {
                CD_search(cat_val, $("[id*='Text1']").val(), '', '', '', '');
            }
            else if ($("[id*='ddl_selectcat']").val() == "Map") {
                Map_search(cat_val, $("[id*='Text1']").val(), '', '', '', '');
            }
            //   else if ($("[id*='ddl_selectcat']").val() == "Periodical") { }
        }
        else if ($("[id*='ddl_search']").val() == "Author") {
            if ($("[id*='ddl_selectcat']").val() == "Book") {
                book_search(cat_val, '', $("[id*='Text1']").val(), '', '', '','');
            }
            else if ($("[id*='ddl_selectcat']").val() == "CD") {
                CD_search(cat_val, '', $("[id*='Text1']").val(), '', '', '');
            }
            else if ($("[id*='ddl_selectcat']").val() == "Map") {
                Map_search(cat_val, '', $("[id*='Text1']").val(), '', '', '');
            }

        }
        else if ($("[id*='ddl_search']").val() == "Publisher") {
            if ($("[id*='ddl_selectcat']").val() == "Book") {
                book_search(cat_val, '', '', $("[id*='Text1']").val(), '', '','');
            }
            else if ($("[id*='ddl_selectcat']").val() == "CD") {
                CD_search(cat_val, '', '', $("[id*='Text1']").val(), '', '');
            }
            else if ($("[id*='ddl_selectcat']").val() == "Map") {
                Map_search(cat_val, '', '', $("[id*='Text1']").val(), '', '');
            }



        }
        else if ($("[id*='ddl_search']").val() == "Keywords") {
            if ($("[id*='ddl_selectcat']").val() == "Book") {
                book_search(cat_val, '', '', '', $("[id*='Text1']").val(), '','');
            }
            else if ($("[id*='ddl_selectcat']").val() == "CD") {
                CD_search(cat_val, '', '', '', $("[id*='Text1']").val(), '');
            }
            else if ($("[id*='ddl_selectcat']").val() == "Map") {
                Map_search(cat_val, '', '', '', $("[id*='Text1']").val(), '');
            }



        }
        else if ($("[id*='ddl_search']").val() == "ISBN No") {
            if ($("[id*='ddl_selectcat']").val() == "Book") {
                book_search(cat_val, '', '', '', '', $("[id*='Text1']").val(),'');
            }
            else if ($("[id*='ddl_selectcat']").val() == "CD") {
                CD_search(cat_val, '', '', '', '', $("[id*='Text1']").val());
            }
            else if ($("[id*='ddl_selectcat']").val() == "Map") {
                Map_search(cat_val, '', '', '', '', $("[id*='Text1']").val());
            }

        }
        else if ($("[id*='ddl_search']").val() == "Accession No") {
            if ($("[id*='ddl_selectcat']").val() == "Book") {
                book_search(cat_val, '', '', '', '','',$("[id*='Text1']").val());
            }
        }


        return false;
    }
});

function book_search(val, title, author, publisher, keyword, isbn,acc_no) {

    $.ajax({
        type: "POST",
        url: "book_search.aspx/book_sear",
        contentType: "application/json; charset=utf-8",
        data: '{book_name:"' + title + '",author:"' + author + '",publisher:"' + publisher + '",keyword:"' + keyword + '",isbn:"' + isbn + '",acc_no:"' + acc_no + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
        // data: '{type:"' + $("[id*='ddl_selectcat']").val() + '",title:"' + $("[id*='Text1']").val() + '"}',
        //  async: false,
        success: function (data) {
            $("[id*=TBL_BK_SR]")[0].innerHTML = "";
            if (data.d.length > 0) {
                $("[id*=TBL_BK_SR]").append("<thead><tr></tr><tr class='alert-info'><th style='display:none'><center>ACCESSION NO</center></th><th ><center>AUTHOR</center></th><th ><center>TITLE</center></th><th ><center>CALLNO</center></th><th ><center>PUBLISHER</center></th><th ><center>YEAR</center></th><th ><center>KEYWORD</center></th><th ><center>ISBN No.</center></th><th ><center>LANGUAGE</center></th><th ><center>Book Count</center></th><th style='display:none'><center>Issued Books</center></th><th style='display:none'><center>Avaiable</center></th><th></th></tr></thead>");//<th ><center>ACCOMMANING MATERIALS</center></th><th ><center>SUBJECTS</center></th><th ><center>REMARK</center></th><th ><center>BILL NO</center></th><th ><center>BILL DATE</center></th><th ><center>MRP</center></th><th ><center>DISCOUNT</center></th><th ><center>PRICE</center></th><th ><center>VENDOR</center></th><th ><center>REGISTRATION DATE</center></th><th ><center>DONOR</center></th></tr></thead>");
                for (var i = 0; i < data.d.length; i++) {
                    if (i == 0) {
                        $("[id*=TBL_BK_SR]").append("<tbody>");
                    }
                    var count = data.d[i].ACCESSION_NO.split(",");
                    //$("[id*=TBL_BK_SR]").append("<tr></tr><tr class='alert-info'><th ><center>'"+data.d[i].TITLE+"'</center></th><th ><center>'"+data.d[i].AUTHOR+"'</center></th><th ><center>'"+data.d[i].ISBN+"'</center></th><th ><center>'"+data.d[i].LANG+"'</center></th><th ><center>'"+data.d[i].KEYWORD+"'</center></th><th ><center>'"+data.d[i].PUBLISHER+"'</center></th><th ><center>'"+data.d[i].YEAR+"'</center></th><th ><center>'"+data.d[i].CALLNO+"'</center></th><th ><center>'"+data.d[i].ACC_MATERIALS+"'</center></th><th ><center>'"+data.d[i].SUBJ+"'</center></th><th ><center>'"+data.d[i].REMARK+"'</center></th><th ><center>'"+data.d[i].ACCESSION_NO+"'</center></th><th ><center>'"+data.d[i].BILL_NO+"'</center></th><th ><center>'"+data.d[i].BILL_Dt+"'</center></th><th ><center>'"+data.d[i].MRP+"'</center></th><th ><center>'"+data.d[i].DISCOUNT+"'</center></th><th ><center>'"+data.d[i].PRICE+"'</center></th><th ><center>'"+data.d[i].VENDOR+"'</center></th><th ><center>'"+data.d[i].REG_DT+"'</center></th><th ><center>'"+data.d[i].DONOR+"'</center></th></tr>");
                    $("[id*=TBL_BK_SR]").append("<tr></tr><tr><td style='display:none' ><center>" + data.d[i].ACCESSION_NO + "</center></td><td ><center>" + data.d[i].AUTHOR + "</center></td><td ><center>" + data.d[i].TITLE + "</center></td><td ><center>" + data.d[i].CALLNO + "</center></td><td ><center>" + data.d[i].PUBLISHER + "</center></td><td ><center>" + data.d[i].YEAR + "</center></td><td ><center>" + data.d[i].KEYWORD + "</center></td><td ><center>" + data.d[i].ISBN + "</center></td><td ><center>" + data.d[i].LANG + "</center></td><td ><center>" + count.length + "</center></td><td style='display:none'><center>" + data.d[i].issued + "</center></td><td style='display:none'><center>" + data.d[i].available + "</center></td><td style='display:none'><center>" + data.d[i].REMARK + "</center></td><td style='display:none'><center>" + data.d[i].ISSUE_TYPE + "</center></td><td style='display:none'><center>" + data.d[i].SUBJ + "</center></td><td style='display:none'><center>" + data.d[i].REG_DT + "</center></td><td><a href='#' class='Select' style='color:blue'>Details</a></td></tr>");//<td ><center>" + data.d[i].ACC_MATERIALS + "</center></td><td ><center>" + data.d[i].SUBJ + "</center></td><td ><center>" + data.d[i].REMARK + "</center></td><td ><center>" + data.d[i].BILL_NO + "</center></td><td ><center>" + data.d[i].BILL_DT + "</center></td><td ><center>" + data.d[i].MRP + "</center></td><td ><center>" + data.d[i].DISCOUNT + "</center></td><td ><center>" + data.d[i].PRICE + "</center></td><td ><center>" + data.d[i].VENDOR + "</center></td><td ><center>" + data.d[i].REG_DT + "</center></td><td ><center>" + data.d[i].DONOR_ID + "</center></td></tr>");

                    if (i == data.d.length - 1) {
                        $("[id*=TBL_BK_SR]").append("</tbody>");
                    }
                }

                var x = document.getElementsByClassName("loader");
                x[0].style.display = "none";

               // document.getElementById('divhideshow').style.display = "block";
                $("[id*='lb']")[0].innerText = "(" + data.d.length + ")";

            }
            else {
                $.notify("No Data Found.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

            }
        },
        error: function () {

        }
    });
    //  return false;
}
function CD_search(val, title, author, publisher, keyword, isbn) {



    $.ajax({
        type: "POST",
        url: "book_search.aspx/CD_search",
        contentType: "application/json; charset=utf-8",
        data: '{book_name:"' + title + '",author:"' + author + '",publisher:"' + publisher + '",keyword:"' + keyword + '",isbn:"' + isbn + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
        // data: '{type:"' + $("[id*='ddl_selectcat']").val() + '",title:"' + $("[id*='Text1']").val() + '"}',
        //  async: false,
        success: function (data) {
            $("[id*=Table1]")[0].innerHTML = "";
            if (data.d.length > 0) {
                $("[id*=Table1]").append("<thead><tr></tr><tr class='alert-info'><th style='display:none'><center>ACCESSION NO</center></th><th ><center>AUTHOR</center></th><th ><center>TITLE</center></th><th ><center>CALLNO</center></th><th ><center>PUBLISHER</center></th><th ><center>YEAR</center></th><th ><center>KEYWORD</center></th><th ><center>ISBN No.</center></th><th ><center>LANGUAGE</center></th><th ><center>Book Count</center></th><th style='display:none'><center>Issued Books</center></th><th style='display:none'><center>Avaiable</center></th><th></th></tr></thead>");//<th ><center>ACCOMMANING MATERIALS</center></th><th ><center>SUBJECTS</center></th><th ><center>REMARK</center></th><th ><center>BILL NO</center></th><th ><center>BILL DATE</center></th><th ><center>MRP</center></th><th ><center>DISCOUNT</center></th><th ><center>PRICE</center></th><th ><center>VENDOR</center></th><th ><center>REGISTRATION DATE</center></th><th ><center>DONOR</center></th></tr></thead>");
                for (var i = 0; i < data.d.length; i++) {
                    if (i == 0) {
                        $("[id*=Table1]").append("<tbody>");
                    }
                    var count = data.d[i].ACCESSION_NO.split(",");
                    //$("[id*=TBL_BK_SR]").append("<tr></tr><tr class='alert-info'><th ><center>'"+data.d[i].TITLE+"'</center></th><th ><center>'"+data.d[i].AUTHOR+"'</center></th><th ><center>'"+data.d[i].ISBN+"'</center></th><th ><center>'"+data.d[i].LANG+"'</center></th><th ><center>'"+data.d[i].KEYWORD+"'</center></th><th ><center>'"+data.d[i].PUBLISHER+"'</center></th><th ><center>'"+data.d[i].YEAR+"'</center></th><th ><center>'"+data.d[i].CALLNO+"'</center></th><th ><center>'"+data.d[i].ACC_MATERIALS+"'</center></th><th ><center>'"+data.d[i].SUBJ+"'</center></th><th ><center>'"+data.d[i].REMARK+"'</center></th><th ><center>'"+data.d[i].ACCESSION_NO+"'</center></th><th ><center>'"+data.d[i].BILL_NO+"'</center></th><th ><center>'"+data.d[i].BILL_Dt+"'</center></th><th ><center>'"+data.d[i].MRP+"'</center></th><th ><center>'"+data.d[i].DISCOUNT+"'</center></th><th ><center>'"+data.d[i].PRICE+"'</center></th><th ><center>'"+data.d[i].VENDOR+"'</center></th><th ><center>'"+data.d[i].REG_DT+"'</center></th><th ><center>'"+data.d[i].DONOR+"'</center></th></tr>");
                    $("[id*=Table1]").append("<tr></tr><tr><td style='display:none' ><center>" + data.d[i].ACCESSION_NO + "</center></td><td ><center>" + data.d[i].AUTHOR + "</center></td><td ><center>" + data.d[i].TITLE + "</center></td><td ><center>" + data.d[i].CALLNO + "</center></td><td ><center>" + data.d[i].PUBLISHER + "</center></td><td ><center>" + data.d[i].YEAR + "</center></td><td ><center>" + data.d[i].KEYWORD + "</center></td><td ><center>" + data.d[i].ISBN + "</center></td><td ><center>" + data.d[i].LANG + "</center></td><td ><center>" + count.length + "</center></td><td style='display:none'><center>" + data.d[i].issued + "</center></td><td style='display:none'><center>" + data.d[i].available + "</center></td><td><a href='#' class='Select' style='color:blue'>Details</a></td></tr>");//<td ><center>" + data.d[i].ACC_MATERIALS + "</center></td><td ><center>" + data.d[i].SUBJ + "</center></td><td ><center>" + data.d[i].REMARK + "</center></td><td ><center>" + data.d[i].BILL_NO + "</center></td><td ><center>" + data.d[i].BILL_DT + "</center></td><td ><center>" + data.d[i].MRP + "</center></td><td ><center>" + data.d[i].DISCOUNT + "</center></td><td ><center>" + data.d[i].PRICE + "</center></td><td ><center>" + data.d[i].VENDOR + "</center></td><td ><center>" + data.d[i].REG_DT + "</center></td><td ><center>" + data.d[i].DONOR_ID + "</center></td></tr>");

                    if (i == data.d.length - 1) {
                        $("[id*=Table1]").append("</tbody>");
                    }
                }

                var x = document.getElementsByClassName("loader");
                x[0].style.display = "none";

                document.getElementById('div2').style.display = "block";
                $("[id*='Label1']")[0].innerText = "(" + data.d.length + ")";
            }
            else {
                $.notify("No Data Found.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

            }
        },
        error: function () {

        }
    });
    //  return false;
}
function Map_search(val, title, author, publisher, keyword, isbn) {

    $.ajax({
        type: "POST",
        url: "book_search.aspx/Map_search",
        contentType: "application/json; charset=utf-8",
        data: '{book_name:"' + title + '",author:"' + author + '",publisher:"' + publisher + '",keyword:"' + keyword + '",isbn:"' + isbn + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
        // data: '{type:"' + $("[id*='ddl_selectcat']").val() + '",title:"' + $("[id*='Text1']").val() + '"}',
        //  async: false,
        success: function (data) {
            $("[id*=Table2]")[0].innerHTML = "";
            if (data.d.length > 0) {
                $("[id*=Table2]").append("<thead><tr></tr><tr class='alert-info'><th style='display:none'><center>ACCESSION NO</center></th><th ><center>AUTHOR</center></th><th ><center>TITLE</center></th><th ><center>CALLNO</center></th><th ><center>PUBLISHER</center></th><th ><center>YEAR</center></th><th ><center>KEYWORD</center></th><th ><center>ISBN No.</center></th><th ><center>LANGUAGE</center></th><th ><center>Book Count</center></th><th style='display:none'><center>Issued Books</center></th><th style='display:none'><center>Avaiable</center></th><th></th></tr></thead>");//<th ><center>ACCOMMANING MATERIALS</center></th><th ><center>SUBJECTS</center></th><th ><center>REMARK</center></th><th ><center>BILL NO</center></th><th ><center>BILL DATE</center></th><th ><center>MRP</center></th><th ><center>DISCOUNT</center></th><th ><center>PRICE</center></th><th ><center>VENDOR</center></th><th ><center>REGISTRATION DATE</center></th><th ><center>DONOR</center></th></tr></thead>");
                for (var i = 0; i < data.d.length; i++) {
                    if (i == 0) {
                        $("[id*=Table2]").append("<tbody>");
                    }
                    var count = data.d[i].ACCESSION_NO.split(",");
                    //$("[id*=TBL_BK_SR]").append("<tr></tr><tr class='alert-info'><th ><center>'"+data.d[i].TITLE+"'</center></th><th ><center>'"+data.d[i].AUTHOR+"'</center></th><th ><center>'"+data.d[i].ISBN+"'</center></th><th ><center>'"+data.d[i].LANG+"'</center></th><th ><center>'"+data.d[i].KEYWORD+"'</center></th><th ><center>'"+data.d[i].PUBLISHER+"'</center></th><th ><center>'"+data.d[i].YEAR+"'</center></th><th ><center>'"+data.d[i].CALLNO+"'</center></th><th ><center>'"+data.d[i].ACC_MATERIALS+"'</center></th><th ><center>'"+data.d[i].SUBJ+"'</center></th><th ><center>'"+data.d[i].REMARK+"'</center></th><th ><center>'"+data.d[i].ACCESSION_NO+"'</center></th><th ><center>'"+data.d[i].BILL_NO+"'</center></th><th ><center>'"+data.d[i].BILL_Dt+"'</center></th><th ><center>'"+data.d[i].MRP+"'</center></th><th ><center>'"+data.d[i].DISCOUNT+"'</center></th><th ><center>'"+data.d[i].PRICE+"'</center></th><th ><center>'"+data.d[i].VENDOR+"'</center></th><th ><center>'"+data.d[i].REG_DT+"'</center></th><th ><center>'"+data.d[i].DONOR+"'</center></th></tr>");
                    $("[id*=Table2]").append("<tr></tr><tr><td style='display:none' ><center>" + data.d[i].ACCESSION_NO + "</center></td><td ><center>" + data.d[i].AUTHOR + "</center></td><td ><center>" + data.d[i].TITLE + "</center></td><td ><center>" + data.d[i].CALLNO + "</center></td><td ><center>" + data.d[i].PUBLISHER + "</center></td><td ><center>" + data.d[i].YEAR + "</center></td><td ><center>" + data.d[i].KEYWORD + "</center></td><td ><center>" + data.d[i].ISBN + "</center></td><td ><center>" + data.d[i].LANG + "</center></td><td ><center>" + count.length + "</center></td><td style='display:none'><center>" + data.d[i].issued + "</center></td><td style='display:none'><center>" + data.d[i].available + "</center></td><td><a href='#' class='Select' style='color:blue'>Details</a></td></tr>");//<td ><center>" + data.d[i].ACC_MATERIALS + "</center></td><td ><center>" + data.d[i].SUBJ + "</center></td><td ><center>" + data.d[i].REMARK + "</center></td><td ><center>" + data.d[i].BILL_NO + "</center></td><td ><center>" + data.d[i].BILL_DT + "</center></td><td ><center>" + data.d[i].MRP + "</center></td><td ><center>" + data.d[i].DISCOUNT + "</center></td><td ><center>" + data.d[i].PRICE + "</center></td><td ><center>" + data.d[i].VENDOR + "</center></td><td ><center>" + data.d[i].REG_DT + "</center></td><td ><center>" + data.d[i].DONOR_ID + "</center></td></tr>");

                    if (i == data.d.length - 1) {
                        $("[id*=Table2]").append("</tbody>");
                    }
                }

                var x = document.getElementsByClassName("loader");
                x[0].style.display = "none";

                //document.getElementById('div3').style.display = "block";
                $("[id*='Label2']")[0].innerText = "(" + data.d.length + ")";

            }
            else {
                $.notify("No Data Found.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

            }
        },
        error: function () {

        }
    });
    //  return false;
}
$("[id*=TBL_BK_SR]").on('click', 'td a.Select', function () {

    // $("[id*=Div3]").modal('show');
    var $td = $(this).closest('tr').children('td');
    var count = $td.eq(0).text().split(",");
    //var b3 = imageExists("Library/Book/"+ count[0] +".jpg");
    $.ajax(
      {
          url: "Library/Book/" + count[0].trim() + ".jpg",
          success: function (data) {
              document.getElementById("img1").src = "Library/Book/" + count[0].trim() + ".jpg";
          },
          error: function (data) {
              document.getElementById("img1").src = " images/book_open.png";
          }
      });
    //if (b3 == true) {
   
    //  }
    document.getElementById('txtbooktitle').innerText = $td.eq(2).text();
    document.getElementById('txtauthor').innerText = $td.eq(1).text();
    document.getElementById('txtpublication').innerText = $td.eq(4).text();
    document.getElementById('txtdescription').innerText = $td.eq(0).text();
    document.getElementById('txtkeywords').innerText = $td.eq(6).text();
    document.getElementById('txtcount').innerText = $td.eq(9).text();
    document.getElementById('txtissuedbook').innerText = $td.eq(10).text();
    document.getElementById('txtavailablebook').innerText = $td.eq(11).text();
    document.getElementById('txtwithdraw').innerText = $td.eq(12).text();
    document.getElementById('txtmissing').innerText = $td.eq(13).text();
    document.getElementById('txtWid').innerText = $td.eq(14).text();
    document.getElementById('txtMisAcc').innerText = $td.eq(15).text();
    ////$("[id*=txtauthor]").val($td.eq(1).text());
    ////$("[id*=txtpublication]").val($td.eq(4).text());
    ////$("[id*=txtdescription]").val($td.eq(0).text());
    ////$("[id*=txtkeywords]").val($td.eq(6).text());
    ////$("[id*=txtcount]").val($td.eq(9).text());


    $('#searchModal').modal("show");
});
$("[id*=Table1]").on('click', 'td a.Select', function () {

    // $("[id*=Div3]").modal('show');
    var $td = $(this).closest('tr').children('td');
    var count = $td.eq(0).text().split(",");
    //var b3 = imageExists("Library/Book/"+ count[0] +".jpg");

    //if (b3 == true) {
    $.ajax(
    {
        url: "Library/CD/" + count[0].trim() + ".jpg",
        success: function (data) {
            document.getElementById("img1").src = "Library/CD/" + count[0].trim() + ".jpg";
        },
        error: function (data) {
            document.getElementById("img1").src = " images/cd.png";
        }
    });
   
    //  }
    document.getElementById('txtbooktitle').innerText = $td.eq(2).text();
    document.getElementById('txtauthor').innerText = $td.eq(1).text();
    document.getElementById('txtpublication').innerText = $td.eq(4).text();
    document.getElementById('txtdescription').innerText = $td.eq(0).text();
    document.getElementById('txtkeywords').innerText = $td.eq(6).text();
    document.getElementById('txtcount').innerText = $td.eq(9).text();
    document.getElementById('txtissuedbook').innerText = $td.eq(10).text();
    document.getElementById('txtavailablebook').innerText = $td.eq(11).text();
    ////$("[id*=txtauthor]").val($td.eq(1).text());
    ////$("[id*=txtpublication]").val($td.eq(4).text());
    ////$("[id*=txtdescription]").val($td.eq(0).text());
    ////$("[id*=txtkeywords]").val($td.eq(6).text());
    ////$("[id*=txtcount]").val($td.eq(9).text());


    $('#searchModal').modal("show");
});
$("[id*=Table2]").on('click', 'td a.Select', function () {

    // $("[id*=Div3]").modal('show');
    var $td = $(this).closest('tr').children('td');
    var count = $td.eq(0).text().split(",");
    //var b3 = imageExists("Library/Book/"+ count[0] +".jpg");

    //if (b3 == true) {
    $.ajax(
   {
       url: "Library/Map/" + count[0].trim() + ".jpg",
       success: function (data) {
           document.getElementById("img1").src = "Library/Map/" + count[0].trim() + ".jpg";
       },
       error: function (data) {
           document.getElementById("img1").src = " images/map.png";
       }
   });

  
    //  }
    document.getElementById('txtbooktitle').innerText = $td.eq(2).text();
    document.getElementById('txtauthor').innerText = $td.eq(1).text();
    document.getElementById('txtpublication').innerText = $td.eq(4).text();
    document.getElementById('txtdescription').innerText = $td.eq(0).text();
    document.getElementById('txtkeywords').innerText = $td.eq(6).text();
    document.getElementById('txtcount').innerText = $td.eq(9).text();
    document.getElementById('txtissuedbook').innerText = $td.eq(10).text();
    document.getElementById('txtavailablebook').innerText = $td.eq(11).text();
    ////$("[id*=txtauthor]").val($td.eq(1).text());
    ////$("[id*=txtpublication]").val($td.eq(4).text());
    ////$("[id*=txtdescription]").val($td.eq(0).text());
    ////$("[id*=txtkeywords]").val($td.eq(6).text());
    ////$("[id*=txtcount]").val($td.eq(9).text());


    $('#searchModal').modal("show");
});
function clear() {
    document.getElementById('div2').style.display = "none";
    document.getElementById('div2').style.display = "none";
    $("[id*='Label1']")[0].innerText = "";
    //document.getElementById('div3').style.display = "none";
    $("[id*='Label2']")[0].innerText = "";
    document.getElementById('divhideshow').style.display = "none";
    $("[id*='lb']")[0].innerText = "";
    $("[id*=divhideshow]").hide();
    $("[id*=TBL_BK_SR]").empty();
    $("[id*=Table1]").empty();
    $("[id*=ddl_selectcat]")[0].selectedIndex = 0;
    $("[id*=ddl_search]")[0].selectedIndex = 0;
    $("[id*='Text1']").val("");
    var x = document.getElementsByClassName("loader");
    x[0].style.display = "none";
    var y = document.getElementById("loadss");
    y.style.display = "none";

}


$("[id*='Search']").on("click", function () {
   

    document.getElementById('div2_HH').style.display = "none";
    document.getElementById('div2_HH').style.display = "none";
    $("[id*='Label1_ADV']")[0].innerText = "";
    //document.getElementById('div3').style.display = "none";
    $("[id*='Label2_ADV']")[0].innerText = "";
    document.getElementById('divhideshow_ADV').style.display = "none";
    $("[id*='lbA']")[0].innerText = "";
    $("[id*=divhideshow_ADV]").hide();
    $("[id*=ADV_BOOK_T]").empty();
    $("[id*=Table1_ADV]").empty();

    var query = "", flagKey1 = "", flagKey2 = "", flagKey3 = "", flagLogic = "", flagLogic1 = "", type = "";

    if ($("[id*=DDL_CAT]")[0].selectedIndex == 0) {
        $.notify("Fill All Details.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

    }
    else {

        if ($("[id*=keyword1]")[0].selectedIndex == 0 && $("[id*=keyword2]")[0].selectedIndex == 0 && $("[id*=keyword3]")[0].selectedIndex == 0) {

            $.notify("Fill All Details.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
        else {

          
            if ($("[id*=keyword1]")[0].selectedIndex == 1) {
                if (txtTitle.Text != "") {
                    flagKey1 = "title";
                }
                else {
                    $("[id*=keyword2]")[0].selectedIndex = 0;
                }
            }
            else if ($("[id*=keyword1]")[0].selectedIndex == 2) {
                if ($("[id*='txtTitle']").val() != "") {
                    flagKey1 = "author";
                }
                else {
                    $("[id*=keyword2]")[0].selectedIndex = 0;
                }
            }
            else if ($("[id*=keyword1]")[0].selectedIndex == 3) {
                if ($("[id*='txtTitle']").val() != "") {
                    flagKey1 = "PUBLISHER";
                }
                else {
                    $("[id*=keyword2]")[0].selectedIndex = 0;
                }

            }
            else {
                flagKey1 = "";
            }

            if ($("[id*=keyword2]")[0].selectedIndex == 1) {
                if ($("[id*='txtAuthor']").val() != "") {
                    flagKey2 = "TITLE";
                }
                else {
                    $("[id*=keyword3]")[0].selectedIndex = 0;
                }

            }
            else if ($("[id*=keyword2]")[0].selectedIndex == 2) {
                if ($("[id*='txtAuthor']").val() != "") {
                    flagKey2 = "AUTHOR";
                }
                else {
                    $("[id*=keyword3]")[0].selectedIndex = 0;
                }

            }
            else if ($("[id*=keyword2]")[0].selectedIndex == 3) {
                if ($("[id*='txtAuthor']").val() != "") {
                    flagKey2 = "PUBLISHER";
                }
                else {
                    $("[id*=keyword3]")[0].selectedIndex = 0;
                }

            }
            else if ($("[id*=keyword2]")[0].selectedIndex == 4) {
                if ($("[id*='txtAuthor']").val() != "") {
                    flagKey2 = "EDITION";
                }
                else {
                    $("[id*=keyword3]")[0].selectedIndex = 0;
                }

            }
            else if ($("[id*=keyword2]")[0].selectedIndex == 5) {
                if ($("[id*='txtAuthor']").val() != "") {
                    flagKey2 = "ISBN";
                }
                else {
                    $("[id*=keyword3]")[0].selectedIndex = 0;
                }

            }
            else {
                flagKey2 = "";
            }

            if ($("[id*=keyword3]")[0].selectedIndex == 1 && $("[id*='txtPublisher']").val() != "") {
                flagKey3 = "title";
            }
            else if ($("[id*=keyword3]")[0].selectedIndex == 2 && $("[id*='txtPublisher']").val() != "") {
                flagKey3 = "author";
            }
            else if ($("[id*=keyword3]")[0].selectedIndex == 3 && $("[id*='txtPublisher']").val() != "") {
                flagKey3 = "PUBLISHER";
            }
            else if ($("[id*=keyword3]")[0].selectedIndex == 4 && $("[id*='txtPublisher']").val() != "") {
                flagKey3 = "edition";
            }
            else if ($("[id*=keyword3]")[0].selectedIndex == 5 && $("[id*='txtPublisher']").val() != "") {
                flagKey3 = "isbn";
            }
            else {
                flagKey3 = "";
            }

            if (document.getElementById('rdbAND').checked == true) {
                flagLogic = "AND";
            }
            else if (document.getElementById('rdbOR').checked == true) {
                flagLogic = "OR";
            }
            else if (document.getElementById('rdbNOT').checked == true) {
                flagLogic = "NOT";
            }

            if (document.getElementById('rdbAND1').checked == true) {
                flagLogic1 = "AND";
            }
            else if (document.getElementById('rdbOR1').checked == true) {
                flagLogic1 = "OR";
            }
            else if (document.getElementById('rdbNOT1').checked == true) {
                flagLogic1 = "NOT";
            }
            if ($("[id*=DDL_CAT]")[0].selectedIndex == 1) {
                type = "BOOK";

            }
            else if ($("[id*=DDL_CAT]")[0].selectedIndex == 2) {
                type = "CD";
            }
            else if ($("[id*=DDL_CAT]")[0].selectedIndex == 3) {
                type = "MAP";
            }
           
            if ($("[id*=keyword2]").val() != "" && (flagLogic == "")) {
                $.notify("Select one of the option  AND,OR,NOT.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
            else if ($("[id*=keyword3]").val() != "" && (flagLogic1 == "")) {
                $.notify("Select one of the option  AND,OR,NOT.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
            else {
                var x = document.getElementById("loadss");
                x.style.display = "block";


                $.ajax({
                    type: "POST",
                    url: "book_search.aspx/Adv_book_search",
                    contentType: "application/json; charset=utf-8",
                    data: '{book_name:"' + $("[id*='txtTitle']").val() + '",author:"' + $("[id*='txtAuthor']").val() + '",publisher:"' + $("[id*='txtPublisher']").val() + '",flagKey1:"' + flagKey1 + '",flagKey2:"' + flagKey2 + '",flagKey3:"' + flagKey3 + '",flagLogic:"' + flagLogic + '",flagLogic1:"' + flagLogic1 + '",type:"' + type + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
                    // async: false,
                    success: function (data) {
                        if (type == "BOOK") {
                            $("[id*=ADV_BOOK_T]")[0].innerHTML = "";
                            if (data.d.length > 0) {
                                $("[id*=ADV_BOOK_T]").append("<thead><tr></tr><tr class='alert-info'><th style='display:none'><center>ACCESSION NO</center></th><th ><center>AUTHOR</center></th><th ><center>TITLE</center></th><th ><center>CALLNO</center></th><th ><center>PUBLISHER</center></th><th ><center>YEAR</center></th><th ><center>KEYWORD</center></th><th ><center>ISBN No.</center></th><th ><center>LANGUAGE</center></th><th ><center>Book Count</center></th><th style='display:none'><center>Issued Books</center></th><th style='display:none'><center>Avaiable</center></th><th></th></tr></thead>");//<th ><center>ACCOMMANING MATERIALS</center></th><th ><center>SUBJECTS</center></th><th ><center>REMARK</center></th><th ><center>BILL NO</center></th><th ><center>BILL DATE</center></th><th ><center>MRP</center></th><th ><center>DISCOUNT</center></th><th ><center>PRICE</center></th><th ><center>VENDOR</center></th><th ><center>REGISTRATION DATE</center></th><th ><center>DONOR</center></th></tr></thead>");
                                for (var i = 0; i < data.d.length; i++) {
                                    if (i == 0) {
                                        $("[id*=ADV_BOOK_T]").append("<tbody>");
                                    }
                                    var count = data.d[i].ACCESSION_NO.split(",");
                                    //$("[id*=TBL_BK_SR]").append("<tr></tr><tr class='alert-info'><th ><center>'"+data.d[i].TITLE+"'</center></th><th ><center>'"+data.d[i].AUTHOR+"'</center></th><th ><center>'"+data.d[i].ISBN+"'</center></th><th ><center>'"+data.d[i].LANG+"'</center></th><th ><center>'"+data.d[i].KEYWORD+"'</center></th><th ><center>'"+data.d[i].PUBLISHER+"'</center></th><th ><center>'"+data.d[i].YEAR+"'</center></th><th ><center>'"+data.d[i].CALLNO+"'</center></th><th ><center>'"+data.d[i].ACC_MATERIALS+"'</center></th><th ><center>'"+data.d[i].SUBJ+"'</center></th><th ><center>'"+data.d[i].REMARK+"'</center></th><th ><center>'"+data.d[i].ACCESSION_NO+"'</center></th><th ><center>'"+data.d[i].BILL_NO+"'</center></th><th ><center>'"+data.d[i].BILL_Dt+"'</center></th><th ><center>'"+data.d[i].MRP+"'</center></th><th ><center>'"+data.d[i].DISCOUNT+"'</center></th><th ><center>'"+data.d[i].PRICE+"'</center></th><th ><center>'"+data.d[i].VENDOR+"'</center></th><th ><center>'"+data.d[i].REG_DT+"'</center></th><th ><center>'"+data.d[i].DONOR+"'</center></th></tr>");
                                    $("[id*=ADV_BOOK_T]").append("<tr></tr><tr><td style='display:none' ><center>" + data.d[i].ACCESSION_NO + "</center></td><td ><center>" + data.d[i].AUTHOR + "</center></td><td ><center>" + data.d[i].TITLE + "</center></td><td ><center>" + data.d[i].CALLNO + "</center></td><td ><center>" + data.d[i].PUBLISHER + "</center></td><td ><center>" + data.d[i].YEAR + "</center></td><td ><center>" + data.d[i].KEYWORD + "</center></td><td ><center>" + data.d[i].ISBN + "</center></td><td ><center>" + data.d[i].LANG + "</center></td><td ><center>" + count.length + "</center></td><td style='display:none'><center>" + data.d[i].issued + "</center></td><td style='display:none'><center>" + data.d[i].available + "</center></td><td style='display:none'><center>" + data.d[i].REMARK + "</center></td><td style='display:none'><center>" + data.d[i].ISSUE_TYPE + "</center></td><td style='display:none'><center>" + data.d[i].SUBJ + "</center></td><td style='display:none'><center>" + data.d[i].REG_DT + "</center></td><td><a href='#' class='Select' style='color:blue'>Details</a></td></tr>");//<td ><center>" + data.d[i].ACC_MATERIALS + "</center></td><td ><center>" + data.d[i].SUBJ + "</center></td><td ><center>" + data.d[i].REMARK + "</center></td><td ><center>" + data.d[i].BILL_NO + "</center></td><td ><center>" + data.d[i].BILL_DT + "</center></td><td ><center>" + data.d[i].MRP + "</center></td><td ><center>" + data.d[i].DISCOUNT + "</center></td><td ><center>" + data.d[i].PRICE + "</center></td><td ><center>" + data.d[i].VENDOR + "</center></td><td ><center>" + data.d[i].REG_DT + "</center></td><td ><center>" + data.d[i].DONOR_ID + "</center></td></tr>");

                                    if (i == data.d.length - 1) {
                                        $("[id*=ADV_BOOK_T]").append("</tbody>");
                                    }
                                }


                                var x = document.getElementById("loadss");
                                x.style.display = "none";

                               // document.getElementById('divhideshow_ADV').style.display = "block";
                                $("[id*='lbA']")[0].innerText = "(" + data.d.length + ")";

                            }
                            else {
                                $.notify("No Data Found.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

                            }
                        }
                        else if (type == "CD") {
                            $("[id*=Table1]")[0].innerHTML = "";
                            if (data.d.length > 0) {
                                $("[id*=Table1]").append("<thead><tr></tr><tr class='alert-info'><th style='display:none'><center>ACCESSION NO</center></th><th ><center>AUTHOR</center></th><th ><center>TITLE</center></th><th ><center>CALLNO</center></th><th ><center>PUBLISHER</center></th><th ><center>YEAR</center></th><th ><center>KEYWORD</center></th><th ><center>ISBN No.</center></th><th ><center>LANGUAGE</center></th><th ><center>Book Count</center></th><th style='display:none'><center>Issued Books</center></th><th style='display:none'><center>Avaiable</center></th><th></th></tr></thead>");//<th ><center>ACCOMMANING MATERIALS</center></th><th ><center>SUBJECTS</center></th><th ><center>REMARK</center></th><th ><center>BILL NO</center></th><th ><center>BILL DATE</center></th><th ><center>MRP</center></th><th ><center>DISCOUNT</center></th><th ><center>PRICE</center></th><th ><center>VENDOR</center></th><th ><center>REGISTRATION DATE</center></th><th ><center>DONOR</center></th></tr></thead>");
                                for (var i = 0; i < data.d.length; i++) {
                                    if (i == 0) {
                                        $("[id*=Table1]").append("<tbody>");
                                    }
                                    var count = data.d[i].ACCESSION_NO.split(",");
                                    //$("[id*=TBL_BK_SR]").append("<tr></tr><tr class='alert-info'><th ><center>'"+data.d[i].TITLE+"'</center></th><th ><center>'"+data.d[i].AUTHOR+"'</center></th><th ><center>'"+data.d[i].ISBN+"'</center></th><th ><center>'"+data.d[i].LANG+"'</center></th><th ><center>'"+data.d[i].KEYWORD+"'</center></th><th ><center>'"+data.d[i].PUBLISHER+"'</center></th><th ><center>'"+data.d[i].YEAR+"'</center></th><th ><center>'"+data.d[i].CALLNO+"'</center></th><th ><center>'"+data.d[i].ACC_MATERIALS+"'</center></th><th ><center>'"+data.d[i].SUBJ+"'</center></th><th ><center>'"+data.d[i].REMARK+"'</center></th><th ><center>'"+data.d[i].ACCESSION_NO+"'</center></th><th ><center>'"+data.d[i].BILL_NO+"'</center></th><th ><center>'"+data.d[i].BILL_Dt+"'</center></th><th ><center>'"+data.d[i].MRP+"'</center></th><th ><center>'"+data.d[i].DISCOUNT+"'</center></th><th ><center>'"+data.d[i].PRICE+"'</center></th><th ><center>'"+data.d[i].VENDOR+"'</center></th><th ><center>'"+data.d[i].REG_DT+"'</center></th><th ><center>'"+data.d[i].DONOR+"'</center></th></tr>");
                                    $("[id*=Table1]").append("<tr></tr><tr><td style='display:none' ><center>" + data.d[i].ACCESSION_NO + "</center></td><td ><center>" + data.d[i].AUTHOR + "</center></td><td ><center>" + data.d[i].TITLE + "</center></td><td ><center>" + data.d[i].CALLNO + "</center></td><td ><center>" + data.d[i].PUBLISHER + "</center></td><td ><center>" + data.d[i].YEAR + "</center></td><td ><center>" + data.d[i].KEYWORD + "</center></td><td ><center>" + data.d[i].ISBN + "</center></td><td ><center>" + data.d[i].LANG + "</center></td><td ><center>" + count.length + "</center></td><td style='display:none'><center>" + data.d[i].issued + "</center></td><td style='display:none'><center>" + data.d[i].available + "</center></td><td><a href='#' class='Select' style='color:blue'>Details</a></td></tr>");//<td ><center>" + data.d[i].ACC_MATERIALS + "</center></td><td ><center>" + data.d[i].SUBJ + "</center></td><td ><center>" + data.d[i].REMARK + "</center></td><td ><center>" + data.d[i].BILL_NO + "</center></td><td ><center>" + data.d[i].BILL_DT + "</center></td><td ><center>" + data.d[i].MRP + "</center></td><td ><center>" + data.d[i].DISCOUNT + "</center></td><td ><center>" + data.d[i].PRICE + "</center></td><td ><center>" + data.d[i].VENDOR + "</center></td><td ><center>" + data.d[i].REG_DT + "</center></td><td ><center>" + data.d[i].DONOR_ID + "</center></td></tr>");

                                    if (i == data.d.length - 1) {
                                        $("[id*=Table1]").append("</tbody>");
                                    }
                                }

                                var x = document.getElementsByClassName("loader");
                                x[0].style.display = "none";

                                document.getElementById('div2').style.display = "block";
                                $("[id*='Label1']")[0].innerText = "(" + data.d.length + ")";
                            }
                            else {
                                $.notify("No Data Found.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

                            }
                        }
                        else
                        {
                            $("[id*=Table2]")[0].innerHTML = "";
                            if (data.d.length > 0) {
                                $("[id*=Table2]").append("<thead><tr></tr><tr class='alert-info'><th style='display:none'><center>ACCESSION NO</center></th><th ><center>AUTHOR</center></th><th ><center>TITLE</center></th><th ><center>CALLNO</center></th><th ><center>PUBLISHER</center></th><th ><center>YEAR</center></th><th ><center>KEYWORD</center></th><th ><center>ISBN No.</center></th><th ><center>LANGUAGE</center></th><th ><center>Book Count</center></th><th style='display:none'><center>Issued Books</center></th><th style='display:none'><center>Avaiable</center></th><th></th></tr></thead>");//<th ><center>ACCOMMANING MATERIALS</center></th><th ><center>SUBJECTS</center></th><th ><center>REMARK</center></th><th ><center>BILL NO</center></th><th ><center>BILL DATE</center></th><th ><center>MRP</center></th><th ><center>DISCOUNT</center></th><th ><center>PRICE</center></th><th ><center>VENDOR</center></th><th ><center>REGISTRATION DATE</center></th><th ><center>DONOR</center></th></tr></thead>");
                                for (var i = 0; i < data.d.length; i++) {
                                    if (i == 0) {
                                        $("[id*=Table2]").append("<tbody>");
                                    }
                                    var count = data.d[i].ACCESSION_NO.split(",");
                                    //$("[id*=TBL_BK_SR]").append("<tr></tr><tr class='alert-info'><th ><center>'"+data.d[i].TITLE+"'</center></th><th ><center>'"+data.d[i].AUTHOR+"'</center></th><th ><center>'"+data.d[i].ISBN+"'</center></th><th ><center>'"+data.d[i].LANG+"'</center></th><th ><center>'"+data.d[i].KEYWORD+"'</center></th><th ><center>'"+data.d[i].PUBLISHER+"'</center></th><th ><center>'"+data.d[i].YEAR+"'</center></th><th ><center>'"+data.d[i].CALLNO+"'</center></th><th ><center>'"+data.d[i].ACC_MATERIALS+"'</center></th><th ><center>'"+data.d[i].SUBJ+"'</center></th><th ><center>'"+data.d[i].REMARK+"'</center></th><th ><center>'"+data.d[i].ACCESSION_NO+"'</center></th><th ><center>'"+data.d[i].BILL_NO+"'</center></th><th ><center>'"+data.d[i].BILL_Dt+"'</center></th><th ><center>'"+data.d[i].MRP+"'</center></th><th ><center>'"+data.d[i].DISCOUNT+"'</center></th><th ><center>'"+data.d[i].PRICE+"'</center></th><th ><center>'"+data.d[i].VENDOR+"'</center></th><th ><center>'"+data.d[i].REG_DT+"'</center></th><th ><center>'"+data.d[i].DONOR+"'</center></th></tr>");
                                    $("[id*=Table2]").append("<tr></tr><tr><td style='display:none' ><center>" + data.d[i].ACCESSION_NO + "</center></td><td ><center>" + data.d[i].AUTHOR + "</center></td><td ><center>" + data.d[i].TITLE + "</center></td><td ><center>" + data.d[i].CALLNO + "</center></td><td ><center>" + data.d[i].PUBLISHER + "</center></td><td ><center>" + data.d[i].YEAR + "</center></td><td ><center>" + data.d[i].KEYWORD + "</center></td><td ><center>" + data.d[i].ISBN + "</center></td><td ><center>" + data.d[i].LANG + "</center></td><td ><center>" + count.length + "</center></td><td style='display:none'><center>" + data.d[i].issued + "</center></td><td style='display:none'><center>" + data.d[i].available + "</center></td><td><a href='#' class='Select' style='color:blue'>Details</a></td></tr>");//<td ><center>" + data.d[i].ACC_MATERIALS + "</center></td><td ><center>" + data.d[i].SUBJ + "</center></td><td ><center>" + data.d[i].REMARK + "</center></td><td ><center>" + data.d[i].BILL_NO + "</center></td><td ><center>" + data.d[i].BILL_DT + "</center></td><td ><center>" + data.d[i].MRP + "</center></td><td ><center>" + data.d[i].DISCOUNT + "</center></td><td ><center>" + data.d[i].PRICE + "</center></td><td ><center>" + data.d[i].VENDOR + "</center></td><td ><center>" + data.d[i].REG_DT + "</center></td><td ><center>" + data.d[i].DONOR_ID + "</center></td></tr>");

                                    if (i == data.d.length - 1) {
                                        $("[id*=Table2]").append("</tbody>");
                                    }
                                }

                                var x = document.getElementsByClassName("loader");
                                x[0].style.display = "none";

                                //document.getElementById('div3').style.display = "block";
                                $("[id*='Label2']")[0].innerText = "(" + data.d.length + ")";

                            }
                            else {
                                $.notify("No Data Found.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

                            }
                        }
                    },
                    error: function () {

                    }
                });
            }
        }
        }
});

function adv_clear()
{
    document.getElementById('div2_HH').style.display = "none";
    document.getElementById('div2_HH').style.display = "none";
    $("[id*='Label1_ADV']")[0].innerText = "";
    //document.getElementById('div3').style.display = "none";
    $("[id*='Label2_ADV']")[0].innerText = "";
    document.getElementById('divhideshow_ADV').style.display = "none";
    $("[id*='lbA']")[0].innerText = "";
    $("[id*=divhideshow_ADV]").hide();
    $("[id*=ADV_BOOK_T]").empty();
    $("[id*=Table1_ADV]").empty();

    $("[id*='txtTitle']").val("");
    $("[id*='txtAuthor']").val("");
    $("[id*='txtPublisher']").val("");
    document.getElementById('rdbNOT1').checked = false;
    document.getElementById('rdbNOT').checked = false;
    document.getElementById('rdbOR1').checked = false;
    document.getElementById('rdbOR').checked = false;
    document.getElementById('rdbAND1').checked = false;
    document.getElementById('rdbAND').checked = false;
    document.getElementById('txtTitle').disabled = true;
    document.getElementById('txtAuthor').disabled = true;
    document.getElementById('txtPublisher').disabled = true;

    $("[id*=keyword1]")[0].selectedIndex = 0;
    $("[id*=keyword2]")[0].selectedIndex = 0;
    $("[id*=keyword3]")[0].selectedIndex = 0;
    $("[id*=DDL_CAT]")[0].selectedIndex = 0;

    var x = document.getElementById("loadss");
    x.style.display = "none";
    var x = document.getElementsByClassName("loader");
    x[0].style.display = "none";
    var y = document.getElementById("loadss");
    y.style.display = "none";

}
$("[id*='reset']").on("click", function () {
    /*$("#DDL_CAT").val('--Select--');*/
    $("[id*=DDL_CAT]")[0].selectedIndex = 0;
    $("[id*=ddlselect]")[0].selectedIndex = 0;
    $("[id*='txtTitle']").val('');
    $("[id*='txtAuthor']").val('');
    $("[id*='txtPublisher']").val('');
    adv_clear();

});

$("[id*=ADV_BOOK_T]").on('click', 'td a.Select', function () {

    // $("[id*=Div3]").modal('show');
    var $td = $(this).closest('tr').children('td');
    var count = $td.eq(0).text().split(",");
    //var b3 = ImageExist("Library/Book/" + count[0] + ".jpg");

    //if (b3 == true) {
   
    $.ajax(  
        {  
            url: "Library/Book/" + count[0].trim() + ".jpg",  
            success: function(data)  
            {  
                document.getElementById("12img").src = "Library/Book/" + count[0].trim() + ".jpg";
            },  
            error: function(data)  
            {  
                document.getElementById("12img").src =" images/book_open.png";
            }  
        });  
 
     // }
    document.getElementById('txtbooktitle_ADV').innerText = $td.eq(2).text();
    document.getElementById('txtauthor_ADV').innerText = $td.eq(1).text();
    document.getElementById('txtpublication_ADV').innerText = $td.eq(4).text();
    document.getElementById('txtdescription_ADV').innerText = $td.eq(0).text();
    document.getElementById('txtkeywords_ADV').innerText = $td.eq(6).text();
    document.getElementById('txtcount_ADV').innerText = $td.eq(9).text();
    document.getElementById('txtissuedbook_ADV').innerText = $td.eq(10).text();
    document.getElementById('txtavailablebook_ADV').innerText = $td.eq(11).text();
    document.getElementById('txtwithdraw_ADV').innerText = $td.eq(12).text();
    document.getElementById('txtmissing_ADV').innerText = $td.eq(13).text();
    ////$("[id*=txtauthor]").val($td.eq(1).text());
    ////$("[id*=txtpublication]").val($td.eq(4).text());
    ////$("[id*=txtdescription]").val($td.eq(0).text());
    ////$("[id*=txtkeywords]").val($td.eq(6).text());
    ////$("[id*=txtcount]").val($td.eq(9).text());


    $('#Advance_searchModal_1').modal("show");
});
$("[id*=Table1_ADV]").on('click', 'td a.Select', function () {

    // $("[id*=Div3]").modal('show');
    var $td = $(this).closest('tr').children('td');
    var count = $td.eq(0).text().split(",");
    //var b3 = ImageExist("Library/Book/" + count[0] + ".jpg");
    $.ajax(
      {
          url: "Library/CD/" + count[0].trim() + ".jpg",
          success: function (data) {
              document.getElementById("12img").src = "Library/CD/" + count[0].trim() + ".jpg";
          },
          error: function (data) {
              document.getElementById("12img").src = " images/cd.png";
          }
      });
    //if (b3 == true) {
   
      //}
    document.getElementById('txtbooktitle_ADV').innerText = $td.eq(2).text();
    document.getElementById('txtauthor_ADV').innerText = $td.eq(1).text();
    document.getElementById('txtpublication_ADV').innerText = $td.eq(4).text();
    document.getElementById('txtdescription_ADV').innerText = $td.eq(0).text();
    document.getElementById('txtkeywords_ADV').innerText = $td.eq(6).text();
    document.getElementById('txtcount_ADV').innerText = $td.eq(9).text();
    document.getElementById('txtissuedbook_ADV').innerText = $td.eq(10).text();
    document.getElementById('txtavailablebook_ADV').innerText = $td.eq(11).text();
    ////$("[id*=txtauthor]").val($td.eq(1).text());
    ////$("[id*=txtpublication]").val($td.eq(4).text());
    ////$("[id*=txtdescription]").val($td.eq(0).text());
    ////$("[id*=txtkeywords]").val($td.eq(6).text());
    ////$("[id*=txtcount]").val($td.eq(9).text());


    $('#Advance_searchModal_1').modal("show");
});
$("[id*=Table2SD]").on('click', 'td a.Select', function () {

    // $("[id*=Div3]").modal('show');
    var $td = $(this).closest('tr').children('td');
    var count = $td.eq(0).text().split(",");
    //var b3 = ImageExist("Library/Book/" + count[0] + ".jpg");

    //if (b3 == true) {
    $.ajax(
  {
      url: "Library/Map/" + count[0].trim() + ".jpg",
      success: function (data) {
          document.getElementById("12img").src = "Library/Map/" + count[0].trim() + ".jpg";
      },
      error: function (data) {
          document.getElementById("12img").src = "images/Map.png";
      }
  });
    document.getElementById("12img").src = "Library/Map/" + count[0].trim() + ".jpg";
      //}
    document.getElementById('txtbooktitle_ADV').innerText = $td.eq(2).text();
    document.getElementById('txtauthor_ADV').innerText = $td.eq(1).text();
    document.getElementById('txtpublication_ADV').innerText = $td.eq(4).text();
    document.getElementById('txtdescription_ADV').innerText = $td.eq(0).text();
    document.getElementById('txtkeywords_ADV').innerText = $td.eq(6).text();
    document.getElementById('txtcount_ADV').innerText = $td.eq(9).text();
    document.getElementById('txtissuedbook_ADV').innerText = $td.eq(10).text();
    document.getElementById('txtavailablebook_ADV').innerText = $td.eq(11).text();
    ////$("[id*=txtauthor]").val($td.eq(1).text());
    ////$("[id*=txtpublication]").val($td.eq(4).text());
    ////$("[id*=txtdescription]").val($td.eq(0).text());
    ////$("[id*=txtkeywords]").val($td.eq(6).text());
    ////$("[id*=txtcount]").val($td.eq(9).text());


    $('#Advance_searchModal_1').modal("show");
});

function readURL_book(input, imgID) {
   
}