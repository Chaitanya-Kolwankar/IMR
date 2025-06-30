 using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Student_RollNolist : System.Web.UI.Page
{
    Class1 obj = new Class1();
    DataTable dt6 = new DataTable();
    bool rtrn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlsubcourse.Attributes.Add("disabled", "disabled");
            ddlcoursename.Attributes.Add("disabled", "disabled");
            ddlgroup.Attributes.Add("disabled", "disabled");
            txtotalstudno.Attributes.Add("disabled", "disabled");
            txtrollno.Attributes.Add("disabled", "disabled");
            //btnexcel.Attributes.Add("disabled", "disabled");
            btnexcel.Enabled = false;
            // btnforblank.Attributes.Add("disabled","disabled");
            //  chkgenerate.Enabled = false;

            string query1 = "select faculty_id,faculty_name from m_crs_faculty where del_flag='0'";
            obj.fillDataTable(query1);
            DataTable dt = new DataTable();
            dt = obj.fillDataTable(query1);

            ddlfaculty.DataTextField = dt.Columns["faculty_name"].ToString();
            ddlfaculty.DataValueField = dt.Columns["faculty_id"].ToString();
            ddlfaculty.DataSource = dt;
            ddlfaculty.DataBind();
            ddlfaculty.Items.Insert(0, new ListItem("--select--", "NA"));
        }

    }
    protected void ddlfaculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlfaculty.SelectedItem.ToString() == "--select--")
            {
                grid.DataSource = null;
                grid.DataBind();
                ddlcoursename.Items.Clear();
                ddlsubcourse.Items.Clear();
                ddlgroup.Items.Clear();
                btnexcel.Enabled = false;
                txtotalstudno.Text = " Total no of Student : 0";
                txtrollno.Text = "Last roll no given: 0";
            }
            else
            {
            ddlcoursename.Attributes.Remove("disabled");
            string querycoursename = "select course_id,course_name from m_crs_course_tbl where del_flag='0' and faculty_id='" + ddlfaculty.SelectedItem.Value + "'";
            obj.fillDataTable(querycoursename);
            DataTable dt1 = new DataTable();
            dt1 = obj.fillDataTable(querycoursename);
            ddlcoursename.DataTextField = dt1.Columns["course_name"].ToString();
            ddlcoursename.DataValueField = dt1.Columns["course_id"].ToString();
            ////
            ddlsubcourse.DataSource = "";
            ddlsubcourse.DataBind();
            ddlsubcourse.Items.Insert(0, new ListItem("--select--", ""));
            //
            ddlgroup.DataSource = "";
            ddlgroup.DataBind();
            ddlgroup.Items.Insert(0, new ListItem("--select--", ""));
            ///
            ddlcoursename.DataSource = dt1;
            ddlcoursename.DataBind();
            ddlcoursename.Items.Insert(0, new ListItem("--select--", ""));

            dataload();
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }
    protected void ddlcoursename_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlsubcourse.Attributes.Remove("disabled");
            string querysubcourse = "select subcourse_id,subcourse_name from m_crs_subcourse_tbl where del_flag='0' and course_id='" + ddlcoursename.SelectedItem.Value + "'";
            DataTable dt2 = obj.fillDataTable(querysubcourse);
            if(dt2.Rows.Count> 0)
            {
                ddlsubcourse.DataTextField = dt2.Columns["subcourse_name"].ToString();
                ddlsubcourse.DataValueField = dt2.Columns["subcourse_id"].ToString();
                //ddlgroup.DataSource = "";
                //ddlgroup.DataBind();
                //ddlgroup.Items.Insert(0, new ListItem("--select--", ""));

                ddlsubcourse.DataSource = dt2;
                ddlsubcourse.DataBind();
                ddlsubcourse.Items.Insert(0, new ListItem("--select--", ""));
                ddlgroup.Items.Clear();
                dataload();
                grid.DataSource = null;
                grid.DataBind();
            }
            else if (ddlcoursename.SelectedItem.ToString() == "--select--")
            {
                ddlsubcourse.Items.Clear();
                ddlgroup.Items.Clear();
                grid.DataSource = null;
                grid.DataBind();
                //btnexcel.Attributes.Add("disabled", "disabled");
                btnexcel.Enabled = false;
                //========================================================================================================
                txtotalstudno.Text = " Total no of Student : 0";
                txtrollno.Text = "Last roll no given: 0";
            }

            else{
                //btnexcel.Attributes.Add("disabled", "disabled");
                btnexcel.Enabled = false;
                txtotalstudno.Text = " Total no of Student : 0";
                txtrollno.Text = "Last roll no given: 0";
                grid.DataSource = null;
                grid.DataBind();
                ddlsubcourse.Items.Clear();
                ddlgroup.Items.Clear();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('No Subcourse Assign to this Course.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);            
            }
           
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }
    protected void ddlgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string grdquery = "select UPPER(LEFT(m_std_personaldetails_tbl.stud_F_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_F_Name,2,LEN(m_std_personaldetails_tbl.stud_F_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_M_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_M_Name,2,LEN(m_std_personaldetails_tbl.stud_M_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_L_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_L_Name,2,LEN(m_std_personaldetails_tbl.stud_L_Name))) as studentname,m_std_studentacademic_tbl.stud_id,m_std_studentacademic_tbl.Roll_no   ,m_std_personaldetails_tbl.stud_Gender from m_std_studentacademic_tbl left join m_std_personaldetails_tbl on m_std_studentacademic_tbl.stud_id=m_std_personaldetails_tbl.stud_id where m_std_studentacademic_tbl.del_flag=0 and group_id='" + ddlgroup.SelectedItem.Value + "' and ayid='"+ Session["Year"] + "' order by cast(roll_no as int),stud_L_Name,stud_F_Name,stud_M_Name";
            dt6 = obj.fillDataTable(grdquery);
            Session["session_dt6"] = obj.fillDataTable(grdquery);
           
            if (dt6.Rows.Count > 0)
            {
                
                grid.DataSource = dt6;
                grid.DataBind();

                dataload();
                //btnexcel.Attributes.Remove("disabled");
                btnexcel.Enabled = true;
            }
            else if(ddlgroup.SelectedItem.ToString()=="--select--")
            {
                //btnexcel.Attributes.Add("disabled", "disabled");
                btnexcel.Enabled = false;
                txtotalstudno.Text = " Total no of Student : ";
                txtrollno.Text = "Last roll no given: ";
                grid.DataSource = null;
                grid.DataBind();
            }
            else 
            {
                btnexcel.Enabled = false;
                //btnexcel.Attributes.Add("disabled", "disabled");
                txtotalstudno.Text = " Total no of Student : 0";
                txtrollno.Text = "Last roll no given: 0";
                grid.DataSource = null;
                grid.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('No Student Assign to this Group', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }
    protected void ddlsubcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlgroup.Attributes.Remove("disabled");
            string querygroup = "select group_id,group_title from m_crs_subjectgroup_tbl where del_flag='0' and subcourse_id='" + ddlsubcourse.SelectedItem.Value + "'";
            DataTable dt3 = obj.fillDataTable(querygroup);
            if(dt3.Rows.Count>0)
            {
                ddlgroup.DataTextField = dt3.Columns["group_title"].ToString();
                ddlgroup.DataValueField = dt3.Columns["group_id"].ToString();
                ddlgroup.DataSource = dt3;
                ddlgroup.DataBind();
                ddlgroup.Items.Insert(0, new ListItem("--select--", ""));
                dataload();
            }
            else if (ddlsubcourse.SelectedItem.ToString() == "--select--")
            {
                grid.DataSource = null;
                grid.DataBind();
                ddlgroup.Items.Clear();
                txtotalstudno.Text = " Total no of Student : 0";
                txtrollno.Text = "Last roll no given: 0";
                btnexcel.Enabled = false;
            }
            else{
                //btnexcel.Attributes.Add("disabled", "disabled");
                btnexcel.Enabled = false;
                txtotalstudno.Text = " Total no of Student : 0";
                txtrollno.Text = "Last roll no given: 0";
                grid.DataSource = null;
                grid.DataBind();
                ddlgroup.Items.Clear();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('No Group assign to this Subcourse.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }

    public void dataload()
    {

        // btnexcel.Attributes.Remove("disabled");
        // btnforblank.Attributes.Remove("disabled");
        // string totalnoofstudent = "select count(*) as total,max(Roll_no) from m_std_studentacademic_tbl where group_id='" + ddlgroup.Text + "' and ayid  from m_academic)";
        string totalnoofstudent = "select count(*) as total,max(Roll_no)as roll from m_std_studentacademic_tbl where group_id='"+ddlgroup.SelectedValue.ToString()+ "' and ayid='" + Session["Year"] + "' and subcourse_Id='"+ddlsubcourse.SelectedValue.ToString()+"' and del_flag=0 ";

        DataTable dt4 = new DataTable();
        dt4 = obj.fillDataTable(totalnoofstudent);


        txtotalstudno.Text = " Total no of Student :" + dt4.Rows[0]["total"].ToString();
        Session["session_Total"] = dt4.Rows[0]["total"].ToString();
        string lastgiven = "select max(cast(Roll_no as int)) as maxrollno from m_std_studentacademic_tbl where group_id='" + ddlgroup.SelectedValue.ToString() + "' and ayid='" + Session["Year"] + "'";
        DataTable dt5 = obj.fillDataTable(lastgiven);
        txtrollno.Text = "Last roll no given:" + dt5.Rows[0]["maxrollno"].ToString();
        Session["maximum"] = dt5.Rows[0]["maxrollno"].ToString();
        if (dt5.Rows[0]["maxrollno"].ToString() == "")
        {
            txtrollno.Text = "Last roll no given:0";
        }
        //string grdquery = "select UPPER(LEFT(m_std_personaldetails_tbl.stud_F_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_F_Name,2,LEN(m_std_personaldetails_tbl.stud_F_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_M_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_M_Name,2,LEN(m_std_personaldetails_tbl.stud_M_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_L_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_L_Name,2,LEN(m_std_personaldetails_tbl.stud_L_Name))) as studentname,m_std_studentacademic_tbl.stud_id,m_std_studentacademic_tbl.Roll_no   ,m_std_personaldetails_tbl.stud_Gender from m_std_studentacademic_tbl left join m_std_personaldetails_tbl on m_std_studentacademic_tbl.stud_id=m_std_personaldetails_tbl.stud_id where group_id='" + ddlgroup.SelectedItem.Value + "' and ayid in (select max(AYID) from m_academic) order by cast(roll_no as int),stud_L_Name,stud_F_Name,stud_M_Name";
        //dt6 = obj.fillDataTable(grdquery);
        //Session["session_dt6"] = obj.fillDataTable(grdquery);
        //grid.DataSource = dt6;
        //grid.DataBind();


    }


    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "50px");
                Label lblgender = (Label)e.Row.FindControl("grdgender");
                if (lblgender.Text == "0")
                {
                    lblgender.Text = "Female";
                }
                else
                {
                    lblgender.Text = "Male";
                }

            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }
    protected void grdtxtroll_TextChanged(object sender, EventArgs e)
    {

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlfaculty.SelectedItem.ToString() == "--select--")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select Faculty  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (ddlcoursename.SelectedItem.ToString() == "--select--")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select course  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (ddlsubcourse.SelectedItem.ToString() == "--select--")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select Sub course  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (ddlgroup.SelectedItem.ToString() == "--select--")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select Group  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "Employee" + DateTime.Now + ".xls";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                grid.GridLines = GridLines.Both;
                grid.HeaderStyle.Font.Bold = true;
                grid.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }
}

