<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="AssignRollNo.aspx.cs" Inherits="Portals_Staff_Admission_AssignRollNo" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        .FixedHeader {
            position: sticky;
            font-weight: bold;
            top: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle" style="font-size: 29px; margin-left: 34px; font-weight: 300; color: #012970;">
                Assign Roll no
            </div>
            <div class="container-fluid">
                
                
                <div class="card">
                    <div class="card-title mx-4">
                        Assign Roll no.
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-lg-2 col-md-2 col-sm-12">
                                    <label for="inputState" class="form-label">
                                        Faculty
                                    </label>
                                       <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                    <asp:DropDownList ID="ddlfaculty" runat="server" class="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlfaculty_SelectedIndexChanged"  >
                                         
                                    </asp:DropDownList>
                                    </ContentTemplate>    
                                        </asp:UpdatePanel>
                                </div> 
                                
                                <div class="col-lg-2 col-md-2 col-sm-12">
                                    <label for="inputState" class="form-label">
                                        Course Name
                                    </label>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                    <asp:DropDownList ID="ddlCoursename" runat="server" class="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCoursename_SelectedIndexChanged" >

                                    </asp:DropDownList>
                                            </ContentTemplate>
                                </asp:UpdatePanel> 
                                </div>
                                    
                                <div class="col-lg-2  col-md-2 col-sm-12">
                                    <label for="inputState" class="form-label">
                                        Subcourse Name
                                    </label>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                    <asp:DropDownList ID="ddlsubcour" runat="server" class="form-select" OnSelectedIndexChanged="ddlsubcour_SelectedIndexChanged" AutoPostBack="true">

                                    </asp:DropDownList>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                </div>  
                                <div class="col-lg-2  col-md-2 col-sm-12">

                                    <label for="inputState" class="form-label">
                                        Group
                                    </label>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                    <asp:DropDownList ID="ddlgrup" runat="server" class="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlgrup_SelectedIndexChanged">

                                    </asp:DropDownList>
                                    </ContentTemplate>
                                        </asp:UpdatePanel>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-12">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                <asp:Button ID="btnforbank" runat="server" Text="For Blank" CssClass="btn btn-primary  form-control" OnClick="btnforbank_Click"  style="margin-top:31px"/>
                                        </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="form-control btn btn-primary " onclick="btnsave_Click" style="margin-top:31px"/>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:Button ID="btncncl" runat="server" CssClass="form-control btn btn-primary" Text="Cancel" OnClick="btncncl_Click" style="margin-top:31px" />
                                        </div>
                                    </div>
                                        
                                       
                           <%-- <div class="col-lg-2 col-md-4 col-sm-12">


                                 
                             </div> --%>
                                
                            </div>
                             
                            
                            </div>
                        <div class="row my-2">
                                <div class="col-lg-2 col-md-3 col-sm-12">                                   
                                <asp:TextBox ID="txtotalstudno" runat="server" CssClass="form-control" style="border:0px" Text="Total no of Student :"></asp:TextBox>
                            </div>
                            <div class="col-lg-2 col-md-3 col-sm-12">
                                <asp:TextBox ID="txtlastrollnogiven" runat="server" CssClass="form-control" style="border:0px" Text=" Last Rollno. given : "></asp:TextBox>
                            </div> 

               
                             
                            <div class="col-lg-2 col-md-2 col-sm-12  my-2">
                                <asp:CheckBox ID="chkgenerate" runat="server" AutoPostBack="true" OnCheckedChanged ="chkgenerate_CheckedChanged" /> <label for="inputState" class="form-label">Generate</label> 
                            </div> 
                        </div>
                         <br />
                        </ContentTemplate>
                </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>

                        <div  style="max-height:400px; width:100%; overflow:auto">

                        

                       
                        <asp:GridView ID="grd1" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White" style="overflow:auto; max-height:400px;" OnRowDataBound="grd1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Student ID"  HeaderStyle-CssClass="text-blue">
                                    <ItemTemplate>
                                        <asp:Label ID="grdlbltsudid" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("stud_id")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Name" >
                                    <ItemTemplate>
                                        <asp:Label ID="grdlblstudname" runat="server" Text='<%#Eval("studentname")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roll No.">  
                                    <ItemTemplate>
                                        <asp:TextBox ID="grdtxtroll" autocompelete="off" CssClass="form-control" AutoPostBack="true"  runat="server" ViewStateMode="Enabled" onkeyPress="return alphanum(event)" Text='<%#Eval("Roll_no")%>'  oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10"></asp:TextBox>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Gender">
                                    <ItemTemplate>
                                        <asp:Label ID="grdlblgender" runat="server" Text='<%#Eval("stud_Gender")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                 
                        </div>
                            <div class="row">
                                <div class="col-lg-3" >
                                    <%--<asp:Button ID="btngetexcel" runat="server" CssClass="form-control btn btn-primary " Text=" Get Excel"  OnClick="btngetexcel_Click"/>--%>
                                </div>
                                <div class="col-lg-3">
                                    <%--<asp:Button ID="btnclear" runat="server" CssClass="form-control btn  btn-primary" Text="Clear" OnClick="btnclear_Click" />--%>
                                </div>
                            </div>

                
                        </ContentTemplate>
                </asp:UpdatePanel>




                    </div>
                </div>
            </div>
        </div>
    </main>
    <script>

        function alphanum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z0-9\/\s\']+$/);
            return pattern.test(value);
        }
        var table = $('#example').DataTable()

        //    $('#eventType').change(function() {
        //    $('#texr2').text('New Text');


        // }
        // });
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
    </script>
</asp:Content>

