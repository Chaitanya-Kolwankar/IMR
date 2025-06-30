using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Student_tc : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        string passfail = Request.QueryString["pass_fail"];
        if (passfail== "Passed") 
        {
            lblpassfail.Text = "passed";

        }
        else 
        {
            lblpassfail.Text = "failed";

        }
        
        string gender = Request.QueryString["gender"];
        if (gender== "Male") 
        {
            h_s.Text = "He";
            s_h_s.Text = "he";
            shr_kum.Text="Shri";
            a_his_her.Text="His";
            a2_his_her.Text = "His";
            //
            b_h_s.Text = "He";
            b2h_s.Text = "He";
            c_h_s.Text = "He";
            c2_h_s.Text = "He";
            e_h_h.Text = "His";
            //him_herd.Text = "Him";
            f_h_h.Text = "His";
            g_h_s.Text = "He";
            h_h_s.Text = "He";
            h2_h_s.Text = "He";
            h3_h_h.Text = "his";

        }
        else 
        {
            h3_h_h.Text = "her";
            h2_h_s.Text = "She";
          h_s.Text = "She";
            s_h_s.Text = "she";
            shr_kum.Text="Kum";
            a_his_her.Text="Her";
            a2_his_her.Text = "Her";
            //lblpassfail;
            b_h_s.Text = "She";
             b2h_s.Text = "She";
            c_h_s.Text = "She";
            c2_h_s.Text = "She";
            e_h_h.Text = "Her";
          //  him_her.Text = "Her";
            f_h_h.Text = "Her";
            g_h_s.Text = "She";
            h_h_s.Text = "She";




        }
        //shr_kum;
        //a_his_her;
        //a2_his_her
        //lblpassfail;
        //b_h_s
        // b2h_s
        //c_h_s
        //c2_h_s
        //e_h_h
        //him_her
        //f_h_h
        //g_h_s
        //h_h_s
        string name = Request.QueryString["name"];
        lblname.Text = name;
        string course = Request.QueryString["cou"];
        lblcou.Text = course;
        string frsttermfrm = Request.QueryString["fir_term_frm"];
        firstmonth.Text = frsttermfrm;
        string fir_term_to = Request.QueryString["fir_term_to"];
        firstsecmonth.Text = fir_term_to;
        string sec_term_frm = Request.QueryString["sec_term_frm"];
        secfir.Text = sec_term_frm;
        string sec_secmonth = Request.QueryString["sec_term_to"];
        secsecmonth.Text = sec_secmonth;
        string subcourse = Request.QueryString["subcou"];
        lbl_subcourse.Text = subcourse;
        string year1 = Request.QueryString["reportyear"];
        year.Text = year1;
        string month__year = Request.QueryString["month_yeara3"];
        month_year.Text = month__year;
        string trancou = Request.QueryString["tranfercour"];
        lbl_tranfercou.Text = trancou;
        string remark1 = Request.QueryString["remark"];
        lbl_remark.Text = remark1;
        string dob = Request.QueryString["dob"];
        lbl_dob.Text = dob;
        string worddob = Request.QueryString["dobword"];
        lbl_dobword.Text = worddob;
        string volun = Request.QueryString["voluntarysubject"];
        lbl_voluntary.Text = volun;
        string date = "select convert(varchar, GETDATE(),103) as dat";
        DataTable dt = cls.fillDataTable(date);
        lbl_date.Text = dt.Rows[0]["dat"].ToString();
        string clg_name = Request.QueryString["colname"];
        lbl_col_name.Text = clg_name;
        string col_add = Request.QueryString["coladd"];
        lbl_col_add.Text = col_add;
        string colpincode = Request.QueryString["colpin"];
        lbl_col_pin.Text = colpincode;
    }
}