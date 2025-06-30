<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="Course_Master.aspx.cs" Inherits="Portals_Staff_Admission_Master_Course_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../../Assets/datatable/DataTable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Assets/datatable/DataTable.js" type="text/javascript"></script>
    <style>
        table, td, th {
            border: 1px solid #ddd;
            text-align: left;
        }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 15px;
        }

        th {                                                
            color: #012970;
        }

        .caps {
            text-transform: capitalize;
        }

        .label {
            font-weight: 600;
            color: #012970;
        }

        .FixedHeader {
            position: sticky;
            font-weight: bold;
            top: 0;
        }

        .hidden {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Master
            </div>
            <div class="container-fluid ">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-title mx-4" style="font-size: 21px">Course Master</div>
                            <div class="card-body">
                                <div class="container-fluid">
                                    <ul class="nav nav-tabs" id="myTab" role="tablist">
                                        <li class="nav-item" role="presentation">
                                           <%-- <asp:UpdatePanel runat="server">
                                                <ContentTemplate>--%>
      <button class="nav-link active" onclick="oncoursetab()" id="hometab" data-bs-toggle="tab" data-bs-target="#home" type="button" role="tab" style="color: #012970" aria-controls="home" aria-selected="true" >Course</button>
                                                <%--</ContentTemplate>
                                            </asp:UpdatePanel>--%>
 
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <%--<asp:UpdatePanel runat="server">
                                                <ContentTemplate>--%>
<button class="nav-link" id="profiletab" data-bs-toggle="tab" data-bs-target="#profile" type="button" role="tab" style="color: #012970" aria-controls="profile" aria-selected="false" >Sub Course</button>
                                                <%--</ContentTemplate>
                                            </asp:UpdatePanel>--%>

                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <%--<asp:UpdatePanel runat="server">
                                                <ContentTemplate>--%>
                                            <button class="nav-link" id="contacttab" data-bs-toggle="tab" data-bs-target="#contact" type="button" role="tab" style="color: #012970" aria-controls="contact" aria-selected="false">Group</button>
                                                <%--</ContentTemplate>
                                            </asp:UpdatePanel>--%>

                                        </li>
                                    </ul>
                                    <div class="tab-content" id="myTabContent">
                                        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="hometab">
                                            <br />
                                            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>--%>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            Faculty :       
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>


                                                                    <asp:DropDownList ID="ddl_Faculty" CssClass="form-select" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_Faculty_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>

                                                       <%-- <div class="col-2">
                                                            Pattern :  
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>


                                                                    <asp:DropDownList ID="DropDownList1" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="1">Term</asp:ListItem>
                                                                        <asp:ListItem Value="2">Semester</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>--%>

                                                        <div class="col-lg-2">
                                                            Course :                                                   
                                                            <asp:TextBox runat="server" ID="txtCourse" MaxLength="40" CssClass="form-control" oncopy="return false" autocomplete="off"
                                                                onkeyPress="return alphaandnum(event)" onpaste="return false"
                                                                oncut="return false" />
                                                        </div>


                                                        <div class="col-1">
                                                            <div>&nbsp</div>
                                                            <asp:Button ID="Save" runat="server" Text="Add" CssClass="btn btn-primary" Style="width: 100%" OnClick="Save_Click" />
                                                        </div>
                                                        <div class="col-1">
                                                            <div>&nbsp</div>
                                                            <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="btncancel_Click" Style="width: 100%" />
                                                        </div>
                                                    </div>
                                                    <br />

                                                    <%--Gridfor course===========================================--%>
                                                    <div style="">
                                                        <div style="max-height:400px; width:100%; overflow:auto">
                                                            <div class="row">
                                                                <%--<asp:UpdatePanel runat="server" UpdateMode="Conditional" ><ContentTemplate>--%>
                                                                <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="White" OnRowDataBound="grd_RowDataBound"  HeaderStyle-CssClass="FixedHeader" Style="max-height: 400px; overflow: auto">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Faculty Name" HeaderStyle-CssClass="text-blue">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="grdlblfacultyname" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("faculty_name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:TemplateField HeaderText="Pattern" HeaderStyle-CssClass="text-blue">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="grdpattern" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("course_pattern") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Course Name" HeaderStyle-CssClass="text-blue">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="grdcourname" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("course_name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                       
                                                                        <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-blue">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="grdbutton" runat="server" Text=" View" OnClick="grdbutton_Click" CommandName="select" CommandArgument="<%#Container.DataItemIndex %>"><i class="bi bi-pencil"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-blue">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="grdcou" runat="server" Style="color: red" Text="Delete" OnClick="grdcou_Click"> <i class="bi bi-trash"></i> </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="grdcourseid" runat="server" Visible="false" Text='<%#Eval("course_id") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                                <%--   </ContentTemplate>

                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="DropDownList1" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <%--  </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </div>
                                        <%-- for subcourse===============================--%>
                                        <div class="tab-pane fade"  id="profile" role="tabpanel" aria-labelledby="profiletab">
                                            <br />
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-2">
                                                            Faculty :
                                            
                                                    <asp:DropDownList ID="ddl_faculty2" CssClass="form-select" runat="server" OnSelectedIndexChanged="ddl_faculty2_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>

                                                        </div>
                                                        <div class="col-2">
                                                            Course :
                                           
                                                    <asp:DropDownList ID="ddl_course" CssClass="form-select" runat="server" OnSelectedIndexChanged="ddl_course_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>

                                                        </div>
                                                        <div class="col-2">
                                                            Sub Course
                                                    
                                                            <asp:TextBox ID="txtsubcourse" runat="server" CssClass="form-control" MaxLength="25" oncopy="return false"
                                                                autocomplete="off" onkeyPress="return alphaandnum(event)" onpaste="return false"
                                                                oncut="return false" />

                                                        </div>
                                                        <div class="col-1">
                                                            &nbsp
                                                    <br />

                                                            <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" Text="Add" Style="width: 100%" CssClass="btn btn-primary" />


                                                        </div>
                                                        <div class="col-1">
                                                            &nbsp
                                                    <br />


                                                            <asp:Button ID="cncl" runat="server" Text="Cancel" OnClick="cncl_Click" CssClass="btn btn-primary" Style="width: 100%" />

                                                        </div>
                                                    </div>

                                                    <div>
                                                        <br />

                                                                <div style="max-height:400px; width:100%; overflow:auto">
                                                                    <div>
                                                                        <asp:GridView ID="grdSubCourse" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="White" HeaderStyle-CssClass="FixedHeader" Style="max-height: 400px; overflow: auto">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Faculty Name" HeaderStyle-CssClass="text-blue">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="grdlblfacultyname" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("faculty_name") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Course Name" HeaderStyle-CssClass="text-blue">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="grdcourname" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("course_name") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Subcourse Name" HeaderStyle-CssClass="text-blue">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="grdsubcours" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("subcourse_Name") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="View " HeaderStyle-CssClass="text-blue">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="grdbutton" runat="server" OnClick="grdbutton_Click1"><i class="bi bi-pencil"></i></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Delete " HeaderStyle-CssClass="text-blue">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton Style="color: red" ID="btnsubdel" runat="server" OnClick="btnsubdel_Click"><i class="bi bi-trash"></i></asp:LinkButton>

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="grdsubcouid" runat="server" Visible="false" Text='<%#Eval("subcourse_id") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="grdcouid" runat="server" Visible="false" Text='<%#Eval("course_id") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>
                                                            <%--</ContentTemplate>--%>
                                                           <%-- <Triggers>
                                                                <asp:PostBackTrigger ControlID="ddl_course" />
                                                            </Triggers>--%>
                                                        <%--</asp:UpdatePanel>--%>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <%-- for Group===========================================================--%>
                                        <div class="tab-pane fade"  id="contact" role="tabpanel" aria-labelledby="contacttab">
                                            <br />
                                            <div class="row">
                                                <div class="col-2">
                                                    Faculty :
                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddl_faculty3" CssClass="form-select" runat="server" OnSelectedIndexChanged="ddl_faculty3_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                                </div>
                                                <div class="col-2">
                                                    Course :
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddl_course3" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_course3_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                                </div>
                                                <div class="col-2">
                                                    Sub Course :
                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddl_Subcourse" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Subcourse_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-2">
                                                    Group
                                                     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                         <ContentTemplate>
                                                             <asp:TextBox ID="txtgroup" MaxLength="20" runat="server" CssClass="form-control" oncopy="return false"
                                                                 autocomplete="off" onkeyPress="return alphaandnum(event)" onpaste="return false"
                                                                 oncut="return false" />
                                                         </ContentTemplate>
                                                     </asp:UpdatePanel>
                                                </div>
                                                <div class="col-1">
                                                    &nbsp
                                                    <br />
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btngrupadd" runat="server" Text="Add" CssClass="btn btn-primary" Style="width: 100%" OnClick="btngrupadd_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-1">
                                                    &nbsp
                                                    <br />
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btngrpcancel" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="btngrpcancel_Click" Style="width: 100%" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>

                                            </div>
                                            <br />
                                            <div style="max-height:400px; width:100%; overflow:auto">
                                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdgrp" runat="server"  AutoGenerateColumns="false" HeaderStyle-BackColor="White"  HeaderStyle-CssClass="FixedHeader" Style="max-height: 400px; overflow: auto">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Course Name" HeaderStyle-CssClass="text-blue">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="grdgrupcourse" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("course_name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Subcourse Name" HeaderStyle-CssClass="text-blue">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="grdgrupsubcour" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("subcourse_name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Group Title Name" HeaderStyle-CssClass="text-blue">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="grdgruptitle" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("Group_title") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="gruopid" runat="server" Visible="false" Text='<%#Eval("Group_id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="courseid" runat="server" Visible="false" Text='<%#Eval("course_id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="subcourseid" runat="server" Visible="false" Text='<%#Eval("subcourse_id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="facultyid" runat="server" Visible="false" Text='<%#Eval("faculty_id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="View " HeaderStyle-CssClass="text-blue">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="grdbtngrupview" runat="server" OnClick="grdbtngrupview_Click"><i class="bi bi-pencil"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-blue">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="grdbtnview" runat="server" OnClick="grdbtnview_Click1"> <i style="color:red" class="bi bi-trash"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div>
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        //var prm = Sys.WebForms.PageRequestManager.getInstance();

        ///prm.add_endRequest(function () {
        // createDataTable();
        //});

        //createDataTable();
        //"order": [[0, "desc"]]
        // function createDataTable() {
        //   $('#<%= grd.ClientID %>').DataTable({



        // });
        //$('#<%= grdSubCourse.ClientID %>').DataTable({



        //});
        //$('#<%= grdgrp.ClientID %>').DataTable({



        //});

        //}
        function alphaandnum(event) {
            var val = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z0-9()-\s]+$/);
            return pattern.test(val);
        }
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }

        function oncoursetab() {
            $.ajax({
                type: "get",
                url: 'Course_Master.aspx/Coursetab',
                data:{},
                contentType: "application/json;",
                success: function (msg) {  
                },
                error: function (e) {
                    
                }
            });
        }
        function subcoutab() {
            $.ajax({
                type: "POST",
                url: 'Course_Master.aspx/Coursetab',
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {

                },
                error: function (e) {

                }
            });
        }
    </script>
</asp:Content>

