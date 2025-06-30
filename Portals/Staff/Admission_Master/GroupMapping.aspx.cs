using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_Master_GroupMapping : System.Web.UI.Page
{
    string is_select;
    string isselect2;
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataonpageload();
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true);
    }
    public void dataonpageload()
    {
        try
        {
            string coursequry = "select course_id,course_name from m_crs_course_tbl where del_flag=0";
            cls.fillDataTable(coursequry);
            DataTable dtcou = new DataTable();
            dtcou = cls.fillDataTable(coursequry);
            ddl_Course.DataTextField = dtcou.Columns["course_name"].ToString();
            ddl_Course.DataValueField = dtcou.Columns["course_id"].ToString();
            ddl_Course.DataSource = dtcou;
            ddl_Course.DataBind();
            ddl_Course.Items.Insert(0, new ListItem("--Select--", "na"));
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('"+d.Message+"','danger')", true);
        }

    }
    protected void ddl_Course_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Course.SelectedIndex==0) 
            {
                ddl_subcou.Items.Clear();
                lstfrmgroup.Items.Clear();
                lstfrmgroup.DataSource = null;
                lstfrmgroup.DataBind();
                lsttogroup.Items.Clear();
                lsttogroup.DataSource = null;
                lsttogroup.DataBind();

            }
            string subcouqury = "select subcourse_id,subcourse_name from m_crs_subcourse_tbl where course_id='" + ddl_Course.SelectedValue.ToString() + "' and del_flag=0";
            DataTable dtsubcou = cls.fillDataTable(subcouqury);
            if (dtsubcou.Rows.Count > 0)
            {
                ddl_subcou.DataTextField = dtsubcou.Columns["subcourse_name"].ToString();
                ddl_subcou.DataValueField = dtsubcou.Columns["subcourse_id"].ToString();
                ddl_subcou.DataSource = dtsubcou;
                ddl_subcou.DataBind();
                ddl_subcou.Items.Insert(0, new ListItem("--Select--", "na"));
            }
          
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void ddl_subcou_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_subcou.SelectedIndex == 0)
            {
                lstfrmgroup.Items.Clear();
                lstfrmgroup.DataSource = null;
                lstfrmgroup.DataBind();
                lsttogroup.Items.Clear();
                lsttogroup.DataSource = null;
                lsttogroup.DataBind();

            }


            string gruplstbx = "select Group_id,Group_title from m_crs_subjectgroup_tbl where Subcourse_id='" + ddl_subcou.SelectedValue.ToString() + "' and del_flag=0";
            DataTable dtlstbx = cls.fillDataTable(gruplstbx);
            string togrp = "select  Group_title,Group_id from m_crs_subjectgroup_tbl where Subcourse_id in(select Subcourse_id from m_crs_subcourse_tbl WHERE course_id IN (SELECT course_id from m_crs_course_tbl where course_id='" + ddl_Course.SelectedValue.ToString() + "' and del_flag=0)) and del_flag=0";
            DataTable dttogrop = cls.fillDataTable(togrp);

            if (dtlstbx.Rows.Count > 0 && dttogrop.Rows.Count > 0)
            {
                lstfrmgroup.DataTextField = dtlstbx.Columns["group_title"].ToString();
                lstfrmgroup.DataValueField = dtlstbx.Columns["Group_id"].ToString();
                lstfrmgroup.DataSource = dtlstbx;
                lstfrmgroup.DataBind();

                lsttogroup.DataTextField = dttogrop.Columns["Group_title"].ToString();
                lsttogroup.DataValueField = dttogrop.Columns["Group_id"].ToString();
                lsttogroup.DataSource = dttogrop;
                lsttogroup.DataBind();
            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void lstfrmgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            List<int> selecteds = lstfrmgroup.GetSelectedIndices().ToList();
            //lsttogroup.Items.Clear();
            string l = "";
            foreach (int i in lstfrmgroup.GetSelectedIndices())
            {
                if (lstfrmgroup.Items[i].Selected)
                {
                    if (l == "")
                    {
                        l = "'" + lstfrmgroup.Items[selecteds[i]].Value + "'";
                    }
                    else
                    {
                        l = l + ",'" + lstfrmgroup.Items[selecteds[i]].Value + "'";
                    }
                }
            }
            for (int i = 0; i < lsttogroup.Items.Count; i++)
            {
                if (lsttogroup.Items[i].Selected)
                {

                    lsttogroup.Items[i].Selected = false;
                }
            }
            if (l != "")
            {
              

                DataTable dt = cls.fillDataTable("select map_group_id from group_mapping where group_id IN (" + l + ")");
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lsttogroup.Items.FindByValue(dt.Rows[i]["map_group_id"].ToString()).Selected = true;
                    }
                }
                else {
                    //lsttogroup.Items.FindByValue(dt.Rows[i]["map_group_id"].ToString()).Selected = false;
                }
            }
            else
            {

            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    


    }
    protected void lsttogroup_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            is_select = "";
            for (int i = 0; i < lstfrmgroup.Items.Count; i++)
            {
                if (lstfrmgroup.Items[i].Selected)
                {
                    is_select = "true";
                }

            }
            isselect2 = "";
            for (int i = 0; i < lsttogroup.Items.Count; i++)
            {
                if (lsttogroup.Items[i].Selected)
                {
                    isselect2 = "true";
                }

            }

            if (ddl_Course.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select course.','danger')", true);

            }
            else if (ddl_subcou.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select subcourse.','danger')", true);

            }
            else if (is_select=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select From Group.','danger')", true);

            }
            else if(isselect2=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To Group.','danger')", true);
            }
            else {
                for (int i = 0; i < lstfrmgroup.Items.Count; i++)
                {

                    if (lstfrmgroup.Items[i].Selected)
                    {
                        for (int j = 0; j < lsttogroup.Items.Count; j++)
                        {
                            if (lsttogroup.Items[j].Selected)
                            {
                                string chkduplicate = "select * from Group_Mapping where Group_id='" + lstfrmgroup.Items[i].Value.ToString() + "' and Map_Group_Id='" + lsttogroup.Items[j].Value.ToString() + "'";
                                DataTable dts = cls.fillDataTable(chkduplicate);
                                if (dts.Rows.Count > 0)
                                {

                                    string updt = "update Group_Mapping set Map_Group_Id='" + lsttogroup.Items[j].Value.ToString() + "' where group_id='" + lstfrmgroup.Items[i].Value.ToString() + "'";
                                    bool tt = cls.DMLqueries(updt);
                                    if (tt == true)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Group Mapping Successfull','success')", true);
                                    }
                                }
                                else
                                {
                                    string insert = "insert into Group_Mapping (Group_id,Map_Group_Id,curr_dt,del_flag) values('" + lstfrmgroup.Items[i].Value.ToString() + "','" + lsttogroup.Items[j].Value.ToString() + "',GETDATE(),0)";
                                    bool tt = cls.DMLqueries(insert);
                                    if (tt == true)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Group Mapping Successfull','success')", true);
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Group Mapping Failed','danger')", true);
                                    }
                                }
                            }
                        }
                    }
              
                }
                lstfrmgroup.Items.Clear();
                lstfrmgroup.DataSource = null;
                lstfrmgroup.DataBind();
                lsttogroup.Items.Clear();
                lsttogroup.DataSource = null;
                lsttogroup.DataBind();
                ddl_Course.SelectedIndex = 0;
                ddl_subcou.SelectedIndex = 0;


            }

    }
        catch(Exception d)
       {
           ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
}