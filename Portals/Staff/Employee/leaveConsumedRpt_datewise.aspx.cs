using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Employee_leaveConsumedRpt_datewise : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grd_load.Visible = false;
            btn_excel.Visible = false;
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "loadmulti();", true);
            string emptype = "select * from m_department";
            DataTable dt = cls.fillDataTable(emptype);

            ddl_department.DataSource = dt;
            ddl_department.DataTextField = "Department_name";
            ddl_department.DataValueField = "Dept_id";
            ddl_department.DataBind();
            //ddl_department.Items.Insert(0, new ListItem("--Select--", "na"));
        }

    }

    public void gridload()
    {
        //string f_date = fdate.Text.Trim();
        //string t_date = tdate.Text.Trim();

        DataTable dsretrive = new DataTable();

        string department_id = "";


        for (int i = 0; i < ddl_department.Items.Count; i++)
        {
            if (ddl_department.Items[i].Selected)
            {

                if (department_id == "")
                {
                    department_id = ddl_department.Items[i].Value;

                }
                else
                {
                    department_id = department_id + "','" + ddl_department.Items[i].Value;

                }

            }

        }

        //string qry = "select distinct ROW_NUMBER() Over (Order by emp_id) As [Sr No.],emp_id as [EMPLOYEE ID],emp_name[EMPLOYEE NAME],designation[DESIGNATION],DEPARTMENT,[DATE OF JOINING],CL,ML,EL,BCL,BML,BEL,LT_CL,LT_ML,LT_EL,LWP,LT_CO,LT_OUTD,'CO-' + cast(LT_CO as varchar) + '  ' + 'OD-' + cast(LT_OUTD as varchar)[CO_OUTD],CL_dates,ML_dates,EL_dates,OUTD_dates,CO_dates,LWP_dates,MATERNITY_dates from (select distinct e.emp_id,UPPER(isnull(name,'')+' '+isnull(father,'')+' '+isnull(surname,'')) as Emp_Name,CURRENT_DESIGNATION as Designation,(select Department_name from m_department where Dept_id= e.emp_dept_id) as DEPARTMENT,replace(convert(NVARCHAR, e.DOJ, 106), ' ', '-') AS [DATE OF JOINING],(cast(d.CL as float)+cast(d.ML as float)+cast(d.EL as float) ) as LeaveDefine,cast(leaveDays as int) as leavedays,d.CL, d.ML, d.EL,(SELECT ISNULL(sum(cast((cl) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0  and emp_id = l.emp_id) as LT_CL,(SELECT ISNULL(sum(cast((ML) as float)), 0)FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0  and emp_id = l.emp_id) as LT_ML,(SELECT ISNULL(sum(cast((el) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0 and emp_id = l.emp_id) as LT_EL,(SELECT ISNULL(sum(cast((LWP) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0 and emp_id = l.emp_id) as LWP,(SELECT ISNULL(sum(cast((CO) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0 and emp_id = l.emp_id) as LT_CO ,(SELECT ISNULL(sum(cast((OUTD) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0 and emp_id = l.emp_id) as LT_OUTD,(select distinct STUFF((SELECT ',CL(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='cl'  and approved_flag_PRINCIPLE = 0 FOR XML PATH('')), 1, 1, '' ) from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='cl'  and approved_flag_PRINCIPLE = 0) as CL_dates,(select distinct STUFF((SELECT ',ML(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='ml'  and approved_flag_PRINCIPLE = 0 FOR XML PATH('')), 1, 1, '' ) from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='ml'  and approved_flag_PRINCIPLE = 0) as ML_dates,(select distinct STUFF((SELECT ',EL(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='el'  and approved_flag_PRINCIPLE = 0 FOR XML PATH('')), 1, 1, '' ) from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='el'  and approved_flag_PRINCIPLE = 0) as EL_dates,(select distinct STUFF((SELECT ',OD(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='OUTD'  and approved_flag_PRINCIPLE = 0 FOR XML PATH('')), 1, 1, '' )  from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='OUTD'  and approved_flag_PRINCIPLE = 0) as OUTD_dates,(select distinct STUFF((SELECT ',CO(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='co'  and approved_flag_PRINCIPLE = 0 FOR XML PATH('')), 1, 1, '' ) from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='co'  and approved_flag_PRINCIPLE = 0) as CO_dates,(select distinct STUFF((SELECT ',LWP(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='lwp'  and approved_flag_PRINCIPLE = 0 FOR XML PATH('')), 1, 1, '' )  from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='lwp'  and approved_flag_PRINCIPLE = 0) as LWP_dates,(select distinct STUFF((SELECT ',MATERNITY(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='MATERNITY'  and approved_flag_PRINCIPLE = 0 FOR XML PATH('')), 1, 1, '' )  from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='MATERNITY'  and approved_flag_PRINCIPLE = 0) as MATERNITY_dates,(d.cl - (SELECT ISNULL(sum(cast((cl) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0  and emp_id = d.emp_id)) as BCL,(d.PML + d.ML - (SELECT ISNULL(sum(cast((ML) as float)), 0)FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0  and emp_id = d.emp_id)) as BML,(d.pel + d.el - (SELECT ISNULL(sum(cast((el) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0   and approved_flag_PRINCIPLE = 0 and emp_id = d.emp_id)) as BEL from employeepersonal e, emp_leave_form l,emp_leave_data d ,m_department dept where l.emp_id=d.emp_id and e.emp_id=d.emp_id and d.year=l.ayid and e.emp_id=l.emp_id and e.del_flag=0 and d.del_flag=0 and ayid='" + HttpContext.Current.Session["acdyear"].ToString() + "'  and e.emp_dept_id in ('" + department_id + "') and((convert(date,leaveF,103) between convert(date,'" + f_date + "',103) and convert(date,'" + t_date + "',103)) or (convert(date,leavet,103) between convert(date,'" + f_date + "',103)  and convert(date,'" + t_date + "',103)))) p  group by emp_id,emp_name,DESIGNATION,LeaveDefine,CL,ML,EL,BCL,BML,BEL,LT_CL,LT_ML,LT_EL,DEPARTMENT,  [DATE OF JOINING],LWP,LT_CO,LT_OUTD,CL_dates,ML_dates,EL_dates,OUTD_dates,CO_dates,LWP_dates,MATERNITY_dates order by emp_id;";

        string qry = "select distinct ROW_NUMBER() Over (Order by emp_id) As [Sr No.],emp_id as [EMPLOYEE ID],emp_name[EMPLOYEE NAME],designation[DESIGNATION],DEPARTMENT,[DATE OF JOINING],CL,ML,EL,BCL,BML,BEL,LT_CL,LT_ML,LT_EL,LWP,LT_CO,LT_OUTD,'CO-' + cast(LT_CO as varchar) + '  ' + 'OD-' + cast(LT_OUTD as varchar)[CO_OUTD],CL_dates,ML_dates,EL_dates,OUTD_dates,CO_dates,LWP_dates,MATERNITY_dates from (select distinct e.emp_id,UPPER(isnull(name,'')+' '+isnull(father,'')+' '+isnull(surname,'')) as Emp_Name,CURRENT_DESIGNATION as Designation,(select Department_name from m_department where Dept_id= e.emp_dept_id) as DEPARTMENT,replace(convert(NVARCHAR, e.DOJ, 106), ' ', '-') AS [DATE OF JOINING],(cast(d.CL as float)+cast(d.ML as float)+cast(d.EL as float) ) as LeaveDefine,cast(leaveDays as int) as leavedays,d.CL, d.ML, d.EL,(SELECT ISNULL(sum(cast((cl) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0  and emp_id = l.emp_id) as LT_CL,(SELECT ISNULL(sum(cast((ML) as float)), 0)FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0  and emp_id = l.emp_id) as LT_ML,(SELECT ISNULL(sum(cast((el) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0 and emp_id = l.emp_id) as LT_EL,(SELECT ISNULL(sum(cast((LWP) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0 and emp_id = l.emp_id) as LWP,(SELECT ISNULL(sum(cast((CO) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0 and emp_id = l.emp_id) as LT_CO ,(SELECT ISNULL(sum(cast((OUTD) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0 and emp_id = l.emp_id) as LT_OUTD,(select distinct STUFF((SELECT ',CL(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='cl'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + "  FOR XML PATH('')), 1, 1, '' ) from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='cl'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + ") as CL_dates,(select distinct STUFF((SELECT ',ML(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='ml'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + " FOR XML PATH('')), 1, 1, '' ) from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='ml'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + ") as ML_dates,(select distinct STUFF((SELECT ',EL(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='el'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + " FOR XML PATH('')), 1, 1, '' ) from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='el'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + ") as EL_dates,(select distinct STUFF((SELECT ',OD(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='OUTD'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + "  FOR XML PATH('')), 1, 1, '' )  from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='OUTD'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + ") as OUTD_dates,(select distinct STUFF((SELECT ',CO(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='co'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + " FOR XML PATH('')), 1, 1, '' ) from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='co'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + ") as CO_dates,(select distinct STUFF((SELECT ',LWP(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='lwp'  and approved_flag_PRINCIPLE = 0 and month(leaveF)=" + ddl_month.SelectedValue + " FOR XML PATH('')), 1, 1, '' )  from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='lwp'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + ") as LWP_dates,(select distinct STUFF((SELECT ',MATERNITY(' + replace(convert(NVARCHAR, leaveF, 106), ' ', '-') + ')' FROM Emp_Leave_Form where leaveF  <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='MATERNITY'  and approved_flag_PRINCIPLE = 0 and month(leaveF)=" + ddl_month.SelectedValue + " FOR XML PATH('')), 1, 1, '' )  from Emp_Leave_Form where leaveF <> '' and del_flag=0  and emp_id=l.emp_id and leaveType='MATERNITY'  and approved_flag_PRINCIPLE = 0  and month(leaveF)=" + ddl_month.SelectedValue + ") as MATERNITY_dates,(d.cl - (SELECT ISNULL(sum(cast((cl) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0  and emp_id = d.emp_id)) as BCL,(d.PML + d.ML - (SELECT ISNULL(sum(cast((ML) as float)), 0)FROM Emp_Leave_Form WHERE del_flag = 0 and approved_flag_PRINCIPLE = 0  and emp_id = d.emp_id)) as BML,(d.pel + d.el - (SELECT ISNULL(sum(cast((el) as float)), 0) FROM Emp_Leave_Form WHERE del_flag = 0   and approved_flag_PRINCIPLE = 0 and emp_id = d.emp_id)) as BEL from employeepersonal e, emp_leave_form l,emp_leave_data d ,m_department dept where l.emp_id=d.emp_id and e.emp_id=d.emp_id and d.year=l.ayid and e.emp_id=l.emp_id and e.del_flag=0 and d.del_flag=0 and ayid='" + HttpContext.Current.Session["Year"].ToString() + "'  and e.emp_dept_id in ('" + department_id + "')) p group by emp_id,emp_name,DESIGNATION,LeaveDefine,CL,ML,EL,BCL,BML,BEL,LT_CL,LT_ML,LT_EL,DEPARTMENT,  [DATE OF JOINING],LWP,LT_CO,LT_OUTD,CL_dates,ML_dates,EL_dates,OUTD_dates,CO_dates,LWP_dates,MATERNITY_dates order by emp_id;";

        dsretrive = cls.fillDataTable(qry);

        DataSet ds = new DataSet();
        ds = cls.fillDataset(qry);

        if (ds.Tables[0].Rows.Count > 0)
        {
            grd_load.Visible = true;

            btn_excel.Visible = true;

            grd_load.DataSource = dsretrive;
            grd_load.DataBind();
        }
        else
        {
            btn_excel.Visible = false;
            grd_load.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('No Data Found!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);

        }

    }

    protected void btn_report_Click(object sender, EventArgs e)
    {
        string lstboxcheckornot = "";

        for (int i = 0; i < ddl_department.Items.Count; i++)
        {
            if (ddl_department.Items[i].Selected == true)
            {
                lstboxcheckornot = "true";


            }

        }
        if (lstboxcheckornot == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Department', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
            grd_load.Visible = false;
            return;
        }
        //else if (fdate.Text.Trim() == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select from date', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        //    grd_load.Visible = false;
        //}
        //else if (tdate.Text.Trim() == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select till date', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        //    grd_load.Visible = false;
        //}
        else if (ddl_month.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Month', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
            grd_load.Visible = false;
        }

        else
        {
            gridload();
        }

    }

    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    // excel working shrink cells
    private void ExportGridToExcel()
    {


    }

    protected void btn_excel_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }

    protected void grd_load_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        TableHeaderCell cell = new TableHeaderCell();

        cell = new TableHeaderCell();
        cell.Text = "";
        cell.ColumnSpan = 14;
        row.Controls.Add(cell);


        cell = new TableHeaderCell();
        cell.Text = "OPENING BALANCE";
        cell.ColumnSpan = 3;
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 3;
        cell.Text = "LEAVE TAKEN";
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 3;
        cell.Text = "BALANCE LEAVE";
        row.Controls.Add(cell);



        grd_load.HeaderRow.Parent.Controls.AddAt(0, row);
    }
}