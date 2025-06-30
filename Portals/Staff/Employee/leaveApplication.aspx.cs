using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Globalization;
public partial class Portals_Staff_Employee_leaveApplication : System.Web.UI.Page
{

    Class1 cls = new Class1();

    protected void Page_Load(object sender, EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "ddl_hod_multi();", true);
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "ddl_principal_multi();", true);
        ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:date(); ", true);

        txtdays.Text = Request.Form[hiddays.UniqueID];

        if (!IsPostBack)
        {

            if (Convert.ToString(Session["emp_id"]) == "")
            {
                Response.Redirect("../../Staff/Login.aspx");
            }
            else
            {
                balance();
                grid.Visible = false;
                gridload();
                dataload();
                txtcl.Enabled = false;
                txtcomp.Enabled = false;
                txtml.Enabled = false;
                txtel.Enabled = false;
                txtoutd.Enabled = false;
                txtlwp.Enabled = false;
                txtmaternity.Enabled = false;
                txtleavedaysno.Enabled = false;
                txtadd.Enabled = false;
                txt_contact.Enabled = false;

                ddl_emp_name.Attributes.Add("disabled", "disabled");
                tdate.Attributes.Add("disabled", "disabled");
                hq.Visible = false;

                //lblCL.Enabled = false;
                //lblCL.Attributes["disabled"] = "disabled";

            }


        }
        else
        {

        }
    }
    public void balance()
    {
        //string str = "select id, emp_id, CL, CO, ML,PML, EL, PEL,OUTD, curr_dt, del_flag, year,BCL,BCO,BML,BEL,BOUTD,BCL + ML + EL + PML + PEL  as Total_Leave from(SELECT *, (cl - (SELECT ISNULL(sum(cast((cl) as float)), 0) FROM   Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0  and emp_id = '" + Session["emp_id"].ToString() + "' and AYID='" + Session["acdyear"].ToString() + "')) as BCL,((SELECT ISNULL(sum(cast((CO) as float)), 0)FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["acdyear"].ToString() + "')) as BCO,((PML + ML) - (SELECT ISNULL(sum(cast((ML) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["acdyear"].ToString() + "')) as BML,((PEL + EL) - (SELECT ISNULL(sum(cast((EL) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["acdyear"].ToString() + "')) as BEL,((SELECT ISNULL(sum(cast((outd) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["acdyear"].ToString() + "')) as BOUTD FROM emp_leave_data WHERE del_flag = 0 and emp_id = '" + Session["emp_id"].ToString() + "' and year ='" + Session["acdyear"].ToString() + "') a";

        string str = "select id, emp_id, CL, CO, ML,PML, EL, PEL,OUTD, curr_dt, del_flag, year,BCL,BCO,C_ML,BML,ML_PML,C_EL,BEL,EL_PEL,BOUTD,BCL + C_ML + C_EL + PML + PEL  as Total_Leave from (SELECT *,(cl - (SELECT ISNULL(sum(cast((cl) as float)), 0) FROM   Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0  and emp_id = '" + Session["emp_id"].ToString() + "' and AYID='" + Session["Year"].ToString() + "')) as BCL,((SELECT ISNULL(sum(cast((CO) as float)), 0)FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "')) as BCO, case when (SELECT ISNULL(sum(cast((ML) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "') >= (ML) then  ((PML + ML) - (SELECT ISNULL(sum(cast((ML) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "')) else (PML)end as BML, case when (ML)>=  (SELECT ISNULL(sum(cast((ML) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "')  then ((ML) - (SELECT ISNULL(sum(cast((ML) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "')) else  0  end as C_ML, ((PML + ML) - (SELECT ISNULL(sum(cast((ML) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "')) as ML_PML, case when (SELECT ISNULL(sum(cast((EL) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "') >= (EL) then  ((PEL + EL) - (SELECT ISNULL(sum(cast((EL) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "')) else (PEL)end as BEL, case when (EL)>=  (SELECT ISNULL(sum(cast((EL) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "')  then ((EL) - (SELECT ISNULL(sum(cast((EL) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "')) else  0  end as C_EL, ((PEL + EL) - (SELECT ISNULL(sum(cast((EL) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "')) as EL_PEL, ((SELECT ISNULL(sum(cast((outd) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + Session["emp_id"].ToString() + "'  and AYID='" + Session["Year"].ToString() + "')) as BOUTD FROM emp_leave_data WHERE del_flag = 0 and emp_id = '" + Session["emp_id"].ToString() + "' and year ='" + Session["Year"].ToString() + "') a";


        DataSet ds = cls.fillDataset(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCL.Text = ds.Tables[0].Rows[0]["BCL"].ToString();
            lblML.Text = ds.Tables[0].Rows[0]["C_ML"].ToString();
            lblEL.Text = ds.Tables[0].Rows[0]["C_EL"].ToString();
            lblOUTD.Text = ds.Tables[0].Rows[0]["BOUTD"].ToString();
            lblPML.Text = ds.Tables[0].Rows[0]["BML"].ToString();
            lblPEL.Text = ds.Tables[0].Rows[0]["BEL"].ToString();
            //lblEL.Text = ds.Tables[0].Rows[0]["EL"].ToString();
            lblCOMPL.Text = ds.Tables[0].Rows[0]["BCO"].ToString();
            lblTBL.Text = ds.Tables[0].Rows[0]["Total_Leave"].ToString();
            RangeValidator_CL.MaximumValue = ds.Tables[0].Rows[0]["BCL"].ToString();
            RangeValidator_EL.MaximumValue = ds.Tables[0].Rows[0]["EL_PEL"].ToString();
            RangeValidator_ML.MaximumValue = ds.Tables[0].Rows[0]["ML_PML"].ToString();
        }
        else
        {
            btn_Save.Enabled = false;
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Leave Not Defined Kindly Defined Leaves Then Apply for leave', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }


    }

    public void dataload()
    {

        string str1 = "select NAME+' '+FATHER+' '+SURNAME as name,emp_dept_id,* from EmployeePersonal where emp_id='" + Session["emp_id"].ToString() + "' ";
        DataSet ds1 = cls.fillDataset(str1);
        string deptid = ds1.Tables[0].Rows[0]["emp_dept_id"].ToString();

        string str = "select emp_id,NAME+' '+FATHER+' '+SURNAME as name  from EmployeePersonal where emp_dept_id='" + deptid + "' and emp_id<>'" + Session["emp_id"].ToString() + "'";
        DataSet ds = cls.fillDataset(str);

        string str3 = "select w.role_id,w.role_name as role  from EmployeePersonal e,web_tp_roletype w,web_tp_login m where w.role_id=m.role_id and e.emp_id=m.emp_id and emp_dept_id='" + deptid + "'and  e.emp_id='" + Session["emp_id"].ToString() + "'";
        DataSet ds3 = cls.fillDataset(str3);



        lbldesig.Text = ds3.Tables[0].Rows[0]["role"].ToString();
        lblname.Text = ds1.Tables[0].Rows[0]["name"].ToString().ToUpper();


        string emp_name_qry = "select distinct m.emp_id,Upper(e.NAME+' '+e.FATHER+' '+e.SURNAME) as name  from EmployeePersonal e,web_tp_roletype w,web_tp_login m, m_department d where  w.role_id=m.role_id and e.emp_id=m.emp_id and e.del_flag=0 and e.emp_dept_id= '" + deptid + "' and m.emp_id <> '" + Session["emp_id"].ToString() + "'";
        DataTable dt_emp_name_qry = cls.fillDataTable(emp_name_qry);
        ddl_emp_name.DataTextField = "name";
        ddl_emp_name.DataValueField = "emp_id";
        ddl_emp_name.DataSource = dt_emp_name_qry;
        ddl_emp_name.DataBind();
        // ddl_emp_name.Items.Insert(0, new ListItem("--Select--", "na"));


        string hod_load_qry = "SELECT emp_id,UPPER(name + ' ' + Father + ' ' + Surname ) as name from EmployeePersonal where emp_id in(select emp_id from web_tp_login where role_id='37' and del_flag=0)";
        DataTable dt_hod_load = cls.fillDataTable(hod_load_qry);
        ddl_hod.DataTextField = "name";
        ddl_hod.DataValueField = "emp_id";
        ddl_hod.DataSource = dt_hod_load;
        ddl_hod.DataBind();


        string principal_load_qry = "SELECT emp_id,UPPER(name + ' ' + Father + ' ' + Surname ) as name from EmployeePersonal where emp_id in(select emp_id from web_tp_login where role_id='29'  and del_flag=0)";
        DataTable dt_principal_load = cls.fillDataTable(principal_load_qry);
        ddl_principal.DataTextField = "name";
        ddl_principal.DataValueField = "emp_id";
        ddl_principal.DataSource = dt_principal_load;
        ddl_principal.DataBind();


    }

    public void gridload()
    {
        DataTable dsretrive = new DataTable();


        string qry = "select* from(select*,case when CL = 0 then ''else 'CL-' + cast(CL as varchar) + ',' end + case when CO = 0 then ''else 'CO-' + cast(CO as varchar) + ',' end + case when ML = 0 then ''else 'ML-' + cast(ML as varchar) + ','  end + case when EL = 0 then ''else 'EL-' + cast(EL as varchar) + ',' end +case when OUTD = 0 then ''else 'OUTD-' + cast(OUTD as varchar) + ','end + case when halfday = '' OR halfday IS NULL then ''else 'HALFDAY' + ','end + case when vacation = '' OR vacation IS NULL then ''else 'VACATION'end as a,convert(date, leavef, 105) as f1,convert(date, leavet, 105) as t1,case when approved_flag_HOD = 0 then 'Sanctioned' when approved_flag_HOD = 1 then 'Not Sanctioned' else ''end as approved_hod ,case when approved_flag_PRINCIPLE = 0 then 'Sanctioned' when approved_flag_PRINCIPLE = 1 then 'Not Sanctioned' else ''end as approved_principle ,case when paid_unpaid = 0 then 'PAID' when paid_unpaid = 1  then 'UNPAID' when paid_unpaid = 2  then 'HALFPAID' else ''end as [PAID/UNPAID] from Emp_Leave_Form where del_flag = 0 and AYID='" + Session["Year"].ToString() + "' and emp_id = '" + Session["emp_id"].ToString() + "') b order by srno desc";

        dsretrive = cls.fillDataTable(qry);

        if (dsretrive.Rows.Count > 0)
        {
            grid.Visible = true;
            grd_load.DataSource = dsretrive;
            grd_load.DataBind();
        }
        else
        {
            grid.Visible = false;
        }


    }

    protected void rdbcl_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbcl.Checked == true)
        {
            hq.Visible = true;
            txtcl.Enabled = true;
            txtcomp.Enabled = false;
            txtml.Enabled = false;
            txtel.Enabled = false;
            txtoutd.Enabled = false;
            //txtcl.Text = "";
            txtcomp.Text = "";
            txtml.Text = "";
            txtel.Text = "";
            txtoutd.Text = "";
            ddl_adjust_alternative.Enabled = true;
            txtres.Enabled = true;
            txtadd.Enabled = false;
            txt_contact.Enabled = false;
            txtadd.Text = "";
            txt_contact.Text = "";
            txtlwp.Text = "";
            txtmaternity.Text = "";
            txtlwp.Enabled = false;
            txtmaternity.Enabled = false;
            txtcomp.BorderColor = System.Drawing.Color.Silver;
            txtml.BorderColor = System.Drawing.Color.Silver;
            txtel.BorderColor = System.Drawing.Color.Silver;
            txtoutd.BorderColor = System.Drawing.Color.Silver;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select HQ is YES/NO', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }
        else
        {

        }

    }

    protected void rdbcomp_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbcomp.Checked == true)
        {
            txtcl.Enabled = false;
            txtcomp.Enabled = true;
            txtml.Enabled = false;
            txtel.Enabled = false;
            txtoutd.Enabled = false;
            ddl_adjust_alternative.Enabled = true;
            txtcl.Text = "";
            //txtcomp.Text = "";
            txtml.Text = "";
            txtel.Text = "";
            txtoutd.Text = "";
            txtres.Enabled = true;
            txtadd.Enabled = false;
            txt_contact.Enabled = false;
            txtadd.Text = "";
            txt_contact.Text = "";
            txtlwp.Text = "";
            txtmaternity.Text = "";
            txtlwp.Enabled = false;
            txtmaternity.Enabled = false;
            hq.Visible = false;
            ddlhq.SelectedIndex = 0;
            txtcl.BorderColor = System.Drawing.Color.Silver;
            txtml.BorderColor = System.Drawing.Color.Silver;
            txtel.BorderColor = System.Drawing.Color.Silver;
            txtoutd.BorderColor = System.Drawing.Color.Silver;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {
            txtcl.Text = "";
            //txtcomp.Text = "";
            txtml.Text = "";
            txtel.Text = "";
            txtoutd.Text = "";
        }

    }

    protected void rdbml_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbml.Checked == true)
        {
            txtcl.Enabled = false;
            txtcomp.Enabled = false;
            txtml.Enabled = true;
            txtel.Enabled = false;
            txtoutd.Enabled = false;
            txtcl.Text = "";
            txtcomp.Text = "";
            // txtml.Text = "";
            txtel.Text = "";
            txtoutd.Text = "";
            txtres.Enabled = true;
            ddl_adjust_alternative.Enabled = true;
            txtadd.Enabled = false;
            txt_contact.Enabled = false;
            txtadd.Text = "";
            txt_contact.Text = "";
            txtlwp.Text = "";
            txtmaternity.Text = "";
            txtlwp.Enabled = false;
            txtmaternity.Enabled = false;
            hq.Visible = false;
            ddlhq.SelectedIndex = 0;
            txtcomp.BorderColor = System.Drawing.Color.Silver;
            txtcl.BorderColor = System.Drawing.Color.Silver;
            txtel.BorderColor = System.Drawing.Color.Silver;
            txtoutd.BorderColor = System.Drawing.Color.Silver;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {

        }
    }

    protected void rdbel_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbel.Checked == true)
        {
            txtcl.Enabled = false;
            txtcomp.Enabled = false;
            txtml.Enabled = false;
            txtel.Enabled = true;
            txtoutd.Enabled = false;
            txtcl.Text = "";
            txtcomp.Text = "";
            txtml.Text = "";
            //txtel.Text = "";
            txtoutd.Text = "";
            txtres.Enabled = true;
            ddl_adjust_alternative.Enabled = true;
            txtadd.Enabled = false;
            txt_contact.Enabled = false;
            txtadd.Text = "";
            txt_contact.Text = "";
            txtlwp.Text = "";
            txtmaternity.Text = "";
            txtlwp.Enabled = false;
            txtmaternity.Enabled = false;
            hq.Visible = false;
            ddlhq.SelectedIndex = 0;
            txtcl.BorderColor = System.Drawing.Color.Silver;
            txtml.BorderColor = System.Drawing.Color.Silver;
            txtcomp.BorderColor = System.Drawing.Color.Silver;
            txtoutd.BorderColor = System.Drawing.Color.Silver;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {

        }
    }

    protected void rdboutd_CheckedChanged(object sender, EventArgs e)
    {
        if (rdboutd.Checked == true)
        {
            txtcl.Enabled = false;
            txtcomp.Enabled = false;
            txtml.Enabled = false;
            txtel.Enabled = false;
            txtoutd.Enabled = true;
            txtcl.Text = "";
            txtcomp.Text = "";
            txtml.Text = "";
            txtel.Text = "";
            //txtoutd.Text = "";
            txtres.Enabled = true;
            ddl_adjust_alternative.Enabled = true;
            txtadd.Enabled = false;
            txt_contact.Enabled = false;
            txtadd.Text = "";
            txt_contact.Text = "";
            txtlwp.Text = "";
            txtmaternity.Text = "";
            txtlwp.Enabled = false;
            txtmaternity.Enabled = false;
            hq.Visible = false;
            ddlhq.SelectedIndex = 0;
            txtcl.BorderColor = System.Drawing.Color.Silver;
            txtml.BorderColor = System.Drawing.Color.Silver;
            txtel.BorderColor = System.Drawing.Color.Silver;
            txtcomp.BorderColor = System.Drawing.Color.Silver;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {

        }
    }

    protected void rdblwp_CheckedChanged(object sender, EventArgs e)
    {
        if (rdblwp.Checked == true)
        {
            txtcl.Enabled = false;
            txtcomp.Enabled = false;
            txtml.Enabled = false;
            txtel.Enabled = false;
            txtoutd.Enabled = false;
            txtcl.Text = "";
            txtcomp.Text = "";
            txtml.Text = "";
            txtel.Text = "";
            txtoutd.Text = "";
            txtres.Enabled = true;
            ddl_adjust_alternative.Enabled = true;
            txtadd.Enabled = false;
            txt_contact.Enabled = false;
            txtadd.Text = "";
            txt_contact.Text = "";
            //txtlwp.Text = "";
            txtmaternity.Text = "";
            txtlwp.Enabled = true;
            txtmaternity.Enabled = false;
            hq.Visible = false;
            ddlhq.SelectedIndex = 0;
            txtcomp.BorderColor = System.Drawing.Color.Silver;
            txtcl.BorderColor = System.Drawing.Color.Silver;
            txtel.BorderColor = System.Drawing.Color.Silver;
            txtoutd.BorderColor = System.Drawing.Color.Silver;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {

        }
    }

    protected void rdbmaternity_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbmaternity.Checked == true)
        {
            txtcl.Enabled = false;
            txtcomp.Enabled = false;
            txtml.Enabled = false;
            txtel.Enabled = false;
            txtoutd.Enabled = false;
            txtcl.Text = "";
            txtcomp.Text = "";
            txtml.Text = "";
            txtel.Text = "";
            txtoutd.Text = "";
            txtres.Enabled = true;
            ddl_adjust_alternative.Enabled = true;
            txtadd.Enabled = false;
            txt_contact.Enabled = false;
            txtadd.Text = "";
            txt_contact.Text = "";
            txtlwp.Text = "";
            //txtmaternity.Text = "";
            txtlwp.Enabled = false;
            txtmaternity.Enabled = true;
            hq.Visible = false;
            ddlhq.SelectedIndex = 0;
            txtcomp.BorderColor = System.Drawing.Color.Silver;
            txtcl.BorderColor = System.Drawing.Color.Silver;
            txtel.BorderColor = System.Drawing.Color.Silver;
            txtoutd.BorderColor = System.Drawing.Color.Silver;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {

        }
    }
    protected void rdbhalf_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbhalf.Checked == true)
        {
            txtcl.Enabled = false;
            txtcomp.Enabled = false;
            txtml.Enabled = false;
            txtel.Enabled = false;
            txtoutd.Enabled = false;
            txtcl.Text = "";
            txtcomp.Text = "";
            txtml.Text = "";
            txtel.Text = "";
            txtoutd.Text = "";
            txtres.Enabled = true;
            ddl_adjust_alternative.Enabled = true;
            txtadd.Enabled = false;
            txt_contact.Enabled = false;
            txtadd.Text = "";
            txt_contact.Text = "";
            txtlwp.Text = "";
            txtmaternity.Text = "";
            txtlwp.Enabled = false;
            txtmaternity.Enabled = false;
            hq.Visible = false;
            ddlhq.SelectedIndex = 0;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {

        }
    }

    protected void rdbvacation_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbvacation.Checked == true)
        {
            txtcl.Enabled = false;
            txtcomp.Enabled = false;
            txtml.Enabled = false;
            txtel.Enabled = false;
            txtoutd.Enabled = false;
            txtcomp.Text = "";
            txtcl.Text = "";
            txtcomp.Text = "";
            txtml.Text = "";
            txtel.Text = "";
            txtoutd.Text = "";
            txtres.Enabled = false;
            txtres.Text = "";
            ddl_adjust_alternative.Enabled = true;
            txtadd.Enabled = true;
            txt_contact.Enabled = true;
            txtlwp.Text = "";
            txtmaternity.Text = "";
            txtlwp.Enabled = false;
            txtmaternity.Enabled = false;
            hq.Visible = false;
            ddlhq.SelectedIndex = 0;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {

        }

    }

    protected void rdb_hq_CheckedChanged(object sender, EventArgs e)
    {
        if (rdb_hq.Checked == true)
        {
            txtcl.Enabled = false;
            txtcomp.Enabled = false;
            txtml.Enabled = false;
            txtel.Enabled = false;
            txtoutd.Enabled = false;
            txtcomp.Text = "";
            txtcl.Text = "";
            txtcomp.Text = "";
            txtml.Text = "";
            txtel.Text = "";
            txtoutd.Text = "";
            ddl_adjust_alternative.Enabled = false;
            //ddl_emp_name.Enabled = false;
            txtadd.Enabled = true;
            txtres.Enabled = true;
            txt_contact.Enabled = true;
            txtlwp.Text = "";
            txtmaternity.Text = "";
            txtlwp.Enabled = false;
            txtmaternity.Enabled = false;
            hq.Visible = false;
            ddlhq.SelectedIndex = 0;
            ddl_emp_name.Attributes.Add("disabled", "disabled");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
    }

    protected void ddl_leave_days_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_leave_days_type.SelectedValue == "Prefix" || ddl_leave_days_type.SelectedValue == "Suffix" || ddl_leave_days_type.SelectedValue == "Both")
        {
            txtleavedaysno.Enabled = true;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {
            txtleavedaysno.Text = "";
            txtleavedaysno.Enabled = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
    }

    protected void ddl_adjust_alternative_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_adjust_alternative.SelectedValue == "yes")

        {
            //dataload();
            string lstboxcheckornot = "";

            for (int i = 0; i < ddl_emp_name.Items.Count; i++)
            {
                if (ddl_emp_name.Items[i].Selected == true)
                {
                    lstboxcheckornot = "true";
                }
            }
            //if (lstboxcheckornot == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select alternative arrangement', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
            //}
            ddl_emp_name.Attributes.Remove("disabled");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }

        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
            ddl_emp_name.Attributes.Add("disabled", "disabled");
        }
    }

    public void LOCUM()
    {

        string emp_name_qry = "select distinct m.emp_id,Upper(e.NAME+' '+e.FATHER+' '+e.SURNAME) as name  from EmployeePersonal e,web_tp_roletype w,web_tp_login m, m_department d where  w.role_id=m.role_id and e.emp_id=m.emp_id and e.del_flag=0 and e.emp_id= '" + ddl_emp_name.SelectedValue.ToString() + "'";
        DataTable dt_emp_name_qry = cls.fillDataTable(emp_name_qry);
        ddl_emp_name.DataTextField = "name";
        ddl_emp_name.DataValueField = "emp_id";
        ddl_emp_name.DataSource = dt_emp_name_qry;
        ddl_emp_name.DataBind();
    }
    protected void grd_load_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")

        {
            Clear();

            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvrow = grd_load.Rows[index];
            Label LBLSRNO = (Label)grd_load.Rows[index].FindControl("lbl_srno");
            Label LBLEMPID = (Label)grd_load.Rows[index].FindControl("lbl_empid");
            Label LBLINFORMTOSUPERIOR = (Label)grd_load.Rows[index].FindControl("lbl_inform_to_superior");
            Label LBL_LDAYSTYPE = (Label)grd_load.Rows[index].FindControl("lbl_leave_days_type");
            Label LBL_LDAYSTYPENO = (Label)grd_load.Rows[index].FindControl("lbl_leave_days_type_no");
            Label LBL_LTYPE = (Label)grd_load.Rows[index].FindControl("lbl_Ltype");
            Label LBLCL = (Label)grd_load.Rows[index].FindControl("lbl_cl");
            Label LBLCO = (Label)grd_load.Rows[index].FindControl("lbl_co");
            Label LBLML = (Label)grd_load.Rows[index].FindControl("lbl_ml");
            Label LBLEL = (Label)grd_load.Rows[index].FindControl("lbl_el");
            Label LBLOUTD = (Label)grd_load.Rows[index].FindControl("lbl_outd");
            Label LBLLWP = (Label)grd_load.Rows[index].FindControl("lbl_lwp");
            Label LBLMATERNITY = (Label)grd_load.Rows[index].FindControl("lbl_maternity");
            Label LBLHQ = (Label)grd_load.Rows[index].FindControl("lbl_hq");
            Label LBL_LFROM = (Label)grd_load.Rows[index].FindControl("lbl_Lfrom");
            Label LBL_LTO = (Label)grd_load.Rows[index].FindControl("lbl_Lto");
            Label LBL_LDAYS = (Label)grd_load.Rows[index].FindControl("lbl_Ldays");

            Label LBL_LOCUMID = (Label)grd_load.Rows[index].FindControl("lbl_locumID");
            Label LBL_LADD = (Label)grd_load.Rows[index].FindControl("lbl_Ladd");
            Label LBLCONTACTNO = (Label)grd_load.Rows[index].FindControl("lbl_contactno");
            Label LBLREASONLEAVE = (Label)grd_load.Rows[index].FindControl("lbl_resleave");
            Label LBLREMARK = (Label)grd_load.Rows[index].FindControl("lbl_remark");
            Label LBLDETAILS = (Label)grd_load.Rows[index].FindControl("lbl_details");
            Label LBL_HODID = (Label)grd_load.Rows[index].FindControl("lbl_hodID");
            Label LBL_PRINCIPALID = (Label)grd_load.Rows[index].FindControl("lbl_principalID");
            string leavetype = LBL_LTYPE.Text;

            if (leavetype == "CL")
            {
                rdbcl.Checked = true;
                txtcl.Enabled = true;
                rdbcomp.Checked = false;
                rdbml.Checked = false;
                rdbel.Checked = false;
                rdboutd.Checked = false;
                rdbhalf.Checked = false;
                rdbvacation.Checked = false;
                rdb_hq.Checked = false;
                txtleavedaysno.Enabled = true;
                txtadd.Enabled = false;
                txt_contact.Enabled = false;
                txtadd.Text = "";
                txt_contact.Text = "";
                hq.Visible = true;
                rdbmaternity.Checked = false;
                txtmaternity.Enabled = false;
                rdblwp.Checked = false;
                txtlwp.Enabled = false;
            }


            if (leavetype == "CO")
            {
                rdbcomp.Checked = true;
                txtcomp.Enabled = true;
                rdbcl.Checked = false;
                rdbml.Checked = false;
                rdbel.Checked = false;
                rdboutd.Checked = false;
                rdbhalf.Checked = false;
                rdbvacation.Checked = false;
                rdb_hq.Checked = false;
                txtleavedaysno.Enabled = true;
                txtadd.Enabled = false;
                txt_contact.Enabled = false;
                txtadd.Text = "";
                txt_contact.Text = "";
                rdbmaternity.Checked = false;
                txtmaternity.Enabled = false;
                rdblwp.Checked = false;
                txtlwp.Enabled = false;
            }


            if (leavetype == "ML")
            {
                rdbml.Checked = true;
                txtml.Enabled = true;
                rdbcl.Checked = false;
                rdbcomp.Checked = false;
                rdbel.Checked = false;
                rdboutd.Checked = false;
                rdbhalf.Checked = false;
                rdbvacation.Checked = false;
                rdb_hq.Checked = false;
                txtleavedaysno.Enabled = true;
                txtadd.Enabled = false;
                txt_contact.Enabled = false;
                txtadd.Text = "";
                txt_contact.Text = "";
                rdbmaternity.Checked = false;
                txtmaternity.Enabled = false;
                rdblwp.Checked = false;
                txtlwp.Enabled = false;
            }


            if (leavetype == "EL")
            {
                rdbel.Checked = true;
                txtel.Enabled = true;
                rdbcl.Checked = false;
                rdbcomp.Checked = false;
                rdbml.Checked = false;
                rdboutd.Checked = false;
                rdbhalf.Checked = false;
                rdbvacation.Checked = false;
                rdb_hq.Checked = false;
                txtleavedaysno.Enabled = true;
                txtadd.Enabled = false;
                txt_contact.Enabled = false;
                txtadd.Text = "";
                txt_contact.Text = "";
                rdbmaternity.Checked = false;
                txtmaternity.Enabled = false;
                rdblwp.Checked = false;
                txtlwp.Enabled = false;
            }


            if (leavetype == "OUTD")
            {
                rdboutd.Checked = true;
                txtoutd.Enabled = true;
                rdbcl.Checked = false;
                rdbcomp.Checked = false;
                rdbml.Checked = false;
                rdbel.Checked = false;
                rdbhalf.Checked = false;
                rdbvacation.Checked = false;
                rdb_hq.Checked = false;
                txtleavedaysno.Enabled = true;
                txtadd.Enabled = false;
                txt_contact.Enabled = false;
                txtadd.Text = "";
                txt_contact.Text = "";
                rdbmaternity.Checked = false;
                txtmaternity.Enabled = false;
                rdblwp.Checked = false;
                txtlwp.Enabled = false;
            }

            if (leavetype == "LWP")
            {
                rdblwp.Checked = true;
                txtlwp.Enabled = true;
                rdbml.Checked = false;
                txtml.Enabled = false;
                rdbcl.Checked = false;
                rdbcomp.Checked = false;
                rdbel.Checked = false;
                rdboutd.Checked = false;
                rdbhalf.Checked = false;
                rdbvacation.Checked = false;
                rdb_hq.Checked = false;
                txtleavedaysno.Enabled = true;
                txtadd.Enabled = false;
                txt_contact.Enabled = false;
                txtadd.Text = "";
                txt_contact.Text = "";
            }

            if (leavetype == "MATERNITY")
            {
                rdbmaternity.Checked = true;
                txtmaternity.Enabled = true;
                rdblwp.Checked = false;
                txtlwp.Enabled = false;
                rdbml.Checked = false;
                txtml.Enabled = false;
                rdbcl.Checked = false;
                rdbcomp.Checked = false;
                rdbel.Checked = false;
                rdboutd.Checked = false;
                rdbhalf.Checked = false;
                rdbvacation.Checked = false;
                rdb_hq.Checked = false;
                txtleavedaysno.Enabled = true;
                txtadd.Enabled = false;
                txt_contact.Enabled = false;
                txtadd.Text = "";
                txt_contact.Text = "";
            }

            if (leavetype == "HALFDAY")
            {
                rdbhalf.Checked = true;
                rdbcl.Checked = false;
                rdbcomp.Checked = false;
                rdbml.Checked = false;
                rdbel.Checked = false;
                rdboutd.Checked = false;
                rdbvacation.Checked = false;
                rdb_hq.Checked = false;
                txtleavedaysno.Enabled = true;
                txtadd.Enabled = false;
                txt_contact.Enabled = false;
                txtadd.Text = "";
                txt_contact.Text = "";
                rdbmaternity.Checked = false;
                txtmaternity.Enabled = false;
                rdblwp.Checked = false;
                txtlwp.Enabled = false;
            }


            if (leavetype == "VACATION")
            {
                rdbvacation.Checked = true;
                rdbcl.Checked = false;
                rdbcomp.Checked = false;
                rdbml.Checked = false;
                rdbel.Checked = false;
                rdboutd.Checked = false;
                rdbhalf.Checked = false;
                rdb_hq.Checked = false;
                txtleavedaysno.Enabled = true;
                txtadd.Enabled = true;
                txt_contact.Enabled = true;
                txtres.Enabled = false;
                rdbmaternity.Checked = false;
                txtmaternity.Enabled = false;
                rdblwp.Checked = false;
                txtlwp.Enabled = false;
            }

            if (leavetype == "HQ")
            {
                rdb_hq.Checked = true;
                rdbcl.Checked = false;
                rdbcomp.Checked = false;
                rdbml.Checked = false;
                rdbel.Checked = false;
                rdboutd.Checked = false;
                rdbhalf.Checked = false;
                rdbvacation.Checked = false;
                ddl_adjust_alternative.Enabled = false;
                txtleavedaysno.Enabled = true;
                txtadd.Enabled = true;
                txt_contact.Enabled = true;
                rdbmaternity.Checked = false;
                txtmaternity.Enabled = false;
                rdblwp.Checked = false;
                txtlwp.Enabled = false;
            }

            txtcl.Text = LBLCL.Text;
            txtcomp.Text = LBLCO.Text;
            txtml.Text = LBLML.Text;
            txtel.Text = LBLEL.Text;
            txtoutd.Text = LBLOUTD.Text;
            txtlwp.Text = LBLLWP.Text;
            txtmaternity.Text = LBLMATERNITY.Text;
            ddl_inform_to_superrior.SelectedValue = LBLINFORMTOSUPERIOR.Text;
            ddl_leave_days_type.SelectedValue = LBL_LDAYSTYPE.Text;
            txtleavedaysno.Text = LBL_LDAYSTYPENO.Text;
            fdate.Text = LBL_LFROM.Text;
            tdate.Text = LBL_LTO.Text;
            tdate.Attributes.Remove("disabled");
            txtdays.Text = LBL_LDAYS.Text;
            hiddays.Value = LBL_LDAYS.Text;


            if (LBLHQ.Text == "")
            {
                ddlhq.SelectedIndex = 0;
            }
            else
            {
                ddlhq.SelectedValue = LBLHQ.Text;
            }

            if (ddlhq.SelectedValue == "YES")
            {
                txtadd.Enabled = true;
                txt_contact.Enabled = true;
            }

            if (LBL_LOCUMID.Text != "")
            {
                ddl_emp_name.Attributes.Remove("disabled");
                dataload();
                ddl_adjust_alternative.SelectedValue = "yes";

                string[] locumid = LBL_LOCUMID.Text.Split(',');

                for (int j = 0; j < locumid.Length; j++)
                {
                    for (int i = 0; i < ddl_emp_name.Items.Count; i++)

                    {

                        if (ddl_emp_name.Items[i].Value.Trim() == locumid[j])
                        {
                            ddl_emp_name.Items[i].Selected = true;



                        }

                    }
                }


            }
            else
            {
                ddl_adjust_alternative.SelectedValue = "no";
            }
            if (LBL_LDAYSTYPE.Text == "NA")
            {
                txtleavedaysno.Enabled = false;
            }
            // LOCUM();
            txtadd.Text = LBL_LADD.Text;
            txtres.Text = LBLREASONLEAVE.Text;
            txt_contact.Text = LBLCONTACTNO.Text;
            txtdetails.Text = LBLDETAILS.Text;
            txt_sr.Text = LBLSRNO.Text;

            string[] hod_id = LBL_HODID.Text.Split(',');

            for (int h = 0; h < hod_id.Length; h++)
            {
                //  dataload();
                for (int z = 0; z < ddl_hod.Items.Count; z++)

                {

                    if (ddl_hod.Items[z].Value == hod_id[h])
                    {
                        ddl_hod.Items[z].Selected = true;



                    }

                }
            }


            string[] principal_id = LBL_PRINCIPALID.Text.Split(',');

            for (int h = 0; h < principal_id.Length; h++)
            {
                //  dataload();
                for (int z = 0; z < ddl_principal.Items.Count; z++)

                {

                    if (ddl_principal.Items[z].Value == principal_id[h])
                    {
                        ddl_principal.Items[z].Selected = true;



                    }

                }
            }
            btn_Save.Text = "Update";


        }


        //GridViewRow rowSelect = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
        //int rowindex = rowSelect.RowIndex;

        if (e.CommandName == "delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvrow = grd_load.Rows[index];
            Label lbl_SRNO = (Label)grd_load.Rows[index].FindControl("lbl_srno");
            Label lbl_EMPID = (Label)grd_load.Rows[index].FindControl("lbl_empid");

            string del_qry = "update Emp_Leave_Form set del_flag = 1 where emp_id='" + lbl_EMPID.Text + "' and srno='" + lbl_SRNO.Text + "'";

            if (cls.DMLqueries(del_qry))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Leave deleted successfully', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                Clear();
                btn_Save.Text = "Save";
            }
            else { }
        }


        if (e.CommandName == "print")
        {

            //Response.Write("<script>");           
            // var newurl = "LeaveApplicationForm.aspx?cameraid=";
            // Response.Write("window.open('" + newurl + "',null,'height=600px,width=600px,status=0,toolbar=0,menubar=0,location=0')");
            //Response.Write("</script>");
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvrow = grd_load.Rows[index];
            Label lbl_SRNO = (Label)grd_load.Rows[index].FindControl("lbl_srno");
            Label lbl_EMPID = (Label)grd_load.Rows[index].FindControl("lbl_empid");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('LeaveApplicationForm.aspx','_newtab');", true);
            Session["srno"] = lbl_SRNO.Text;
            Session["emp_id"] = lbl_EMPID.Text;



        }

        if (e.CommandName == "view")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvrow = grd_load.Rows[index];
            Label lbl_SRNO = (Label)grd_load.Rows[index].FindControl("lbl_srno");
            Session["srno"] = lbl_SRNO.Text;

            string filename = Session["emp_id"].ToString() + "_" + lbl_SRNO.Text + ".pdf";




            //string path = ("http://localhost:60604/Applications/" + filename);
            string path = ("https://imr.vivacollege.in/viva_imr_v_1/Applications/" + filename);

            Response.Write("<script>");
            Response.Write("window.open('" + path + "',null,'height=600px,width=700px,status=0,toolbar=no,location=0')");
            Response.Write("</script>");
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + path + "','_newtab');", true);
        }
    }

    protected void grd_load_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        gridload();
    }

    public void application()
    {
        if (btn_Save.Text == "Save")
        {

            string empid = Session["emp_id"].ToString();
            string srno_qry = "select top 1 srno from Emp_Leave_Form where emp_id='" + Session["emp_id"].ToString() + "' and del_flag=0  order by curr_dt desc";
            DataTable ds = cls.fillDataTable(srno_qry);

            string srno = ds.Rows[0]["srno"].ToString();
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                if (fileName != "")
                {
                    string[] chkext = fileName.Split(' ');
                    if (fileName.ToLower().Contains("pdf"))
                    {

                        string path = (Server.MapPath("~/Applications/"));
                        if (fileName != "")
                        {
                            string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                            FileUpload1.SaveAs(path + empid + '_' + srno + extension);


                        }


                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('.pdf format only', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;

                    }
                }
            }


        }
        else
        {
            //string[] folders = Directory.GetFiles(Server.MapPath("~/Applications/"));
            string empid = Session["emp_id"].ToString();
            string filename = Session["emp_id"].ToString() + "_" + txt_sr.Text + ".pdf";
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                if (fileName != "")
                {
                    string[] chkext = fileName.Split(' ');
                    if (fileName.ToLower().Contains("pdf"))
                    {

                        string path = (Server.MapPath("~/Applications/"));
                        if (fileName != "")
                        {
                            string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                            FileUpload1.SaveAs(path + filename);


                        }


                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('.pdf format only', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);

                    }
                }
            }
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        string leave_type = "", no_of_CL = "", no_of_CO = "", no_of_ML = "", no_of_EL = "", no_of_OUTD = "", no_of_LWP = "", no_of_MATERNITY = "", no_of_HALFDAY = "", no_of_VACATION = "", no_of_HQ = "";
        if (rdbcl.Checked == true && txtcl.Text == "" || rdbcomp.Checked == true && txtcomp.Text == "" || rdbml.Checked == true && txtml.Text == "" || rdbel.Checked == true && txtel.Text == "" || rdboutd.Checked == true && txtoutd.Text == "" || rdblwp.Checked == true && txtlwp.Text == "" || rdbmaternity.Checked == true && txtmaternity.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Number of Days for checked Leave Type', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            if (rdbcl.Checked == true)
            {
                leave_type = "CL";
                no_of_CL = txtcl.Text;

            }
            else if (rdbcomp.Checked == true)
            {
                leave_type = "CO";
                no_of_CO = txtcomp.Text;
            }
            else if (rdbml.Checked == true)
            {
                leave_type = "ML";
                no_of_ML = txtml.Text;
            }
            else if (rdbel.Checked == true)
            {
                leave_type = "EL";
                no_of_EL = txtel.Text;
            }
            else if (rdboutd.Checked == true)
            {
                leave_type = "OUTD";
                no_of_OUTD = txtoutd.Text;
            }
            else if (rdblwp.Checked == true)
            {
                leave_type = "LWP";
                no_of_LWP = txtlwp.Text;
            }
            else if (rdbmaternity.Checked == true)
            {
                leave_type = "MATERNITY";
                no_of_MATERNITY = txtmaternity.Text;
            }
            else if (rdbhalf.Checked == true)
            {
                leave_type = "HALFDAY";
                no_of_HALFDAY = "1";
            }
            else if (rdbvacation.Checked == true)
            {
                leave_type = "VACATION";
                no_of_VACATION = "1";
            }
            else if (rdb_hq.Checked == true)
            {
                leave_type = "HQ";
                no_of_HQ = "1";
            }
        }



        string alternative_emp_id = "";
        string alternative_emp_name = "";

        for (int i = 0; i < ddl_emp_name.Items.Count; i++)
        {
            if (ddl_emp_name.Items[i].Selected)
            {

                if (alternative_emp_id == "" && alternative_emp_name == "")
                {
                    alternative_emp_id = ddl_emp_name.Items[i].Value;
                    alternative_emp_name = ddl_emp_name.Items[i].Text;
                }
                else
                {
                    alternative_emp_id = alternative_emp_id + "," + ddl_emp_name.Items[i].Value;
                    alternative_emp_name = alternative_emp_name + "," + ddl_emp_name.Items[i].Text;
                }

            }

        }


        string HOD_ID_multiselect = "";

        for (int i = 0; i < ddl_hod.Items.Count; i++)
        {
            if (ddl_hod.Items[i].Selected)
            {

                if (HOD_ID_multiselect == "")
                {
                    HOD_ID_multiselect = ddl_hod.Items[i].Value;
                }
                else
                {
                    HOD_ID_multiselect = HOD_ID_multiselect + "," + ddl_hod.Items[i].Value;
                }

            }

        }


        string PRINCIPAL_ID_multiselect = "";

        for (int i = 0; i < ddl_principal.Items.Count; i++)
        {
            if (ddl_principal.Items[i].Selected)
            {

                if (PRINCIPAL_ID_multiselect == "")
                {
                    PRINCIPAL_ID_multiselect = ddl_principal.Items[i].Value;
                }
                else
                {
                    PRINCIPAL_ID_multiselect = PRINCIPAL_ID_multiselect + "," + ddl_principal.Items[i].Value;
                }

            }

        }





        if (btn_Save.Text == "Save")
        {
            if (leave_type == "ML")
            {

                if (Convert.ToDecimal(no_of_ML) > 2)
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (filename == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Upload your Certificate', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;

                    }
                    decimal size = Math.Round(((decimal)FileUpload1.PostedFile.ContentLength / (decimal)1024), 2);
                    if (size > 200)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('File size must not exceed 200 KB.', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;

                    }
                    else
                    {


                    }
                }
                else
                {

                }
            }

            if (leave_type == "OUTD")
            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (filename == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Upload your Certificate', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;

                }
            }

            if (leave_type == "CO")
            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (filename == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Upload your Certificate', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;

                }
            }

            if (ddlhq.SelectedValue == "YES" || leave_type == "VACATION")
            {
                if (txtadd.Text == "" || txt_contact.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter address & contact', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
                    return;
                }
                else { }
                if (txt_contact.Text.Length < 10)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter 10 digit contact no', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;
                }
                else { }
            }

            if (leave_type == "CL")
            {
                if (ddlhq.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select HQ is YES/NO', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;
                }
            }
            //else
            //{

            //}


            //if (rdbcl.Checked == true || rdbcomp.Checked == true || rdbml.Checked == true || rdbel.Checked == true || rdboutd.Checked == true || rdb_hq.Checked == true)
            //{
            //    if (txtres.Text.Trim() == "")
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter your reason', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
            //        return;
            //    }
            //}
            //else
            //{

            //}

            bool lstboxcheckornot_principal = false;
            for (int i = 0; i < ddl_principal.Items.Count; i++)
            {
                if (ddl_principal.Items[i].Selected == true)
                {
                    lstboxcheckornot_principal = true;
                }
                //else
                //{
                //    lstboxcheckornot_principal = false;
                //}
            }


            if (ddl_adjust_alternative.SelectedValue == "yes")
            {
                if (rdbcl.Checked == true || rdbcomp.Checked == true || rdbml.Checked == true || rdbel.Checked == true || rdboutd.Checked == true)
                {
                    string lstboxcheckornot = "";

                    for (int i = 0; i < ddl_emp_name.Items.Count; i++)
                    {
                        if (ddl_emp_name.Items[i].Selected == true)
                        {
                            lstboxcheckornot = "true";
                            if (txtdetails.Text == "")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter your div/course/date & time of lectures/practicals details', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                                return;
                            }

                        }

                    }
                    if (lstboxcheckornot == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select alternative arrangement', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
            }

            if (ddl_leave_days_type.SelectedValue == "Prefix" || ddl_leave_days_type.SelectedValue == "Suffix" || ddl_leave_days_type.SelectedValue == "Both")
            {
                if (txtleavedaysno.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter number of leave days', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;
                }

            }


            if (rdbcl.Checked == false && rdbcomp.Checked == false && rdbml.Checked == false && rdbel.Checked == false && rdboutd.Checked == false && rdblwp.Checked == false && rdbmaternity.Checked == false && rdbhalf.Checked == false && rdbvacation.Checked == false && rdb_hq.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select leave type', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;

            }



            else if (rdbcl.Checked == true && txtcl.Text == "" || rdbcomp.Checked == true && txtcomp.Text == "" || rdbml.Checked == true && txtml.Text == "" || rdbel.Checked == true && txtel.Text == "" || rdboutd.Checked == true && txtoutd.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Number of Days for checked Leave Type', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;
            }
            else if (lstboxcheckornot_principal != true)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select principal', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;
            }
            else if (ddl_inform_to_superrior.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select inform to superior', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;
            }
            else if (ddl_leave_days_type.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select leave days type', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;
            }
            else if (ddl_adjust_alternative.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select adjustment arrangement', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;
            }
            else if (fdate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select from date', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;
            }
            else if (tdate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select to date', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;
            }
            else if (txtres.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Reason For Leave', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;
            }
            else if (txtdetails.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter your div/course/date & time of lectures/practicals details', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;
            }
            else if (txtdays.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter number of days', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                return;
            }

            else

            {
                string insrt_qry = "INSERT INTO Emp_Leave_Form (emp_id,inform_to_superior, leaveType, leaveF, leaveT,leaveDays,locumID,locumName,leaveadd,contactno,CL,CO,ML,EL,OUTD,LWP,MATERNITY,halfday,vacation,HQ,leave_days_type,leave_days_type_no,resleave,details,AYID,del_flag,curr_dt,HOD_ID,PRINCIPAL_ID)VALUES('" + Session["emp_id"].ToString() + "','" + ddl_inform_to_superrior.SelectedValue.ToString() + "', '" + leave_type + "', convert(Date,'" + fdate.Text.Trim() + "',105),  convert(Date,'" + tdate.Text.Trim() + "',105), '" + txtdays.Text + "', '" + alternative_emp_id + "', '" + alternative_emp_name + "', '" + txtadd.Text.Trim().Replace("'", "''") + "', '" + txt_contact.Text.Trim() + "', '" + no_of_CL + "', '" + no_of_CO + "', '" + no_of_ML + "', '" + no_of_EL + "', '" + no_of_OUTD + "', '" + no_of_LWP + "', '" + no_of_MATERNITY + "', '" + no_of_HALFDAY + "', '" + no_of_VACATION + "','" + ddlhq.SelectedValue.ToString() + "','" + ddl_leave_days_type.SelectedValue.ToString() + "','" + txtleavedaysno.Text.Trim() + "', '" + txtres.Text.Trim().Replace("'", "''") + "','" + txtdetails.Text.Trim().Replace("'", "''") + "','" + Session["Year"].ToString() + "', 0, GETDATE(),'" + HOD_ID_multiselect + "','" + PRINCIPAL_ID_multiselect + "');";

                if (cls.DMLqueries(insrt_qry))
                {
                    application();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Data saved successfully.', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Error occured !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                }
                Clear();
                gridload();
            }


        }

        else
        {
            if (btn_Save.Text == "Update")
            {
                if (leave_type == "ML")
                {

                    if (Convert.ToDecimal(no_of_ML) > 2)
                    {
                        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                        if (filename == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Upload your Certificate', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                            return;

                        }
                        decimal size = Math.Round(((decimal)FileUpload1.PostedFile.ContentLength / (decimal)1024), 2);
                        if (size > 200)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('File size must not exceed 200 KB.', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                            return;

                        }
                        else
                        {


                        }
                    }
                    else
                    {

                    }
                }

                if (leave_type == "OUTD")
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Upload your Certificate', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;

                    }
                }

                if (leave_type == "CO")
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Upload your Certificate', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;

                    }
                }

                if (rdbcl.Checked == true || rdbcomp.Checked == true || rdbml.Checked == true || rdbel.Checked == true || rdboutd.Checked == true || rdb_hq.Checked == true)
                {
                    if (txtres.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter your reason', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;
                    }

                }
                else
                {

                }

                if (ddlhq.SelectedValue == "YES" || leave_type == "VACATION")
                {
                    if (txtadd.Text == "" || txt_contact.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter address & contact', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                    else { }
                    if (txt_contact.Text.Length < 10)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter 10 digit contact no', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                    else { }
                }

                if (leave_type == "CL")
                {
                    if (ddlhq.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select HQ is YES/NO', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
                else
                {

                }


                bool lstboxcheckornot_principal = false;
                for (int i = 0; i < ddl_principal.Items.Count; i++)
                {
                    if (ddl_principal.Items[i].Selected == true)
                    {
                        lstboxcheckornot_principal = true;
                    }
                }


                if (ddl_adjust_alternative.SelectedValue == "yes")
                {
                    if (rdbcl.Checked == true || rdbcomp.Checked == true || rdbml.Checked == true || rdbel.Checked == true || rdboutd.Checked == true)
                    {
                        string lstboxcheckornot = "";

                        for (int i = 0; i < ddl_emp_name.Items.Count; i++)
                        {
                            if (ddl_emp_name.Items[i].Selected == true)
                            {
                                lstboxcheckornot = "true";
                                if (txtdetails.Text == "")
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter your div/course/date & time of lectures/practicals details', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                                    return;
                                }
                            }

                        }
                        if (lstboxcheckornot == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select alternative arrangement', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                            return;
                        }
                    }
                }
                if (ddl_leave_days_type.SelectedValue == "Prefix" || ddl_leave_days_type.SelectedValue == "Suffix" || ddl_leave_days_type.SelectedValue == "Both")
                {
                    if (txtleavedaysno.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter number of leave days', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti();", true);
                }


                if (rdbcl.Checked == false && rdbcomp.Checked == false && rdbml.Checked == false && rdbel.Checked == false && rdboutd.Checked == false && rdblwp.Checked == false && rdbmaternity.Checked == false && rdbhalf.Checked == false && rdbvacation.Checked == false && rdb_hq.Checked == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select leave type', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;

                }



                else if (rdbcl.Checked == true && txtcl.Text == "" || rdbcomp.Checked == true && txtcomp.Text == "" || rdbml.Checked == true && txtml.Text == "" || rdbel.Checked == true && txtel.Text == "" || rdboutd.Checked == true && txtoutd.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Number of Days for checked Leave Type', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;
                }

                else if (lstboxcheckornot_principal != true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select principal', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;
                }

                else if (ddl_inform_to_superrior.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select inform to superior', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;
                }
                else if (ddl_leave_days_type.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select leave days type', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;
                }

                else if (fdate.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select from date', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;
                }
                else if (tdate.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select to date', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;
                }
                else if (txtdays.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter number of days', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    return;
                }
                else
                {
                    string updt_qry = "update Emp_Leave_Form set inform_to_superior='" + ddl_inform_to_superrior.SelectedValue.ToString() + "',leaveType='" + leave_type + "',leaveF=convert(Date,'" + fdate.Text.Trim() + "',105),leaveT=convert(Date,'" + tdate.Text.Trim() + "',105),leaveDays='" + txtdays.Text + "',locumID='" + alternative_emp_id + "',locumName='" + alternative_emp_name + "',leaveadd='" + txtadd.Text.Trim().Replace("'", "''") + "',contactno='" + txt_contact.Text.Trim() + "',CL='" + no_of_CL + "',CO='" + no_of_CO + "',ML='" + no_of_ML + "',EL='" + no_of_EL + "',OUTD='" + no_of_OUTD + "',LWP='" + no_of_LWP + "',MATERNITY='" + no_of_MATERNITY + "',halfday='" + no_of_HALFDAY + "',vacation='" + no_of_VACATION + "',HQ='" + ddlhq.SelectedValue.ToString() + "',leave_days_type='" + ddl_leave_days_type.SelectedValue.ToString() + "',leave_days_type_no='" + txtleavedaysno.Text.Trim() + "',resleave='" + txtres.Text.Trim().Replace("'", "''") + "',details='" + txtdetails.Text.Trim().Replace("'", "''") + "',del_flag=0,mod_dt=GETDATE(),HOD_ID='" + HOD_ID_multiselect + "',PRINCIPAL_ID='" + PRINCIPAL_ID_multiselect + "' where srno='" + txt_sr.Text.Trim() + "' and emp_id='" + Session["emp_id"].ToString() + "' and AYID='" + Session["Year"].ToString() + "'";

                    if (cls.DMLqueries(updt_qry))
                    {
                        application();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Data updated successfully.', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Error occured !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    }
                    Clear();
                    gridload();
                }
            }

        }

    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    public void Clear()
    {
        rdbcl.Checked = false;
        rdbcomp.Checked = false;
        rdbml.Checked = false;
        rdbel.Checked = false;
        rdboutd.Checked = false;
        rdblwp.Checked = false;
        rdbmaternity.Checked = false;
        rdbhalf.Checked = false;
        rdbvacation.Checked = false;
        rdb_hq.Checked = false;
        fdate.Text = "";
        tdate.Text = "";
        txtdays.Text = "";
        hiddays.Value = "";
        ddl_emp_name.Items.Clear();
        txtadd.Text = "";
        txtres.Text = "";
        txtres.Enabled = true;
        txt_contact.Text = "";
        txtcl.Enabled = false;
        txtcomp.Enabled = false;
        txtml.Enabled = false;
        txtel.Enabled = false;
        txtoutd.Enabled = false;
        txtcl.Text = "";
        txtcomp.Text = "";
        txtml.Text = "";
        txtel.Text = "";
        txtoutd.Text = "";
        txtleavedaysno.Text = "";
        ddl_leave_days_type.SelectedIndex = 0;
        ddl_inform_to_superrior.SelectedIndex = 0;
        ddl_adjust_alternative.SelectedIndex = 0;
        ddl_adjust_alternative.Enabled = true;
        ddl_emp_name.Attributes.Add("disabled", "disabled");
        txtdetails.Text = "";
        txtadd.Enabled = false;
        txt_contact.Enabled = false;
        txtlwp.Text = "";
        txtmaternity.Text = "";
        rdblwp.Checked = false;
        rdbmaternity.Checked = false;
        txtlwp.Enabled = false;
        txtmaternity.Enabled = false;
        tdate.Attributes.Add("disabled", "disable");
        ddl_hod.Items.Clear();
        ddl_principal.Items.Clear();
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true); 
        hq.Visible = false;
        ddlhq.SelectedIndex = 0;
        txtcl.BorderColor = System.Drawing.Color.Silver;
        txtml.BorderColor = System.Drawing.Color.Silver;
        txtel.BorderColor = System.Drawing.Color.Silver;
        txtoutd.BorderColor = System.Drawing.Color.Silver;
        txtcomp.BorderColor = System.Drawing.Color.Silver;
        dataload();
        btn_Save.Text = "Save";
    }

    protected void grd_load_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            Label lbl_principle = (Label)e.Row.FindControl("lbl_A_principle");
            Label lbl_hod = (Label)e.Row.FindControl("lbl_A_hod");
            Label lbl_srno = (Label)e.Row.FindControl("lbl_srno");
            LinkButton btnview = (LinkButton)e.Row.FindControl("lnkbtn_view");
            LinkButton btndelete = (LinkButton)e.Row.FindControl("lnkbtn_delete");
            LinkButton btnedit = (LinkButton)e.Row.FindControl("lnkbtn_edit");
            LinkButton btn = (LinkButton)e.Row.FindControl("lnkbtn_print");


            if (lbl_hod.Text == "" && lbl_principle.Text == "")
            {

                //btn.Attributes.Add("disabled", "disabled");
                //btn.CommandName = "";
                btn.Enabled = false;
                btn.BackColor = System.Drawing.Color.LightGreen;

                //e.Row.Cells[22].Enabled = false;

            }

            else
            {

                //btnedit.Attributes.Add("disabled", "disabled");
                //btnedit.CommandName = "";
                //btnedit.Enabled = false;

                btnedit.Enabled = false;
                btnedit.CssClass = "btn btn-success btn-block editDisabled"; 

                //btndelete.Attributes.Add("disabled", "disabled");
                //btndelete.CommandName = "";
                //btnedit.Enabled = false;
                btndelete.Enabled = false;
                btndelete.CssClass = "btn btn-danger btn-block deleteDisabled";
            }

            string[] folders = Directory.GetFiles(Server.MapPath("~/Applications/"));
            string filename = Session["emp_id"].ToString() + "_" + lbl_srno.Text + ".pdf";
            string files = ("~/Applications/" + filename);

            if (File.Exists(Server.MapPath(files)))
            {

            }
            else
            {

                btnview.Attributes.Add("disabled", "disabled");
                btnview.CommandName = "";
                btnview.Enabled = false;
                btnview.BackColor = System.Drawing.Color.LightGreen;
                //btnview.Attributes.Remove("CssClass");
            }



        }

    }

    protected void txtcl_TextChanged(object sender, EventArgs e)
    {
        //string clwrd = lblCL.Text.Trim();
        float LBL_CL = float.Parse(lblCL.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
        float TXT_CL = float.Parse(txtcl.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
        if (TXT_CL > LBL_CL)
        {
            //btn_Save.Attributes.Add("disabled", "disabled");
            txtcl.BorderColor = System.Drawing.Color.Red;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {
            txtcl.BorderColor = System.Drawing.Color.Silver;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
    }

    //protected void txtcomp_TextChanged(object sender, EventArgs e)
    //{
    //    float LBL_COMP = float.Parse(lblCOMPL.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
    //    float TXT_COMP = float.Parse(txtcomp.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
    //    if (TXT_COMP > LBL_COMP)
    //    {            

    //        txtcomp.BorderColor = System.Drawing.Color.Red;
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
    //        btn_Save.Enabled = false;
    //    }
    //    else
    //    {
    //        txtcomp.BorderColor = System.Drawing.Color.Silver;
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
    //        btn_Save.Enabled = true;
    //    }

    //}

    protected void txtml_TextChanged(object sender, EventArgs e)
    {
        float LBL_ML = float.Parse(lblML.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
        float TXT_ML = float.Parse(txtml.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
        if (TXT_ML > LBL_ML)
        {
            txtml.BorderColor = System.Drawing.Color.Red;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {
            txtml.BorderColor = System.Drawing.Color.Silver;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
    }

    protected void txtel_TextChanged(object sender, EventArgs e)
    {
        float LBL_EL = float.Parse(lblEL.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
        float TXT_EL = float.Parse(txtel.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
        if (TXT_EL > LBL_EL)
        {
            txtel.BorderColor = System.Drawing.Color.Red;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
        else
        {
            txtel.BorderColor = System.Drawing.Color.Silver;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
        }
    }

    //protected void txtoutd_TextChanged(object sender, EventArgs e)
    //{
    //    float LBL_OUTD = float.Parse(lblOUTD.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
    //    float TXT_OUTD = float.Parse(txtoutd.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
    //    if (TXT_OUTD > LBL_OUTD)
    //    {
    //        txtoutd.BorderColor = System.Drawing.Color.Red;
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
    //        btn_Save.Enabled = false;
    //    }
    //    else
    //    {
    //        txtoutd.BorderColor = System.Drawing.Color.Silver;
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);
    //        btn_Save.Enabled = true;
    //    }
    //}

    protected void ddlhq_SelectedIndexChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti(); ddl_hod_multi(); ddl_principal_multi(); ", true);

        if (ddlhq.SelectedValue == "YES")
        {
            txtadd.Enabled = true;
            txt_contact.Enabled = true;
            txtadd.Text = "";
            txt_contact.Text = "";
        }
        else
        {
            txtadd.Enabled = false;
            txt_contact.Enabled = false;
            txtadd.Text = "";
            txt_contact.Text = "";
        }
    }

}