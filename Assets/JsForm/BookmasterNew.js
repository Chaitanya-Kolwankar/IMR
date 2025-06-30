
var books_arr = []; var se_book_id = ""; var se_book_name = ""; var ori_val = ""; var cha_val = ""; var donor = []; var upd_id = ""; var upd_tit = ""; var maps_arr = []; var Ebook_arr = [];

$(document).ready(function ()
{
   // $(".txt_dur").timeEntry({ show24Hours: true });
    localStorage.setItem("type", "insert");

    //sessionStorage.setItem("connect", "");
    FillLanguage();

    var connect = localStorage.getItem("connect");
    if (connect) {
        $("[id*='ddlselect']").val(connect);
    }
  

    $(function () {
        // for bootstrap 3 use 'shown.bs.tab', for bootstrap 2 use 'shown' in the next line
        $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
            // save the latest tab; use cookies if you like 'em better:
            localStorage.setItem('lastTab', $(this).attr('href'));
        
        });
      
        // go to the latest tab, if it exists:
        var lastTab = localStorage.getItem('lastTab');
        
        if (lastTab) {
            //$('a[href="#career"]').tab('show');
            //   $('.nav-tabs a[href="#secondyear"]').tab('show');
            //$('#sub .nav-tabs a[href="#secondyear"]').tab('show')
            //if (lastTab == '#cd' || lastTab == '#map' || lastTab == '#book') {
            //    // $('#sub a[href="' + lastTab + '"]').tab('show');
            //    $('a[href="#current"]').tab('show');

            //    $('#Tabs a[href="' + lastTab + '"]').tab('show');
            //}
            //else {
            var connect = localStorage.getItem("connect");
            $("[id*='ddlselect']").val(connect);
            $('a[href="' + lastTab + '"]').tab('show');
            //}
        }
    });
    //new
    $(function () {



        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/Get_book_Title",
            data: '{type:"book",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            aync: false,
            success: function (data) {
                debugger;

                for (var i = 0; i < data.d.length; i++) {
                    // var val = item[i];
                    var item = data.d[i].id;
                    var mid = data.d[i].title;
                    books_arr.push(mid);
                }
                // setup autocomplete function pulling from currencies[] array


                var books = books_arr;

                $('#txtbooktitlee').autocomplete({
                    source: [books]
                });
            },
            error: function () {

                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });




    });
    //map
    $(function () {



        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/Get_book_Title",
            data: '{type:"map",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            aync: false,
            success: function (data) {
                debugger;

                for (var i = 0; i < data.d.length; i++) {
                    // var val = item[i];
                    var item = data.d[i].id;
                    var mid = data.d[i].title;
                    maps_arr.push(mid);
                }
                // setup autocomplete function pulling from currencies[] array


                var books = maps_arr;

                $('#txtmaptitle').autocomplete({
                    source: [books]
                });


            },
            error: function () {

                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });




    });

    //eBOOK
    $(function () {



        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/Get_book_Title",
            data: '{type:"Ebook",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            aync: false,
            success: function (data) {
                debugger;

                for (var i = 0; i < data.d.length; i++) {
                    // var val = item[i];
                    var item = data.d[i].id;
                    var mid = data.d[i].title;
                    Ebook_arr.push(mid);
                }
                // setup autocomplete function pulling from currencies[] array


                var books = Ebook_arr;

                $('#txtebooktitle').autocomplete({
                    source: [books]
                });


            },
            error: function () {

                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });




    });


    (function () {
        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/LoadPublisher",
            data: '{type:"p",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d.length > 0) {

                    $('#txtpublisher').tokens({

                        source: r.d,



                    });

                    $('#txt_pub').tokens({

                        source: r.d,



                    });

                    $('#txtpublisher_map').tokens({

                        source: r.d,



                    });
                }
            }
        });


    })();

    (function () {
        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/LoadPublisher",

            data: '{type:"A",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d.length > 0) {

                    $('#txtauthor').tokens({

                        source: r.d,



                    });
                    $('#txt_auth').tokens({

                        source: r.d,



                    });

                    $('#txtauthor_map').tokens({

                        source: r.d,



                    });

                    $('#txt_author_ebook').tokens({

                        source: r.d,



                    });

                }
            }
        });


    })();

    //doner
    (function () {
        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/LoadPublisher",

            data: '{type:"D",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d.length > 0) {

                    $('#txtdonor').tokens({

                        source: r.d,



                    });
                    $('#donar_name').tokens({

                        source: r.d,



                    });

                    $('#txtdonor_map').tokens({

                        source: r.d,



                    });

                }
            }
        });


    })();
    
    $(function () {



        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/Get_cd_Title",
            data: '{connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            aync: false,
            success: function (data) {
                debugger;

                for (var i = 0; i < data.d.length; i++) {
                    // var val = item[i];
                    //  var item = data.d[i].cd_id;
                    var mid = data.d[i].cd_name;
                    donor.push(mid);
                }
                // setup autocomplete function pulling from currencies[] array

                var cd_title = donor;

                $('#txt_cd_tit').autocomplete({
                    source: [cd_title]
                });

            },
            error: function () {

                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });




    });
  //  FillLanguage();

    //new

    //end
    (function () {

        $('#txt_pub').tokens({

            search: false, // The function against which are evaluated the suggestions.

            keyCode: {

                UP: 38,

                DOWN: 40,

                BACKSPACE: 8,

                TAB: 9,

                ENTER: 13,

                ESC: 27,

                COMMA: 188,

                SPACE: 32

            },

            texts: { // All appearing texts can be replaced by passing parameters within this object:

                'close-text': '×',

                'type-suggestions': 'Type to search values',

                'no-results': 'There are no results matching',

                'add-result': 'Add "%s" to the list',

                'invalid-format': '%s is not the correct format'

            },

            cssClasses: { // All css classes can be replaced by passing parameters within this object

                'token-list': 'tokens-token-list',

                'list-input-holder': 'tokens-list-input-holder',

                'list-token-holder': 'tokens-list-token-holder',

                'input-text': 'tokens-input-text',

                'delete-anchor': 'tokens-delete-token',

                'suggestion-selector': 'tokens-suggestion-selector',

                'suggestions-list-element': 'tokens-suggestions-list-element',

                'highlighted-suggestion': 'tokens-highlighted-suggestion'

            },

            maxSelected: 0, // Option to cap the ammount of tokens you can add.

            showSuggestionOnFocus: true,

            showMessageOnNoResults: true, // Option to show a message if no suggestions are available.

            allowAddingNoSuggestion: true, // Option that allows you to add a value on enter even if it's not on the suggestions.

            cleanInputOnHide: true,

            suggestionsZindex: 999,

            source: [], // Array of sources

            initValue: [], // Array of initial values you want to see added when plugin inits

            minChars: 0

        });

    })();

    (function () {

        $('#txt_auth').tokens({

            search: false, // The function against which are evaluated the suggestions.

            keyCode: {

                UP: 38,

                DOWN: 40,

                BACKSPACE: 8,

                TAB: 9,

                ENTER: 13,

                ESC: 27,

                COMMA: 188,

                SPACE: 32

            },

            texts: { // All appearing texts can be replaced by passing parameters within this object:

                'close-text': '×',

                'type-suggestions': 'Type to search values',

                'no-results': 'There are no results matching',

                'add-result': 'Add "%s" to the list',

                'invalid-format': '%s is not the correct format'

            },

            cssClasses: { // All css classes can be replaced by passing parameters within this object

                'token-list': 'tokens-token-list',

                'list-input-holder': 'tokens-list-input-holder',

                'list-token-holder': 'tokens-list-token-holder',

                'input-text': 'tokens-input-text',

                'delete-anchor': 'tokens-delete-token',

                'suggestion-selector': 'tokens-suggestion-selector',

                'suggestions-list-element': 'tokens-suggestions-list-element',

                'highlighted-suggestion': 'tokens-highlighted-suggestion'

            },

            maxSelected: 0, // Option to cap the ammount of tokens you can add.

            showSuggestionOnFocus: true,

            showMessageOnNoResults: true, // Option to show a message if no suggestions are available.

            allowAddingNoSuggestion: true, // Option that allows you to add a value on enter even if it's not on the suggestions.

            cleanInputOnHide: true,

            suggestionsZindex: 999,

            source: [], // Array of sources

            initValue: [], // Array of initial values you want to see added when plugin inits

            minChars: 0

        });

    })();

    //new
    (function () {

        $('#txtdonor').tokens({

            search: false, // The function against which are evaluated the suggestions.

            keyCode: {

                UP: 38,

                DOWN: 40,

                BACKSPACE: 8,

                TAB: 9,

                ENTER: 13,

                ESC: 27,

                COMMA: 188,

                SPACE: 32

            },

            texts: { // All appearing texts can be replaced by passing parameters within this object:

                'close-text': '×',

                'type-suggestions': 'Type to search values',

                'no-results': 'There are no results matching',

                'add-result': 'Add "%s" to the list',

                'invalid-format': '%s is not the correct format'

            },

            cssClasses: { // All css classes can be replaced by passing parameters within this object

                'token-list': 'tokens-token-list',

                'list-input-holder': 'tokens-list-input-holder',

                'list-token-holder': 'tokens-list-token-holder',

                'input-text': 'tokens-input-text',

                'delete-anchor': 'tokens-delete-token',

                'suggestion-selector': 'tokens-suggestion-selector',

                'suggestions-list-element': 'tokens-suggestions-list-element',

                'highlighted-suggestion': 'tokens-highlighted-suggestion'

            },

            maxSelected: 0, // Option to cap the ammount of tokens you can add.

            showSuggestionOnFocus: true,

            showMessageOnNoResults: true, // Option to show a message if no suggestions are available.

            allowAddingNoSuggestion: true, // Option that allows you to add a value on enter even if it's not on the suggestions.

            cleanInputOnHide: true,

            suggestionsZindex: 999,

            source: [], // Array of sources

            initValue: [], // Array of initial values you want to see added when plugin inits

            minChars: 0

        });

    })();
    //end

    (function () {

        $('#donar_name').tokens({

            search: false, // The function against which are evaluated the suggestions.

            keyCode: {

                UP: 38,

                DOWN: 40,

                BACKSPACE: 8,

                TAB: 9,

                ENTER: 13,

                ESC: 27,

                COMMA: 188,

                SPACE: 32

            },

            texts: { // All appearing texts can be replaced by passing parameters within this object:

                'close-text': '×',

                'type-suggestions': 'Type to search values',

                'no-results': 'There are no results matching',

                'add-result': 'Add "%s" to the list',

                'invalid-format': '%s is not the correct format'

            },

            cssClasses: { // All css classes can be replaced by passing parameters within this object

                'token-list': 'tokens-token-list',

                'list-input-holder': 'tokens-list-input-holder',

                'list-token-holder': 'tokens-list-token-holder',

                'input-text': 'tokens-input-text',

                'delete-anchor': 'tokens-delete-token',

                'suggestion-selector': 'tokens-suggestion-selector',

                'suggestions-list-element': 'tokens-suggestions-list-element',

                'highlighted-suggestion': 'tokens-highlighted-suggestion'

            },

            maxSelected: 0, // Option to cap the ammount of tokens you can add.

            showSuggestionOnFocus: true,

            showMessageOnNoResults: true, // Option to show a message if no suggestions are available.

            allowAddingNoSuggestion: true, // Option that allows you to add a value on enter even if it's not on the suggestions.

            cleanInputOnHide: true,

            suggestionsZindex: 999,

            source: [], // Array of sources

            initValue: [], // Array of initial values you want to see added when plugin inits

            minChars: 0

        });

    })();
    (function () {

        $('#txtpublisher').tokens({

            search: false, // The function against which are evaluated the suggestions.

            keyCode: {

                UP: 38,

                DOWN: 40,

                BACKSPACE: 8,

                TAB: 9,

                ENTER: 13,

                ESC: 27,

                COMMA: 188,

                SPACE: 32

            },

            //texts: { // All appearing texts can be replaced by passing parameters within this object:

            //    'close-text': '×',

            //    'type-suggestions': 'Type to search values',

            //    'no-results': 'There are no results matching',

            //    'add-result': 'Add "%s" to the list',

            //    'invalid-format': '%s is not the correct format'

            //},

            cssClasses: { // All css classes can be replaced by passing parameters within this object

                'token-list': 'tokens-token-list',

                'list-input-holder': 'tokens-list-input-holder',

                'list-token-holder': 'tokens-list-token-holder',

                'input-text': 'tokens-input-text',

                'delete-anchor': 'tokens-delete-token',

                'suggestion-selector': 'tokens-suggestion-selector',

                'suggestions-list-element': 'tokens-suggestions-list-element',

                'highlighted-suggestion': 'tokens-highlighted-suggestion'

            },

            maxSelected: 0, // Option to cap the ammount of tokens you can add.

            showSuggestionOnFocus: true,

            showMessageOnNoResults: true, // Option to show a message if no suggestions are available.

            allowAddingNoSuggestion: true, // Option that allows you to add a value on enter even if it's not on the suggestions.

            cleanInputOnHide: true,

            suggestionsZindex: 999,

            source: [], // Array of sources

            initValue: [], // Array of initial values you want to see added when plugin inits

            minChars: 0

        });

    })();

    (function () {

        $('#txtauthor').tokens({

            search: false, // The function against which are evaluated the suggestions.

            keyCode: {

                UP: 38,

                DOWN: 40,

                BACKSPACE: 8,

                TAB: 9,

                ENTER: 13,

                ESC: 27,

                COMMA: 188,

                SPACE: 32

            },

            texts: { // All appearing texts can be replaced by passing parameters within this object:

                'close-text': '×',

                'type-suggestions': 'Type to search values',

                'no-results': 'There are no results matching',

                'add-result': 'Add "%s" to the list',

                'invalid-format': '%s is not the correct format'

            },

            cssClasses: { // All css classes can be replaced by passing parameters within this object

                'token-list': 'tokens-token-list',

                'list-input-holder': 'tokens-list-input-holder',

                'list-token-holder': 'tokens-list-token-holder',

                'input-text': 'tokens-input-text',

                'delete-anchor': 'tokens-delete-token',

                'suggestion-selector': 'tokens-suggestion-selector',

                'suggestions-list-element': 'tokens-suggestions-list-element',

                'highlighted-suggestion': 'tokens-highlighted-suggestion'

            },

            maxSelected: 0, // Option to cap the ammount of tokens you can add.

            showSuggestionOnFocus: true,

            showMessageOnNoResults: true, // Option to show a message if no suggestions are available.

            allowAddingNoSuggestion: true, // Option that allows you to add a value on enter even if it's not on the suggestions.

            cleanInputOnHide: true,

            suggestionsZindex: 999,

            source: [], // Array of sources

            initValue: [], // Array of initial values you want to see added when plugin inits

            minChars: 0

        });

    })();

    (function () {

        $('#txtdonor').tokens({

            search: false, // The function against which are evaluated the suggestions.

            keyCode: {

                UP: 38,

                DOWN: 40,

                BACKSPACE: 8,

                TAB: 9,

                ENTER: 13,

                ESC: 27,

                COMMA: 188,

                SPACE: 32

            },

            texts: { // All appearing texts can be replaced by passing parameters within this object:

                'close-text': '×',

                'type-suggestions': 'Type to search values',

                'no-results': 'There are no results matching',

                'add-result': 'Add "%s" to the list',

                'invalid-format': '%s is not the correct format'

            },

            cssClasses: { // All css classes can be replaced by passing parameters within this object

                'token-list': 'tokens-token-list',

                'list-input-holder': 'tokens-list-input-holder',

                'list-token-holder': 'tokens-list-token-holder',

                'input-text': 'tokens-input-text',

                'delete-anchor': 'tokens-delete-token',

                'suggestion-selector': 'tokens-suggestion-selector',

                'suggestions-list-element': 'tokens-suggestions-list-element',

                'highlighted-suggestion': 'tokens-highlighted-suggestion'

            },

            maxSelected: 0, // Option to cap the ammount of tokens you can add.

            showSuggestionOnFocus: true,

            showMessageOnNoResults: true, // Option to show a message if no suggestions are available.

            allowAddingNoSuggestion: true, // Option that allows you to add a value on enter even if it's not on the suggestions.

            cleanInputOnHide: true,

            suggestionsZindex: 999,

            source: [], // Array of sources

            initValue: [], // Array of initial values you want to see added when plugin inits

            minChars: 0

        });

    })();



    $.ajax({
        type: "POST",
        url: "BookmasterNew.aspx/cd_dept",
        data: '{connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            $.each(r.d, function () {

                $("[id*=ddlcourse_cd]").append($("<option></option>").val(this['Value']).html(this['Text']));
                $("[id*=ddlcourse_cd]").multiselect("rebuild");

                $("[id*=ddlMapDept]").append($("<option></option>").val(this['Value']).html(this['Text']));
                $("[id*=ddlMapDept]").multiselect("rebuild");
            });
        },
        error: function () {
            $.notify("Error ! Error Occured , please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });

    localStorage.setItem("auth", "");
    localStorage.setItem("don", "");
    localStorage.setItem("pub", "");

})


$("[id*='ddlselect']").change(function () {
    localStorage.setItem("type", "insert");

    localStorage.setItem("connect", $("[id*='ddlselect']").val());
    var connect = localStorage.getItem("connect");
    $("[id*='ddlselect']").val(connect);
    FillLanguage();

    $(function () {



        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/Get_book_Title",
            data: '{type:"book",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            aync: false,
            success: function (data) {
                debugger;

                for (var i = 0; i < data.d.length; i++) {
                    // var val = item[i];
                    var item = data.d[i].id;
                    var mid = data.d[i].title;
                    books_arr.push(mid);
                }
                // setup autocomplete function pulling from currencies[] array


                var books = books_arr;

                $('#txtbooktitlee').autocomplete({
                    source: [books]
                });
            },
            error: function () {

                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });




    });
    //map
    $(function () {



        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/Get_book_Title",
            data: '{type:"map",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            aync: false,
            success: function (data) {
                debugger;

                for (var i = 0; i < data.d.length; i++) {
                    // var val = item[i];
                    var item = data.d[i].id;
                    var mid = data.d[i].title;
                    maps_arr.push(mid);
                }
                // setup autocomplete function pulling from currencies[] array


                var books = maps_arr;

                $('#txtmaptitle').autocomplete({
                    source: [books]
                });


            },
            error: function () {

                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });




    });

    $(function () {



        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/Get_cd_Title",
            data: '{connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            aync: false,
            success: function (data) {
                debugger;

                for (var i = 0; i < data.d.length; i++) {
                    // var val = item[i];
                    //  var item = data.d[i].cd_id;
                    var mid = data.d[i].cd_name;
                    donor.push(mid);
                }
                // setup autocomplete function pulling from currencies[] array

                var cd_title = donor;

                $('#txt_cd_tit').autocomplete({
                    source: [cd_title]
                });

            },
            error: function () {

                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });




    });
  

    $.ajax({
        type: "POST",
        url: "BookmasterNew.aspx/cd_dept",
        data: '{connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            $.each(r.d, function () {

                $("[id*=ddlcourse_cd]").append($("<option></option>").val(this['Value']).html(this['Text']));
                $("[id*=ddlcourse_cd]").multiselect("rebuild");

                $("[id*=ddlMapDept]").append($("<option></option>").val(this['Value']).html(this['Text']));
                $("[id*=ddlMapDept]").multiselect("rebuild");
            });
        },
        error: function () {
            $.notify("Error ! Error Occured , please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        }
    });

    window.location.reload(true);


});


//AutoFilltable
$("[id*='btnnoofbooks']").on("click", function () {
    var count = $("[id*='txtbookcount']")[0].value;
    if (count != 0 && count != "") {
        var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
        if (tds.length > 0) {
            if (tds.length < count) {
                var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
                var tbl_len = parseInt(tds.length);
                for (var i = tbl_len; i < count; i++) {
                    var data = parseInt(i) + 1;

                    $("[id*=tableacceesiontable]").append("<tr><td>" + data + "</td><td><select id='ddlbookprefix_" + i + "' class='form-control' onchange='criteraichng(this.id);'></select></td><td><input type='text' id='txtbookAccession_" + i + "' style='font-size:12px'/></td><td><input type='text' id='txtbookbillno_" + i + "' style='width:90px'/></td><td><input type='text' id='txtbookbilldate_" + i + "' /></td><td><input type='text' id='txtbookmrp_" + i + "' style='width:80px'/></td><td><input type='text' id='txtbookdiscount_" + i + "' style='width:80px'/></td><td><input type='text' id='txtbookprice_" + i + "' style='width:80px'/></td><td><input type='text' id='txtbookvendordetails_" + i + "' style='font-size:12px'/></td><td><input type='text' id='txtbookregistrationdate_" + i + "' style='font-size:12px'/></td><td><input type='text' id='txt_purchase_orderDate" + i + "' style='font-size:12px'/></td><td><input type='text' id='txtOrderNo" + i + "' style='font-size:12px'/></td></tr>");
                    $('[id*=txtbookbilldate]').datetimepicker({
                        singleDatePicker: true,
                        calender_style: "picker_1",
                        timepicker: false,
                        format: 'd-M-Y'
                    }, function (start, end, label) {
                        console.log(start.toISOString(), end.toISOString(), label);
                    });
                    $('[id*=txtbookregistrationdate]').datetimepicker({
                        singleDatePicker: true,
                        calender_style: "picker_1",
                        timepicker: false,
                        format: 'd-M-Y'
                    }, function (start, end, label) {
                        console.log(start.toISOString(), end.toISOString(), label);
                    });
                    $('[id*=txt_purchase_orderDate]').datetimepicker({
                        singleDatePicker: true,
                        calender_style: "picker_1",
                        timepicker: false,
                        format: 'd-M-Y'
                    }, function (start, end, label) {
                        console.log(start.toISOString(), end.toISOString(), label);
                    });
                    ///vendor

                    $(function () {

                        var books_arr = [];

                        $.ajax({
                            type: "POST",
                            url: "BookmasterNew.aspx/LoadPublisher",
                            data: '{type:"v"}',
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            success: function (data) {
                                debugger;

                                for (var i = 0; i < data.d.length; i++) {
                                    // var val = item[i];
                                    var item = data.d[i];
                                    var mid = data.d[i];
                                    books_arr.push(mid);
                                }
                                // setup autocomplete function pulling from currencies[] array


                                var books = books_arr;

                                $('[id*=txtbookvendordetails]').autocomplete({
                                    source: [books]
                                });


                            },
                            error: function () {

                                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });




                    });
                    //prefix


                    $.ajax({
                        type: "POST",
                        url: "BookmasterNew.aspx/LoadPrefix",
                        data: '{type:"book",connect:"' + $("[id*='ddlselect']").val() + '"}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (data) {
                            $("[id^='ddlbookprefix_']").empty().append('<option selected="selected" value="0">--select--</option>');
                            $.each(data.d, function () {
                                $("[id^='ddlbookprefix_']").append($("<option></option>").val(this['Value']).html(this['Text']));
                            });

                        },
                        error: function () {

                            //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    });
                    fill_tbl_book_val(i);

                }
            }
            else if (tds.length > count) {
                var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
                var tbl_len = parseInt(tds.length) + 3;

                var init_val = parseInt(tds.length) + 1;
                for (var i = init_val; i < tbl_len; i--) {
                    if (count != tds.length) {
                        document.getElementById("tableacceesiontable").deleteRow(i);
                        tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
                        tbl_len = parseInt(tds.length) + 2;
                    }
                    else {
                        tbl_len = parseInt(i) - 1;
                    }
                }
            }
        }
        else {
            $("[id*=tableacceesiontable]")[0].innerHTML = "";
            $("[id*=tableacceesiontable]").append("<thead><tr class='alert-info'><th><center>Sr.No</th><th ><center>Prefix</th><th><center>Enter Accession No</th><th ><center>Bill No</th><th ><center>Bill Date(DD MM YYYY)</th><th ><center>MRP(In INR)</th><th ><center>Discount <select id='tbl_dis_book' style='background-color: grey'><option style='color:black'>percent(%)</option><option style='color:black'>price</option></select></th><th ><center>Price</th><th><center>Vendor Details<a class='btn-info btn btn-sm' data-toggle='modal' data-target='#myModal1'><span class='glyphicon glyphicon-plus'></span></a></th><th><center>Registration Date</th><th><center>Purchase Order Date</th><th><center>Order No</th></tr></thead>");


            //var accession = [];

            var count = $("[id*='txtbookcount']")[0].value;
            for (var i = 0; i < parseInt(count) ; i++) {
                if (i == 0) {
                    $("[id*=tableacceesiontable]").append("<tbody>");
                    document.getElementById("divhideshow").style.display = "block";
                }
                var data = parseInt(i) + 1;
                $("[id*=tableacceesiontable]").append("<tr><td>" + data + "</td><td><select id='ddlbookprefix_" + i + "' class='form-control' onchange='criteraichng(this.id);'></select></td><td><input type='text' id='txtbookAccession_" + i + "' style='font-size:12px'/></td><td><input type='text' id='txtbookbillno_" + i + "' style='width:90px'/></td><td><input type='text' id='txtbookbilldate_" + i + "' /></td><td><input type='text' id='txtbookmrp_" + i + "' style='width:80px'/></td><td><input type='text' id='txtbookdiscount_" + i + "' style='width:80px'/></td><td><input type='text' id='txtbookprice_" + i + "' style='width:80px'/></td><td><input type='text' id='txtbookvendordetails_" + i + "' style='font-size:12px'/></td><td><input type='text' id='txtbookregistrationdate_" + i + "' style='font-size:12px'/></td><td><input type='text' id='txt_purchase_orderDate" + i + "' style='font-size:12px'/></td><td><input type='text' id='txtOrderNo" + i + "' style='font-size:12px'/></td></tr>");
                $('[id*=txtbookbilldate]').datetimepicker({
                    singleDatePicker: true,
                    calender_style: "picker_1",
                    timepicker: false,
                    format: 'd-M-Y'
                }, function (start, end, label) {
                    console.log(start.toISOString(), end.toISOString(), label);
                });
                $('[id*=txtbookregistrationdate]').datetimepicker({
                    singleDatePicker: true,
                    calender_style: "picker_1",
                    timepicker: false,
                    format: 'd-M-Y'
                }, function (start, end, label) {
                    console.log(start.toISOString(), end.toISOString(), label);
                });
                $('[id*=txt_purchase_orderDate]').datetimepicker({
                    singleDatePicker: true,
                    calender_style: "picker_1",
                    timepicker: false,
                    format: 'd-M-Y'
                }, function (start, end, label) {
                    console.log(start.toISOString(), end.toISOString(), label);
                });
                ///vendor

                $(function () {

                    var books_arr = [];

                    $.ajax({
                        type: "POST",
                        url: "BookmasterNew.aspx/LoadPublisher",
                        data: '{type:"v",connect:"' + $("[id*='ddlselect']").val() + '"}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (data) {
                            debugger;

                            for (var i = 0; i < data.d.length; i++) {
                                // var val = item[i];
                                var item = data.d[i];
                                var mid = data.d[i];
                                books_arr.push(mid);
                            }
                            // setup autocomplete function pulling from currencies[] array


                            var books = books_arr;

                            $('[id*=txtbookvendordetails]').autocomplete({
                                source: [books]
                            });


                        },
                        error: function () {

                            //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    });




                });
                //prefix


                $.ajax({
                    type: "POST",
                    url: "BookmasterNew.aspx/LoadPrefix",
                    data: '{type:"book",connect:"' + $("[id*='ddlselect']").val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        $("[id^='ddlbookprefix_']").empty().append('<option selected="selected" value="0">--select--</option>');
                        $.each(data.d, function () {
                            $("[id^='ddlbookprefix_']").append($("<option></option>").val(this['Value']).html(this['Text']));
                        });

                    },
                    error: function () {

                        //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                });
            }
        }
            $("[id*=tableacceesiontable]").append("</tbody>");
        
    }
});

function fill_tbl_book_val(i) {

    var j = parseInt(i) - 1;
    if ($("[id*='txtbookAccession_" + j + "']").val() != "") {
        var word = $("[id*='txtbookAccession_" + j + "']").val();
        var myArray = word.split(/[0-9]+/);
        var novalue = word.split(/\D+/);
        if (myArray[0] != "") {
            var value = String(parseInt(novalue[1]) + 1);
            value = app0(novalue[1], value);
        }
        else {
            var value = String(parseInt(novalue[0]) + 1);
            value = app0(novalue[0], value);
        }

        value = myArray[0] + value;
        $("[id*='txtbookAccession_" + i + "']").val(value);
    }
    if ($("[id*='txtbookbillno_" + j + "']").val() != "") {
        var word = $("[id*='txtbookbillno_" + j + "']").val();
        $("[id*='txtbookbillno_" + i + "']").val(word);
    }
    if ($("[id*='txtbookbilldate_" + j + "']").val() != "") {
        var word = $("[id*='txtbookbilldate_" + j + "']").val();
        $("[id*='txtbookbilldate_" + i + "']").val(word);
    }
    if ($("[id*='txtbookmrp_" + j + "']").val() != "") {
        var word = $("[id*='txtbookmrp_" + j + "']").val();
        $("[id*='txtbookmrp_" + i + "']").val(word);
    }
    if ($("[id*='txtbookdiscount_" + j + "']").val() != "") {
        if ($("[id*=tbl_dis_book]").val() == "percent(%)") {

            var word = $("[id*='txtbookdiscount_" + j + "']").val();
            var total = $("[id*='txtbookmrp_" + j + "']").val();
            var discount_value = (total / 100) * word;
            var rate = total - discount_value;
            $("[id*='txtbookdiscount_" + i + "']").val(word);
            $("[id*='txtbookprice_" + i + "']").val(rate);
        }
        else {
            var word = $("[id*='txtbookdiscount_" + j + "']").val();
            var total = $("[id*='txtbookmrp_" + j + "']").val();
          //  var discount_value = (total / 100) * word;
            var rate = total - word;
            $("[id*='txtbookdiscount_" + i + "']").val(word);
            $("[id*='txtbookprice_" + i + "']").val(rate);
        }
    }
    if ($("[id*='txtbookvendordetails" + j + "']").val() != "") {
        var word = $("[id*='txtbookvendordetails" + j + "']").val();
        $("[id*='txtbookvendordetails" + i + "']").val(word);
    }
    if ($("[id*='txtbookregistrationdate" + j + "']").val() != "") {
        var word = $("[id*='txtbookregistrationdate" + j + "']").val();
        $("[id*='txtbookregistrationdate" + i + "']").val(word);
    }
    if ($("[id*='txt_purchase_orderDate" + j + "']").val() != "") {
        var word = $("[id*='txt_purchase_orderDate" + j + "']").val();
        $("[id*='txt_purchase_orderDate" + i + "']").val(word);
    }
    if ($("[id*='txtOrderNo" + j + "']").val() != "") {
        var word = $("[id*='txtOrderNo" + j + "']").val();
        $("[id*='txtOrderNo" + i + "']").val(word);
    }
}

$("#txtbookcount").on('keydown', function (e) {
    if (e.which === 13) {
        event.preventDefault();
        $("#btnnoofbooks").click();


        return false;
    }
});
//Clear_book    
$("[id*='btnnclear']").on("click", function () {
    Clear_book();
   // window.location.reload(true);
});

function Clear_book() {
    localStorage.setItem("auth", "");
    localStorage.setItem("don", "");
    localStorage.setItem("pub", "");

    $("[id*=tableacceesiontable]")[0].innerHTML = "";
    $(".tokens-list-token-holder").remove();
    $("[id*='txtbooktitle']")[0].value = "";
    $("[id*='txtcallno']")[0].value = "";
    $("[id*='txtSubject']")[0].value = "";
    $("[id*='txtkeyword']")[0].value = "";
    $("[id*='txtaccompaningmaterial']")[0].value = "";
    $("[id*='txtpublisher']")[0].value = "";
    $("[id*='txtauthor']")[0].value = "";
    $("[id*='txtbookedition']")[0].value = "";
    $("[id*='txtisbnno']")[0].value = "";
    $("[id*='txtnoofpages']")[0].value = "";
    $("[id*='txtyear']")[0].value = "";
    $("[id*='ddllanguage']").val('--Select--');
    $("[id*='ddlbookcatogary']").val('--Select--');
    $("[id*='ddlbooktype']").val('--Select--');
    $("[id*='ddlbookbound']").val('--Select--');
    $("[id*='txtremark']")[0].value = "";
    $("[id*='txtbookcount']")[0].value = "";
    $("#divhideshow").hide(500);
    $("#book_photo").val('');
    document.getElementById('txtbookcount').disabled = false;
    $("[id*='imgbook']").attr('src', '../../../Assets/img/book_open.png');

    //window.location.reload(true);
};


//$('.commonclass').on('keydown', function (e) {
$("[id*=tableacceesiontable]").on('keydown', 'input[type="text"]', function (e) {
    var id = e.currentTarget.id;
    var sp = id.split('_');
    var int = parseInt(sp[1]) + 1;
    if (e.which === 13) {
        event.preventDefault();
        if ($("[id*=tableacceesiontable]")[0].innerHTML != "") {
            var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
            if (id.startsWith('txtbookAccession_')) {
                var k = 1;
                for (var i = int; i < tds.length; i++) {

                    // String.fromCharCode
                    var word = $("[id*='" + id + "']").val();
                    var myArray = word.split(/[0-9]+/);
                    var novalue = word.split(/\D+/);
                    var value = String(parseInt(novalue[1]) + k);
                    value = app0(novalue[1], value);
                    value = myArray[0] + value;
                    $("[id*='txtbookAccession_" + i + "']").val(value);
                    k++;

                }
            }
            if (id.startsWith('txtbookbillno_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtbookbillno_" + i + "']").val(word);

                }
            }


                if (id.startsWith('txtbookbilldate_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtbookbilldate_" + i + "']").val(word);

                }
            }


                if (id.startsWith('txtbookmrp_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtbookmrp_" + i + "']").val(word);

                }
            }

                if (id.startsWith('txtbookdiscount_')) {
                    int = sp[1];
                    for (var i = int; i < tds.length; i++) {
                        if ($("[id*=tbl_dis_book]").val() == "percent(%)") {

                            var word = $("[id*='" + id + "']").val();
                            var total = $("[id*='txtbookmrp_" + i + "']").val();
                            var discount_value = (total / 100) * word;
                            var rate = total - discount_value;
                            $("[id*='txtbookdiscount_" + i + "']").val(word);
                            $("[id*='txtbookprice_" + i + "']").val(rate);
                        } else {
                            var word = $("[id*='" + id + "']").val();
                            var total = $("[id*='txtbookmrp_" + i + "']").val();
                           // var discount_value = (total / 100) * word;
                            var rate = total - word;
                            $("[id*='txtbookdiscount_" + i + "']").val(word);
                            $("[id*='txtbookprice_" + i + "']").val(rate);
                        }

                    }
                }

                if (id.startsWith('txtbookprice_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtbookprice_" + i + "']").val(word);

                }
                }

                if (id.startsWith('txtbookvendordetails_')) {
                    for (var i = int; i < tds.length; i++) {
                        var word = $("[id*='" + id + "']").val();
                        $("[id*='txtbookvendordetails_" + i + "']").val(word);

                    }
                }

                if (id.startsWith('txtbookregistrationdate_')) {
                    for (var i = int; i < tds.length; i++) {
                        var word = $("[id*='" + id + "']").val();
                        $("[id*='txtbookregistrationdate_" + i + "']").val(word);

                    }
                }
                if (id.startsWith('txt_purchase_orderDate')) {
                    for (var i = int; i < tds.length; i++) {
                        var word = $("[id*='" + id + "']").val();
                        $("[id*='txt_purchase_orderDate" + i + "']").val(word);

                    }
                }
                    if (id.startsWith('txtOrderNo')) {
                        for (var i = int; i < tds.length; i++) {
                            var word = $("[id*='" + id + "']").val();
                            $("[id*='txtOrderNo" + i + "']").val(word);

                        }
            }

        }
    }
});
$("[id*=tableacceesiontable]").on('blur', 'input[type="text"]', function (e) {


    var id = e.currentTarget.id;
    var sp = id.split('_');
    var int = parseInt(sp[1]);
    if ($("[id*=tableacceesiontable]")[0].innerHTML != "") {
        var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');

        if (id.startsWith('txtbookAccession_')) {
            int = sp[1];
            $.ajax({
                type: "POST",
                url: "BookmasterNew.aspx/load_cd_book",
                data: '{accession:"' + $("[id*='txtbookAccession_" + int + "']")[0].value + '",type:"book",connect:"' + $("[id*='ddlselect']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (r) {
                    if (r.d.length > 0) {
                        $("[id*='txtbookAccession_" + int + "']").val('');
                        $.notify("Alert ! Accession already exists.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                },
                error: function () {

                    //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            });
        }
    }

});

function app0(id, value) {
    var z = ""; var d = value;
    if (id.length != d.length) {
        var h = id.length;
        var f = d.length;
        var o = parseInt(h) - parseInt(f);
        for (var j = 0; j < o; j++) {
            z = z + "0";
        }
        value = z + value;
    }
    return value;
}

$("[id*='btngeneraldetails']").on("click", function () {
    saveGeneraldata();

        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/LoadPublisher",
            data: '{type:"p",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d.length > 0) {

                    $('#txtpublisher').tokens({

                        source: r.d,



                    });

                    $('#txt_pub').tokens({

                        source: r.d,



                    });

                    $('#txtpublisher_map').tokens({

                        source: r.d,



                    });
                }
            }
        });




    
        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/LoadPublisher",

            data: '{type:"A",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d.length > 0) {

                    $('#txtauthor').tokens({

                        source: r.d,



                    });
                    $('#txt_auth').tokens({

                        source: r.d,



                    });

                    $('#txtauthor_map').tokens({

                        source: r.d,



                    });

                    $('#txt_author_ebook').tokens({

                        source: r.d,



                    });
                }
            }
        });


   
        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/LoadPublisher",
            data: '{type:"D",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
           async: false,
            success: function (r) {
                if (r.d.length > 0) {

                    $('#txtdonor').tokens({

                        source: r.d,



                    });
                    $('#donar_name').tokens({

                        source: r.d,



                    });

                    $('#txtdonor_map').tokens({

                        source: r.d,



                    });

                }
            }
        });


});

function validateGeneraldata() {
    var retval = true;
    if ($("[id*='txtauthorname']").val() == '') {
        retval = false;
        $("[id*=txtauthorname]").css("border-color", "red");
    }
    else {
        $("[id*=txtauthorname]").css("border-color", "#ccc");
        ret = true;

    }
    if ($("[id*='rdbvendor']").checked == false && $("[id*='rdbpublisher']").checked == false && $("[id*='rdbdonor']").checked == false && $("[id*='rdbauthor']").checked == false) {
        retval = false;
    }
    else {

    }

    return retval;
}
//Insert Author
function saveGeneraldata() {
    if (validateGeneraldata() == true) {
        var generaltype = '';
        if ($("[id*='rdbvendor']")[0].checked == true) {
            generaltype = 'V';
        }
        else if ($("[id*='rdbpublisher']")[0].checked == true) {
            generaltype = 'P';
        }

        else if ($("[id*='rdbdonor']")[0].checked == true) {
            generaltype = 'D'
        }
        else if ($("[id*='rdbauthor']")[0].checked == true) {
            generaltype = 'A';
        }
        else {

        }
        var loc="";
        if (document.getElementById('rdbauthor').checked == true) {
            loc = $("[id*='ddltype']").val();
        }
        else {
            loc = $("[id*='txtauthorLocation']").val();
        }
        // return generaltype;


        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/AuthorInsert",
            data: '{generalid:"",generaltype:"' + generaltype + '",generalname:"' + $("[id*='txtauthorname']").val() + '",contact1:"' + $("[id*='txtauthormobileno']").val() + '",contact2:"",email:"' + $("[id*='txtauthorEmailid']").val() + '",location:"' + loc + '",address:"' + $("[id*='txtauthoraddress']").val() + '",not_in_use:"",userid:"",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (r) {
                if (r.d == true) {
                    $.notify("Data Save Successfully!!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                    $("[id*='myModal1']").modal("hide");
                    if(generaltype != 'V')
                    {
                    window.location.reload();
                }
                    clearmodalgeneraldetails();
                    var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
                    if (tds.length > 0) {
                        $(function () {

                            var books_arr = [];

                            $.ajax({
                                type: "POST",
                                url: "BookmasterNew.aspx/LoadPublisher",
                                data: '{type:"v",connect:"' + $("[id*='ddlselect']").val() + '"}',
                                contentType: "application/json; charset=utf-8",
                                async: false,
                                success: function (data) {
                                    debugger;

                                    for (var i = 0; i < data.d.length; i++) {
                                        // var val = item[i];
                                        var item = data.d[i];
                                        var mid = data.d[i];
                                        books_arr.push(mid);
                                    }
                                    // setup autocomplete function pulling from currencies[] array


                                    var books = books_arr;

                                    $('[id*=txtbookvendordetails]').autocomplete({
                                        source: [books]
                                    });


                                },
                                error: function () {

                                    //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                }
                            });




                        });
                    }
                }
                else {
                    $.notify("No Data Save!!!", { color: "#fff", background: "#20b2aa", blur: 0.2, delay: 0 });
                }
            }
        });
        
    }
}

$( 'input[name="Author"]:radio' ).on('change', function(e) {
//$("#Author").on('change', function (e) {
    if (document.getElementById('rdbauthor').checked == true)
    {

        document.getElementById("ddltype").disabled = false;
        document.getElementById("txtauthorLocation").disabled = true;
    }
else
    {

        document.getElementById("ddltype").disabled = true;
        document.getElementById("txtauthorLocation").disabled = false;
}
});


$("[id*=tableacceesiontable]").on('blur', 'input[type="text"]', function (e) {
    var id = e.currentTarget.id;
    var sp = id.split('_');
    var int = parseInt(sp[1]) + 1;
    if ($("[id*=tableacceesiontable]")[0].innerHTML != "") {
        var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');


        if (id.startsWith('txtbookdiscount_')) {
            int = sp[1];
            if ($("[id*=tbl_dis]").val() == "percent(%)") {
                var word = $("[id*='" + id + "']").val();
                var total = $("[id*='txtbookmrp_" + int + "']").val();
                var discount_value = (total / 100) * word;
                var rate = total - discount_value;
                $("[id*='txtbookdiscount_" + int + "']").val(word);
                $("[id*='txtbookprice_" + int + "']").val(rate);
            }
            else {
                var word = $("[id*='" + id + "']").val();
                var total = $("[id*='txtbookmrp_" + int + "']").val();
              //  var discount_value = (total / 100) * word;
                var rate = total - word;
                $("[id*='txtbookdiscount_" + int + "']").val(word);
                $("[id*='txtbookprice_" + int + "']").val(rate);
            }
        }
    }
});

//Number Validation

function isNumberKey(evt, obj) {


    var charCode = (evt.which) ? evt.which : event.keyCode
    var value = obj.value;
    var dotcontains = value.indexOf(".") != -1;
    if (dotcontains)
        if (charCode == 46) return false;
    if (charCode == 46) return true;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
//save book
$("[id*='btnnsave']").on("click", function () {
   
    if (localStorage.getItem("auth").toString() != "") {
        if ($("[id*='txtauthor']").val() == localStorage.getItem("auth").toString()) {
            str = $("[id*='txtauthor']").val();
        }
        else {

            if ($("[id*='txtauthor']").val().indexOf(localStorage.getItem("auth").toString()) > -1) {
                str = $("[id*='txtauthor']").val();
            }
            else {

                str = $("[id*='txtauthor']").val() + "| " + localStorage.getItem("auth").toString();

            }
            // str = $("[id*='txtauthor_map']").val() + "| " + localStorage.getItem("auth").toString();

        }
    }
    else {
        str = $("[id*='txtauthor']").val();
      

    }

    var str_rp = str.replace("| |", "|");
    var str_rp1 = str_rp.replace("||", "|");
    var auth_final = str_rp1.trim();


    var str_pub = "";
    if (localStorage.getItem("pub").toString() != "") {
        if ($("[id*='txtpublisher']").val() == localStorage.getItem("pub").toString()) {

            str_pub = $("[id*='txtpublisher']").val();

        }
        else {

            if ($("[id*='txtpublisher']").val().indexOf(localStorage.getItem("pub").toString()) > -1) {
                str_pub = $("[id*='txtpublisher']").val();

            }
            else {

                str_pub = $("[id*='txtpublisher']").val() + "| " + localStorage.getItem("pub").toString();


            }
            // str_pub = $("[id*='txtpublisher_map']").val() + "| " + localStorage.getItem("pub").toString();


        }

    }
    else {
        str_pub = $("[id*='txtpublisher']").val();

    }

    var str_pub_rp = str_pub.replace("| |", "|");
    var str_pub_rp1 = str_pub_rp.replace("||", "|");
    var pub_final = str_pub_rp1.trim();



    var str_don = "";
    if (localStorage.getItem("don").toString() != "") {
        str_don = $("[id*='txtdonor']").val() + "| " + localStorage.getItem("don").toString();
        if ($("[id*='txtdonor']").val() == localStorage.getItem("don").toString()) {

            str_don = $("[id*='txtdonor']").val();
        }
        else {
            if ($("[id*='txtdonor']").val().indexOf(localStorage.getItem("don").toString()) > -1) {
                str_don = $("[id*='txtdonor']").val();


            }
            else {

                str_don = $("[id*='txtdonor']").val() + "| " + localStorage.getItem("don").toString();


            }
            // str_don = $("[id*='txtdonor_map']").val() + "| " + localStorage.getItem("don").toString();



        }
    }
    else {
        str_don = $("[id*='txtdonor']").val();

    }

    var str_don_rp = str_don.replace("| |", "|");
    var str_don_rp1 = str_don_rp.replace("||", "|");

    var donor_final = str_don_rp1.trim();


    if ($("[id*='ddlbooktype']").val() == "FOR ISSUE") {
        cd_rd = "1";
    } else { cd_rd = "0"; }
    var accession_book = [];
    var ins = "";
    var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
    var accession = "";
    for (var i = 0; i < tds.length; i++) {
        if(accession ==""){
            accession = $("[id*='txtbookAccession_" + i + "']").val();
        }
        else{
            accession = accession + "','" + $("[id*='txtbookAccession_" + i + "']").val();
        }
    }
    if($("[id*='txtbooktitlee']").val() !="" && auth_final !="")
        {
    var res = books_arr.indexOf($("[id*='txtbooktitlee']").val().trim());
        if (res > -1) {


        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/CheckAlready",
            data: '{booktitle:"' + $("[id*='txtbooktitlee']").val() + '",edition:"' + $("[id*='txtbookedition']").val() + '",author:"' + $("[id*='txtauthor']").val() + '",publisher:"' + $("[id*='txtpublisher']").val() + '",accession:"' + accession + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                if (data.d.length>0) {
                    if (data.d[0].id=="1") {
                        //if (se_book_id != "") {
                        //    if (se_book_id.includes(",")) {
            
                        //        if ($("[id*=tableacceesiontable]")[0].innerHTML != "") {
                        //            var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
                        //            var gen_id = [];
                        //            gen_id = se_book_id.split(",");
                        //            for (var k = 0; k < gen_id.length; k++) {
                        //                for (var i = 0; i < tds.length; i++) {
                        //                    accession_book.push($("[id*='txtbookAccession_" + i + "']").val());
                        //                    if (gen_id[k].toUpperCase() == $("[id*='txtbookAccession_" + i + "']").val().toUpperCase()) {
                                    
                        //                        ins = ins + "update lib_book_master  set title=N'" + $("[id*='txtbooktitlee']").val().trim() + "', author=N'" + auth_final + "', NOOFPAGES='" + $("[id*='txtnoofpages']").val() + "',BOUND='" + $("[id*='ddlbookbound']").val() + "',ISBN='" + $("[id*='txtisbnno']").val() + "',LANG=N'" + $("[id*='ddllanguage']").val() + "',ISSUE_TYPE='" + $("[id*='ddlbooktype']").val() + "',KEYWORD=N'" + $("[id*='txtkeyword']").val() + "',PUBLISHER=N'" + pub_final + "',YEAR='" + $("[id*='txtyear']").val() + "',ACC_MATERIALS=N'" + $("[id*='txt_acc_mat']").val() + "',REMARK=N'" + $("[id*='txtremark']").val() + "',DONOR_ID=N'" + donor_final + "',ACCESSION_NO='" + $("[id*='txtbookAccession_" + i + "']").val() + "',BILL_NO='" + $("[id*='txtbookbillno_" + i + "']").val() + "',BILL_DT='" + $("[id*='txtbookbilldate_" + i + "']").val() + "',MRP='" + $("[id*='txtbookmrp_" + i + "']").val() + "',DISCOUNT='" + $("[id*='txtbookdiscount_" + i + "']").val() + "',Discount_type='" + $("[id*='tbl_dis_book']").val() + "',PRICE='" + $("[id*='txtbookprice_" + i + "']").val() + "',VENDOR=N'" + $("[id*='txtbookvendordetails_" + i + "']").val() + "',REG_DT='" + $("[id*='txtbookregistrationdate_" + i + "']").val() + "',PURCHASE_DATE='" + $("[id*='txt_purchase_orderDate" + i + "']").val() + "',ORDER_NO='" + $("[id*='txtOrderNo" + i + "']").val() + "'  where ACCESSION_NO in ('" + gen_id[k] + "');";
                        //                    }
                        //                }
                        //            }
                        //            //    ins = ins + "update lib_cd_master  set NOOFPAGES='" + $("[id*='txtnoofpages']").val() + "',BOUND='" + $("[id*='ddlbookbound']").val() + "',ISBN='" + $("[id*='txtisbnno']").val() + "',LANG='" + $("[id*='ddllanguage']").val() + "',ISSUE_TYPE='" + cd_rd + "',KEYWORD='" + $("[id*='txtkeyword']").val() + "',PUBLISHER='" + pub_final + "',YEAR='" + $("[id*='txtyear']").val() + "',ACC_MATERIALS='" + $("[id*='txt_acc_mat']").val() + "',REMARK='" + $("[id*='txtremark']").val() + "',DONOR_ID='" + donor_final + "',ACCESSION_NO='" + $("[id*='txtbookAccession_" + i + "']").val() + "',txtbookbillno_='" + $("[id*='txtbillno_" + i + "']").val() + "',txtbookbilldate_='" + $("[id*='txtbilldt_" + i + "']").val() + "',txtbookmrp_='" + $("[id*='txtmrp_" + i + "']").val() + "',DISCOUNT='" + $("[id*='txtbookdiscount_" + i + "']").val() + "',PRICE='" + $("[id*='txtbookprice_" + i + "']").val() + "',VENDOR='" + $("[id*='txtvendet_" + i + "']").val() + "',REG_DT='" + $("[id*='txtbookregistrationdate_" + i + "']").val() + "' where ACCESSION_NO in ('" + se_book_id + "');";
                        //            //}
                        //        }
               
                        //    }
                        //    else {
                        //        var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');

                        //        for (var i = 0; i < tds.length; i++) {
                        //            accession_book.push($("[id*='txtbookAccession_" + i + "']").val());
                        //            ins += "update lib_book_master  set title=N'" + $("[id*='txtbooktitlee']").val().trim() + "',author=N'" + auth_final + "', NOOFPAGES='" + $("[id*='txtnoofpages']").val() + "',BOUND='" + $("[id*='ddlbookbound']").val() + "',ISBN='" + $("[id*='txtisbnno']").val() + "',LANG=N'" + $("[id*='ddllanguage']").val() + "',ISSUE_TYPE='" + $("[id*='ddlbooktype']").val() + "',KEYWORD=N'" + $("[id*='txtkeyword']").val() + "',PUBLISHER=N'" + pub_final + "',YEAR='" + $("[id*='txtyear']").val() + "',ACC_MATERIALS=N'" + $("[id*='txt_acc_mat']").val() + "',REMARK=N'" + $("[id*='txtremark']").val() + "',DONOR_ID=N'" + donor_final + "',ACCESSION_NO='" + $("[id*='txtbookAccession_" + i + "']").val() + "',BILL_NO='" + $("[id*='txtbookbillno_" + i + "']").val() + "',BILL_DT='" + $("[id*='txtbookbilldate_" + i + "']").val() + "',MRP='" + $("[id*='txtbookmrp_" + i + "']").val() + "',DISCOUNT='" + $("[id*='txtbookdiscount_" + i + "']").val() + "',Discount_type='" + $("[id*='tbl_dis_book']").val() + "',PRICE='" + $("[id*='txtbookprice_" + i + "']").val() + "',VENDOR=N'" + $("[id*='txtbookvendordetails_" + i + "']").val() + "',REG_DT='" + $("[id*='txtbookregistrationdate_" + i + "']").val() + "',PURCHASE_DATE='" + $("[id*='txt_purchase_orderDate" + i + "']").val() + "',ORDER_NO='" + $("[id*='txtOrderNo" + i + "']").val() + "' where ACCESSION_NO in ('" + se_book_id + "');";
                        //        }
                        //    }

                        //}
                    
                        //else {
                            var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');

                            for (var i = 0; i < tds.length; i++) {
                                accession_book.push($("[id*='txtbookAccession_" + i + "']").val());
                                ins += "update lib_book_master  set title=N'" + $("[id*='txtbooktitlee']").val().trim() + "',author=N'" + auth_final + "', NOOFPAGES='" + $("[id*='txtnoofpages']").val() + "',EDITION='" + $("[id*='txtbookedition']").val().trim() + "', CALLNO='" + $("[id*='txtcallno']").val().trim() + "',BOUND='" + $("[id*='ddlbookbound']").val() + "',ISBN='" + $("[id*='txtisbnno']").val() + "',LANG=N'" + $("[id*='ddllanguage']").val() + "',ISSUE_TYPE='" + $("[id*='ddlbooktype']").val() + "',KEYWORD=N'" + $("[id*='txtkeyword']").val() + "',PUBLISHER=N'" + pub_final + "',YEAR='" + $("[id*='txtyear']").val() + "',ACC_MATERIALS=N'" + $("[id*='txtaccompaningmaterial']").val().trim().replace("'", "''") + "',SUBJ=N'" + $("[id*='txtSubject']").val().trim().replace("'", "''") + "',REMARK=N'" + $("[id*='txtremark']").val() + "',DONOR_ID=N'" + donor_final + "',ACCESSION_NO='" + $("[id*='txtbookAccession_" + i + "']").val() + "',BILL_NO='" + $("[id*='txtbookbillno_" + i + "']").val() + "'";
                                if ($("[id*='txtbookbilldate_" + i + "']").val() == "") {
                                    ins += ", BILL_DT = null";
                                }
                                else {
                                    ins += ", BILL_DT = convert(date, '" + $("[id*='txtbookbilldate_" + i + "']").val() + "', 105)";
                                }
                                ins += ", MRP = '" + $("[id*='txtbookmrp_" + i + "']").val() + "', DISCOUNT = '" + $("[id*='txtbookdiscount_" + i + "']").val() + "', Discount_type = '" + $("[id*='tbl_dis_book']").val() + "', PRICE = '" + $("[id*='txtbookprice_" + i + "']").val() + "', VENDOR = N'" + $("[id*='txtbookvendordetails_" + i + "']").val() + "'";
                                if ($("[id*='txtbookregistrationdate_" + i + "']").val() == "") {
                                    ins += ", REG_DT = null";
                                }
                                else {
                                    ins += ", REG_DT = convert(date, '" + $("[id*='txtbookregistrationdate_" + i + "']").val() + "', 105)";
                                }
                                if ($("[id*='txt_purchase_orderDate" + i + "']").val() == "") {
                                    ins += ", PURCHASE_DATE = null";
                                }
                                else {
                                    ins += ", PURCHASE_DATE = convert(date, '" + $("[id*='txt_purchase_orderDate" + i + "']").val() + "', 105)";
                                }
                                ins+=", ORDER_NO = '" + $("[id*='txtOrderNo" + i + "']").val() + "' where ACCESSION_NO = '" + $("[id*='txtbookAccession_" + i + "']").val() + "'";
                           }
                        //    //ins = "update lib_book_master  set NOOFPAGES='" + $("[id*='txtnoofpages']").val() + "',BOUND='" + $("[id*='ddlbookbound']").val() + "',ISBN='" + $("[id*='txtisbnno']").val() + "',LANG='" + $("[id*='ddllanguage']").val() + "',ISSUE_TYPE='" + cd_rd + "',KEYWORD='" + $("[id*='txtkeyword']").val() + "',PUBLISHER='" + pub_final + "',YEAR='" + $("[id*='txtyear']").val() + "',ACC_MATERIALS='" + $("[id*='txtaccompaningmaterial']").val() + "',REMARK='" + $("[id*='txtremark']").val() + "',DONOR_ID='" + donor_final + "' where TITLE=N'" + se_book_name + "';";
                        //}
                    }
                    else {
                        if (validatebook() == true) {
                            if ($("[id*=tableacceesiontable]")[0].innerHTML != "") {
                                var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
                                for (var i = 0; i < tds.length; i++) {
                                    accession_book.push($("[id*='txtbookAccession_" + i + "']").val());
                                    //var vendor_name = ""; var vendor_id = "";
                                    //var d = $("[id*='txtbookvendordetails_" + i + "']").val();
                                    //d = d.split(',');

                                    //for (var j = 0; j < d.length; j++) {
                                    //    if (vendor_name == "") {
                                    //        vendor_name = d[j];
                                    //    }
                                    //    else {
                                    //        vendor_name = vendor_name + "','" + d[j].trim();
                                    //    }
                                    //}
                                    // vendor_id = "(select general_id from ll_general_master where general_name in ('" + vendor_name + "') and general_type='V')";

                                    if ($("[id*='txtbookAccession_" + i + "']").val() != "") {
                                        ins = ins + "insert into lib_book_master values(N'" + $("[id*='txtbooktitlee']").val() + "',N'" + auth_final + "', '" + $("[id*='txtbookedition']").val() + "',N'" + pub_final + "','" + $("[id*='txtcallno']").val() + "','" + $("[id*='txtisbnno']").val() + "',N'" + $("[id*='ddllanguage']").val() + "',N'" + $("[id*='txtkeyword']").val() + "','" + $("[id*='txtyear']").val() + "', '" + $("[id*='txtnoofpages']").val() + "',N'" + $("[id*='txtSubject']").val() + "',N'" + $("[id*='txtremark']").val() + "',N'" + $("[id*='txtaccompaningmaterial']").val() + "','" + $("[id*='ddlbookcatogary']").val() + "','" + $("[id*='ddlbooktype']").val() + "','" + $("[id*='ddlbookbound']").val() + "',N'" + donor_final + "','" + $("[id*='txtbookAccession_" + i + "']").val().toUpperCase() + "','" + $("[id*='txtbookbillno_" + i + "']").val() + "'";
                                        if ($("[id*='txtbookbilldate_" + i + "']").val() == "") {
                                            ins = ins + ",null";
                                        }
                                        else {
                                            ins += ", convert(date, '" + $("[id*='txtbookbilldate_" + i + "']").val() + "', 105)";
                                        }

                                        ins += ",'" + $("[id*='txtbookmrp_" + i + "']").val() + "', '" + $("[id*='txtbookdiscount_" + i + "']").val() + "', '" + $("[id*='tbl_dis_book']").val() + "', '" + $("[id*='txtbookprice_" + i + "']").val() + "', N'" + $("[id*='txtbookvendordetails_" + i + "']").val() + "'";
                                        if ($("[id*='txtbookregistrationdate_" + i + "']").val() == "") {
                                            ins = ins + ",null";
                                        }
                                        else {
                                            ins += ", convert(date, '" + $("[id*='txtbookregistrationdate_" + i + "']").val() + "', 105)";
                                        }
                                        if ($("[id*='txt_purchase_orderDate" + i + "']").val() == "") {
                                            ins = ins + ",null";
                                        }
                                        else {
                                            ins += ", convert(date, '" + $("[id*='txt_purchase_orderDate" + i + "']").val() + "', 105)";
                                        }
                                        ins+=", '" + $("[id*='txtOrderNo" + i + "']").val() + "', '" + empId + "', getdate(), '', 0, '')";
                                    }
                                    else {
                                        $.notify("Enter Acession No.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                    }
                                }
                            }
                        }
                    }
                }
            },
        });



    }
        else if (res == -1) {

            $.ajax({
                type: "POST",
                url: "BookmasterNew.aspx/CheckAlready",
                data: '{booktitle:"' + $("[id*='txtbooktitlee']").val().trim().replace("'", "''") + '",edition:"' + $("[id*='txtbookedition']").val().trim() + '",author:"' + $("[id*='txtauthor']").val().replace("'", "''") + '",publisher:"' + $("[id*='txtpublisher']").val().replace("'", "''") + '",accession:"' + accession + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    if (data.d[0].id == "1") {

                        var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');

                        for (var i = 0; i < tds.length; i++) {
                            accession_book.push($("[id*='txtbookAccession_" + i + "']").val());
                            ins += "update lib_book_master  set title=N'" + $("[id*='txtbooktitlee']").val().trim() + "',author=N'" + auth_final + "', NOOFPAGES='" + $("[id*='txtnoofpages']").val() + "',EDITION='" + $("[id*='txtbookedition']").val().trim() + "', CALLNO='" + $("[id*='txtcallno']").val().trim() + "',BOUND='" + $("[id*='ddlbookbound']").val() + "',ISBN='" + $("[id*='txtisbnno']").val() + "',LANG=N'" + $("[id*='ddllanguage']").val() + "',ISSUE_TYPE='" + $("[id*='ddlbooktype']").val() + "',KEYWORD=N'" + $("[id*='txtkeyword']").val() + "',PUBLISHER=N'" + pub_final + "',YEAR='" + $("[id*='txtyear']").val() + "',ACC_MATERIALS=N'" + $("[id*='txtaccompaningmaterial']").val().trim().replace("'", "''") + "',SUBJ=N'" + $("[id*='txtSubject']").val().trim().replace("'", "''") + "',REMARK=N'" + $("[id*='txtremark']").val() + "',DONOR_ID=N'" + donor_final + "',ACCESSION_NO='" + $("[id*='txtbookAccession_" + i + "']").val() + "',BILL_NO='" + $("[id*='txtbookbillno_" + i + "']").val() + "'";
                            if ($("[id*='txtbookbilldate_" + i + "']").val() == "") {
                                ins += ", BILL_DT = null";
                            }
                            else {
                                ins += ", BILL_DT = convert(date, '" + $("[id*='txtbookbilldate_" + i + "']").val() + "', 105)";
                            }
                            ins += ", MRP = '" + $("[id*='txtbookmrp_" + i + "']").val() + "', DISCOUNT = '" + $("[id*='txtbookdiscount_" + i + "']").val() + "', Discount_type = '" + $("[id*='tbl_dis_book']").val() + "', PRICE = '" + $("[id*='txtbookprice_" + i + "']").val() + "', VENDOR = N'" + $("[id*='txtbookvendordetails_" + i + "']").val() + "'";
                            if ($("[id*='txtbookregistrationdate_" + i + "']").val() == "") {
                                ins += ", REG_DT = null";
                            }
                            else {
                                ins += ", REG_DT = convert(date, '" + $("[id*='txtbookregistrationdate_" + i + "']").val() + "', 105)";
                            }
                            if ($("[id*='txt_purchase_orderDate" + i + "']").val() == "") {
                                ins += ", PURCHASE_DATE = null";
                            }
                            else {
                                ins += ", PURCHASE_DATE = convert(date, '" + $("[id*='txt_purchase_orderDate" + i + "']").val() + "', 105)";
                            }
                            ins+=", ORDER_NO = '" + $("[id*='txtOrderNo" + i + "']").val() + "' where ACCESSION_NO = '" + $("[id*='txtbookAccession_" + i + "']").val() + "'";
                        }
                    }


                    else {
                        if (validatebook() == true) {
                            if ($("[id*=tableacceesiontable]")[0].innerHTML != "") {
                                var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
                                for (var i = 0; i < tds.length; i++) {
                                    accession_book.push($("[id*='txtbookAccession_" + i + "']").val());
                                    //var vendor_name = ""; var vendor_id = "";
                                    //var d = $("[id*='txtbookvendordetails_" + i + "']").val();
                                    //d = d.split(',');

                                    //for (var j = 0; j < d.length; j++) {
                                    //    if (vendor_name == "") {
                                    //        vendor_name = d[j];
                                    //    }
                                    //    else {
                                    //        vendor_name = vendor_name + "','" + d[j].trim();
                                    //    }
                                    //}
                                    // vendor_id = "(select general_id from ll_general_master where general_name in ('" + vendor_name + "') and general_type='V')";

                                    if ($("[id*='txtbookAccession_" + i + "']").val() != "") {
                                        ins = ins + "insert into lib_book_master values(N'" + $("[id*='txtbooktitlee']").val() + "',N'" + auth_final + "', '" + $("[id*='txtbookedition']").val() + "',N'" + pub_final + "','" + $("[id*='txtcallno']").val() + "','" + $("[id*='txtisbnno']").val() + "',N'" + $("[id*='ddllanguage']").val() + "',N'" + $("[id*='txtkeyword']").val() + "','" + $("[id*='txtyear']").val() + "', '" + $("[id*='txtnoofpages']").val() + "',N'" + $("[id*='txtSubject']").val() + "',N'" + $("[id*='txtremark']").val() + "',N'" + $("[id*='txtaccompaningmaterial']").val() + "','" + $("[id*='ddlbookcatogary']").val() + "','" + $("[id*='ddlbooktype']").val() + "','" + $("[id*='ddlbookbound']").val() + "',N'" + donor_final + "','" + $("[id*='txtbookAccession_" + i + "']").val().toUpperCase() + "','" + $("[id*='txtbookbillno_" + i + "']").val() + "'";
                                        if ($("[id*='txtbookbilldate_" + i + "']").val() == "") {
                                            ins = ins + ",null";
                                        }
                                        else {
                                            ins += ", convert(date, '" + $("[id*='txtbookbilldate_" + i + "']").val() + "', 105)";
                                        }
                                        ins += ", '" + $("[id*='txtbookmrp_" + i + "']").val() + "', '" + $("[id*='txtbookdiscount_" + i + "']").val() + "', '" + $("[id*='tbl_dis_book']").val() + "', '" + $("[id*='txtbookprice_" + i + "']").val() + "', N'" + $("[id*='txtbookvendordetails_" + i + "']").val() + "'";
                                        if ($("[id*='txtbookregistrationdate_" + i + "']").val() == "") {
                                            ins = ins + ",null";
                                        }
                                        else {
                                            ins += ", convert(date, '" + $("[id*='txtbookregistrationdate_" + i + "']").val() + "', 105)";
                                        }
                                        if ($("[id*='txt_purchase_orderDate" + i + "']").val() == "") {
                                            ins = ins + ",null";
                                        }
                                        else {
                                            ins += ", convert(date, '" + $("[id*='txt_purchase_orderDate" + i + "']").val() + "', 105)";
                                        }
                                        ins+=", '" + $("[id*='txtOrderNo" + i + "']").val() + "', '" + empId + "', getdate(), '', 0, '')";
                                    }
                                    else {
                                        $.notify("Enter Acession No.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                    }
                                }
                            }
                        }
                    }
                }

            });




        //if (validatebook() == true) {
        //    if ($("[id*=tableacceesiontable]")[0].innerHTML != "") {
        //        var tds = document.querySelectorAll('[id*=tableacceesiontable] tbody tr');
        //        for (var i = 0; i < tds.length; i++) {
        //            accession_book.push($("[id*='txtbookAccession_" + i + "']").val());
        //            //var vendor_name = ""; var vendor_id = "";
        //            //var d = $("[id*='txtbookvendordetails_" + i + "']").val();
        //            //d = d.split(',');

        //            //for (var j = 0; j < d.length; j++) {
        //            //    if (vendor_name == "") {
        //            //        vendor_name = d[j];
        //            //    }
        //            //    else {
        //            //        vendor_name = vendor_name + "','" + d[j].trim();
        //            //    }
        //            //}
        //            // vendor_id = "(select general_id from ll_general_master where general_name in ('" + vendor_name + "') and general_type='V')";
                    
        //            if ($("[id*='txtbookAccession_" + i + "']").val() != "") {
        //                ins = ins + "insert into lib_book_master values(N'" + $("[id*='txtbooktitlee']").val() + "',N'" + auth_final + "', '" + $("[id*='txtbookedition']").val() + "',N'" + pub_final + "','" + $("[id*='txtcallno']").val() + "','" + $("[id*='txtisbnno']").val() + "','" + $("[id*='ddllanguage']").val() + "',N'" + $("[id*='txtkeyword']").val() + "','" + $("[id*='txtyear']").val() + "', '" + $("[id*='txtnoofpages']").val() + "',N'" + $("[id*='txtSubject']").val() + "',N'" + $("[id*='txtremark']").val() + "',N'" + $("[id*='txtaccompaningmaterial']").val() + "','" + $("[id*='ddlbookcatogary']").val() + "','" + $("[id*='ddlbooktype']").val() + "','" + $("[id*='ddlbookbound']").val() + "',N'" + donor_final + "','" + $("[id*='txtbookAccession_" + i + "']").val().toUpperCase() + "','" + $("[id*='txtbookbillno_" + i + "']").val() + "','" + $("[id*='txtbookbilldate_" + i + "']").val() + "','" + $("[id*='txtbookmrp_" + i + "']").val() + "','" + $("[id*='txtbookdiscount_" + i + "']").val() + "','" + $("[id*='tbl_dis_book']").val() + "','" + $("[id*='txtbookprice_" + i + "']").val() + "',N'" + $("[id*='txtbookvendordetails_" + i + "']").val() + "','" + $("[id*='txtbookregistrationdate_" + i + "']").val() + "','" + $("[id*='txt_purchase_orderDate" + i + "']").val() + "','" + $("[id*='txtOrderNo" + i + "']").val() + "','" + empId + "',getdate(),'',0,'')";
        //            }
        //            else {
        //                $.notify("Enter Acession No.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
        //            }



        //        }
        //    }
        //}
    }
    $.ajax({
        type: "POST",
        url: "BookmasterNew.aspx/saveData",
        data: '{qry:"' + ins + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            if (r.d == true) {
                Bookuploadpic(accession_book);
                Clear_book();
                $(function () {
                    $.ajax({
                        type: "POST",
                        url: "BookmasterNew.aspx/Get_book_Title",
                        data: '{type:"book",connect:"' + $("[id*='ddlselect']").val() + '"}',
                        contentType: "application/json; charset=utf-8",
                        aync: false,
                        success: function (data) {
                            debugger;

                            for (var i = 0; i < data.d.length; i++) {
                                // var val = item[i];
                                var item = data.d[i].id;
                                var mid = data.d[i].title;
                                books_arr.push(mid);
                            }
                            // setup autocomplete function pulling from currencies[] array


                            var books = books_arr;

                            $('#txtbooktitlee').autocomplete({
                                source: [books]
                            });
                        },
                        error: function () {

                            //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    });
                });
                $.notify("Data Saved successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                window.location.reload(true);
              
            }
            else {
                $.notify("Error ! Error Occured , please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        }
    });
} 
    else {

        $.notify("Fill All The Fields.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

}

});

$("#txtbooktitlee").on('keydown', function (e) {

    if (e.which === 13) {
        event.preventDefault();
        se_book_id = "";
        se_book_name = $("[id*='txtbooktitlee']").val();
        LoadBook("", $("[id*='txtbooktitlee']").val());
       
    }
});

$("#txtbooksearch").on('keydown', function (e) {

    if (e.which === 13) {
        event.preventDefault();
        se_book_id = $("[id*='txtbooksearch']").val();
        se_book_name = "";
        LoadBook($("[id*='txtbooksearch']").val(),"");
    }
});

//Retrive Data
function LoadBook(bookid,book_name) {
    $.ajax({
        type: "POST",
        url: "BookmasterNew.aspx/get_cd_data",
        data: '{cd:"' + bookid + '",cd_name:"' + book_name + '",type:"book",connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            if (r.d.length > 0) {
                if (r.d[0].cd_msg == "get") {
                    $(".tokens-list-token-holder").remove();

                //$("[id*='bookid']").val(bookid);
                $("[id*='txtbooktitlee']").val(r.d[0].cd_TITLE);
                //$("[id*='txtauthor']").val(r.d[0].cd_AUTHOR);
                $("[id*='txtbookedition']").val(r.d[0].bookedition);
                localStorage.setItem("auth", r.d[0].cd_AUTHOR);
                $("[id*='txtauthor']").val(r.d[0].cd_AUTHOR);

                localStorage.setItem("pub", r.d[0].cd_PUBLISHER);

                $("[id*='txtpublisher']").val(r.d[0].cd_PUBLISHER);

                localStorage.setItem("don", r.d[0].cd_DONOR_ID);

                $("[id*='txtdonor']").val(r.d[0].cd_DONOR_ID);


                var aa = $(".tokens-token-list");
                for (var i = 0; i <= aa.length - 1; i++) {
                    if (aa[i].nextElementSibling.id == "txtauthor") {

                        var arr = r.d[0].cd_AUTHOR.split('|');
                        for (var y = 0; y <= arr.length - 1; y++) {
                            if (arr[y] != "") {
                                var li = document.createElement("li");
                                li.setAttribute("class", "tokens-list-token-holder");
                                li.setAttribute("onClick", "removeItem_book(this);");
                                var p = document.createElement("p");

                                //p.setAttribute("innerHTML", 'abc');
                                p.textContent = arr[y];
                                li.append(p);

                                var span = document.createElement("span");
                                span.setAttribute("class", "tokens-delete-token");

                                // span.setAttribute("innerHTML", 'x');
                                span.textContent = 'x';

                                li.append(span);



                                aa[i].prepend(li);
                            }

                        }

                    }


                    else if (aa[i].nextElementSibling.id == "txtpublisher") {

                        var arr = r.d[0].cd_PUBLISHER.split('|');
                        for (var y = 0; y <= arr.length - 1; y++) {
                            if (arr[y] != "") {
                                var li = document.createElement("li");
                                li.setAttribute("class", "tokens-list-token-holder");
                                li.setAttribute("onClick", "removeItem_book(this);");
                                var p = document.createElement("p");

                                //p.setAttribute("innerHTML", 'abc');
                                p.textContent = arr[y];
                                li.append(p);

                                var span = document.createElement("span");
                                span.setAttribute("class", "tokens-delete-token");

                                // span.setAttribute("innerHTML", 'x');
                                span.textContent = 'x';

                                li.append(span);



                                aa[i].prepend(li);
                            }

                        }

                    }

                    else {
                        var arr = r.d[0].cd_DONOR_ID.split('|');
                        for (var y = 0; y <= arr.length - 1; y++) {
                            if (arr[y] != "") {
                                var li = document.createElement("li");
                                li.setAttribute("class", "tokens-list-token-holder");
                                li.setAttribute("onClick", "removeItem_book(this);");
                                var p = document.createElement("p");

                                //p.setAttribute("innerHTML", 'abc');
                                p.textContent = arr[y];
                                li.append(p);

                                var span = document.createElement("span");
                                span.setAttribute("class", "tokens-delete-token");

                                // span.setAttribute("innerHTML", 'x');
                                span.textContent = 'x';

                                li.append(span);



                                aa[i].prepend(li);

                            }
                        }
                    }

                }
                    var b = imageExists("../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".jpg");
                    var b1 = imageExists("../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".jpeg");
                    var b2 = imageExists("../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".png");
                    var b3 = imageExists("../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".gif");

                if (b == true) {
                    document.getElementById("imgbook").src = "../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".jpg";
                }
                else if (b1 == true) {
                    document.getElementById("imgbook").src = "../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".jpeg";
                }
                else if (b2 == true) {
                    document.getElementById("imgbook").src = "../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".png";
                }
                else if (b3 == true) {
                    document.getElementById("imgbook").src = "../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".gif";
                }

                if (b == false && b1 == false && b2 == false && b3 == false)
                {
                    $("#book_photo").val('');
                    $("[id*='imgbook']").attr('src', '../../../Assets/img/book_open.png');
                }

               // $("[id*='txtpublisher']").val(r.d[0].cd_PUBLISHER);
                $("[id*='txtcallno']").val(r.d[0].bookcallno);
                $("[id*='txtisbnno']").val(r.d[0].cd_ISBN);
                $("[id*='ddllanguage']").val(r.d[0].cd_LANG);
                $("[id*='txtkeyword']").val(r.d[0].cd_KEYWORD);
                $("[id*='txtyear']").val(r.d[0].cd_YEAR);
                $("[id*='txtnoofpages']").val(r.d[0].booknoofpages);
                $("[id*='txtSubject']").val(r.d[0].cd_SUBJ);
                $("[id*='txtremark']").val(r.d[0].cd_REMARK);
                $("[id*='txtaccompaningmaterial']").val(r.d[0].cd_ACC_MATERIALS);
                $("[id*='ddlbookcatogary']").val(r.d[0].bookcatogary);
                $("[id*='ddlbooktype']").val(r.d[0].cd_ISSUE_TYPE);
                $("[id*='ddlbookbound']").val(r.d[0].bookbound);
               // $("[id*='txtdonor']").val(r.d[0].cd_DONOR_ID);
                $("[id*='txtbookcount']").val(r.d.length);
                $("#txtbookcount").trigger(jQuery.Event('keydown', { keyCode: 13, which: 13 }));

                document.getElementById('txtbookcount').disabled = true;
                //if (r.d.length == 1)
                //{
                //}
                //else
                //{
                //    $("#tableacceesiontable").find("*").attr("disabled", "disabled");
                  
                    //}
                var dd1 = $("[id*='ddlbookprefix']");

                for (var i = 0; i < r.d.length; i++) {
                    $("[id*='tbl_dis_book']").val(r.d[0].dis_type);

                    $("[id*='txtbookAccession_" + i + "']").val(r.d[i].cd_ACCESSION_NO);
                    $("[id*='txtbookbillno_" + i + "']").val(r.d[i].cd_BILL_NO);
                    $("[id*='txtbookbilldate_" + i + "']").val(r.d[i].cd_BILL_DT.substring(0, 10));
                    $("[id*='txtbookmrp_" + i + "']").val(r.d[i].cd_MRP);
                    $("[id*='txtbookdiscount_" + i + "']").val(r.d[i].cd_DISCOUNT);
                    $("[id*='txtbookprice_" + i + "']").val(r.d[i].cd_PRICE);
                    $("[id*='txtbookvendordetails_" + i + "']").val(r.d[i].cd_VENDOR);
                    $("[id*='txtbookregistrationdate_" + i + "']").val(r.d[i].cd_REG_DT.substring(0, 9));
                    $("[id*='txt_purchase_orderDate" + i + "']").val(r.d[i].cd_PURCHASE_DT.substring(0, 10));
                    $("[id*='txtOrderNo" + i + "']").val(r.d[i].cd_ORDER_NO);
                    $("[id*='ddlbookprefix_" + i + "']").val(r.d[i].prefix);

                }
                $("#menu_toggle").click();

                //document.getElementById('cd_bthSave').innerText = "Update";

            }
            else if (r.d[0].cd_msg == "multiple") {
               // $.notify("Mismatched id:" + rd.d[0].cd_id + ".", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                $.confirm({

                    title: 'CD Master',
                    text: "Mismatched Tile:" + r.d[0].cd_id + " and Author:" + r.d[0].Auth_cd_id + ".",
                    content: 'Mismatched Tile:" + r.d[0].cd_id + " and Author:" + r.d[0].Auth_cd_id + ".',
                    confirmButton: 'Yes',
                    cancelButton: 'No',
                    confirm: function () {
                        var new_id = bookid;
                        var id = [];
                        id = new_id.split(",");

                        $.ajax({
                            type: "POST",
                            url: "BookmasterNew.aspx/get_cd_data",
                            data: '{cd:"' + id[0] + '",cd_name:"' + bookid + '",type:"book"}',
                            contentType: "application/json; charset=utf-8",
                            success: function (r) {
                                if (r.d.length > 0) {
                                    if (r.d[0].cd_msg == "get") {

                                        $(".tokens-list-token-holder").remove();

                                        //$("[id*='bookid']").val(bookid);
                                        $("[id*='txtbooktitlee']").val(r.d[0].cd_TITLE);
                                        //$("[id*='txtauthor']").val(r.d[0].cd_AUTHOR);
                                        $("[id*='txtbookedition']").val(r.d[0].bookedition);
                                        localStorage.setItem("auth", r.d[0].cd_AUTHOR);
                                        $("[id*='txtauthor']").val(r.d[0].cd_AUTHOR);

                                        localStorage.setItem("pub", r.d[0].cd_PUBLISHER);

                                        $("[id*='txtpublisher']").val(r.d[0].cd_PUBLISHER);

                                        localStorage.setItem("don", r.d[0].cd_DONOR_ID);

                                        $("[id*='txtdonor']").val(r.d[0].cd_DONOR_ID);


                                        var aa = $(".tokens-token-list");
                                        for (var i = 0; i <= aa.length - 1; i++) {
                                            if (aa[i].nextElementSibling.id == "txtauthor") {

                                                var arr = r.d[0].cd_AUTHOR.split('|');
                                                for (var y = 0; y <= arr.length - 1; y++) {
                                                    if (arr[y] != "") {
                                                        var li = document.createElement("li");
                                                        li.setAttribute("class", "tokens-list-token-holder");
                                                        li.setAttribute("onClick", "removeItem_book(this);");
                                                        var p = document.createElement("p");

                                                        //p.setAttribute("innerHTML", 'abc');
                                                        p.textContent = arr[y];
                                                        li.append(p);

                                                        var span = document.createElement("span");
                                                        span.setAttribute("class", "tokens-delete-token");

                                                        // span.setAttribute("innerHTML", 'x');
                                                        span.textContent = 'x';

                                                        li.append(span);



                                                        aa[i].prepend(li);
                                                    }

                                                }

                                            }


                                            else if (aa[i].nextElementSibling.id == "txtpublisher") {

                                                var arr = r.d[0].cd_PUBLISHER.split('|');
                                                for (var y = 0; y <= arr.length - 1; y++) {
                                                    if (arr[y] != "") {
                                                        var li = document.createElement("li");
                                                        li.setAttribute("class", "tokens-list-token-holder");
                                                        li.setAttribute("onClick", "removeItem_book(this);");
                                                        var p = document.createElement("p");

                                                        //p.setAttribute("innerHTML", 'abc');
                                                        p.textContent = arr[y];
                                                        li.append(p);

                                                        var span = document.createElement("span");
                                                        span.setAttribute("class", "tokens-delete-token");

                                                        // span.setAttribute("innerHTML", 'x');
                                                        span.textContent = 'x';

                                                        li.append(span);



                                                        aa[i].prepend(li);
                                                    }

                                                }

                                            }

                                            else {
                                                var arr = r.d[0].cd_DONOR_ID.split('|');
                                                for (var y = 0; y <= arr.length - 1; y++) {
                                                    if (arr[y] != "") {
                                                        var li = document.createElement("li");
                                                        li.setAttribute("class", "tokens-list-token-holder");
                                                        li.setAttribute("onClick", "removeItem_book(this);");
                                                        var p = document.createElement("p");

                                                        //p.setAttribute("innerHTML", 'abc');
                                                        p.textContent = arr[y];
                                                        li.append(p);

                                                        var span = document.createElement("span");
                                                        span.setAttribute("class", "tokens-delete-token");

                                                        // span.setAttribute("innerHTML", 'x');
                                                        span.textContent = 'x';

                                                        li.append(span);



                                                        aa[i].prepend(li);

                                                    }
                                                }
                                            }

                                        }
                                        var b = imageExists("../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".jpg");
                                        var b1 = imageExists("../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".jpeg");
                                        var b2 = imageExists("../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".png");
                                        var b3 = imageExists("../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".gif");

                                        if (b == true) {
                                            document.getElementById("imgbook").src = "../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".jpg";
                                        }                                             
                                        else if (b1 == true) {                        
                                            document.getElementById("imgbook").src = "../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".jpeg";
                                        }                                             
                                        else if (b2 == true) {                        
                                            document.getElementById("imgbook").src = "../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".png";
                                        }                                             
                                        else if (b3 == true) {                        
                                            document.getElementById("imgbook").src = "../../../Library/Book/" + r.d[0].cd_ACCESSION_NO + ".gif";
                                        }


                                        if (b == false && b1 == false && b2 == false && b3 == false) {
                                            $("#book_photo").val('');
                                            $("[id*='imgbook']").attr('src', '../../../Assets/img/book_open.png');
                                        }
                                        // $("[id*='txtpublisher']").val(r.d[0].cd_PUBLISHER);
                                        $("[id*='txtcallno']").val(r.d[0].bookcallno);
                                        $("[id*='txtisbnno']").val(r.d[0].cd_ISBN);
                                        $("[id*='ddllanguage']").val(r.d[0].cd_LANG);
                                        $("[id*='txtkeyword']").val(r.d[0].cd_KEYWORD);
                                        $("[id*='txtyear']").val(r.d[0].cd_YEAR);
                                        $("[id*='txtnoofpages']").val(r.d[0].booknoofpages);
                                        $("[id*='txtSubject']").val(r.d[0].cd_SUBJ);
                                        $("[id*='txtremark']").val(r.d[0].cd_REMARK);
                                        $("[id*='txtaccompaningmaterial']").val(r.d[0].cd_ACC_MATERIALS);
                                        $("[id*='ddlbookcatogary']").val(r.d[0].bookcatogary);
                                        $("[id*='ddlbooktype']").val(r.d[0].cd_ISSUE_TYPE);
                                        $("[id*='ddlbookbound']").val(r.d[0].bookbound);
                                        // $("[id*='txtdonor']").val(r.d[0].cd_DONOR_ID);
                                        $("[id*='txtbookcount']").val(r.d.length);
                                        $("#txtbookcount").trigger(jQuery.Event('keydown', { keyCode: 13, which: 13 }));

                                        document.getElementById('txtbookcount').disabled = true;
                                        //if (r.d.length == 1)
                                        //{
                                        //}
                                        //else
                                        //{
                                        //    $("#tableacceesiontable").find("*").attr("disabled", "disabled");

                                        //}
                                        var dd1 = $("[id*='ddlbookprefix']");

                                        for (var i = 0; i < r.d.length; i++) {
                                            $("[id*='tbl_dis_book']").val(r.d[0].dis_type);

                                            $("[id*='txtbookAccession_" + i + "']").val(r.d[i].cd_ACCESSION_NO);
                                            $("[id*='txtbookbillno_" + i + "']").val(r.d[i].cd_BILL_NO);
                                            $("[id*='txtbookbilldate_" + i + "']").val(r.d[i].cd_BILL_DT.substring(0, 10));
                                            $("[id*='txtbookmrp_" + i + "']").val(r.d[i].cd_MRP);
                                            $("[id*='txtbookdiscount_" + i + "']").val(r.d[i].cd_DISCOUNT);
                                            $("[id*='txtbookprice_" + i + "']").val(r.d[i].cd_PRICE);
                                            $("[id*='txtbookvendordetails_" + i + "']").val(r.d[i].cd_VENDOR);
                                            $("[id*='txtbookregistrationdate_" + i + "']").val(r.d[i].cd_REG_DT.substring(0, 10));
                                            $("[id*='ddlbookprefix_" + i + "']").val(r.d[i].prefix);
                                            $("[id*='txt_purchase_orderDate" + i + "']").val(r.d[i].cd_PURCHASE_DT.substring(0, 10));
                                            $("[id*='txtOrderNo" + i + "']").val(r.d[i].cd_ORDER_NO);

                                        }
                                        $("#menu_toggle").click();

                                    }
                                }
                            }
                        });
                    },
                });
            }
            else if (r.d[0].cd_msg == "") {
                $.notify("No data found", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
            $("[id*='EditmodalBook']").modal('hide');

        }
    }
        
    });
}
function removeItem_book(li) {
    var ul = li.parentElement;
    ul.removeChild(li);

    var str = localStorage.getItem("auth").toString();
    if (str.indexOf(li.innerText.substring(0, li.innerText.length - 1)) > -1) {
        var f_str = str.replace(li.innerText.substring(0, li.innerText.length - 1), '');
        var auth1 = $("[id*='txtauthor']").val().replace(li.innerText.substring(0, li.innerText.length - 1), '');
        $("[id*='txtauthor']").val(auth1);
        localStorage.setItem("auth", f_str);
    }


    var str_pub = localStorage.getItem("pub").toString();
    if (str_pub.indexOf(li.innerText.substring(0, li.innerText.length - 1)) > -1) {
        var f_str_pub = str_pub.replace(li.innerText.substring(0, li.innerText.length - 1), '');
        var pub1 = $("[id*='txtpublisher']").val().replace(li.innerText.substring(0, li.innerText.length - 1), '');
        $("[id*='txtpublisher']").val(pub1);
        localStorage.setItem("pub", f_str_pub);
    }

    var str_don = localStorage.getItem("don").toString();
    if (str_don.indexOf(li.innerText.substring(0, li.innerText.length - 1)) > -1) {
        var f_str_don = str_don.replace(li.innerText.substring(0, li.innerText.length - 1), '');
        var don1 = $("[id*='txtdonor']").val().replace(li.innerText.substring(0, li.innerText.length - 1), '');
        $("[id*='txtdonor']").val(don1);
        localStorage.setItem("don", f_str_don);
    }
    //  li.parentElement.remove();
    //alert('hi');
}

//cd part//-----------------------------------------------------------------------start------------------
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

$("#txt_cd_cnt").on('keydown', function (e) {

    if (e.which === 13) {

        event.preventDefault();
        var count = $("[id*='txt_cd_cnt']")[0].value;
        if (count != 0 && count != "") {
            var tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');
            //document.getElementById("divcdhide").style.display = "block";
            if (tds.length > 0) {
                if (tds.length < count) {
                    var tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');
                    var tbl_len = parseInt(tds.length);
                    for (var i = tbl_len; i < count; i++) {
                        var data = parseInt(i) + 1;
                        $("[id*=tbl_cd]").append("<tr><td>" + data + "</td><td><select id='ddlcdprefix_" + i + "' class='form-control' onchange='criteraichng(this.id);'></select></td><td><input type='text' id='txtcdAccession_" + i + "'/></td><td><input type='text' id='txtbillno_" + i + "'/></td><td><input type='text' id='txtbilldt_" + i + "'/></td><td><input type='text' id='txtmrp_" + i + "'/></td><td><input type='text' id='txtdiscount_" + i + "' /></td><td><input type='text' id='txtprice_" + i + "'/></td><td><input type='text' id='txtvendet_" + i + "'/></td><td><input type='text' id='txtregdt_" + i + "'/></td></tr>");
                        $('[id*=txtregdt]').datetimepicker({
                            singleDatePicker: true,
                            calender_style: "picker_1",
                            timepicker: false,
                            format: 'd-M-Y'
                        }, function (start, end, label) {
                            console.log(start.toISOString(), end.toISOString(), label);
                        });
                        $('[id*=txtbilldt]').datetimepicker({
                            singleDatePicker: true,
                            calender_style: "picker_1",
                            timepicker: false,
                            format: 'd-M-Y'
                        }, function (start, end, label) {
                            console.log(start.toISOString(), end.toISOString(), label);
                        });
                        $("[id*=tbl_cd]").append("</tbody>");

                        $(function () {

                            var books_arr = [];

                            $.ajax({
                                type: "POST",
                                url: "BookmasterNew.aspx/LoadPublisher",
                                data: '{type:"v"}',
                                contentType: "application/json; charset=utf-8",
                                async: false,
                                success: function (data) {
                                    debugger;

                                    for (var i = 0; i < data.d.length; i++) {
                                        // var val = item[i];
                                        var item = data.d[i];
                                        var mid = data.d[i];
                                        books_arr.push(mid);
                                    }
                                    // setup autocomplete function pulling from currencies[] array


                                    var books = books_arr;

                                    $('[id*=txtvendet_]').autocomplete({
                                        source: [books]
                                    });


                                },
                                error: function () {

                                    //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                }
                            });
                        });
                        
                        //prefix

                        $.ajax({
                            type: "POST",
                            url: "BookmasterNew.aspx/LoadPrefix",
                            data: '{type:"cd",connect:"' + $("[id*='ddlselect']").val() + '"}',
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            success: function (data) {
                                $("[id^='ddlcdprefix_']").empty().append('<option selected="selected" value="0">--select--</option>');
                                $.each(data.d, function () {
                                    $("[id^='ddlcdprefix_']").append($("<option></option>").val(this['Value']).html(this['Text']));
                                });

                            },
                            error: function () {

                                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });
                        fill_tbl_cd_val(i);

                    }
                }
                else if (tds.length > count) {
                    var tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');
                    var tbl_len = parseInt(tds.length) + 3;

                    var init_val = parseInt(tds.length) + 1;
                    for (var i = init_val; i < tbl_len; i--) {
                        if (count != tds.length) {
                            document.getElementById("tbl_cd").deleteRow(i);
                            tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');
                            tbl_len = parseInt(tds.length) + 2;
                        }
                        else {
                            tbl_len = parseInt(i) - 1;
                        }
                    }
                }
            }
            else {
                $("[id*=tbl_cd]")[0].innerHTML = "";
                for (var i = 0; i < parseInt(count) ; i++) {
                    if (i == 0) {
                        $("[id*=tbl_cd]").append("<thead><tr></tr><tr class='alert-info'><th><center>Sr.No</th><th ><center>Prefix</th><th ><center>Enter Accession No</th><th><center>Bill No.</th><th><center>Bill Date(DD MM YYYY)</th><th><center>MRP (Rs.)</th><th><center>Discount <select id='tbl_dis' style='background-color: grey'><option style='color:black'>percent(%)</option><option style='color:black'>price</option></select></th><th><center>Price</th><th><center>Vendor Details  <a class='btn-info btn btn-sm' data-toggle='modal' data-target='#myModal1'><span class='glyphicon glyphicon-plus'></span></a></th><th><center>Registration Date</th></tr></thead>");
                        $("[id*=tbl_cd]").append("<tbody>");
                    }
                    var data = parseInt(i) + 1;
                    $("[id*=tbl_cd]").append("<tr><td>" + data + "</td><td><select id='ddlcdprefix_" + i + "' class='form-control' onchange='criteraichng(this.id);'></select></td><td><input type='text' id='txtcdAccession_" + i + "'/></td><td><input type='text' id='txtbillno_" + i + "'/></td><td><input type='text' id='txtbilldt_" + i + "'/></td><td><input type='text' id='txtmrp_" + i + "'/></td><td><input type='text' name='txtdiscount' id='txtdiscount_" + i + "' /></td><td><input type='text' id='txtprice_" + i + "'/></td><td><input type='text' id='txtvendet_" + i + "'/></td><td><input type='text' id='txtregdt_" + i + "'/></td></tr>");
                    $('[id*=txtregdt]').datetimepicker({
                        singleDatePicker: true,
                        calender_style: "picker_1",
                        timepicker: false,
                        format: 'd-M-Y'
                    }, function (start, end, label) {
                        console.log(start.toISOString(), end.toISOString(), label);
                    });
                    $('[id*=txtbilldt]').datetimepicker({
                        singleDatePicker: true,
                        calender_style: "picker_1",
                        timepicker: false,
                        format: 'd-M-Y'
                    }, function (start, end, label) {
                        console.log(start.toISOString(), end.toISOString(), label);
                    });
                }
                $("[id*=tbl_cd]").append("</tbody>");

                $(function () {

                    var books_arr = [];

                    $.ajax({
                        type: "POST",
                        url: "BookmasterNew.aspx/LoadPublisher",
                        data: '{type:"v",connect:"' + $("[id*='ddlselect']").val() + '"}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (data) {
                            debugger;

                            for (var i = 0; i < data.d.length; i++) {
                                // var val = item[i];
                                var item = data.d[i];
                                var mid = data.d[i];
                                books_arr.push(mid);
                            }
                            // setup autocomplete function pulling from currencies[] array


                            var books = books_arr;

                            $('[id*=txtvendet_]').autocomplete({
                                source: [books]
                            });


                        },
                        error: function () {

                            //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    });




                });

                //prefix

                $.ajax({
                    type: "POST",
                    url: "BookmasterNew.aspx/LoadPrefix",
                    data: '{type:"cd",connect:"' + $("[id*='ddlselect']").val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        $("[id^='ddlcdprefix_']").empty().append('<option selected="selected" value="0">--select--</option>');
                        $.each(data.d, function () {
                            $("[id^='ddlcdprefix_']").append($("<option></option>").val(this['Value']).html(this['Text']));
                        });

                    },
                    error: function () {

                        //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                });
            }
        }
    }
});

function fill_tbl_cd_val(i) {

    var j = parseInt(i) - 1;
    if ($("[id*='txtcdAccession_" + j + "']").val() != "") {
        var word = $("[id*='txtcdAccession_" + j + "']").val();
        var myArray = word.split(/[0-9]+/);
        var novalue = word.split(/\D+/);
        if (myArray[0] != "") {
            var value = String(parseInt(novalue[1]) + 1);
            value = app0(novalue[1], value);
        }
        else {
            var value = String(parseInt(novalue[0]) + 1);
            value = app0(novalue[0], value);
        }

        value = myArray[0] + value;
        $("[id*='txtcdAccession_" + i + "']").val(value);
    }
    if ($("[id*='txtbillno_" + j + "']").val() != "") {
        var word = $("[id*='txtbillno_" + j + "']").val();
        $("[id*='txtbillno_" + i + "']").val(word);
    }
    if ($("[id*='txtbilldt_" + j + "']").val() != "") {
        var word = $("[id*='txtbilldt_" + j + "']").val();
        $("[id*='txtbilldt_" + i + "']").val(word);
    }
    if ($("[id*='txtmrp_" + j + "']").val() != "") {
        var word = $("[id*='txtmrp_" + j + "']").val();
        $("[id*='txtmrp_" + i + "']").val(word);
    }
    if ($("[id*='txtdiscount_" + j + "']").val() != "") {
        if ($("[id*=tbl_dis]").val() == "percent(%)") {
            var word = $("[id*='txtdiscount_" + j + "']").val();
            var total = $("[id*='txtmrp_" + j + "']").val();
            var discount_value = (total / 100) * word;
            var rate = total - discount_value;
            $("[id*='txtdiscount_" + i + "']").val(word);
            $("[id*='txtprice_" + i + "']").val(rate);
        }
        else {
            var word = $("[id*='txtdiscount_" + j + "']").val();
            var total = $("[id*='txtmrp_" + j + "']").val();
           // var discount_value = (total / 100) * word;
            var rate = total - word;
            $("[id*='txtdiscount_" + i + "']").val(word);
            $("[id*='txtprice_" + i + "']").val(rate);
        }
    }
    if ($("[id*='txtvendet_" + j + "']").val() != "") {
        var word = $("[id*='txtvendet_" + j + "']").val();
        $("[id*='txtvendet_" + i + "']").val(word);
    }
    if ($("[id*='txtregdt_" + j + "']").val() != "") {
        var word = $("[id*='txtregdt_" + j + "']").val();
        $("[id*='txtregdt_" + i + "']").val(word);
    }
}

//$('.commonclass').on('keydown', function (e) {
$("[id*=tbl_cd]").on('keydown', 'input[type="text"]', function (e) {
    var id = e.currentTarget.id;
    var sp = id.split('_');
    var int = parseInt(sp[1]) + 1;
    if (e.which === 13) {
        event.preventDefault();
        if ($("[id*=tbl_cd]")[0].innerHTML != "") {
            var tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');
            if (id.startsWith('txtcdAccession_')) {
                var k = 1;
                for (var i = int; i < tds.length; i++) {

                    // String.fromCharCode
                    var word = $("[id*='" + id + "']").val();
                    var myArray = word.split(/[0-9]+/);
                    var novalue = word.split(/\D+/);
                    if (myArray[0] != "") {
                        var value = String(parseInt(novalue[1]) + k);
                        value = app0(novalue[1], value);
                    }
                    else {
                        var value = String(parseInt(novalue[0]) + k);
                        value = app0(novalue[0], value);
                    }

                    value = myArray[0] + value;
                    $("[id*='txtcdAccession_" + i + "']").val(value);
                    k++;

                }
            }
            if (id.startsWith('txtbillno_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtbillno_" + i + "']").val(word);

                }
            }

            if (id.startsWith('txtbilldt_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtbilldt_" + i + "']").val(word);

                }
            }

            if (id.startsWith('txtmrp_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtmrp_" + i + "']").val(word);

                }
            }

            if (id.startsWith('txtdiscount_')) {
              
                int = sp[1];
                for (var i = int; i < tds.length; i++) {
                    if ($("[id*=tbl_dis]").val() == "percent(%)") {
                        var word = $("[id*='" + id + "']").val();
                        var total = $("[id*='txtmrp_" + i + "']").val();
                        var discount_value = (total / 100) * word;
                        var rate = total - discount_value;
                        $("[id*='txtdiscount_" + i + "']").val(word);
                        $("[id*='txtprice_" + i + "']").val(rate);
                    }
                    else {
                        var word = $("[id*='" + id + "']").val();
                        var total = $("[id*='txtmrp_" + i + "']").val();
                        //var discount_value = (total / 100) * word;
                        var rate = total-word;
                        $("[id*='txtdiscount_" + i + "']").val(word);
                        $("[id*='txtprice_" + i + "']").val(rate);
                    }

                }
            }


            if (id.startsWith('txtvendet_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtvendet_" + i + "']").val(word);

                }
            }

            if (id.startsWith('txtregdt_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtregdt_" + i + "']").val(word);

                }
            }

        }
    }
});

$("[id*=tbl_cd]").on('blur', 'input[type="text"]', function (e) {

    
        var id = e.currentTarget.id;
        var sp = id.split('_');
        var int = parseInt(sp[1]);
        if ($("[id*=tbl_cd]")[0].innerHTML != "") {
            var tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');

            if (id.startsWith('txtcdAccession_')) {
                int = sp[1];
                $.ajax({
                    type: "POST",
                    url: "BookmasterNew.aspx/load_cd_book",
                    data: '{accession:"' + $("[id*='txtcdAccession_" + int + "']")[0].value + '",type:"cd",connect:"' + $("[id*='ddlselect']").val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (r) {
                        if (r.d.length > 0) {
                            $("[id*='txtcdAccession_" + int + "']").val('');
                            $.notify("Alert ! Accession already exists.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    },
                    error: function () {

                        //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                });
            }
        }
    
});

function app0(id, value) {
    var z = ""; var d = value;
    if (id.length != d.length) {
        var h = id.length;
        var f = d.length;
        var o = parseInt(h) - parseInt(f);
        for (var j = 0; j < o; j++) {
            z = z + "0";
        }
        value = z + value;
    }
    return value;
}

$("[id*='btn_CD_ok']").on("click", function () {
    upd_tit = "";
    upd_id = $("[id*='txt_cd_access']").val();
    get_dt($("[id*='txt_cd_access']").val(), "");
});
//save cs
$("[id*='cd_bthSave']").on("click", function () {
    var accession_cd = [];
    if (localStorage.getItem("auth").toString() != "") {
        if ($("[id*='txt_auth']").val() == localStorage.getItem("auth").toString()) {
            str = $("[id*='txt_auth']").val();
        }
        else {

            if ($("[id*='txt_auth']").val().indexOf(localStorage.getItem("auth").toString()) > -1) {
                str = $("[id*='txt_auth']").val();
            }
            else {

                str = $("[id*='txt_auth']").val() + "| " + localStorage.getItem("auth").toString();

            }
            // str = $("[id*='txtauthor_map']").val() + "| " + localStorage.getItem("auth").toString();

        }
    }
    else {
        str = $("[id*='txt_auth']").val();

    }

    var str_rp = str.replace("| |", "|");
    var str_rp1 = str_rp.replace("||", "|");
    var auth_final = str_rp1.trim();


    var str_pub = "";
    if (localStorage.getItem("pub").toString() != "") {
        if ($("[id*='txt_pub']").val() == localStorage.getItem("pub").toString()) {

            str_pub = $("[id*='txt_pub']").val();

        }
        else {

            if ($("[id*='txt_pub']").val().indexOf(localStorage.getItem("pub").toString()) > -1) {
                str_pub = $("[id*='txt_pub']").val();

            }
            else {

                str_pub = $("[id*='txt_pub']").val() + "| " + localStorage.getItem("pub").toString();


            }
            // str_pub = $("[id*='txtpublisher_map']").val() + "| " + localStorage.getItem("pub").toString();


        }

    }
    else {
        str_pub = $("[id*='txt_pub']").val();

    }

    var str_pub_rp = str_pub.replace("| |", "|");
    var str_pub_rp1 = str_pub_rp.replace("||", "|");
    var pub_final = str_pub_rp1.trim();



    var str_don = "";
    if (localStorage.getItem("don").toString() != "") {
        str_don = $("[id*='donar_name']").val() + "| " + localStorage.getItem("don").toString();
        if ($("[id*='donar_name']").val() == localStorage.getItem("don").toString()) {

            str_don = $("[id*='donar_name']").val();
        }
        else {
            if ($("[id*='donar_name']").val().indexOf(localStorage.getItem("don").toString()) > -1) {
                str_don = $("[id*='donar_name']").val();


            }
            else {

                str_don = $("[id*='donar_name']").val() + "| " + localStorage.getItem("don").toString();


            }
            // str_don = $("[id*='txtdonor_map']").val() + "| " + localStorage.getItem("don").toString();



        }
    }
    else {
        str_don = $("[id*='donar_name']").val();

    }

    var str_don_rp = str_don.replace("| |", "|");
    var str_don_rp1 = str_don_rp.replace("||", "|");

    var donor_final = str_don_rp1.trim();
    if (document.getElementById('rd_cd_iss').checked == true) {
        cd_rd = "1";
    } else { cd_rd = "0"; }
    var ins = "";
    if (validatecd() == true && $("[id*='txt_cd_tit']").val() != "" && auth_final != "") {
        var res = donor.indexOf($("[id*='txt_cd_tit']").val().trim());
        if (res > -1) {
            if (upd_id != "") {
                if (upd_id.includes(",")) {
                    //{
                    //    ins = "update lib_cd_master  set ISBN='" + $("[id*='txt_isbn']").val() + "',Author='" + auth_final + "',LANG='" + $("[id*='cd_lang']").val() + "',ISSUE_TYPE='" + cd_rd + "',KEYWORD='" + $("[id*='txt_key']").val() + "',PUBLISHER='" + pub_final + "',YEAR='" + $("[id*='txt_yr']").val() + "',DURATION='" + $("[id*='txt_dur']").val() + "',DEPARTMENT='" + $("[id*='ddlcourse_cd']").val() + "',ACC_MATERIALS='" + $("[id*='txt_acc_mat']").val() + "',REMARK='" + $("[id*='txt_rem']").val() + "',DONOR_ID='" + donor_final + "' where ACCESSION_NO in ('" + upd_id + "');";
                    //}
                    //else {
                    if ($("[id*=tbl_cd]")[0].innerHTML != "") {
                        var tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');
                        var gen_id = [];
                        gen_id = upd_id.split(",");
                        for (var k = 0; k < gen_id.length; k++) {
                            for (var i = 0; i < tds.length; i++) {
                                accession_cd.push($("[id*='txtcdAccession_" + i + "']").val());
                                if (gen_id[k] == $("[id*='txtcdAccession_" + i + "']").val()) {
                                    ins = ins + "update lib_cd_master  set ISBN='" + $("[id*='txt_isbn']").val() + "',Author=N'" + auth_final + "',LANG='" + $("[id*='cd_lang']").val() + "',ISSUE_TYPE='" + cd_rd + "',KEYWORD=N'" + $("[id*='txt_key']").val() + "',PUBLISHER=N'" + pub_final + "',YEAR='" + $("[id*='txt_yr']").val() + "',DURATION='" + $("[id*='txt_dur']").val() + "',DEPARTMENT='" + $("[id*='ddlcourse_cd']").val() + "',ACC_MATERIALS=N'" + $("[id*='txt_acc_mat']").val() + "',REMARK=N'" + $("[id*='txt_rem']").val() + "',DONOR_ID='" + donor_final + "',ACCESSION_NO='" + $("[id*='txtcdAccession_" + i + "']").val() + "',BILL_NO='" + $("[id*='txtbillno_" + i + "']").val() + "',BILL_DT='" + $("[id*='txtbilldt_" + i + "']").val() + "',MRP='" + $("[id*='txtmrp_" + i + "']").val() + "',DISCOUNT='" + $("[id*='txtdiscount_" + i + "']").val() + "',Discount_type='" + $("[id*='tbl_dis']").val() + "',PRICE='" + $("[id*='txtprice_" + i + "']").val() + "',VENDOR=N'" + $("[id*='txtvendet_" + i + "']").val() + "',REG_DT='" + $("[id*='txtregdt_" + i + "']").val() + "' where ACCESSION_NO in ('" + gen_id[k] + "');";
                                }
                            }
                        }
                    }
                    

                }
                else {
                    var tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');
                    for (var i = 0; i < tds.length; i++) {
                        accession_cd.push($("[id*='txtcdAccession_" + i + "']").val());
                        ins += "update lib_cd_master  set ISBN='" + $("[id*='txt_isbn']").val() + "',Author=N'" + auth_final + "',LANG=N'" + $("[id*='cd_lang']").val() + "',ISSUE_TYPE='" + cd_rd + "',KEYWORD=N'" + $("[id*='txt_key']").val() + "',PUBLISHER=N'" + pub_final + "',YEAR='" + $("[id*='txt_yr']").val() + "',DURATION='" + $("[id*='txt_dur']").val() + "',DEPARTMENT='" + $("[id*='ddlcourse_cd']").val() + "',ACC_MATERIALS=N'" + $("[id*='txt_acc_mat']").val() + "',REMARK=N'" + $("[id*='txt_rem']").val() + "',DONOR_ID=N'" + donor_final + "',ACCESSION_NO='" + $("[id*='txtcdAccession_" + i + "']").val() + "',BILL_NO='" + $("[id*='txtbillno_" + i + "']").val() + "',BILL_DT='" + $("[id*='txtbilldt_" + i + "']").val() + "',MRP='" + $("[id*='txtmrp_" + i + "']").val() + "',DISCOUNT='" + $("[id*='txtdiscount_" + i + "']").val() + "',Discount_type='" + $("[id*='tbl_dis']").val() + "',PRICE='" + $("[id*='txtprice_" + i + "']").val() + "',VENDOR=N'" + $("[id*='txtvendet_" + i + "']").val() + "',REG_DT='" + $("[id*='txtregdt_" + i + "']").val() + "' where ACCESSION_NO in ('" + upd_id + "');";
                    }
                    //ins = "update lib_cd_master  set ISBN='" + $("[id*='txt_isbn']").val() + "',Author='" + auth_final + "',LANG='" + $("[id*='cd_lang']").val() + "',ISSUE_TYPE='" + cd_rd + "',KEYWORD='" + $("[id*='txt_key']").val() + "',PUBLISHER='" + pub_final + "',YEAR='" + $("[id*='txt_yr']").val() + "',DURATION='" + $("[id*='txt_dur']").val() + "',DEPARTMENT='" + $("[id*='ddlcourse_cd']").val() + "',ACC_MATERIALS='" + $("[id*='txt_acc_mat']").val() + "',REMARK='" + $("[id*='txt_rem']").val() + "',DONOR_ID='" + donor_final + "' where ACCESSION_NO in ('" + upd_id + "');";
                }
            }
            else {
                var tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');
                for (var i = 0; i < tds.length; i++) {
                    accession_cd.push($("[id*='txtcdAccession_" + i + "']").val());
                    ins += "update lib_cd_master  set ISBN='" + $("[id*='txt_isbn']").val() + "',Author=N'" + auth_final + "',LANG=N'" + $("[id*='cd_lang']").val() + "',ISSUE_TYPE='" + cd_rd + "',KEYWORD=N'" + $("[id*='txt_key']").val() + "',PUBLISHER=N'" + pub_final + "',YEAR='" + $("[id*='txt_yr']").val() + "',DURATION=N'" + $("[id*='txt_dur']").val() + "',DEPARTMENT='" + $("[id*='ddlcourse_cd']").val() + "',ACC_MATERIALS=N'" + $("[id*='txt_acc_mat']").val() + "',REMARK=N'" + $("[id*='txt_rem']").val() + "',DONOR_ID=N'" + donor_final + "',ACCESSION_NO='" + $("[id*='txtcdAccession_" + i + "']").val() + "',BILL_NO='" + $("[id*='txtbillno_" + i + "']").val() + "',BILL_DT='" + $("[id*='txtbilldt_" + i + "']").val() + "',MRP='" + $("[id*='txtmrp_" + i + "']").val() + "',DISCOUNT='" + $("[id*='txtdiscount_" + i + "']").val() + "',Discount_type='" + $("[id*='tbl_dis']").val() + "',PRICE='" + $("[id*='txtprice_" + i + "']").val() + "',VENDOR=N'" + $("[id*='txtvendet_" + i + "']").val() + "',REG_DT='" + $("[id*='txtregdt_" + i + "']").val() + "' where ACCESSION_NO='" + $("[id*='txtcdAccession_" + i + "']").val() + "';";
                }
                //ins = "update lib_cd_master  set ISBN='" + $("[id*='txt_isbn']").val() + "',Author='" + auth_final + "',LANG='" + $("[id*='cd_lang']").val() + "',ISSUE_TYPE='" + cd_rd + "',KEYWORD='" + $("[id*='txt_key']").val() + "',PUBLISHER='" + pub_final + "',YEAR='" + $("[id*='txt_yr']").val() + "',DURATION='" + $("[id*='txt_dur']").val() + "',DEPARTMENT='" + $("[id*='ddlcourse_cd']").val() + "',ACC_MATERIALS='" + $("[id*='txt_acc_mat']").val() + "',REMARK='" + $("[id*='txt_rem']").val() + "',DONOR_ID='" + donor_final + "' where TITLE=N'" + upd_tit + "';";
            }


        }
            
        else {
            if ($("[id*=tbl_cd]")[0].innerHTML != "") {
                var tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');

                for (var i = 0; i < tds.length; i++) {
                    accession_cd.push($("[id*='txtcdAccession_" + i + "']").val());
                    //var vendor_name = ""; var vendor_id = "";
                    //var d = ;
                    //d = d.split(',');

                    //for (var j = 0; j < d.length; j++) {
                    //    if (vendor_name == "") {
                    //        vendor_name = d[j];
                    //    }
                    //    else {
                    //        vendor_name = vendor_name + "','" + d[j].trim();
                    //    }
                    //}
                    //   vendor_id = "(select general_id from ll_general_master where general_name in ('" + vendor_name + "') and general_type='V')";
                    
                    if ($("[id*='txtbookAccession_" + i + "']").val() != "") {
                        ins = ins + "insert into lib_cd_master values(N'" + $("[id*='txt_cd_tit']").val() + "',N'" + auth_final + "','" + $("[id*='txt_isbn']").val() + "',N'" + $("[id*='cd_lang']").val() + "','" + cd_rd + "',N'" + $("[id*='txt_key']").val() + "',N'" + pub_final + "','" + $("[id*='txt_yr']").val() + "','" + $("[id*='txt_dur']").val() + "','" + $("[id*='ddlcourse_cd']").val() + "',N'" + $("[id*='txt_acc_mat']").val() + "',N'" + $("[id*='txt_sub']").val() + "',N'" + $("[id*='txt_rem']").val() + "','" + $("[id*='txtcdAccession_" + i + "']").val() + "','" + $("[id*='txtbillno_" + i + "']").val() + "','" + $("[id*='txtbilldt_" + i + "']").val() + "','" + $("[id*='txtmrp_" + i + "']").val() + "','" + $("[id*='txtdiscount_" + i + "']").val() + "','" + $("[id*=tbl_dis]").val() + "','" + $("[id*='txtprice_" + i + "']").val() + "',N'" + $("[id*='txtvendet_" + i + "']").val() + "','" + $("[id*='txtregdt_" + i + "']").val() + "',N'" + donor_final + "','" + empId + "',getdate(),'',0,'');";
                    }
                    else {
                        $.notify("Enter Acession No.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                }
            }
            //else {
            //            ins = "insert into lib_cd_master values(N'" + $("[id*='txt_cd_tit']").val() + "','" + auth_final + "','" + $("[id*='txt_isbn']").val() + "','" + $("[id*='cd_lang']").val() + "','" + cd_rd + "','" + $("[id*='txt_key']").val() + "','" + pub_final + "','" + $("[id*='txt_yr']").val() + "','" + $("[id*='txt_dur']").val() + "','" + $("[id*='ddlcourse_cd']").val() + "','" + $("[id*='txt_acc_mat']").val() + "','" + $("[id*='txt_sub']").val() + "','" + $("[id*='txt_rem']").val() + "','','','','','','','','','" + donor_final + "','" + empId + "',getdate(),'',0,'');";
            //}
        }
        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/saveData",
            data: '{qry:"' + ins + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (r) {
                if (r.d == true) {
                    $.notify("Data Saved successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                    Cduploadpic(accession_cd);
                    clear_cd();
                    $(function () {



                        $.ajax({
                            type: "POST",
                            url: "BookmasterNew.aspx/Get_cd_Title",
                            data: '{connect:"' + $("[id*='ddlselect']").val() + '"}',
                            contentType: "application/json; charset=utf-8",
                            aync: false,
                            success: function (data) {
                                debugger;

                                for (var i = 0; i < data.d.length; i++) {
                                    // var val = item[i];
                                    //  var item = data.d[i].cd_id;
                                    var mid = data.d[i].cd_name;
                                    donor.push(mid);
                                }
                                // setup autocomplete function pulling from currencies[] array

                                var cd_title = donor;

                                $('#txt_cd_tit').autocomplete({
                                    source: [cd_title]
                                });

                            },
                            error: function () {

                                $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });




                    });
                }
                else {
                    $.notify("Error ! Error Occured , please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
        });

        }
  

    //else {
    //    $.notify("Fill All The Fields.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

    //}



});
$("[id*='cd_bthclear']").on("click", function () {
    clear_cd();
});
//clear cd
function clear_cd() {
    localStorage.setItem("auth", "");
    localStorage.setItem("don", "");
    localStorage.setItem("pub", "");

    $(".tokens-list-token-holder").remove();

    document.getElementById('txt_cd_tit').disabled = false;
    $("[id*='txt_cd_tit']").val('');
    $("[id*='txt_isbn']").val('');
    $("[id*='cd_lang']").val('');
    document.getElementById('rd_cd_iss').checked = true;
    $("[id*='txt_key']").val('');
    $("[id*=ddlcourse_cd]").val('');
    $("[id*=ddlcourse_cd]").multiselect("refresh");
    $('#txt_pub').val('');
    $("[id*='txt_auth']").val('');
    $("[id*='txt_yr']").val('');
    $("[id*='txt_dur']").val('');
    $("[id*='txt_acc_mat']").val('');
    $("[id*='txt_sub']").val('');
    $("[id*='txt_rem']").val('');
    $("[id*='donar_name']").val('');
    $("[id*='txt_cd_cnt']").val('');
    $("[id*='imgcd']").attr('src', '../../../Assets/img/cd.png');
    
    document.getElementById('txt_cd_cnt').disabled = false;
    // $("#txt_cd_cnt").trigger('keydown', { keyCode: 13, which: 13 });
    $("[id*=tbl_cd]")[0].innerHTML = "";
   // $("#divcdhide").hide(500);
      //window.location.reload(true);

    $("#cd_photo").val('');

}

$("#txt_cd_access").on('keydown', function (e) {

    if (e.which === 13) {
        event.preventDefault();
        upd_tit = "";
        upd_id = $("[id*='txt_cd_access']").val();
        get_dt($("[id*='txt_cd_access']").val(), "");
    }
});

$("#txt_cd_tit").on('keydown', function (e) {

    if (e.which === 13) {
        event.preventDefault();
        upd_id = "";
        upd_tit = $("[id*='txt_cd_tit']").val();
        get_dt("", $("[id*='txt_cd_tit']").val());
    }
});

$("#txtmaptitle").on('keydown', function (e) {

    if (e.which === 13) {

        if (e.which === 13) {
            event.preventDefault();
            localStorage.setItem("type","singleTitle")
            get_map("", $("[id*='txtmaptitle']").val());

            
           
        }
    }
});
function get_dt(cd_id, cd_name) {
    $.ajax({
        type: "POST",
        url: "BookmasterNew.aspx/get_cd_data",
        data: '{cd:"' + cd_id + '",cd_name:"' + cd_name + '",type:"cd",connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            if (r.d.length > 0) {
                if (r.d[0].cd_msg == "get") {
                    $(".tokens-list-token-holder").remove();
                    document.getElementById('txt_cd_tit').disabled = true;
                    $("[id*='txt_cd_tit']").val(r.d[0].cd_TITLE);
                    $("[id*='txt_isbn']").val(r.d[0].cd_ISBN);
                    $("[id*='cd_lang']").val(r.d[0].cd_LANG);
                    if (r.d[0].cd_ISSUE_TYPE == "1") {
                        document.getElementById('rd_cd_n_iss').checked = true;
                    } else { document.getElementById('rd_cd_iss').checked = true; }



                    $("[id*='txt_key']").val(r.d[0].cd_KEYWORD);
                    var prod = r.d[0].cd_DEPARTMENT;
                    var arr = [];
                    arr = prod.split(',');
                    $("[id*=ddlcourse_cd]").val(arr);
                    $("[id*=ddlcourse_cd]").multiselect("refresh");

                    localStorage.setItem("auth", r.d[0].cd_AUTHOR);
                    $("[id*='txt_auth']").val(r.d[0].cd_AUTHOR);

                    localStorage.setItem("pub", r.d[0].cd_PUBLISHER);

                    $("[id*='txt_pub']").val(r.d[0].cd_PUBLISHER);

                    localStorage.setItem("don", r.d[0].cd_DONOR_ID);

                    $("[id*='donar_name']").val(r.d[0].cd_DONOR_ID);


                    var aa = $(".tokens-token-list");
                    for (var i = 0; i <= aa.length - 1; i++) {
                        if (aa[i].nextElementSibling.id == "txt_auth") {

                            var arr = r.d[0].cd_AUTHOR.split('|');
                            for (var y = 0; y <= arr.length - 1; y++) {
                                if (arr[y] != "") {
                                    var li = document.createElement("li");
                                    li.setAttribute("class", "tokens-list-token-holder");
                                    li.setAttribute("onClick", "removeItem_cd(this);");
                                    var p = document.createElement("p");

                                    //p.setAttribute("innerHTML", 'abc');
                                    p.textContent = arr[y];
                                    li.append(p);

                                    var span = document.createElement("span");
                                    span.setAttribute("class", "tokens-delete-token");

                                    // span.setAttribute("innerHTML", 'x');
                                    span.textContent = 'x';

                                    li.append(span);



                                    aa[i].prepend(li);
                                }

                            }

                        }


                        else if (aa[i].nextElementSibling.id == "txt_pub") {

                            var arr = r.d[0].cd_PUBLISHER.split('|');
                            for (var y = 0; y <= arr.length - 1; y++) {
                                if (arr[y] != "") {
                                    var li = document.createElement("li");
                                    li.setAttribute("class", "tokens-list-token-holder");
                                    li.setAttribute("onClick", "removeItem_cd(this);");
                                    var p = document.createElement("p");

                                    //p.setAttribute("innerHTML", 'abc');
                                    p.textContent = arr[y];
                                    li.append(p);

                                    var span = document.createElement("span");
                                    span.setAttribute("class", "tokens-delete-token");

                                    // span.setAttribute("innerHTML", 'x');
                                    span.textContent = 'x';

                                    li.append(span);



                                    aa[i].prepend(li);
                                }

                            }

                        }

                        else {
                            var arr = r.d[0].cd_DONOR_ID.split('|');
                            for (var y = 0; y <= arr.length - 1; y++) {
                                if (arr[y] != "") {
                                    var li = document.createElement("li");
                                    li.setAttribute("class", "tokens-list-token-holder");
                                    li.setAttribute("onClick", "removeItem_cd(this);");
                                    var p = document.createElement("p");

                                    //p.setAttribute("innerHTML", 'abc');
                                    p.textContent = arr[y];
                                    li.append(p);

                                    var span = document.createElement("span");
                                    span.setAttribute("class", "tokens-delete-token");

                                    // span.setAttribute("innerHTML", 'x');
                                    span.textContent = 'x';

                                    li.append(span);



                                    aa[i].prepend(li);

                                }
                            }
                        }

                    }
                    var b = imageExists("Library/CD/" + r.d[0].cd_ACCESSION_NO + ".jpg");
                    var b1 = imageExists("Library/CD/" + r.d[0].cd_ACCESSION_NO + ".jpeg");
                    var b2 = imageExists("Library/CD/" + r.d[0].cd_ACCESSION_NO + ".png");
                    var b3 = imageExists("Library/CD/" + r.d[0].cd_ACCESSION_NO + ".gif");

                    if (b == true) {
                        document.getElementById("imgcd").src = "Library/CD/" + r.d[0].cd_ACCESSION_NO + ".jpg";
                    }
                    else if (b1 == true) {
                        document.getElementById("imgcd").src = "Library/CD/" + r.d[0].cd_ACCESSION_NO + ".jpeg";
                    }
                    else if (b2 == true) {
                        document.getElementById("imgcd").src = "Library/CD/" + r.d[0].cd_ACCESSION_NO + ".png";
                    }
                    else if (b3 == true) {
                        document.getElementById("imgcd").src = "Library/CD/" + r.d[0].cd_ACCESSION_NO + ".gif";
                    }


                    if (b == false && b1 == false && b2 == false && b3 == false) {
                        $("#cd_photo").val('');
                        $("[id*='imgcd']").attr('src', 'images/user.png');
                    }

                    // $('#txt_pub').val(r.d[0].cd_PUBLISHER);
                  //  $("[id*='txt_auth']").val(r.d[0].cd_AUTHOR);
                    $("[id*='txt_yr']").val(r.d[0].cd_YEAR);
                    $("[id*='txt_dur']").val(r.d[0].cd_DURATION);
                    $("[id*='txt_acc_mat']").val(r.d[0].cd_ACC_MATERIALS);
                    $("[id*='txt_sub']").val(r.d[0].cd_SUBJ);
                    $("[id*='txt_rem']").val(r.d[0].cd_REMARK);
                    //$("[id*='donar_name']").val(r.d[0].cd_DONOR_ID);
                    $("[id*='txt_cd_cnt']").val(r.d.length);
                    document.getElementById('txt_cd_cnt').disabled = true;
                    // $("#txt_cd_cnt").trigger('keydown', { keyCode: 13, which: 13 });
                    $("#txt_cd_cnt").trigger(jQuery.Event('keydown', { keyCode: 13, which: 13 }));
                    var dd1 = $("[id*='ddlcdprefix']");

                    for (var i = 0; i < r.d.length; i++) {
                        $("[id*='tbl_dis']").val(r.d[0].dis_type);
                        $("[id*='txtcdAccession_" + i + "']").val(r.d[i].cd_ACCESSION_NO);
                        $("[id*='txtbillno_" + i + "']").val(r.d[i].cd_BILL_NO);
                        $("[id*='txtbilldt_" + i + "']").val(r.d[i].cd_BILL_DT.substring(0, 10));
                        $("[id*='txtmrp_" + i + "']").val(r.d[i].cd_MRP);
                        $("[id*='txtdiscount_" + i + "']").val(r.d[i].cd_DISCOUNT);
                        $("[id*='txtprice_" + i + "']").val(r.d[i].cd_PRICE);
                        $("[id*='txtvendet_" + i + "']").val(r.d[i].cd_VENDOR);
                        $("[id*='txtregdt_" + i + "']").val(r.d[i].cd_REG_DT.substring(0, 10));
                        $("[id*='ddlcdprefix_" + i + "']").val(r.d[i].prefix);

                    }

                    $("#menu_toggle").click();
                    //if (r.d.length == 1) {
                    //}
                    //else {
                    //    $("#tbl_cd").find("*").attr("disabled", "disabled");
                    //}
                    //document.getElementById('cd_bthSave').innerText = "Update";
                }
                else if (r.d[0].cd_msg == "multiple") {
                    //Auth_cd_id
                    //$.notify("Mismatched Tile:" + r.d[0].cd_id + " and Author:" + r.d[0].Auth_cd_id + ".", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $.confirm({

                        title: 'CD Master',
                        text: "Mismatched Tile:" + r.d[0].cd_id + " and Author:" + r.d[0].Auth_cd_id + ".",
                        content: 'Mismatched Tile:" + r.d[0].cd_id + " and Author:" + r.d[0].Auth_cd_id + ".',
                        confirmButton: 'Yes',
                        cancelButton: 'No',
                        confirm: function () {
                            var new_id = cd_id;
                            var id = [];
                            id = new_id.split(",");
                            
                            $.ajax({
                                type: "POST",
                                url: "BookmasterNew.aspx/get_cd_data",
                                data: '{cd:"' + id[0] + '",cd_name:"' + cd_id + '",type:"cd",connect:"' + $("[id*='ddlselect']").val() + '"}',
                                contentType: "application/json; charset=utf-8",
                                success: function (r) {
                                    if (r.d.length > 0) {
                                        if (r.d[0].cd_msg == "get") {

                                            $(".tokens-list-token-holder").remove();
                                            document.getElementById('txt_cd_tit').disabled = true;
                                            $("[id*='txt_cd_tit']").val(r.d[0].cd_TITLE);
                                            $("[id*='txt_isbn']").val(r.d[0].cd_ISBN);
                                            $("[id*='cd_lang']").val(r.d[0].cd_LANG);
                                            if (r.d[0].cd_ISSUE_TYPE == "1") {
                                                document.getElementById('rd_cd_n_iss').checked = true;
                                            } else { document.getElementById('rd_cd_iss').checked = true; }



                                            $("[id*='txt_key']").val(r.d[0].cd_KEYWORD);
                                            var prod = r.d[0].cd_DEPARTMENT;
                                            var arr = [];
                                            arr = prod.split(',');
                                            $("[id*=ddlcourse_cd]").val(arr);
                                            $("[id*=ddlcourse_cd]").multiselect("refresh");

                                            localStorage.setItem("auth", r.d[0].cd_AUTHOR);
                                            $("[id*='txt_auth']").val(r.d[0].cd_AUTHOR);

                                            localStorage.setItem("pub", r.d[0].cd_PUBLISHER);

                                            $("[id*='txt_pub']").val(r.d[0].cd_PUBLISHER);

                                            localStorage.setItem("don", r.d[0].cd_DONOR_ID);

                                            $("[id*='donar_name']").val(r.d[0].cd_DONOR_ID);


                                            var aa = $(".tokens-token-list");
                                            for (var i = 0; i <= aa.length - 1; i++) {
                                                if (aa[i].nextElementSibling.id == "txt_auth") {

                                                    var arr = r.d[0].cd_AUTHOR.split('|');
                                                    for (var y = 0; y <= arr.length - 1; y++) {
                                                        if (arr[y] != "") {
                                                            var li = document.createElement("li");
                                                            li.setAttribute("class", "tokens-list-token-holder");
                                                            li.setAttribute("onClick", "removeItem_cd(this);");
                                                            var p = document.createElement("p");

                                                            //p.setAttribute("innerHTML", 'abc');
                                                            p.textContent = arr[y];
                                                            li.append(p);

                                                            var span = document.createElement("span");
                                                            span.setAttribute("class", "tokens-delete-token");

                                                            // span.setAttribute("innerHTML", 'x');
                                                            span.textContent = 'x';

                                                            li.append(span);



                                                            aa[i].prepend(li);
                                                        }

                                                    }

                                                }


                                                else if (aa[i].nextElementSibling.id == "txt_pub") {

                                                    var arr = r.d[0].cd_PUBLISHER.split('|');
                                                    for (var y = 0; y <= arr.length - 1; y++) {
                                                        if (arr[y] != "") {
                                                            var li = document.createElement("li");
                                                            li.setAttribute("class", "tokens-list-token-holder");
                                                            li.setAttribute("onClick", "removeItem_cd(this);");
                                                            var p = document.createElement("p");

                                                            //p.setAttribute("innerHTML", 'abc');
                                                            p.textContent = arr[y];
                                                            li.append(p);

                                                            var span = document.createElement("span");
                                                            span.setAttribute("class", "tokens-delete-token");

                                                            // span.setAttribute("innerHTML", 'x');
                                                            span.textContent = 'x';

                                                            li.append(span);



                                                            aa[i].prepend(li);
                                                        }

                                                    }

                                                }

                                                else {
                                                    var arr = r.d[0].cd_DONOR_ID.split('|');
                                                    for (var y = 0; y <= arr.length - 1; y++) {
                                                        if (arr[y] != "") {
                                                            var li = document.createElement("li");
                                                            li.setAttribute("class", "tokens-list-token-holder");
                                                            li.setAttribute("onClick", "removeItem_cd(this);");
                                                            var p = document.createElement("p");

                                                            //p.setAttribute("innerHTML", 'abc');
                                                            p.textContent = arr[y];
                                                            li.append(p);

                                                            var span = document.createElement("span");
                                                            span.setAttribute("class", "tokens-delete-token");

                                                            // span.setAttribute("innerHTML", 'x');
                                                            span.textContent = 'x';

                                                            li.append(span);



                                                            aa[i].prepend(li);

                                                        }
                                                    }
                                                }

                                            }
                                            var b = imageExists("Library/CD/" + r.d[0].cd_ACCESSION_NO + ".jpg");
                                            var b1 = imageExists("Library/CD/" + r.d[0].cd_ACCESSION_NO + ".jpeg");
                                            var b2 = imageExists("Library/CD/" + r.d[0].cd_ACCESSION_NO + ".png");
                                            var b3 = imageExists("Library/CD/" + r.d[0].cd_ACCESSION_NO + ".gif");

                                            if (b == true) {
                                                document.getElementById("imgcd").src = "Library/CD/" + r.d[0].cd_ACCESSION_NO + ".jpg";
                                            }
                                            else if (b1 == true) {
                                                document.getElementById("imgcd").src = "Library/CD/" + r.d[0].cd_ACCESSION_NO + ".jpeg";
                                            }
                                            else if (b2 == true) {
                                                document.getElementById("imgcd").src = "Library/CD/" + r.d[0].cd_ACCESSION_NO + ".png";
                                            }
                                            else if (b3 == true) {
                                                document.getElementById("imgcd").src = "Library/CD/" + r.d[0].cd_ACCESSION_NO + ".gif";
                                            }
                                            if (b == false && b1 == false && b2 == false && b3 == false) {
                                                $("#cd_photo").val('');
                                                $("[id*='imgcd']").attr('src', 'images/user.png');
                                            }
                                            // $('#txt_pub').val(r.d[0].cd_PUBLISHER);
                                            //  $("[id*='txt_auth']").val(r.d[0].cd_AUTHOR);
                                            $("[id*='txt_yr']").val(r.d[0].cd_YEAR);
                                            $("[id*='txt_dur']").val(r.d[0].cd_DURATION);
                                            $("[id*='txt_acc_mat']").val(r.d[0].cd_ACC_MATERIALS);
                                            $("[id*='txt_sub']").val(r.d[0].cd_SUBJ);
                                            $("[id*='txt_rem']").val(r.d[0].cd_REMARK);
                                            //$("[id*='donar_name']").val(r.d[0].cd_DONOR_ID);
                                            $("[id*='txt_cd_cnt']").val(r.d.length);
                                            document.getElementById('txt_cd_cnt').disabled = true;
                                            // $("#txt_cd_cnt").trigger('keydown', { keyCode: 13, which: 13 });
                                            $("#txt_cd_cnt").trigger(jQuery.Event('keydown', { keyCode: 13, which: 13 }));


                                            var dd1 = $("[id*='ddlcdprefix']");

                                            for (var i = 0; i < r.d.length; i++) {
                                                $("[id*='tbl_dis']").val(r.d[0].dis_type);
                                                $("[id*='txtcdAccession_" + i + "']").val(r.d[i].cd_ACCESSION_NO);
                                                $("[id*='txtbillno_" + i + "']").val(r.d[i].cd_BILL_NO);
                                                $("[id*='txtbilldt_" + i + "']").val(r.d[i].cd_BILL_DT.substring(0, 10));
                                                $("[id*='txtmrp_" + i + "']").val(r.d[i].cd_MRP);
                                                $("[id*='txtdiscount_" + i + "']").val(r.d[i].cd_DISCOUNT);
                                                $("[id*='txtprice_" + i + "']").val(r.d[i].cd_PRICE);
                                                $("[id*='txtvendet_" + i + "']").val(r.d[i].cd_VENDOR);
                                                $("[id*='txtregdt_" + i + "']").val(r.d[i].cd_REG_DT.substring(0, 10));
                                                $("[id*='ddlcdprefix_" + i + "']").val(r.d[i].prefix);

                                            }
                                            $("#menu_toggle").click();

                                            if (r.d.length == 1) {
                                            }
                                            else {
                                             //   $("#tbl_cd").find("*").attr("disabled", "disabled");
                                            }
                                            //document.getElementById('cd_bthSave').innerText = "Update";
                                        }
                                        $("[id*='Editmodal_cd']").modal('hide');
                                    }
                                }
                            });
                        },
                    });
                }
                else if (r.d[0].cd_msg == "") {
                    $.notify("No data found", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
                $("[id*='Editmodal_cd']").modal('hide');
            }
        }
    });
}
function removeItem_cd(li) {
    var ul = li.parentElement;
    ul.removeChild(li);

    var str = localStorage.getItem("auth").toString();
    if (str.indexOf(li.innerText.substring(0, li.innerText.length - 1)) > -1) {
        var f_str = str.replace(li.innerText.substring(0, li.innerText.length - 1), '');
        var auth1 = $("[id*='txt_auth']").val().replace(li.innerText.substring(0, li.innerText.length - 1), '');
        $("[id*='txt_auth']").val(auth1);
        localStorage.setItem("auth", f_str);
    }


    var str_pub = localStorage.getItem("pub").toString();
    if (str_pub.indexOf(li.innerText.substring(0, li.innerText.length - 1)) > -1) {
        var f_str_pub = str_pub.replace(li.innerText.substring(0, li.innerText.length - 1), '');
        var pub1 = $("[id*='txt_pub']").val().replace(li.innerText.substring(0, li.innerText.length - 1), '');
        $("[id*='txt_pub']").val(pub1);
        localStorage.setItem("pub", f_str_pub);
    }

    var str_don = localStorage.getItem("don").toString();
    if (str_don.indexOf(li.innerText.substring(0, li.innerText.length - 1)) > -1) {
        var f_str_don = str_don.replace(li.innerText.substring(0, li.innerText.length - 1), '');
        var don1 = $("[id*='donar_name']").val().replace(li.innerText.substring(0, li.innerText.length - 1), '');
        $("[id*='donar_name']").val(don1);
        localStorage.setItem("don", f_str_don);
    }
    //  li.parentElement.remove();
    //alert('hi');
}

/////////////////////////////////MAP//////////////////////////////////////////////////////////
function criteraichng(id) {
    var ind = id.split('_');
    var type = "";
    if (ind[0] == "ddlcdprefix") {
        type = "cd";

        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/getMaxAccession",
            data: '{accession:"' + $("[id*=ddlcdprefix_" + ind[1] + "] :selected").text() + '",type:"' + type + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                var acc = data.d.toString();
                var arr = acc.split('|');
                var new_val = (parseInt(arr[0])) + 1;
                $("[id*=txtcdAccession_" + ind[1] + "]").val($("[id*=ddlcdprefix_" + ind[1] + "] :selected").text() + app0(arr[0], new_val.toString()));
            },
            error: function () {

                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });


        for (var i = 0; i <= $("[id^='ddlcdprefix_']").length - 1; i++) {
            if (ind[1] < i) {
                $("[id*=ddlcdprefix_" + i + "]")[0].selectedIndex = $("[id*=ddlcdprefix_" + ind[1] + "]")[0].selectedIndex;
                $("[id*=txtcdAccession_" + i + "]")[0].value = '';
            }
        }
    }
    else if (ind[0] == "ddlprefix") {
        type = "map";

        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/getMaxAccession",
            data: '{accession:"' + $("[id*=ddlprefix_" + ind[1] + "] :selected").text() + '",type:"' + type + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {

                var acc = data.d.toString();
                var arr = acc.split('|');
                var new_val = (parseInt(arr[0])) + 1;
                $("[id*=txtmapAccession_" + ind[1] + "]").val($("[id*=ddlprefix_" + ind[1] + "] :selected").text() + app0(arr[0], new_val.toString()));



            },
            error: function () {

                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });


        for (var i = 0; i <= $("[id^='ddlprefix']").length - 1; i++) {
            if (ind[1] < i) {
                $("[id*=ddlprefix_" + i + "]")[0].selectedIndex = $("[id*=ddlprefix_" + ind[1] + "]")[0].selectedIndex;
                $("[id*=txtmapAccession_" + i + "]")[0].value = '';
            }
        }
    }
    else {

        type = "book";

        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/getMaxAccession",
            data: '{accession:"' + $("[id*=ddlbookprefix_" + ind[1] + "] :selected").text() + '",type:"' + type + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {

                var acc = data.d.toString();
                var arr = acc.split('|');
                var new_val = (parseInt(arr[0])) + 1;
                $("[id*=txtbookAccession_" + ind[1] + "]").val($("[id*=ddlbookprefix_" + ind[1] + "] :selected").text() + app0(arr[0], new_val.toString()));



            },
            error: function () {

                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        });


        for (var i = 0; i <= $("[id^='ddlbookprefix_']").length - 1; i++) {
            if (ind[1] < i) {
                $("[id*=ddlbookprefix_" + i + "]")[0].selectedIndex = $("[id*=ddlbookprefix_" + ind[1] + "]")[0].selectedIndex;
                $("[id*=txtbookAccession_" + i + "]")[0].value = '';
            }
        }
    }



};

$("[id*=tblmap]").on('blur', function () {


});
$("#txt_map_count").on('keydown', function (e) {

    if (e.which === 13) {
        event.preventDefault();
        createTable();
    }
});
function createTable() {
    
    var count = $("[id*='txt_map_count']")[0].value;
    if (count != 0 && count != "") {
        var tds = document.querySelectorAll('[id*=tblmap] tbody tr');
        if (tds.length > 0) {
            if (tds.length < count) {
                var tds = document.querySelectorAll('[id*=tblmap] tbody tr');
                var tbl_len = parseInt(tds.length);
                for (var i = tbl_len; i < count; i++) {
                    var data = parseInt(i) + 1;
                    $("[id*=tblmap]").append("<tr><td>" + data + "</td><td><select id='ddlprefix_" + i + "' class='form-control' onchange='criteraichng(this.id);'></select></td><td><input type='text' id='txtmapAccession_" + i + "'/></td><td><input type='text' id='txtmapbillno_" + i + "'/></td><td><input type='text' id='txtmapbilldt_" + i + "'/></td><td><input type='text' id='txtmapmrp_" + i + "'/></td><td><input type='text' id='txtmapdiscount_" + i + "'/></td><td><input type='text' id='txtmapprice_" + i + "'/></td><td><input type='text' id='txtmapvendet_" + i + "'/></td><td><input type='text' id='txtmapregdt_" + i + "'/></td></tr>");

                    $('[id*=txtmapregdt]').datetimepicker({
                        singleDatePicker: true,
                        calender_style: "picker_1",
                        timepicker: false,
                        format: 'd-M-Y'
                    }, function (start, end, label) {
                        console.log(start.toISOString(), end.toISOString(), label);
                    });
                    $('[id*=txtmapbilldt]').datetimepicker({
                        singleDatePicker: true,
                        calender_style: "picker_1",
                        timepicker: false,
                        format: 'd-M-Y'
                    }, function (start, end, label) {
                        console.log(start.toISOString(), end.toISOString(), label);
                    });


                    ///vendor

                    $(function () {

                        var books_arr = [];

                        $.ajax({
                            type: "POST",
                            url: "BookmasterNew.aspx/LoadPublisher",
                            data: '{type:"v",connect:"' + $("[id*='ddlselect']").val() + '"}',
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            success: function (data) {
                                debugger;

                                for (var i = 0; i < data.d.length; i++) {
                                    // var val = item[i];
                                    var item = data.d[i];
                                    var mid = data.d[i];
                                    books_arr.push(mid);
                                }
                                // setup autocomplete function pulling from currencies[] array


                                var books = books_arr;

                                $('[id*=txtmapvendet]').autocomplete({
                                    source: [books]
                                });


                            },
                            error: function () {

                                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });




                    });
                    //prefix

                    $.ajax({
                        type: "POST",
                        url: "BookmasterNew.aspx/LoadPrefix",
                        data: '{type:"map",connect:"' + $("[id*='ddlselect']").val() + '"}',
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (data) {
                            $("[id^='ddlprefix']").empty().append('<option selected="selected" value="0">--select--</option>');
                            $.each(data.d, function () {
                                $("[id^='ddlprefix']").append($("<option></option>").val(this['Value']).html(this['Text']));
                            });

                        },
                        error: function () {

                            //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    });
                    fill_tbl_map_val(i);

                }
            }
            else if (tds.length > count) {
                var tds = document.querySelectorAll('[id*=tblmap] tbody tr');
                var tbl_len = parseInt(tds.length) + 3;

                var init_val = parseInt(tds.length) + 1;
                for (var i = init_val; i < tbl_len; i--) {
                    if (count != tds.length) {
                        document.getElementById("tblmap").deleteRow(i);
                        tds = document.querySelectorAll('[id*=tblmap] tbody tr');
                        tbl_len = parseInt(tds.length) + 2;
                    }
                    else {
                        tbl_len = parseInt(i) - 1;
                    }
                }
            }
        }
    else{
            $("[id*=tblmap]")[0].innerHTML = "";
        for (var i = 0; i < parseInt(count) ; i++) {
            if (i == 0) {
                $("[id*=tblmap]").append("<thead><tr></tr><tr class='alert-info'><th><center>Sr.No</th><th ><center>Prefix</th><th ><center>Enter Accession No</th><th><center>Bill No.</th><th><center>Bill Date(DD MM YYYY)</th><th><center>MRP</th><th><center>Discount<select id='tbl_dis_map' style='background-color: grey'><option style='color:black'>percent(%)</option><option style='color:black'>price</option></select></th><th><center>Price</th><th><center>Vendor Details  <a class='btn-info btn btn-sm' data-toggle='modal' data-target='#myModal1'><span class='glyphicon glyphicon-plus'></span></a></th><th><center>Registration Details</th></tr></thead>");
                $("[id*=tblmap]").append("<tbody>");
                //document.getElementById("count_cd").style.display = "block";
            }
            var data = parseInt(i) + 1;
            $("[id*=tblmap]").append("<tr><td>" + data + "</td><td><select id='ddlprefix_" + i + "' class='form-control' onchange='criteraichng(this.id);'></select></td><td><input type='text' id='txtmapAccession_" + i + "'/></td><td><input type='text' id='txtmapbillno_" + i + "'/></td><td><input type='text' id='txtmapbilldt_" + i + "'/></td><td><input type='text' id='txtmapmrp_" + i + "'/></td><td><input type='text' id='txtmapdiscount_" + i + "'/></td><td><input type='text' id='txtmapprice_" + i + "'/></td><td><input type='text' id='txtmapvendet_" + i + "'/></td><td><input type='text' id='txtmapregdt_" + i + "'/></td></tr>");
            $('[id*=txtmapregdt]').datetimepicker({
                singleDatePicker: true,
                calender_style: "picker_1",
                timepicker: false,
                format: 'd-M-Y'
            }, function (start, end, label) {
                console.log(start.toISOString(), end.toISOString(), label);
            });
            $('[id*=txtmapbilldt]').datetimepicker({
                singleDatePicker: true,
                calender_style: "picker_1",
                timepicker: false,
                format: 'd-M-Y'
            }, function (start, end, label) {
                console.log(start.toISOString(), end.toISOString(), label);
            });


            ///vendor

            $(function () {

                var books_arr = [];

                $.ajax({
                    type: "POST",
                    url: "BookmasterNew.aspx/LoadPublisher",
                    data: '{type:"v",connect:"' + $("[id*='ddlselect']").val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        debugger;

                        for (var i = 0; i < data.d.length; i++) {
                            // var val = item[i];
                            var item = data.d[i];
                            var mid = data.d[i];
                            books_arr.push(mid);
                        }
                        // setup autocomplete function pulling from currencies[] array


                        var books = books_arr;

                        $('[id*=txtmapvendet]').autocomplete({
                            source: [books]
                        });


                    },
                    error: function () {

                        //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                });




            });

            //prefix

            $.ajax({
                type: "POST",
                url: "BookmasterNew.aspx/LoadPrefix",
                data: '{type:"map",connect:"' + $("[id*='ddlselect']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    $("[id^='ddlprefix']").empty().append('<option selected="selected" value="0">--select--</option>');
                    $.each(data.d, function () {
                        $("[id^='ddlprefix']").append($("<option></option>").val(this['Value']).html(this['Text']));
                    });

                },
                error: function () {

                    //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            });

        }

        $("[id*=tblmap]").append("</tbody>");
    }
    ////else {
    ////    //document.getElementById("count_cd").style.display = "none";
    ////}
}
};
$("[id*=tblmap]").on('blur', 'input[type="text"]', function (e) {
    var id = e.currentTarget.id;
    var sp = id.split('_');
    var int = parseInt(sp[1]) + 1;
    if ($("[id*=tblmap]")[0].innerHTML != "") {
        var tds = document.querySelectorAll('[id*=tblmap] tbody tr');


        if (id.startsWith('txtmapdiscount_')) {
            int = sp[1];
            // for (var i = int; i < tds.length; i++) {

            var word = $("[id*='" + id + "']").val();
            var total = $("[id*='txtmapmrp_" + int + "']").val();
            var discount_value = (total / 100) * word;
            var rate = total - discount_value;
            $("[id*='txtmapdiscount_" + int + "']").val(word);
            $("[id*='txtmapprice_" + int + "']").val(rate);

            // }
        }
    }
});
$("[id*=tblmap]").on('blur', 'input[type="text"]', function (e) {

    if (localStorage.getItem("type") == "insert") {
        var id = e.currentTarget.id;
        var sp = id.split('_');
        var int = parseInt(sp[1]);
        if ($("[id*=tblmap]")[0].innerHTML != "") {
            var tds = document.querySelectorAll('[id*=tblmap] tbody tr');

            if (id.startsWith('txtmapbillno_')) {
                int = sp[1];
                $.ajax({
                    type: "POST",
                    url: "BookmasterNew.aspx/LoadMap",
                    data: '{accession:"' + $("[id*='txtmapAccession_" + int + "']")[0].value + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (r) {
                        if (r.d.length > 0) {
                            $("[id*='txtmapAccession_" + int + "']").val('');
                            $.notify("Alert ! Accession already exists.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
                    },
                    error: function () {

                        //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                });
            }
        }
    }
});
$("[id*=tblmap]").on('keydown', 'input[type="text"]', function (e) {
    var id = e.currentTarget.id;
    var sp = id.split('_');
    var int = parseInt(sp[1]) + 1;
    if (e.which === 13) {
        event.preventDefault();
        if ($("[id*=tblmap]")[0].innerHTML != "") {
            var tds = document.querySelectorAll('[id*=tblmap] tbody tr');
            if (id.startsWith('txtmapAccession_')) {
                var k = 1;
                for (var i = int; i < tds.length; i++) {

                    // String.fromCharCode
                    var word = $("[id*='" + id + "']").val();
                    var myArray = word.split(/[0-9]+/);
                    var novalue = word.split(/\D+/);
                    var value = String(parseInt(novalue[1]) + k);
                    value = app0(novalue[1], value);
                    value = myArray[0] + value;
                    $("[id*='txtmapAccession_" + i + "']").val(value);
                    k++;

                }
            }
            if (id.startsWith('txtmapbillno_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtmapbillno_" + i + "']").val(word);

                }
            }

            if (id.startsWith('txtmapbilldt_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtmapbilldt_" + i + "']").val(word);

                }
            }

            if (id.startsWith('txtmapmrp_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtmapmrp_" + i + "']").val(word);

                }
            }

            if (id.startsWith('txtmapdiscount_')) {
                int = sp[1];
                for (var i = int; i < tds.length; i++) {
                    //var word = $("[id*='" + id + "']").val();
                    //$("[id*='txtmapdiscount_" + i + "']").val(word);

                    var word = $("[id*='" + id + "']").val();
                    var total = $("[id*='txtmapmrp_" + i + "']").val();
                    var discount_value = (total / 100) * word;
                    var rate = total - discount_value;
                    $("[id*='txtmapdiscount_" + i + "']").val(word);
                    $("[id*='txtmapprice_" + i + "']").val(rate);

                }
            }

            if (id.startsWith('txtmapvendet_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtmapvendet_" + i + "']").val(word);

                }
            }

            if (id.startsWith('txtmapregdt_')) {
                for (var i = int; i < tds.length; i++) {
                    var word = $("[id*='" + id + "']").val();
                    $("[id*='txtmapregdt_" + i + "']").val(word);

                }
            }

        }
    }
});

function fill_tbl_map_val(i) {

    var j = parseInt(i) - 1;
    if ($("[id*='txtmapAccession_" + j + "']").val() != "") {
        var word = $("[id*='txtmapAccession_" + j + "']").val();
        var myArray = word.split(/[0-9]+/);
        var novalue = word.split(/\D+/);
        if (myArray[0] != "") {
            var value = String(parseInt(novalue[1]) + 1);
            value = app0(novalue[1], value);
        }
        else {
            var value = String(parseInt(novalue[0]) + 1);
            value = app0(novalue[0], value);
        }

        value = myArray[0] + value;
        $("[id*='txtmapAccession_" + i + "']").val(value);
    }
    if ($("[id*='txtmapbillno_" + j + "']").val() != "") {
        var word = $("[id*='txtmapbillno_" + j + "']").val();
        $("[id*='txtmapbillno_" + i + "']").val(word);
    }
    if ($("[id*='txtmapbilldt_" + j + "']").val() != "") {
        var word = $("[id*='txtmapbilldt_" + j + "']").val();
        $("[id*='txtmapbilldt_" + i + "']").val(word);
    }
    if ($("[id*='txtmapmrp_" + j + "']").val() != "") {
        var word = $("[id*='txtmapmrp_" + j + "']").val();
        $("[id*='txtmapmrp_" + i + "']").val(word);
    }
    if ($("[id*='txtmapdiscount_" + j + "']").val() != "") {
        if ($("[id*=tbl_dis_map]").val() == "percent(%)") {
            var word = $("[id*='txtmapdiscount_" + j + "']").val();
            var total = $("[id*='txtmapmrp_" + j + "']").val();
            var discount_value = (total / 100) * word;
            var rate = total - discount_value;
            $("[id*='txtmapdiscount_" + i + "']").val(word);
            $("[id*='txtmapprice_" + i + "']").val(rate);
        }
        else {
            var word = $("[id*='txtmapdiscount_" + j + "']").val();
            var total = $("[id*='txtmapmrp_" + j + "']").val();
            // var discount_value = (total / 100) * word;
            var rate = total - word;
            $("[id*='txtmapdiscount_" + i + "']").val(word);
            $("[id*='txtmapprice_" + i + "']").val(rate);
        }
    }
    if ($("[id*='txtmapvendet_" + j + "']").val() != "") {
        var word = $("[id*='txtmapvendet_" + j + "']").val();
        $("[id*='txtmapvendet_" + i + "']").val(word);
    }
    if ($("[id*='txtmapregdt_" + j + "']").val() != "") {
        var word = $("[id*='txtmapregdt_" + j + "']").val();
        $("[id*='txtmapregdt_" + i + "']").val(word);
    }
}

function app0(id, value) {
    var z = ""; var d = value;
    if (id.length != d.length) {
        var h = id.length;
        var f = d.length;
        var o = parseInt(h) - parseInt(f);
        for (var j = 0; j < o; j++) {
            z = z + "0";
        }
        value = z + value;
    }
    return value;
}
$("[id*=btnMapClear]").on('click', function () {
    clearMap();
});
$("[id*=btnMapSave]").on('click', function () {


    if (validateMap() == true) {

        if ($("[id*='txtauthor_map']").val() == '') {
            $.notify("Alert ! Please provide Authors.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

            $("[id*=txtauthor_map]").css("border-color", "red");
        }
        else {
            $("[id*=txtauthor_map]").css("border-color", "#ccc");
            if ($("[id*='txtpublisher_map']").val() == '') {
                $.notify("Alert ! Please provide Publishers.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                $("[id*=txtpublisher_map]").css("border-color", "red");
            }
            else {
                $("[id*=txtpublisher_map]").css("border-color", "#ccc");
                if ($("[id*='txtdonor_map']").val() == '') {
                    $.notify("Alert ! Please provide Donors.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

                    $("[id*=txtdonor_map]").css("border-color", "red");
                }
                else {
                    $("[id*=txtdonor_map]").css("border-color", "#ccc");
                    if ($("[id*='ddlMapDept'] :selected").text() == "--select--" || $("[id*='ddlMapDept'] :selected").text() == "") {
                        $("[id*='ddlMapDept']").css("border-color", "red");
                        $.notify("Alert ! Please provide Deprtment.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

                    }
                    else {
                        $("[id*='ddlMapDept']").css("border-color", "#ccc");
                        //  if (localStorage.getItem("type") == "insert") {
                        saveMap(localStorage.getItem("type"));
                        //}
                        //else if  (localStorage.getItem("type") == "insert"){
                        //    saveMap('update');
                        //}
                    }
                }

            }

        }



    }
    else {
        $.notify("Alert ! Please provide all the details.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
    }
});
function validateMap() {
    var retval = true;
    //if ($("[id*='txtmaptitle']").val() == '') {
    //    retval = false;
    //    $("[id*=txtmaptitle]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txtmaptitle]").css("border-color", "#ccc");

    //}
    //if ($("[id*='txtmapisbn']").val() == '') {
    //    retval = false;
    //    $("[id*=txtmapisbn]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txtmapisbn]").css("border-color", "#ccc");

    //}
    ////if ($("[id*='txtmapyear']").val() == '') {
    ////    retval = false;
    ////    $("[id*=txtmapyear]").css("border-color", "red");
    ////}
    ////else {
    ////    $("[id*=txtmapyear]").css("border-color", "#ccc");

    ////}
    //if ($("[id*='ddlmaplang'] :selected").text() == "--Select--") {
    //    retval = false;
    //    $("[id*=ddlmaplang]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=ddlmaplang]").css("border-color", "#ccc");

    //}
    //if ($("[id*='dllmaptype'] :selected").text() == "--Select--") {
    //    retval = false;
    //    $("[id*=dllmaptype]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=dllmaptype]").css("border-color", "#ccc");

    //}
    ////if ($("[id*='txtmapkeywords']").val() == '') {
    ////    retval = false;
    ////    $("[id*=txtmapkeywords]").css("border-color", "red");
    ////}
    ////else {
    ////    $("[id*=txtmapkeywords]").css("border-color", "#ccc");

    ////}
    ////if ($("[id*='txtmapsubj']").val() == '') {
    ////    retval = false;
    ////    $("[id*=txtmapsubj]").css("border-color", "red");
    ////}
    ////else {
    ////    $("[id*=txtmapsubj]").css("border-color", "#ccc");

    ////}
    ////if ($("[id*='txtmapremrk']").val() == '') {
    ////    retval = false;
    ////    $("[id*=txtmapremrk]").css("border-color", "red");
    ////}
    ////else {
    ////    $("[id*=txtmapremrk]").css("border-color", "#ccc");

    ////}
    ////if ($("[id*='ttxmapacmaterial']").val() == '') {
    ////    retval = false;
    ////    $("[id*=ttxmapacmaterial]").css("border-color", "red");
    ////}
    ////else {
    ////    $("[id*=ttxmapacmaterial]").css("border-color", "#ccc");

    ////}
    ////if ($("[id*='txtmapcallno']").val() == '') {
    ////    retval = false;
    ////    $("[id*=txtmapcallno]").css("border-color", "red");
    ////}
    ////else {
    ////    $("[id*=txtmapcallno]").css("border-color", "#ccc");

    ////}

    //if ($("[id*='txt_map_count']").val() == '') {
    //    retval = false;
    //    $("[id*=txt_map_count]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txt_map_count]").css("border-color", "#ccc");

    //}

    return retval;

}

function saveMap(type) {
    var str = "";
    if (localStorage.getItem("auth").toString() != "") {
        if ($("[id*='txtauthor_map']").val() == localStorage.getItem("auth").toString()) {
            str = $("[id*='txtauthor_map']").val();
        }
        else {

            if ($("[id*='txtauthor_map']").val().indexOf(localStorage.getItem("auth").toString()) > -1) {
                str = $("[id*='txtauthor_map']").val();
            }
            else {

                str = $("[id*='txtauthor_map']").val() + "| " + localStorage.getItem("auth").toString();

            }
            // str = $("[id*='txtauthor_map']").val() + "| " + localStorage.getItem("auth").toString();

        }
    }
    else {
        str = $("[id*='txtauthor_map']").val();

    }

    var str_rp = str.replace("| |", "|");
    var str_rp1 = str_rp.replace("||", "|");
    var auth_final = str_rp1.trim();


    var str_pub = "";
    if (localStorage.getItem("pub").toString() != "") {
        if ($("[id*='txtpublisher_map']").val() == localStorage.getItem("pub").toString()) {

            str_pub = $("[id*='txtpublisher_map']").val();

        }
        else {

            if ($("[id*='txtpublisher_map']").val().indexOf(localStorage.getItem("pub").toString()) > -1) {
                str_pub = $("[id*='txtpublisher_map']").val();

            }
            else {

                str_pub = $("[id*='txtpublisher_map']").val() + "| " + localStorage.getItem("pub").toString();


            }
            // str_pub = $("[id*='txtpublisher_map']").val() + "| " + localStorage.getItem("pub").toString();


        }

    }
    else {
        str_pub = $("[id*='txtpublisher_map']").val();

    }

    var str_pub_rp = str_pub.replace("| |", "|");
    var str_pub_rp1 = str_pub_rp.replace("||", "|");
    var pub_final = str_pub_rp1.trim();



    var str_don = "";
    if (localStorage.getItem("don").toString() != "") {
        str_don = $("[id*='txtdonor_map']").val() + "| " + localStorage.getItem("don").toString();
        if ($("[id*='txtdonor_map']").val() == localStorage.getItem("don").toString()) {

            str_don = $("[id*='txtdonor_map']").val();
        }
        else {
            if ($("[id*='txtdonor_map']").val().indexOf(localStorage.getItem("don").toString()) > -1) {
                str_don = $("[id*='txtdonor_map']").val();


            }
            else {

                str_don = $("[id*='txtdonor_map']").val() + "| " + localStorage.getItem("don").toString();


            }
            // str_don = $("[id*='txtdonor_map']").val() + "| " + localStorage.getItem("don").toString();



        }
    }
    else {
        str_don = $("[id*='txtdonor_map']").val();

    }

    var str_don_rp = str_don.replace("| |", "|");
    var str_don_rp1 = str_don_rp.replace("||", "|");

    var donor_final = str_don_rp1.trim();




    var issuetype
    if ($("[id*='dllmaptype'] :selected").text() == "FOR ISSUE") {
        issuetype = 1;
    }
    else {
        issuetype = 0;
    }

    var deptid = "";
    $("[id*='ddlMapDept'] :selected").each(function (i, selected) {
        if (i == 0) {
            deptid = $(selected).val();
        }
        else {
            deptid += "," + $(selected).val();
        }

    });
    var finalquery = "";
    var tds = document.querySelectorAll('[id*=tblmap] tbody tr');
    var accession = [];
    if (type == "insert") {
        var res = maps_arr.indexOf($("[id*='txtmaptitle']").val());
        if (res == -1) {
            var qry = "INSERT INTO [lib_MAP_MASTER]([TITLE],[AUTHOR],[ISBN],[LANG],[ISSUE_TYPE],[KEYWORD],[PUBLISHER],[YEAR],[CALLNO],[DEPARTMENT],[ACC_MATERIALS],[SUBJ],[REMARK],[ACCESSION_NO],[BILL_NO],[BILL_DT],[MRP],[DISCOUNT],[Discount_type],[PRICE],[VENDOR],[REG_DT],[DONOR_ID],[USERID],[CURR_DT],[MOD_DT],[DEL_FLAG],[DEL_DT]) ";
            for (var i = 0; i < tds.length; i++) {
                accession.push($("[id*='txtmapAccession_" + i + "']").val());
                qry += " select N'" + $("[id*='txtmaptitle']").val() + "',N'" + auth_final + "','" + $("[id*='txtmapisbn']").val() + "','" + $("[id*='ddlmaplang'] :selected").text() + "'," + issuetype + ",N'" + $("[id*='txtmapkeywords']").val() + "',N'" + pub_final + "','" + $("[id*='txtmapyear']").val() + "','" + $("[id*='txtmapcallno']").val() + "','" + deptid + "',N'" + $("[id*='ttxmapacmaterial']").val() + "',N'" + $("[id*='txtmapsubj']").val() + "',N'" + $("[id*='txtmapremrk']").val() + "','" + $("[id*='txtmapAccession_" + i + "']").val() + "','" + $("[id*='txtmapbillno_" + i + "']").val() + "','" + $("[id*='txtmapbilldt_" + i + "']").val() + "','" + $("[id*='txtmapmrp_" + i + "']").val() + "','" + $("[id*='txtmapdiscount_" + i + "']").val() + "','" + $("[id*='tbl_dis_map']").val() + "','" + $("[id*='txtmapprice_" + i + "']").val() + "','" + $("[id*='txtmapvendet_" + i + "']").val() + "','" + $("[id*='txtmapregdt_" + i + "']").val() + "',N'" + donor_final + "','" + empId + "',getdate(),NULL,0,NULL union all";
                //qry += " select N'" + $("[id*='txtmaptitle']").val() + "','" + auth_final + "','" + $("[id*='txtmapisbn']").val() + "','" + $("[id*='ddlmaplang'] :selected").text() + "'," + issuetype + ",'" + $("[id*='txtmapkeywords']").val() + "',";
                //qry += "'" + pub_final + "','" + $("[id*='txtmapyear']").val() + "','" + $("[id*='txtmapcallno']").val() + "','" + deptid + "','" + $("[id*='ttxmapacmaterial']").val() + "','" + $("[id*='txtmapsubj']").val() + "','";
                //qry += $("[id*='txtmapremrk']").val() + "','" + $("[id*='txtmapAccession_" + i + "']").val() + "','" + $("[id*='txtmapbillno_" + i + "']").val() + "','" + $("[id*='txtmapbilldt_" + i + "']").val() + "','" + $("[id*='txtmapmrp_" + i + "']").val() + "','" + $("[id*='txtmapdiscount_" + i + "']").val() + "','" + $("[id*='tbl_dis_map']").val() + "','" + $("[id*='txtmapprice_" + i + "']").val() + "','" + $("[id*='txtmapvendet_" + i + "']").val() + "','" + $("[id*='txtmapregdt_" + i + "']").val() + "',";
                //qry += "'" + donor_final + "','" + empId + "',getdate(),NULL,0,NULL union all";
            }

            finalquery = qry.substring(0, qry.lastIndexOf('union all'));
        }
        else {
            finalquery = "";
            $.notify("Error ! " + $("[id*='txtmaptitle']").val() + " title already exists.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

        }
    }
    else if (type == "single") {
        accession.push($("[id*='txtmapAccession_0']").val());

        var qry = "update lib_MAP_MASTER set  AUTHOR=N'" + auth_final + "',ISBN ='" + $("[id*='txtmapisbn']").val() + "',LANG =N'" + $("[id*='ddlmaplang'] :selected").text() + "',ISSUE_TYPE =" + issuetype + ",KEYWORD =N'" + $("[id*='txtmapkeywords']").val() + "',PUBLISHER =N'" + pub_final + "',YEAR ='" + $("[id*='txtmapyear']").val() + "',CALLNO ='" + $("[id*='txtmapcallno']").val() + "',DEPARTMENT='" + deptid + "',ACC_MATERIALS=N'" + $("[id*='ttxmapacmaterial']").val() + "',SUBJ =N'" + $("[id*='txtmapsubj']").val() + "',REMARK =N'" + $("[id*='txtmapremrk']").val() + "',BILL_NO ='" + $("[id*='txtmapbillno_0']").val() + "',BILL_DT ='" + $("[id*='txtmapbilldt_0']").val() + "',MRP ='" + $("[id*='txtmapmrp_0']").val() + "',DISCOUNT ='" + $("[id*='txtmapdiscount_0']").val() + "',PRICE ='" + $("[id*='txtmapprice_0']").val() + "',VENDOR=N'" + $("[id*='txtmapvendet_0']").val() + "',REG_DT ='" + $("[id*='txtmapregdt_0']").val() + "',DONOR_ID=N'" + donor_final + "' where ACCESSION_NO='" + $("[id*='txtmapAccession_0']").val() + "' and del_flag=0";
        finalquery = qry;
    }
    else if (type == "singleTitle") {
        var qry = "";
        for (var i = 0; i < tds.length; i++) {
            accession.push($("[id*='txtmapAccession_" + i + "']").val());
            qry += "update lib_MAP_MASTER set  AUTHOR=N'" + auth_final + "',ISBN ='" + $("[id*='txtmapisbn']").val() + "',LANG =N'" + $("[id*='ddlmaplang'] :selected").text() + "',ISSUE_TYPE =" + issuetype + ",KEYWORD =N'" + $("[id*='txtmapkeywords']").val() + "',PUBLISHER =N'" + pub_final + "',YEAR ='" + $("[id*='txtmapyear']").val() + "',CALLNO ='" + $("[id*='txtmapcallno']").val() + "',DEPARTMENT='" + deptid + "',ACC_MATERIALS=N'" + $("[id*='ttxmapacmaterial']").val() + "',SUBJ =N'" + $("[id*='txtmapsubj']").val() + "',REMARK =N'" + $("[id*='txtmapremrk']").val() + "',BILL_NO ='" + $("[id*='txtmapbillno_0']").val() + "',BILL_DT ='" + $("[id*='txtmapbilldt_0']").val() + "',MRP ='" + $("[id*='txtmapmrp_0']").val() + "',DISCOUNT ='" + $("[id*='txtmapdiscount_0']").val() + "',PRICE ='" + $("[id*='txtmapprice_0']").val() + "',VENDOR=N'" + $("[id*='txtmapvendet_0']").val() + "',REG_DT ='" + $("[id*='txtmapregdt_0']").val() + "',DONOR_ID=N'" + donor_final + "' where ACCESSION_NO='" + $("[id*='txtmapAccession_" + i + "']").val() + "' and del_flag=0";

        }
        //var acc = $("#txt_map_access")[0].value;
        //var final_acc = acc.replace(",", "','");

        finalquery = qry;
    }
    else {
        var qry = "";
        for (var i = 0; i < tds.length; i++) {
            accession.push($("[id*='txtmapAccession_" + i + "']").val());
            qry += "update lib_MAP_MASTER set  AUTHOR=N'" + auth_final + "',ISBN ='" + $("[id*='txtmapisbn']").val() + "',LANG ='" + $("[id*='ddlmaplang'] :selected").text() + "',ISSUE_TYPE =" + issuetype + ",KEYWORD =N'" + $("[id*='txtmapkeywords']").val() + "',PUBLISHER =N'" + pub_final + "',YEAR ='" + $("[id*='txtmapyear']").val() + "',CALLNO ='" + $("[id*='txtmapcallno']").val() + "',DEPARTMENT='" + deptid + "',ACC_MATERIALS='" + $("[id*='ttxmapacmaterial']").val() + "',SUBJ ='" + $("[id*='txtmapsubj']").val() + "',REMARK =N'" + $("[id*='txtmapremrk']").val() + "',BILL_NO ='" + $("[id*='txtmapbillno_0']").val() + "',BILL_DT ='" + $("[id*='txtmapbilldt_0']").val() + "',MRP ='" + $("[id*='txtmapmrp_0']").val() + "',DISCOUNT ='" + $("[id*='txtmapdiscount_0']").val() + "',PRICE ='" + $("[id*='txtmapprice_0']").val() + "',VENDOR=N'" + $("[id*='txtmapvendet_0']").val() + "',REG_DT ='" + $("[id*='txtmapregdt_0']").val() + "',DONOR_ID=N'" + donor_final + "' where ACCESSION_NO='" + $("[id*='txtmapAccession_" + i + "']").val() + "' and del_flag=0";

        }


        finalquery = qry;
    }
    console.log(finalquery);

    //to execute  query
    if (finalquery != '') {
        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/saveData",
            data: '{qry:"' + finalquery + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            success: function (r) {
                if (r.d == true) {
                    uploadpic(accession);
                    //upload pic
                    clearMap();
                    $.notify("Saved successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                    $(function () {



                        $.ajax({
                            type: "POST",
                            url: "BookmasterNew.aspx/Get_book_Title",
                            data: '{type:"map",connect:"' + $("[id*='ddlselect']").val() + '"}',
                            contentType: "application/json; charset=utf-8",
                            aync: false,
                            success: function (data) {
                                debugger;

                                for (var i = 0; i < data.d.length; i++) {
                                    // var val = item[i];
                                    var item = data.d[i].id;
                                    var mid = data.d[i].title;
                                    maps_arr.push(mid);
                                }
                                // setup autocomplete function pulling from currencies[] array


                                var books = maps_arr;

                                $('#txtmaptitle').autocomplete({
                                    source: [books]
                                });


                            },
                            error: function () {

                                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });




                    });
                }
                else {
                    $.notify("Error ! Error Occured , please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
        });
    }
}
//clear map
function clearMap() {
    localStorage.setItem("type", "insert");
    localStorage.setItem("auth", "");
    localStorage.setItem("don", "");
    localStorage.setItem("pub", "");
    document.getElementById('txtmaptitle').disabled = false;
    document.getElementById('txt_map_count').disabled = false;

    $("[id*='txtmaptitle']").val('');
    $("[id*='txtmapisbn']").val('');
    $("[id*='txtmapyear']").val('');
    $("[id*='txtmapkeywords']").val('');
    $("[id*='txtmapsubj']").val('');
    $("[id*='txtmapremrk']").val('');
    $("[id*='ttxmapacmaterial']").val('');
    $("[id*='txtmapcallno']").val('');
    $("[id*='txt_map_count']").val('');
    $("[id*=ddlMapDept]").multiselect("clearSelection");
    $("[id*='txtauthor_map']").val('');
    $("[id*='txtpublisher_map']").val('');
    $("[id*='txtdonor_map']").val('');

    $("[id*=tblmap]")[0].innerHTML = "";
    $(".tokens-list-token-holder").remove();
    document.getElementById("imgMap").src = "../../../Assets/img/Map.png";
    $("#get_photo").val('');
    //window.location.reload(true);
    
}

$("[id*=rdbSingle]").on('click', function () {
    $("[id*=divSingle]").show();
    $("[id*=divMultiple]").hide();

});
$("[id*=rdbMultiple]").on('click', function () {
    $("[id*=divMultiple]").show();
    $("[id*=divSingle]").hide();
});
$("#txt_map_access").on('keydown', function (e) {

    if (e.which === 13) {
        event.preventDefault();
        if ($("#txt_map_access")[0].value.indexOf(',') > -1) {
            fillMultipledata($("#txt_map_access")[0].value);
            localStorage.setItem("type", "multiple");
        }
        else {
            localStorage.setItem("type", "single");
            fillSingledata($("#txt_map_access")[0].value);
        }
    }
});
function fillSingledata(accession) {
    $.ajax({
        type: "POST",
        url: "BookmasterNew.aspx/LoadMap",
        data: '{accession:"' + accession + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            if (r.d.length > 0) {
                document.getElementById('txt_map_count').disabled = true;
                $(".tokens-list-token-holder").remove();
                $('#Editmodal').modal('hide');
                $("[id*='txtmaptitle']").val(r.d[0].TITLE);
                $("[id*='txtmapisbn']").val(r.d[0].ISBN);
                $("[id*='txtmapyear']").val(r.d[0].YEAR);
                $("[id*='txtmapkeywords']").val(r.d[0].KEYWORD);
                $("[id*='txtmapsubj']").val(r.d[0].SUBJ);
                $("[id*='txtmapremrk']").val(r.d[0].REMARK);
                $("[id*='ttxmapacmaterial']").val(r.d[0].ACC_MATERIALS);
                $("[id*='txtmapcallno']").val(r.d[0].CALLNO);
                $("[id*='txt_map_count']").val(1);

                var dd = $("[id*='ddlmaplang']")[0];
                for (var i = 0; i < dd.options.length; i++) {
                    if (dd.options[i].text === r.d[0].LANG) {
                        dd.selectedIndex = i;
                        break;
                    }
                }



                if (r.d[0].ISSUE_TYPE == "1") {
                    $("[id*='dllmaptype']")[0].selectedIndex = 1;
                } else { $("[id*='dllmaptype']")[0].selectedIndex = 2; }



                var prod = r.d[0].DEPARTMENT;
                var arr = [];
                arr = prod.split(',');
                $("[id*=ddlMapDept]").val(arr);
                $("[id*=ddlMapDept]").multiselect("refresh");

                localStorage.setItem("auth", r.d[0].AUTHOR);
                $("[id*='txtauthor_map']").val(r.d[0].AUTHOR);

                localStorage.setItem("pub", r.d[0].PUBLISHER);

                $("[id*='txtpublisher_map']").val(r.d[0].PUBLISHER);

                localStorage.setItem("don", r.d[0].DONOR_ID);

                $("[id*='txtdonor_map']").val(r.d[0].DONOR_ID);


                var aa = $(".tokens-token-list");
                for (var i = 0; i <= aa.length - 1; i++) {
                    if (aa[i].nextElementSibling.id == "txtauthor_map") {

                        var arr = r.d[0].AUTHOR.split('|');
                        for (var y = 0; y <= arr.length - 1; y++) {
                            if (arr[y] != "") {
                                var li = document.createElement("li");
                                li.setAttribute("class", "tokens-list-token-holder");
                                li.setAttribute("onClick", "removeItem(this);");
                                var p = document.createElement("p");

                                //p.setAttribute("innerHTML", 'abc');
                                p.textContent = arr[y];
                                li.append(p);

                                var span = document.createElement("span");
                                span.setAttribute("class", "tokens-delete-token");

                                // span.setAttribute("innerHTML", 'x');
                                span.textContent = 'x';

                                li.append(span);



                                aa[i].prepend(li);
                            }

                        }

                    }


                    else if (aa[i].nextElementSibling.id == "txtpublisher_map") {

                        var arr = r.d[0].PUBLISHER.split('|');
                        for (var y = 0; y <= arr.length - 1; y++) {
                            if (arr[y] != "") {
                                var li = document.createElement("li");
                                li.setAttribute("class", "tokens-list-token-holder");
                                li.setAttribute("onClick", "removeItem(this);");
                                var p = document.createElement("p");

                                //p.setAttribute("innerHTML", 'abc');
                                p.textContent = arr[y];
                                li.append(p);

                                var span = document.createElement("span");
                                span.setAttribute("class", "tokens-delete-token");

                                // span.setAttribute("innerHTML", 'x');
                                span.textContent = 'x';

                                li.append(span);



                                aa[i].prepend(li);
                            }

                        }

                    }

                    else {
                        var arr = r.d[0].DONOR_ID.split('|');
                        for (var y = 0; y <= arr.length - 1; y++) {
                            if (arr[y] != "") {
                                var li = document.createElement("li");
                                li.setAttribute("class", "tokens-list-token-holder");
                                li.setAttribute("onClick", "removeItem(this);");
                                var p = document.createElement("p");

                                //p.setAttribute("innerHTML", 'abc');
                                p.textContent = arr[y];
                                li.append(p);

                                var span = document.createElement("span");
                                span.setAttribute("class", "tokens-delete-token");

                                // span.setAttribute("innerHTML", 'x');
                                span.textContent = 'x';

                                li.append(span);



                                aa[i].prepend(li);

                            }
                        }
                    }

                }

                ////fill bill table
                createTable();
                var dd1 = $("[id*='ddlprefix_0']");

                dd1.val(r.d[0].prefix);
                //$("[id*='txtmapAccession_']")[0].disabled = 'disabled ';
                //$("[id*='txtmapbillno_']")[0].disabled = 'disabled ';
                //$("[id*='txtmapbilldt_']")[0].disabled = 'disabled ';
                //$("[id*='txtmapmrp_']")[0].disabled = 'disabled ';
                //$("[id*='txtmapdiscount_']")[0].disabled = 'disabled ';
                //$("[id*='txtmapprice_']")[0].disabled = 'disabled ';
                //$("[id*='txtmapvendet_']")[0].disabled = 'disabled ';

                //$("[id*='txtmapregdt_']")[0].disabled = 'disabled ';


                ///assign data
                $("[id*='txtmapAccession_']")[0].value = r.d[0].ACCESSION_NO;
                $("[id*='txtmapbillno_']")[0].value = r.d[0].BILL_NO;
                $("[id*='txtmapbilldt_']")[0].value = r.d[0].BILL_DT.substring(0, 10);
                $("[id*='txtmapmrp_']")[0].value = r.d[0].MRP;
                $("[id*='txtmapdiscount_']")[0].value = r.d[0].DISCOUNT;
                $("[id*='txtmapprice_']")[0].value = r.d[0].PRICE;
                $("[id*='txtmapvendet_']")[0].value = r.d[0].VENDOR;
                $("[id*='txtmapregdt_']")[0].value = r.d[0].REG_DT.substring(0, 10);

                var b = imageExists("Library/Map/" + r.d[0].ACCESSION_NO + ".jpg");
                var b1 = imageExists("Library/Map/" + r.d[0].ACCESSION_NO + ".jpeg");
                var b2 = imageExists("Library/Map/" + r.d[0].ACCESSION_NO + ".png");
                var b3 = imageExists("Library/Map/" + r.d[0].ACCESSION_NO + ".gif");

                if (b == true) {
                    document.getElementById("imgMap").src = "Library/Map/" + r.d[0].ACCESSION_NO + ".jpg";
                }
                else if (b1 == true) {
                    document.getElementById("imgMap").src = "Library/Map/" + r.d[0].ACCESSION_NO + ".jpeg";
                }
                else if (b2 == true) {
                    document.getElementById("imgMap").src = "Library/Map/" + r.d[0].ACCESSION_NO + ".png";
                }
                else if (b3 == true) {
                    document.getElementById("imgMap").src = "Library/Map/" + r.d[0].ACCESSION_NO + ".gif";
                }
                $("#menu_toggle").click();

                if (b == false && b1 == false && b2 == false && b3 == false) {
                    $("#get_photo").val('');
                    $("[id*='imgMap']").attr('src', 'images/user.png');
                }
            }
            else {
                $.notify("Error ! Error Occured , please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        }
    });
}
function imageExists(image_url) {

    var http = new XMLHttpRequest();

    http.open('HEAD', image_url, false);
    http.send();

    return http.status != 404;

}
function removeItem(li) {
    var ul = li.parentElement;
    ul.removeChild(li);

    var str = localStorage.getItem("auth").toString();
    if (str.indexOf(li.innerText.substring(0, li.innerText.length - 1)) > -1) {
        var f_str = str.replace(li.innerText.substring(0, li.innerText.length - 1), '');
        var auth1 = $("[id*='txtauthor_map']").val().replace(li.innerText.substring(0, li.innerText.length - 1), '');
        $("[id*='txtauthor_map']").val(auth1);
        localStorage.setItem("auth", f_str);
    }


    var str_pub = localStorage.getItem("pub").toString();
    if (str_pub.indexOf(li.innerText.substring(0, li.innerText.length - 1)) > -1) {
        var f_str_pub = str_pub.replace(li.innerText.substring(0, li.innerText.length - 1), '');
        var pub1 = $("[id*='txtpublisher_map']").val().replace(li.innerText.substring(0, li.innerText.length - 1), '');
        $("[id*='txtpublisher_map']").val(pub1);
        localStorage.setItem("pub", f_str_pub);
    }

    var str_don = localStorage.getItem("don").toString();
    if (str_don.indexOf(li.innerText.substring(0, li.innerText.length - 1)) > -1) {
        var f_str_don = str_don.replace(li.innerText.substring(0, li.innerText.length - 1), '');
        var don1 = $("[id*='txtdonor_map']").val().replace(li.innerText.substring(0, li.innerText.length - 1), '');
        $("[id*='txtdonor_map']").val(don1);
        localStorage.setItem("don", f_str_don);
    }
    //  li.parentElement.remove();
    //alert('hi');
}
function fillMultipledata(accession) {

    get_map($("[id*='txt_map_access']").val(), "");


}

function get_map(cd_id, cd_name) {
    $.ajax({
        type: "POST",
        url: "BookmasterNew.aspx/get_cd_data",
        data: '{cd:"' + cd_id + '",cd_name:"' + cd_name + '",type:"map",connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            if (r.d.length > 0) {
                if (r.d[0].cd_msg == "get") {
                    document.getElementById('txt_map_count').disabled = true;

                    $(".tokens-list-token-holder").remove();

                    //document.getElementById('txtmaptitle').disabled = true;
                    $("[id*='txtmaptitle']").val(r.d[0].cd_TITLE);
                    //  $("[id*='txtmaptitle']")[0].disabled = 'disabled';
                    document.getElementById('txtmaptitle').disabled = true;
                    $("[id*='txtmapisbn']").val(r.d[0].cd_ISBN);



                    var dd = $("[id*='ddlmaplang']")[0];
                    for (var i = 0; i < dd.options.length; i++) {
                        if (dd.options[i].text === r.d[0].cd_LANG) {
                            dd.selectedIndex = i;
                            break;
                        }
                    }



                    if (r.d[0].cd_ISSUE_TYPE == "1") {
                        $("[id*='dllmaptype']")[0].selectedIndex = 1;
                    } else { $("[id*='dllmaptype']")[0].selectedIndex = 2; }



                    $("[id*='txtmapkeywords']").val(r.d[0].cd_KEYWORD);
                    var prod = r.d[0].cd_DEPARTMENT;
                    var arr = [];
                    arr = prod.split(',');
                    $("[id*=ddlMapDept]").val(arr);
                    $("[id*=ddlMapDept]").multiselect("refresh");

                    $("[id*='txtmapcallno']").val(r.d[0].CALLNO);


                   // localStorage.setItem("type", "update");




                    localStorage.setItem("auth", r.d[0].cd_AUTHOR);
                    $("[id*='txtauthor_map']").val(r.d[0].cd_AUTHOR);

                    localStorage.setItem("pub", r.d[0].cd_PUBLISHER);

                    $("[id*='txtpublisher_map']").val(r.d[0].cd_PUBLISHER);

                    localStorage.setItem("don", r.d[0].cd_DONOR_ID);

                    $("[id*='txtdonor_map']").val(r.d[0].cd_DONOR_ID);


                    var aa = $(".tokens-token-list");
                    for (var i = 0; i <= aa.length - 1; i++) {
                        if (aa[i].nextElementSibling.id == "txtauthor_map") {

                            var arr = r.d[0].cd_AUTHOR.split('|');
                            for (var y = 0; y <= arr.length - 1; y++) {
                                if (arr[y] != "") {
                                    var li = document.createElement("li");
                                    li.setAttribute("class", "tokens-list-token-holder");
                                    li.setAttribute("onClick", "removeItem(this);");
                                    var p = document.createElement("p");

                                    //p.setAttribute("innerHTML", 'abc');
                                    p.textContent = arr[y];
                                    li.append(p);

                                    var span = document.createElement("span");
                                    span.setAttribute("class", "tokens-delete-token");

                                    // span.setAttribute("innerHTML", 'x');
                                    span.textContent = 'x';

                                    li.append(span);



                                    aa[i].prepend(li);
                                }

                            }

                        }


                        else if (aa[i].nextElementSibling.id == "txtpublisher_map") {

                            var arr = r.d[0].cd_PUBLISHER.split('|');
                            for (var y = 0; y <= arr.length - 1; y++) {
                                if (arr[y] != "") {
                                    var li = document.createElement("li");
                                    li.setAttribute("class", "tokens-list-token-holder");
                                    li.setAttribute("onClick", "removeItem(this);");
                                    var p = document.createElement("p");

                                    //p.setAttribute("innerHTML", 'abc');
                                    p.textContent = arr[y];
                                    li.append(p);

                                    var span = document.createElement("span");
                                    span.setAttribute("class", "tokens-delete-token");

                                    // span.setAttribute("innerHTML", 'x');
                                    span.textContent = 'x';

                                    li.append(span);



                                    aa[i].prepend(li);
                                }

                            }

                        }

                        else {
                            var arr = r.d[0].cd_DONOR_ID.split('|');
                            for (var y = 0; y <= arr.length - 1; y++) {
                                if (arr[y] != "") {
                                    var li = document.createElement("li");
                                    li.setAttribute("class", "tokens-list-token-holder");
                                    li.setAttribute("onClick", "removeItem(this);");
                                    var p = document.createElement("p");

                                    //p.setAttribute("innerHTML", 'abc');
                                    p.textContent = arr[y];
                                    li.append(p);

                                    var span = document.createElement("span");
                                    span.setAttribute("class", "tokens-delete-token");

                                    // span.setAttribute("innerHTML", 'x');
                                    span.textContent = 'x';

                                    li.append(span);



                                    aa[i].prepend(li);

                                }
                            }
                        }

                    }
                    var b = imageExists("Library/Map/" + r.d[0].cd_ACCESSION_NO + ".jpg");
                    var b1 = imageExists("Library/Map/" + r.d[0].cd_ACCESSION_NO + ".jpeg");
                    var b2 = imageExists("Library/Map/" + r.d[0].cd_ACCESSION_NO + ".png");
                    var b3 = imageExists("Library/Map/" + r.d[0].cd_ACCESSION_NO + ".gif");

                    if (b == true) {
                        document.getElementById("imgMap").src = "Library/Map/" + r.d[0].cd_ACCESSION_NO + ".jpg";
                    }
                    else if (b1 == true) {
                        document.getElementById("imgMap").src = "Library/Map/" + r.d[0].cd_ACCESSION_NO + ".jpeg";
                    }
                    else if (b2 == true) {
                        document.getElementById("imgMap").src = "Library/Map/" + r.d[0].cd_ACCESSION_NO + ".png";
                    }
                    else if (b3 == true) {
                        document.getElementById("imgMap").src = "Library/Map/" + r.d[0].cd_ACCESSION_NO + ".gif";
                    }
                    if (b == false && b1 == false && b2 == false && b3 == false) {
                        $("#get_photo").val('');
                        $("[id*='imgMap']").attr('src', 'images/user.png');
                    }

                    // $("[id*='txt_auth']").val(r.d[0].cd_AUTHOR);
                    $("[id*='txtmapyear']").val(r.d[0].cd_YEAR);
                    $("[id*='ttxmapacmaterial']").val(r.d[0].cd_ACC_MATERIALS);
                    $("[id*='txtmapsubj']").val(r.d[0].cd_SUBJ);
                    $("[id*='txtmapremrk']").val(r.d[0].cd_REMARK);
                    // $("[id*='donar_name']").val(r.d[0].cd_DONOR_ID);
                    $("[id*='txt_map_count']").val(r.d.length);
                    document.getElementById('txt_map_count').disabled = true;
                    // $("#txt_cd_cnt").trigger('keydown', { keyCode: 13, which: 13 });
                    $("#txt_map_count").trigger(jQuery.Event('keydown', { keyCode: 13, which: 13 }));
                    var dd1 = $("[id*='ddlprefix']");

                    for (var i = 0; i < r.d.length; i++) {
                        $("[id*='tbl_dis_map']").val(r.d[0].dis_type);
                        $("[id*='txtmapAccession_" + i + "']").val(r.d[i].cd_ACCESSION_NO);
                        $("[id*='txtmapbillno_" + i + "']").val(r.d[i].cd_BILL_NO);
                        $("[id*='txtmapbilldt_" + i + "']").val(r.d[i].cd_BILL_DT.substring(0, 10));
                        $("[id*='txtmapmrp_" + i + "']").val(r.d[i].cd_MRP);
                        $("[id*='txtmapdiscount_" + i + "']").val(r.d[i].cd_DISCOUNT);
                        $("[id*='txtmapprice_" + i + "']").val(r.d[i].cd_PRICE);
                        $("[id*='txtmapvendet_" + i + "']").val(r.d[i].cd_VENDOR);
                        $("[id*='txtmapregdt_" + i + "']").val(r.d[i].cd_REG_DT.substring(0, 10));
                        $("[id*='ddlprefix_" + i + "']").val(r.d[i].prefix);

                    }
                    $("#menu_toggle").click();


                    //if (r.d.length == 1) {
                    //}
                    //else {
                    //    $("#tblmap").find("*").attr("disabled", "disabled");
                    //}
                    //document.getElementById('cd_bthSave').innerText = "Update";
                }
                else if (r.d[0].cd_msg == "multiple") {
                    //   $.notify("Following Accession " + r.d[0].cd_id + " does not match with either title or author for the first entered accession.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $.confirm({

                        title: 'Map Master',
                        text: "Mismatched Tile:" + r.d[0].cd_id + " and Author:" + r.d[0].Auth_cd_id + ".",
                        content: 'Mismatched Tile:" + r.d[0].cd_id + " and Author:" + r.d[0].Auth_cd_id + ".',
                        confirmButton: 'Yes',
                        cancelButton: 'No',
                        confirm: function () {
                            var new_id = cd_id;
                            var id = [];
                            id = new_id.split(",");

                            $.ajax({
                                type: "POST",
                                url: "BookmasterNew.aspx/get_cd_data",
                                data: '{cd:"' + id[0] + '",cd_name:"' + cd_id + '",type:"cd"}',
                                contentType: "application/json; charset=utf-8",
                                success: function (r) {
                                    if (r.d.length > 0) {
                                        if (r.d[0].cd_msg == "get") {
                                            $(".tokens-list-token-holder").remove();

                                            //document.getElementById('txtmaptitle').disabled = true;
                                            $("[id*='txtmaptitle']").val(r.d[0].cd_TITLE);
                                            //  $("[id*='txtmaptitle']")[0].disabled = 'disabled';
                                            document.getElementById('txtmaptitle').disabled = true;
                                            $("[id*='txtmapisbn']").val(r.d[0].cd_ISBN);



                                            var dd = $("[id*='ddlmaplang']")[0];
                                            for (var i = 0; i < dd.options.length; i++) {
                                                if (dd.options[i].text === r.d[0].cd_LANG) {
                                                    dd.selectedIndex = i;
                                                    break;
                                                }
                                            }



                                            if (r.d[0].cd_ISSUE_TYPE == "1") {
                                                $("[id*='dllmaptype']")[0].selectedIndex = 1;
                                            } else { $("[id*='dllmaptype']")[0].selectedIndex = 2; }



                                            $("[id*='txtmapkeywords']").val(r.d[0].cd_KEYWORD);
                                            var prod = r.d[0].cd_DEPARTMENT;
                                            var arr = [];
                                            arr = prod.split(',');
                                            $("[id*=ddlMapDept]").val(arr);
                                            $("[id*=ddlMapDept]").multiselect("refresh");

                                            $("[id*='txtmapcallno']").val(r.d[0].CALLNO);


                                            // localStorage.setItem("type", "update");




                                            localStorage.setItem("auth", r.d[0].cd_AUTHOR);
                                            $("[id*='txtauthor_map']").val(r.d[0].cd_AUTHOR);

                                            localStorage.setItem("pub", r.d[0].cd_PUBLISHER);

                                            $("[id*='txtpublisher_map']").val(r.d[0].cd_PUBLISHER);

                                            localStorage.setItem("don", r.d[0].cd_DONOR_ID);

                                            $("[id*='txtdonor_map']").val(r.d[0].cd_DONOR_ID);


                                            var aa = $(".tokens-token-list");
                                            for (var i = 0; i <= aa.length - 1; i++) {
                                                if (aa[i].nextElementSibling.id == "txtauthor_map") {

                                                    var arr = r.d[0].cd_AUTHOR.split('|');
                                                    for (var y = 0; y <= arr.length - 1; y++) {
                                                        if (arr[y] != "") {
                                                            var li = document.createElement("li");
                                                            li.setAttribute("class", "tokens-list-token-holder");
                                                            li.setAttribute("onClick", "removeItem(this);");
                                                            var p = document.createElement("p");

                                                            //p.setAttribute("innerHTML", 'abc');
                                                            p.textContent = arr[y];
                                                            li.append(p);

                                                            var span = document.createElement("span");
                                                            span.setAttribute("class", "tokens-delete-token");

                                                            // span.setAttribute("innerHTML", 'x');
                                                            span.textContent = 'x';

                                                            li.append(span);



                                                            aa[i].prepend(li);
                                                        }

                                                    }

                                                }


                                                else if (aa[i].nextElementSibling.id == "txtpublisher_map") {

                                                    var arr = r.d[0].cd_PUBLISHER.split('|');
                                                    for (var y = 0; y <= arr.length - 1; y++) {
                                                        if (arr[y] != "") {
                                                            var li = document.createElement("li");
                                                            li.setAttribute("class", "tokens-list-token-holder");
                                                            li.setAttribute("onClick", "removeItem(this);");
                                                            var p = document.createElement("p");

                                                            //p.setAttribute("innerHTML", 'abc');
                                                            p.textContent = arr[y];
                                                            li.append(p);

                                                            var span = document.createElement("span");
                                                            span.setAttribute("class", "tokens-delete-token");

                                                            // span.setAttribute("innerHTML", 'x');
                                                            span.textContent = 'x';

                                                            li.append(span);



                                                            aa[i].prepend(li);
                                                        }

                                                    }

                                                }

                                                else {
                                                    var arr = r.d[0].cd_DONOR_ID.split('|');
                                                    for (var y = 0; y <= arr.length - 1; y++) {
                                                        if (arr[y] != "") {
                                                            var li = document.createElement("li");
                                                            li.setAttribute("class", "tokens-list-token-holder");
                                                            li.setAttribute("onClick", "removeItem(this);");
                                                            var p = document.createElement("p");

                                                            //p.setAttribute("innerHTML", 'abc');
                                                            p.textContent = arr[y];
                                                            li.append(p);

                                                            var span = document.createElement("span");
                                                            span.setAttribute("class", "tokens-delete-token");

                                                            // span.setAttribute("innerHTML", 'x');
                                                            span.textContent = 'x';

                                                            li.append(span);



                                                            aa[i].prepend(li);

                                                        }
                                                    }
                                                }

                                            }
                                            var b = imageExists("Library/Map/" + r.d[0].cd_ACCESSION_NO + ".jpg");
                                            var b1 = imageExists("Library/Map/" + r.d[0].cd_ACCESSION_NO + ".jpeg");
                                            var b2 = imageExists("Library/Map/" + r.d[0].cd_ACCESSION_NO + ".png");
                                            var b3 = imageExists("Library/Map/" + r.d[0].cd_ACCESSION_NO + ".gif");

                                            if (b == true) {
                                                document.getElementById("imgMap").src = "Library/Map/" + r.d[0].cd_ACCESSION_NO + ".jpg";
                                            }
                                            else if (b1 == true) {
                                                document.getElementById("imgMap").src = "Library/Map/" + r.d[0].cd_ACCESSION_NO + ".jpeg";
                                            }
                                            else if (b2 == true) {
                                                document.getElementById("imgMap").src = "Library/Map/" + r.d[0].cd_ACCESSION_NO + ".png";
                                            }
                                            else if (b3 == true) {
                                                document.getElementById("imgMap").src = "Library/Map/" + r.d[0].cd_ACCESSION_NO + ".gif";
                                            }
                                            if (b == false && b1 == false && b2 == false && b3 == false) {
                                                $("#get_photo").val('');
                                                $("[id*='imgMap']").attr('src', 'images/user.png');
                                            }

                                            // $("[id*='txt_auth']").val(r.d[0].cd_AUTHOR);
                                            $("[id*='txtmapyear']").val(r.d[0].cd_YEAR);
                                            $("[id*='ttxmapacmaterial']").val(r.d[0].cd_ACC_MATERIALS);
                                            $("[id*='txtmapsubj']").val(r.d[0].cd_SUBJ);
                                            $("[id*='txtmapremrk']").val(r.d[0].cd_REMARK);
                                            // $("[id*='donar_name']").val(r.d[0].cd_DONOR_ID);
                                            $("[id*='txt_map_count']").val(r.d.length);
                                            document.getElementById('txt_map_count').disabled = true;
                                            // $("#txt_cd_cnt").trigger('keydown', { keyCode: 13, which: 13 });
                                            $("#txt_map_count").trigger(jQuery.Event('keydown', { keyCode: 13, which: 13 }));
                                            var dd1 = $("[id*='ddlprefix']");

                                            for (var i = 0; i < r.d.length; i++) {
                                                $("[id*='tbl_dis_map']").val(r.d[0].dis_type);
                                                $("[id*='txtmapAccession_" + i + "']").val(r.d[i].cd_ACCESSION_NO);
                                                $("[id*='txtmapbillno_" + i + "']").val(r.d[i].cd_BILL_NO);
                                                $("[id*='txtmapbilldt_" + i + "']").val(r.d[i].cd_BILL_DT.substring(0, 10));
                                                $("[id*='txtmapmrp_" + i + "']").val(r.d[i].cd_MRP);
                                                $("[id*='txtmapdiscount_" + i + "']").val(r.d[i].cd_DISCOUNT);
                                                $("[id*='txtmapprice_" + i + "']").val(r.d[i].cd_PRICE);
                                                $("[id*='txtmapvendet_" + i + "']").val(r.d[i].cd_VENDOR);
                                                $("[id*='txtmapregdt_" + i + "']").val(r.d[i].cd_REG_DT.substring(0, 10));
                                                $("[id*='ddlprefix_" + i + "']").val(r.d[i].prefix);

                                            }
                                            $("#menu_toggle").click();

                                        }
                                       // $("[id*='Editmodal_cd']").modal('hide');
                                    }
                                }
                            });
                        },
                    });
                }
                else if (r.d[0].cd_msg == "") {
                    $.notify("No data found", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
                $("[id*='Editmodal']").modal('hide');
            }
        }
    });
}

function uploadpic(accession) {

    if (document.getElementById("get_photo").value != "") {


        for (var k = 0; k <= accession.length - 1; k++) {


            var img = document.getElementById("imgMap").src;
            var ext = img.split(';')[0].match(/jpg|jpeg|png|gif/)[0];
            // strip off the data: url prefix to get just the base64-encoded bytes
            var stud_photo = img.replace(/^data:image\/\w+;base64,/, "");
            // var buf = new Buffer(img, 'base64');
            //var buf = new Buffer(stud_photo, 'base64');

            //to save in folder
            var get_photo = $("#get_photo").get(0);
            var uploadedfiles = get_photo.files;


            var fromdata = new FormData();
            for (var i = 0; i < uploadedfiles.length; i++) {
                fromdata.append(uploadedfiles[i].name, uploadedfiles[i]);
            }

            if (uploadedfiles.length > 0) {
                $.ajax({
                    url: 'UploadMap.ashx?ID=' + accession[k] + '?map',
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: fromdata,
                    async: false,
                    success: function (result) {
                        if (result == 'File Uploaded Successfully!') {
                            document.getElementById("imgMap").src = img;

                            //  $.notify("Photo Updated Successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });

                        }
                        else {
                            //getdata();
                        }
                    },
                    error: function (err) {
                        //  $.notify("Error ! Error Occured.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    }
                });
            }
            else {
                //$.notify("First Choose Image.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

            }
        }
    }
}

$("#get_photo").change(function () {
    readURL(this, 'imgMap');
});
function readURL(input, imgID) {
    var fileInput = document.getElementById('get_photo');
    var filePath = fileInput.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif|\.bmp)$/i;
    if (!allowedExtensions.exec(filePath)) {
        alert('Please upload Valid image file');
        fileInput.value = '';
        return false;
    } else {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#' + imgID + '').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
}

///////////////////////////////END MAP////////////////////////////////////////
//forbook
function Bookuploadpic(accession) {
    for (var k = 0; k <= accession.length - 1; k++) {


        var img = document.getElementById("imgbook").src;
        var ext = img.split(';')[0].match(/jpg|jpeg|png|gif/)[0];
        // strip off the data: url prefix to get just the base64-encoded bytes
        var stud_photo = img.replace(/^data:image\/\w+;base64,/, "");
        // var buf = new Buffer(img, 'base64');
        //var buf = new Buffer(stud_photo, 'base64');

        //to save in folder
        var get_photo = $("#book_photo").get(0);
        var uploadedfiles = get_photo.files;


        var fromdata = new FormData();
        for (var i = 0; i < uploadedfiles.length; i++) {
            fromdata.append(uploadedfiles[i].name, uploadedfiles[i]);
        }

        if (uploadedfiles.length > 0) {
            $.ajax({
                url: 'UploadMap.ashx?ID=' + accession[k] + '?Book',
                type: "POST",
                contentType: false,
                processData: false,
                data: fromdata,
                async: false,
                success: function (result) {
                    if (result == 'File Uploaded Successfully!') {
                        document.getElementById("imgbook").src = img;

                        //  $.notify("Photo Updated Successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });

                    }
                    else {
                        //getdata();
                    }
                },
                error: function (err) {
                    //  $.notify("Error ! Error Occured.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            });
        }
        else {
            //$.notify("First Choose Image.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

        }
    }
}
//forcd
function Cduploadpic(accession) {
    for (var k = 0; k <= accession.length - 1; k++) {


        var img = document.getElementById("imgcd").src;
        var ext = img.split(';')[0].match(/jpg|jpeg|png|gif/)[0];
        // strip off the data: url prefix to get just the base64-encoded bytes
        var stud_photo = img.replace(/^data:image\/\w+;base64,/, "");
        // var buf = new Buffer(img, 'base64');
        //var buf = new Buffer(stud_photo, 'base64');

        //to save in folder
        var get_photo = $("#cd_photo").get(0);
        var uploadedfiles = get_photo.files;


        var fromdata = new FormData();
        for (var i = 0; i < uploadedfiles.length; i++) {
            fromdata.append(uploadedfiles[i].name, uploadedfiles[i]);
        }

        if (uploadedfiles.length > 0) {
            $.ajax({
                url: 'UploadMap.ashx?ID=' + accession[k] + '?CD',
                type: "POST",
                contentType: false,
                processData: false,
                data: fromdata,
                async: false,
                success: function (result) {
                    if (result == 'File Uploaded Successfully!') {
                        document.getElementById("imgcd").src = img;

                        //  $.notify("Photo Updated Successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });

                    }
                    else {
                        //getdata();
                    }
                },
                error: function (err) {
                    //  $.notify("Error ! Error Occured.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            });
        }
        else {
            //$.notify("First Choose Image.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

        }
    }
}
//bookimage
$("#book_photo").change(function () {
    readURL_book(this, 'imgbook');
});
function readURL_book(input, imgID) {
    var fileInput = document.getElementById('book_photo');
    var filePath = fileInput.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif|\.bmp)$/i;
    if (!allowedExtensions.exec(filePath)) {
        alert('Please upload Valid image file');
        fileInput.value = '';
        return false;
    } else {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#' + imgID + '').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
}
//cdimage
$("#cd_photo").change(function () {
    readURL_cd(this, 'imgcd');
});
function readURL_cd(input, imgID) {
    var fileInput = document.getElementById('cd_photo');
    var filePath = fileInput.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif|\.bmp)$/i;
    if (!allowedExtensions.exec(filePath)) {
        alert('Please upload Valid image file');
        fileInput.value = '';
        return false;
    } else {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#' + imgID + '').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
}

//
function validatecd() {
    var retval = true;
    if ($("[id*='txt_cd_tit']").val() == '') {
        retval = false;
        $("[id*=txt_cd_tit]").css("border-color", "red");
    }
    else {
        $("[id*=txt_cd_tit]").css("border-color", "#ccc");

    }
    if ($("[id*='txt_isbn']").val() == '') {
        retval = false;
        $("[id*=txt_isbn]").css("border-color", "red");
    }
    else {
        $("[id*=txt_isbn]").css("border-color", "#ccc");

    }
    if ($("[id*='txt_key']").val() == '') {
        retval = false;
        $("[id*=txt_key]").css("border-color", "red");
    }
    else {
        $("[id*=txt_key]").css("border-color", "#ccc");

    }
    if ($("[id*='cd_lang'] :selected").text() == "--Select--") {
        retval = false;
        $("[id*=cd_lang]").css("border-color", "red");
    }
    else {
        $("[id*=cd_lang]").css("border-color", "#ccc");

    }
    if ($("[id*='ddlcourse_cd'] :selected").text() == "--Select--") {
        retval = false;
        $("[id*=ddlcourse_cd]").css("border-color", "red");
    }
    else {
        $("[id*=ddlcourse_cd]").css("border-color", "#ccc");

    }
   
    //if ($("[id*='txt_yr']").val() == '') {
    //    retval = false;
    //    $("[id*=txt_yr]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txt_yr]").css("border-color", "#ccc");

    //}
    //if ($("[id*='txt_acc_mat']").val() == '') {
    //    retval = false;
    //    $("[id*=txt_acc_mat]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txt_acc_mat]").css("border-color", "#ccc");

    //}
    //if ($("[id*='txt_sub']").val() == '') {
    //    retval = false;
    //    $("[id*=txt_sub]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txt_sub]").css("border-color", "#ccc");

    //}

    //if ($("[id*='txt_rem']").val() == '') {
    //    retval = false;
    //    $("[id*=txt_rem]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txt_rem]").css("border-color", "#ccc");

    //}
    if ($("[id*='txt_cd_cnt']").val() == '') {
        retval = false;
        $("[id*=txt_cd_cnt]").css("border-color", "red");
    }
    else {
        $("[id*=txt_cd_cnt]").css("border-color", "#ccc");

    }
   

    return retval;

}

$("[id*=tbl_cd]").on('blur', 'input[type="text"]', function (e) {
    var id = e.currentTarget.id;
    var sp = id.split('_');
    var int = parseInt(sp[1]) + 1;
    if ($("[id*=tbl_cd]")[0].innerHTML != "") {
        var tds = document.querySelectorAll('[id*=tbl_cd] tbody tr');


        if (id.startsWith('txtdiscount_')) {
            int = sp[1];
            // for (var i = int; i < tds.length; i++) {

            if ($("[id*=tbl_dis]").val() == "percent(%)") {
                var word = $("[id*='" + id + "']").val();
                var total = $("[id*='txtmrp_" + int + "']").val();
                var discount_value = (total / 100) * word;
                var rate = total - discount_value;
                $("[id*='txtdiscount_" + int + "']").val(word);
                $("[id*='txtprice_" + int + "']").val(rate);
            }
            else {
                var word = $("[id*='" + id + "']").val();
                var total = $("[id*='txtmrp_" + int + "']").val();
                //var discount_value = (total / 100) * word;
                var rate = total - word;
                $("[id*='txtdiscount_" + int + "']").val(word);
                $("[id*='txtprice_" + int + "']").val(rate);
            }

            // }
        }
    }
});
//for book
$("[id*='btnlanguageadd']").on("click", function () {
    Addlanguage();
});
function Addlanguage() {
    //var query = "insert into ll_language_master values('" + $("[id*='txtaddlanguage']").val() + "')";
    var query = "if not exists (select * from ll_language_master where language='" + $("[id*='txtaddlanguage']").val() + "')begin insert into ll_language_master values(N'" + $("[id*='txtaddlanguage']").val() + "')end";
    $.ajax({
        type: "POST",
        url: "BookmasterNew.aspx/saveData",
        data: '{qry:"' + query + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            if (r.d == true) {
                $.notify("Saved successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                $("[id*='txtaddlanguage']")[0].value = "";
                $("[id*='modallanguage']").modal('hide');
                FillLanguage();
            }
            else {
                $.notify("Data Already Exist.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }
        }
    });

}

function FillLanguage() {
    //var ddllanguage = "";
    $.ajax({
        type: "POST",
        url: "BookMasterNew.aspx/fillLanguage",
        data: '{connect:"' + $("[id*='ddlselect']").val() + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            $("[id*='ddllanguage']").empty();

            $.each(r.d, function () {
                $("[id*='ddllanguage']").append($("<option></option>").val(this['Value']).html(this['Text']));
            });

            $("[id*='ddlmaplang']").empty();

            $.each(r.d, function () {
                $("[id*='ddlmaplang']").append($("<option></option>").val(this['Value']).html(this['Text']));
            });

            $("[id*='cd_lang']").empty();

            $.each(r.d, function () {
                $("[id*='cd_lang']").append($("<option></option>").val(this['Value']).html(this['Text']));
            });

            $("[id*='ddl_lang_ebook']").empty();

            $.each(r.d, function () {
                $("[id*='ddl_lang_ebook']").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        }
    });
}

$("[id*='btnlanguageclear']").on("click", function () {
    $("[id*='txtaddlanguage']")[0].value = "";
    $("[id*='modallanguage']").modal('hide');
});


$("[id*='btnmodalclear']").on("click", function () {
    clearmodalgeneraldetails();
});
function clearmodalgeneraldetails() {

    $("[id*='txtauthorname']")[0].value = "";
    $("[id*='txtauthormobileno']")[0].value = "";
    $("[id*='txtauthorEmailid']")[0].value = "";
    $("[id*='txtauthorLocation']")[0].value = "";
    $("[id*='ddltype']").val('--Select--');
    $("[id*='txtauthoraddress']")[0].value = "";
    $("[id*='txtauthorname']")[0].value = "";
    $("[id*='modallanguage']").modal('hide');

}
$(".nav-tabs a").click(function () {
    clear_cd();
    clearMap();
    Clear_book();
});

function validatebook() {
    var retval = true;
    if ($("[id*='txtbooktitlee']").val() == '') {
        retval = false;
        $("[id*=txtbooktitlee]").css("border-color", "red");
    }
    else {
        $("[id*=txtbooktitlee]").css("border-color", "#ccc");

    }
    //if ($("[id*='txtisbnno']").val() == '') {
    //    retval = false;
    //    $("[id*=txtisbnno]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txtisbnno]").css("border-color", "#ccc");

    //}

    if ($("[id*='txtcallno']").val() == '') {
        retval = false;
        $("[id*=txtcallno]").css("border-color", "red");
    }
    else {
        $("[id*=txtcallno]").css("border-color", "#ccc");

    }



   
    
    if ($("[id*='ddllanguage'] :selected").text() == "--Select--") {
        retval = false;
        $("[id*=ddllanguage]").css("border-color", "red");
    }
    else {
        $("[id*=ddllanguage]").css("border-color", "#ccc");

    }

    //if ($("[id*='txtkeyword']").val() == '') {
    //    retval = false;
    //    $("[id*=txtkeyword]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txtkeyword]").css("border-color", "#ccc");

    //}

    //if ($("[id*='txtyear']").val() == '') {
    //    retval = false;
    //    $("[id*=txtyear]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txtyear]").css("border-color", "#ccc");

    //}

    //if ($("[id*='txtaccompaningmaterial']").val() == '') {
    //    retval = false;
    //    $("[id*=txtaccompaningmaterial]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txtaccompaningmaterial]").css("border-color", "#ccc");

    //}

    //if ($("[id*='txtSubject']").val() == '') {
    //    retval = false;
    //    $("[id*=txtSubject]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txtSubject]").css("border-color", "#ccc");

    //}

    //if ($("[id*='txtremark']").val() == '') {
    //    retval = false;
    //    $("[id*=txtremark]").css("border-color", "red");
    //}
    //else {
    //    $("[id*=txtremark]").css("border-color", "#ccc");

    //}
    if ($("[id*='txtbookcount']").val() == '') {
        retval = false;
        $("[id*=txtbookcount]").css("border-color", "red");
    }
    else {
        $("[id*=txtbookcount]").css("border-color", "#ccc");

    }


    return retval;

}


//----------------------------------EBOOK----------------------
//Clear ebook    
$("[id*='btnEbookclear']").on("click", function () {
    Clear_ebook();
});

function Clear_ebook() {
    localStorage.setItem("auth", "");
   
    $("[id*='txtebooktitle']")[0].value = "";
    $("[id*='txt_keyword_ebook']")[0].value = "";
    $("[id*='txt_page_no_ebook']")[0].value = "";
    $("[id*='txt_classification_no_ebook']")[0].value = "";
    $("[id*='txt_author_ebook']")[0].value = "";
    $("[id*='ddl_ebook_type']").val('--Select--');
    $("[id*='ddl_ebook_bound']").val('--Select--');
    $("[id*='ddl_lang_ebook']").val('--Select--');
    $("[id*='txt_ebook_acc_no']")[0].value = "";
    //$("[id*='txt_author_ebook']").empty();
};

//save Ebook
$("[id*='btnEbookSave']").on("click", function () {

    if (localStorage.getItem("auth").toString() != "") {
        if ($("[id*='txt_author_ebook']").val() == localStorage.getItem("auth").toString()) {
            str = $("[id*='txt_author_ebook']").val();
        }
        else {

            if ($("[id*='txt_author_ebook']").val().indexOf(localStorage.getItem("auth").toString()) > -1) {
                str = $("[id*='txt_author_ebook']").val();
            }
            else {

                str = $("[id*='txt_author_ebook']").val() + "| " + localStorage.getItem("auth").toString();
                 }
        }
    }
    else {
        str = $("[id*='txt_author_ebook']").val();
                }

    var str_rp = str.replace("| |", "|");
    var str_rp1 = str_rp.replace("||", "|");
    var auth_final = str_rp1.trim();

    if ($("[id*='ddl_ebook_type']").val() == "FOR ISSUE")
    {
        cd_rd = "1";
    }
    else
    {
        cd_rd = "0";
    }
    var accession_book = [];
    var ins = "";
    var accession = "";
    accession = $("[id*='txt_ebook_acc_no']").val();
    
    if ($("[id*='txtebooktitle']").val() != "" && auth_final != "") {
        var res = Ebook_arr.indexOf($("[id*='txtebooktitle']").val().trim());
        if (res > -1) {
            $.ajax({
                type: "POST",
                url: "BookmasterNew.aspx/CheckAlreadyebook",
                data: '{accession:"' + accession + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (data) {
                    if (data.d.length > 0) {
                        if (data.d[0].id == "1")
                            if (se_book_id != "") {
                                if (se_book_id.includes(",")) 
                                    {
                                        var gen_id = [];
                                        gen_id = se_book_id.split(",");
                                        for (var k = 0; k < gen_id.length; k++)
                                        {
                                            accession_book.push($("[id*='txt_ebook_acc_no']").val());
                                          if (gen_id[k].toUpperCase() == $("[id*='txt_ebook_acc_no']").val().toUpperCase())
                                           {

                                             ins = ins + "update lib_Ebook_master  set TITLE=N'" + $("[id*='txtebooktitle']").val().trim() + "', AUTHOR=N'" + auth_final + "',CALLNO='" + $("[id*='txt_classification_no_ebook']").val() + "' ,NOOFPAGES='" + $("[id*='txt_page_no_ebook']").val() + "',BOUND='" + $("[id*='ddl_ebook_bound']").val() + "',LANG=N'" + $("[id*='ddl_lang_ebook']").val() + "',ISSUE_TYPE='" + $("[id*='ddl_ebook_type']").val() + "',KEYWORD=N'" + $("[id*='txt_keyword_ebook']").val() + "',ACCESSION_NO='" + $("[id*='txt_ebook_acc_no']").val() + "' where ACCESSION_NO in ('" + gen_id[k] + "');";
                                           }
                                        }
                                }
                                else {
                                   
                                    accession_book.push($("[id*='txt_ebook_acc_no']").val());
                                        ins = ins + "update lib_Ebook_master  set TITLE=N'" + $("[id*='txtebooktitle']").val().trim() + "', AUTHOR=N'" + auth_final + "',CALLNO='" + $("[id*='txt_classification_no_ebook']").val() + "' ,NOOFPAGES='" + $("[id*='txt_page_no_ebook']").val() + "',BOUND='" + $("[id*='ddl_ebook_bound']").val() + "',LANG=N'" + $("[id*='ddl_lang_ebook']").val() + "',ISSUE_TYPE='" + $("[id*='ddl_ebook_type']").val() + "',KEYWORD=N'" + $("[id*='txt_keyword_ebook']").val() + "',ACCESSION_NO='" + $("[id*='txt_ebook_acc_no']").val() + "' where ACCESSION_NO in ('" + se_book_id + "');";
                                }

                                     }
                                else {
                                accession_book.push($("[id*='txt_ebook_acc_no']").val());
                                        ins = ins + "update lib_Ebook_master  set TITLE=N'" + $("[id*='txtebooktitle']").val().trim() + "', AUTHOR=N'" + auth_final + "',CALLNO='" + $("[id*='txt_classification_no_ebook']").val() + "' ,NOOFPAGES='" + $("[id*='txt_page_no_ebook']").val() + "',BOUND='" + $("[id*='ddl_ebook_bound']").val() + "',LANG=N'" + $("[id*='ddl_lang_ebook']").val() + "',ISSUE_TYPE='" + $("[id*='ddl_ebook_type']").val() + "',KEYWORD=N'" + $("[id*='txt_keyword_ebook']").val() + "',ACCESSION_NO='" + $("[id*='txt_ebook_acc_no']").val() + "' where ACCESSION_NO in ('" + $("[id*='txt_ebook_acc_no']").val() + "');";
                                     }
                            }
                            else {
                                if (validateEbook() == true) {
                                    accession_book.push($("[id*='txt_ebook_acc_no']").val());
                                    if ($("[id*='txt_ebook_acc_no']").val() != "") {
                                        ins = ins + "insert into lib_Ebook_master values(N'" + $("[id*='txtebooktitle']").val() + "',N'" + auth_final + "',N'" + $("[id*='txt_classification_no_ebook']").val() + "',N'" + $("[id*='ddl_lang_ebook']").val() + "',N'" + $("[id*='txt_keyword_ebook']").val() + "', '" + $("[id*='txt_page_no_ebook']").val() + "','" + $("[id*='ddl_ebook_type']").val() + "','" + $("[id*='ddl_ebook_bound']").val() + "','" + $("[id*='txt_ebook_acc_no']").val() + "',NULL,NULL,NULL,'" + empId + "',getdate(),'',0,'')";
                                    }
                                    else {
                                        $.notify("Enter Acession No.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                                    }
                                }
                            }
                },
            });
        }
        else {
            if (validateEbook() == true) {
               
                        accession_book.push($("[id*='txt_ebook_acc_no']").val());
                        if ($("[id*='txt_ebook_acc_no']").val() != "")
                        {
                            ins = ins + "insert into lib_Ebook_master values(N'" + $("[id*='txtebooktitle']").val() + "',N'" + auth_final + "',N'" + $("[id*='txt_classification_no_ebook']").val() + "',N'" + $("[id*='ddl_lang_ebook']").val() + "',N'" + $("[id*='txt_keyword_ebook']").val() + "', '" + $("[id*='txt_page_no_ebook']").val() + "','" + $("[id*='ddl_ebook_type']").val() + "','" + $("[id*='ddl_ebook_bound']").val() + "','" + $("[id*='txt_ebook_acc_no']").val() + "',NULL,NULL,NULL,'" + empId + "',getdate(),'',0,'')";
                        }
                        else
                        {
                            $.notify("Enter Acession No.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                        }
            }
        }
        $.ajax({
            type: "POST",
            url: "BookmasterNew.aspx/saveData",
            data: '{qry:"' + ins + '",connect:"' + $("[id*='ddlselect']").val() + '"}',
            contentType: "application/json; charset=utf-8",
            async:false,
            success: function (r) {
                if (r.d == true) {

                    Clear_ebook();
                    $(function () {
                        $.ajax({
                            type: "POST",
                            url: "BookmasterNew.aspx/Get_book_Title",
                            data: '{type:"Ebook",connect:"' + $("[id*='ddlselect']").val() + '"}',
                            contentType: "application/json; charset=utf-8",
                            aync: false,
                            success: function (data) {
                                debugger;

                                for (var i = 0; i < data.d.length; i++) {
                                    // var val = item[i];
                                    var item = data.d[i].id;
                                    var mid = data.d[i].title;
                                    Ebook_arr.push(mid);
                                }
                                // setup autocomplete function pulling from currencies[] array


                                var books = Ebook_arr;

                                $('#txtbooktitlee').autocomplete({
                                    source: [books]
                                });
                            },
                            error: function () {

                                //   $.notify("Error ! Connection error, please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                            }
                        });
                    });
                    $.notify("Data Saved successfully.", { color: "#fff", background: "#127515", blur: 0.2, delay: 0 });
                   // window.location.reload(true);

                }
                else {
                    $.notify("Error ! Error Occured , please retry.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
            }
        });
    }
    else {

        $.notify("Fill All The Fields.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

    }

});

//validate ebook
function validateEbook() {
    var retval = true;
    if ($("[id*='txtebooktitle']").val() == '') {
        retval = false;
        $("[id*=txtebooktitle]").css("border-color", "red");
    }
    else {
        $("[id*=txtebooktitle]").css("border-color", "#ccc");

    }
  
    if ($("[id*='txt_classification_no_ebook']").val() == '') {
        retval = false;
        $("[id*=txt_classification_no_ebook]").css("border-color", "red");
    }
    else {
        $("[id*=txt_classification_no_ebook]").css("border-color", "#ccc");

    }

    if ($("[id*='ddl_lang_ebook'] :selected").text() == "--Select--") {
        retval = false;
        $("[id*=ddl_lang_ebook]").css("border-color", "red");
    }
    else {
        $("[id*=ddl_lang_ebook]").css("border-color", "#ccc");

    }
       
    if ($("[id*='ddl_ebook_type']").val() == '') {
        retval = false;
        $("[id*=ddl_ebook_type]").css("border-color", "red");
    }
    else {
        $("[id*=ddl_ebook_type]").css("border-color", "#ccc");

    }

    return retval;

}


$("#txtebooktitle").on('keydown', function (e) {

    if (e.which === 13) {
        event.preventDefault();
        se_book_id = "";
        se_book_name = $("[id*='txtebooktitle']").val();
        Load_EBook("", $("[id*='txtebooktitle']").val());

    }
});

$("#txt_ebook_search").on('keydown', function (e) {

    if (e.which === 13) {
        event.preventDefault();
        se_ebook_id = $("[id*='txt_ebook_search']").val();
        se_ebook_name = "";
        Load_EBook($("[id*='txt_ebook_search']").val(), "");
    }
});


//Retrive Data
function Load_EBook(bookid, book_name) {
    $.ajax({
        type: "POST",
        url: "BookmasterNew.aspx/get_cd_data",
        data: '{cd:"' + bookid + '",cd_name:"' + book_name + '",type:"Ebook",connect:"' + $("[id*='ddlselect']").val() + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (r) {
            if (r.d.length > 0) {
                if (r.d[0].cd_msg == "get") {
                    $(".tokens-list-token-holder").remove();

                    $("[id*='txtebooktitle']").val(r.d[0].cd_TITLE);
          
                    localStorage.setItem("auth", r.d[0].cd_AUTHOR);
                    $("[id*='txt_author_ebook']").val(r.d[0].cd_AUTHOR);

                    var aa = $(".tokens-token-list");
                    for (var i = 0; i <= aa.length - 1; i++) {
                        if (aa[i].nextElementSibling.id == "txt_author_ebook") {

                            var arr = r.d[0].cd_AUTHOR.split('|');
                            for (var y = 0; y <= arr.length - 1; y++) {
                                if (arr[y] != "") {
                                    var li = document.createElement("li");
                                    li.setAttribute("class", "tokens-list-token-holder");
                                    li.setAttribute("onClick", "removeItem_book(this);");
                                    var p = document.createElement("p");

                                    //p.setAttribute("innerHTML", 'abc');
                                    p.textContent = arr[y];
                                    li.append(p);

                                    var span = document.createElement("span");
                                    span.setAttribute("class", "tokens-delete-token");

                                    // span.setAttribute("innerHTML", 'x');
                                    span.textContent = 'x';

                                    li.append(span);



                                    aa[i].prepend(li);
                                }

                            }

                        }
                    }
                    $("[id*='txt_keyword_ebook']").val(r.d[0].cd_KEYWORD);
                    $("[id*='txt_page_no_ebook']").val(r.d[0].booknoofpages);
                    $("[id*='txt_classification_no_ebook']").val(r.d[0].bookcallno);
                    $("[id*='ddl_ebook_type']").val(r.d[0].cd_ISSUE_TYPE);
                    $("[id*='ddl_ebook_bound']").val(r.d[0].bookbound);
                    $("[id*='ddl_lang_ebook']").val(r.d[0].cd_LANG);
                    $("[id*='txt_ebook_acc_no']").val(r.d[0].cd_ACCESSION_NO);

                    $("#menu_toggle").click();

                    //document.getElementById('cd_bthSave').innerText = "Update";

                }
                else if (r.d[0].cd_msg == "multiple") {
                    // $.notify("Mismatched id:" + rd.d[0].cd_id + ".", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                    $.confirm({

                        title: 'CD Master',
                        text: "Mismatched Tile:" + r.d[0].cd_id + " and Author:" + r.d[0].Auth_cd_id + ".",
                        content: 'Mismatched Tile:" + r.d[0].cd_id + " and Author:" + r.d[0].Auth_cd_id + ".',
                        confirmButton: 'Yes',
                        cancelButton: 'No',
                        confirm: function () {
                            var new_id = bookid;
                            var id = [];
                            id = new_id.split(",");

                            $.ajax({
                                type: "POST",
                                url: "BookmasterNew.aspx/get_cd_data",
                                data: '{cd:"' + id[0] + '",cd_name:"' + bookid + '",type:"Ebook"}',
                                contentType: "application/json; charset=utf-8",
                                success: function (r) {
                                    if (r.d.length > 0) {
                                        if (r.d[0].cd_msg == "get") {

                                            $(".tokens-list-token-holder").remove();

                                            $("[id*='txtebooktitle']").val(r.d[0].cd_TITLE);
                                          
                                            localStorage.setItem("auth", r.d[0].cd_AUTHOR);
                                            $("[id*='txt_author_ebook']").val(r.d[0].cd_AUTHOR);

                                      

                                            var aa = $(".tokens-token-list");
                                            for (var i = 0; i <= aa.length - 1; i++) {
                                                if (aa[i].nextElementSibling.id == "txt_author_ebook") {

                                                    var arr = r.d[0].cd_AUTHOR.split('|');
                                                    for (var y = 0; y <= arr.length - 1; y++) {
                                                        if (arr[y] != "") {
                                                            var li = document.createElement("li");
                                                            li.setAttribute("class", "tokens-list-token-holder");
                                                            li.setAttribute("onClick", "removeItem_book(this);");
                                                            var p = document.createElement("p");

                                                            //p.setAttribute("innerHTML", 'abc');
                                                            p.textContent = arr[y];
                                                            li.append(p);

                                                            var span = document.createElement("span");
                                                            span.setAttribute("class", "tokens-delete-token");

                                                            // span.setAttribute("innerHTML", 'x');
                                                            span.textContent = 'x';

                                                            li.append(span);



                                                            aa[i].prepend(li);
                                                        }

                                                    }

                                                }
                                            }
                                          
                                            $("[id*='txt_keyword_ebook']").val(r.d[0].cd_KEYWORD);
                                            $("[id*='txt_page_no_ebook']").val(r.d[0].booknoofpages);
                                            $("[id*='txt_classification_no_ebook']").val(r.d[0].bookcallno);
                                            $("[id*='ddl_ebook_type']").val(r.d[0].cd_ISSUE_TYPE);
                                            $("[id*='ddl_ebook_bound']").val(r.d[0].bookbound);
                                            $("[id*='ddl_lang_ebook']").val(r.d[0].cd_LANG);
                                            $("[id*='txt_ebook_acc_no']").val(r.d[0].cd_ACCESSION_NO);

                             
                                            $("#menu_toggle").click();

                                        }
                                    }
                                }
                            });
                        },
                    });
                }
                else if (r.d[0].cd_msg == "") {
                    $.notify("No data found", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
                }
                $("[id*='EditmodalBook']").modal('hide');

            }
        }

    });
}
//---------------------------------------------------------------------------