using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_StudentCancellation : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["emp_id"]) == "")
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
            else
            {
                btnclear.Visible = false;
                btncncladmn.Visible = false;
                lbltxtchange.Visible = false;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
                clear();
            }
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
    }
    protected void lbsearch_Click(object sender, EventArgs e)
    {
        if (txtstudid.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Kindly Enter Student ID','danger')", true);
        }
        else
        {

            string searchqry = "Select isnull(per.stud_F_name,'')  +'  '+ isnull(per.stud_M_name,'') +'  '+ isnull(per.stud_L_name,'') as  stud_name, aca.group_id,class.subcourse_name,class.subcourse_id, course.Course_id, course.course_name, per.Del_Flag, fac.faculty_name, grp.group_title,grp.Descritption, (select MAX(fyid)fyid  from m_std_pervrecord_tbl where Stud_id='" + txtstudid.Text + "') fyid ,aca.ayid ,sum(fee_mas.Amount) as course_tot_fees,(select sum(amount) from m_feeentry as entry where entry.stud_id = aca.stud_id and entry.del_flag = 0 and ENTRY.TYPE='Fee' and entry.Chq_status = 'Clear' and entry.ayid = fee_mas.ayid ) as course_fee_paid,            (select top 1 convert(varchar,Curr_dt ,106 )  from m_std_studentacademic_tbl where Stud_id='" + txtstudid.Text + "' order by curr_dt desc) admission_date,case when (select sum(amount) from m_feeentry as entry where entry.stud_id = aca.stud_id and entry.del_flag = 0 and ENTRY.TYPE='Fee' and entry.Chq_status = 'Clear' and entry.ayid = fee_mas.ayid )< sum(fee_mas.Amount)             then 'BALANCE'              else case when (select sum(amount) from m_feeentry as entry where entry.stud_id = aca.stud_id and entry.del_flag = 0 and ENTRY.TYPE='Fee' and entry.Chq_status = 'Clear' and entry.ayid = fee_mas.ayid )= sum(fee_mas.Amount)  then 'PAID' else 'PAID MORE' end end 'FEES STATUS'  from 	m_std_studentacademic_tbl as aca		inner join 	m_std_personaldetails_tbl as per on per.stud_id = aca.stud_id 		inner join  	m_crs_subcourse_tbl as class on class.subcourse_id = aca.subcourse_id 		inner join 	m_crs_course_tbl as course on course.course_id = class.course_id 		inner join 	m_crs_faculty  as fac on fac.faculty_id = course.faculty_id inner join  	m_crs_subjectgroup_tbl as grp on grp.Group_id = aca.group_id 		left outer join  	m_feemaster as fee_mas on fee_mas.group_id = grp.group_id and fee_mas.ayid = aca.AYID  where  aca.stud_id = '" + txtstudid.Text + "' and  	aca.AYID = (select max(ayid) from m_std_studentacademic_tbl where stud_id='" + txtstudid.Text + "') and aca.del_flag=0 group by aca.course_tot_fees, aca.course_fee_paid,   aca.group_id, class.subcourse_name,  course.Course_id,   course.course_name, per.Del_Flag,  fac.faculty_name, grp.group_title ,aca.ayid, per.stud_F_name, per.stud_M_name, per.stud_L_name, aca.stud_id , fee_mas.ayid ,class.subcourse_id,grp.Descritption";
            DataTable dtsearch = cls.fillDataTable(searchqry);

            string chkcontains = dtsearch.Columns["Del_Flag"].ToString();
            if (dtsearch.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' No Student Available With ID: " + txtstudid.Text + "','danger')", true);
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Student Available With '" + txtstudid.Text + "' ID','danger')", true);

            }
            else if (chkcontains=="True")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('student admission already cancelled ','danger')", true);
                txtstudid.Text = "";
        
        }
            else
            {
                txtname.Text = dtsearch.Rows[0]["stud_name"].ToString();
                txtcou.Text = dtsearch.Rows[0]["course_name"].ToString();
                txtclass.Text = dtsearch.Rows[0]["group_title"].ToString();
                txtcoufees.Text = dtsearch.Rows[0]["course_tot_fees"].ToString();
                txtpaid.Text = dtsearch.Rows[0]["course_fee_paid"].ToString();
                txtfeestat.Text = dtsearch.Rows[0]["FEES STATUS"].ToString();
                txtadmdate.Text = dtsearch.Rows[0]["admission_date"].ToString();
            }
                        // txtcncldte.Text = dtsearch.Rows[0][""].ToString();
            //  txtdaydiff.Text = dtsearch.Rows[0][""].ToString();
        }


    }
    //protected void txtcncldte_TextChanged(object sender, EventArgs e)
    //{
    //    System.DateTime dtTodayNoon = new System.DateTime(2018, 9, 13, 12, 0, 0);
    //    System.DateTime dtYestMidnight = new System.DateTime(txtcncldte.);
    //    int diffResult = (dtTodayNoon - dtYestMidnight).Days;  

    ////string  adimdate=  txtadmdate.Text;
    ////DateTime admindate = adimdate.Date;
    ////    DateTime canceldate = DateTime.Now;
    ////    var numberOfDays = (futurDate - TodayDate).TotalDays;
    //}
    protected void txtcncldte_TextChanged(object sender, EventArgs e)
    {
        btnclear.Visible = true;
        lbltxtchange.Visible = true;
        btncncladmn.Visible = true;
        lbltxtchange.Text = txtstudid.Text;
    }
    protected void btncncladmn_Click(object sender, EventArgs e)
    {
        cls.CancelAdmission(txtstudid.Text, Session["Year"].ToString(), Session["Year"].ToString(), ddlreason.SelectedValue.ToString());
        if(cls.CancelAdmission(txtstudid.Text, Session["Year"].ToString(), Session["Year"].ToString(), ddlreason.SelectedValue.ToString()))
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Admission Cancelled ','danger')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong ','danger')", true);

        }

    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
    }
    public void clear() 
    {
        txtstudid.Text = "";
        txtname.Text = ""; txtcou.Text = "";
        txtclass.Text = "";
        txtcoufees.Text = "";
        txtpaid.Text = "";
        txtfeestat.Text = "";
        txtadmdate.Text = "";
        txtcncldte.Text = "";
        txtdaydiff.Text = "";
        ddlreason.SelectedIndex = 0;
        lbltxtchange.Text = "";
    }
}