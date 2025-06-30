using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_Master_Course_Master : System.Web.UI.Page
{
    DataTable dt1;
    DataTable dtcrs;
    Class1 cls = new Class1();
    string pat;
    Label lblcourseid;
    Label lblgrdsubcourseID;
    string lblgroupid;
    string ccou_var;
    //coursetab.Attributes.Add("Class", "nav-link  ");
    //coursetab.Attributes.Add("aria-selected", "false");;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["Emp_id"]) == "")
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
            else
            {
                DataOnPageLoad();
                txtCourse.Enabled = false;
                //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
                //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
                //grdgrp.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        //DataOnPageLoad();
        //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
        // grdgrp.HeaderRow.TableSection = TableRowSection.TableHeader;

    }

    public void DataOnPageLoad()
    {
        string facultyQuery = "select faculty_id,faculty_name from m_crs_faculty where del_flag=0";
        DataTable dt = new DataTable();
        dt = cls.fillDataTable(facultyQuery);
        ddl_Faculty.DataTextField = dt.Columns["faculty_name"].ToString();
        ddl_Faculty.DataValueField = dt.Columns["faculty_id"].ToString();
        ddl_Faculty.DataSource = dt;
        ddl_Faculty.DataBind();
        ddl_Faculty.Items.Insert(0, new ListItem("--Select--", "na"));
        string grdquery = "SELECT m_crs_faculty.faculty_name, m_crs_faculty.faculty_id, m_crs_course_tbl.course_id,m_crs_course_tbl.course_id, m_crs_course_tbl.course_name, m_crs_course_tbl.course_pattern FROM m_crs_course_tbl INNER JOIN m_crs_faculty ON m_crs_course_tbl.faculty_id = m_crs_faculty.faculty_id where m_crs_course_tbl.del_flag='0' and m_crs_faculty.del_flag='0' order by m_crs_course_tbl.course_id asc";
        DataTable dt1 = new DataTable();
        dt1 = cls.fillDataTable(grdquery);
        grd.DataSource = dt1;
        grd.DataBind();

        ddl_faculty2.DataTextField = dt.Columns["faculty_name"].ToString();
        ddl_faculty2.DataValueField = dt.Columns["faculty_id"].ToString();
        ddl_faculty2.Items.Insert(0, new ListItem("--Select--", "na"));
        ddl_faculty2.DataSource = dt;
        ddl_faculty2.DataBind();
        ddl_faculty2.Items.Insert(0, new ListItem("--Select--", "na"));

        ddl_faculty3.DataTextField = dt.Columns["faculty_name"].ToString();
        ddl_faculty3.DataValueField = dt.Columns["faculty_id"].ToString();
        ddl_faculty3.Items.Insert(0, new ListItem("--Select--", "na"));
        ddl_faculty3.DataSource = dt;
        ddl_faculty3.DataBind();
        ddl_faculty3.Items.Insert(0, new ListItem("--Select--", "na"));
        //for subcourse
        string querysubrs = "SELECT dbo.m_crs_faculty.faculty_id, dbo.m_crs_course_tbl.course_id, dbo.m_crs_course_tbl.course_name, dbo.m_crs_faculty.faculty_name, dbo.m_crs_subcourse_tbl.subcourse_id, dbo.m_crs_subcourse_tbl.course_id AS Expr1, dbo.m_crs_subcourse_tbl.subcourse_name FROM            dbo.m_crs_course_tbl INNER JOIN                        dbo.m_crs_faculty ON dbo.m_crs_course_tbl.faculty_id = dbo.m_crs_faculty.faculty_id INNER JOIN                         dbo.m_crs_subcourse_tbl ON dbo.m_crs_course_tbl.course_id = dbo.m_crs_subcourse_tbl.course_id where dbo.m_crs_faculty.del_flag='0' and dbo.m_crs_course_tbl.del_flag='0' and dbo.m_crs_subcourse_tbl.del_flag='0'  order by m_crs_subcourse_tbl.subcourse_id asc";
        DataTable dtSubcoures = cls.fillDataTable(querysubrs);
        grdSubCourse.DataSource = dtSubcoures;
        grdSubCourse.DataBind();
        string groupquery = "select a.course_id, a.course_name,b.subcourse_name,b.subcourse_id, c.Group_title,c.Group_id, d.faculty_id,d.faculty_name from m_crs_course_tbl as a, m_crs_subcourse_tbl as b,m_crs_subjectgroup_tbl as c ,m_crs_faculty as d where a.course_id=b.course_id and b.subcourse_id=c.Subcourse_id and d.faculty_id=a.faculty_id and c.del_flag='0' and a.del_flag='0'and b.del_flag='0' order by c.Group_id asc ";
        DataTable grpdt = cls.fillDataTable(groupquery);
        grdgrp.DataSource = grpdt;
        grdgrp.DataBind();

       // DropDownList1.Enabled = false;
        //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void Fac_Click(object sender, EventArgs e)
    {
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Faculty.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select faculty','danger')", true);

            }
            //else if (DropDownList1.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Pattern','danger')", true);

            //}
            else if (txtCourse.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Add Course Name','danger')", true);

            }
            else
            {
                string chkduplicate = "select course_name, course_pattern from m_crs_course_tbl where del_flag='0' and course_name='" + txtCourse.Text.Trim() + "'";
                DataTable dtchk = cls.fillDataTable(chkduplicate);
                if (dtchk.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Provided Course Name Already Exist.','danger')", true);

                }

                else
                {
                    if (Save.Text == "Add")
                    {
                        string facid = ddl_Faculty.SelectedValue.ToString();
                        string insertCourse = "insert into m_crs_course_tbl(faculty_id,course_id,course_name,course_uni_start_date,course_col_start_date,course_type_of_course,course_pattern,course_duration,user_id,curr_dt,mod_dt,del_flag,del_dt,AYID,FYID) values('" + ddl_Faculty.SelectedValue + "','" + auto_crs_id() + "','" + txtCourse.Text.Trim() + "',getdate(),getdate(),0,1,2,'Admin',getdate(),null,0,null,'" + Session["Year"] + "','fin0015')";
                        if (cls.DMLqueries(insertCourse))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Course Added Successful ','success')", true);
                            txtCourse.Text = "";
                            txtCourse.Enabled = false;
                            DataOnPageLoad();
                            ddl_Faculty.SelectedIndex = 0;
                           // DropDownList1.SelectedIndex = 0;
                            //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
                            ddl_Faculty.Enabled = true;
                            ddl_course.Items.Clear();

                        }
                    }
                    else
                    {
                        string bb = ddl_Faculty.SelectedItem.ToString();
                        //string pp = DropDownList1.SelectedItem.ToString();
                        string updatequery = "update m_crs_course_tbl set faculty_id='" + ddl_Faculty.SelectedValue + "' ,course_name='" + txtCourse.Text.Trim() + "'  where course_id='" + Session["CourseId"] + "' and del_flag='0'";
                        if (cls.DMLqueries(updatequery))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Course Updated ','success')", true);
                            DataOnPageLoad();
                            //DropDownList1.SelectedIndex = 0;
                            txtCourse.Text = "";
                            Save.Text = "Add";
                            txtCourse.Enabled = false;
                            ddl_Faculty.Enabled = true;
                            //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }

                    }
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "50px");
                //Label lblpattern = (Label)e.Row.FindControl("grdpattern");
                //if (lblpattern.Text == "1")
                //{
                //    lblpattern.Text = "Term";
                //}
                //else
                //{
                //    lblpattern.Text = "Semester";
                //}
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + d.Message + "')", true);
        }
    }
    public string auto_crs_id()
    {
        string intid = "select max(cast(substring(course_id,5,6) as int)+1)  from m_crs_course_tbl";
        return "CRS0" + cls.fillDataTable(intid).Rows[0][0].ToString();
    }
    /// <summary>
    /// Course Working
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdbutton_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Label lbl = (Label)row.FindControl("grdlblfacultyname") as Label;
            Label lblcour = (Label)row.FindControl("grdcourname") as Label;
            Label lblpattern = (Label)row.FindControl("grdpattern") as Label;
            lblcourseid = (Label)row.FindControl("grdcourseid") as Label;
            Session["CourseId"] = lblcourseid.Text;
            ddl_Faculty.SelectedValue = ddl_Faculty.Items.FindByText(lbl.Text).Value;
            ddl_Faculty.Enabled = false;
           // DropDownList1.SelectedValue = DropDownList1.Items.FindByText(lblpattern.Text).Value;
            txtCourse.Text = lblcour.Text.Trim();
            Save.Text = "Update";
          //  DropDownList1.Enabled = true;
            txtCourse.Enabled = true;
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    //====================subcourse=========
    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtCourse.Text = "";
          //  DropDownList1.SelectedIndex = 0;
            ddl_Faculty.SelectedIndex = 0;
            ddl_Faculty.Enabled = true;
         //   DropDownList1.Enabled = false;
            txtCourse.Enabled = false;
            Save.Text = "Add";

            //DataOnPageLoad();
            string grdquery = "SELECT m_crs_faculty.faculty_name, m_crs_faculty.faculty_id, m_crs_course_tbl.course_id,m_crs_course_tbl.course_id, m_crs_course_tbl.course_name, m_crs_course_tbl.course_pattern FROM m_crs_course_tbl INNER JOIN m_crs_faculty ON m_crs_course_tbl.faculty_id = m_crs_faculty.faculty_id where m_crs_course_tbl.del_flag='0' and m_crs_faculty.del_flag='0' ";
            DataTable dt1 = new DataTable();
            dt1 = cls.fillDataTable(grdquery);
            grd.DataSource = dt1;
            grd.DataBind();
            //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    /////////SUBCOURSE FACULTY
    protected void ddl_faculty2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
        try
        {
            if (ddl_faculty2.SelectedIndex == 0)
            {
                string querysubrs = "SELECT dbo.m_crs_faculty.faculty_id, dbo.m_crs_course_tbl.course_id, dbo.m_crs_course_tbl.course_name, dbo.m_crs_faculty.faculty_name, dbo.m_crs_subcourse_tbl.subcourse_id, dbo.m_crs_subcourse_tbl.course_id AS Expr1, dbo.m_crs_subcourse_tbl.subcourse_name FROM            dbo.m_crs_course_tbl INNER JOIN                        dbo.m_crs_faculty ON dbo.m_crs_course_tbl.faculty_id = dbo.m_crs_faculty.faculty_id INNER JOIN                         dbo.m_crs_subcourse_tbl ON dbo.m_crs_course_tbl.course_id = dbo.m_crs_subcourse_tbl.course_id where dbo.m_crs_faculty.del_flag='0' and dbo.m_crs_course_tbl.del_flag='0' and dbo.m_crs_subcourse_tbl.del_flag='0' ";
                DataTable dtSubcoures = cls.fillDataTable(querysubrs);
                grdSubCourse.DataSource = dtSubcoures;
                grdSubCourse.DataBind();
                //ddl_course.Enabled = false;
                string queryFor = "select course_id,course_name from m_crs_course_tbl where faculty_id='" + ddl_faculty2.SelectedValue.ToString() + "' and  del_flag='0'";
                DataTable dtcrs = new DataTable();
                dtcrs = cls.fillDataTable(queryFor);
                ddl_course.DataTextField = dtcrs.Columns["course_name"].ToString();
                ddl_course.DataValueField = dtcrs.Columns["course_id"].ToString();
                ddl_course.DataSource = dtcrs;
                ddl_course.DataBind();
                ddl_course.Items.Insert(0, new ListItem("--Select--", "na"));
                txtsubcourse.Text = "";
                //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                //ddl_course.Enabled = false;
                //ddl_course.SelectedIndex = 0;
                string querysubrs = "SELECT dbo.m_crs_faculty.faculty_id, dbo.m_crs_course_tbl.course_id, dbo.m_crs_course_tbl.course_name, dbo.m_crs_faculty.faculty_name, dbo.m_crs_subcourse_tbl.subcourse_id, dbo.m_crs_subcourse_tbl.course_id AS Expr1, dbo.m_crs_subcourse_tbl.subcourse_name FROM            dbo.m_crs_course_tbl INNER JOIN                        dbo.m_crs_faculty ON dbo.m_crs_course_tbl.faculty_id = dbo.m_crs_faculty.faculty_id INNER JOIN                         dbo.m_crs_subcourse_tbl ON dbo.m_crs_course_tbl.course_id = dbo.m_crs_subcourse_tbl.course_id where dbo.m_crs_faculty.del_flag='0' and dbo.m_crs_course_tbl.del_flag='0' and dbo.m_crs_subcourse_tbl.del_flag='0' ";
                DataTable dtSubcoures = cls.fillDataTable(querysubrs);
                grdSubCourse.DataSource = dtSubcoures;
                grdSubCourse.DataBind();
                ///////
                string queryFor2 = "select course_id,course_name from m_crs_course_tbl where faculty_id='" + ddl_faculty2.SelectedValue.ToString() + "' and  del_flag='0'";
                DataTable dtcrs2 = new DataTable();
                dtcrs2 = cls.fillDataTable(queryFor2);
                ddl_course.DataTextField = dtcrs2.Columns["course_name"].ToString();
                ddl_course.DataValueField = dtcrs2.Columns["course_id"].ToString();
                ddl_course.DataSource = dtcrs2;
                ddl_course.DataBind();
                ddl_course.Items.Insert(0, new ListItem("--Select--", "na"));
                //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }


    }
    ///////////////////////
    protected void ddl_course_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtsubcourse.Text = "";
        try
        {
            if (btnadd.Text != "Update")
            {
                if (ddl_course.SelectedIndex == 0)
                {
                    string querysubrs = "SELECT dbo.m_crs_faculty.faculty_id, dbo.m_crs_course_tbl.course_id, dbo.m_crs_course_tbl.course_name, dbo.m_crs_faculty.faculty_name, dbo.m_crs_subcourse_tbl.subcourse_id, dbo.m_crs_subcourse_tbl.course_id AS Expr1, dbo.m_crs_subcourse_tbl.subcourse_name FROM            dbo.m_crs_course_tbl INNER JOIN                        dbo.m_crs_faculty ON dbo.m_crs_course_tbl.faculty_id = dbo.m_crs_faculty.faculty_id INNER JOIN                         dbo.m_crs_subcourse_tbl ON dbo.m_crs_course_tbl.course_id = dbo.m_crs_subcourse_tbl.course_id where dbo.m_crs_faculty.del_flag='0' and dbo.m_crs_course_tbl.del_flag='0' and dbo.m_crs_subcourse_tbl.del_flag='0' ";
                    DataTable dtSubcoures = cls.fillDataTable(querysubrs);
                    grdSubCourse.DataSource = dtSubcoures;
                    grdSubCourse.DataBind();
                    //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    string ddlcou_grd = " SELECT dbo.m_crs_faculty.faculty_id, dbo.m_crs_course_tbl.course_id, dbo.m_crs_course_tbl.course_name, dbo.m_crs_faculty.faculty_name, dbo.m_crs_subcourse_tbl.subcourse_id, dbo.m_crs_subcourse_tbl.course_id AS Expr1, dbo.m_crs_subcourse_tbl.subcourse_name FROM            dbo.m_crs_course_tbl INNER JOIN                        dbo.m_crs_faculty ON dbo.m_crs_course_tbl.faculty_id = dbo.m_crs_faculty.faculty_id INNER JOIN                         dbo.m_crs_subcourse_tbl ON dbo.m_crs_course_tbl.course_id = dbo.m_crs_subcourse_tbl.course_id where dbo.m_crs_faculty.del_flag='0' and dbo.m_crs_course_tbl.del_flag='0' and dbo.m_crs_subcourse_tbl.del_flag='0' and  m_crs_course_tbl.course_id='" + ddl_course.SelectedValue + "' and dbo.m_crs_faculty.faculty_id='" + ddl_faculty2.SelectedValue + "'";
                    DataTable dtddlcou = new DataTable();
                    dtddlcou = cls.fillDataTable(ddlcou_grd);
                    if (dtddlcou.Rows.Count > 0)
                    {
                        grdSubCourse.DataSource = dtddlcou;
                        grdSubCourse.DataBind();
                        //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Subcourse Assigned To This Course','danger')", true);
                        grdSubCourse.DataSource = null;
                        grdSubCourse.DataBind();
                        //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    //==========groupdropdown ahet fakt
    protected void ddl_faculty3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string queryFor = "select course_id,course_name from m_crs_course_tbl where faculty_id='" + ddl_faculty3.SelectedValue.ToString() + "' and del_flag='0'";
            DataTable dtcrs = new DataTable();
            dtcrs = cls.fillDataTable(queryFor);
            ddl_course3.DataTextField = dtcrs.Columns["course_name"].ToString();
            ddl_course3.DataValueField = dtcrs.Columns["course_id"].ToString();
            ddl_course3.DataSource = dtcrs;
            ddl_course3.DataBind();
            ddl_course3.Items.Insert(0, new ListItem("--Select--", "na"));
            try
            {
                string ddlgroupquery = "select a.course_id, a.course_name,b.subcourse_name,b.subcourse_id, c.Group_title,c.Group_id, d.faculty_id,d.faculty_name from m_crs_course_tbl as a, m_crs_subcourse_tbl as b,m_crs_subjectgroup_tbl as c ,m_crs_faculty as d where a.course_id=b.course_id and b.subcourse_id=c.Subcourse_id and d.faculty_id=a.faculty_id and c.del_flag='0' and a.del_flag='0'and b.del_flag='0' ";
                DataTable dtgrpdt = cls.fillDataTable(ddlgroupquery);
                if (dtgrpdt.Rows.Count > 0)
                {
                    grdgrp.DataSource = dtgrpdt;
                    grdgrp.DataBind();
                    //grdgrp.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Group Assigned To this Subcourse','danger')", true);
                    grdgrp.DataSource = null;
                    grdgrp.DataBind();
                    //grdgrp.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //  grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                if (ddl_faculty3.SelectedIndex == 0)
                {
                    txtgroup.Text = "";
                    ddl_course.Items.Clear();
                    ddl_Subcourse.Items.Clear();

                    // ddl_Subcourse.SelectedIndex = 0;
                    // ddl_Subcourse_SelectedIndexChanged(this,EventArgs.Empty );
                }
            }
            catch (Exception d)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
            }
            //ddl_course3_SelectedIndexChanged(this, EventArgs.Empty);
            //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
            //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            //ddl_Subcourse.DataSource = null;
            //ddl_Subcourse.DataBind();
            //ddl_Subcourse.Items.Insert(0, new ListItem("--Select--", "na"));


        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    protected void ddl_course3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            

            try
            {
                string queryFor = "select subcourse_id,subcourse_name from m_crs_subcourse_tbl where course_id='" + ddl_course3.SelectedValue.ToString() + "' and del_flag='0'";
                DataTable dtsubcrs = new DataTable();
                dtsubcrs = cls.fillDataTable(queryFor);
                if (dtsubcrs.Rows.Count > 0)
                {

                    ddl_Subcourse.DataTextField = dtsubcrs.Columns["subcourse_name"].ToString();
                    ddl_Subcourse.DataValueField = dtsubcrs.Columns["subcourse_id"].ToString();
                    ddl_Subcourse.DataSource = dtsubcrs;
                    ddl_Subcourse.DataBind();
                    ddl_Subcourse.Items.Insert(0, new ListItem("--Select--", "na"));
                }
                else
                {
                    if (ddl_course3.SelectedIndex==0) 
                    {
                    
                    }
                    else {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Subcourse Assigned To this Course','danger')", true);
                    }
                  
                    //ddl_Subcourse.SelectedIndex = 0;
                    //ddl_Subcourse.Items.Clear();

                }
                string ddlgroupquery = "select a.course_id, a.course_name,b.subcourse_name,b.subcourse_id, c.Group_title,c.Group_id, d.faculty_id,d.faculty_name from m_crs_course_tbl as a, m_crs_subcourse_tbl as b,m_crs_subjectgroup_tbl as c ,m_crs_faculty as d where a.course_id=b.course_id and b.subcourse_id=c.Subcourse_id and d.faculty_id=a.faculty_id and c.del_flag='0' and a.del_flag='0'and b.del_flag='0' and  b.course_id='" + ddl_course3.SelectedValue + "' ";
                DataTable dtgrpdt = cls.fillDataTable(ddlgroupquery);
                if (dtgrpdt.Rows.Count > 0)
                {
                    grdgrp.DataSource = dtgrpdt;
                    grdgrp.DataBind();
                    //grdgrp.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
                else if (ddl_course3.SelectedIndex == 0)
                {
                    txtgroup.Text = "";
                    ddl_Subcourse.Items.Clear();

                }
                else
                {
                    if (dtgrpdt.Rows.Count < 0)
                    {

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Group Assigned To this Course','danger')", true);
                        grdgrp.DataSource = null;
                        grdgrp.DataBind();
                        ddl_course3.SelectedIndex = 0;
                    }
                    else
                    {

                    }
                    //grdgrp.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //  grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception d)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
            }
            //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
            //grdgrp.HeaderRow.TableSection = TableRowSection.TableHeader;

            //if (ddl_Subcourse.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Group Assigned To this Subcourse','danger')", true);
            //    grdgrp.DataSource = null;
            //    grdgrp.DataBind();
            //}

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    //===============groupend

    //=========subcourse startedagain
    protected void btnadd_Click(object sender, EventArgs e)
    {

        try
        {
            if (ddl_faculty2.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select faculty','danger')", true);
            }
            else if (ddl_course.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Course','danger')", true);
            }
            else if (txtsubcourse.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select SubCourse','danger')", true);
            }
            else
            {

                /////////////////////

                string chkdupli = "select  del_flag,subcourse_name from m_crs_subcourse_tbl where  del_flag='0' and subcourse_name='" + txtsubcourse.Text.Trim() + "' and course_id='" + ddl_course.SelectedValue + "'";
                DataTable dtchk = cls.fillDataTable(chkdupli);
                if (dtchk.Rows.Count > 0)
                {
                    //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Provided Subcourse Name Already Exist.','danger')", true);
                }
                else
                {
                    if (btnadd.Text == "Add")
                    {
                        string queryforsubcourse = "insert into m_crs_subcourse_tbl (course_id,subcourse_id,subcourse_name,subcourse_Total_fees,subcourse_NoOfSeats,subcourse_Remark,subcourse_NoOfStudsPerDiv,semester,user_id,curr_dt,mod_dt,del_flag,del_dt,AYID,FYID) values('" + ddl_course.SelectedValue + "','" + auto_subcrs_id() + "','" + txtsubcourse.Text.Trim() + "','','','','','','Admin',getdate(),'',0,'','" + Session["Year"] + "','FIN0045')";


                        if (cls.DMLqueries(queryforsubcourse))
                        {
                            DataOnPageLoad();
                            ddl_faculty2.SelectedIndex = 0;
                            ddl_faculty2_SelectedIndexChanged(this, EventArgs.Empty);
                            ddl_course.Items.Clear();                            //ddl_course_SelectedIndexChanged(this, EventArgs.Empty);
                            txtsubcourse.Text = "";
                            ddl_course3.Items.Clear();
                            ddl_Subcourse.Items.Clear();
                            txtgroup.Text = "";

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Subcourse Added Successfull ','success')", true);
                        }
                    }

                    else
                    {
                        ddl_faculty2.Enabled = true;
                        string subcouupdate = "update m_crs_subcourse_tbl set subcourse_name='" + txtsubcourse.Text.Trim() + "',course_id='" + ddl_course.SelectedValue + "' where subcourse_id='" + Session["grpid"] + "'";


                        if (cls.DMLqueries(subcouupdate))
                        {

                            ddl_course.SelectedIndex = 0;
                            ddl_faculty2.Enabled = true;
                            txtsubcourse.Text = "";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Subcourse Updated Successfull ','success')", true); DataOnPageLoad();
                            btnadd.Text = "Add";
                        }

                    }
                    //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + " ','danger')", true);
        }
    }
    public string auto_subcrs_id()
    {
        string SUBINT = "select max(cast(substring(subcourse_id,5,6) as int)+1)  from m_crs_subcourse_tbl";
        return "SCR0" + cls.fillDataTable(SUBINT).Rows[0][0].ToString();
    }
    protected void grdbtnview_Click(object sender, EventArgs e)
    {
    }
    protected void grdbutton_Click1(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr2 = (GridViewRow)btn.NamingContainer;
            Label grdlblfac = (Label)gvr2.FindControl("grdlblfacultyname") as Label;
            Label grdlblcour = (Label)gvr2.FindControl("grdcourname") as Label;
            Label grdlblsubcou = (Label)gvr2.FindControl("grdsubcours") as Label;
            lblgrdsubcourseID = (Label)gvr2.FindControl("grdsubcouid") as Label;
            Session["grpid"] = lblgrdsubcourseID.Text.Trim();
            ddl_faculty2.SelectedValue = ddl_faculty2.Items.FindByText(grdlblfac.Text).Value;
            ddl_faculty2_SelectedIndexChanged(this, EventArgs.Empty);
            //ddl_faculty2_SelectedIndexChanged(this, EventArgs.Empty);
            ddl_course.SelectedValue = ddl_course.Items.FindByText(grdlblcour.Text).Value;

            txtsubcourse.Text = grdlblsubcou.Text.Trim();
            btnadd.Text = "Update";
            ddl_faculty2.Enabled = false;
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + " ','danger')", true);
        }
    }

    protected void cncl_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_faculty2.SelectedIndex = 0;
            ddl_faculty2_SelectedIndexChanged(this, EventArgs.Empty);
            ddl_course.SelectedIndex = 0;
            txtsubcourse.Text = "";
            btnadd.Text = "Add";
            ddl_faculty2.Enabled = true;
            //ddl_course.Items.Clear();
            //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
            //////
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + " ','danger')", true);
        }
    }

    protected void grdbtngrupview_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton grpbtn = (LinkButton)sender;
            GridViewRow gvrgrup = (GridViewRow)grpbtn.NamingContainer;
            Label grupfacul = (Label)gvrgrup.FindControl("facultyid") as Label;
            Label coursid = (Label)gvrgrup.FindControl("courseid") as Label;
            Label grupcou = (Label)gvrgrup.FindControl("grdgrupcourse") as Label;
            Label grupsub = (Label)gvrgrup.FindControl("grdgrupsubcour") as Label;
            Label gruptitle = (Label)gvrgrup.FindControl("grdgruptitle") as Label;
            Label lblgrdgrupid = (Label)gvrgrup.FindControl("gruopid") as Label;
            Label subcouid = (Label)gvrgrup.FindControl("subcourseid") as Label;
            Session["groupid"] = lblgrdgrupid.Text.Trim();
            ddl_faculty3.SelectedValue = ddl_faculty3.Items.FindByValue(grupfacul.Text).Value;
            ddl_faculty3_SelectedIndexChanged(this, EventArgs.Empty);
            ddl_course3.SelectedValue = ddl_course3.Items.FindByValue(coursid.Text).Value;
            ddl_course3_SelectedIndexChanged(this, EventArgs.Empty);
            ddl_Subcourse.SelectedValue = ddl_Subcourse.Items.FindByValue(subcouid.Text).Value;
            // ddl_Subcourse_SelectedIndexChanged(this, EventArgs.Empty);

            // ddl_course3_SelectedIndexChanged(this, EventArgs.Empty);
            //       ddl_Subcourse.SelectedValue = ddl_Subcourse.Items.FindByText(ddl_Subcourse.Text).Value;
            txtgroup.Text = gruptitle.Text.Trim();
            btngrupadd.Text = "Update";


            ddl_faculty3.Enabled = false;
            ddl_course3.Enabled = false;

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }

    }
    protected void btngrupadd_Click(object sender, EventArgs e)
    {
        try
        {
            ////////////////////////////////////////group cha add button


            if (ddl_faculty3.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select faculty','danger')", true);

            }
            else if (ddl_course3.SelectedIndex == 0)
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Course','danger')", true);
            }
            else if (ddl_Subcourse.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Subcourse','danger')", true);

            }
            else if (txtgroup.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Add Group','danger')", true);
            }
            else////////////============================================================================================================////////////////////////
            {
                //string chkduplic = "select  Group_title from m_crs_subjectgroup_tbl where del_flag='0' and Group_title='" + txtgroup.Text + "' and  Subcourse_id='" + ddl_Subcourse.SelectedValue + "'";
                //string chkduplic = "select Group_title from m_crs_subjectgroup_tbl where del_flag=0 and Subcourse_id='" + ddl_Subcourse.SelectedValue + "'";


                //DataTable chk = cls.fillDataTable(chkduplic);
                //// if (chk.Rows.Count > 0)
                //List<string> ids = new List<string>(chk.Rows.Count);
                //foreach (DataRow row in chk.Rows)
                //{

                //    ids.Add((string)row["group_title"]);
                //}
                //if (ids.Distinct().Contains(txtgroup.Text))
                //{
                //    
                //}
                string chkdup = "select Group_title from m_crs_subjectgroup_tbl where del_flag=0 and Subcourse_id='"+ddl_Subcourse.SelectedValue+"' and Group_title='"+txtgroup.Text.Trim()+"'";
                DataTable dt = cls.fillDataTable(chkdup);
                if (dt.Rows.Count>0) 
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Provided Group Name Already Exist.','danger')", true);

                }

                else
                {
                    if (btngrupadd.Text == "Add")
                    {
                        string addgrup = "insert into m_crs_subjectgroup_tbl (Group_title,Group_id,Subcourse_id,Descritption,No_of_seats,No_of_Subject,AYID,user_id,curr_dt,mod_dt,del_flag,del_dt) values('" + txtgroup.Text.Trim() + "','" + auto_group_id() + "','" + ddl_Subcourse.SelectedValue + "','','','','" + Session["Year"] + "','Admin',GETDATE(),'','0','')";
                        if (cls.DMLqueries(addgrup))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Group Added Successfull','success')", true);
                            //DataOnPageLoad();
                            //ddl_course3.SelectedIndex = 0;
                            //ddl_Subcourse.SelectedIndex = 0;
                            //txtgroup.Text = "";   
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something Went Wrong','danger')", true);
                        }// DataTable dtgroup = new DataTable();
                        // DataOnPageLoad();
                    }
                    else
                    {
                        string grupupdate = "update m_crs_subjectgroup_tbl set Group_title='" + txtgroup.Text.Trim() + "' ,Subcourse_id='" + ddl_Subcourse.SelectedValue + "' where Group_id='" + Session["groupid"] + "' ";
                        if (cls.DMLqueries(grupupdate))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Group Updated Successfull','success')", true);
                            ddl_faculty3.Enabled = true;
                            ddl_course3.Enabled = true;
                            //ddl_course3.SelectedIndex = 0;
                            //ddl_Subcourse.SelectedIndex = 0;
                            //txtgroup.Text = "";
                            //DataOnPageLoad();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something Went Wrong','danger')", true);
                        }
                    }
                    DataOnPageLoad();
                    ddl_course3.SelectedIndex = 0;
                    ddl_course3.Items.Clear();
                    ddl_Subcourse.Items.Clear();
                    txtgroup.Text = String.Empty;

                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    public string auto_group_id()
    {
        string groupINT = "select max(cast(substring(Group_id,5,6) as int)+1)  from m_crs_subjectgroup_tbl";
        return "GRP0" + cls.fillDataTable(groupINT).Rows[0][0].ToString();
    }
    protected void btngrpcancel_Click(object sender, EventArgs e)
    {
        try
        {
            DataOnPageLoad();
            ddl_faculty3.SelectedIndex = 0;
            ddl_course3.Items.Clear();
            ddl_Subcourse.Items.Clear();
            //ddl_course3.SelectedIndex = 0;
            //ddl_Subcourse.SelectedIndex = 0;
            txtgroup.Text = "";
            btngrupadd.Text = "Add";
            ddl_faculty3.Enabled = true;
            ddl_course3.Enabled = true;

            // grdgrp.HeaderRow.TableSection = TableRowSection.TableHeader;

            //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;













        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    protected void grdbtnview_Click1(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvrgrup = (GridViewRow)btn.NamingContainer;
            //   Label grupfacul = (Label)gvrgrup.FindControl("facultyid") as Label;
            Label lblcouid = (Label)gvrgrup.FindControl("courseid") as Label;
            Label lblgruptxt = (Label)gvrgrup.FindControl("grdgruptitle") as Label;
            Label lblsubcouid = (Label)gvrgrup.FindControl("subcourseid") as Label;
            Label lblgrupid = (Label)gvrgrup.FindControl("gruopid") as Label;

            string chkqry = "select stud_id from m_std_studentacademic_tbl where group_id='" + lblgrupid.Text.Trim() + "' and  del_flag='0'";
            cls.fillDataTable(chkqry);
            DataTable dtchk = new DataTable();
            dtchk = cls.fillDataTable(chkqry);

            if (dtchk.Rows.Count == 0)
            {
                string delqury = "update m_crs_subjectgroup_tbl set del_flag=1 where Group_title='" + lblgruptxt.Text.Trim() + "' and Group_id='" + lblgrupid.Text.Trim() + "' and Subcourse_id='" + lblsubcouid.Text.Trim() + "' ";
                cls.DMLqueries(delqury);
                if (cls.DMLqueries(delqury))
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Group Deleted Successfull','success')", true);

                    //ddl_faculty3.SelectedIndex = 0;
                    //ddl_faculty3_SelectedIndexChanged(this, EventArgs.Empty);
                    //ddl_course3.SelectedIndex = 0;
                    //ddl_course3_SelectedIndexChanged(this, EventArgs.Empty);
                    //ddl_Subcourse.SelectedIndex = 0;
                    //ddl_Subcourse_SelectedIndexChanged(this, EventArgs.Empty);
                    txtgroup.Text = "";
                    btngrupadd.Text = "Add";
                    ddl_course3.Enabled = true;
                    ddl_faculty3.Enabled = true;
                    DataOnPageLoad();
                    ddl_course3.Items.Clear();
                    ddl_Subcourse.Items.Clear();



                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Deletion of group restricted','danger')", true);

            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }

    }

    protected void btnsubdel_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr3 = (GridViewRow)btn.NamingContainer;
            Label subcoutxt = (Label)gvr3.FindControl("grdsubcours") as Label;
            Label grdsubcouid = (Label)gvr3.FindControl("grdsubcouid") as Label;
            Label grdcouid = (Label)gvr3.FindControl("grdcouid") as Label;
            Label grdfac = (Label)gvr3.FindControl("grdlblfacultyname") as Label;
            string chkqry = "select count(*) as count from m_crs_subjectgroup_tbl where subcourse_id='" + grdsubcouid.Text.Trim() + "' and  del_flag='0'";
            cls.fillDataTable(chkqry);
            DataTable dtchk = new DataTable();
            dtchk = cls.fillDataTable(chkqry);
            if (dtchk.Rows[0]["count"].ToString() == "0")
            {
                string delqury = "update  m_crs_subcourse_tbl set del_flag='1' where course_id='" + grdcouid.Text.Trim() + "' and subcourse_id='" + grdsubcouid.Text.Trim() + "' and subcourse_name='" + subcoutxt.Text.Trim() + "'";
                if (cls.DMLqueries(delqury))
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Subcourse Deleted Successfull','danger')", true);
                    // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Subcourse Deleted Successfully','success')", true);
                    DataOnPageLoad();
                    ddl_faculty2.SelectedIndex = 0;
                    ddl_faculty2_SelectedIndexChanged(this, EventArgs.Empty);
                    ///////////
                    ddl_course.SelectedIndex = 0;
                    // ddl_course_SelectedIndexChanged(this,EventArgs.Empty);
                    txtsubcourse.Text = "";
                    btnadd.Text = "Add";
                    ddl_faculty2.Enabled = true;
                    //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;



                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong','danger')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Deletion Restricted because some Group are assigned to this subcourse.','danger')", true);
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    protected void grdcou_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr3 = (GridViewRow)btn.NamingContainer;
            Label coursetxt = (Label)gvr3.FindControl("grdcourname") as Label;
            Label grdcouid = (Label)gvr3.FindControl("grdcourseid") as Label;
            string chkqry = "select count(*) as count from m_crs_subcourse_tbl where course_id ='" + grdcouid.Text.Trim() + "' and  del_flag='0'";
            cls.fillDataTable(chkqry);
            DataTable dtchk = new DataTable();
            dtchk = cls.fillDataTable(chkqry);
            if (dtchk.Rows[0]["count"].ToString() == "0")
            {
                string couupdate = "update m_crs_course_tbl set del_flag='1' where course_id='" + grdcouid.Text.Trim() + "'  ";
                if (cls.DMLqueries(couupdate))
                {
                    DataOnPageLoad();
                    ddl_Faculty.SelectedIndex = 0;
                    txtCourse.Text = "";
                    //DropDownList1.SelectedIndex = 0;
                    Save.Text = "Add";


                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Course Deleted ','danger')", true);
                    //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
                    ddl_Faculty.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong','danger')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Deletion Of Course Restricted Because Some SubCourse Were Assigned To This Course','danger')", true);
            }
        }
        catch (Exception d)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    ////protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    ////{
    ////    try
    ////    {


    ////        if (Save.Text == "Add")
    ////        {
    ////            if (DropDownList1.SelectedIndex != 0)
    ////            {

    ////                txtCourse.Enabled = true;
    ////                string grdquery2 = "SELECT m_crs_faculty.faculty_name, m_crs_faculty.faculty_id, m_crs_course_tbl.course_id,m_crs_course_tbl.course_id, m_crs_course_tbl.course_name, m_crs_course_tbl.course_pattern FROM m_crs_course_tbl INNER JOIN m_crs_faculty ON m_crs_course_tbl.faculty_id = m_crs_faculty.faculty_id where m_crs_course_tbl.del_flag='0' and m_crs_faculty.del_flag='0' and course_pattern='" + DropDownList1.SelectedValue + "'";

    ////                DataTable dt12 = new DataTable();
    ////                dt12 = cls.fillDataTable(grdquery2);
    ////                if (dt12.Rows.Count > 0)
    ////                {
    ////                    grd.DataSource = dt12;
    ////                    grd.DataBind();
    ////                    //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
    ////                    //  grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
    ////                }
    ////                else
    ////                {
    ////                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Course Added To This Pattern','danger')", true);
    ////                }

    ////            }
    ////            else
    ////            {

    ////                DropDownList1.SelectedIndex = 0;
    ////                string grdquery = "SELECT m_crs_faculty.faculty_name, m_crs_faculty.faculty_id, m_crs_course_tbl.course_id,m_crs_course_tbl.course_id, m_crs_course_tbl.course_name, m_crs_course_tbl.course_pattern FROM m_crs_course_tbl INNER JOIN m_crs_faculty ON m_crs_course_tbl.faculty_id = m_crs_faculty.faculty_id where m_crs_course_tbl.del_flag='0' and m_crs_faculty.del_flag='0' ";
    ////                DataTable dt1 = new DataTable();
    ////                dt1 = cls.fillDataTable(grdquery);
    ////                grd.DataSource = dt1;
    ////                grd.DataBind();

    ////            }
    ////        }

    ////        if (DropDownList1.SelectedIndex == 0)
    ////        {
    ////            txtCourse.Text = "";
    ////        }

    ////    }
    ////    catch (Exception d)
    ////    {
    ////        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);

    ////    }


    ////}
    protected void ddl_Subcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            string ddlgroupquery = "select a.course_id, a.course_name,b.subcourse_name,b.subcourse_id, c.Group_title,c.Group_id, d.faculty_id,d.faculty_name from m_crs_course_tbl as a, m_crs_subcourse_tbl as b,m_crs_subjectgroup_tbl as c ,m_crs_faculty as d where a.course_id=b.course_id and b.subcourse_id=c.Subcourse_id and d.faculty_id=a.faculty_id and c.del_flag='0' and a.del_flag='0'and b.del_flag='0' and  b.subcourse_id='" + ddl_Subcourse.SelectedValue + "' ";
            DataTable dtgrpdt = cls.fillDataTable(ddlgroupquery);
            if (dtgrpdt.Rows.Count > 0)
            {
                grdgrp.DataSource = dtgrpdt;
                grdgrp.DataBind();
                //grdgrp.HeaderRow.TableSection = TableRowSection.TableHeader;
                //grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            else
            {
                if (ddl_Subcourse.SelectedIndex == 0)
                {
                    txtgroup.Text = "";
                    grdgrp.DataSource = null;
                    grdgrp.DataBind();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Group Assigned To this Subcourse','danger')", true);
                    grdgrp.DataSource = null;
                    grdgrp.DataBind();
                }
                //grdgrp.HeaderRow.TableSection = TableRowSection.TableHeader;
                //  grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            //if (ddl_Subcourse.SelectedIndex == 0)
            //{
            //    txtgroup.Text = "";
            //}
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    protected void ddl_Faculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtsubcourse.Text = "";
            if (ddl_Faculty.SelectedIndex != 0)
            {
                txtCourse.Text = "";
                txtCourse.Enabled = true;

                //DropDownList1.Enabled = true;
                string grdquery = "SELECT m_crs_faculty.faculty_name, m_crs_faculty.faculty_id, m_crs_course_tbl.course_id,m_crs_course_tbl.course_id, m_crs_course_tbl.course_name, m_crs_course_tbl.course_pattern FROM m_crs_course_tbl INNER JOIN m_crs_faculty ON m_crs_course_tbl.faculty_id = m_crs_faculty.faculty_id where m_crs_course_tbl.del_flag='0' and m_crs_faculty.del_flag='0' ";
                DataTable dt1 = new DataTable();
                dt1 = cls.fillDataTable(grdquery);
                grd.DataSource = dt1;
                grd.DataBind();
                //grd.HeaderRow.TableSection = TableRowSection.TableHeader; grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                txtCourse.Text = "";
                txtCourse.Enabled = false;
              //  DropDownList1.Enabled = false;
             //   DropDownList1.SelectedIndex = 0;
                string grdquery = "SELECT m_crs_faculty.faculty_name, m_crs_faculty.faculty_id, m_crs_course_tbl.course_id,m_crs_course_tbl.course_id, m_crs_course_tbl.course_name, m_crs_course_tbl.course_pattern FROM m_crs_course_tbl INNER JOIN m_crs_faculty ON m_crs_course_tbl.faculty_id = m_crs_faculty.faculty_id where m_crs_course_tbl.del_flag='0' and m_crs_faculty.del_flag='0' ";
                DataTable dt1 = new DataTable();
                dt1 = cls.fillDataTable(grdquery);
                grd.DataSource = dt1;
                grd.DataBind();
                //grd.HeaderRow.TableSection = TableRowSection.TableHeader; grdSubCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);

        }

    }

    //protected void coursetab_Click(object sender, EventArgs e)
    //{
    //coursetab.Attributes.Remove("Class");
    //coursetab.Attributes.Add("Class", "nav-link active ");
    //coursetab.Attributes.Add("aria-selected","true" );
    //home.Attributes.Remove("Class");
    //home.Attributes.Add("Class", "tab-pane fade active show");

    //SubCourse.Attributes.Remove("Class"); 
    //SubCourse.Attributes.Add("Class", "nav-link  ");
    //SubCourse.Attributes.Add("aria-selected","false" );

    //group.Attributes.Remove("Class");
    //group.Attributes.Add("Class", "nav-link  ");
    //group.Attributes.Add("aria-selected", "false");



    //group.Attributes.Add("Class", "nav-link  ");
    //SubCourse.Attributes.Add("Class", "nav-link");
    //DataOnPageLoad();
    //DropDownList1.SelectedIndex = 0;

    //}
    //protected void SubCourse_Click(object sender, EventArgs e)
    //{
    //coursetab.Attributes.Remove("Class");
    //coursetab.Attributes.Add("Class", "nav-link  ");
    //coursetab.Attributes.Add("aria-selected", "false");


    //SubCourse.Attributes.Remove("Class");
    //SubCourse.Attributes.Add("Class", "nav-link active ");
    //SubCourse.Attributes.Add("aria-selected", "true");
    //profile.Attributes.Remove("Class");
    //profile.Attributes.Add("Class", "tab-pane fade active show");

    //group.Attributes.Remove("Class");
    //group.Attributes.Add("Class", "nav-link  ");
    //group.Attributes.Add("aria-selected", "false");
    //DataOnPageLoad();
    //}
    //protected void group_Click(object sender, EventArgs e)
    //{

    //coursetab.Attributes.Remove("Class");
    //coursetab.Attributes.Add("Class", "nav-link  ");
    //coursetab.Attributes.Add("aria-selected", "false");


    //SubCourse.Attributes.Remove("Class");
    //SubCourse.Attributes.Add("Class", "nav-link  ");
    //SubCourse.Attributes.Add("aria-selected", "false");

    //group.Attributes.Remove("Class");
    //group.Attributes.Add("Class", "nav-link  active");
    //group.Attributes.Add("aria-selected", "true");
    //contact.Attributes.Remove("Class");
    //contact.Attributes.Add("Class", "tab-pane fade active show");

    //}

    [WebMethod]
    public void Coursetab()
    {


        DataOnPageLoad();
        //home.Attributes.Remove("Class"); //home is id of tab
        //home.Attributes.Add("Class", "fade show active ");
        //hometab.Attributes.Add("aria-selected", "true");
        //hometab.Attributes.Remove("Class"); // hometabe is id  of button
        //hometab.Attributes.Add("Class","nav-link active");


        // profiletab.Attributes.Remove("Class");
        // profiletab.Attributes.Add("aria-selected", "false");
        // profiletab.Attributes.Add("Class", "nav-link");
        // contacttab.Attributes.Remove("Class");
        // contacttab.Attributes.Add("Class", "nav-link");

        //Your Logic
    }
    [WebMethod()]
    public static void subcoutab()
    {
        //DataOnPageLoad();
        // ddl_faculty2_SelectedIndexChanged(this,null);

        //profiletab.Attributes.Remove("Class");//profiletab is button
        //profiletab.Attributes.Add("Class", "nav-link active");
        //profiletab.Attributes.Add("aria-selected", "true");
        //profile.Attributes.Remove("Class");//Profile is id of tab
        //profile.Attributes.Add("Class","fade show active");

        //home.Attributes.Remove("Class");        
        //hometab.Attributes.Add("Class","nav-link");
        //hometab.Attributes.Remove("Class");
        //hometab.Attributes.Add("aria-selected","false");

        //contacttab.Attributes.Remove("Class");
        //contacttab.Attributes.Add("Class", "nav-link");
        //contacttab.Attributes.Add("aria-selected","false");
        //contact.Attributes.Remove("Class");


    }
    public static void grouptab()
    {
        //   DataOnPageLoad();
        //txt
    }


}