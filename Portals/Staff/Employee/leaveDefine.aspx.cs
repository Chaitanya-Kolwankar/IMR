using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Employee_leaveDefine : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["acdyear"]) == "" && Convert.ToString(Session["year"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true);
                
                string emptype = "select role_id,role_name from web_tp_roletype where del_flag=0";
                DataTable dt = cls.fillDataTable(emptype);

                ddl_emp_type.DataSource = dt;
                ddl_emp_type.DataTextField = "role_name";
                ddl_emp_type.DataValueField = "role_id";
                ddl_emp_type.DataBind();
                ddl_emp_type.Items.Insert(0, new ListItem("--Select--", "na"));


                dd_department_load();

                string emp_year = "select AYID,SUBSTRING(Duration,9,4)+'-'+SUBSTRING(Duration,23,4) as Duration from m_academic order by ayid desc";
                DataTable dt_year = cls.fillDataTable(emp_year);

                ddl_year.DataSource = dt_year;
                ddl_year.DataTextField = "Duration";
                ddl_year.DataValueField = "AYID";
                ddl_year.DataBind();
                ddl_year.Items.Insert(0, new ListItem("--Select--", "na"));

                ddl_emp_name.Enabled = false;
                grid.Visible = false;
                gridload();
            }
        }

        
    }

    public void dd_department_load()
    {

        string department_qry = "select Dept_id,Department_name from m_department where del_flag=0";
        DataTable dt_department_qry = cls.fillDataTable(department_qry);
        ddl_department.DataTextField = "Department_name";
        ddl_department.DataValueField = "Dept_id";
        ddl_department.DataSource = dt_department_qry;
        ddl_department.DataBind();
        ddl_department.Items.Insert(0, new ListItem("--Select--", "na"));

    }

    protected void ddl_department_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddl_year.SelectedIndex = 0;
        txtcl.Text = "";
        txtml.Text = "";
        txt_Pml.Text = "";
        txtoutd.Text = "";
        txtel.Text = "";
        txt_Pel.Text = "";
        txtcomp.Text = "";
        ddl_emp_name.Items.Clear();

        string emp_name_qry = "select distinct m.emp_id,Upper(e.NAME+' '+e.FATHER+' '+e.SURNAME) as name  from EmployeePersonal e,web_tp_roletype w,web_tp_login m, m_department d where  w.role_id=m.role_id and e.emp_id=m.emp_id and e.del_flag=0 and e.emp_dept_id= '" + ddl_department.SelectedValue.ToString() + "'";
        DataTable dt_emp_name = cls.fillDataTable(emp_name_qry);
        ddl_emp_name.Enabled = true;
        ddl_emp_name.DataTextField = dt_emp_name.Columns["name"].ToString();
        ddl_emp_name.DataValueField = dt_emp_name.Columns["emp_id"].ToString();
        ddl_emp_name.DataSource = dt_emp_name;
        ddl_emp_name.DataBind();


        

        if (ddl_department.SelectedIndex == 0)
        {
            gridload();
        }
        else
        {
            DataSet dsretrive = new DataSet();

            string dept_gridload = "select  d.id,d.emp_id,e.emp_dept_id,d.CL,d.CO,d.ML,d.EL,d.OUTD,d.PML,d.PEL,d.year,SUBSTRING(a.Duration,9,4)+'-'+SUBSTRING(a.Duration,23,4) as Duration,m.role_id,Upper(e.NAME+' '+e.FATHER+' '+e.SURNAME) as name  from EmployeePersonal e,emp_leave_data d,web_tp_roletype w,web_tp_login m,m_academic a where d.emp_id=e.emp_id and w.role_id=m.role_id and e.emp_id=m.emp_id and d.del_flag=0  and a.AYID='" + Session["Year"].ToString() + "' and d.year='" + Session["Year"].ToString() + "' and e.emp_dept_id='" + ddl_department.SelectedValue.ToString() + "'  order by curr_dt desc ";

            dsretrive = cls.fillDataset(dept_gridload);

            grd_load.DataSource = dsretrive;
            grd_load.DataBind();
        }

    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    public void gridload()
    {
        DataTable dsretrivee = new DataTable();

        string qry = "select d.id,d.emp_id,e.emp_dept_id,d.CL,d.CO,d.ML,d.EL,d.OUTD,d.PML,d.PEL,d.year,SUBSTRING(a.Duration,9,4)+'-'+SUBSTRING(a.Duration,23,4) as Duration,m.role_id,Upper(e.NAME+' '+e.FATHER+' '+e.SURNAME) as name  from EmployeePersonal e,emp_leave_data d,web_tp_roletype w,web_tp_login m,m_academic a where d.emp_id=e.emp_id and w.role_id=m.role_id and e.emp_id=m.emp_id and d.del_flag=0   and a.AYID='" + Session["Year"].ToString() + "' and d.year='" + Session["Year"].ToString() + "' order by curr_dt desc";

        dsretrivee = cls.fillDataTable(qry);

        if (dsretrivee.Rows.Count > 0)
        {
            if (dsretrivee.Rows.Count > 0)
            {
                grid.Visible = true;
                grd_load.DataSource = dsretrivee;
                grd_load.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti()", true);
            }
            else
            {
                grid.Visible = false;
            }
        }
        else
        {
            grid.Visible = false;
            //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('No Data Found!!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

        string str = "";
        string emp_id = "";

        string lstboxcheckornot = "";
        for (int i = 0; i < ddl_emp_name.Items.Count; i++)
        {
            if (ddl_emp_name.Items[i].Selected == true)
            {
                lstboxcheckornot = "true";
            }
        }


        for (int i = 0; i < ddl_emp_name.Items.Count; i++)
        {
            if (ddl_emp_name.Items[i].Selected)
            {

                if (emp_id == "")
                {
                    emp_id = ddl_emp_name.Items[i].Value;
                }
                else
                {
                    emp_id = emp_id + "," + ddl_emp_name.Items[i].Value;
                }

            }

        }
        string[] values = emp_id.Split(',');

        if (ddl_emp_type.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Employee Type ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }
        else if (ddl_department.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Department ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }
        else if (ddl_year.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Year ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }
        else if (lstboxcheckornot == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Employee Name', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }

        else if (txtcl.Text == "" && txtml.Text == "" && txt_Pml.Text == "" && txtel.Text == "" && txt_Pel.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Fill Atleast One Values', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }
        //&& txtoutd.Text == "" && txtcomp.Text == ""  |---remove samiya

        else
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim();
                str = "select * from emp_leave_data where emp_id='" + values[i] + "' and year='" + ddl_year.SelectedValue + "' and del_flag=0 ";
                DataSet ds = cls.fillDataset(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    str = "update emp_leave_data set CL='" + txtcl.Text.Trim() + "',CO='" + txtcomp.Text.Trim() + "',ML='" + txtml.Text.Trim() + "',EL='" + txtel.Text.Trim() + "',OUTD='" + txtoutd.Text.Trim() + "',PML='" + txt_Pml.Text.Trim() + "',PEL='" + txt_Pel.Text.Trim() + "',mod_dt=getdate() where emp_id='" + values[i] + "'  and year='" + ddl_year.SelectedValue + "' and year='" + ddl_year.SelectedValue + "'";
                    if (cls.DMLqueries(str) == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Leave updated successfully.', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                        btnsave.Text = "Save";
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Leave not updated!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    }

                }
                else
                {
                    str = "insert into emp_leave_data (emp_id,CL,CO,ML,EL,OUTD,PML,PEL,year,curr_dt,del_flag) values('" + values[i] + "','" + txtcl.Text.Trim() + "','" + txtcomp.Text.Trim() + "','" + txtml.Text.Trim() + "','" + txtel.Text.Trim() + "','" + txtoutd.Text.Trim() + "','" + txt_Pml.Text.Trim() + "','" + txt_Pel.Text.Trim() + "','" + ddl_year.SelectedValue + "',getdate(),0)";
                    if (cls.DMLqueries(str) == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Leave saved successfully', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Leave not saved!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    }

                }


            }
            Clear();

        }

        gridload();
    }


    public void department_empname()
    {

        string emp_name_qry = "select distinct m.emp_id,Upper(e.NAME+' '+e.FATHER+' '+e.SURNAME) as name  from EmployeePersonal e,web_tp_roletype w,web_tp_login m, m_department d where  w.role_id=m.role_id and e.emp_id=m.emp_id and e.del_flag=0 and e.emp_dept_id= '" + ddl_department.SelectedValue.ToString() + "'";


        DataTable dt_emp_name = cls.fillDataTable(emp_name_qry);
        ddl_emp_name.DataTextField = dt_emp_name.Columns["name"].ToString();
        ddl_emp_name.DataValueField = dt_emp_name.Columns["emp_id"].ToString();
        ddl_emp_name.DataSource = dt_emp_name;
        ddl_emp_name.DataBind();

        ddl_emp_name.Enabled = true;
    }


    protected void grd_load_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvrow = grd_load.Rows[index];
            Label lblID = (Label)grd_load.Rows[index].FindControl("lbl_id");
            Label lblAYID = (Label)grd_load.Rows[index].FindControl("lblayid");
            Label lblEMPID = (Label)grd_load.Rows[index].FindControl("lblempid");
            Label lblDEPTID = (Label)grd_load.Rows[index].FindControl("lblDeptid");
            Label lblNAME = (Label)grd_load.Rows[index].FindControl("lblempname");
            Label lblCL = (Label)grd_load.Rows[index].FindControl("lblcl");
            Label lblCOMP = (Label)grd_load.Rows[index].FindControl("lblco");
            Label lblML = (Label)grd_load.Rows[index].FindControl("lblml");
            Label lblPML = (Label)grd_load.Rows[index].FindControl("lblPml");
            Label lblEL = (Label)grd_load.Rows[index].FindControl("lblel");
            Label lblPEL = (Label)grd_load.Rows[index].FindControl("lblPel");
            Label lblOUTD = (Label)grd_load.Rows[index].FindControl("lbloutd");
            Label lblROLEID = (Label)grd_load.Rows[index].FindControl("lblroleid");


            txtcl.Text = lblCL.Text;
            txtcomp.Text = lblCOMP.Text;
            txtml.Text = lblML.Text;
            txt_Pml.Text = lblPML.Text;
            txtel.Text = lblEL.Text;
            txt_Pel.Text = lblPEL.Text;
            txtoutd.Text = lblOUTD.Text;
            ddl_year.SelectedValue = lblAYID.Text;

            ddl_emp_type.SelectedValue = lblROLEID.Text;
            ddl_department.SelectedValue = lblDEPTID.Text;

            department_empname();
            ddl_emp_name.SelectedValue = lblEMPID.Text;
            btnsave.Text = "Update";


        }
        if (e.CommandName == "delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvrow = grd_load.Rows[index];
            Label lblID = (Label)grd_load.Rows[index].FindControl("lbl_id");
            Label lblEMPID = (Label)grd_load.Rows[index].FindControl("lblempid");

            string del_qry = "update emp_leave_data set del_flag=1 where emp_id='" + lblEMPID.Text + "' and id='" + lblID.Text + "'";

            if (cls.DMLqueries(del_qry))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Leave deleted successfully', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                Clear();
                btnsave.Text = "Save";
            }
            else { }
        }

    }

    public void Clear()
    {
        ddl_emp_type.SelectedIndex = 0;
        ddl_department.SelectedIndex = 0;
        ddl_year.SelectedIndex = 0;
        txtcl.Text = "";
        txtml.Text = "";
        txt_Pml.Text = "";
        txtoutd.Text = "";
        txtel.Text = "";
        txt_Pel.Text = "";
        txtcomp.Text = "";
        ddl_emp_name.Items.Clear();

    }

    protected void grd_load_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        gridload();
    }

    protected void ddl_emp_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_department.SelectedIndex = 0;
        ddl_year.SelectedIndex = 0;
        txtcl.Text = "";
        txtml.Text = "";
        txt_Pml.Text = "";
        txtoutd.Text = "";
        txtel.Text = "";
        txt_Pel.Text = "";
        txtcomp.Text = "";
        ddl_emp_name.Items.Clear();
        gridload();
    }
}