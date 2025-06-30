using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Pre_Admission_student_eligibility : System.Web.UI.Page
{
    string a = "";
    Class1 cls = new Class1();
    string fromyear;
    string is_select;
    string sub_frmyear = "";

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
                fromyear = Session["Year"].ToString();
                int y;
                y = fromyear.IndexOf("0");
                string sub_frmyear = fromyear.Substring(5);
                toyear();
                course();
                btn_stud_search.Enabled = true;
                txtstudid.Enabled = false;
                btnsave.Enabled = false;
                DataTable dttogrup = cls.fillDataTable("select  Group_title,Group_id from m_crs_subjectgroup_tbl where Subcourse_id in(select Subcourse_id from m_crs_subcourse_tbl WHERE course_id IN (SELECT course_id from m_crs_course_tbl where course_id='" + ddlcourse.SelectedValue.ToString() + "' and del_flag=0)) and del_flag=0");
                lsttogrp.DataTextField = dttogrup.Columns["Group_title"].ToString();
                lsttogrp.DataValueField = dttogrup.Columns["Group_id"].ToString();
                lsttogrp.DataSource = dttogrup;
                lsttogrp.DataBind();
                if (ddlfrmgrp.SelectedIndex == 0)
                {
                    lsttogrp.Items.Clear();
                    lsttogrp.DataSource = null;
                    lsttogrp.DataBind();
                }


            }
        }
        fromyear = Session["Year"].ToString();
        ddltoyear.Items.Remove(ddltoyear.Items.FindByValue(fromyear));
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);

    }
    public void toyear()
    {
        fromyear = Session["Year"].ToString();
        string c = fromyear.Substring(5);
        int y;
        y = fromyear.IndexOf("0");
        string sub_frmyear = fromyear.Substring(5);

        string toyear = "SELECT SUBSTRING(AYID,6,7) as dear,AYID,Duration FROM m_academic where  SUBSTRING(AYID,6,7) > '" + sub_frmyear + "'  order by AYID desc ";
        // string toyear = "select Duration,AYID from m_academic  order by Duration desc";
        cls.fillDataTable(toyear);
        DataTable dt = new DataTable();
        dt = cls.fillDataTable(toyear);
        ddltoyear.DataTextField = dt.Columns["Duration"].ToString();
        ddltoyear.DataValueField = dt.Columns["AYID"].ToString();
        ddltoyear.DataSource = dt;
        ddltoyear.DataBind();
        ddltoyear.Items.Insert(0, new ListItem("--Select--", "NA"));
        DropDownList ddlMaster = (DropDownList)Master.FindControl("ddlyear");
        string masteyer = ddlMaster.SelectedValue.ToString();

        ddltoyear.Items.Remove(ddltoyear.Items.FindByValue(masteyer));
        //string masteyer=Session["Year"].ToString();
        //string removeitemddl = ddltoyear.SelectedValue.ToString();
        //ListItem value = ddltoyear.SelectedItem;
        //if(masteyer.ToString()==ddltoyear.SelectedValue.ToString())
        //{
        //    ddltoyear.Items.Remove("value");

        //}


    }
    public void course()
    {
        DataTable dtcou = cls.fillDataTable("select course_id,course_name from m_crs_course_tbl where del_flag=0");
        ddlcourse.DataTextField = dtcou.Columns["course_name"].ToString();
        ddlcourse.DataValueField = dtcou.Columns["course_id"].ToString();
        ddlcourse.DataSource = dtcou;
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, new ListItem("--Select--", "NA"));
        //DropDownList chkddl=(DropDownList)ContentPlaceHolder1.FindControl();


        if (ddlcourse.SelectedIndex == 0)
        {
            grd1.DataSource = null;
            grd1.DataBind();
            ddlfrmgrp.Items.Clear();
        }
    }

    public void subfun()
    {
        DataTable dtfrmgroup = cls.fillDataTable("SELECT Group_id,Group_title FROM m_crs_subjectgroup_tbl WHERE Subcourse_id='" + ddlsubcou.SelectedValue.ToString() + "' and del_flag=0");
        if (dtfrmgroup.Rows.Count > 0)
        {
            ddlfrmgrp.DataTextField = dtfrmgroup.Columns["Group_title"].ToString();
            ddlfrmgrp.DataValueField = dtfrmgroup.Columns["Group_id"].ToString();
            ddlfrmgrp.DataSource = dtfrmgroup;
            ddlfrmgrp.DataBind();
            ddlfrmgrp.Items.Insert(0, new ListItem("--Select--", "NA"));
        }
        else 
        {
            if (ddlsubcou.SelectedIndex == 0)
            {
                ddltoyear.SelectedIndex = 0;
                lsttogrp.Items.Clear();
                lsttogrp.DataSource = null;
                lsttogrp.DataBind();
                ddlfrmgrp.Items.Clear();



            }
            else 
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Group Assigned to this Subcourse.','danger')", true);
                ddlsubcou.SelectedIndex = 0;
            }
        
        
        }
        
    }
    public void course_selectedindexchanged()
    {
        DataTable dtsubcou = cls.fillDataTable("select subcourse_id,subcourse_name from m_crs_subcourse_tbl where course_id='" + ddlcourse.SelectedValue.ToString() + "' and del_flag=0");
        if (dtsubcou.Rows.Count > 0)
        {
            ddlsubcou.DataTextField = dtsubcou.Columns["subcourse_name"].ToString();
            ddlsubcou.DataValueField = dtsubcou.Columns["subcourse_id"].ToString();
            ddlsubcou.DataSource = dtsubcou;
            ddlsubcou.DataBind();
            ddlsubcou.Items.Insert(0, new ListItem("--Select--", "NA"));

        }
       else
        {
            if (ddlcourse.SelectedIndex == 0)
            {
                grd1.DataSource = null;
                grd1.DataBind();
                ddlfrmgrp.Items.Clear();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('no Subcourse to this course.','danger')", true);

                ddlsubcou.Items.Clear();
            }
        }
      
       
    }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            course_selectedindexchanged();
            if (ddlcourse.SelectedIndex == 0)
            {
                ddlfrmgrp.Items.Clear();
                ddlsubcou.Items.Clear();
                lsttogrp.Items.Clear();
                lsttogrp.DataSource = null;
                lsttogrp.DataBind();
                grd1.DataSource = null;
                grd1.DataBind();
                ddltoyear.SelectedIndex = 0;
                btnsave.Enabled = false;
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }


    protected void ddlsubcou_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            subfun();
            if (ddlsubcou.SelectedIndex == 0)
            {
                grd1.DataSource = null;
                grd1.DataBind();
                lsttogrp.Items.Clear();
                lsttogrp.DataSource = null;
                lsttogrp.DataBind();
                ddltoyear.SelectedIndex = 0;
                ddlfrmgrp.Items.Clear();
                btnsave.Enabled = false;


            }
            //DataTable dtfrmgroup = cls.fillDataTable("SELECT Group_id,Group_title FROM m_crs_subjectgroup_tbl WHERE Subcourse_id='"+ddlsubcou.SelectedValue.ToString()+"' and del_flag=0");
            //ddlfrmgrp.DataTextField = dtfrmgroup.Columns["Group_title"].ToString();
            //ddlfrmgrp.DataValueField = dtfrmgroup.Columns["Group_id"].ToString();
            //ddlfrmgrp.DataSource = dtfrmgroup;
            //ddlfrmgrp.DataBind();
            //ddlfrmgrp.Items.Insert(0, new ListItem("--Select--", "NA"));
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);

        }

    }




    protected void ddlfrmgrp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //string togrp = "select  Group_title,Group_id from m_crs_subjectgroup_tbl where Subcourse_id in(select Subcourse_id from m_crs_subcourse_tbl WHERE course_id IN (SELECT course_id from m_crs_course_tbl where course_id='" + ddlcourse.SelectedValue.ToString() + "' and del_flag=0)) and del_flag=0";
            DataTable dttogrup = cls.fillDataTable("select  Group_title,Group_id from m_crs_subjectgroup_tbl where Subcourse_id in(select Subcourse_id from m_crs_subcourse_tbl WHERE course_id IN (SELECT course_id from m_crs_course_tbl where course_id='" + ddlcourse.SelectedValue.ToString() + "' and del_flag=0)) and del_flag=0");
            lsttogrp.DataTextField = dttogrup.Columns["Group_title"].ToString();
            lsttogrp.DataValueField = dttogrup.Columns["Group_id"].ToString();
            lsttogrp.DataSource = dttogrup;
            lsttogrp.DataBind();
            if (ddlfrmgrp.SelectedIndex == 0)
            {
                lsttogrp.Items.Clear();
                lsttogrp.DataSource = null;
                lsttogrp.DataBind();
                grd1.DataSource = null;
                grd1.DataBind();
                ddltoyear.SelectedIndex = 0;
                btnsave.Enabled = false;

            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    public void chk_toyear_togrup()
    {

    }

    protected void chk_search_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_search.Checked)
            {
                ddlfrmgrp.Items.Clear();
                ddlfrmgrp.Enabled = false;
                ddlsubcou.Items.Clear();
                ddlsubcou.Enabled = false;
                ddlcourse.SelectedIndex = 0;
                ddlcourse.Enabled = false;
                txtstudid.Enabled = true;
                ddltoyear.SelectedIndex = 0;
                grd1.DataSource = null;
                grd1.DataBind();
                lsttogrp.Items.Clear();
                lsttogrp.DataSource = null;
                lsttogrp.DataBind();
                btnsave.Enabled = false;
            }
            else
            {
                //unchecked 
                ddlsubcou.Items.Clear();
                course();
                ddlcourse.Enabled = true;
                ddlsubcou.Enabled = true;
                ddlfrmgrp.Enabled = true;
                txtstudid.Text = "";
                txtstudid.Enabled = false;
                ddltoyear.SelectedIndex = 0;
                grd1.DataSource = null;
                grd1.DataBind();
                lsttogrp.Items.Clear();
                lsttogrp.DataSource = null;
                lsttogrp.DataBind();
                btnsave.Enabled = false;
            }
        }
        catch (Exception d)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    protected void btn_stud_search_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < lsttogrp.Items.Count; i++)
            {
                if (lsttogrp.Items[i].Selected)
                {
                    if (a == "")
                    {
                        a = "" + lsttogrp.Items[i].Value + "";

                    }
                    else
                    {

                        a = a + "," + lsttogrp.Items[i].Value + "";
                    }
                }
            }

            is_select = "";
            for (int i = 0; i < lsttogrp.Items.Count; i++)
            {
                if (lsttogrp.Items[i].Selected)
                {
                    is_select = "true";
                }

            }

            if (chk_search.Checked)
            {
                if (txtstudid.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID','danger')", true);
                    // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID','danger')", true);
                }
                //else if(ddltoyear.SelectedIndex==0)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To Year.','danger')", true);

                //}
                else
                {


                    fromyear = Session["Year"].ToString();
                    string studid_search = "select distinct UPPER(LEFT(p.stud_F_Name,1))+LOWER(SUBSTRING(p.stud_F_Name,2,LEN(p.stud_F_Name)))+' '+UPPER(LEFT(p.stud_M_Name,1))+LOWER(SUBSTRING(p.stud_M_Name,2,LEN(p.stud_M_Name)))+' '+ UPPER(LEFT(p.stud_L_Name,1))+LOWER(SUBSTRING(p.stud_L_Name,2,LEN(p.stud_L_Name)))as studname, m.stud_id,AYD.AYID,m.Roll_no,m.subcourse_Id,c.course_id,c.course_name,s.subcourse_id,s.subcourse_name,m.group_id,g.Group_title from m_std_studentacademic_tbl as m,m_crs_course_tbl as c,m_std_personaldetails_tbl as p,m_academic as ayd,m_crs_subcourse_tbl as s,m_crs_subjectgroup_tbl as g where m.stud_id=p.stud_id and m.stud_id='" + txtstudid.Text.Trim() + "' and ayd.AYID='" + fromyear + "' and c.course_id=s.course_id and m.subcourse_Id=s.subcourse_id and g.Group_id=m.group_id order by m.Roll_no,studname asc";
                    DataTable dtstudid = new DataTable();
                    dtstudid = cls.fillDataTable(studid_search);
                    if (dtstudid.Rows.Count > 0)
                    {
                        btnsave.Enabled = true;
                        grd1.DataSource = dtstudid;
                        grd1.DataBind();



                        DataTable dtcou = cls.fillDataTable("select course_id,course_name from m_crs_course_tbl where del_flag=0");
                        ddlcourse.DataTextField = dtcou.Columns["course_name"].ToString();
                        ddlcourse.DataValueField = dtcou.Columns["course_id"].ToString();
                        ddlcourse.DataSource = dtcou;
                        ddlcourse.DataBind();
                        string b = dtstudid.Rows[0]["course_name"].ToString();
                        ddlcourse.SelectedItem.Text = b;


                        DataTable dtsubcou = cls.fillDataTable("select subcourse_id,subcourse_name from m_crs_subcourse_tbl where course_id='" + ddlcourse.SelectedValue.ToString() + "' and del_flag=0");
                        ddlsubcou.DataTextField = dtsubcou.Columns["subcourse_name"].ToString();
                        ddlsubcou.DataValueField = dtsubcou.Columns["subcourse_id"].ToString();
                        ddlsubcou.DataSource = dtsubcou;
                        ddlsubcou.DataBind();


                        DataTable dtfrmgroup = cls.fillDataTable("SELECT Group_id,Group_title FROM m_crs_subjectgroup_tbl WHERE Subcourse_id='" + ddlsubcou.SelectedValue.ToString() + "' and del_flag=0");
                        ddlfrmgrp.DataTextField = dtfrmgroup.Columns["Group_title"].ToString();
                        ddlfrmgrp.DataValueField = dtfrmgroup.Columns["Group_id"].ToString();
                        ddlfrmgrp.DataSource = dtfrmgroup;
                        ddlfrmgrp.DataBind();

                        if (a == "")
                        {


                            DataTable dttogrup = cls.fillDataTable("select  Group_title,Group_id from m_crs_subjectgroup_tbl where Subcourse_id in(select Subcourse_id from m_crs_subcourse_tbl WHERE course_id IN (SELECT course_id from m_crs_course_tbl where course_id='" + ddlcourse.SelectedValue.ToString() + "' and del_flag=0)) and del_flag=0");
                            lsttogrp.DataTextField = dttogrup.Columns["Group_title"].ToString();
                            lsttogrp.DataValueField = dttogrup.Columns["Group_id"].ToString();
                            lsttogrp.DataSource = dttogrup;
                            lsttogrp.DataBind();
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Student ID.','danger')", true);
                        txtstudid.Text = "";

                        //ddlcourse.Enabled = true;

                    }
                }
            }
            else
            {
                if (ddlcourse.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Course.','danger')", true);
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Course')", true);
                }

                else if (ddlsubcou.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Subcourse.','danger')", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select SubCourse')", true);
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Course')", true);
                }
                else if (ddlfrmgrp.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select From Group','danger')", true);
                    //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select From Group')", true);
                    // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select SubCourse')", true);
                }
                else if (is_select.ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To Group','danger')", true);
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select From Group')", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select To Group')", true);
                }
                else if (ddltoyear.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To Year','danger')", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select To Year')", true);
                }

                else
                {
                    fromyear = Session["Year"].ToString();
                    string getdataqury = "select  UPPER(LEFT(p.stud_F_Name,1))+LOWER(SUBSTRING(p.stud_F_Name,2,LEN(p.stud_F_Name)))+' '+UPPER(LEFT(p.stud_M_Name,1))+LOWER(SUBSTRING(p.stud_M_Name,2,LEN(p.stud_M_Name)))+' '+ UPPER(LEFT(p.stud_L_Name,1))+LOWER(SUBSTRING(p.stud_L_Name,2,LEN(p.stud_L_Name)))as studname,m.Roll_no,m.stud_id,m.ayid,c.course_id,c.course_name,m.group_id,g.Group_title,s.subcourse_name,m.subcourse_Id from m_std_personaldetails_tbl as p,m_std_studentacademic_tbl as m,m_crs_course_tbl as c,m_academic as ayd,m_crs_subcourse_tbl as s,m_crs_subjectgroup_tbl as g where m.stud_id=p.stud_id and ayd.ayid='" + fromyear + "' and m.ayid=ayd.AYID and  c.course_id=s.course_id and g.Group_id=m.group_id and s.subcourse_id=m.subcourse_Id  and c.course_id='" + ddlcourse.SelectedValue.ToString() + "' and m.subcourse_Id='" + ddlsubcou.SelectedValue.ToString() + "' and m.group_id='" + ddlfrmgrp.SelectedValue.ToString() + "'  order by cast(m.Roll_no as int) asc";
                    DataTable dt2 = new DataTable();
                    dt2 = cls.fillDataTable(getdataqury);
                    if (dt2.Rows.Count > 0)
                    {
                        grd1.DataSource = dt2;
                        grd1.DataBind();
                        btnsave.Enabled = true;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('NO STUDENT FOR THIS SELECTION','danger')", true);
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('NO STUDENT FOR THIS SELECTION')", true);
                        grd1.DataSource = null;
                        grd1.DataBind();
                        ddlfrmgrp.Items.Clear();
                        ddlsubcou.Items.Clear();
                        ddlcourse.SelectedIndex = 0;
                        btnsave.Enabled = false;
                       
                    }
                }


            }

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    protected void grd1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            is_select = "";
            for (int i = 0; i < lsttogrp.Items.Count; i++)
            {
                if (lsttogrp.Items[i].Selected)
                {
                    is_select = "true";
                }

            }

            //if(ddltoyear.SelectedIndex==0)
            //{
            //       ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To Year.','danger')", true);
            //       return;
            //}
            //else if (is_select.ToString() == "")
            //{
            //   // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To Group.','danger')", true);
            //    //return;
            //}
            // else
            // {
            foreach (GridViewRow row in grd1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (row.FindControl("grdchk") as CheckBox);
                    Label lbl_grd_studi = (row.FindControl("gridlblStudid") as Label);

                    string chk_chked_ontogroupSelection = "select is_eligible,Stud_id from www_Eligibility where stud_id='" + lbl_grd_studi.Text + "' and Group_id='" + ddlfrmgrp.SelectedValue.ToString() + "' and to_group_id='" + a + "' and del_flag='0'";
                    //  string chk_chked_ontogroupSelection = "  select  UPPER(LEFT(p.stud_F_Name,1))+LOWER(SUBSTRING(p.stud_F_Name,2,LEN(p.stud_F_Name)))+' '+UPPER(LEFT(p.stud_M_Name,1))+LOWER(SUBSTRING(p.stud_M_Name,2,LEN(p.stud_M_Name)))+' '+ UPPER(LEFT(p.stud_L_Name,1))+LOWER(SUBSTRING(p.stud_L_Name,2,LEN(p.stud_L_Name)))as studname,m.Roll_no,m.stud_id,m.ayid,c.course_id,c.course_name,m.group_id,g.Group_title,s.subcourse_name,m.subcourse_Id,E.to_group_id as Elig_togroupid,E.is_eligible from m_std_personaldetails_tbl as p,m_std_studentacademic_tbl as m,m_crs_course_tbl as c,m_academic as ayd,m_crs_subcourse_tbl as s,m_crs_subjectgroup_tbl as g ,www_Eligibility as E where m.stud_id=p.stud_id and ayd.ayid='" + fromyear + "' and m.ayid=ayd.AYID and  c.course_id=s.course_id and g.Group_id=m.group_id and s.subcourse_id=m.subcourse_Id  and c.course_id='" + ddlcourse.SelectedValue.ToString() + "' and m.subcourse_Id='" + ddlsubcou.SelectedValue.ToString() + "' and m.group_id='" + ddlfrmgrp.SelectedValue.ToString() + "' and E.Stud_id=m.stud_id and E.Group_id=g.Group_id and E.to_group_id='" + a + "'and  E.Stud_id='" + lbl_grd_studi.Text + "' order by cast(m.Roll_no as int) asc";
                    DataTable dtchk = new DataTable();
                    dtchk = cls.fillDataTable(chk_chked_ontogroupSelection);
                    if (dtchk.Rows.Count == 0)
                    {
                        chk.Checked = false;
                    }
                    else if (dtchk.Rows[0]["is_eligible"].ToString() == "True")
                    {
                        chk.Checked = true;

                    }
                    else
                    {
                        chk.Checked = false;

                    }
                }
            }
            //}


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "50px");

            }

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    protected void grdchk_CheckedChanged(object sender, EventArgs e)
    {
    }
    protected void grd1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            foreach (GridViewRow row in grd1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[4].FindControl("chkRow") as CheckBox);

                    if (chkRow.Checked)
                    {

                    }

                }
            }
        }
        catch (Exception d)
        { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true); }
    }
    //protected void btngetdata_Click(object sender, EventArgs e)
    //{

    //}

    public bool chk_toyearchecked()
    {
        if (ddltoyear.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To year.','danger')", true);
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select To year.')", true);
        }
        else if (is_select.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To Group.','danger')", true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select To Group.')", true);            
        }

        return false;
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            string empid;
            string toyear;
            string cou;
            string subcou;
            string frmgrup;
            string frmyear;
            is_select = "";
            for (int i = 0; i < lsttogrp.Items.Count; i++)
            {
                if (lsttogrp.Items[i].Selected)
                {
                    is_select = "true";
                }

            }

            for (int i = 0; i < lsttogrp.Items.Count; i++)
            {
                if (lsttogrp.Items[i].Selected)
                {
                    if (a == "")
                    {
                        a = "" + lsttogrp.Items[i].Value + "";

                    }
                    else
                    {

                        a = a + "," + lsttogrp.Items[i].Value + "";
                    }
                }
            }
            //List<int> selecteds = lsttogrp.GetSelectedIndices().ToList();
            //a = "";
            //foreach (int i in lsttogrp.GetSelectedIndices())
            //{
            //    if (lsttogrp.Items[i].Selected)
            //    {
            //        if (a == "")
            //        {
            //            a = "" + lsttogrp.Items[selecteds[i]].Value + "";

            //        }
            //        else
            //        {
            //            a = a + "," + lsttogrp.Items[selecteds[i]].Value + "";

            //        }
            //    }
            //}

            string hope_so;
            // chk_toyearchecked();
            if (ddltoyear.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To year.','danger')", true);
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select To year.')", true);
            }
            else if (is_select.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To Group.','danger')", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select To Group.')", true);
            }
            else if(grd1.Rows.Count<0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('invalid steps.','danger')", true);
            }

            else
            {
                if (chk_search.Checked && txtstudid.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID.','danger')", true);
                    grd1.DataSource = null;
                    grd1.DataBind();
                    ddltoyear.SelectedIndex = 0;
                    lsttogrp.Items.Clear();
                    lsttogrp.DataSource = null;
                    lsttogrp.DataBind();
                    ddlfrmgrp.Items.Clear();
                    ddlsubcou.Items.Clear();
                    ddlcourse.Items.Clear();
                    txtstudid.Text = "";

                }
                else
                {
                    btnsave.Enabled = true;
                    foreach (GridViewRow row in grd1.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chk = (row.FindControl("grdchk") as CheckBox);
                            if (chk.Checked)
                            {
                                Label lbl_studid = (Label)row.FindControl("gridlblStudid");
                                toyear = ddltoyear.SelectedValue.ToString();
                                cou = ddlcourse.SelectedValue.ToString();
                                subcou = ddlsubcou.SelectedValue.ToString();
                                frmgrup = ddlfrmgrp.SelectedValue.ToString();
                                frmyear = Session["Year"].ToString();
                                empid = Session["username"].ToString();

                                string chk_exist = "SELECT * FROM www_Eligibility WHERE Stud_id='" + lbl_studid.Text + "' and del_flag=0 and Group_id='" + frmgrup.ToString() + "' and From_year='" + frmyear.ToString() + "' and to_year='" + toyear.ToString() + "'";
                                //  string chk_exist = "SELECT * FROM www_Eligibility WHERE Stud_id='" + lbl_studid.Text + "' and del_flag=0";
                                DataTable chkdt = new DataTable();
                                chkdt = cls.fillDataTable(chk_exist);
                                if (chkdt.Rows.Count > 0)
                                {

                                    string update_qury = "UPDATE www_Eligibility set Group_id='" + frmgrup + "',Stud_id='" + lbl_studid.Text + "',to_year='" + toyear + "',From_year='" + frmyear + "',is_eligible=1,curr_dt=GETDATE(),mod_dt=NULL,del_flag=0,del_dt=NULL,to_group_id='" + a + "',emp_id='" + empid + "' WHERE Stud_id='" + lbl_studid.Text + "'";
                                    string updte2 = update_qury + "UPDATE www_Eligibility set Group_id='" + frmgrup + "',Stud_id='" + lbl_studid.Text + "',to_year='" + toyear + "',From_year='" + frmyear + "',is_eligible=1,curr_dt=GETDATE(),mod_dt=NULL,del_flag=0,del_dt=NULL,to_group_id='" + a + "',emp_id='" + empid + "' WHERE Stud_id='" + lbl_studid.Text + "'";
                                    //cls.DMLqueries(updte2);
                                    if (cls.DMLqueries(updte2))
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Eligibility Successful.','success')", true);
                                        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eligibility Successful.')", true);
                                    }
                                    else
                                    {
                                        ddltoyear.SelectedIndex = 0;
                                        ddlcourse.SelectedIndex = 0;
                                        ddlsubcou.Items.Clear();
                                        ddlfrmgrp.Items.Clear();
                                        grd1.DataSource = null;
                                        grd1.DataBind();
                                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eligibility Unsuccessfull.')", true);
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Eligibility failed','danger')", true);
                                    }

                                }
                                else
                                {


                                    string queryinsert = "insert into www_Eligibility(Group_id,Stud_id,to_year,From_year,is_eligible,curr_dt,mod_dt,del_flag,del_dt,to_group_id,emp_id)values('" + frmgrup + "','" + lbl_studid.Text + "','" + toyear + "','" + frmyear + "',1,GETDATE(),NULL,0,NULL,'" + a + "','" + empid + "')";
                                    //cls.DMLqueries(queryinsert);
                                    //string insert2 = queryinsert + "insert into www_Eligibility(Group_id,Stud_id,to_year,From_year,is_eligible,curr_dt,mod_dt,del_flag,del_dt,to_group_id,emp_id)values('" + frmgrup + "','" + lbl_studid.Text + "','" + toyear + "','" + frmyear + "',1,GETDATE(),NULL,0,NULL,'" + a + "','" + empid + "')";
                                    if (cls.DMLqueries(queryinsert))
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Eligibility Successful.','success')", true);
                                        //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eligibility Successful.')", true);
                                    }
                                    else
                                    {
                                        ddltoyear.SelectedIndex = 0;
                                        ddlcourse.SelectedIndex = 0;
                                        ddlsubcou.Items.Clear();
                                        ddlfrmgrp.Items.Clear();
                                        grd1.DataSource = null;
                                        grd1.DataBind();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('eligibilty failed','danger')", true);
                                        // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('eligibility failed')", true);
                                    }
                                }


                            }
                            if (chk.Checked == false)
                            {

                                Label lbl_studid = (Label)row.FindControl("gridlblStudid");
                                toyear = ddltoyear.SelectedValue.ToString();
                                cou = ddlcourse.SelectedValue.ToString();
                                subcou = ddlsubcou.SelectedValue.ToString();
                                frmgrup = ddlfrmgrp.SelectedValue.ToString();
                                frmyear = Session["Year"].ToString();
                                empid = Session["username"].ToString();
                                string chk_exist = "SELECT * FROM www_Eligibility WHERE Stud_id='" + lbl_studid.Text + "' and del_flag=0";
                                DataTable chkextdt = cls.fillDataTable(chk_exist);
                                if (chkextdt.Rows.Count > 0)
                                {
                                    string updatefor_uncked = "UPDATE www_Eligibility set Group_id='" + frmgrup + "',Stud_id='" + lbl_studid.Text + "',to_year='" + toyear + "',From_year='" + frmyear + "',is_eligible=0,curr_dt=GETDATE(),mod_dt=NULL,del_flag=0,del_dt=NULL,to_group_id='" + a + "',emp_id='" + empid + "' WHERE Stud_id='" + lbl_studid.Text + "'";
                                    // cls.DMLqueries(updatefor_uncked);
                                    if (cls.DMLqueries(updatefor_uncked))
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Eligibility Successful.','success')", true);
                                        //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eligibility Successful. ')", true);
                                    }
                                    else
                                    {
                                        ddltoyear.SelectedIndex = 0;
                                        ddlcourse.SelectedIndex = 0;
                                        ddlsubcou.Items.Clear();
                                        ddlfrmgrp.Items.Clear();
                                        grd1.DataSource = null;
                                        grd1.DataBind();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('eligibility failed.','success')", true);
                                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('UNSUCCESSFULL update ')", true);
                                    }
                                }
                                else
                                {

                                    string quryfornoteligible = "insert into www_Eligibility(Group_id,Stud_id,to_year,From_year,is_eligible,curr_dt,mod_dt,del_flag,del_dt,to_group_id,emp_id)values(' " + frmgrup + " ','" + lbl_studid.Text + "','" + toyear + "','" + frmyear + "',0,GETDATE(),NULL,0,NULL,'" + a + "',NULL)";
                                    // cls.DMLqueries(quryfornoteligible);
                                    if (cls.DMLqueries(quryfornoteligible))
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Eligibility Successful.','success')", true);
                                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eligibility Successful. ')", true);
                                    }
                                    else
                                    {
                                        ddltoyear.SelectedIndex = 0;
                                        ddlcourse.SelectedIndex = 0;
                                        ddlsubcou.Items.Clear();
                                        ddlfrmgrp.Items.Clear();
                                        grd1.DataSource = null;
                                        grd1.DataBind();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Eligibility Failed.','danger')", true);
                                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('unscessfull eligibility ')", true);

                                    }

                                }
                            }
                        }

                    }
                    lsttogrp.Items.Clear();
                    lsttogrp.DataSource = null;
                    lsttogrp.DataBind();
                    grd1.DataSource = null;
                    grd1.DataBind();
                    ddltoyear.SelectedIndex = 0;
                    ddlfrmgrp.Items.Clear();
                    ddlsubcou.Items.Clear();
                    course();
                    txtstudid.Text = "";
                    btnsave.Enabled = false;

                }
            }



            //ddltoyear.SelectedIndex = 0;
            //ddlcourse.SelectedIndex = 0;
            //ddlsubcou.Items.Clear();

            //ddlfrmgrp.SelectedIndex = 0;
            //ddlfrmgrp.Items.Clear();
            //grd1.DataSource = null;
            //grd1.DataBind();

            //chk_search.Checked = false;
            // chkbx_ischecked();

        }
        catch (Exception d)
        { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true); }
    }
    protected void headchk_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            btnsave.Attributes.Remove("disabled");
            CheckBox chkheader = (CheckBox)grd1.HeaderRow.FindControl("headchk");
            foreach (GridViewRow row in grd1.Rows)
            {
                CheckBox chkrw = (CheckBox)row.FindControl("grdchk");
                if (chkheader.Checked)
                {
                    chkrw.Checked = true;

                }
                else
                {
                    chkrw.Checked = false;
                }

            }

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }

    }
    protected void lsttogrp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddltoyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlMaster = (DropDownList)Master.FindControl("ddlyear");
            //string masteyer = Session["Year"].ToString();
            //string removeitemddl = ddltoyear.SelectedValue.ToString();
            //if (masteyer.ToString() == ddltoyear.SelectedValue.ToString())
            //{
            //    ddltoyear.Items.Remove("removeitemddl");

            //}
            string masteyer = ddlMaster.SelectedValue.ToString();

            ddltoyear.Items.Remove(ddltoyear.Items.FindByValue(masteyer));
            //string masteyer=   ddlMaster.SelectedItem.ToString();
            //string masteyer = Session["Year"].ToString();
            // string removeitemddl = ddltoyear.SelectedValue.ToString();
            //DropDownList value = ddltoyear.SelectedItem.Text;
            // if (masteyer.ToString() == ddltoyear.SelectedItem.ToString())
            // {
            //     ddltoyear.Items.Remove(masteyer);

            // }

            //if (ddltoyear.SelectedValue.ToString() == ddlMaster.SelectedValue.ToString())
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Current Year and Toyear Cant Be Same.','danger')", true);
            //  //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Current Year and Toyear Cant Be Same.')", true);
            //    ddltoyear.SelectedIndex = 0;
            //}
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    public void chkbx_ischecked()
    {
        if (chk_search.Checked)
        {
            ddlfrmgrp.Items.Clear();
            ddlfrmgrp.Enabled = false;
            ddlsubcou.Items.Clear();
            ddlsubcou.Enabled = false;
            ddlcourse.SelectedIndex = 0;
            ddlcourse.Enabled = false;
            txtstudid.Enabled = true;
            ddltoyear.SelectedIndex = 0;
            grd1.DataSource = null;
            grd1.DataBind();
            lsttogrp.Items.Clear();
            lsttogrp.DataSource = null;
            lsttogrp.DataBind();
        }
        else
        {               //unchecked 
            course();
            ddlcourse.Enabled = true;
            ddlsubcou.Enabled = true;
            ddlfrmgrp.Enabled = true;
            txtstudid.Text = "";
            txtstudid.Enabled = false;
            ddltoyear.SelectedIndex = 0;
            grd1.DataSource = null;
            grd1.DataBind();
            lsttogrp.Items.Clear();
            lsttogrp.DataSource = null;
            lsttogrp.DataBind();
        }

    }

    protected void grdchk_CheckedChanged1(object sender, EventArgs e)
    {
        try
        {
            string grdchecked;
            grdchecked = "";
            btnsave.Attributes.Remove("disabled");
            foreach (GridViewRow row in grd1.Rows)
            {
                CheckBox chkheader = (CheckBox)grd1.HeaderRow.FindControl("headchk");
                CheckBox chkrw = (CheckBox)row.FindControl("grdchk");
                if (chkrw.Checked != true)
                {
                    grdchecked = "off";

                }
                if (grdchecked == "off")
                {
                    chkheader.Checked = false;
                }
                if (grdchecked == "")
                {
                    chkheader.Checked = true;
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
}