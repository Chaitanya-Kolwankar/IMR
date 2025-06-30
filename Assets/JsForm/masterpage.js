////$(document).ready(function () {
////    fill_form();
////    fill_module();

////});


////function fill_module() {
////   /* var emp_id = empId;*/

////    $.ajax({
////        type: "POST",
////        url:"/IMR_Staff/Portals/Staff/Login.aspx/fillModule",
////        /*url: "/Portals/Staff/Login.aspx/fillModule",*/
////        data: '{emp_id:"' + empId + '"}',
////        contentType: "application/json; charset=utf-8",
////        success: function (data) {
////            if (data.d.length > 0) {
////                for (var i=0;i<data.d.length;i++)
////                {
////                    var nam = data.d[i].module_name + "_li";
////                    if (data.d[i].module_name == "Staff Portal" || data.d[i].module_name == "" || data.d[i].module_name=="Module") { } else {
                        
////                        document.getElementById(data.d[i].module_name).style.display = "block";
/////*                        .sidebar - nav.nav - content a*/
////                    }
                    
////                }
////                //portal = data.d[0].module_temp;

////            }
////        }
////    });

////}

////function fill_form() {
////    //var emp_id = empId;

////    $.ajax({
////        type: "POST",
////        url: "/IMR_Staff/Portals/Staff/Login.aspx/fillform",
////        /*url: "/Portals/Staff/Login.aspx/fillform",*/
////        data: '{emp_id:"' + empId + '"}',
////        contentType: "application/json; charset=utf-8",
////        success: function (data) {
////            if (data.d.length > 0) {
////                for (var i = 0; i < data.d.length; i++) {
////                    var name = data.d[i].form_name;
////                    if (name != "") {
////                        document.getElementById(data.d[i].form_name).style.display = "block";
////                    }
////                }              
////            }
////        }
////    });
////}










$(document).ready(function () {
    loadSidebarState();
});

function loadSidebarState() {
    var moduleState = localStorage.getItem('moduleState');
    var formState = localStorage.getItem('formState');

    if (moduleState && formState) {
        applySidebarState(JSON.parse(moduleState), JSON.parse(formState));
    } else {
        fill_module();
        fill_form();
    }
}

function fill_module() {
    $.ajax({
        type: "POST",
        url: "~/Login.aspx/fillModule",
        data: '{emp_id:"' + empId + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d.length > 0) {
                var moduleState = {};
                for (var i = 0; i < data.d.length; i++) {
                    var moduleName = data.d[i].module_name;
                    if (moduleName && moduleName !== "Staff Portal" && moduleName !== "Module") {
                        moduleState[moduleName] = true;
                    }
                }
                localStorage.setItem('moduleState', JSON.stringify(moduleState));
                applySidebarState(moduleState, JSON.parse(localStorage.getItem('formState')));
            }
        }
    });
}

function fill_form() {
    $.ajax({
        type: "POST",
        url: "~/Login.aspx/fillform",
        data: '{emp_id:"' + empId + '"}',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d.length > 0) {
                var formState = {};
                for (var i = 0; i < data.d.length; i++) {
                    var formName = data.d[i].form_name;
                    if (formName) {
                        formState[formName] = true;
                    }
                }
                localStorage.setItem('formState', JSON.stringify(formState));
                applySidebarState(JSON.parse(localStorage.getItem('moduleState')), formState);
            }
        }
    });
}

function applySidebarState(moduleState, formState) {
    if (moduleState) {
        for (var moduleName in moduleState) {
            if (moduleState[moduleName]) {
                document.getElementById(moduleName).style.display = "block";
            }
        }
    }
    if (formState) {
        for (var formName in formState) {
            if (formState[formName]) {
                document.getElementById(formName).style.display = "block";
            }
        }
    }
}
