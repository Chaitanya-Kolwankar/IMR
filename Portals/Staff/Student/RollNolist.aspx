<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="RollNolist.aspx.cs" Inherits="Portals_Staff_Student_RollNolist" %>

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
            Student 
            </div>

            <div class="container-fluid">
                
                <div class="card">
                    <div class="card-title mx-4" >
                        Roll no list
                    </div>
                    <div class="card-body">
         

                        

                        
                    <div class="row">
                        <div class="col-lg-2 col-md-2 col-sm-12">
                            <label for="inputstate" class="form-label">
                                Faculty
                            </label>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                            <asp:DropDownList ID="ddlfaculty" runat="server" AutoPostBack="true" class="form-select" OnSelectedIndexChanged="ddlfaculty_SelectedIndexChanged"></asp:DropDownList>
                             </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12">
                            <label for="inputstate" class="form-label">
                                Course Name
                            </label>
                               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                            <asp:DropDownList ID="ddlcoursename" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcoursename_SelectedIndexChanged" CssClass="form-select"></asp:DropDownList>
                                     </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12">
                            <label for="inputstate" class="form-label">
                                Subcourse Name
                            </label>
                               <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                            <asp:DropDownList ID="ddlsubcourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlsubcourse_SelectedIndexChanged" CssClass="form-select"></asp:DropDownList>
                                     </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12">
                            <label for="inputstate" class="form-label">
                                Group
                            </label>
                               <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                            <asp:DropDownList ID="ddlgroup" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlgroup_SelectedIndexChanged" ></asp:DropDownList>
                                     </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                        <%--<div class="col-lg-2 col-md-2 col-sm-12">
                            <asp:Button ID="btnforblank" runat="server" Text="For Blank" CssClass="btn btn-primary form-control" style="margin-top:31px"/> 
                        </div--%>
                        <div class="col-lg-2 col-md-2 col-sm-12">
                               <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                  
                            <Triggers>
    <asp:PostBackTrigger ControlID="btnexcel" />
</Triggers>
                                <ContentTemplate>
                            <asp:Button ID="btnexcel" runat="server" Text="Get Excel" CssClass="btn  btn-primary form-control" OnClick="btnexcel_Click" style="margin-top:31px" />
                                     </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                    </div>
<div class="row my-2">
                            <div class="col-lg-2 col-md-2 col-sm-12">
                                 <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                            <asp:TextBox ID="txtotalstudno" runat="server" CssClass="form-control" style="border:0px" Text="Total no. of Student :"></asp:TextBox>
                                    </ContentTemplate></asp:UpdatePanel>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-12">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                <asp:Textbox ID="txtrollno" runat="server" CssClass="form-control" style="border:0px" Text=" Last Roll no. Given : "></asp:Textbox>
                                    </ContentTemplate></asp:UpdatePanel>
                            </div>
                          
                        </div> 
                                <br />
                           
                        <asp:UpdatePanel ID="updtepanel2" runat="server"> 
                            <ContentTemplate>
                                
                                <div style="width: 100%;
    height: 500px;
    overflow-y: auto;"> 
                                    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor ="White" style="overflow:auto; " OnRowDataBound="grid_RowDataBound">
                                        <Columns>
                                    <asp:TemplateField HeaderText="Student ID" HeaderStyle-CssClass="text-blue">
                                            <ItemTemplate>
                                                       <asp:Label ID="grdlblstudid" runat="server" ItemStyle-cssclass="caps" Text='<%#Eval("stud_id")%>'></asp:Label>
                                             </ItemTemplate>
                                    </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="grdlblstudname" runat="server" Text='<%#Eval("studentname")%>'></asp:Label> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Roll No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="grdlblroll" runat="server" Text='<%#Eval("Roll_no")%>'></asp:Label>
<%--                                                    <asp:TextBox ID="grdtxtroll" CssClass="form-control" OnTextChanged="grdtxtroll_TextChanged" AutoPostBack="true" runat="server" onkeypress="return alphanum(event)"   oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10"></asp:TextBox>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gender">
                                                <ItemTemplate>
                                                    <asp:Label ID="grdgender" runat="server" Text='<%#Eval("stud_Gender")%>'></asp:Label>
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
        </div>


    </main>
</asp:Content>

