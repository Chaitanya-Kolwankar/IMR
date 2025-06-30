using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Form_Insert : System.Web.UI.Page
{
    //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
    Class1 c1 = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
            {
            if (!IsPostBack)
            {
                BindGridView();
                modulemodal();
                ddl_Modulename();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
            }
            
        }
            catch (Exception ex)
        {
            Response.Redirect("~/Portals/Staff/Login.aspx");

        }
    }

    private void BindGridView()
    {
        string str = "select * from Register_Form as r ,ModuleForm as m where r.mod_id = m.mod_id and r.del_flag = 0 and m.del_flag = 0";
        DataTable ds = c1.fillDataTable(str);
        grd_maingrd.DataSource=ds;
        grd_maingrd.DataBind();

    }
    public void modulemodal()//h
    {
        string moduleload = "select mod_id, module_name from ModuleForm where del_flag = 0";
        DataTable dt = c1.fillDataTable(moduleload);
        if (dt.Rows.Count>0)
        {
            grd_module.DataSource = dt;
            grd_module.DataBind();
        }
    }
    public void ddl_Modulename()
    {
        string ddlmodule = "select mod_id, module_name from ModuleForm where del_flag = 0";
        DataTable dt = c1.fillDataTable(ddlmodule);
        txt_li_name.DataTextField = dt.Columns["module_name"].ToString();
        txt_li_name.DataValueField = dt.Columns["mod_id"].ToString(); 
        txt_li_name.DataSource = dt;
        txt_li_name.DataBind();
        txt_li_name.Items.Insert(0, new ListItem("--Select--", "na"));
       

    }

    protected void btn_save_Click(object sender, EventArgs e)//---------------------------------------
    {
        if (btn_save.Text == "Save")
        {
            if (txt_li_name.SelectedIndex == 0)
            {
                
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Module Name','danger')", true);
            }
            else if (txt_formname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Form Name','danger')", true);
            }
            else
            {
                string chkdup_form = "select * from  Register_Form where Form_name='" + txt_formname.Text.Trim() + "' and Mod_id='" + txt_li_name.SelectedValue + "' and del_flag=0";
                DataTable dt = c1.fillDataTable(chkdup_form);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Form Name Already Exist.','danger')", true);
                    txt_formname.Text = "";
                }
                else
                {

                    string insert_in_regisform1 = "insert into Register_Form (Form_name,mod_id,curr_dt,del_flag) values('" + txt_formname.Text.ToString().Trim() + "','" + txt_li_name.SelectedValue.ToString() + "',getdate(),0)";
                    if (c1.DMLqueries(insert_in_regisform1))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Form Name saved successfully','success')", true);
                        BindGridView();                        
                        modulemodal();
                        txt_li_name.SelectedIndex = 0;
                        txt_formname.Text = "";

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong','success')", true);
                    }

                }
            }

        }
        else 
        {
             if (btn_save.Text=="Update") 
            {
                if (txt_li_name.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Module Name','danger')", true);
                }
                else if (txt_formname.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Form Name','danger')", true);
                }
                else 
                {
                    string chkdup = "select * from Register_Form where Form_name='"+txt_formname.Text.Trim()+"'  and mod_id='"+txt_li_name.SelectedValue.ToString()+"' and del_flag='0'";
                    DataTable dt1 = c1.fillDataTable(chkdup);
                    if (dt1.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Form name Already exist','danger')", true);
                        btn_save.Text = "Save";
                        txt_li_name.SelectedIndex = 0;
                        txt_formname.Text = "";

                    }
                    else
                    {

                        string updte_form = "update Register_Form set Form_name = '" + txt_formname.Text.Trim() + "', mod_id = '" + txt_li_name.SelectedValue.ToString() + "', mod_dt = getdate() where del_flag = 0 and Form_id = '" + ViewState["vs_form_id"].ToString() + "'";
                        if (c1.DMLqueries(updte_form))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Form update Successfully','success')", true);
                            btn_save.Text = "Save";
                            txt_li_name.SelectedIndex = 0;
                            txt_formname.Text = "";
                            BindGridView();
                            modulemodal();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong','danger')", true);
                            btn_save.Text = "Save";
                            txt_li_name.SelectedIndex = 0;
                            txt_formname.Text = "";

                        }
                    }                               
                }
            }               
        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        clear();
    }
    public void clear()
    {
        txt_li_name.SelectedIndex = 0;
        txt_formname.Text = "";
        msg.InnerText = "";
    }
    //protected void grid_form_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    GridViewRow row = (GridViewRow)grid_form.Rows[e.RowIndex];
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("delete FROM Register_Form where Sr_no='" + Convert.ToInt32(grid_form.Rows[e.RowIndex].Cells[0].Text) + "'", con);
    //    cmd.ExecuteNonQuery();
    //    con.Close();
    //    BindGridView();
    //}
    protected void grid_form_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }
    }

    protected void btn_saveModulename_Click(object sender, EventArgs e) //h
    {
        if (txtModalname.Text.Trim() == "")
        {
            txtModalname.Focus();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Module Name.','danger')", true);
        }
        
        else 
        {
            string chkdup = "select mod_id, module_name from ModuleForm where del_flag = 0 and module_Name = '" + txtModalname.Text.Trim() + "'";
            DataTable dt1 = c1.fillDataTable(chkdup);
            if (dt1.Rows.Count>0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Module Name Already Exist.','danger')", true);

           }
            else
            {
                if (btn_saveModulename.Text == "Save")
                {
                    string qury_addmodule = "insert into ModuleForm (module_Name,ext1,ext2,ext3,curr_dt,del_flag) values('" + txtModalname.Text.Trim() + "','','','',GETDATE(),0)";
                    if (c1.DMLqueries(qury_addmodule))
                    {
                        txtModalname.Text = "";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Module Name Added .','success')", true);
                        modulemodal();
                        ddl_Modulename();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong.','danger')", true);

                    }
                }                               
            }
        }

         if (btn_saveModulename.Text == "Update")
        {
            if (txtModalname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Modal Name.','success')", true);
            }
            else
            {
                string chk_dup = "select * from ModuleForm where module_Name='" + txtModalname.Text.Trim() + "' and del_flag=0 ";
                DataTable dt3 = c1.fillDataTable(chk_dup);
                if (dt3.Rows.Count > 0)
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Module Name Already Exist','danger')", true);
                }
                else
                {

                    string updet = "update ModuleForm set module_Name='" + txtModalname.Text.Trim() + "',mod_dt=GETDATE() where mod_id='" + lblmod_id.Text.Trim() + "'";
                    if (c1.DMLqueries(updet))
                    {
                        txtModalname.Text = "";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Module Name updated successfully','success')", true);
                        modulemodal(); ddl_Modulename(); BindGridView();
                        btn_saveModulename.Text = "Save";

                    }
                }
            }
        }
    }

    protected void btn_Clear_Click(object sender, EventArgs e)//h
    {
        txtModalname.Text = "";
        btn_saveModulename.Text = "Save";
    }

    protected void grd_module_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Module_Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Label lblmod_name_frm_grd = (Label)grd_module.Rows[index].FindControl("modal_grd_lblmodalname");
            Label lbl_mod_id_frm_grd = (Label)grd_module.Rows[index].FindControl("modal_id");
            txtModalname.Text = lblmod_name_frm_grd.Text.ToString();
            lblmod_id.Text = lbl_mod_id_frm_grd.Text.ToString();
            btn_saveModulename.Text = "Update";

        }
        else
        {
            if (e.CommandName == "module_del")
            {
                int ind = Convert.ToInt32(e.CommandArgument);
                Label lblmodname = (Label)grd_module.Rows[ind].FindControl("modal_grd_lblmodalname");
                Label lblmodid = (Label)grd_module.Rows[ind].FindControl("modal_id");
                string delch = "select * from Register_Form where mod_id='"+ lblmodid.Text.Trim() + "'";
                DataTable dt = c1.fillDataTable(delch);
                if (dt.Rows.Count > 0)
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('forms are mapped to this module hence cannot be deleted','danger')", true);
                    BindGridView();
                }
                else
                {
                    string del_mod = "update ModuleForm set del_flag=1 where mod_id='"+ lblmodid.Text + "'";
                    if (c1.DMLqueries(del_mod))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Module Deleted','success')", true);
                        BindGridView(); modulemodal();
                    }
                    else 
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong','danger')", true);

                    }                
                }
            }
        }
    }

    protected void grd_maingrd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "mainSelect")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Label maingrd_lblmod_id = (Label)grd_maingrd.Rows[index].FindControl("maingrdmod_id");
            Label maingrd_lblmod_name = (Label)grd_maingrd.Rows[index].FindControl("grd_Modname");
            Label maingrd_formid = (Label)grd_maingrd.Rows[index].FindControl("maingrdlblformid");
            Label maingrd_forname = (Label)grd_maingrd.Rows[index].FindControl("grd_form_name");
            ViewState["vs_mod_id"] = maingrd_lblmod_id.Text;
            ViewState["vs_form_id"] = maingrd_formid.Text;
            string b = maingrd_lblmod_id.Text;
            txt_li_name.SelectedValue = b;
            txt_formname.Text = maingrd_forname.Text;
            btn_save.Text = "Update";
        }
        else 
        {
            if (e.CommandName== "mainDel") 
            {
                int ind = Convert.ToInt32(e.CommandArgument);
                Label modid = (Label)grd_maingrd.Rows[ind].FindControl("maingrdmod_id");
                Label maingrd_lblmod_name1 = (Label)grd_maingrd.Rows[ind].FindControl("grd_Modname");
                Label maingrd_formid1 = (Label)grd_maingrd.Rows[ind].FindControl("maingrdlblformid");
                Label maingrd_forname1 = (Label)grd_maingrd.Rows[ind].FindControl("grd_form_name");
               


            }
        
        
        
        
        }
    }

    protected void txt_li_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        string li_name = "select * from Register_Form as r ,ModuleForm as m where r.mod_id = m.mod_id and r.del_flag = 0 and m.del_flag = 0 and m.mod_id='"+txt_li_name.SelectedValue+"'";
        DataTable dt = c1.fillDataTable(li_name);
        if (dt.Rows.Count>0)
        {
            grd_maingrd.DataSource = dt;
            grd_maingrd.DataBind();

        }
    }
}