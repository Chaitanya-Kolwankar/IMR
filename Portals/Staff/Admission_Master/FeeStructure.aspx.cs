using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_Master_FeeStructure : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlcourse.Attributes.Add("disabled", "disabled");
            ddlsubcou.Attributes.Add("disabled", "disabled");
            ddlgrup.Attributes.Add("disabled", "disabled");
            string facultyqry = "select faculty_id,faculty_name from m_crs_faculty where del_flag='0'";
            cls.fillDataTable(facultyqry);
            DataTable dt1 = new DataTable();
            dt1 = cls.fillDataTable(facultyqry);
            ddlfac.DataTextField = dt1.Columns["faculty_name"].ToString();
            ddlfac.DataValueField = dt1.Columns["faculty_id"].ToString();
            ddlfac.DataSource = dt1;
            ddlfac.DataBind();
            ddlfac.Items.Insert(0, new ListItem("--Select--", "na"));
        }
    }


    protected void ddlfac_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlcourse.Attributes.Remove("disabled");
            string courseqry = "select course_id,course_name from m_crs_course_tbl where del_flag='0' and faculty_id='" + ddlfac.SelectedItem.Value + "'";
            cls.fillDataTable(courseqry);
            DataTable dt2 = new DataTable();
            dt2 = cls.fillDataTable(courseqry);
            ddlcourse.DataTextField = dt2.Columns["course_name"].ToString();
            ddlcourse.DataValueField = dt2.Columns["course_id"].ToString();
            ddlcourse.DataSource = dt2;
            ddlcourse.DataBind();
            ddlcourse.Items.Insert(0, new ListItem("--Select--", "na"));
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        }
    }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlsubcou.Attributes.Remove("disabled");
            string subcourseqry = "select subcourse_id,subcourse_name from m_crs_subcourse_tbl where del_flag='0' and course_id='" + ddlcourse.SelectedItem.Value + "'";
            cls.fillDataTable(subcourseqry);
            DataTable dt3 = new DataTable();
            dt3 = cls.fillDataTable(subcourseqry);
            ddlsubcou.DataTextField = dt3.Columns["subcourse_name"].ToString();
            ddlsubcou.DataValueField = dt3.Columns["subcourse_id"].ToString();
            ddlsubcou.DataSource = dt3;
            ddlsubcou.DataBind();
            ddlsubcou.Items.Insert(0, new ListItem("--Select--", "na"));
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        }


    }

    protected void ddlsubcou_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlgrup.Attributes.Remove("disabled");

            string querygroup = "select group_id,group_title from m_crs_subjectgroup_tbl where del_flag='0' and subcourse_id='" + ddlsubcou.SelectedItem.Value + "'";
            DataTable dt3 = cls.fillDataTable(querygroup);
            ddlgrup.DataTextField = dt3.Columns["group_title"].ToString();
            ddlgrup.DataValueField = dt3.Columns["group_id"].ToString();
            ddlgrup.DataSource = dt3;
            ddlgrup.DataBind();

            ddlgrup.Items.Insert(0, new ListItem("--select--", ""));
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        }
    }
    protected void ddlgrup_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlinstall_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}