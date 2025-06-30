<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="ApplicantReport.aspx.cs" Inherits="Portals_Staff_Admission_ApplicantReport" %>

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
            color: blue;
            font-weight:100;
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
                    Applicant Report
                </div>
                <div class="card-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-3">
                               <label for="inputState" class="form-label">Details Fields</label>
                                <asp:ListBox runat="server" ID="lstbx_detail" CssClass="form-control" SelectionMode="Multiple" Width="100%">
                                    <asp:ListItem Text="Mother Name" Value="Mo_name as [Mother Name]"></asp:ListItem>
                                 
                                    <asp:ListItem Text="Religion" Value="Religion"></asp:ListItem>
                                    <asp:ListItem Text="Physical Handicap" Value="phy_handicap_Description as [Physical Handicap description]"></asp:ListItem>
                                    <asp:ListItem Text="Address" Value="Address_line1 +' '+Address_line2+' '+Address_line3+' '+city+' '+pincode as [Address]"></asp:ListItem>
                                    <asp:ListItem Text="Nationality" Value="Nationality"></asp:ListItem>
                                    <asp:ListItem Text="applicant Mobile No." Value="Mob_No as [Student Mobile no.]"></asp:ListItem>
                                    <asp:ListItem Text="applicant Email ID" Value="Email_id as [Applicant Email Id]"></asp:ListItem>
                                    <asp:ListItem Text="s.s.c" Value="S_Exam as [Exam ssc]"></asp:ListItem>
                                    <asp:ListItem Text="s.s.c institute name" Value="S_Ins_Name"></asp:ListItem>
                                    <asp:ListItem Text="s.s.c Institute Place" Value="S_Ins_Place as [Institute Palce]"></asp:ListItem>
                                    <asp:ListItem Text="s.s.c Seat Name" Value="S_seat_no as [ssc seat No.]"></asp:ListItem>
                                    <asp:ListItem Text="ssc Board Name" Value="S_Board_name"></asp:ListItem>
                                    <asp:ListItem Text="ssc Sate" Value="S_state as [ssc State]"></asp:ListItem>
                                    <asp:ListItem Text="ssc passing month" Value="S_Month as [ssc passing Month]"></asp:ListItem>
                                    <asp:ListItem Text="ssc passing Year" Value="S_Year as [S.S.C Passing Year]"></asp:ListItem>
                                    <asp:ListItem Text="ssc Marks Obtained" Value="S_Mks_Obtained as [ssc Marks Obtained]"></asp:ListItem>
                                    <asp:ListItem Text="ssc Outof Marks" Value="S_Mks_OutOf as [ssc outof marks]"></asp:ListItem>
                                    <asp:ListItem Text="ssc first Attempt" Value="  case when s_First_Attempt=1 then 'Yes' when S_First_Attempt=0 then 'No' else '' end as [ssc First Attempt]"></asp:ListItem>
                                    <asp:ListItem Text="ssc grade" Value="S_grade as [ssc grade]" ></asp:ListItem>
                                    <asp:ListItem Text="blood Group" Value="blood_group as [blood Group]"></asp:ListItem>
                                    <asp:ListItem Text="BirthPlace" Value="birth_place as [birthPlace]"></asp:ListItem>
                                    <asp:ListItem Text="Domicile" Value="Domicile"></asp:ListItem>
                                    <asp:ListItem Text="Father Age" Value=" Father_age  as [father's Age]"></asp:ListItem>
                                    <asp:ListItem Text="Father Email ID" Value="Father_emailID as [Father's Email ID]"></asp:ListItem>
                                    <asp:ListItem Text="Father Contact no." Value="Father_Contact_No AS [Father's Contact No.]"></asp:ListItem>
                                    <asp:ListItem Text="Father Qualification" Value="Father_qualification as [Father Qualification]"></asp:ListItem>
                                    <asp:ListItem Text="Father Occupation" Value="Father_Occup as [Father Occupation]"></asp:ListItem>
                                    <asp:ListItem Text="Father Designation" Value="Father_desg as [Father Designation]"></asp:ListItem>
                                    <asp:ListItem Text="Father Business Address" Value="Father_Busi_addr as [Father bussiness address]"></asp:ListItem>
                                    <asp:ListItem Text="Mother Age" Value="Mother_age as [Mother's Age]"></asp:ListItem>
                                    <asp:ListItem Text="Mother EmailID" Value="Mother_emailID as [Mother's Email ID]"></asp:ListItem>
                                    <asp:ListItem Text="Mother Contact No." Value="Mother_contact_No as [Mother Contact no.]"></asp:ListItem>
                                    <asp:ListItem Text="Mother Qualification" Value="Mother_qualification as [Mother Qualification]"></asp:ListItem>
                                    <asp:ListItem Text="Mother Occupation" Value="Mother_Occup as [Mother's Occupation]"></asp:ListItem>
                                    <asp:ListItem Text="Mother Designation" Value="Mother_desg as [Mother's Designation]"></asp:ListItem>
                                    <asp:ListItem Text="Mother Bussiness Address" Value="Mother_Busi_Addr as [Mother Bussiness Address]"></asp:ListItem>
                                    <asp:ListItem Text="Is Ncc/Nss" Value="is_Nss_Ncc as [Is NSS/NCC]"></asp:ListItem>
                                    <asp:ListItem Text="Is Scholarship" Value="case when is_Scholarship=1 then 'yes' when is_Scholarship=0 then 'No' else '' end  as [Is Scholarship]"></asp:ListItem>
                                    <asp:ListItem Text="no. of Earning members in Family" Value="Earning as [no. of Earning members in Family]"></asp:ListItem>
                                    <asp:ListItem Text="no. of Non Earning members in family" Value="NonEarning as [no. of Non Earning members in family]"></asp:ListItem>
                                    <asp:ListItem Text="Annual Income" Value="Annual_Income as [Annual Income]"></asp:ListItem>
                                    <asp:ListItem Text="Certificate No." Value="Certificate_No as [Certificate No.]"></asp:ListItem>
                                    <asp:ListItem Text="Extra Curricular Activities" Value="Extra_Curricular_Activities as [Extra Curricular Activities]"></asp:ListItem>                                    
                                    <asp:ListItem Text="physically handicapped" Value="case when phy_handicap=1 then 'yes' when phy_handicap=0 then 'No' else '' end as   [Physcially Handicapped]"></asp:ListItem>
                                    <asp:ListItem Text="Category" Value="Category as [Category]"></asp:ListItem>
                                    <asp:ListItem Text="Caste" Value="CASE ISNULL(Caste,'')  WHEN  'NULL' THEN ''   ELSE ISNULL(Caste,'') END as [Caste]"></asp:ListItem>
                                    <asp:ListItem Text="Sub Caste" Value="Sub_Caste as [Sub Caste]"></asp:ListItem>
                                    <asp:ListItem Text="s.s.c Board Name" Value="Board_name as [sscBoard Name]"></asp:ListItem> 
                                    <asp:ListItem Text="Current State" Value="State as [State]"></asp:ListItem>
                                    <asp:ListItem Text="Percentage" Value="percentage as [Percentage]"></asp:ListItem>
                                   <asp:ListItem Text="ssc year Passsing" Value="year as [S.S.C year of Passing]"></asp:ListItem>
                                    <asp:ListItem  Text="Month" Value="Month"></asp:ListItem>
                                    <asp:ListItem Text="Date of Birth" Value="DOB as [Date of Birth]"></asp:ListItem>
                                    <%--<asp:ListItem Text="Date of Birth" Value="format(DOB,'dd/MM/yyyy') as [Date of Birth]"></asp:ListItem>--%>
                                    <asp:ListItem Text="Other Criteria" Value="other_criteria as [Other Criteria]"></asp:ListItem>
                                    <asp:ListItem Text="Group Name" Value="Group_id as [Group Title]"></asp:ListItem>
                                    <%--<asp:ListItem Text="Quota" Value="Quota"></asp:ListItem>--%>
                                    <%--<asp:ListItem Text="is Admitted" Value="Is_Admited as [Is admitted]"></asp:ListItem>--%>
                                    <%--<asp:ListItem Text="is Inhouse" Value="Is_Inhouse"></asp:ListItem>--%>
                                    <asp:ListItem Text="Remark" Value="Remark"></asp:ListItem>
                                    <asp:ListItem Text="Merit List" Value="Meritlist as [Merit List]"></asp:ListItem>
                                    <asp:ListItem Text="Merit List Date" Value="MeritList_Date as [Merit List Date]"></asp:ListItem>
                                    <asp:ListItem Text="Pre Faculty" Value="pre_faculty as [Pre Faculty]"></asp:ListItem>
                                    <asp:ListItem Text="Is Diploma Holder" Value="CASE WHEN  diploma_holder=1 THEN 'Yes' WHEN diploma_holder=0 then 'No' else '' end as [Diploma Holder]"></asp:ListItem>
                                    <%-- ---------------------- --%>
                                    <asp:ListItem Text="Subjects" Value="subjects"></asp:ListItem>
                                    <asp:ListItem Text="FYID" Value="FYID AS [FYID]"></asp:ListItem>
                                    <asp:ListItem Text="hsc Exam" Value="Exam"></asp:ListItem>
                                    <asp:ListItem Text="hsc state" Value="State_board as [hsc state board]"></asp:ListItem>
                                    <asp:ListItem Text="HSC Institute Name" Value="Ins_name"></asp:ListItem>
                                    <asp:ListItem Text="HSC Institute Place Name" Value="Ins_place"></asp:ListItem>
                                    <asp:ListItem Text="HSC Seat No." Value="Seat_No as [HSC Seat No.]"></asp:ListItem>
                                    <asp:ListItem Text="HSC  Marks Obtained" Value="Mks_Obtained as [HSC Marks Obtained]"></asp:ListItem>
                                    <asp:ListItem Text="HSC Out of Marks" Value="Mks_outof as [hsc Out Of]"></asp:ListItem>
                                    <%-- ----------------- --%>
                                    <asp:ListItem Text="Entrance exam type" Value="exam_type as [Entrance exam type]"></asp:ListItem>
                                    <asp:ListItem Text="Entrance Exam marks Obtained" Value="jee_obt as [Entrance Exam marks Obtained]"></asp:ListItem>
                                    <asp:ListItem Text="Entrance Exam Outof Marks" Value="jee_outof as [Entrance Exam Outof Marks]"></asp:ListItem>
                                    <asp:ListItem Text="Post Graduate State" Value="pg_state as [Post Graduate State]"></asp:ListItem>
                                    <asp:ListItem Text="Post Graduate Board" Value="pg_board as [PostGraduate University]"></asp:ListItem>
                                    <asp:ListItem Text="Post Graduate Institute Name" Value="pg_inst_name as [Post Graduate Institute Name]"></asp:ListItem>
                                    <asp:ListItem Text="Post Graduate Institute Place" Value="pg_inst_place"></asp:ListItem>
                                    <asp:ListItem Text="Post Graduate first Attempt" Value="CASE WHEN  pg_first_attempt=1 THEN 'Yes' WHEN pg_first_attempt=0 then 'No' else '' end AS [Post Graduate first Attempt]"></asp:ListItem>
                                    <asp:ListItem Text="post Graduate Passing year" Value="pg_passing_tear as [post Graduate Passing year]"></asp:ListItem>
                                    <asp:ListItem Text="post Graduate Passing Month" Value="pg_passing_month"></asp:ListItem>
                                    <asp:ListItem Text="post Graduate Total Marks" Value="pg_total_mks as [Post Graduate Total Marks]"></asp:ListItem>
                                    <asp:ListItem Text="post Graduate out of marks" Value="pg_out_of_mks as [Post Graduate OutOf Marks]"></asp:ListItem>
                                    <asp:ListItem Text="post Graduate Grade" Value="pg_grade as [post Graduate Grade]"></asp:ListItem>
 <asp:ListItem Text="post Graduate Seat" Value="pg_seat_no as [post Graduate Seat]"></asp:ListItem>
                                    <asp:ListItem Text="ty Institute Name" Value="ty_institute_name as [ty institute Name]"></asp:ListItem>
                                    <asp:ListItem Text="ty Institute Place" Value="ty_Institute_place as [ty Institute Place]"></asp:ListItem>
                                    <asp:ListItem Text="ty University" Value="ty_board as [ty University]"></asp:ListItem>
                                    <asp:ListItem Text="ty State" Value="ty_state as [ty State]"></asp:ListItem>
                                    <asp:ListItem Text="ty Marks Obtained" Value="ty_marks_obt as [ty Marks Obtained]"></asp:ListItem>
                                    <asp:ListItem Text="ty OutOf Marks" Value="ty_out_of as [ty OutOf Marks]"></asp:ListItem>
                                    <asp:ListItem Text="ty Grade Obtained" Value="ty_grade_obt as [ty Grade Obtained]"></asp:ListItem>
                                    <asp:ListItem Text="ty year Passing" Value="ty_pass_year as [ty year Passing]"></asp:ListItem>
                                    <asp:ListItem Text="ty Pass Month" Value="ty_pass_month as [ty Pass Month]"></asp:ListItem>
                                    <asp:ListItem Text="ty First Attempt" Value="CASE WHEN  ty_first_Attempt=1 THEN 'Yes' WHEN ty_first_Attempt=0 then 'No' else '' end as [TY First Attempt]"></asp:ListItem>
                                    <asp:ListItem Text="ty Seat no." Value="ty_seat_No"></asp:ListItem>
                                    <asp:ListItem Text="ty Course" Value="ty_course as [TY Course Name]"></asp:ListItem>                                                             
                                </asp:ListBox>
                            </div>
                            <div class="col-lg-1" style="margin-top:36PX">
                                <asp:Button runat="server" CssClass="btn btn-primary" ID="BTN_GETDATA" OnClick="BTN_GETDATA_Click"  Text="Get Data"/>
                            </div>
                            <div class="col-lg-1" style="margin-top:36PX">
                                 <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_Clear" OnClick="btn_Clear_Click" Text="  Clear  " />
                            </div>
                             <div class="col-lg-1" style="margin-top:36PX">
                                <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_excl" OnClick="btn_excl_Click" Text="Get Excel" />
                            </div>

                        </div>
                       
                        <br />

                            <div id="scrll" style="width: 100%; height: 600px; overflow-x:auto">    
                                <asp:GridView ID="Grid_app" runat="server" AutoGenerateColumns="true" OnRowDataBound="Grid_app_RowDataBound"  HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="white">
                                <Columns>

                                </Columns>

                            </asp:GridView>
                                </div>

                       
                    </div>
                    <br />

                </div>
            </div>
        </div>
    </div>
   

    <script>
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
        lstbx();
        function lstbx() {
            $(function () {
                $('[id*=lstbx_detail]').multiselect({
                    includeSelectAllOption: true

                });
            });
        }
    </script>


</asp:Content>

