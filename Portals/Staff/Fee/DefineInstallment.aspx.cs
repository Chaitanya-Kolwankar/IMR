using iTextSharp.tool.xml.css;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Fee_DefineInstallment : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {

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

    protected void btnsave_Click(object sender, EventArgs e)
    {

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {

    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        try
        {
            txt_studid.Enabled = false;
            GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
            string stud_id = txt_studid.Text.Trim();
            string group_id = ((Label)gvrow.FindControl("lblgroupid")).Text.Trim();
            string course = ((Label)gvrow.FindControl("lblcourse")).Text.Trim();
            string subcourse = ((Label)gvrow.FindControl("lblsubcourse")).Text.Trim();
            string year = ((Label)gvrow.FindControl("lblyear")).Text.Trim();
            string ayid = ((Label)gvrow.FindControl("lblayid")).Text.Trim();
            string Group_Title = ((Label)gvrow.FindControl("lblgroup")).Text.Trim();

            DataTable dt_category = cls.fillDataTable("select distinct stud_Category,UPPER(stud_Gender) [stud_Gender] from m_std_personaldetails_tbl where stud_id='" + txt_studid.Text.Trim() + "' and del_flag=0");

            if (dt_category.Rows.Count > 0)
            {
                string category = dt_category.Rows[0]["stud_Category"].ToString().Trim().ToUpper();
                string gender = dt_category.Rows[0]["stud_Gender"].ToString().Trim().ToUpper();
                gender = gender == "0" ? "FEMALE" : (gender == "1" ? "MALE" : gender);
                if (dt_category.Rows[0]["stud_Category"].ToString() == "OPEN")
                {
                    Session["feemaster"] = "m_FeeMaster";
                    Session["gender"] = "NON";
                }
                else
                {
                    Session["feemaster"] = "m_FeeMaster_category";
                    Session["gender"] = gender;
                }
                string student_details = "SELECT ISNULL(Paid.PaidAmount, 0) AS PaidAmount,ISNULL(Total.TotalAmount, 0) AS TotalAmount,ISNULL(Total.TotalAmount, 0) - ISNULL(Paid.PaidAmount, 0) AS Balance FROM (SELECT SUM(CAST(Amount AS INT)) AS PaidAmount FROM m_FeeEntry WHERE Stud_id = '" + stud_id + "' AND Ayid = '" + ayid + "' AND Chq_status = 'Clear' AND del_flag = 0) AS Paid CROSS JOIN(SELECT SUM(CAST(Amount AS INT)) AS TotalAmount FROM " + Session["feemaster"].ToString() + " WHERE Ayid = '" + ayid + "' AND Group_id = '" + group_id + "' AND del_flag = 0 and Gender='" + Session["gender"].ToString() + "' and Category='" + category + "' ) AS Total";

                DataTable dt = cls.fillDataTable(student_details);
                if (dt.Rows.Count > 0)
                {
                    lblname.Text = lblmodalname.Text.Trim();
                    lblgender.Text = gender;
                    lbl_totalfees.Text = dt.Rows[0]["Balance"].ToString();
                    lblgroup.Text = Group_Title;
                    lblgroupid.Text = group_id;
                    lblyear.Text = year.ToString();
                    lblayid.Text = ayid.ToString();
                    lblcategory.Text = category;
                    lblpaidfees.Text = dt.Rows[0]["PaidAmount"].ToString();
                    lblbal.Text = dt.Rows[0]["Balance"].ToString();
                    //lbl_totalfees.Text = (Convert.ToInt32(ds.Tables["Tution"].Rows[0][0].ToString()) + Convert.ToInt32(ds.Tables["Development"].Rows[0][0].ToString()) + Convert.ToInt32(ds.Tables["Other"].Rows[0][0].ToString())).ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal('modalyear');", true);
                    feepanel.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Fees not defined', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Category not defined', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
    }

    protected void ddl_installment_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public string getnum(int num)
    {
        switch (num)
        {
            case 1: return "ONE";
            case 2: return "TWO";
            case 3: return "THREE";
            case 4: return "FOUR";
            case 5: return "FIVE";
            case 6: return "SIX";
            case 7: return "SEVEN";
            case 8: return "EIGHT";
            case 9: return "NINE";
            case 10: return "TEN";
            default: return "INVALID";
        }
    }
}