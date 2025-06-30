<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="StudentReports.aspx.cs" Inherits="Portals_Staff_Student_StudentReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script>

    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />



  <link href="../../../Assets/multiselect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../../../Assets/multiselect/js/bootstrap-multiselect.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
      <style>
        .multiselect {
            width:100%;
            margin-top: 5px;
            border: 1px solid #ced4da;
        }

        .multiselect-container {
            height: 350px;
            width: 100%;
            overflow:scroll;
        }
        .btn-group{
            width:100%;
        }

        table, td, th {
            border: 1px solid #ddd;
            text-align: left;
        }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 8px;
        }

        th {
            color: darkblue;
            /*font-weight:100;*/
            font-weight:bold;
        }

        .FixedHeader {
            position: sticky;
            font-weight:100 ;
            top: 0;
        }

        .redcolor {
            color: red;
        }

        .chkbxx {
            height: 50px;
            width: 40px;
        }

        .caps {
            text-transform: capitalize;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main" id="main">
        <div class="container-fluid">
            <div class="card">
                 <div  class="card-title mx-4">                    
                     Student Report
                </div>
                <div class="card-body">
<div class="container-fluid">
    <div class="row">
        <div class="col-lg-3">
            <label for="inputState" class="form-label">Detail Fields</label>
            <asp:ListBox ID="lsbx_stdfidls" runat="server" CssClass="form-control" SelectionMode="Multiple" Width="100%">
                <asp:ListItem Text="Blood Group" Value="stud_BloodGroup as [Blood Group]"></asp:ListItem>
                <%--<asp:ListItem Text="Date Of Birth" Value="format(stud_DOB,'dd/MM/yyyy') as [Date Of Birth]"></asp:ListItem>--%>
                <asp:ListItem Text="Nationality" Value="stud_Nationality as [Nationality]"></asp:ListItem>
                <asp:ListItem Text="Religion" Value="stud_Religion as [Religion]"></asp:ListItem>
                <asp:ListItem Text="Birth Place" Value="stud_BirthPlace as [Birth Place]"></asp:ListItem>
                <asp:ListItem Text="Permemenent Address" Value="stud_PermanentAdd as [Permanent Address]"></asp:ListItem>
                <asp:ListItem Text="adress State" Value="stud_PermanentState as [state address] "></asp:ListItem>
                <asp:ListItem Text="stud City" Value="stud_permanentCity as [per city]"></asp:ListItem>
                <asp:ListItem Text="pincode" Value="stud_permanentPincode as [pincode]"></asp:ListItem>
                <asp:ListItem Text="Mobile No." Value="stud_permanentPhone as [Mobile no.]"></asp:ListItem>
                <asp:ListItem Text="Native Address" Value="stud_NativeAdd as [Native Address]"></asp:ListItem>
                <asp:ListItem Text="Native Sate" Value="stud_NativeState as [Native Sate]"></asp:ListItem>
                <asp:ListItem Text="Native City" Value="stud_NativeCity as [Native City]"></asp:ListItem>
                <asp:ListItem Text="Native Pincode" Value="stud_NativePincode as [Native Pincode]"></asp:ListItem>
                <asp:ListItem Text="Native Phone" Value="stud_NativePhone as [Native Phone]"></asp:ListItem>
                <asp:ListItem Text="Category" Value="stud_Category as [Category]"></asp:ListItem>
                <asp:ListItem Text="Caste" Value="stud_Caste as [Caste]"></asp:ListItem>
                <asp:ListItem Text="Sub Caste" Value="stud_SubCaste as [Sub caste]"></asp:ListItem>
                
                <asp:ListItem Text="Email ID" Value="stud_Email as [Email Id]"></asp:ListItem>
                <asp:ListItem Text="Father Name" Value="stud_Father_FName as [Father Name]"></asp:ListItem>
                <asp:ListItem Text="Father Last Name" Value="stud_Father_LName as [Father Last Name]"></asp:ListItem>
                <asp:ListItem Text="Address" Value="stud_Father_ResidentAdd as [Address]"></asp:ListItem>
                <asp:ListItem Text="Father Occupation" Value="stud_Father_Occupation as [Father Occupation]"></asp:ListItem>
                <asp:ListItem Text="Father Business/Service Address" Value="stud_Father_BusinessServiceAdd as [Father Business/Service Address]"></asp:ListItem>
                <asp:ListItem Text="Father Contact No." Value="stud_Father_TelNo as [Father Contact No.]"></asp:ListItem>
                <asp:ListItem Text="Mother Name" Value="stud_Mother_FName as [Mother Name]"></asp:ListItem>
                <asp:ListItem Text="Mother Middle Name" Value="stud_Mother_MName as [Mother Middle Name]"></asp:ListItem>
                <asp:ListItem Text="Mother Last Name" Value="stud_Mother_Lname as [Mother Last Name]"></asp:ListItem>
                <asp:ListItem Text="Mother Resident Address" Value="stud_Mother_Residentadd as [Mother Resident Address]"></asp:ListItem>
                <asp:ListItem Text="Mother Occupation" Value="stud_Mother_Occupation as [Mother Occupation]"></asp:ListItem>
                <asp:ListItem Text="Mother Service/Business" Value="stud_Mother_businessServiceadd as [Mother Service/Business]"></asp:ListItem>
                <asp:ListItem Text="Mother Contact No." Value="stud_Mother_TelNo as [Mother Contact No.]"></asp:ListItem>
                <asp:ListItem Text="Guardian First Name" Value="stud_Gaurd_Fname as [Guardian First Name]"></asp:ListItem>
                <asp:ListItem Text="Guardian Middle Name" Value="stud_gaurd_Mname as [Guardian Middle Name]"></asp:ListItem>
                <asp:ListItem Text="Guardian Last Name" Value="stud_gaurd_Lname as [Guardian Last Name]"></asp:ListItem>
                <asp:ListItem Text="Guardian Contact no." Value="stud_gaurd_TelNo as [guardian Contact No.]"></asp:ListItem>
                <asp:ListItem Text="Guardian Address" Value="stud_gaurd_add as [Gaurdian Address]"></asp:ListItem>
                <asp:ListItem Text="Numbers of Family Members" Value="stud_NoOfFamilyMembers as [Numbers of Family Members]"></asp:ListItem>
                <asp:ListItem Text="Earning membersin family" Value="stud_Earning as [Earning membersin family]"></asp:ListItem>
                <asp:ListItem Text="Non Earning members in family" Value="stud_NonEarning as [Non Earning members in family]"></asp:ListItem>
                <asp:ListItem Text="Yearly Income of Family" Value="stud_YearlyIncome as [yearly Income of Family]"></asp:ListItem>

                <%--m_std_academic--%>
                
                <asp:ListItem Text="Student Roll no." Value="Roll_no as [Roll no.]"></asp:ListItem>
                <asp:ListItem Text="division" Value="Division"></asp:ListItem>
                <asp:ListItem Text="Library card No." Value="Lib_Card_No as [Libaray card no.]"></asp:ListItem>
                
            </asp:ListBox>

        </div>
        <div class="col-lg-1" style="margin-top:35px">
            <asp:Button ID="btngetdata" Text="Get Data" OnClick="btngetdata_Click" CssClass="btn btn-primary" runat="server"/>
        </div>
        <div class="col-lg-1"  style="margin-top:35px">
            <asp:Button ID="btnclr" Text="Clear" onclick="btnclr_Click" CssClass="btn btn-primary" runat="server" />
        </div>
        <div class="col-lg-1"  style="margin-top:35px">
            <asp:Button ID="btngetexcel" runat="server" OnClick="btngetexcel_Click" CssClass="btn btn-primary" Text="Get Excel" />
        </div>
    </div>
    </div>
    <br />
         <div id="scrll" style="width: 100%; height: 600px; overflow-x:auto">    
        <asp:GridView runat="server" OnRowDataBound="Unnamed_RowDataBound" ID="grdrep" AutoGenerateColumns="true" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White">
            <Columns>
                
            </Columns>
        </asp:GridView>
             </div>
    </div>


                </div>
            </div>
        </div>
    </div>
    
    <script>
        lstbx();
        function lstbx() {
            $(function () {
                $('[id*=lsbx_stdfidls]').multiselect({
                    includeSelectAllOption: true
                });
            });
        }
    </script>
</asp:Content>

