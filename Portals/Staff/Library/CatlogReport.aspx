<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="CatlogReport.aspx.cs" Inherits="CatlogReport" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <script src="../../../Assets/vendor/select2/docs/vendor/js/jquery.min.js"></script>
    <script src="../../../Assets/jquery-table2excel-master/jquery-table2excel-master/src/jquery.table2excel.js"></script>
    <meta charset="utf-8" />
  <style>
     
             /*hr.style17 {
            border-top: 1px solid #8c8b8b;
            text-align: center;
        }

            hr.style17:after {
                /*content: '&';*/
        /*display: inline-grid;
                position: relative;
                top: -14px;
                padding: 0 10px;
                background: #f0f0f0;
                color: #8c8b8b;
                font-size: 18px;*/
        /*-webkit-transform: rotate(60deg);
	-moz-transform: rotate(60deg);
	transform: rotate(60deg);*/
        /*}*/

        .modal-backdrop.in
        {
            opacity: 0;
        }



        .loader
        {
            border: 16px solid #f3f3f3;
            border-radius: 50%;
            border-top: 16px solid #172D44;
            width: 120px;
            height: 120px;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
        }

        @-webkit-keyframes spin
        {
            0%
            {
                -webkit-transform: rotate(0deg);
            }

            100%
            {
                -webkit-transform: rotate(360deg);
            }
        }

        @keyframes spin
        {
            0%
            {
                transform: rotate(0deg);
            }

            100%
            {
                transform: rotate(360deg);
            }
        }







        element.style
        {
        }

        .box.box-primary
        {
            border-top-color: #3c8dbc;
        }

        .box
        {
            position: relative;
            border-radius: 3px;
            background: #ffffff;
            border-top: 3px solid #d2d6de;
            margin-bottom: 20px;
            width: 100%;
            box-shadow: 0 1px 1px rgba(0,0,0,0.1);
        }


        .profile-user-img
        {
            margin: 0 auto;
            width: 100px;
            padding: 3px;
            border: 3px solid #d2d6de;
        }


        .img-circle
        {
            border-radius: 50%;
        }

        element.style
        {
        }

        .box-body
        {
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
            padding: 10px;
        }

        /*.list-group-item {
    position: relative;
    display: block;
    padding: 10px 15px;
    margin-bottom: -1px;
    background-color: #fff;
    border: 1px solid #ddd;
}
ul, menu, dir {
    display: block;
    list-style-type: disc;
    -webkit-margin-before: 1em;
    -webkit-margin-after: 1em;
    -webkit-margin-start: 0px;
    -webkit-margin-end: 0px;
    -webkit-padding-start: 40px;
}

        /*element.style {
}

.content {
    min-height: 250px;
    padding: 15px;
    margin-right: auto;
    margin-left: auto;
    padding-left: 15px;
    padding-right: 15px;
}

article, aside, details, figcaption, figure, footer, header, hgroup, main, menu, nav, section, summary {
    display: block;
}


.profile-username {
    font-size: 21px;
    margin-top: 5px;
}


.text-center {
    text-align: center;
}






.margin-r-5 {
    margin-right: 5px;
}


.fa {
    display: inline-block;
    font: normal normal normal 14px/1 FontAwesome;
    font-size: inherit;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
}*/




        /*th, td {
    padding: 15px;
    text-align: left;
}*/
        table#t01
        {
            width: 100%;
            background-color: #f1f1c1;
        }


        @media screen and (max-width: 768px) {

            *[class*='modal-width-media'] {
                width: auto;
            }
        }

        @media screen and (max-width: 992px) {

            *[class*='modal-width-media'] {
                width: auto;
            }
        }
        @media screen and (max-width: 1200px) {

            *[class*='modal-width-media'] {
                width: 800px;
            }
        }
         @media screen and (max-width: 1920px) {

            *[class*='modal-width-media'] {
                width: 800px;
            }
        }
        .modal-backdrop.in
        {
            opacity: 0;
        }
        .loader
        {
            border: 16px solid #f3f3f3;
            border-radius: 50%;
            border-top: 16px solid #172D44;
            width: 120px;
            height: 120px;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
        }

        @-webkit-keyframes spin
        {
            0%
            {
                -webkit-transform: rotate(0deg);
            }

            100%
            {
                -webkit-transform: rotate(360deg);
            }
        }

        @keyframes spin
        {
            0%
            {
                transform: rotate(0deg);
            }

            100%
            {
                transform: rotate(360deg);
            }
        }
        element.style
        {
        }

        .box.box-primary
        {
            border-top-color: #3c8dbc;
        }

        .box
        {
            position: relative;
            border-radius: 3px;
            background: #ffffff;
            border-top: 3px solid #d2d6de;
            margin-bottom: 20px;
            width: 100%;
            box-shadow: 0 1px 1px rgba(0,0,0,0.1);
        }


        .profile-user-img
        {
            margin: 0 auto;
            width: 100px;
            padding: 3px;
            border: 3px solid #d2d6de;
        }


        .img-circle
        {
            border-radius: 50%;
        }

        element.style
        {
        }

        .box-body
        {
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
            padding: 10px;
        }


        table#t01
        {
            width: 100%;
            background-color: #f1f1c1;
        }

   .fixedheader {
       background-color:dodgerblue;
        position: sticky!important;
        top: 0;
    }

        @media screen and (max-width: 768px) {

            *[class*='modal-width-media'] {
                width: auto;
            }
        }

        @media screen and (max-width: 992px) {

            *[class*='modal-width-media'] {
                width: auto;
            }
        }
        @media screen and (max-width: 1200px) {

            *[class*='modal-width-media'] {
                width: 800px;
            }
        }
         @media screen and (max-width: 1920px) {

            *[class*='modal-width-media'] {
                width: 800px;
            }
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--------zrb--------->

     <div id="main" class="main">
        <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Catelogue Report 
        </div>

           <div class="container-fluid">
        <div class="card card-info" style="margin: 10px">
        
        <div class=" card card-body">
            <br />
        <div class="row">
            <div class="col-lg-8">
                <ul class="nav nav-tabs" id="myTab" role="tablist">

                     <li class="nav-item" role="presentation">
                          <button class="nav-link active" id="prefix_tab" data-bs-toggle="tab" data-bs-target="#Prefix" type="button" role="tab" style="color: #012970" aria-controls="book" aria-selected="true">Prefix Wise Report</button>
                             </li>
                     <li class="nav-item" role="presentation">
                   <button class="nav-link " id="cat_tab" data-bs-toggle="tab" data-bs-target="#Categories" type="button" role="tab" style="color: #012970" aria-controls="cd" aria-selected="true">Categories Wise Report</button>
                                </li>


         <%--  <li class="active"><a data-toggle="tab" href="#Prefix">Prefix Wise Report</a></li>
                    <li><a data-toggle="tab" href="#Categories">Categories Wise Report</a></li>--%>
                </ul>
            </div>
            <div class="col-lg-1"></div>
            <div class="col-lg-2" style="float: right;display:none;">
                <a id="dlink"  style="display:none;"></a>
                <%--<a id="btncountreport" class="btn btn-success btn-block btn-md">Prefix Count Report</a>--%>
                 <asp:Button ID="btncountreport" CssClass="btn btn-success" runat="server" Width="100%" OnClick="btncountreport_Click" Text="Excel" />
            </div>
        </div>
        <div class="tab-content">

            <div id="Prefix" class="tab-pane fade show active" role="tabpanel">
                <div class="card card-primary">
                    <div class="card-body">
                        <div class="row">
                                <div class="col-lg-3">
                                    <br />
                                    Select Prefix:
                                  <asp:DropDownList ID="ddlloadprefix" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-lg-2" style="padding-top: 59px">
                                        <asp:Button ID="btnGetData1" CssClass="btn btn-success" runat="server" Text="Get Data" Width="100%" OnClick="btnGetData1_Click" />
                                </div>
                             
                                 <div class="col-lg-2" style="padding-top: 59px">
                                      <asp:Button ID="btnGetClear" CssClass="btn btn-danger" runat="server" Text="Clear" Width="100%" OnClick="btnGetClear_Click" />
                                </div>
                                   <div class="col-lg-2" style="padding-top: 59px">
                                     <asp:Button ID="btnGetExcel" CssClass="btn btn-success" runat="server" Width="100%" OnClick="btnGetExcel_Click" Text="Excel" />
                                </div>
                            
                        </div>
                         <center>
                 <div class="loader" id="loader" runat="server" visible="false"></div>
                       </center>
                      <br />
                         <div class="table-responsive" style="overflow:scroll;height:550px">
                                  <asp:GridView ID="id_grid" runat="server" CssClass="table table-bordered table-hover"  HeaderStyle-CssClass="fixedheader" CellPadding="4" Style="width: 100%;text-align:center;"  AutoGenerateColumns="true" >   
                                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>                    
                        </div>
                    </div>
                </div>
            </div>


            <div id="Categories" class="tab-pane fade">
                <div class="card card-primary">
                    <div class="card-body">
                        <div class="row">
                            
                                <div class="col-lg-3">
                                    <br />
                                    Select Categories:
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>REFERENCE</asp:ListItem>
                                        <asp:ListItem>TEXT BOOK</asp:ListItem>
                                        <asp:ListItem>GENERAL</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2" style="padding-top: 59px">
                                        <asp:Button ID="btnCategoriesGetdata" CssClass="btn btn-success" runat="server" Text="Get Data" Width="100%" OnClick="btnCategoriesGetdata_Click" />
                                </div>
                            <div class="col-lg-2" style="padding-top: 59px">
                                       <asp:Button ID="btn_clear" CssClass="btn btn-danger" runat="server" Width="100%" OnClick="btn_clear_Click" Text="Clear" />
                                      </div>
                                  <div class="col-lg-2" style="padding-top: 59px">
                                       <asp:Button ID="btnCategoriesGetexcel" CssClass="btn btn-success" runat="server" Width="100%" OnClick="btnCategoriesGetexcel_Click" Text="Excel" />
                                      </div>
                                       </div>
                       
                                       <br />
                                        <div class="table-responsive" style="overflow:scroll;height:550px">
                                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" HeaderStyle-CssClass="fixedheader"  CellPadding="4" Style="width: 100%;text-align:center;" AutoGenerateColumns="true">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                                       </div>
                        </div></div></div>
                        </div>
            </div>

        </div>
                    </div>
         </div>
</asp:Content>

