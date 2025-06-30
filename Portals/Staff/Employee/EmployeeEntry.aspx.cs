using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Employee_EmployeeEntry : System.Web.UI.Page
{
    Class1 cls = new Class1();
    string is_grup_select;
    string module;
    string from_select;
    string msg = "";
    //SqlConnection con = new SqlConnection("Data Source=103.31.144.152; Initial Catalog=VIVAIMR; User Id = sa; password=passwd@12;");
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
    //Data Source = 172.16.10.44; Initial Catalog = Applied_Art; User ID = sa; Password=passwd@12;"
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            dept_ddl();
            datapageload();
            txtEmpId.Enabled = false;
            btn_save.Text = "Save";
            btn_des.Text = "Add";
            lstbx_Module.Attributes.Add("disabled", "");
            lstbx_formname.Attributes.Add("disabled", "");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtemail.Text = "";
        clean();

        txtEmpId.Enabled = false;
        lstbx_Module.Attributes.Add("disabled", "");
        lstbx_formname.Attributes.Add("disabled", "");

    }
    public void clean()
    {
        clearlstbx();
        sameabov.Checked = false;
        txtpercity.Text = "";
        txtperpin.Text = "";
        txtcity.Text = "";
        TXTPIN.Text = "";
        ddl_rel.SelectedIndex = 0;
        rad_female.Checked = false;
        rad_gender.Checked = false;
        txtEmpId.Text = "";
        txtEmpId.Enabled = false;
        txtlastname.Text = "";
        txtfirstname.Text = "";
        txtmiddlename.Text = "";
        txtmothername.Text = "";
        groupload();
        txtDOJ.Text = "";
        txtdob.Text = "";
        txtannualsal.Text = "";
        ddlbloodgroup.SelectedIndex = 0;
        txtmobile.Text = "";
        txtmobno.Text = "";
        txtemail.Text = "";
        txtaddress.Text = "";
        ddlnation.SelectedIndex = 0;
        ddlmart.SelectedIndex = 0;
        txtadd.Text = "";
        txtaadhar.Text = "";
        txtpan.Text = "";
        txt_pf.Text = "";
        ddl_stafftype.SelectedIndex = 0;
        ddldepart1.SelectedIndex = 0;
        ddlDesignation1.SelectedIndex = 0;
        state();
        ddlstate.SelectedIndex = 0;
        chkbx_phys.Checked = false;
        ddlRole.SelectedIndex = 0;
        ddlcast.Items.Clear();
        //ddlcast.SelectedIndex = 0;
        ddlcat.SelectedIndex = 0;
        btnsave.Enabled = true;
        btnsave.Text = "Save";
        groupload();
        for (int i = 0; i < lstgroup.Items.Count; i++)
        {
            if (lstgroup.Items[i].Selected)
            {
                lstgroup.Items[i].Selected = false;
            }

        }
    }
    public void clearlstbx()
    {
        for (int i = 0; i < lstbx_Module.Items.Count; i++)
        {
            if (lstbx_Module.Items[i].Selected)
            {
                lstbx_Module.Items[i].Selected = false;
                lstbx_Module.Items[i].Attributes.Remove("disabled");
            }
        }
        for (int i = 0; i < lstbx_formname.Items.Count; i++)
        {
            if (lstbx_formname.Items[i].Selected)
            {
                lstbx_formname.Items[i].Selected = false;
                lstbx_formname.Items[i].Attributes.Remove("disabled");
            }
        }
    }

    public void groupload()
    {
        string grup_qry = "select * from m_crs_subjectgroup_tbl where del_flag=0";
        DataTable dtgrp = cls.fillDataTable(grup_qry);
        lstgroup.DataTextField = dtgrp.Columns["group_title"].ToString();
        lstgroup.DataValueField = dtgrp.Columns["group_id"].ToString();
        lstgroup.DataSource = dtgrp;
        lstgroup.DataBind();
    }
    public void datapageload()
    {
        module_lstbx();
        // formlstbox();
        formname_fun();
        txtEmpId.Enabled = true;
        groupload();
        dept_ddl();       //department load
        dept_loadmodal();//departmnent modal
        designation_modal();//modal designation
        designation();    //designation
        category();       //category load
        caste();          //caste
        state();          //state
        Roleload();
        ROLE_FORMNAME();
        religion_load();//religion load
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true);
    }


    public void modselectchange()
    {



    }

    public void formlstbox()
    {
        bool m = true;
        for (int i = 0; i < lstbx_Module.Items.Count; i++)
        {
            if (lstbx_Module.Items[i].Selected == true)
            {
                m = true;
            }
            else { m = false; }
        }

        if (m)
        {

            lstbx_formname.Enabled = true;
            string frmname = "select * from Register_Form where del_flag=0";
            DataTable dt = cls.fillDataTable(frmname);
            lstbx_formname.DataTextField = dt.Columns["Form_name"].ToString();
            lstbx_formname.DataValueField = dt.Columns["Form_id"].ToString();
            lstbx_formname.DataSource = dt;
            lstbx_formname.DataBind();


        }
        else
        {

        }
    }
    public void formname_fun()
    {
        lstbx_formname.Enabled = true;
        string frmname = "select * from Register_Form where del_flag=0";
        DataTable dt = cls.fillDataTable(frmname);
        lstbx_formname.DataTextField = dt.Columns["Form_name"].ToString();
        lstbx_formname.DataValueField = dt.Columns["Form_id"].ToString();
        lstbx_formname.DataSource = dt;
        lstbx_formname.DataBind();



    }
    public void module_lstbx()
    {
        bool m;
        string module11 = "select * from  ModuleForm where del_flag=0";
        DataTable moddt = cls.fillDataTable(module11);
        lstbx_Module.DataTextField = moddt.Columns["module_Name"].ToString();
        lstbx_Module.DataValueField = moddt.Columns["mod_id"].ToString();
        lstbx_Module.DataSource = moddt;
        lstbx_Module.DataBind();
        for (int i = 0; i < lstbx_Module.Items.Count; i++)
        {
            if (lstbx_Module.Items[i].Selected == true)
            {
                m = true;
            }
            else { m = false; }
        }

    }

    public void designation_modal()
    {
        string desgrd = "select * from m_designation where del_flag=0";
        DataTable dtdesgrd = cls.fillDataTable(desgrd);
        if (dtdesgrd.Rows.Count > 0)
        {
            grddes.DataSource = dtdesgrd;
            grddes.DataBind();
        }


    }
    public void religion_load()
    {
        string rel = "select Parent from State_category_details where Main='Religion' and del_flag=0";
        DataTable reldt = cls.fillDataTable(rel);
        ddl_rel.DataTextField = reldt.Columns["Parent"].ToString().Trim();
        ddl_rel.DataValueField = reldt.Columns["Parent"].ToString().Trim();
        ddl_rel.DataSource = reldt;
        ddl_rel.DataBind();
        ddl_rel.Items.Insert(0, new ListItem("--Select--", "na"));


    }

    public void dept_loadmodal()
    {
        //dept modal
        string dept = "select * from m_department where del_flag=0";
        DataTable dt = cls.fillDataTable(dept);
        if (dt.Rows.Count > 0)
        {
            grd_dept.DataSource = dt;
            grd_dept.DataBind();
            dept_ddl();
        }

    }
    public void Roleload()
    {
        string role = "select * from web_tp_roletype where del_flag=0";
        DataTable dtrole = cls.fillDataTable(role);
        ddlRole.DataTextField = dtrole.Columns["role_name"].ToString();
        ddlRole.DataValueField = dtrole.Columns["role_id"].ToString();
        ddlRole.DataSource = dtrole;
        ddlRole.DataBind();
        ddlRole.Items.Insert(0, new ListItem("--Select--", "na"));

    }
    public void designation()
    {
        string des = "select * from m_designation where del_flag=0";
        DataTable dtdes = cls.fillDataTable(des);
        ddlDesignation1.DataTextField = dtdes.Columns["Designation_Title"].ToString();
        ddlDesignation1.DataValueField = dtdes.Columns["Designation_ID"].ToString();
        ddlDesignation1.DataSource = dtdes;
        ddlDesignation1.DataBind();
        ddlDesignation1.Items.Insert(0, new ListItem("--Select--", "na"));

    }

    public void dept_ddl()
    {
        string deptlod = "select * from m_department where del_flag=0";
        DataTable dtdep = cls.fillDataTable(deptlod);
        ddldepart1.DataTextField = dtdep.Columns["Department_name"].ToString();
        ddldepart1.DataValueField = dtdep.Columns["Dept_id"].ToString();
        ddldepart1.DataSource = dtdep;
        ddldepart1.DataBind();
        ddldepart1.Items.Insert(0, new ListItem("--Select--", "na"));
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true);

    }
    public void category()
    {

        string cate = "select distinct Parent  from State_category_details where main ='Reserved Category' and del_flag=0";
        DataTable dtcat = cls.fillDataTable(cate);
        ddlcat.DataTextField = dtcat.Columns["Parent"].ToString();
        ddlcat.DataValueField = dtcat.Columns["Parent"].ToString();
        ddlcat.DataSource = dtcat;
        ddlcat.DataBind();
        ddlcat.Items.Insert(0, new ListItem("--Select--", "na"));

        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true);
    }

    public void caste()
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
        string caste = "select distinct child from   State_category_details where parent='" + ddlcat.SelectedValue.ToString() + "' and del_flag=0";
        DataTable dtcast = cls.fillDataTable(caste);
        ddlcast.DataTextField = dtcast.Columns["child"].ToString();
        ddlcast.DataValueField = dtcast.Columns["child"].ToString();
        ddlcast.DataSource = dtcast;
        ddlcast.DataBind();
        ddlcast.Items.Insert(0, new ListItem("--Select--", "na"));

    }
    public void ROLE_FORMNAME()
    {
        string rol = "select * from Register_Form where [Del_Flag]=0 order by Form_Name asc";
        DataTable dtrol = cls.fillDataTable(rol);
        if (dtrol.Rows.Count > 0)
        {
            grdrole.DataSource = dtrol;
            grdrole.DataBind();
        }

    }
    public void role_roleName_webtp()
    {
        string role1 = "select * from web_tp_roletype where del_flag=0";
        DataTable dtrolegrd = cls.fillDataTable(role1);
        grddefine.DataSource = dtrolegrd;
        grddefine.DataBind();

    }
    public void desgload()
    {
        string desgrd = "select * from m_designation where del_flag=0";
        DataTable dtdesgrd = cls.fillDataTable(desgrd);
        if (dtdesgrd.Rows.Count > 0)
        {
            grddes.DataSource = dtdesgrd;
            grddes.DataBind();
        }
    }
    public void deptload()
    {
        string dept = "select * from m_department where del_flag=0";
        DataTable dt = cls.fillDataTable(dept);
        if (dt.Rows.Count > 0)
        {
            grd_dept.DataSource = dt;
            grd_dept.DataBind();
        }
    }

    public void state()
    {
        string state = "select distinct Parent from State_category_details where main ='State' and del_flag=0";
        DataTable dtstat = cls.fillDataTable(state);
        ddlstate.DataTextField = dtstat.Columns["parent"].ToString().Trim();
        ddlstate.DataValueField = dtstat.Columns["parent"].ToString().Trim();
        ddlstate.DataSource = dtstat;
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, new ListItem("--Select--", "na"));
        ddlperState.DataTextField = dtstat.Columns["parent"].ToString().Trim();
        ddlperState.DataValueField = dtstat.Columns["parent"].ToString().Trim();
        ddlperState.DataSource = dtstat;
        ddlperState.DataBind();
        ddlperState.Items.Insert(0, new ListItem("--Select--", "na"));
    }

    protected void btnmodify_Click(object sender, EventArgs e)
    {
        clean();
        txtEmpId.Enabled = true;
        txtEmpId.Focus();
        btnsave.Enabled = false;
        btnsave.Text = "Update";

    }

    public void mod_form_disable()
    {
        string qury = "select form_name from web_tp_roletype where del_flag=0 and role_id='" + ddlRole.SelectedValue.ToString() + "'";
        DataTable dt = cls.fillDataTable(qury);
        string formid = dt.Rows[0]["form_name"].ToString();
        string[] formid_list = formid.Split(',');
        if (dt.Rows.Count > 0)
        {
            string qury2 = "select distinct convert(int,mod_id) as modulename from  Register_Form where Form_id in (" + dt.Rows[0]["form_name"].ToString() + ")";
            DataTable dt2 = cls.fillDataTable(qury2);
            string modid = dt2.Rows[0]["modulename"].ToString();
            string[] modlist = modid.Split(',');
            for (int i = 0; i < modlist.Length; i++)
            {
                for (int j = 0; j < lstbx_Module.Items.Count; j++)
                {
                    if (modlist[i].Equals(lstbx_Module.Items[j].Value))
                    {
                        lstbx_Module.Items[j].Selected = true;
                        lstbx_Module.Items[j].Attributes.Add("disabled", "disabled");
                    }
                }
            }

            bool m = false;
            string z = "";
            for (int i = 0; i < lstbx_Module.Items.Count; i++)
            {
                if (lstbx_Module.Items[i].Selected == true)
                {
                    m = true;
                }

            }
            for (int i = 0; i < lstbx_Module.Items.Count; i++)
            {
                if (lstbx_Module.Items[i].Selected)
                {
                    if (z == "")
                    {
                        z = "" + lstbx_Module.Items[i].Value + "";

                    }
                    else
                    {

                        z = z + "," + lstbx_Module.Items[i].Value + "";
                    }
                }
            }

            if (m)
            {
                if (z != "")
                {


                    lstbx_formname.Enabled = true;
                    string frmname = "select * from Register_Form where del_flag=0 and mod_id in(" + z + ")";
                    DataTable dt4 = cls.fillDataTable(frmname);
                    lstbx_formname.DataTextField = dt4.Columns["Form_name"].ToString();
                    lstbx_formname.DataValueField = dt4.Columns["Form_id"].ToString();
                    lstbx_formname.DataSource = dt4;
                    lstbx_formname.DataBind();
                    for (int i = 0; i < formid_list.Length; i++)
                    {
                        for (int j = 0; j < lstbx_formname.Items.Count; j++)
                        {
                            if (formid_list[i].Equals(lstbx_formname.Items[j].Value))
                            {
                                lstbx_formname.Items[j].Selected = true;
                                lstbx_formname.Items[j].Attributes.Add("disabled", "disabled");
                                // lstbx_formname.Items[j].Enabled = false;
                            }


                        }


                    }
                }

            }
        }

    }
    //protected void ddldepart1_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}

    //protected void ddlDesignation1_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.SelectedIndex == 0)
        {
            lstbx_Module.Attributes.Add("disabled", "");
            lstbx_formname.Attributes.Add("disabled", "");
            for (int j = 0; j < lstbx_Module.Items.Count; j++)
            {

                lstbx_Module.Items[j].Selected = false;
                lstbx_Module.Items[j].Attributes.Remove("disabled");
            }
            for (int j = 0; j < lstbx_formname.Items.Count; j++)
            {

                lstbx_formname.Items[j].Selected = false;
                lstbx_formname.Items[j].Attributes.Remove("disabled");
            }
        }
        else
        {
            lstbx_Module.Attributes.Remove("disabled");
            lstbx_formname.Attributes.Remove("disabled");
            for (int j = 0; j < lstbx_Module.Items.Count; j++)
            {

                lstbx_Module.Items[j].Selected = false;
                lstbx_Module.Items[j].Attributes.Remove("disabled");
            }
            string qury = "select form_name from web_tp_roletype where del_flag=0 and role_id='" + ddlRole.SelectedValue.ToString() + "'";
            DataTable dt = cls.fillDataTable(qury);
            string formid = dt.Rows[0]["form_name"].ToString();
            string[] formid_list = formid.Split(',');
            if (dt.Rows.Count > 0)
            {
                string qury2 = "select STRING_AGG( convert(int,mod_id),',') as modulename from  Register_Form where Form_id in (" + formid + ")";
                DataTable dt2 = cls.fillDataTable(qury2);
                string modid = dt2.Rows[0]["modulename"].ToString();
                string[] modlist = modid.Split(',');
                for (int i = 0; i < modlist.Length; i++)
                {
                    for (int j = 0; j < lstbx_Module.Items.Count; j++)
                    {
                        if (modlist[i].Equals(lstbx_Module.Items[j].Value))
                        {
                            lstbx_Module.Items[j].Selected = true;
                            lstbx_Module.Items[j].Attributes.Add("disabled", "disabled");
                            //lstbx_Module.Items[j].Enabled = false;                                       
                        }
                    }
                }

                bool m = false;
                string z = "";
                for (int i = 0; i < lstbx_Module.Items.Count; i++)
                {
                    if (lstbx_Module.Items[i].Selected == true)
                    {
                        m = true;
                    }

                }
                for (int i = 0; i < lstbx_Module.Items.Count; i++)
                {
                    if (lstbx_Module.Items[i].Selected)
                    {
                        if (z == "")
                        {
                            z = "" + lstbx_Module.Items[i].Value + "";

                        }
                        else
                        {

                            z = z + "," + lstbx_Module.Items[i].Value + "";
                        }
                    }
                }

                if (m)
                {
                    if (z != "")
                    {


                        lstbx_formname.Enabled = true;
                        string frmname = "select * from Register_Form where del_flag=0 and mod_id in(" + z + ")";
                        DataTable dt4 = cls.fillDataTable(frmname);
                        lstbx_formname.DataTextField = dt4.Columns["Form_name"].ToString();
                        lstbx_formname.DataValueField = dt4.Columns["Form_id"].ToString();
                        lstbx_formname.DataSource = dt4;
                        lstbx_formname.DataBind();
                        for (int i = 0; i < formid_list.Length; i++)
                        {
                            for (int j = 0; j < lstbx_formname.Items.Count; j++)
                            {
                                if (formid_list[i].Equals(lstbx_formname.Items[j].Value))
                                {
                                    lstbx_formname.Items[j].Selected = true;
                                    lstbx_formname.Items[j].Attributes.Add("disabled", "disabled");
                                    //lstbx_formname.Items[j].Enabled = false;
                                }


                            }


                        }
                    }

                }
            }


        }




    }

    //protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlRole.SelectedIndex == 0)
    //    {
    //        lstbx_Module.Attributes.Add("disabled", "");
    //        lstbx_formname.Attributes.Add("disabled", "");
    //        for (int j = 0; j < lstbx_Module.Items.Count; j++)
    //        {

    //            lstbx_Module.Items[j].Selected = false;
    //            lstbx_Module.Items[j].Attributes.Remove("disabled");
    //        }
    //        for (int j = 0; j < lstbx_formname.Items.Count; j++)
    //        {

    //            lstbx_formname.Items[j].Selected = false;
    //            lstbx_formname.Items[j].Attributes.Remove("disabled");
    //        }
    //    }
    //    else
    //    {
    //        lstbx_Module.Attributes.Remove("disabled");
    //        lstbx_formname.Attributes.Remove("disabled");
    //        for (int j = 0; j < lstbx_Module.Items.Count; j++)
    //        {

    //            lstbx_Module.Items[j].Selected = false;
    //            lstbx_Module.Items[j].Attributes.Remove("disabled");
    //        }
    //        string qury = "select form_name from web_tp_roletype where del_flag=0 and role_id='" + ddlRole.SelectedValue.ToString() + "'";
    //        DataTable dt = cls.fillDataTable(qury);
    //        string formid = dt.Rows[0]["form_name"].ToString();
    //        string[] formid_list = formid.Split(',');
    //        if (dt.Rows.Count > 0)
    //        {
    //            string qury2 = "select STRING_AGG( convert(int,mod_id),',') as modulename from  Register_Form where Form_id in (" + formid + ")";
    //            DataTable dt2 = cls.fillDataTable(qury2);
    //            string modid = dt2.Rows[0]["modulename"].ToString();
    //            string[] modlist = modid.Split(',');
    //            for (int i = 0; i < modlist.Length; i++)
    //            {
    //                for (int j = 0; j < lstbx_Module.Items.Count; j++)
    //                {
    //                    if (modlist[i].Equals(lstbx_Module.Items[j].Value))
    //                    {
    //                        lstbx_Module.Items[j].Selected = true;
    //                        lstbx_Module.Items[j].Attributes.Add("disabled", "disabled");
    //                        //lstbx_Module.Items[j].Enabled = false;                                       
    //                    }
    //                }
    //            }

    //            bool m = false;
    //            string z = "";
    //            for (int i = 0; i < lstbx_Module.Items.Count; i++)
    //            {
    //                if (lstbx_Module.Items[i].Selected == true)
    //                {
    //                    m = true;
    //                }

    //            }
    //            for (int i = 0; i < lstbx_Module.Items.Count; i++)
    //            {
    //                if (lstbx_Module.Items[i].Selected)
    //                {
    //                    if (z == "")
    //                    {
    //                        z = "" + lstbx_Module.Items[i].Value + "";

    //                    }
    //                    else
    //                    {

    //                        z = z + "," + lstbx_Module.Items[i].Value + "";
    //                    }
    //                }
    //            }

    //            if (m)
    //            {
    //                if (z != "")
    //                {


    //                    lstbx_formname.Enabled = true;
    //                    string frmname = "select * from Register_Form where del_flag=0 and mod_id in(" + z + ")";
    //                    DataTable dt4 = cls.fillDataTable(frmname);
    //                    lstbx_formname.DataTextField = dt4.Columns["Form_name"].ToString();
    //                    lstbx_formname.DataValueField = dt4.Columns["Form_id"].ToString();
    //                    lstbx_formname.DataSource = dt4;
    //                    lstbx_formname.DataBind();
    //                    for (int i = 0; i < formid_list.Length; i++)
    //                    {
    //                        for (int j = 0; j < lstbx_formname.Items.Count; j++)
    //                        {
    //                            if (formid_list[i].Equals(lstbx_formname.Items[j].Value))
    //                            {
    //                                lstbx_formname.Items[j].Selected = true;
    //                                lstbx_formname.Items[j].Attributes.Add("disabled", "disabled");
    //                                //lstbx_formname.Items[j].Enabled = false;
    //                            }


    //                        }


    //                    }
    //                }

    //            }
    //        }


    //    }

    //    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "func", "$('[id*=txtDOJ]').datetimepicker({changeMonth: false,changeYear: false, timepicker: false,format: 'd-m-Y'}); ", true);


    //}


    protected void btnsave_Click(object sender, EventArgs e)
    {
        string col2 = "";
        string z = "";
        from_select = "";
        is_grup_select = "";
        for (int i = 0; i < lstgroup.Items.Count; i++)
        {
            if (lstgroup.Items[i].Selected)
            {
                is_grup_select = "true";
            }

        }
        for (int i = 0; i < lstgroup.Items.Count; i++)
        {
            if (lstgroup.Items[i].Selected)
            {
                if (z == "")
                {
                    z = "" + lstgroup.Items[i].Value + "";

                }
                else
                {

                    z = z + "," + lstgroup.Items[i].Value + "";
                }
            }
        }
        string hh = "";
        string f = "";
        for (int i = 0; i < lstbx_formname.Items.Count; i++)
        {
            if (lstbx_formname.Items[i].Selected)
            {
                f = "" + lstbx_formname.Items[i].Value + "";
            }
            else
            {
                f = f + "," + lstbx_formname.Items[i].Value + "";

            }

        }


        if (btnsave.Text == "Update")
        {

            bool phychk;
            if (chkbx_phys.Checked == true)
            {
                phychk = true;
            }
            else
            {
                phychk = false;
            }
            bool mail2 = false;


            string mail = txtemail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            if (mail.Contains("@") && mail.Contains("."))
            {
                mail2 = true;
            }
            else
            {
                mail2 = regex.IsMatch(mail);
                //if (!mail2)
                //{

                //}
            }

            if (ddlcat.SelectedValue != "OPEN")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Caste.','danger')", true);
                ddlcast.Focus();

            }
            else
            {
                ddlcast.Enabled = false;
            }

            if (txtfirstname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter First Name','danger')", true);
                txtfirstname.Focus();
            }
            else if (txtmiddlename.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Middle Name','danger')", true);
                txtmiddlename.Focus();

            }
            else if (txtmothername.Text.Trim() == "")
            {
                txtmothername.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Mother Name','danger')", true);

            }
            //=====
            else if (rad_female.Checked == false && rad_gender.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Gender.','danger')", true);

            }
            else if (txtdob.Text.Trim() == "")
            {
                txtdob.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter  Date of Birth.','danger')", true);
            }
            else if (txtDOJ.Text.Trim() == "")
            {
                txtDOJ.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Date of Joining.','danger')", true);
            }

            else if (txtemail.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Email ID.','danger')", true);

            }
            else if (!mail2)
            {
                txtemail.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Invalid Email', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                return;
            }
            else if (txtmobno.Text.Trim() == "")
            {
                txtmobno.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Mobile No.','danger')", true);
            }
            else if (txtmobno.Text.Trim().Length < 10)
            {
                txtmobno.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter 10 digit Mobile No.','danger')", true);
            }
            else if (txtmobile.Text.Trim() == "")
            {
                txtmobile.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Alternate Mobile no.','danger')", true);
            }
            else if (txtmobile.Text.Trim().Length < 10)
            {
                txtmobno.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter 10 digit Alternate Mobile No.','danger')", true);
            }
            else if (ddlmart.SelectedIndex == 0)
            {
                ddlmart.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Marital Status.','danger')", true);

            }
            else if (ddlbloodgroup.SelectedIndex == 0)
            {
                ddlbloodgroup.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Blood Group.','danger')", true);
            }
            else if (ddlnation.SelectedIndex == 0)
            {
                ddlnation.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Nationality.','danger')", true);

            }

            else if (ddl_rel.SelectedIndex == 0)
            {
                ddl_rel.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Religion.','danger')", true);

            }
            else if (ddlcat.SelectedIndex == 0)
            {
                ddlcat.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Category.','danger')", true);
            }
            else if (ddlcast.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Caste.','danger')", true);
                ddlcast.Focus();
            }
            else if (txtaddress.Text.Trim() == "")
            {
                txtaddress.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Address.','danger')", true);
            }
            else if (txtcity.Text.Trim() == "")
            {
                txtcity.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter City.','danger')", true);

            }
            else if (ddlstate.SelectedIndex == 0)
            {
                ddlstate.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select State.','danger')", true);
            }
            else if (TXTPIN.Text.Trim() == "")
            {
                TXTPIN.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Pin Code.','danger')", true);
            }
            else if (txtadd.Text.Trim() == "")
            {
                txtadd.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Permanent Address.','danger')", true);

            }
            else if (txtpercity.Text.Trim() == "")
            {
                txtpercity.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Permanent City.','danger')", true);
            }
            else if (ddlperState.SelectedIndex == 0)
            {
                ddlperState.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select State','danger')", true);
            }

            else if (txtperpin.Text.Trim() == "")
            {
                txtperpin.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Permanent Pincode','danger')", true);

            }
            else if (txtannualsal.Text.Trim() == "")
            {
                txtannualsal.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Annual Salary.','danger')", true);
            }
            else if (txtaadhar.Text.Trim() == "")
            {
                txtaadhar.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Aadhaar Card No.','danger')", true);
            }
            else if (txtaadhar.Text.Trim().Length < 12)
            {
                txtaadhar.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter 12 digit Aadhaar Card No.','danger')", true);
            }
            else if (txtpan.Text.Trim() == "")
            {
                txtpan.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Pan Card No.','danger')", true);
            }
            else if (txtpan.Text.Trim().Length < 10)
            {
                txtpan.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter 10 digit  Pan Card No.','danger')", true);
            }
            else if (txt_pf.Text.Trim() == "")
            {

                txt_pf.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter PF No.','danger')", true);
            }
            else if (txt_pf.Text.Trim().Length < 20)
            {

                txt_pf.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter 20 digit PF No.','danger')", true);
            }
            else if (ddl_stafftype.SelectedIndex == 0)
            {
                ddl_stafftype.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Staff type.','danger')", true);
            }
            else if (is_grup_select == "")
            {
                lstgroup.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Group.','danger')", true);
            }
            else if (ddldepart1.SelectedIndex == 0)
            {
                ddldepart1.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Department','danger')", true);
            }

            else if (ddlDesignation1.SelectedIndex == 0)
            {
                ddlDesignation1.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Designation.','danger')", true);
            }
            else if (ddlRole.SelectedIndex == 0)
            {
                ddlRole.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Role.','danger')", true);
            }

            else
            {



                try
                {
                    string dtae = txtdob.Text;
                    DateTime date2;
                    //DateTime dob1 = Convert.ToDateTime(txtdob.Text.ToString());
                    //DateTime doj1 = Convert.ToDateTime(txtDOJ.Text.ToString());

                    string formid = "";
                    string sp_nam = "m_emp_personal";
                    using (SqlCommand cmd = new SqlCommand(sp_nam, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@emp_fname", txtfirstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_mname", txtmiddlename.Text.Trim());
                        if (txtlastname.Text.Trim() == "")
                        {
                            cmd.Parameters.AddWithValue("@emp_lname", null);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@emp_lname", txtlastname.Text.Trim());

                        }

                        cmd.Parameters.AddWithValue("@emp_mother_name", txtmothername.Text.Trim());


                        //cmd.Parameters.AddWithValue("@emp_dob", txtdob.Text.Trim());
                        //cmd.Parameters.AddWithValue("@emp_doj", txtDOJ.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_doj", txtDOJ.Text);
                        cmd.Parameters.AddWithValue("@emp_dob", txtdob.Text);

                        cmd.Parameters.AddWithValue("@emp_blood_group", ddlbloodgroup.SelectedValue.ToString());
                        if (rad_female.Checked)
                        {
                            cmd.Parameters.AddWithValue("@emp_gender", "Female");
                        }
                        else { cmd.Parameters.AddWithValue("@emp_gender", "Male"); }
                        //  cmd.Parameters.AddWithValue("@emp_gender", rad_gender.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_maritial_status", ddlmart.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_nationality", ddlnation.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_handicaped", phychk);
                        cmd.Parameters.AddWithValue("@emp_category", ddlcat.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_cast", ddlcast.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_photo", null);

                        cmd.Parameters.AddWithValue("@emp_to_date", DBNull.Value);
                        cmd.Parameters.AddWithValue("@emp_sign", null);
                        cmd.Parameters.AddWithValue("@emp_phone1", null);
                        cmd.Parameters.AddWithValue("@emp_phone2", null);
                        cmd.Parameters.AddWithValue("@emp_mobile1", txtmobno.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@emp_mobile2", txtmobile.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@emp_email", txtemail.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@emp_p_f_num", txt_pf.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_pan_card_no", txtpan.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_tds_num", null);
                        cmd.Parameters.AddWithValue("@emp_dricing_lic_no", null);
                        cmd.Parameters.AddWithValue("@emp_pan_no", txtpan.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_passport_no", null);
                        cmd.Parameters.AddWithValue("@emp_address_curr", txtaddress.Text.Trim() + "~" + txtcity.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_state_curr", ddlstate.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_pincode_curr", TXTPIN.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_address_per", txtadd.Text.Trim() + "~" + txtpercity.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_state_per", ddlperState.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_pincode_per", txtperpin.Text.Trim());
                        cmd.Parameters.AddWithValue("@date_of_leaving", null);
                        cmd.Parameters.AddWithValue("@del_flag", 0);
                        cmd.Parameters.AddWithValue("@del_dt", null);
                        cmd.Parameters.AddWithValue("@dept_id", ddldepart1.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_aadhar_no", txtaadhar.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_religion", ddl_rel.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_id", txtEmpId.Text.Trim());
                        cmd.Parameters.AddWithValue("@type", "Update");
                        con.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            string rol = ddlRole.SelectedValue.ToString();
                            for (int i = 0; i < lstbx_formname.Items.Count; i++)
                            {

                                if (lstbx_formname.Items[i].Selected)
                                {
                                    if (hh == "")
                                    {
                                        hh = "" + lstbx_formname.Items[i].Value + "";
                                    }
                                    else
                                    {
                                        hh = hh + "," + lstbx_formname.Items[i].Value + "";
                                    }
                                }
                            }
                            string[] hh1 = hh.Split(',');  
                            string[] hh1copy = hh.Split(',');
                            List<string> list = new List<string>(hh1copy);

                            string qury1 = "select form_name from web_tp_roletype where role_id='" + ddlRole.SelectedValue.ToString() + "'";
                            DataTable dt3 = cls.fillDataTable(qury1);
                            if (dt3.Rows.Count > 0)
                            {
                                formid = dt3.Rows[0]["form_name"].ToString();
                            }
                            string[] formid2 = formid.Split(',');
                            for (int i = 0; i < hh1.Length; i++)
                            {
                                for (int j = 0; j < formid2.Length; j++)
                                {
                                    if (hh1[i].Equals(formid2[j]))
                                    {
                                        list.Remove(formid2[j]);

                                    }
                                }

                            }
                            string grup_nam = "";
                            for (int i = 0; i < lstgroup.Items.Count; i++)
                            {
                                if (lstgroup.Items[i].Selected)
                                {
                                    if (grup_nam == "")
                                    {
                                        grup_nam = "" + lstgroup.Items[i].Value + "";

                                    }
                                    else
                                    {

                                        grup_nam = grup_nam + "," + lstgroup.Items[i].Value + "";
                                    }
                                }
                            }
                            string col = string.Join(",", list);
                            string webtp_login = "update web_tp_login set col2='" + col + "',group_ids='" + grup_nam + "' where emp_id='" + txtEmpId.Text.Trim() + "'";
                            string salary = "update employee_department_des set actual_basic_salary='" + txtannualsal.Text.Trim() + "' where emp_id='" + txtEmpId.Text.Trim() + "'";
                            cls.DMLqueries(salary);
                            if (cls.DMLqueries(webtp_login))
                            {
                                msg = "true";
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Employee ID Updated successfully.','success')", true);
                                btnsave.Text = "Save";

                            }
                        }
                        else
                        {
                            msg = "false";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong','danger')", true);
                            clean();
                        }
                        con.Close();
                    }
                    clean();
                }
                catch (Exception h)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + h + "','danger')", true);
                    clean();
                }
            }
        }


        else if (btnsave.Text == "Save")
        {
            string h = "";
            for (int i = 0; i < lstbx_formname.Items.Count; i++)
            {
                if (lstbx_formname.Items[i].Selected)
                {
                    if (h == "")
                    {
                        h = "" + lstbx_formname.Items[i].Value + "";

                    }
                    else
                    {

                        h = h + "," + lstbx_formname.Items[i].Value + "";
                    }
                }
            }

            try
            {
                bool phychk;
                if (chkbx_phys.Checked == true)
                {
                    phychk = true;
                }
                else
                {
                    phychk = false;
                }
                bool mail2 = false;


                string mail = txtemail.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                if (mail.Contains("@") && mail.Contains("."))
                {
                    mail2 = true;
                }
                else
                {
                    mail2 = regex.IsMatch(mail);
                    //if (!mail2)
                    //{

                    //}
                }

                if (ddlcat.SelectedValue != "OPEN")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Caste.','danger')", true);
                    ddlcast.Focus();

                }
                else
                {
                    ddlcast.Enabled = false;
                }

                if (txtfirstname.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter First Name','danger')", true);
                    txtfirstname.Focus();
                }
                else if (txtmiddlename.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Middle Name','danger')", true);
                    txtmiddlename.Focus();

                }
                else if (txtmothername.Text.Trim() == "")
                {
                    txtmothername.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Mother Name','danger')", true);

                }
                else if (rad_female.Checked == false && rad_gender.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Check Gender.','danger')", true);

                }
                else if (txtdob.Text.Trim() == "")
                {
                    txtdob.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter  Date of Birth.','danger')", true);
                }
                else if (txtDOJ.Text.Trim() == "")
                {
                    txtDOJ.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Date of Joining.','danger')", true);
                }

                else if (txtemail.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Email ID.','danger')", true);

                }
                else if (!mail2)
                {
                    txtemail.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Invalid Email', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                    return;
                }
                else if (txtmobno.Text.Trim() == "")
                {
                    txtmobno.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Mobile No.','danger')", true);
                }
                else if (txtmobno.Text.Trim().Length < 10)
                {
                    txtmobno.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter 10 digit Mobile No.','danger')", true);
                }
                else if (txtmobile.Text.Trim() == "")
                {
                    txtmobile.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Alternate Mobile no.','danger')", true);
                }
                else if (txtmobile.Text.Trim().Length < 10)
                {
                    txtmobno.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter 10 digit Alternate Mobile No.','danger')", true);
                }
                else if (ddlmart.SelectedIndex == 0)
                {
                    ddlmart.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Marital Status.','danger')", true);

                }
                else if (ddlbloodgroup.SelectedIndex == 0)
                {
                    ddlbloodgroup.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Blood Group.','danger')", true);
                }
                else if (ddlnation.SelectedIndex == 0)
                {
                    ddlnation.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Nationality.','danger')", true);

                }

                else if (ddl_rel.SelectedIndex == 0)
                {
                    ddl_rel.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Religion.','danger')", true);

                }
                else if (ddlcat.SelectedIndex == 0)
                {
                    ddlcat.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Category.','danger')", true);
                }
                else if (ddlcast.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Caste.','danger')", true);
                    ddlcast.Focus();
                }
                else if (txtaddress.Text.Trim() == "")
                {
                    txtaddress.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Address.','danger')", true);
                }
                else if (txtcity.Text.Trim() == "")
                {
                    txtcity.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter City.','danger')", true);

                }
                else if (ddlstate.SelectedIndex == 0)
                {
                    ddlstate.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select State.','danger')", true);
                }
                else if (TXTPIN.Text.Trim() == "")
                {
                    TXTPIN.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Pin Code.','danger')", true);
                }
                else if (txtadd.Text.Trim() == "")
                {
                    txtadd.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Permanent Address.','danger')", true);

                }
                else if (txtpercity.Text.Trim() == "")
                {
                    txtpercity.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Permanent City.','danger')", true);
                }
                else if (ddlperState.SelectedIndex == 0)
                {
                    ddlperState.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select State','danger')", true);
                }

                else if (txtperpin.Text.Trim() == "")
                {
                    txtperpin.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Permemnent Pincode','danger')", true);

                }
                else if (txtannualsal.Text.Trim() == "")
                {
                    txtannualsal.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Annual Salary.','danger')", true);
                }
                else if (txtaadhar.Text.Trim() == "")
                {
                    txtaadhar.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Aadhaar Card No.','danger')", true);
                }
                else if (txtaadhar.Text.Trim().Length < 12)
                {
                    txtaadhar.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter 12 digit Aadhaar Card No.','danger')", true);
                }
                else if (txtpan.Text.Trim() == "")
                {
                    txtpan.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Pan Card.','danger')", true);
                }
                else if (txtpan.Text.Trim().Length < 10)
                {
                    txtpan.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter 10 digit  Pan Card No.','danger')", true);
                }
                else if (txt_pf.Text.Trim() == "")
                {

                    txt_pf.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter PF No.','danger')", true);
                }
                else if (txt_pf.Text.Trim().Length < 20)
                {

                    txt_pf.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter 20 digit PF No.','danger')", true);
                }
                else if (ddl_stafftype.SelectedIndex == 0)
                {
                    ddl_stafftype.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Staff type.','danger')", true);
                }
                else if (is_grup_select == "")
                {
                    lstgroup.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Group.','danger')", true);
                }
                else if (ddldepart1.SelectedIndex == 0)
                {
                    ddldepart1.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Department','danger')", true);
                }

                else if (ddlDesignation1.SelectedIndex == 0)
                {
                    ddlDesignation1.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Designation.','danger')", true);
                }
                else if (ddlRole.SelectedIndex == 0)
                {
                    ddlRole.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Role.','danger')", true);
                }

                else
                {




                    string procnam = "m_emp_personal";
                    DateTime date1;

                    using (SqlCommand cmd = new SqlCommand(procnam, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // DateTime CreatdDate = DateTime.ParseExact(txtdob.Text, "YYYY-MM-DD hh: mm: ss.nnn", System.Globalization.CultureInfo.InvariantCulture);
                        //DateTime dob=Convert.ToDateTime(txtdob.Text.ToString());
                        //DateTime doj = Convert.ToDateTime(txtDOJ.Text.ToString());
                        // DateTime.TryParse(txtDOJ.Text.Trim(), out date1)

                        cmd.Parameters.AddWithValue("@emp_id", "");

                        cmd.Parameters.AddWithValue("@emp_fname", txtfirstname.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_mname", txtmiddlename.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_lname", txtlastname.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_mother_name", txtmothername.Text.Trim());
                        //cmd.Parameters.AddWithValue("@emp_dob", DateTime.TryParse(txtdob.Text, out date1));
                        //cmd.Parameters.AddWithValue("@emp_doj", DateTime.TryParse(txtDOJ.Text, out date1));
                        cmd.Parameters.AddWithValue("@emp_dob", txtdob.Text);
                        cmd.Parameters.AddWithValue("@emp_doj", txtDOJ.Text);
                        cmd.Parameters.AddWithValue("@emp_blood_group", ddlbloodgroup.SelectedValue.ToString());
                        if (rad_female.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@emp_gender", "Female");
                        }
                        if (rad_gender.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@emp_gender", "Male");
                        }
                        //cmd.Parameters.AddWithValue("@emp_gender", rad_gender.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_maritial_status", ddlmart.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_nationality", ddlnation.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_handicaped", phychk);
                        cmd.Parameters.AddWithValue("@emp_category", ddlcat.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_cast", ddlcast.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_photo", null);
                        //cmd.Parameters.AddWithValue("@emp_to_date",  null);
                        cmd.Parameters.AddWithValue("@emp_sign", null);
                        cmd.Parameters.AddWithValue("@emp_phone1", null);
                        cmd.Parameters.AddWithValue("@emp_phone2", null);
                        cmd.Parameters.AddWithValue("@emp_mobile1", txtmobno.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@emp_mobile2", txtmobile.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@emp_email", txtemail.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@emp_p_f_num", txt_pf.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_pan_card_no", txtpan.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_tds_num", null);
                        cmd.Parameters.AddWithValue("@emp_dricing_lic_no", null);
                        cmd.Parameters.AddWithValue("@emp_pan_no", txtpan.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_passport_no", null);
                        cmd.Parameters.AddWithValue("@emp_address_curr", txtaddress.Text.Trim() + "~" + txtcity.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_state_curr", ddlstate.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_pincode_curr", TXTPIN.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_address_per", txtadd.Text.Trim() + "~" + txtpercity.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_state_per", ddlperState.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_pincode_per", txtperpin.Text.Trim());
                        cmd.Parameters.AddWithValue("@date_of_leaving", null);
                        cmd.Parameters.AddWithValue("@del_flag", 0);
                        cmd.Parameters.AddWithValue("@del_dt", 0);
                        cmd.Parameters.AddWithValue("@dept_id", ddldepart1.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_aadhar_no", txtaadhar.Text.Trim());
                        cmd.Parameters.AddWithValue("@emp_religion", ddl_rel.SelectedValue.ToString());
                        //---------------------
                        cmd.Parameters.AddWithValue("@emp_des_id", ddlDesignation1.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@emp_from_date", DateTime.TryParse(txtDOJ.Text, out date1));
                        cmd.Parameters.AddWithValue("@emp_to_date", null);
                        cmd.Parameters.AddWithValue("@emp_del_flag", 1);
                        cmd.Parameters.AddWithValue("@actual_basic_salary", txtannualsal.Text.Trim());
                        cmd.Parameters.AddWithValue("@type_dept", "Insert_Update");
                        //--------------
                        cmd.Parameters.AddWithValue("@role_id", ddlRole.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@group_ids", z);
                        cmd.Parameters.AddWithValue("@col1", ddl_stafftype.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@col2", "");
                        cmd.Parameters.AddWithValue("@col3", "");
                        cmd.Parameters.AddWithValue("@mod_date", null);
                        cmd.Parameters.AddWithValue("@type", "Insert");

                        con.Open();

                        SqlDataReader dReader;
                        dReader = cmd.ExecuteReader();
                        //cmd.ExecuteNonQuery();
                        if ((dReader.Read()))
                        {
                            string bb = dReader[0].ToString();
                            string formnamelist = "";
                            string formid2 = "";
                            string savrol = ddlRole.SelectedValue.ToString();
                            for (int i = 0; i < lstbx_formname.Items.Count; i++)
                            {

                                if (lstbx_formname.Items[i].Selected)
                                {
                                    if (formnamelist == "")
                                    {
                                        formnamelist = "" + lstbx_formname.Items[i].Value + "";
                                    }
                                    else
                                    {
                                        formnamelist = formnamelist + "," + lstbx_formname.Items[i].Value + "";
                                    }
                                }
                            }
                            string[] hh2 = formnamelist.Split(',');
                            string[] hh2copy = formnamelist.Split(',');
                            List<string> list1 = new List<string>(hh2copy);

                            string qury1 = "select form_name from web_tp_roletype where role_id='" + ddlRole.SelectedValue.ToString() + "'";
                            DataTable dt3 = cls.fillDataTable(qury1);
                            if (dt3.Rows.Count > 0)
                            {
                                formid2 = dt3.Rows[0]["form_name"].ToString();
                            }
                            string[] formid3 = formid2.Split(',');
                            for (int i = 0; i < hh2.Length; i++)
                            {
                                for (int j = 0; j < formid3.Length; j++)
                                {
                                    if (hh2[i].Equals(formid3[j]))
                                    {
                                        list1.Remove(formid3[j]);

                                    }
                                }

                            }

                            string col = string.Join(",", list1);
                            string webtp_login = "update web_tp_login set col2='" + col + "' where emp_id='" + bb + "'";

                            if (cls.DMLqueries(webtp_login))
                            {

                                clean();
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Employee ID is " + bb + "','success')", true);
                                msg = "true";
                                /// ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Employee ID Updated.','success')", true);
                                btnsave.Text = "Save";

                            }


                            //string webtp_login = "update web_tp_login set col2='"+h+"' where emp_id='"+bb+"'";
                            //cls.DMLqueries(webtp_login);

                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Employee ID is " + bb + " ,'success')", true);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception d)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
            }
        }
    }

    protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
        if (ddlcat.SelectedIndex == 0)
        {
            ddlcast.Items.Clear();
        }

        else
        {

            string caste = "select distinct child from   State_category_details where parent='" + ddlcat.SelectedValue.ToString() + "' and del_flag=0";
            DataTable dtcast = cls.fillDataTable(caste);
            ddlcast.DataTextField = dtcast.Columns["child"].ToString();
            ddlcast.DataValueField = dtcast.Columns["child"].ToString();
            ddlcast.DataSource = dtcast;
            ddlcast.DataBind();
            ddlcast.Items.Insert(0, new ListItem("--Select--", "na"));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true);
            ddlcast.Enabled = true;
            if (ddlcat.SelectedValue == "OPEN")
            {
                ddlcast.Enabled = false;
            }
        }
    }


    protected void grd_dept_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow gvrow = grd_dept.Rows[index];
                Label grdlbldeptname = (Label)grd_dept.Rows[index].FindControl("grd_dept_nam");
                Label grdlbldeptpre = (Label)grd_dept.Rows[index].FindControl("grd_pre");
                Label grblbldeo_id = (Label)grd_dept.Rows[index].FindControl("lbldeptid");
                txtdepid.Text = grblbldeo_id.Text;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "adddept", "<script>$('#adddept').modal('show');</script>", false);
                dep_name.Text = grdlbldeptname.Text.ToString();
                dpt_prefix.Text = grdlbldeptpre.Text.ToString();
                btn_save.Text = "Update";

            }
            if (e.CommandName == "dept_Delete")
            {
                con.Open();
                string dlflg = "";
                string proc_name = "MDepartment";
                int index2 = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvrdept = grd_dept.Rows[index2];
                Label grdlbldeptnamedel = (Label)grd_dept.Rows[index2].FindControl("grd_dept_nam");
                Label grdlbldepid = (Label)grd_dept.Rows[index2].FindControl("lbldeptid");
                Label grdlblpre = (Label)grd_dept.Rows[index2].FindControl("grd_pre");
                Label grdlbl_dtest = (Label)grd_dept.Rows[index2].FindControl("lbldate");
                Label grdlbl_delf = (Label)grd_dept.Rows[index2].FindControl("lbldelfg");
                if (grdlbl_delf.Text == "True")
                {
                    dlflg = "1";
                }
                else { dlflg = "0"; }
                Label grdlbl_currdt = (Label)grd_dept.Rows[index2].FindControl("lblcurr");
                Label grdlbl_moddt = (Label)grd_dept.Rows[index2].FindControl("lblmodt");

                using (SqlCommand cmd1 = new SqlCommand(proc_name, con))
                {

                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Dept_id", grdlbldepid.Text);
                    cmd1.Parameters.AddWithValue("@Department_name", grdlbldeptnamedel.Text);
                    cmd1.Parameters.AddWithValue("@date_establishment", grdlbl_dtest.Text);
                    cmd1.Parameters.AddWithValue("@del_flag", dlflg);
                    cmd1.Parameters.AddWithValue("@PREFIX", grdlblpre.Text);
                    cmd1.Parameters.AddWithValue("@type", "Delete");
                    // con.Open();

                    cmd1.ExecuteNonQuery();
                    if (cmd1.ExecuteNonQuery() > 0)
                    {
                        msg = "true";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Department Deleted.','success')", true);
                        deptload();
                    }
                    else
                    {
                        msg = "false";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Department Deletion Restricted since employees are Designated. ','danger')", true);
                    }
                    con.Close();
                }
            }

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }



    protected void grd_dept_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void grd_dept_RowEditing(object sender, GridViewEditEventArgs e)
    {


    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        string dtea = "select getdate() AS DAT";
        DataTable dtdtdt = cls.fillDataTable(dtea);
        string date1 = dtdtdt.Rows[0]["DAT"].ToString();
        if (btn_save.Text == "Save")
        {
            if (dep_name.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Department Name','danger')", true);
                //  return;
            }
            else if (dpt_prefix.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Department Prefix.','danger')", true);
                // return;
            }
            else
            {

                SqlCommand cmd = new SqlCommand("MDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dept_id", "");
                cmd.Parameters.AddWithValue("@Department_name", dep_name.Text.Trim());
                cmd.Parameters.AddWithValue("@date_establishment", date1);
                cmd.Parameters.AddWithValue("@del_flag", 0);
                cmd.Parameters.AddWithValue("@PREFIX", dpt_prefix.Text.Trim());
                con.Open();
                cmd.Parameters.AddWithValue("@type", "insert");
                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd);
                DataTable dtsp = new DataTable();
                adapter2.Fill(dtsp);
                string resultdep = "";
                resultdep = dtsp.Rows[0][0].ToString();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + resultdep + "','success')", true);
                con.Close();
                dep_name.Text = "";
                dpt_prefix.Text = "";
                deptload();
                dept_ddl();
            }

        }
        else
        {
            if (btn_save.Text == "Update")
            {
                if (dep_name.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Department Name','danger')", true);
                }
                else if (dpt_prefix.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Department Prefix.','danger')", true);

                }
                else
                {
                    string proc_name = "MDepartment";
                    using (SqlCommand cmd = new SqlCommand(proc_name, con))
                    {
                        string sp_type = "update";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Dept_id", txtdepid.Text);
                        cmd.Parameters.AddWithValue("@Department_name", dep_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@date_establishment", date1);
                        cmd.Parameters.AddWithValue("@del_flag", 0);
                        cmd.Parameters.AddWithValue("@PREFIX", dpt_prefix.Text.Trim());
                        cmd.Parameters.AddWithValue("@type", "update");
                        con.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            msg = "true";
                            btn_des.Text = "Add";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Department Updated Successful.','success')", true);
                            deptload();
                        }
                        else
                        {
                            msg = "false";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something wen wrong','danger')", true);
                        }
                        con.Close();
                    }
                    dept_ddl();
                }
            }

        }

    }

    protected void btn_clear_Click(object sender, EventArgs e)
    {
        dep_name.Text = "";
        dpt_prefix.Text = "";
        btn_save.Text = "Save";
    }

    protected void grddes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "desedit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow grverow = grddes.Rows[index];
            Label grdlbldesname = (Label)grddes.Rows[index].FindControl("grdlbl_des");
            Label grdlbldesid = (Label)grddes.Rows[index].FindControl("lbldesgid");
            Label grdlbldelfg = (Label)grddes.Rows[index].FindControl("lbldesgnation_delf");
            txtdesname.Text = grdlbldesname.Text.ToString();
            btn_des.Text = "Update";
            txtdes_id.Text = grdlbldesid.Text.ToString();
        }
        if (e.CommandName == "des_del")
        {
            con.Open();
            string proccname = "MDesignation";
            using (SqlCommand cmd = new SqlCommand(proccname, con))
            {
                string sptype = "Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Designation_ID", txtdes_id.Text);
                cmd.Parameters.AddWithValue("@Designation_Title", txtdesname.Text);
                cmd.Parameters.AddWithValue("@user_id", "Admin");
                cmd.Parameters.AddWithValue("@del_flag", 0);
                cmd.Parameters.AddWithValue("@type", sptype);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    msg = "true";
                    txtdesname.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Designation Deleted Successful.','success')", true);
                    desgload();
                }
                else
                {
                    msg = "false";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Designation Deletion Restricted since employees are desinated to this Desgination.','danger')", true);
                }
                con.Close();
            }

            designation();
        }
    }

    protected void btn_des_Click(object sender, EventArgs e)
    {
        if (btn_des.Text == "Add")
        {
            if (txtdesname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Designation Name','danger')", true);
            }
            else
            {
                string chk_dup = "select * from m_designation where Designation_Title='" + txtdesname.Text.Trim() + "' and del_flag=0 ";
                DataTable dt = cls.fillDataTable(chk_dup);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Designation Name Already Exist.','danger')", true);
                    txtdesname.Text = "";

                }
                else
                {
                    con.Open();
                    string proccname = "MDesignation";
                    using (SqlCommand cmd = new SqlCommand(proccname, con))
                    {
                        string sptype = "Insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Designation_ID", "");
                        cmd.Parameters.AddWithValue("@Designation_Title", txtdesname.Text);
                        cmd.Parameters.AddWithValue("@user_id", "Admin");
                        cmd.Parameters.AddWithValue("@del_flag", 0);
                        cmd.Parameters.AddWithValue("@type", sptype);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            msg = "true";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Designation Added Successful.','success')", true);
                            desgload();
                            txtdesname.Text = "";
                        }
                        else
                        {
                            msg = "false";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong','danger')", true);
                        }
                        con.Close();
                    }
                }

            }
            designation();
        }

        if (btn_des.Text == "Update")
        {
            if (txtdesname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Designation Name','danger')", true);
            }
            else
            {
                string chk_dup = "select * from m_designation where Designation_Title='" + txtdesname.Text.Trim() + "' and del_flag=0 ";
                DataTable dt = cls.fillDataTable(chk_dup);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Designation Name Already Exist.','danger')", true);
                    txtdesname.Text = "";

                }
                else
                {
                    con.Open();
                    string procd = "MDesignation";
                    using (SqlCommand cmd = new SqlCommand(procd, con))
                    {
                        string sptype = "Update";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Designation_ID", txtdes_id.Text);
                        cmd.Parameters.AddWithValue("@Designation_Title", txtdesname.Text);
                        cmd.Parameters.AddWithValue("@user_id", "Admin");
                        cmd.Parameters.AddWithValue("@del_flag", 0);
                        cmd.Parameters.AddWithValue("@type", sptype);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            msg = "true";
                            txtdesname.Text = "";
                            btn_des.Text = "Add";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Designation updated Successful.','success')", true);
                            desgload();
                        }
                        else
                        {
                            msg = "false";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong','danger')", true);
                        }
                        con.Close();
                    }
                }
            }
            designation();
        }
    }

    protected void btn_desclear_Click(object sender, EventArgs e)
    {
        txtdesname.Text = "";
        btn_des.Text = "Add";
    }

    protected void btn_editRole_Click(object sender, EventArgs e)
    {
        if (btn_editRole.Text == "Edit Role")
        {
            txt_rol.Text = "";
            btn_editRole.Text = "Define Role";
            btn_roladd.Text = "Add";
            btn_roladd.Enabled = false;
            grdrole.DataSource = null;
            grdrole.DataBind();
            role_roleName_webtp();

        }
        else
        {
            txt_rol.Text = "";
            btn_roladd.Enabled = true;
            btn_editRole.Text = "Edit Role";
            grddefine.DataSource = null;
            grddefine.DataBind();
            ROLE_FORMNAME();



        }
    }

    protected void btnrol_clear_Click(object sender, EventArgs e)
    {
        string X = "";
        txt_rol.Text = "";
        ROLE_FORMNAME();
        btn_editRole.Text = "Edit Role";
        btn_roladd.Text = "Add";
        btn_roladd.Enabled = true;
        foreach (GridViewRow row in grddefine.Rows)
        {
            if (grddefine.Rows.Count > 0)
            {
                grddefine.DataSource = null;
                grddefine.DataBind();
                break;
            }
        }
    }

    protected void grdrole_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grddefine_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grddefine_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "roleedit")
        {
            btn_roladd.Text = "Update";
            btn_editRole.Text = "Edit Role";
            btn_roladd.Enabled = true;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow grverow = grddefine.Rows[index];
            Label grdlbl_rolename = (Label)grddefine.Rows[index].FindControl("grdlbl_sr");
            Label grdlbl_roleId = (Label)grddefine.Rows[index].FindControl("grdlbl_roleid");
            string rol_edit = "select * from web_tp_roletype where role_id='" + grdlbl_roleId.Text + "' and del_flag=0";
            txt_rolid.Text = grdlbl_roleId.Text.ToString();
            txt_rol.Text = grdlbl_rolename.Text.ToString();
            DataTable dtedit = cls.fillDataTable(rol_edit);
            string fns = dtedit.Rows[0]["form_name"].ToString();
            grddefine.DataSource = null;
            grddefine.DataBind();
            ROLE_FORMNAME();

            string[] comsep = fns.Split(',');
            for (int i = 0; i < comsep.Length; i++)
            {
                foreach (GridViewRow gvr in grdrole.Rows)
                {
                    string str = ((Label)gvr.FindControl("grdlbl_formid")).Text;

                    if (comsep[i] == str)
                    {
                        CheckBox chk = (gvr.FindControl("chkbx_sel") as CheckBox);
                        chk.Checked = true;
                    }
                }
            }
        }
        if (e.CommandName == "roledelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow grvrowdel = grddefine.Rows[index];
            Label grdlbl_sr = (Label)grddefine.Rows[index].FindControl("grdlbl_sr");
            Label grlblril_id = (Label)grddefine.Rows[index].FindControl("grdlbl_roleid");
            string chckrole = "select * from web_tp_login where role_id = '" + grlblril_id.Text.Trim() + "' and Del_flag=0";
            DataTable roldt2 = cls.fillDataTable(chckrole);

            if (roldt2.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Role cant be deleted','danger')", true);
            }
            else
            {
                string deleterole = "update web_tp_roletype set del_flag=1 where role_name='" + grdlbl_sr.Text.ToString().Trim() + "'";
                if (cls.DMLqueries(deleterole))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Role Deleted Successful','success')", true);
                    role_roleName_webtp();
                    Roleload();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Role cant be deleted','success')", true);
                }
            }
        }
    }

    protected void btn_roladd_Click(object sender, EventArgs e)
    {
        string strr = "";
        foreach (GridViewRow gvvr in grdrole.Rows)
        {
            CheckBox chk = (gvvr.FindControl("chkbx_sel") as CheckBox);
            if (chk.Checked == true)
            {
                if (strr == "")
                {
                    strr = ((Label)gvvr.FindControl("grdlbl_formid")).Text;
                }
                else
                {
                    strr = strr + "," + ((Label)gvvr.FindControl("grdlbl_formid")).Text;
                }
            }
        }
        string chk_checkbx_checked = "";
        foreach (GridViewRow gvt in grdrole.Rows)
        {
            CheckBox chkw = (gvt.FindControl("chkbx_sel") as CheckBox);
            if (chkw.Checked == true)
            {
                chk_checkbx_checked = "True";
            }

        }
        if (btn_roladd.Text == "Add")
        {
            if (txt_rol.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Form Name','danger')", true);
            }
            else if (chk_checkbx_checked == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Forn name.','danger')", true);
            }
            else
            {
                string chkdup_rol = "Select * from web_tp_roletype where role_name='" + txt_rol.Text.Trim() + "' and del_flag=0";
                DataTable dtrol = cls.fillDataTable(chkdup_rol);
                if (dtrol.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Role with this name already exists','danger')", true);
                    txt_rol.Text = "";
                }
                else
                {
                    string roleinsert = "insert into web_tp_roletype(role_name, form_name, col1, col2, is_active, curr_date, del_flag) values('" + txt_rol.Text.Trim() + "', '" + strr + "', '', '', 1,getdate(), 0)";
                    if (cls.DMLqueries(roleinsert))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Role Added Successful.','success')", true);
                        txt_rol.Text = "";
                        ROLE_FORMNAME();
                        Roleload();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Role Added failed.','danger')", true);
                        txt_rol.Text = "";
                    }
                }
            }
        }

        if (btn_roladd.Text == "Update")
        {
            if (txt_rol.Text.Trim() == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Role Name.','danger')", true);
            }
            else
            {
                string updtrole_name = "update web_tp_roletype set form_name='" + strr + "' where del_flag=0 and role_id='" + txt_rolid.Text + "'";
                if (cls.DMLqueries(updtrole_name))
                {
                    btn_roladd.Text = "Add";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Role updation Successful.','success')", true);
                    txt_rol.Text = "";
                    ROLE_FORMNAME();
                    Roleload();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Role updation failed.','danger')", true);
                }
            }
        }
    }


    protected void txtEmpId_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string lstgrup = "";
            if (txtEmpId.Text.Length == 8)
            {
                if (txtEmpId.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Employee ID','danger')", true);
                }
                else
                {
                    string empdet = "select l.group_ids,depdes.actual_basic_salary,ROL.role_id,ROL.role_name,depdes.emp_dept_id,depdes.emp_des_id,desi.Designation_Title,l.col1 AS STAFFTYPE,CONVERT(VARCHAR,ep.emp_dob ,103)as dob,CONVERT(VARCHAR,ep.emp_doj ,103) as doj, * from m_employee_personal as ep,web_tp_login as l,employee_department_des as depdes,web_tp_roletype AS ROL,m_designation as desi where ep.emp_id= '" + txtEmpId.Text + "' and ep.emp_id=l.emp_id and depdes.emp_id=ep.emp_id AND ROL.role_id=L.role_id and desi.Designation_ID=depdes.emp_des_id";
                    DataTable empdt = cls.fillDataTable(empdet);
                    if (empdt.Rows.Count > 0)
                    {
                        lstbx_Module.Attributes.Remove("disabled");
                        lstbx_formname.Attributes.Remove("disabled");

                        lstbx_formname.Enabled = true;
                        string state1 = empdt.Rows[0]["emp_state_per"].ToString();
                        btnsave.Text = "Update";
                        btnsave.Enabled = true;
                        //current address
                        String ADDRESS_CURR = "";
                        ADDRESS_CURR = empdt.Rows[0]["emp_address_curr"].ToString();
                        string[] address_city = ADDRESS_CURR.Split('~');
                        txtaddress.Text = address_city[0];
                        txtcity.Text = address_city[1];
                        //permanent address
                        string address_per = "";
                        address_per = empdt.Rows[0]["emp_address_per"].ToString();
                        string[] peraddr = address_per.Split('~');
                        txtadd.Text = peraddr[0];
                        ddlmart.SelectedValue = empdt.Rows[0]["emp_maritial_status"].ToString();
                        state();
                        txtpercity.Text = peraddr[1];
                        ddlperState.SelectedValue = empdt.Rows[0]["emp_state_per"].ToString().Trim();
                        txtperpin.Text = empdt.Rows[0]["emp_pincode_per"].ToString();
                        TXTPIN.Text = empdt.Rows[0]["emp_pincode_curr"].ToString();
                        btnsave.Enabled = true;
                        txtlastname.Text = empdt.Rows[0]["emp_lname"].ToString();
                        txtmiddlename.Text = empdt.Rows[0]["emp_mname"].ToString();
                        txtfirstname.Text = empdt.Rows[0]["emp_fname"].ToString();
                        txtmothername.Text = empdt.Rows[0]["emp_mother_name"].ToString();
                        if (empdt.Rows[0]["emp_handicaped"].ToString() == "False")
                        {

                            chkbx_phys.Checked = false;
                        }
                        else
                        {

                            chkbx_phys.Checked = true;
                        }


                        if (empdt.Rows[0]["emp_gender"].ToString() == "Male")
                        {
                            rad_gender.Checked = true;
                        }
                        else
                        {
                            rad_female.Checked = true;
                        }
                        btnsave.Enabled = true;
                        txtDOJ.Text = empdt.Rows[0]["doj"].ToString();
                        txtdob.Text = empdt.Rows[0]["dob"].ToString();
                        //txtannualsal.Text = empdt.Rows[0]["emp_dob"].ToString();
                        string bldgrp = empdt.Rows[0]["emp_blood_group"].ToString().Trim();

                        ddlbloodgroup.SelectedValue = empdt.Rows[0]["emp_blood_group"].ToString().Trim();
                        ddlbloodgroup.Items.FindByValue(bldgrp).Selected = true;
                        // cmd.Parameters.AddWithValue("@emp_mobile1", txtmobno.Text.ToString().Trim());
                        // cmd.Parameters.AddWithValue("@emp_mobile2", txtmobile.Text.ToString().Trim());
                        string reli = empdt.Rows[0]["emp_religion"].ToString();
                        ddl_rel.SelectedValue = empdt.Rows[0]["emp_religion"].ToString().Trim().ToUpper();

                        txtmobno.Text = empdt.Rows[0]["emp_mobile1"].ToString();
                        txtmobile.Text = empdt.Rows[0]["emp_mobile2"].ToString();
                        txtemail.Text = empdt.Rows[0]["emp_email"].ToString();
                        //  txtaddress.Text = empdt.Rows[0]["emp_address_curr"].ToString();
                        ddlcat.SelectedValue = empdt.Rows[0]["emp_category"].ToString();
                        caste();
                        string cste = "";
                        cste = empdt.Rows[0]["emp_cast"].ToString();

                        ddlcast.SelectedIndex = ddlcast.Items.IndexOf(ddlcast.Items.FindByValue(cste));
                        ddlnation.SelectedValue = empdt.Rows[0]["emp_nationality"].ToString();
                        // txtadd.Text = empdt.Rows[0]["emp_address_per"].ToString();
                        txtaadhar.Text = empdt.Rows[0]["emp_aadhar_no"].ToString();
                        txtpan.Text = empdt.Rows[0]["emp_pan_no"].ToString();
                        txt_pf.Text = empdt.Rows[0]["emp_p_f_num"].ToString();
                        state();
                        string stat1 = "";
                        stat1 = empdt.Rows[0]["emp_state_curr"].ToString();
                        txtannualsal.Text = empdt.Rows[0]["actual_basic_salary"].ToString();
                        ddlstate.SelectedIndex = ddlstate.Items.IndexOf(ddlstate.Items.FindByValue(stat1));
                        Roleload();

                        dept_ddl();
                        ddlmart.SelectedValue = empdt.Rows[0]["emp_maritial_status"].ToString();
                        ddl_stafftype.SelectedValue = empdt.Rows[0]["STAFFTYPE"].ToString();
                        ddldepart1.SelectedValue = empdt.Rows[0]["emp_dept_id"].ToString();
                        string desg = "";
                        desg = empdt.Rows[0]["Designation_Title"].ToString();
                        designation();
                        ddlDesignation1.SelectedValue = empdt.Rows[0]["emp_des_id"].ToString().Trim();
                        ddlRole.SelectedValue = empdt.Rows[0]["role_id"].ToString();
                        // mod_form_disable();


                        string a = "select role_id,col2,* from web_tp_login where emp_id='" + txtEmpId.Text.Trim() + "'";
                        DataTable dt_webtp = cls.fillDataTable(a);

                        string form_id_frm_web_tp_log = dt_webtp.Rows[0]["col2"].ToString();
                        string[] form = form_id_frm_web_tp_log.Split(',');
                        string qury = "select form_name from web_tp_roletype where del_flag=0 and role_id='" + ddlRole.SelectedValue.ToString() + "'";
                        DataTable dt = cls.fillDataTable(qury);
                        string formid = dt.Rows[0]["form_name"].ToString();
                        string sum = "";
                        if (form_id_frm_web_tp_log=="")
                        {
                            sum = formid;
                        }
                        else 
                        {
                            sum = form_id_frm_web_tp_log + ',' + formid;
                        }
                         
                        string[] formid_list = formid.Split(',');
                        if (sum != "")
                        {
                            string qury2 = "select distinct convert(int,mod_id) as modulename from  Register_Form where Form_id in (" + sum + ")";
                            DataTable dt2 = cls.fillDataTable(qury2);

                            string qury3 = "select distinct convert(int,mod_id) as modulename from  Register_Form where Form_id in (" + formid + ")";
                            DataTable dt3 = cls.fillDataTable(qury3);

                            for (int i = 0; i < lstbx_Module.Items.Count; i++)
                            {
                                for (int j = 0; j < dt2.Rows.Count; j++)
                                {
                                    if (lstbx_Module.Items[i].Value.ToString() == dt2.Rows[j]["modulename"].ToString())
                                    {
                                        lstbx_Module.Items[i].Selected = true;
                                        for (int k = 0; k < dt3.Rows.Count; k++)
                                        {
                                            if (lstbx_Module.Items[i].Value.ToString() == dt3.Rows[k]["modulename"].ToString())
                                            {
                                                lstbx_Module.Items[i].Selected = true;
                                                lstbx_Module.Items[i].Attributes.Add("disabled", "disabled");

                                            }
                                        }
                                    }
                                }
                            }
                            string h = "";
                            for (int i = 0; i < lstbx_Module.Items.Count; i++)
                            {
                                if (lstbx_Module.Items[i].Selected)
                                {
                                    if (h == "")
                                    {
                                        h = "" + lstbx_Module.Items[i].Value + "";

                                    }
                                    else
                                    {

                                        h = h + "," + lstbx_Module.Items[i].Value + "";
                                    }
                                }
                            }
                            string frmname1 = "select * from Register_Form where del_flag=0 and mod_id in(" + h + ")";
                            DataTable dt4 = cls.fillDataTable(frmname1);
                            lstbx_formname.DataTextField = dt4.Columns["Form_name"].ToString();
                            lstbx_formname.DataValueField = dt4.Columns["Form_id"].ToString();
                            lstbx_formname.DataSource = dt4;
                            lstbx_formname.DataBind();

                            for (int i = 0; i < lstbx_formname.Items.Count; i++)
                            {
                                for (int j = 0; j < formid_list.Length; j++)
                                {
                                    if (lstbx_formname.Items[i].Value.ToString() == formid_list[j].ToString())
                                    {
                                        lstbx_formname.Items[i].Selected = true;
                                        lstbx_formname.Items[i].Attributes.Add("disabled", "disabled");

                                    }
                                }
                                for (int k = 0; k < form.Length; k++)
                                {
                                    if (lstbx_formname.Items[i].Value.ToString() == form[k].ToString())
                                    {
                                        lstbx_formname.Items[i].Selected = true;


                                    }

                                }
                            }

                            //lstbx_Module_SelectedIndexChanged(this, EventArgs.Empty);



                            string modid = dt2.Rows[0]["modulename"].ToString();
                            string[] modlist = modid.Split(',');







                            txtEmpId.Enabled = false;
                            groupload();
                            lstgrup = empdt.Rows[0]["group_ids"].ToString();
                            string[] grpname = lstgrup.Split(',');
                            for (int i = 0; i < grpname.Length; i++)
                            {

                                for (int j = 0; j < lstgroup.Items.Count; j++)
                                {
                                    if (grpname[i].Equals(lstgroup.Items[j].Value))
                                    {
                                        lstgroup.Items[j].Selected = true;

                                    }


                                }


                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Employee ID','danger')", true);
                            txtEmpId.Text = "";
                            btnsave.Enabled = false;
                            clean();

                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid employee id','danger')", true);
                //clean();
            }
        }

        catch (Exception h)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + h.Message + "','danger')", true);

        }
    }

    //protected void txtEmpId_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string lstgrup = "";
    //        if (txtEmpId.Text.Length == 8)
    //        {
    //            if (txtEmpId.Text.Trim() == "")
    //            {
    //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Employee ID','danger')", true);
    //            }
    //            else
    //            {
    //                string empdet = "select l.group_ids,depdes.actual_basic_salary,ROL.role_id,ROL.role_name,depdes.emp_dept_id,depdes.emp_des_id,desi.Designation_Title,l.col1 AS STAFFTYPE,CONVERT(VARCHAR,ep.emp_dob ,103)as dob,CONVERT(VARCHAR,ep.emp_doj ,103) as doj, * from m_employee_personal as ep,web_tp_login as l,employee_department_des as depdes,web_tp_roletype AS ROL,m_designation as desi where ep.emp_id= '" + txtEmpId.Text + "' and ep.emp_id=l.emp_id and depdes.emp_id=ep.emp_id AND ROL.role_id=L.role_id and desi.Designation_ID=depdes.emp_des_id";
    //                DataTable empdt = cls.fillDataTable(empdet);
    //                if (empdt.Rows.Count > 0)
    //                {
    //                    lstbx_Module.Attributes.Remove("disabled");
    //                    lstbx_formname.Attributes.Remove("disabled");

    //                    lstbx_formname.Enabled = true;
    //                    string state1 = empdt.Rows[0]["emp_state_per"].ToString();
    //                    btnsave.Text = "Update";
    //                    btnsave.Enabled = true;
    //                    //current address
    //                    String ADDRESS_CURR = "";
    //                    ADDRESS_CURR = empdt.Rows[0]["emp_address_curr"].ToString();
    //                    string[] address_city = ADDRESS_CURR.Split('~');
    //                    txtaddress.Text = address_city[0];
    //                    txtcity.Text = address_city[1];
    //                    //permanent address
    //                    string address_per = "";
    //                    address_per = empdt.Rows[0]["emp_address_per"].ToString();
    //                    string[] peraddr = address_per.Split('~');
    //                    txtadd.Text = peraddr[0];
    //                    txtpercity.Text = peraddr[1];
    //                    ddlperState.SelectedValue = empdt.Rows[0]["emp_state_per"].ToString();
    //                    txtperpin.Text = empdt.Rows[0]["emp_pincode_per"].ToString();
    //                    TXTPIN.Text = empdt.Rows[0]["emp_pincode_curr"].ToString();
    //                    btnsave.Enabled = true;
    //                    txtlastname.Text = empdt.Rows[0]["emp_lname"].ToString();
    //                    txtmiddlename.Text = empdt.Rows[0]["emp_mname"].ToString();
    //                    txtfirstname.Text = empdt.Rows[0]["emp_fname"].ToString();
    //                    txtmothername.Text = empdt.Rows[0]["emp_mother_name"].ToString();
    //                    if (empdt.Rows[0]["emp_handicaped"].ToString() == "False")
    //                    {

    //                        chkbx_phys.Checked = false;
    //                    }
    //                    else
    //                    {

    //                        chkbx_phys.Checked = true;
    //                    }


    //                    if (empdt.Rows[0]["emp_gender"].ToString() == "Male")
    //                    {
    //                        rad_gender.Checked = true;
    //                    }
    //                    else
    //                    {
    //                        rad_female.Checked = true;
    //                    }
    //                    btnsave.Enabled = true;
    //                    txtDOJ.Text = empdt.Rows[0]["doj"].ToString();
    //                    txtdob.Text = empdt.Rows[0]["dob"].ToString();
    //                    //txtannualsal.Text = empdt.Rows[0]["emp_dob"].ToString();
    //                    string bldgrp = empdt.Rows[0]["emp_blood_group"].ToString().Trim();

    //                    ddlbloodgroup.SelectedValue = empdt.Rows[0]["emp_blood_group"].ToString().Trim();
    //                    ddlbloodgroup.Items.FindByValue(bldgrp).Selected = true;
    //                    // cmd.Parameters.AddWithValue("@emp_mobile1", txtmobno.Text.ToString().Trim());
    //                    // cmd.Parameters.AddWithValue("@emp_mobile2", txtmobile.Text.ToString().Trim());
    //                    string reli = empdt.Rows[0]["emp_religion"].ToString();
    //                    ddl_rel.SelectedValue = empdt.Rows[0]["emp_religion"].ToString();

    //                    txtmobno.Text = empdt.Rows[0]["emp_mobile1"].ToString();
    //                    txtmobile.Text = empdt.Rows[0]["emp_mobile2"].ToString();
    //                    txtemail.Text = empdt.Rows[0]["emp_email"].ToString();
    //                    //  txtaddress.Text = empdt.Rows[0]["emp_address_curr"].ToString();
    //                    ddlcat.SelectedValue = empdt.Rows[0]["emp_category"].ToString();
    //                    caste();
    //                    string cste = "";
    //                    cste = empdt.Rows[0]["emp_cast"].ToString();

    //                    ddlcast.SelectedIndex = ddlcast.Items.IndexOf(ddlcast.Items.FindByValue(cste));
    //                    ddlnation.SelectedValue = empdt.Rows[0]["emp_nationality"].ToString();
    //                    // txtadd.Text = empdt.Rows[0]["emp_address_per"].ToString();
    //                    txtaadhar.Text = empdt.Rows[0]["emp_aadhar_no"].ToString();
    //                    txtpan.Text = empdt.Rows[0]["emp_pan_no"].ToString();
    //                    txt_pf.Text = empdt.Rows[0]["emp_p_f_num"].ToString();
    //                    state();
    //                    string stat1 = "";
    //                    stat1 = empdt.Rows[0]["emp_state_curr"].ToString();
    //                    txtannualsal.Text = empdt.Rows[0]["actual_basic_salary"].ToString();
    //                    ddlstate.SelectedIndex = ddlstate.Items.IndexOf(ddlstate.Items.FindByValue(stat1));
    //                    Roleload();

    //                    dept_ddl();
    //                    ddlmart.SelectedValue = empdt.Rows[0]["emp_maritial_status"].ToString();
    //                    ddl_stafftype.SelectedValue = empdt.Rows[0]["STAFFTYPE"].ToString();
    //                    ddldepart1.SelectedValue = empdt.Rows[0]["emp_dept_id"].ToString();
    //                    string desg = "";
    //                    desg = empdt.Rows[0]["Designation_Title"].ToString();
    //                    designation();
    //                    ddlDesignation1.SelectedValue = empdt.Rows[0]["emp_des_id"].ToString().Trim();
    //                    ddlRole.SelectedValue = empdt.Rows[0]["role_id"].ToString();
    //                    // mod_form_disable();


    //                    string a = "select role_id,col2,* from web_tp_login where emp_id='" + txtEmpId.Text.Trim() + "'";
    //                    DataTable dt_webtp = cls.fillDataTable(a);

    //                    string form_id_frm_web_tp_log = dt_webtp.Rows[0]["col2"].ToString();
    //                    string[] form = form_id_frm_web_tp_log.Split(',');
    //                    string qury = "select form_name from web_tp_roletype where del_flag=0 and role_id='" + ddlRole.SelectedValue.ToString() + "'";
    //                    DataTable dt = cls.fillDataTable(qury);
    //                    string formid = dt.Rows[0]["form_name"].ToString();


    //                    string sum = form_id_frm_web_tp_log + ',' + formid;
    //                    string[] formid_list = formid.Split(',');
    //                    if (sum != "")
    //                    {
    //                        string qury2 = "select distinct convert(int,mod_id) as modulename from  Register_Form where Form_id in (" + sum + ")";
    //                        DataTable dt2 = cls.fillDataTable(qury2);

    //                        string qury3 = "select distinct convert(int,mod_id) as modulename from  Register_Form where Form_id in (" + formid + ")";
    //                        DataTable dt3 = cls.fillDataTable(qury3);

    //                        for (int i = 0; i < lstbx_Module.Items.Count; i++)
    //                        {
    //                            for (int j = 0; j < dt2.Rows.Count; j++)
    //                            {
    //                                if (lstbx_Module.Items[i].Value.ToString() == dt2.Rows[j]["modulename"].ToString())
    //                                {
    //                                    lstbx_Module.Items[i].Selected = true;
    //                                    for (int k = 0; k < dt3.Rows.Count; k++)
    //                                    {
    //                                        if (lstbx_Module.Items[i].Value.ToString() == dt3.Rows[k]["modulename"].ToString())
    //                                        {
    //                                            lstbx_Module.Items[i].Selected = true;
    //                                            lstbx_Module.Items[i].Attributes.Add("disabled", "disabled");

    //                                        }
    //                                    }
    //                                }
    //                            }
    //                        }
    //                        string h = "";
    //                        for (int i = 0; i < lstbx_Module.Items.Count; i++)
    //                        {
    //                            if (lstbx_Module.Items[i].Selected)
    //                            {
    //                                if (h == "")
    //                                {
    //                                    h = "" + lstbx_Module.Items[i].Value + "";

    //                                }
    //                                else
    //                                {

    //                                    h = h + "," + lstbx_Module.Items[i].Value + "";
    //                                }
    //                            }
    //                        }
    //                        string frmname1 = "select * from Register_Form where del_flag=0 and mod_id in(" + h + ")";
    //                        DataTable dt4 = cls.fillDataTable(frmname1);
    //                        lstbx_formname.DataTextField = dt4.Columns["Form_name"].ToString();
    //                        lstbx_formname.DataValueField = dt4.Columns["Form_id"].ToString();
    //                        lstbx_formname.DataSource = dt4;
    //                        lstbx_formname.DataBind();

    //                        for (int i = 0; i < lstbx_formname.Items.Count; i++)
    //                        {
    //                            for (int j = 0; j < formid_list.Length; j++)
    //                            {
    //                                if (lstbx_formname.Items[i].Value.ToString() == formid_list[j].ToString())
    //                                {
    //                                    lstbx_formname.Items[i].Selected = true;
    //                                    lstbx_formname.Items[i].Attributes.Add("disabled", "disabled");

    //                                }
    //                            }
    //                            for (int k = 0; k < form.Length; k++)
    //                            {
    //                                if (lstbx_formname.Items[i].Value.ToString() == form[k].ToString())
    //                                {
    //                                    lstbx_formname.Items[i].Selected = true;


    //                                }

    //                            }
    //                        }

    //                        //lstbx_Module_SelectedIndexChanged(this, EventArgs.Empty);



    //                        string modid = dt2.Rows[0]["modulename"].ToString();
    //                        string[] modlist = modid.Split(',');



    //                        //for (int i = 0; i < modlist.Length; i++)
    //                        //{
    //                        //    for (int j = 0; j < lstbx_Module.Items.Count; j++)
    //                        //    {
    //                        //        if (modlist[i].Equals(lstbx_Module.Items[j].Value))
    //                        //        {
    //                        //            lstbx_Module.Items[j].Selected = true;
    //                        //            lstbx_Module.Items[j].Attributes.Add("disabled", "disabled");
    //                        //        }
    //                        //    }
    //                        //}

    //                        //bool m = false;
    //                        //string z = "";
    //                        //for (int i = 0; i < lstbx_Module.Items.Count; i++)
    //                        //{
    //                        //    if (lstbx_Module.Items[i].Selected == true)
    //                        //    {
    //                        //        m = true;
    //                        //    }

    //                        //}
    //                        //for (int i = 0; i < lstbx_Module.Items.Count; i++)
    //                        //{
    //                        //    if (lstbx_Module.Items[i].Selected)
    //                        //    {
    //                        //        if (z == "")
    //                        //        {
    //                        //            z = "" + lstbx_Module.Items[i].Value + "";

    //                        //        }
    //                        //        else
    //                        //        {

    //                        //            z = z + "," + lstbx_Module.Items[i].Value + "";
    //                        //        }
    //                        //    }
    //                        //}

    //                        //    if (m)
    //                        //    {
    //                        //        if (z != "")
    //                        //        {


    //                        //            lstbx_formname.Enabled = true;
    //                        //            string frmname = "select * from Register_Form where del_flag=0 and mod_id in(" + z + ")";
    //                        //            DataTable dt4 = cls.fillDataTable(frmname);
    //                        //            lstbx_formname.DataTextField = dt4.Columns["Form_name"].ToString();
    //                        //            lstbx_formname.DataValueField = dt4.Columns["Form_id"].ToString();
    //                        //            lstbx_formname.DataSource = dt4;
    //                        //            lstbx_formname.DataBind();
    //                        //            for (int i = 0; i < formid_list.Length; i++)
    //                        //            {
    //                        //                for (int j = 0; j < lstbx_formname.Items.Count; j++)
    //                        //                {
    //                        //                    if (formid_list[i].Equals(lstbx_formname.Items[j].Value))
    //                        //                    {
    //                        //                        lstbx_formname.Items[j].Selected = true;
    //                        //                        lstbx_formname.Items[j].Attributes.Add("disabled", "disabled");
    //                        //                        // lstbx_formname.Items[j].Enabled = false;
    //                        //                    }


    //                        //                }


    //                        //            }
    //                        //        }

    //                        //    }
    //                        //}


    //                        //string qyr = "select * from web_tp_login where emp_id='"+ txtEmpId.Text.Trim() + "' and del_flag=0";
    //                        //DataTable d = cls.fillDataTable(qyr);
    //                        //if (d.Rows.Count>0)
    //                        //{
    //                        //    string col2 = d.Rows[0]["col2"].ToString();
    //                        //    string modload = "select * from Register_Form where Form_id in ('"+col2+"')";
    //                        //    DataTable moddt = cls.fillDataTable(modload);

    //                        //    string[] col2_sp = col2.Split(',');
    //                        //    for (int i = 0; i < lstbx_formname.Items.Count; i++)
    //                        //    {
    //                        //        for (int j=0;j<col2_sp.Length;j++) 
    //                        //    {

    //                        //            if (col2_sp[j].Equals(lstbx_formname.Items[i].Value))
    //                        //            {
    //                        //                lstbx_formname.Items[i].Selected = true;
    //                        //                //lstbx_formname.Items[j].Attributes.Add("disabled", "disabled");
    //                        //               // lstbx_formname.Items[j].Enabled=false;

    //                        //            }
    //                        //        }
    //                        //    }

    //                        //}




    //                        txtEmpId.Enabled = false;
    //                        groupload();
    //                        lstgrup = empdt.Rows[0]["group_ids"].ToString();
    //                        string[] grpname = lstgrup.Split(',');
    //                        for (int i = 0; i < grpname.Length; i++)
    //                        {

    //                            for (int j = 0; j < lstgroup.Items.Count; j++)
    //                            {
    //                                if (grpname[i].Equals(lstgroup.Items[j].Value))
    //                                {
    //                                    lstgroup.Items[j].Selected = true;

    //                                }


    //                            }


    //                        }

    //                    }
    //                    else
    //                    {
    //                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Employee ID','danger')", true);
    //                        txtEmpId.Text = "";
    //                        btnsave.Enabled = false;
    //                        clean();

    //                    }
    //                }

    //            }
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid employee id','danger')", true);
    //            //clean();
    //        }
    //    }

    //    catch (Exception h)
    //    {
    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + h.Message + "','danger')", true);

    //    }
    //}

    protected void rad_gender_CheckedChanged(object sender, EventArgs e)
    {

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
        if (rad_gender.Checked == true)
        {
            rad_female.Checked = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);

        }
    }

    protected void rad_female_CheckedChanged(object sender, EventArgs e)
    {
        if (rad_female.Checked == true)
        {
            rad_gender.Checked = false;
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
    }

    protected void ddl_rel_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void sameabov_CheckedChanged(object sender, EventArgs e)
    {
        if (sameabov.Checked == true)
        {
            txtadd.Text = txtaddress.Text;
            txtpercity.Text = txtcity.Text;
            ddlperState.SelectedValue = ddlstate.SelectedValue;
            txtperpin.Text = TXTPIN.Text;

        }
        else
        {
            txtadd.Text = "";
            txtpercity.Text = "";
            ddlperState.SelectedIndex = 0;
            txtperpin.Text = "";

        }

    }

    protected void lstbx_Module_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool m = false;
        string z = "";
        for (int i = 0; i < lstbx_Module.Items.Count; i++)
        {
            if (lstbx_Module.Items[i].Selected == true)
            {
                m = true;
            }

        }
        for (int i = 0; i < lstbx_Module.Items.Count; i++)
        {
            if (lstbx_Module.Items[i].Selected)
            {
                if (z == "")
                {
                    z = "" + lstbx_Module.Items[i].Value + "";

                }
                else
                {

                    z = z + "," + lstbx_Module.Items[i].Value + "";
                }
            }
        }

        if (m)//checks  if modules is selected or not
        {
            if (z != "") // z  contains selected items values
            {


                lstbx_formname.Enabled = true;
                string frmname = "select * from Register_Form where del_flag=0 and mod_id in(" + z + ")";  //filling of formname listbox
                DataTable dt = cls.fillDataTable(frmname);
                lstbx_formname.DataTextField = dt.Columns["Form_name"].ToString();
                lstbx_formname.DataValueField = dt.Columns["Form_id"].ToString();
                lstbx_formname.DataSource = dt;
                lstbx_formname.DataBind();
                //==============

                string qury = "select form_name from web_tp_roletype where del_flag=0 and role_id='" + ddlRole.SelectedValue.ToString() + "'";
                DataTable dt1 = cls.fillDataTable(qury);
                string formid = dt1.Rows[0]["form_name"].ToString();
                string[] formid_list = formid.Split(',');
                if (dt.Rows.Count > 0)
                {
                    string qury2 = "select STRING_AGG( convert(int,mod_id),',') as modulename from  Register_Form where Form_id in (" + formid + ")";
                    DataTable dt2 = cls.fillDataTable(qury2);
                    string modid = dt2.Rows[0]["modulename"].ToString();
                    string[] modlist = modid.Split(',');
                    for (int i = 0; i < modlist.Length; i++)
                    {
                        for (int j = 0; j < lstbx_Module.Items.Count; j++)
                        {
                            if (modlist[i].Equals(lstbx_Module.Items[j].Value))
                            {
                                lstbx_Module.Items[j].Selected = true;
                                lstbx_Module.Items[j].Attributes.Add("disabled", "disabled");

                            }
                        }
                    }

                    bool m1 = false;
                    string z1 = "";
                    for (int i = 0; i < lstbx_Module.Items.Count; i++)
                    {
                        if (lstbx_Module.Items[i].Selected == true)
                        {
                            m1 = true;
                        }

                    }
                    for (int i = 0; i < lstbx_Module.Items.Count; i++)
                    {
                        if (lstbx_Module.Items[i].Selected)
                        {
                            if (z1 == "")
                            {
                                z1 = "" + lstbx_Module.Items[i].Value + "";

                            }
                            else
                            {

                                z1 = z1 + "," + lstbx_Module.Items[i].Value + "";
                            }
                        }
                    }



                    string a = "select role_id,col2,* from web_tp_login where emp_id='" + txtEmpId.Text.Trim() + "'";
                    DataTable dt_webtp = cls.fillDataTable(a);

                    string form_id_frm_web_tp_log = "";
                    if (dt_webtp.Rows.Count > 0)
                    {
                        form_id_frm_web_tp_log = dt_webtp.Rows[0]["col2"].ToString();
                    }
                    string[] form = form_id_frm_web_tp_log.Split(',');
                    for (int i = 0; i < lstbx_formname.Items.Count; i++)
                    {
                        for (int j = 0; j < formid_list.Length; j++)
                        {
                            if (lstbx_formname.Items[i].Value.ToString() == formid_list[j].ToString())
                            {
                                lstbx_formname.Items[i].Selected = true;
                                lstbx_formname.Items[i].Attributes.Add("disabled", "disabled");

                            }
                        }
                        if (dt_webtp.Rows.Count > 0)
                        {
                            for (int k = 0; k < form.Length; k++)
                            {
                                if (lstbx_formname.Items[i].Value.ToString() == form[k].ToString())
                                {
                                    lstbx_formname.Items[i].Selected = true;


                                }

                            }
                        }

                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Check atleast Module','danger')", true);

            }
        }
        else
        {
            // lstbx_formname.Enabled = false;
        }
        // mod_form_disable();

    }
    //protected void lstbx_Module_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bool m = false;
    //    string z = "";
    //    for (int i = 0; i < lstbx_Module.Items.Count; i++)
    //    {
    //        if (lstbx_Module.Items[i].Selected == true)
    //        {
    //            m = true;
    //        }

    //    }
    //    for (int i = 0; i < lstbx_Module.Items.Count; i++)
    //    {
    //        if (lstbx_Module.Items[i].Selected)
    //        {
    //            if (z == "")
    //            {
    //                z = "" + lstbx_Module.Items[i].Value + "";

    //            }
    //            else
    //            {

    //                z = z + "," + lstbx_Module.Items[i].Value + "";
    //            }
    //        }
    //    }

    //    if (m)//checks  if modules is selected or not
    //    {
    //        if (z != "") // z  contains selected items values
    //        {


    //            lstbx_formname.Enabled = true;
    //            string frmname = "select * from Register_Form where del_flag=0 and mod_id in(" + z + ")";  //filling of formname listbox
    //            DataTable dt = cls.fillDataTable(frmname);
    //            lstbx_formname.DataTextField = dt.Columns["Form_name"].ToString();
    //            lstbx_formname.DataValueField = dt.Columns["Form_id"].ToString();
    //            lstbx_formname.DataSource = dt;
    //            lstbx_formname.DataBind();
    //            //==============

    //            string qury = "select form_name from web_tp_roletype where del_flag=0 and role_id='" + ddlRole.SelectedValue.ToString() + "'";
    //            DataTable dt1 = cls.fillDataTable(qury);
    //            string formid = dt1.Rows[0]["form_name"].ToString();
    //            string[] formid_list = formid.Split(',');
    //            if (dt.Rows.Count > 0)
    //            {
    //                string qury2 = "select STRING_AGG( convert(int,mod_id),',') as modulename from  Register_Form where Form_id in (" + formid + ")";
    //                DataTable dt2 = cls.fillDataTable(qury2);
    //                string modid = dt2.Rows[0]["modulename"].ToString();
    //                string[] modlist = modid.Split(',');
    //                for (int i = 0; i < modlist.Length; i++)
    //                {
    //                    for (int j = 0; j < lstbx_Module.Items.Count; j++)
    //                    {
    //                        if (modlist[i].Equals(lstbx_Module.Items[j].Value))
    //                        {
    //                            lstbx_Module.Items[j].Selected = true;
    //                            lstbx_Module.Items[j].Attributes.Add("disabled", "disabled");

    //                        }
    //                    }
    //                }

    //                bool m1 = false;
    //                string z1 = "";
    //                for (int i = 0; i < lstbx_Module.Items.Count; i++)
    //                {
    //                    if (lstbx_Module.Items[i].Selected == true)
    //                    {
    //                        m1 = true;
    //                    }

    //                }
    //                for (int i = 0; i < lstbx_Module.Items.Count; i++)
    //                {
    //                    if (lstbx_Module.Items[i].Selected)
    //                    {
    //                        if (z1 == "")
    //                        {
    //                            z1 = "" + lstbx_Module.Items[i].Value + "";

    //                        }
    //                        else
    //                        {

    //                            z1 = z1 + "," + lstbx_Module.Items[i].Value + "";
    //                        }
    //                    }
    //                }

    //                //if (m1)
    //                //{
    //                //    if (z1 != "")
    //                //    {


    //                //        lstbx_formname.Enabled = true;
    //                //        string frmname1 = "select * from Register_Form where del_flag=0 and mod_id in(" + z + ")";
    //                //        DataTable dt4 = cls.fillDataTable(frmname1);
    //                //        lstbx_formname.DataTextField = dt4.Columns["Form_name"].ToString();
    //                //        lstbx_formname.DataValueField = dt4.Columns["Form_id"].ToString();
    //                //        lstbx_formname.DataSource = dt4;
    //                //        lstbx_formname.DataBind();
    //                //        for (int i = 0; i < formid_list.Length; i++)
    //                //        {
    //                //            for (int j = 0; j < lstbx_formname.Items.Count; j++)
    //                //            {
    //                //                if (formid_list[i].Equals(lstbx_formname.Items[j].Value))
    //                //                {
    //                //                    lstbx_formname.Items[j].Selected = true;
    //                //                    lstbx_formname.Items[j].Attributes.Add("disabled", "disabled");
    //                //                    //lstbx_formname.Items[j].Enabled = false;
    //                //                }


    //                //            }
    //                //        }
    //                //    }

    //                //}
    //            }
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Check atleast Module','danger')", true);

    //        }
    //    }
    //    else
    //    {
    //        // lstbx_formname.Enabled = false;
    //    }
    //    // mod_form_disable();

    //}
}