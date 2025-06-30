using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class Portals_Staff_Admission_AssignRollNo : System.Web.UI.Page
{
    ArrayList arraylist = new ArrayList();
    ArrayList intersectfound = new ArrayList();
    ArrayList arraylistcomp = new ArrayList();
    ArrayList secondarray = new ArrayList();
    DataTable dt6 = new DataTable();
    string id;
    //int i;
    Class1 obj = new Class1();
    bool rtrn;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ddlCoursename.Attributes.Add("disabled", "disabled");
            ddlsubcour.Attributes.Add("disabled", "disabled");
            ddlgrup.Attributes.Add("disabled", "disabled");
            txtotalstudno.Attributes.Add("disabled", "disabled");
            txtlastrollnogiven.Attributes.Add("disabled", "disabled");
            btnforbank.Attributes.Add("disabled", "disabled");
            //ddlfaculty.Attributes.Add("disabled", "disabled");
            btnsave.Attributes.Add("disabled", "disabled");
            chkgenerate.Enabled = false;
            string query1 = "select faculty_id,faculty_name from m_crs_faculty where del_flag='0'";
            obj.fillDataTable(query1);
            DataTable dt = new DataTable();
            dt = obj.fillDataTable(query1);

            ddlfaculty.DataTextField = dt.Columns["faculty_name"].ToString();
            ddlfaculty.DataValueField = dt.Columns["faculty_id"].ToString();
            ddlfaculty.DataSource = dt;
            ddlfaculty.DataBind();
            ddlfaculty.Items.Insert(0, new ListItem("--Select--", "NA"));
        }

    }

    protected void ddlfaculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlCoursename.Attributes.Remove("disabled");
            string querycoursename = "select course_id,course_name from m_crs_course_tbl where del_flag='0' and faculty_id='" + ddlfaculty.SelectedItem.Value + "'";
            obj.fillDataTable(querycoursename);
            DataTable dt1 = new DataTable();
            dt1 = obj.fillDataTable(querycoursename);
            ddlCoursename.DataTextField = dt1.Columns["course_name"].ToString();
            ddlCoursename.DataValueField = dt1.Columns["course_id"].ToString();
            ddlCoursename.DataSource = dt1;
            ddlCoursename.DataBind();
            ddlCoursename.Items.Insert(0, new ListItem("--select--", ""));
            ddlsubcour.DataSource = "";
            ddlsubcour.DataBind();
            ddlsubcour.Items.Insert(0, new ListItem("--select--", ""));
            ddlgrup.DataSource = "";
            ddlgrup.DataBind();
            ddlgrup.Items.Insert(0, new ListItem("--select--", ""));
            dataload();
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);  
        }
    }
    protected void ddlCoursename_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlgrup.SelectedIndex != 0)
            //{
                ddlsubcour.Attributes.Remove("disabled");
                string querysubcourse = "select subcourse_id,subcourse_name from m_crs_subcourse_tbl where del_flag='0' and course_id='" + ddlCoursename.SelectedItem.Value + "'";
                DataTable dt2 = obj.fillDataTable(querysubcourse);
                ddlsubcour.DataTextField = dt2.Columns["subcourse_name"].ToString();
                ddlsubcour.DataValueField = dt2.Columns["subcourse_id"].ToString();
                ddlsubcour.DataSource = dt2;
                ddlsubcour.DataBind();
                ddlsubcour.Items.Insert(0, new ListItem("--select--", ""));
                ddlgrup.DataSource = "";
                ddlgrup.DataBind();
                ddlgrup.Items.Insert(0, new ListItem("--select--", ""));
                dataload();
            //}
            //else {
            //    grd1.DataSource = null;
            //    grd1.DataBind();
            //}
        }
        catch (Exception d) 
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);  
        }
    }
    protected void ddlsubcour_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlgrup.Attributes.Remove("disabled");
            string querygroup = "select group_id,group_title from m_crs_subjectgroup_tbl where del_flag='0' and subcourse_id='" + ddlsubcour.SelectedItem.Value + "'";
            DataTable dt3 = obj.fillDataTable(querygroup);
            ddlgrup.DataTextField = dt3.Columns["group_title"].ToString();
            ddlgrup.DataValueField = dt3.Columns["group_id"].ToString();
            ddlgrup.DataSource = dt3;
            ddlgrup.DataBind();

            ddlgrup.Items.Insert(0, new ListItem("--select--", ""));
            dataload();
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);  
        }
    }
    protected void ddlgrup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlgrup.SelectedIndex != 0)
            {
                btnsave.Attributes.Remove("disabled");
                btnforbank.Attributes.Remove("disabled");
                string totalnoofstudent = "select count(*) as total,max(Roll_no) from m_std_studentacademic_tbl where group_id='" + ddlgrup.Text + "' and ayid ='" + Session["Year"] + "'";
                DataTable dt4 = new DataTable();
                dt4 = obj.fillDataTable(totalnoofstudent);

                txtotalstudno.Text = " Total no of Student :" + dt4.Rows[0]["total"].ToString();
                Session["session_Total"] = dt4.Rows[0]["total"].ToString();
                string lastgiven = "select max(cast(Roll_no as int)) as maxrollno from m_std_studentacademic_tbl where group_id='" + ddlgrup.Text + "' and ayid ='" + Session["Year"] + "'";
                DataTable dt5 = obj.fillDataTable(lastgiven);
                txtlastrollnogiven.Text = "Last roll no given:" + dt5.Rows[0]["maxrollno"].ToString();
                Session["maximum"] = dt5.Rows[0]["maxrollno"].ToString();
                if (dt5.Rows[0]["maxrollno"].ToString() == "")
                {
                    txtlastrollnogiven.Text = "Last roll no given:0";
                }
                string grdquery = "select UPPER(LEFT(m_std_personaldetails_tbl.stud_F_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_F_Name,2,LEN(m_std_personaldetails_tbl.stud_F_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_M_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_M_Name,2,LEN(m_std_personaldetails_tbl.stud_M_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_L_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_L_Name,2,LEN(m_std_personaldetails_tbl.stud_L_Name))) as studentname,m_std_studentacademic_tbl.stud_id,m_std_studentacademic_tbl.Roll_no   ,m_std_personaldetails_tbl.stud_Gender from m_std_studentacademic_tbl left join m_std_personaldetails_tbl on m_std_studentacademic_tbl.stud_id=m_std_personaldetails_tbl.stud_id where group_id='" + ddlgrup.Text + "' and ayid='" + Session["Year"] + "' order by cast(roll_no as int),stud_L_Name,stud_F_Name,stud_M_Name";
                dt6 = obj.fillDataTable(grdquery);
                if (dt6.Rows.Count != 0)
                {

                    //Session["session_dt6"] = obj.fillDataTable(grdquery);
                    grd1.DataSource = dt6;
                    grd1.DataBind();
                }
                else
                {
                    if (ddlgrup.SelectedIndex != 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Student Assign For This Group','danger')", true);
                        btnforbank.Attributes.Add("disabled", "disabled");
                        btnsave.Attributes.Add("disabled", "disabled");

                    }

                }
                ////Session["session_dt6"] = obj.fillDataTable(grdquery);
                ////grd1.DataSource = dt6;
                ////grd1.DataBind();
                foreach (GridViewRow row in grd1.Rows)
                {
                    TextBox txt_roll_no = (TextBox)row.FindControl("grdtxtroll");
                    if (txt_roll_no.Text == "")
                    {
                        rtrn = true;
                    }
                    else
                    {
                        rtrn = false;
                        break;
                    }
                }
                if (rtrn == true)
                {

                    chkgenerate.Enabled = true;
                }
                else
                {
                    chkgenerate.Enabled = false;
                }
            }
            else {
                grd1.DataSource = null;
                grd1.DataBind();
            }
        }
        catch (Exception d) 
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);  
        }//dataload();
        //  ddlgrup.Items.Insert(0, new ListItem("--select---", ""));
    }
    public void dataload()
    {
        btnsave.Attributes.Remove("disabled");
        btnforbank.Attributes.Remove("disabled");
        string totalnoofstudent = "select count(*) as total,max(Roll_no) from m_std_studentacademic_tbl where group_id='" + ddlgrup.Text + "' and ayid ='" + Session["Year"] + "'";
        DataTable dt4 = new DataTable();
        dt4 = obj.fillDataTable(totalnoofstudent);

        txtotalstudno.Text = " Total no of Student :" + dt4.Rows[0]["total"].ToString();
        Session["session_Total"] = dt4.Rows[0]["total"].ToString();
        string lastgiven = "select max(cast(Roll_no as int)) as maxrollno from m_std_studentacademic_tbl where group_id='" + ddlgrup.Text + "' and ayid ='" + Session["Year"] + "'";
        DataTable dt5 = obj.fillDataTable(lastgiven);
        txtlastrollnogiven.Text = "Last roll no given:" + dt5.Rows[0]["maxrollno"].ToString();
        Session["maximum"] = dt5.Rows[0]["maxrollno"].ToString();
        if (dt5.Rows[0]["maxrollno"].ToString() == "")
        {
            txtlastrollnogiven.Text = "Last roll no given:0";
        }
        string grdquery = "select UPPER(LEFT(m_std_personaldetails_tbl.stud_F_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_F_Name,2,LEN(m_std_personaldetails_tbl.stud_F_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_M_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_M_Name,2,LEN(m_std_personaldetails_tbl.stud_M_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_L_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_L_Name,2,LEN(m_std_personaldetails_tbl.stud_L_Name))) as studentname,m_std_studentacademic_tbl.stud_id,m_std_studentacademic_tbl.Roll_no   ,m_std_personaldetails_tbl.stud_Gender from m_std_studentacademic_tbl left join m_std_personaldetails_tbl on m_std_studentacademic_tbl.stud_id=m_std_personaldetails_tbl.stud_id where group_id='" + ddlgrup.Text + "' and ayid in (select max(AYID) from m_academic where iscurrent=1) order by cast(roll_no as int),stud_L_Name,stud_F_Name,stud_M_Name";
        dt6 = obj.fillDataTable(grdquery);
        Session["session_dt6"] = obj.fillDataTable(grdquery);
        grd1.DataSource = dt6;
        grd1.DataBind();
        foreach (GridViewRow row in grd1.Rows)
        {
            TextBox txt_roll_no = (TextBox)row.FindControl("grdtxtroll");
            if (txt_roll_no.Text == "")
            {
                rtrn = true;
            }
            else
            {
                rtrn = false;
                break;
            }
        }
        if (rtrn == true)
        {

            chkgenerate.Enabled = true;
        }
        else
        {
            chkgenerate.Enabled = false;
        }
    }
    protected void grd1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "50px");
                Label lblgender = (Label)e.Row.FindControl("grdlblgender");
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
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);  
        }
    }
    protected void chkgenerate_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            //checkbox checked
            if (chkgenerate.Checked)
            {
                string session_maximum = Session["maximum"].ToString();
                if(string.IsNullOrEmpty(session_maximum))
                {
                    session_maximum = "0";
                }
                int i = int.Parse(session_maximum) + 1;
                foreach (GridViewRow row in grd1.Rows)
                {
                    TextBox txt_roll_no = (TextBox)row.FindControl("grdtxtroll");
                    txt_roll_no.Text = i.ToString();
                    i++;
                }
            }
            else                                                                                                  //on checkbox uncheck  
            {
                int i = 1;
                foreach (GridViewRow row in grd1.Rows)
                {
                    TextBox txt_roll_no = (TextBox)row.FindControl("grdtxtroll");
                    txt_roll_no.Text = null;
                    i++;
                }
            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);  
        }
    }






    protected void btnsave_Click(object sender, EventArgs e)                                                  //save button working
    {
        try
        {
            int i = 1;
            ////string[] roll_list;
            //string[] list1 ;
            List<string> list = new List<string>();


            foreach (GridViewRow row in grd1.Rows)
            {
                TextBox Roll = (TextBox)row.FindControl("grdtxtroll");
                if (Roll.Text != "")
                {
                    list.Add(Roll.Text);
                }
                //list1=list.ToArray();
            }
            if (list.Distinct().Count() != list.Count())
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Enter Unique Value ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else
            {
                // if(){}
                ////}
                ////=======





                if (ddlfaculty.SelectedItem.ToString() == "--select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select Faculty  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
                else if (ddlCoursename.SelectedItem.ToString() == "--select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select course  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
                else if (ddlsubcour.SelectedItem.ToString() == "--select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select Sub course  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
                else if (ddlgrup.SelectedItem.ToString() == "--select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select Group  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
                else
                {
                    string ddlgrp_text = ddlgrup.SelectedValue.ToString();
                    foreach (GridViewRow row in grd1.Rows)
                    {
                        Label girdlabel = (Label)row.FindControl("grdlbltsudid");/////////////
                        TextBox txtroll = (TextBox)row.FindControl("grdtxtroll");/////////////
                        

                        string generatequery = "update m_std_studentacademic_tbl set Roll_no='" + txtroll.Text.Trim() + "' where ayid='" + Session["Year"] + "'   and stud_id= '" + girdlabel.Text + "' and group_id='" + ddlgrp_text + "' ";
                        //if (ddlgrup.Text != "")
                        //{
                        DataTable dt9 = new DataTable();
                        obj.DMLqueries(generatequery);
                        if (obj.DMLqueries(generatequery))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Roll No. Updated Successfully', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                            grd1.DataSource = dt9;
                            grd1.DataBind();
                            ddlfaculty.SelectedIndex = 0;
                            ddlCoursename.SelectedIndex = 0;
                            ddlsubcour.SelectedIndex = 0;
                            ddlgrup.SelectedIndex = 0;
                            txtotalstudno.Enabled = false;
                            chkgenerate.Checked = false;
                            txtlastrollnogiven.Text = "Last roll no given:0";
                            txtotalstudno.Text = "Total no of Student :0";
                        }
                        else 
                        {
                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong','danger')", true);
                        }
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong','danger')", true);
                        //}

                        

                        //}
                        //else if (ddlCoursename.Text !="")
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select subCourse Name  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                        //}
                        //else if(ddlsubcour.Text != "")
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select course  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                        //}
                        //else 
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Kindly Select Group  ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                        //}





                    }
                    //dataload();
                }

            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);  
        }
    }






    protected void btnforbank_Click(object sender, EventArgs e)                                           //for blank button working
    {
        try
        {
            string forbankquery = " select UPPER(LEFT(p.stud_F_Name,1))+LOWER(SUBSTRING(p.stud_F_Name,2,LEN(p.stud_F_Name)))+' '+UPPER(LEFT(p.stud_M_Name,1))+LOWER(SUBSTRING(p.stud_M_Name,2,LEN(p.stud_M_Name)))+' '+UPPER(LEFT(p.stud_L_Name,1))+LOWER(SUBSTRING(p.stud_L_Name,2,LEN(p.stud_L_Name))) as [studentname], s.stud_id,s.Roll_no,p.stud_Gender from m_std_personaldetails_tbl as p, m_std_studentacademic_tbl as s where p.stud_id=s.stud_id and s.ayid = '" + Session["Year"] + "' and s.group_id = '" + ddlgrup.Text + "' and isnull(s.Roll_no,'') = '' order by [studentname]";
           // string forbankquery = "select UPPER(LEFT(m_std_personaldetails_tbl.stud_F_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_F_Name,2,LEN(m_std_personaldetails_tbl.stud_F_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_M_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_M_Name,2,LEN(m_std_personaldetails_tbl.stud_M_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_L_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_L_Name,2,LEN(m_std_personaldetails_tbl.stud_L_Name))) as studentname,m_std_studentacademic_tbl.stud_id,m_std_studentacademic_tbl.Roll_no   ,m_std_personaldetails_tbl.stud_Gender from m_std_studentacademic_tbl left join m_std_personaldetails_tbl on m_std_studentacademic_tbl.stud_id=m_std_personaldetails_tbl.stud_id where group_id='" + ddlgrup.Text + "' and ayid='" + Session["Year"] + "' and Roll_no=null or Roll_no = '' order by stud_L_Name,stud_F_Name,stud_M_Name";

            //string forbankquery = "select UPPER(LEFT(m_std_personaldetails_tbl.stud_F_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_F_Name,2,LEN(m_std_personaldetails_tbl.stud_F_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_M_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_M_Name,2,LEN(m_std_personaldetails_tbl.stud_M_Name)))+' '+UPPER(LEFT(m_std_personaldetails_tbl.stud_L_Name,1))+LOWER(SUBSTRING(m_std_personaldetails_tbl.stud_L_Name,2,LEN(m_std_personaldetails_tbl.stud_L_Name))) as studentname,m_std_studentacademic_tbl.stud_id,m_std_studentacademic_tbl.Roll_no   ,m_std_personaldetails_tbl.stud_Gender from m_std_studentacademic_tbl left join m_std_personaldetails_tbl on m_std_studentacademic_tbl.stud_id=m_std_personaldetails_tbl.stud_id where group_id='" + ddlgrup.Text + "' and ayid='"+Session["Year"]+"' and Roll_no = '' order by stud_L_Name,stud_F_Name,stud_M_Name";
            DataTable dt6 = new DataTable();
            obj.fillDataTable(forbankquery);
            dt6 = obj.fillDataTable(forbankquery);

            if (dt6.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('All Roll No. Already Given ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else
            {
                grd1.DataSource = dt6;
                grd1.DataBind();
                chkgenerate.Enabled = true;
            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);  
        }
    }



   

   // public override void VerifyRenderingInServerForm(Control control)
   // {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
   // }
   
    ////protected void grd1_SelectedIndexChanged(object sender, EventArgs e)
    ////{
    ////    //  grd1 = ScrollBars.None;

    ////} 
    protected void btncncl_Click(object sender, EventArgs e)
    {
        ddlfaculty.SelectedIndex = 0;
        ddlfaculty_SelectedIndexChanged(this, EventArgs.Empty);        
        ddlCoursename_SelectedIndexChanged(this,EventArgs.Empty);
        ddlsubcour_SelectedIndexChanged(this, EventArgs.Empty);
        ddlgrup_SelectedIndexChanged(this,EventArgs.Empty);
       // txtotalstudno.Text = "";
       // txtlastrollnogiven.Text = "";

    }
}




