<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tc.aspx.cs" Inherits="Portals_Staff_Student_tc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: 'Constantia';
            font-size: 19px;
            text-align: justify;
            margin-right: 15PX;
            margin-left: 15PX;
            line-height: 1.7
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <img src="../../../MANAGEMENT-AND-RESEARCH.jpg" style="width: 100%; height:150px" />
                <h2 style="text-decoration: underline;margin-top:0px;margin-bottom:0px">TRANSFERENCE CERTIFICATE</h2>
            </center>
            
        </div>
        <div>
            <p>
                &nbsp&nbsp&nbsp &nbsp&nbsp&nbsp Certified that <asp:Label runat="server" ID="shr_kum"></asp:Label>. <asp:Label runat="server" ID="lblname"  Font-Bold="true"></asp:Label>
                has been a student of the VIVA INSTITUTE OF MANAGEMENT & RESEARCH<br />
            
                &nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp Since passing the <asp:Label runat="server" ID="lblcou"  Font-Bold="true"></asp:Label> Examination <asp:Label ID="s_h_s" runat="server"></asp:Label> has not kept two terms in this Institiute. <asp:Label ID="h_s" runat="server"></asp:Label> has kept terms in this institute.
                 From <asp:Label runat="server" ID="firstmonth" Text="JULY"  Font-Bold="true"></asp:Label> to <asp:Label Font-Bold="true" runat="server" Text="NOV" ID="firstsecmonth" ></asp:Label>  (First Term) from <asp:Label ID="secfir" runat="server" Text="nov" Font-Bold="true"></asp:Label>  to  <asp:Label ID="secsecmonth" runat="server"  Font-Bold="true"></asp:Label> (Second Term)   </p>
         
            <pre style="font-family:'Times New Roman';margin-left:42px">
  (a)   <asp:Label runat="server" ID="a_his_her"></asp:Label> work in the Institute Examination  was as follows:
        <asp:Label runat="server" ID="a2_his_her"></asp:Label> <asp:Label ID="lblpassfail" runat="server"></asp:Label> at the <asp:Label ID="lbl_subcourse" runat="server" Font-Bold="true"></asp:Label>  Examination in
        MMS in <asp:Label ID="year" runat="server" Font-Bold="true"></asp:Label> getting examination in <asp:Label ID="month_year" runat="server" Text="April 2011" Font-Bold="true"></asp:Label>
  (b)  <asp:Label runat="server" ID="b_h_s"></asp:Label> would have been in the <asp:label ID="lbl_tranfercou" runat="server" Font-Bold="true"></asp:label> class if <asp:Label runat="server" ID="b2h_s"></asp:Label> had continued in the Institiute.      
  (c)  <asp:Label runat="server" ID="c_h_s"></asp:Label> has no books belonging  to this Institute in <asp:Label runat="server" ID="c2_h_s"></asp:Label>possession.
  (d)  Nothing is owning by <asp:Label ID="him_herd" runat="server"></asp:Label> on account of Institute dues.
  (e) <asp:Label runat="server" ID="e_h_h"></asp:Label>  conduct and character are <asp:label runat="server" ID="lbl_remark" Font-Bold="true"></asp:label> be the best of my Knowledge and belief.
  (f)  <asp:Label runat="server" ID="f_h_h"></asp:Label> birth-date has contained in the Institute Register is <asp:Label runat="server" ID="lbl_dob" Font-Bold="true"></asp:Label>
   (<asp:Label runat="server" ID="lbl_dobword" Font-Bold="true"></asp:Label>)
  (g)  <asp:Label runat="server" ID="g_h_s"></asp:Label> attended course of Instruction at this Institute in Voluntary subject or Group 
       of subjects.<asp:Label runat="server" ID="lbl_voluntary" Font-Bold="true"></asp:Label>
  (h)  <asp:Label ID="h_h_s" runat="server"></asp:Label> has satisfactorily gone through the course of Physical Training prescribed by
        the University.<asp:Label ID="h2_h_s" runat="server"></asp:Label> was exempted from Physical Training on medical grounds/on the 
       ground of <asp:Label ID="h3_h_h" runat="server"></asp:Label>being of member of N.C.C</pre>             
<p style="float:left;margin-top:1px">
    Date:  <asp:Label ID="lbl_date" runat="server" Font-Underline="true" Font-Bold="true" ></asp:Label>
    <br />
    Forwarded with compliments to the 
   <br />
   <asp:Label runat="server" ID="lbl_col_name" Font-Bold="true" Font-Underline="true" Style="font-family:'Times New Roman'"></asp:Label><br />
<asp:Label runat="server" ID="lbl_col_add" Font-Bold="true" Font-Underline="true" Style="font-family:'Times New Roman'"></asp:Label><br />
  Pincode: <asp:Label runat="server" ID="lbl_col_pin" Font-Bold="true" Font-Underline="true" Style="font-family:'Times New Roman'"></asp:Label>
</p>
            <pre style="float:right;margin-top:20px;font-family:'Times New Roman'">
             
                ___________
                    Director
            </pre>
        </div>
    </form>
    <script>
        window.onload = function () {
            window.print()
        }
        function targetMeBlank() {
            document.forms[0].target = "_blank";
        }
    </script>
</body>

</html>
