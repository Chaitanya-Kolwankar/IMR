using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IdentityModel.Protocols.WSTrust;

public partial class FeeEntry_New : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["emp_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "loaddate()", true);
    }

    protected void lnksearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtstud = cls.fillDataTable("select (select isnull(stud_F_Name,'')+' '+isnull(stud_M_Name,'')+' '+isnull(stud_L_Name,'') [Name] from m_std_personaldetails_tbl where stud_id=a.stud_id) as [Name], (select course_name from m_crs_course_tbl where del_flag=0 and course_id in (select course_id from m_crs_subcourse_tbl where subcourse_id=a.subcourse_Id and del_flag=0)) as Course,(select subcourse_name from m_crs_subcourse_tbl where del_flag=0 and subcourse_id=a.subcourse_Id) Subcourse,(select Group_title from m_crs_subjectgroup_tbl where del_flag=0 and Group_id=a.group_id)[Group],group_id as [Group ID],(select Acd_year from academic where AYID=a.ayid)[Year],ayid as [AYID] from (select * from m_std_studentacademic_tbl where stud_id='" + txt_studid.Text + "' and del_flag=0)a order by ayid");
            if (dtstud.Rows.Count > 0)
            {
                grdyear.DataSource = dtstud;
                grdyear.DataBind();
                lblmodalid.Text = txt_studid.Text;
                lblmodalname.Text = dtstud.Rows[0]["Name"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('modalyear');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Student ID not found', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
    }

    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        try
        {
            txt_studid.Enabled = false;
            details.Visible = false;
            status.Visible = false;
            btn.Visible = false;
            feetable.Visible = false;
            GridViewRow gvrow = grdyear.SelectedRow;


            string stud_id = txt_studid.Text.Trim();
            string group_id = ((Label)gvrow.FindControl("lblgroupid")).Text.Trim();
            string course = ((Label)gvrow.FindControl("lblcourse")).Text.Trim();
            string subcourse = ((Label)gvrow.FindControl("lblsubcourse")).Text.Trim();
            string year = ((Label)gvrow.FindControl("lblyear")).Text.Trim();
            string ayid = ((Label)gvrow.FindControl("lblayid")).Text.Trim();

            string student_details = "select a.group_id,stud_Category,(select group_title from m_crs_subjectgroup_tbl where group_id=a.group_id) as group_title  from m_std_studentacademic_tbl as a,m_std_personaldetails_tbl as b,d_adm_applicant as c where a.stud_id=c.stud_id and a.stud_id=b.stud_id and  a.stud_id='" + txt_studid.Text.Trim() + "' and ayid='" + ayid + "' and a.del_flag=0;";
            student_details += "SELECT ISNULL(Paid.PaidAmount, 0) AS PaidAmount,ISNULL(Total.TotalAmount, 0) AS TotalAmount,ISNULL(Total.TotalAmount, 0) - ISNULL(Paid.PaidAmount, 0) AS Balance FROM (SELECT SUM(CAST(Amount AS INT)) AS PaidAmount FROM m_FeeEntry WHERE Stud_id = '"+ stud_id + "' AND Ayid = '"+ ayid + "' AND Chq_status = 'Clear' AND del_flag = 0) AS Paid CROSS JOIN(SELECT SUM(CAST(Amount AS INT)) AS TotalAmount FROM m_FeeMaster WHERE Ayid = '"+ ayid + "' AND Group_id = '"+ group_id + "' AND del_flag = 0 ) AS Total";

            DataSet ds = cls.fillDataset(student_details);
            if (ds.Tables["Calculated"].Rows.Count > 0)
            {
                lblname.Text = lblmodalname.Text.Trim();
                lblcourse.Text = course.ToString();
                lblsubcourse.Text = subcourse.ToString();
                lblgroup.Text = ds.Tables[0].Rows[0]["Group_Title"].ToString();
                lblgroupid.Text = ds.Tables[0].Rows[0]["Group_id"].ToString();
                lblyear.Text = year.ToString();
                lblayid.Text = ayid.ToString();
                lblcategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                lblpaidfees.Text = ds.Tables[1].Rows[0]["Paid"].ToString();
                lblbal.Text = ds.Tables[1].Rows[0]["Balance"].ToString();
                //lbl_totalfees.Text = (Convert.ToInt32(ds.Tables["Tution"].Rows[0][0].ToString()) + Convert.ToInt32(ds.Tables["Development"].Rows[0][0].ToString()) + Convert.ToInt32(ds.Tables["Other"].Rows[0][0].ToString())).ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal('modalyear');", true);
                feepanel.Visible = true;
                //load_grid(txt_studid.Text, ayid.ToString());
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Fees not defined', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
    }

    public DataTable Dropstatus(string stud_id, string ayid)
    {
        //New Query added with ayid for applying old tution and development fee only for years after dropped year
        string drop = "select distinct Batch_id,ayid from m_std_studentacademic_tbl where stud_id='" + stud_id + "' and ayid!>'" + ayid + "' and del_flag=0 and Batch_id='Drop' order by ayid";
        DataTable dt = cls.fillDataTable(drop);
        return dt;
    }

    protected void ddlpay_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {

    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

    }

    protected void chkselect_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void txtpay_TextChanged(object sender, EventArgs e)
    {

    }
}