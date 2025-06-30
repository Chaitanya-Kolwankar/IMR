using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_Master_Define_Intake : System.Web.UI.Page
{
    Class1 cls = new Class1();
    DataTable grd_dt = new DataTable();
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
                DataOnLoad();

            }

        }
        else
        
        {
           // Clear_Click(this, EventArgs.Empty);
            //Page.Response.Redirect(Page.Request.Url.ToString(), false);
            //Context.ApplicationInstance.CompleteRequest(); 
        }
        
       // GrdIn.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    public void DataOnLoad()
    {
        string QueryForCrs = "select course_name,course_id from m_Crs_course_tbl where del_flag=0 ";
        DataTable dt = new DataTable();
        dt = cls.fillDataTable(QueryForCrs);
        ddl_Course.DataTextField = dt.Columns["course_name"].ToString();
        ddl_Course.DataValueField = dt.Columns["course_id"].ToString();
        ddl_Course.DataSource = dt;
        ddl_Course.DataBind();
        ddl_Course.Items.Insert(0, new ListItem("--Select--", "na"));
        //SubCourseddl();

      
    }
    protected void ddl_Course_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Course.SelectedIndex != 0)
        {
            try
            {
                SubCourseddl();
                GrdIn.DataSource = null;
                GrdIn.DataBind();
            }
            catch (Exception d)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
        }
        else {
            ddl_SubCourse.DataSource = null;
            ddl_SubCourse.DataBind();
            ddl_SubCourse.Items.Clear();
            GrdIn.DataSource = null;
            GrdIn.DataBind();
        }
    }
    protected void ddl_SubCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_SubCourse.SelectedIndex != 0)
            {
                string SearchQuery = "select distinct c.Group_id,c.Group_title,a.intake from  m_crs_subjectgroup_tbl as c left JOIN m_intake as a on c.del_flag=a.del_flag and a.subcourse_id=c.Subcourse_id and  c.Group_id like '%'+a.group_id+'%' and  a.ayid='" + Session["Year"] + "' where   c.subcourse_id='" + ddl_SubCourse.SelectedValue.ToString() + "'  and c.del_flag=0     order by c.Group_title";
                grd_dt = cls.fillDataTable(SearchQuery);
                GrdIn.DataSource = grd_dt;
                GrdIn.DataBind();
                if (grd_dt.Rows.Count > 0)
                {
                    GrdIn.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    ddl_SubCourse.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('No Group Assigned to This Sub Course', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
            }
            else 
            {
                GrdIn.DataSource = null;
                GrdIn.DataBind();
            
            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        }
    }

    public void SubCourseddl()
    {
        string QueryForSubCrs = "select subcourse_id,subcourse_name from m_crs_subcourse_tbl where course_id='" + ddl_Course.SelectedValue + "' and  del_flag=0";
        DataTable dt = new DataTable();
        dt = cls.fillDataTable(QueryForSubCrs);
        if (dt.Rows.Count > 0)
        {
            ddl_SubCourse.DataTextField = dt.Columns["subcourse_name"].ToString();
            ddl_SubCourse.DataValueField = dt.Columns["subcourse_id"].ToString();
            ddl_SubCourse.DataSource = dt;
            ddl_SubCourse.DataBind();
            ddl_SubCourse.Items.Insert(0, new ListItem("--Select--", "na"));
        }
        else {
            ddl_SubCourse.DataSource = null;
            ddl_SubCourse.DataBind();
            ddl_SubCourse.Items.Clear();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('No Subcourse available', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
      
       
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            bool chec=false;
            if (ddl_Course.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select Course', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (ddl_SubCourse.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select Subcourse', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else
            {

                

                

                bool value=false;
                if (GrdIn.Rows.Count != 0)
                {
                    for (int i = 0; i < GrdIn.Rows.Count; i++)
                    {

                        string IntakeText = ((TextBox)GrdIn.Rows[i].FindControl("chk_IsCurrent")).Text.ToString().Trim();
                        string GroupId = ((Label)GrdIn.Rows[i].FindControl("GroupId")).Text.ToString().Trim();
                        string groupname = ((Label)GrdIn.Rows[i].FindControl("lblDuration")).Text.ToString().Trim();
                        if (IntakeText == "")
                        {
                            IntakeText = "0";
                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Intake for " + groupname + " is not valid.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                            //return;
                            GrdIn.HeaderRow.TableSection = TableRowSection.TableHeader;

                        }
                        //else
                        //{
                            string chkdefine = "select COUNT(*) as cou from d_adm_applicant a, m_std_studentacademic_tbl m where m.stud_id=a.stud_id and m.group_id = '" + GroupId + "' and m.del_flag=0 and a.Del_Flag=0 and a.ACDID='" + Session["Year"] + "'  ";
                            DataTable define = cls.fillDataTable(chkdefine);
                            string seatno = define.Rows[0]["cou"].ToString();
                            int a = Convert.ToInt32(seatno);
                            int b = (Convert.ToInt32(IntakeText));
                            if (a > b)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('intake should be greater than Previous intake defined for " + groupname + "', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                                ((TextBox)GrdIn.Rows[i].FindControl("chk_IsCurrent")).Text = a.ToString();

                                return;
                            }
                            else
                            {
                                DataTable dt = new DataTable();
                                dt = cls.fillDataTable("select * from m_intake where group_id='" + GroupId + "' and ayid='" + Session["Year"] + "' and subcourse_id='" + ddl_SubCourse.SelectedValue.ToString() + "' and  del_flag=0");

                                if (IntakeText.ToString() != "")
                                {
                                    if (dt.Rows.Count > 0)
                                    {

                                        value = false;
                                        if (IntakeText != "" )
                                        {
                                            //string finalGrp = qryCls.splitGrp(Convert.ToString(HttpContext.Current.Session["group_ids"]));
                                            String insqry = "update m_intake set intake='" + IntakeText + "',mod_dt=getdate(),user_id='" + Session["Emp_id"] + "' where subcourse_id='" + ddl_SubCourse.SelectedValue.ToString() + "' and group_id='" + GroupId + "' and ayid='" + Session["Year"] + "'";
                                            value = cls.DMLqueries(insqry);
                                            if (cls.DMLqueries(insqry))
                                            {
                                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Intake Defined', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                                                chec = true;
                                                GrdIn.HeaderRow.TableSection = TableRowSection.TableHeader;

                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Intake failed', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                                                GrdIn.DataSource = null;
                                                GrdIn.DataBind();
                                                ddl_SubCourse.Items.Clear();
                                                ddl_Course.SelectedIndex = 0;
                                            }

                                        }
                                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Intake Updated Successful','success')", true);
                                        GrdIn.HeaderRow.TableSection = TableRowSection.TableHeader;
                                    }
                                    else
                                    {
                                        value = false;
                                        if (IntakeText != "" )
                                        {
                                            //string finalGrp = qryCls.splitGrp(Convert.ToString(HttpContext.Current.Session["group_ids"]));
                                            String insqry = "insert into m_intake values('" + Session["Year"] + "','" + ddl_SubCourse.SelectedValue.ToString() + "'," + IntakeText + ",'" + GroupId + "','" + Session["Emp_id"] + "',getdate(),null,0)";
                                            value = cls.DMLqueries(insqry);
                                        if (cls.DMLqueries(insqry)==false)                                        
                                        {
                                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Intake failed', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                                        }

                                            // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Intake Added Successful','success')", true);
                                        }
                                        GrdIn.HeaderRow.TableSection = TableRowSection.TableHeader;
                                    }

                                }
                                else
                                {
                                    if (IntakeText.ToString() != "" )
                                    {
                                        IntakeText = "0";
                                        value = false;
                                        if (IntakeText != "")
                                        {
                                            //string finalGrp = qryCls.splitGrp(Convert.ToString(HttpContext.Current.Session["group_ids"]));
                                            String insqry = "insert into m_intake values('" + Session["Year"] + "','" + ddl_SubCourse.SelectedValue.ToString() + "','" + IntakeText + "','" + GroupId + "','" + Session["Emp_id"] + "',getdate(),null,0)";
                                            value = cls.DMLqueries(insqry);

                                        }
                                        else
                                        {
                                            String insqry = "update m_intake set intake='" + IntakeText + "',mod_dt=getdate(),user_id='" + Session["Emp_id"] + "' where subcourse_id='" + ddl_SubCourse.SelectedValue.ToString() + "' and group_id='" + GroupId + "' and ayid='" + Session["Year"] + "'";
                                            value = cls.DMLqueries(insqry);
                                        }
                                        GrdIn.HeaderRow.TableSection = TableRowSection.TableHeader;

                                    }
                                    else
                                    {
                                        ((TextBox)GrdIn.Rows[i].FindControl("chk_IsCurrent")).Text = "";
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Intake should be greater than zero.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);


                                    }
                                }


                           // }


                        }
                    }

                    //GrdIn.DataSource = null;
                    //GrdIn.DataBind();
                    //ddl_Course.SelectedIndex = 0;
                    //ddl_SubCourse.Items.Clear();

                    //if (value) {

                   // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Intake Defined', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                   
                }
                //}
            }        //DataTable dt = new DataTable();
          
        }catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        }
    }
    protected void Clear_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_SubCourse.DataSource = null;
            ddl_SubCourse.DataBind();
            ddl_SubCourse.Items.Clear();
            GrdIn.DataSource = null;
            GrdIn.DataBind();
            DataOnLoad();
        }
        catch (Exception d) 
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        }
    }
    protected void GrdIn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //add the thead and tbody section programatically
            e.Row.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void chk_IsCurrent_TextChanged(object sender, EventArgs e)
    {
       
        

        
        

    }
}