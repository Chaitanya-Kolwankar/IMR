using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Employee_leaveApproved : System.Web.UI.Page
{
    Class1 cls = new Class1();


    string hod_reason, principal_reason, emp_id_staff = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btn_Excel);
            if (!IsPostBack)
            {
                //gridload();
                btn_Excel.Visible = false;
            }
        }
        catch (Exception w)
        {
            Response.Redirect("Login.aspx");
        }
    }

    public void gridload()
    {
        string emp_id = Session["emp_id"].ToString();
        string dept_qry = "select * from EmployeePersonal where emp_id = '" + emp_id + "'";

        string roleid_qry = "select * from web_tp_login where emp_id='" + emp_id + "'";

        DataTable dss = new DataTable();
        dss = cls.fillDataTable(roleid_qry);
        string roleid = dss.Rows[0]["role_id"].ToString();

        DataTable dsretrive = new DataTable();
        dsretrive = cls.fillDataTable(dept_qry);
        string dept_id = dsretrive.Rows[0]["emp_dept_id"].ToString();
        string qry = "";
        if (roleid == "29")
        {
            qry = "SELECT LF.srno,(replace(convert(NVARCHAR,LF.curr_dt, 106), ' ', '-') ) AS [Application Date],EP.emp_id,UPPER(name + ' ' + Father + ' ' + Surname ) as name,locumName,current_department_name,current_designation,HOD_ID,PRINCIPAL_ID,case when leavef is null then'' else 'FROM : ' + ('('+replace(convert(NVARCHAR, leavef, 106), ' ', '-') +')') + ' TO : ' + ('(' + replace(convert(NVARCHAR, leavet, 106), ' ', '-')+ ')')  end as leave,details,resleave,case when lf.paid_unpaid = 0 then 'PAID'  when lf.paid_unpaid = 1 then 'UNPAID' when lf.paid_unpaid=2 then 'HALFPAID' end as paid_unpaid,LF.approved_reason_HOD,case when LF.approved_flag_hod = 0 then 'Sanctioned' when LF.approved_flag_hod = 1 then 'Not Sanctioned' else 'Not Sanctioned' end as hod_status, LF.approved_flag_HOD,LF.approved_reason_HOD ,case when LF.approved_flag_PRINCIPLE = 0 then'Sanctioned' when LF.approved_flag_PRINCIPLE = 1 then 'Not Sanctioned' else 'Not Sanctioned' end as principle_status, LF.approved_flag_PRINCIPLE,LF.approved_reason_PRINCIPLE ,case when leaveType = 'UNPAID' then 'UNPAID' else case when CL = 0 then '' else 'CL-' + cast(CL as varchar)  end + case when ML = 0 then '' else 'ML-' +  cast(ML as varchar)  end + case when EL = 0 then '' else 'EL-' +  cast(EL as varchar)  end + case when CO = 0 then '' else 'CO-' +  cast(CO as varchar)  end  + case when LWP = 0  OR LWP IS NULL then '' else 'LWP-' + cast(LWP as varchar)  end + case when MATERNITY = 0  OR MATERNITY IS NULL then '' else 'MATERNITY-' + cast(MATERNITY as varchar)  end + case when vacation = 0 then '' else 'VACATION-' + leaveDays end + case when OUTD = '' OR OUTD IS NULL then '' else 'OD-' +  cast(OUTD as varchar)  end + case when  halfday = 0 then ''  else 'halfday-' + cast(halfday as varchar)  end  end as leavetype FROM Emp_Leave_Form AS LF LEFT JOIN EmployeePersonal AS EP ON LF.emp_id = EP.emp_id  left join m_department  as dept on ep.emp_dept_id=dept.Dept_id WHERE LF.del_flag = 0 and AYID='" + HttpContext.Current.Session["Year"].ToString() + "'  and PRINCIPAL_ID like'%" + emp_id + "%' and (month(lf.leaveF)= " + ddl_month.SelectedValue + " or month(lf.leaveT)= " + ddl_month.SelectedValue + ") order by srno desc";
        }
        else
        {

            qry = "SELECT LF.srno,(replace(convert(NVARCHAR,LF.curr_dt, 106), ' ', '-') ) AS [Application Date],EP.emp_id,UPPER(name + ' ' + Father + ' ' + Surname ) as name,locumName,current_department_name,current_designation,HOD_ID,case when leavef is null then'' else 'FROM : ' + ('('+replace(convert(NVARCHAR, leavef, 106), ' ', '-') +')') + ' TO : ' + ('(' + replace(convert(NVARCHAR, leavet, 106), ' ', '-')+ ')') end as leave,details,resleave,case when lf.paid_unpaid = 0 then 'PAID'  when lf.paid_unpaid = 1 then 'UNPAID' when lf.paid_unpaid=2 then 'HALFPAID' end as paid_unpaid,LF.approved_reason_HOD,case when LF.approved_flag_hod = 0 then 'Sanctioned' when LF.approved_flag_hod = 1 then 'Not Sanctioned' else 'Not Sanctioned' end as hod_status, LF.approved_flag_HOD,LF.approved_reason_HOD ,case when LF.approved_flag_PRINCIPLE = 0 then'Sanctioned' when LF.approved_flag_PRINCIPLE = 1 then 'Not Sanctioned' else 'Not Sanctioned' end as principle_status, LF.approved_flag_PRINCIPLE,LF.approved_reason_PRINCIPLE ,case when leaveType = 'UNPAID' then 'UNPAID' else case when CL = 0 then '' else 'CL-' + cast(CL as varchar)  end + case when ML = 0 then '' else 'ML-' +  cast(ML as varchar)  end + case when EL = 0 then '' else 'EL-' +  cast(EL as varchar)  end + case when CO = 0 then '' else 'CO-' +  cast(CO as varchar)  end  + case when LWP = 0  OR LWP IS NULL then '' else 'LWP-' + cast(LWP as varchar)  end + case when MATERNITY = 0  OR MATERNITY IS NULL then '' else 'MATERNITY-' + cast(MATERNITY as varchar)  end + case when vacation = 0 then '' else 'VACATION-' + leaveDays end + case when OUTD = '' OR OUTD IS NULL then '' else 'OD-' +  cast(OUTD as varchar)  end + case when  halfday = 0 then ''  else 'halfday-' + cast(halfday as varchar)  end  end as leavetype FROM Emp_Leave_Form AS LF LEFT JOIN EmployeePersonal AS EP ON LF.emp_id = EP.emp_id  left join m_department  as dept on ep.emp_dept_id=dept.Dept_id WHERE LF.del_flag = 0 and AYID='" + HttpContext.Current.Session["Year"].ToString() + "'   and HOD_ID like '%" + emp_id + "%' and (month(lf.leaveF)= " + ddl_month.SelectedValue + " or month(lf.leaveT)= " + ddl_month.SelectedValue + ") order by srno desc";
        }

        //and Dept_id='" + dept_id + "'----remove samiya

        dsretrive = cls.fillDataTable(qry);

        DataSet ds = new DataSet();
        ds = cls.fillDataset(qry);
        ds.Tables[0].Columns.Add("Bal");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            string empid = ds.Tables[0].Rows[i]["emp_id"].ToString();
            string sum = "";
            string a = "";
            string strm = "SELECT (cl- (SELECT ISNULL(sum(cast((cl) as float)), 0 ) FROM   Emp_Leave_Form WHERE del_flag=0 and  approved_flag_PRINCIPLE = 0 and emp_id = '" + empid + "' and AYID='" + HttpContext.Current.Session["Year"].ToString() + "')) as BCL,((SELECT ISNULL(sum(cast((CO) as float)), 0 ) FROM   Emp_Leave_Form WHERE del_flag=0 and  approved_flag_PRINCIPLE = 0  and emp_id = '" + empid + "'  and AYID='" + HttpContext.Current.Session["Year"].ToString() + "')) as BCO,(PML+ML- (SELECT ISNULL(sum(cast((ML) as float)), 0 )FROM   Emp_Leave_Form WHERE del_flag=0 and  approved_flag_PRINCIPLE = 0  and  emp_id = '" + empid + "'  and AYID='" + HttpContext.Current.Session["Year"].ToString() + "')) as BML,((SELECT ISNULL(sum(cast((outd) as float)), 0 ) FROM   Emp_Leave_Form WHERE del_flag=0 and approved_flag_PRINCIPLE = 0 and emp_id = '" + empid + "'  and AYID='" + HttpContext.Current.Session["Year"].ToString() + "')) as BOUTD,(pel+el- (SELECT ISNULL(sum(cast((el) as float)), 0 ) FROM   Emp_Leave_Form WHERE del_flag=0   and  approved_flag_PRINCIPLE = 0 and emp_id = '" + empid + "'  and AYID='" + HttpContext.Current.Session["Year"].ToString() + "')) as BEL FROM   emp_leave_data WHERE del_flag=0 and emp_id = '" + empid + "' and year='" + HttpContext.Current.Session["Year"].ToString() + "'";

            DataSet ds2 = cls.fillDataset(strm);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Rows[i]["Bal"] = "CL(" + ds2.Tables[0].Rows[0]["BCL"].ToString() + ")," + " ML(" + ds2.Tables[0].Rows[0]["BML"].ToString() + ")," + "EL(" + ds2.Tables[0].Rows[0]["BEL"].ToString() + ")";

                //+" CO(" + ds2.Tables[0].Rows[0]["BCO"].ToString() + "),"
                //+" OD(" + ds2.Tables[0].Rows[0]["BOUTD"].ToString() + "), "
            }
            else
            {
                ds.Tables[0].Rows[i]["Bal"] = "";
            }
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView.Visible = true;
            GridView.DataSource = ds;
            GridView.DataBind();
            btn_Excel.Visible = true;
        }
        else
        {
            GridView.Visible = false;
            btn_Excel.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('No Data Found!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }

        if (roleid == "29")
        {
            for (int z = 0; z < GridView.Rows.Count; z++)
            {
                DropDownList hodstatus = (DropDownList)GridView.Rows[z].FindControl("ddl_hodstatus");
                hodstatus.Enabled = false;
                hodstatus.CssClass = "btn btn-success btn-block customCursor";

                if (ddl_principalstatus.SelectedItem.Text != "Sanctioned")
                {
                    LinkButton btn_print = (LinkButton)GridView.Rows[z].FindControl("lnkbtn_print");
                    btn_print.Enabled = false;
                    btn_print.CssClass = "btn btn-success btn-block customCursor";
                }
            }

        }
        else
        {
            for (int z = 0; z < GridView.Rows.Count; z++)
            {
                LinkButton btn_view = (LinkButton)GridView.Rows[z].FindControl("lnkbtn_view");
                LinkButton btn_print = (LinkButton)GridView.Rows[z].FindControl("lnkbtn_print");

                //btn_view.Enabled = false;
                btn_print.Enabled = false;
                btn_print.CssClass = "btn btn-success btn-block customCursor";
            }
        }


    }

    public void MyButton_Click(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Control)sender).NamingContainer;
        int rowIndex = row.RowIndex;

        Button button = (Button)GridView.Rows[rowIndex].FindControl("MyButton");
        button.Enabled = false;
    }


    protected void ddl_paid_unpaid_SelectedIndexChanged(object sender, EventArgs e)
    {
        int rowIndex = Convert.ToInt32(((sender as DropDownList).NamingContainer as GridViewRow).RowIndex);

        DropDownList ddl_paid_unpaid = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)ddl_paid_unpaid.NamingContainer;

        for (int i = 0; i < GridView.Rows.Count; i++)
        {

            Label emp_id_txt = (Label)GridView.Rows[i].FindControl("emp_id");
            Label name_txt = (Label)GridView.Rows[i].FindControl("name");
            Label sr_no_txt = (Label)GridView.Rows[i].FindControl("sr_no");

            if (rowIndex == i)
            {
                if (ddl_paid_unpaid.SelectedValue == "0")
                {

                    string update_Leave = "update Emp_Leave_Form set  paid_unpaid='" + ddl_paid_unpaid.SelectedValue.ToString() + "' where emp_id='" + emp_id_txt.Text + "' and srno='" + sr_no_txt.Text + "'";
                    bool result = cls.DMLqueries(update_Leave);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + name_txt.Text + " `S LEAVE IS " + ddl_paid_unpaid.SelectedItem.ToString() + " !! ', { color: '#fff', background: '#35B898', blur: 0.2, delay: 0 });", true);
                    ddl_paid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");
                    gridload();
                }
                else if (ddl_paid_unpaid.SelectedValue == "1")
                {
                    string update_Leave = "update Emp_Leave_Form set  paid_unpaid='" + ddl_paid_unpaid.SelectedValue.ToString() + "' where emp_id='" + emp_id_txt.Text + "' and srno='" + sr_no_txt.Text + "'";
                    ddl_paid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#D44950");
                    bool result = cls.DMLqueries(update_Leave);

                    if (result == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + name_txt.Text + " `S LEAVE IS " + ddl_paid_unpaid.SelectedItem.ToString() + " !! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);

                        gridload();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    }
                }
                else if (ddl_paid_unpaid.SelectedValue == "2")
                {
                    string update_Leave = "update Emp_Leave_Form set  paid_unpaid='" + ddl_paid_unpaid.SelectedValue.ToString() + "' where emp_id='" + emp_id_txt.Text + "' and srno='" + sr_no_txt.Text + "'";
                    ddl_paid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#D44950");
                    bool result = cls.DMLqueries(update_Leave);

                    if (result == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + name_txt.Text + " `S LEAVE IS " + ddl_paid_unpaid.SelectedItem.ToString() + " !! ', { color: '#fff', background: '#dc9135', blur: 0.2, delay: 0 });", true);

                        gridload();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    }
                }
            }
        }
    }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        Label lbl_empid = (Label)e.Row.FindControl("emp_id");
        Label lbl_srno = (Label)e.Row.FindControl("sr_no");
        LinkButton btnview = (LinkButton)e.Row.FindControl("lnkbtn_view");
        Label lbl_principle = (Label)e.Row.FindControl("lbl_A_principle");
        Label lbl_hod = (Label)e.Row.FindControl("lbl_A_hod");
        LinkButton btn_print = (LinkButton)e.Row.FindControl("lnkbtn_print");

        string emp_id = Session["emp_id"].ToString();

        string roleid_qry = "select * from web_tp_login where emp_id='" + emp_id + "'";

        DataTable ds = new DataTable();
        ds = cls.fillDataTable(roleid_qry);
        string roleid = ds.Rows[0]["role_id"].ToString();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //  UNPAID PAID - - - - - - -  - -
            Label paid_unpaid_flag = e.Row.FindControl("paid_unpaid_flag") as Label;
            DropDownList ddlpaid_unpaid = e.Row.FindControl("ddl_paid_unpaid") as DropDownList;
            if (roleid == "29")
            {

                if (paid_unpaid_flag.Text != "NULL")
                {
                    if (paid_unpaid_flag.Text == "PAID")
                    {
                        ddlpaid_unpaid.SelectedIndex = ddlpaid_unpaid.Items.IndexOf(ddlpaid_unpaid.Items.FindByText("PAID"));
                        ddlpaid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");//GREEN
                    }
                    else if (paid_unpaid_flag.Text == "UNPAID")
                    {
                        ddlpaid_unpaid.SelectedIndex = ddlpaid_unpaid.Items.IndexOf(ddlpaid_unpaid.Items.FindByText("UNPAID"));
                        ddlpaid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#D44950");//RED
                    }
                    else if (paid_unpaid_flag.Text == "HALFPAID")
                    {
                        ddlpaid_unpaid.SelectedIndex = ddlpaid_unpaid.Items.IndexOf(ddlpaid_unpaid.Items.FindByText("HALFPAID"));
                        ddlpaid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc9135");//Yellow
                        //ddlpaid_unpaid.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4B5F71");//black
                    }
                    else if (paid_unpaid_flag.Text == "")
                    {

                        ddlpaid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#4B5F71");//black
                    }

                }
            }
            else
            {
                e.Row.Cells[14].Enabled = false;

                if (paid_unpaid_flag.Text != "NULL")
                {
                    if (paid_unpaid_flag.Text == "PAID")
                    {
                        ddlpaid_unpaid.SelectedIndex = ddlpaid_unpaid.Items.IndexOf(ddlpaid_unpaid.Items.FindByText("PAID"));
                        ddlpaid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");//GREEN
                    }
                    else if (paid_unpaid_flag.Text == "UNPAID")
                    {
                        ddlpaid_unpaid.SelectedIndex = ddlpaid_unpaid.Items.IndexOf(ddlpaid_unpaid.Items.FindByText("UNPAID"));
                        ddlpaid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#D44950");//RED
                    }
                    else if (paid_unpaid_flag.Text == "HALFPAID")
                    {
                        ddlpaid_unpaid.SelectedIndex = ddlpaid_unpaid.Items.IndexOf(ddlpaid_unpaid.Items.FindByText("HALFPAID"));
                        ddlpaid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc9135");//Yellow
                                                                                                      // ddlpaid_unpaid.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4B5F71");//black
                    }
                    else if (paid_unpaid_flag.Text == "")
                    {

                        ddlpaid_unpaid.BackColor = System.Drawing.ColorTranslator.FromHtml("#4B5F71");//black
                    }
                }

            }
            //UNPAID PAID  - - - - - - -  - -


            //HOD - - - - - - -  - -
            Label approve_flag_HOD = e.Row.FindControl("ddlhodflag") as Label;
            DropDownList drp_dwn_HOD = e.Row.FindControl("ddl_hodstatus") as DropDownList;

            if (roleid == "30")
            {
                Label approve_reson_HOD = e.Row.FindControl("lbl_approved_reason_hod") as Label;


                if (approve_flag_HOD.Text != "NULL")
                {
                    if (approve_flag_HOD.Text == "False")
                    {
                        //drp_dwn.SelectedIndex = drp_dwn.Items.IndexOf(drp_dwn.Items.FindByText("Sanctioned"));
                        drp_dwn_HOD.SelectedValue = drp_dwn_HOD.Items.FindByValue("0").Value;
                        drp_dwn_HOD.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");//GREEN                   
                    }
                    else if (approve_flag_HOD.Text == "True")
                    {
                        drp_dwn_HOD.SelectedValue = drp_dwn_HOD.Items.FindByValue("1").Value;
                        drp_dwn_HOD.BackColor = System.Drawing.ColorTranslator.FromHtml("#D44950");//RED
                    }
                    else if (approve_flag_HOD.Text == "")
                    {
                        approve_flag_HOD.BackColor = System.Drawing.ColorTranslator.FromHtml("#4B5F71");//black
                    }
                }
            }
            else
            {
                //e.Row.Cells[15].Enabled = false;
                if (approve_flag_HOD.Text == "False")
                {
                    //drp_dwn.SelectedIndex = drp_dwn.Items.IndexOf(drp_dwn.Items.FindByText("Sanctioned"));
                    drp_dwn_HOD.SelectedValue = drp_dwn_HOD.Items.FindByValue("0").Value;
                    drp_dwn_HOD.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");//GREEN                   
                }
                else if (approve_flag_HOD.Text == "True")
                {
                    drp_dwn_HOD.SelectedValue = drp_dwn_HOD.Items.FindByValue("1").Value;
                    drp_dwn_HOD.BackColor = System.Drawing.ColorTranslator.FromHtml("#D44950");//RED
                }
                else if (approve_flag_HOD.Text == "")
                {
                    drp_dwn_HOD.BackColor = System.Drawing.ColorTranslator.FromHtml("#4B5F71");//black
                }


            }
            //HOD - - - - - - -  - -


            //PRINCIPAL - - - - - - -  - -
            Label approve_flag_PRINCIPAL = e.Row.FindControl("ddlprincipalflag") as Label;
            DropDownList drp_dwn_PRINCIPAL = e.Row.FindControl("ddl_principalstatus") as DropDownList;

            if (roleid == "29")
            {
                Label approve_reson_PRINCIPAL = e.Row.FindControl("lbl_approved_reason_principal") as Label;


                if (approve_flag_PRINCIPAL.Text != "NULL")
                {
                    if (approve_flag_PRINCIPAL.Text == "False")
                    {
                        //drp_dwn.SelectedIndex = drp_dwn.Items.IndexOf(drp_dwn.Items.FindByText("Sanctioned"));
                        drp_dwn_PRINCIPAL.SelectedValue = drp_dwn_PRINCIPAL.Items.FindByValue("0").Value;
                        drp_dwn_PRINCIPAL.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");//GREEN                   
                    }
                    else if (approve_flag_PRINCIPAL.Text == "True")
                    {
                        drp_dwn_PRINCIPAL.SelectedValue = drp_dwn_PRINCIPAL.Items.FindByValue("1").Value;
                        drp_dwn_PRINCIPAL.BackColor = System.Drawing.ColorTranslator.FromHtml("#D44950");//RED
                    }
                    else if (approve_flag_PRINCIPAL.Text == "")
                    {
                        drp_dwn_PRINCIPAL.BackColor = System.Drawing.ColorTranslator.FromHtml("#4B5F71");//black
                    }
                }
            }
            else
            {
                e.Row.Cells[16].Enabled = false;

                if (approve_flag_PRINCIPAL.Text == "False")
                {
                    //drp_dwn.SelectedIndex = drp_dwn.Items.IndexOf(drp_dwn.Items.FindByText("Sanctioned"));
                    drp_dwn_PRINCIPAL.SelectedValue = drp_dwn_PRINCIPAL.Items.FindByValue("0").Value;
                    drp_dwn_PRINCIPAL.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");//GREEN                   
                }
                else if (approve_flag_PRINCIPAL.Text == "True")
                {
                    drp_dwn_PRINCIPAL.SelectedValue = drp_dwn_PRINCIPAL.Items.FindByValue("1").Value;
                    drp_dwn_PRINCIPAL.BackColor = System.Drawing.ColorTranslator.FromHtml("#D44950");//RED
                }
                else if (approve_flag_PRINCIPAL.Text == "")
                {
                    drp_dwn_PRINCIPAL.BackColor = System.Drawing.ColorTranslator.FromHtml("#4B5F71");//black
                }
            }
            //PRINCIPAL - - - - - - -  - -
            //FOR FETCHING CERTIFICATE - - - - - - -  - -
            string[] folders = Directory.GetFiles(Server.MapPath("~/Applications/"));
            string filename = lbl_empid.Text + "_" + lbl_srno.Text + ".pdf";
            string files = ("~/Applications/" + filename);

            if (File.Exists(Server.MapPath(files)))
            {

            }
            else
            {

                //btnview.Attributes.Add("disabled", "disabled");
                //btnview.CommandName = "";
                btnview.Enabled = false;
                btnview.CssClass = "btn btn-success btn-block customCursor";

            }
            //FOR FETCHING CERTIFICATE - - - - - - -  - -
            //PRINT - - - - - - -  - -
            if (lbl_principle.Text == "Not Sanctioned")
            {

                btn_print.Attributes.Add("disabled", "disabled");
                btn_print.CommandName = "";

            }
            //PRINT - - - - - - -  - -
        }
    }

    protected void ddl_hodstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        int rowIndex = Convert.ToInt32(((sender as DropDownList).NamingContainer as GridViewRow).RowIndex);

        DropDownList ddl_hodstatus = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)ddl_hodstatus.NamingContainer;

        for (int i = 0; i < GridView.Rows.Count; i++)
        {
            TextBox txt_reason_hod = (TextBox)GridView.Rows[i].FindControl("txtreason_hod");
            Button save_btn_hod = (Button)GridView.Rows[i].FindControl("save_btn_hod");
            Label lbl_reason_hod = (Label)GridView.Rows[i].FindControl("lbl_approved_reason_hod");
            Label emp_id_txt = (Label)GridView.Rows[i].FindControl("emp_id");
            Label name_txt = (Label)GridView.Rows[i].FindControl("name");
            Label sr_no_txt = (Label)GridView.Rows[i].FindControl("sr_no");

            if (rowIndex == i)
            {
                if (ddl_hodstatus.SelectedItem.Text == "Not Sanctioned")
                {
                    txt_reason_hod.Visible = true;
                    save_btn_hod.Visible = true;
                }
                else if (ddl_hodstatus.SelectedIndex == 0)
                {
                    string update_Leave = "update Emp_Leave_Form set approved_flag_hod=null , approved_reason_HOD=NULL where emp_id='" + emp_id_txt.Text + "' and srno='" + sr_no_txt.Text + "'";


                    bool result = cls.DMLqueries(update_Leave);

                    if (result == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + name_txt.Text + " LEAVE IS FOR EDITING!! ', { color: '#fff', background: '#35B898', blur: 0.2, delay: 0 });", true);
                        ddl_hodstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");
                        txt_reason_hod.Visible = false;
                        txt_reason_hod.Text = "";
                        save_btn_hod.Visible = false;
                        lbl_reason_hod.Visible = false;
                        gridload();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    }
                }
                else if (ddl_hodstatus.SelectedItem.Text == "Sanctioned")
                {
                    string update_Leave = "update Emp_Leave_Form set approved_flag_hod='" + ddl_hodstatus.SelectedValue.ToString() + "' , approved_reason_HOD=NULL where emp_id='" + emp_id_txt.Text + "' and srno='" + sr_no_txt.Text + "'";


                    bool result = cls.DMLqueries(update_Leave);

                    if (result == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + name_txt.Text + " LEAVE SUCCESSFULLY SANCTIONED!! ', { color: '#fff', background: '#35B898', blur: 0.2, delay: 0 });", true);
                        ddl_hodstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");
                        txt_reason_hod.Visible = false;
                        txt_reason_hod.Text = "";
                        save_btn_hod.Visible = false;
                        lbl_reason_hod.Visible = false;
                        gridload();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    }
                }
                else if (ddl_hodstatus.SelectedIndex == 0)
                {
                    txt_reason_hod.Visible = false;
                    save_btn_hod.Visible = false;
                }
            }
        }
    }

    protected void save_btn_hod_Click(object sender, EventArgs e)
    {

        int rowIndex = Convert.ToInt32(((sender as Button).NamingContainer as GridViewRow).RowIndex);

        for (int i = 0; i < GridView.Rows.Count; i++)
        {
            if (rowIndex == i)
            {
                Button save_btn_hod = (Button)GridView.Rows[i].FindControl("save_btn_hod");
                TextBox txt_reason_hod = (TextBox)GridView.Rows[i].FindControl("txtreason_hod");
                DropDownList ddl_hod = (DropDownList)GridView.Rows[i].FindControl("ddl_hodstatus");
                Label emp_id_txt = (Label)GridView.Rows[i].FindControl("emp_id");
                Label sr_no_txt = (Label)GridView.Rows[i].FindControl("sr_no");
                Label name_txt = (Label)GridView.Rows[i].FindControl("name");

                string update_Leave = "update Emp_Leave_Form set approved_flag_HOD='" + ddl_hod.SelectedValue.ToString() + "' , approved_reason_HOD='" + txt_reason_hod.Text.Replace("'", "''") + "' where emp_id='" + emp_id_txt.Text + "' and srno='" + sr_no_txt.Text + "'";
                bool result = cls.DMLqueries(update_Leave);
                hod_reason = txt_reason_hod.Text;
                emp_id_staff = emp_id_txt.Text;

                if (result == true)
                {

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + name_txt.Text + " LEAVE IS NOT SANCTIONED!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    ddl_hod.BackColor = System.Drawing.ColorTranslator.FromHtml("#D44950");
                    txt_reason_hod.Visible = false;
                    save_btn_hod.Visible = false;
                    gridload();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                }
            }
        }
    }

    protected void ddl_principalstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        int rowIndex = Convert.ToInt32(((sender as DropDownList).NamingContainer as GridViewRow).RowIndex);

        DropDownList ddl_principalstatus = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)ddl_principalstatus.NamingContainer;

        for (int i = 0; i < GridView.Rows.Count; i++)
        {
            TextBox txt_reason_principal = (TextBox)GridView.Rows[i].FindControl("txtreason_principal");
            Button save_btn_principal = (Button)GridView.Rows[i].FindControl("save_btn_principal");
            Label lbl_reason_principal = (Label)GridView.Rows[i].FindControl("lbl_approved_reason_principal");
            Label emp_id_txt = (Label)GridView.Rows[i].FindControl("emp_id");
            Label name_txt = (Label)GridView.Rows[i].FindControl("name");
            Label sr_no_txt = (Label)GridView.Rows[i].FindControl("sr_no");
            LinkButton lnkbtn_print = (LinkButton)GridView.Rows[i].FindControl("lnkbtn_print");

            if (rowIndex == i)
            {
                if (ddl_principalstatus.SelectedItem.Text == "Not Sanctioned")
                {
                    txt_reason_principal.Visible = true;
                    save_btn_principal.Visible = true;
                    lnkbtn_print.Enabled = false;
                    lnkbtn_print.CssClass = "btn btn-success btn-block customCursor";
                }
                else if (ddl_principalstatus.SelectedIndex == 0)
                {
                    string update_Leave = "update Emp_Leave_Form set approved_flag_PRINCIPLE=null , approved_reason_PRINCIPLE=NULL where emp_id='" + emp_id_txt.Text + "' and srno='" + sr_no_txt.Text + "'";
                    //txt_reason_hod.Enabled = false;

                    bool result = cls.DMLqueries(update_Leave);

                    if (result == true)
                    {
                        ddl_principalstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");
                        txt_reason_principal.Visible = false;
                        txt_reason_principal.Text = "";
                        save_btn_principal.Visible = false;
                        lbl_reason_principal.Visible = false;
                        gridload();
                        lnkbtn_print.Enabled = false;

                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + name_txt.Text + " LEAVE IS FOR EDITING!! ', { color: '#fff', background: '#35B898', blur: 0.2, delay: 0 });", true);
                    }

                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    }
                    lnkbtn_print.Enabled = false;
                    lnkbtn_print.CssClass = "btn btn-success btn-block customCursor";
                }
                else if (ddl_principalstatus.SelectedItem.Text == "Sanctioned")
                {
                    string update_Leave = "update Emp_Leave_Form set approved_flag_PRINCIPLE='" + ddl_principalstatus.SelectedValue.ToString() + "' , approved_reason_PRINCIPLE=NULL where emp_id='" + emp_id_txt.Text + "' and srno='" + sr_no_txt.Text + "'";
                    //txt_reason_hod.Enabled = false;

                    bool result = cls.DMLqueries(update_Leave);

                    if (result == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + name_txt.Text + " LEAVE SUCCESSFULLY SANCTIONED!! ', { color: '#fff', background: '#35B898', blur: 0.2, delay: 0 });", true);
                        ddl_principalstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#35B898");
                        txt_reason_principal.Visible = false;
                        txt_reason_principal.Text = "";
                        save_btn_principal.Visible = false;
                        lbl_reason_principal.Visible = false;
                        gridload();


                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    }
                }
                else if (ddl_principalstatus.SelectedIndex == 0)
                {
                    txt_reason_principal.Visible = false;
                    save_btn_principal.Visible = false;
                    lnkbtn_print.Enabled = false;
                }
            }
        }
    }

    protected void save_btn_principal_Click(object sender, EventArgs e)
    {
        int rowIndex = Convert.ToInt32(((sender as Button).NamingContainer as GridViewRow).RowIndex);

        for (int i = 0; i < GridView.Rows.Count; i++)
        {
            if (rowIndex == i)
            {
                Button save_btn_principal = (Button)GridView.Rows[i].FindControl("save_btn_principal");
                TextBox txt_reason_principal = (TextBox)GridView.Rows[i].FindControl("txtreason_principal");
                DropDownList ddl_principal = (DropDownList)GridView.Rows[i].FindControl("ddl_principalstatus");
                Label emp_id_txt = (Label)GridView.Rows[i].FindControl("emp_id");
                Label sr_no_txt = (Label)GridView.Rows[i].FindControl("sr_no");
                Label name_txt = (Label)GridView.Rows[i].FindControl("name");

                string update_Leave = "update Emp_Leave_Form set approved_flag_PRINCIPLE='" + ddl_principal.SelectedValue.ToString() + "' , approved_reason_PRINCIPLE='" + txt_reason_principal.Text.Replace("'", "''") + "' where emp_id='" + emp_id_txt.Text + "' and srno='" + sr_no_txt.Text + "'";
                bool result = cls.DMLqueries(update_Leave);
                hod_reason = txt_reason_principal.Text;
                emp_id_staff = emp_id_txt.Text;

                if (result == true)
                {

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + name_txt.Text + " LEAVE IS NOT SANCTIONED!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                    ddl_principal.BackColor = System.Drawing.ColorTranslator.FromHtml("#D44950");
                    txt_reason_principal.Visible = false;
                    save_btn_principal.Visible = false;
                    gridload();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
                }
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void btn_Excel_Click(object sender, EventArgs e)
    {
        string emp_id = Session["emp_id"].ToString();

        string dept_qry = "select* from EmployeePersonal where emp_id = '" + emp_id + "'";
        DataTable dsretrive = new DataTable();
        dsretrive = cls.fillDataTable(dept_qry);
        string dept_id = dsretrive.Rows[0]["emp_dept_id"].ToString();


        string roleid_qry = "select * from web_tp_login where emp_id='" + emp_id + "'";
        DataTable dss = new DataTable();
        dss = cls.fillDataTable(roleid_qry);
        string roleid = dss.Rows[0]["role_id"].ToString();


        string str = "";
        if (roleid == "29")
        {

            str = "SELECT LF.srno AS [LEAVE APPLICATION ID],(replace(convert(NVARCHAR,LF.curr_dt, 106), ' ', '-') ) AS [APPLICATION DATE],EP.emp_id as [EMPLOYEE ID],UPPER(name + ' ' + Father + ' ' + Surname ) as NAME,locumName AS [ALTERNATIVE ARRANGEMENT],current_department_name as DEPARTMENT,current_designation AS DESIGNATION,case when leavef is null then''  else 'FROM : ' + ('('+replace(convert(NVARCHAR, leavef, 106), ' ', '-') +')') + ' TO : ' + ('(' + replace(convert(NVARCHAR, leavet, 106), ' ', '-')+ ')') end as [LEAVE DATES],details,resleave AS REASON,case when lf.paid_unpaid = 0 then 'PAID'  when lf.paid_unpaid = 1 then 'UNPAID'  end as [PAID/UNPAID],case when LF.approved_flag_hod = 0 then 'Sanctioned' when LF.approved_flag_hod = 1 then 'Not Sanctioned' else 'Not Sanctioned' end as [HOD APPROVAL STATUS], LF.approved_reason_HOD AS [HOD APPROVAL REASON] ,case when LF.approved_flag_PRINCIPLE = 0 then'Sanctioned' when LF.approved_flag_PRINCIPLE = 1 then 'Not Sanctioned' else 'Not Sanctioned' end as [PRINCIPAL APPROVAL STATUS],LF.approved_reason_PRINCIPLE AS [PRINCIPLE APPROVAL REASON] ,case when leaveType = 'UNPAID' then 'UNPAID' else case when CL = 0 then '' else 'CL-' + cast(CL as varchar)  end + case when ML = 0 then '' else 'ML-' +  cast(ML as varchar)  end + case when EL = 0 then '' else 'EL-' +  cast(EL as varchar)  end + case when CO = 0 then '' else 'CO-' +  cast(CO as varchar)  end   + case when LWP = 0  OR LWP IS NULL then '' else 'LWP-' + cast(LWP as varchar)  end + case when MATERNITY = 0  OR MATERNITY IS NULL then '' else 'MATERNITY-' + cast(MATERNITY as varchar)  end + case when vacation = 0 then '' else 'VACATION-' + leaveDays end + case when OUTD = '' OR OUTD IS NULL then '' else 'OD-' +  cast(OUTD as varchar)  end + case when  halfday = 0 then ''  else 'HALFDAY-' + cast(halfday as varchar)  end end as [LEAVE TYPE] FROM Emp_Leave_Form AS LF LEFT JOIN EmployeePersonal AS EP ON LF.emp_id = EP.emp_id left join m_department  as dept on ep.emp_dept_id=dept.Dept_id WHERE LF.del_flag = 0   and AYID='" + HttpContext.Current.Session["Year"].ToString() + "'  and PRINCIPAL_ID like'%" + emp_id + "%' and (month(lf.leaveF)= " + ddl_month.SelectedValue + " or month(lf.leaveT)= " + ddl_month.SelectedValue + ") order by srno desc";
        }
        else
        {
            str = "SELECT LF.srno AS [LEAVE APPLICATION ID],(replace(convert(NVARCHAR,LF.curr_dt, 106), ' ', '-') ) AS [APPLICATION DATE],EP.emp_id as [EMPLOYEE ID],UPPER(name + ' ' + Father + ' ' + Surname ) as NAME,locumName AS [ALTERNATIVE ARRANGEMENT],current_department_name as DEPARTMENT,current_designation AS DESIGNATION,case when leavef is null then'' else 'FROM : ' + ('('+replace(convert(NVARCHAR, leavef, 106), ' ', '-') +')') + ' TO : ' + ('(' + replace(convert(NVARCHAR, leavet, 106), ' ', '-')+ ')') end as [LEAVE DATES],details AS [WORK ADJUSTMENT DETAILS],resleave AS REASON,case when lf.paid_unpaid = 0 then 'PAID'  when lf.paid_unpaid = 1 then 'UNPAID'  end as [PAID/UNPAID],case when LF.approved_flag_hod = 0 then 'Sanctioned' when LF.approved_flag_hod = 1 then 'Not Sanctioned' else 'Not Sanctioned' end as [HOD APPROVAL STATUS], LF.approved_reason_HOD AS [HOD APPROVAL REASON] ,case when LF.approved_flag_PRINCIPLE = 0 then'Sanctioned' when LF.approved_flag_PRINCIPLE = 1 then 'Not Sanctioned' else 'Not Sanctioned' end as [PRINCIPAL APPROVAL STATUS],LF.approved_reason_PRINCIPLE AS [PRINCIPLE APPROVAL REASON] ,case when leaveType = 'UNPAID' then 'UNPAID' else case when CL = 0 then '' else 'CL-' + cast(CL as varchar)  end + case when ML = 0 then '' else 'ML-' +  cast(ML as varchar)  end + case when EL = 0 then '' else 'EL-' +  cast(EL as varchar)  end + case when CO = 0 then '' else 'CO-' +  cast(CO as varchar)  end + case when LWP = 0  OR LWP IS NULL then '' else 'LWP-' + cast(LWP as varchar)  end + case when MATERNITY = 0  OR MATERNITY IS NULL then '' else 'MATERNITY-' + cast(MATERNITY as varchar)  end + case when vacation = 0 then '' else 'VACATION-' + leaveDays end + case when OUTD = '' OR OUTD IS NULL then '' else 'OD-' +  cast(OUTD as varchar)  end + case when  halfday = 0 then ''  else 'HALFDAY-' + cast(halfday as varchar)  end end as [LEAVE TYPE] FROM Emp_Leave_Form AS LF LEFT JOIN EmployeePersonal AS EP ON LF.emp_id = EP.emp_id left join m_department  as dept on ep.emp_dept_id=dept.Dept_id WHERE LF.del_flag = 0  and AYID='" + HttpContext.Current.Session["Year"].ToString() + "' and HOD_ID like '%" + emp_id + "%' and (month(lf.leaveF)= " + ddl_month.SelectedValue + " or month(lf.leaveT)= " + ddl_month.SelectedValue + ") order by srno desc";
        }

        // and Dept_id='"+dept_id+"'

        DataSet ds = cls.fillDataset(str);
        ds = cls.fillDataset(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Columns.Add("BALANCE LEAVE");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string empid = ds.Tables[0].Rows[i]["EMPLOYEE ID"].ToString();
                string sum = "";
                string a = "";
                string strm = "SELECT (cl- (SELECT ISNULL(sum(cast((cl) as float)), 0 ) FROM   Emp_Leave_Form WHERE del_flag=0 and (approved_flag_HOD = 0 and approved_flag_PRINCIPLE = 0)  and emp_id = '" + empid + "'  and AYID='" + HttpContext.Current.Session["Year"].ToString() + "')) as BCL,((SELECT ISNULL(sum(cast((CO) as float)), 0 ) FROM   Emp_Leave_Form WHERE del_flag=0 and (approved_flag_HOD = 0 and approved_flag_PRINCIPLE = 0)  and emp_id = '" + empid + "' and AYID='" + HttpContext.Current.Session["Year"].ToString() + "')) as BCO,(PML+ML- (SELECT ISNULL(sum(cast((ML) as float)), 0 )FROM   Emp_Leave_Form WHERE del_flag=0 and (approved_flag_HOD = 0 and approved_flag_PRINCIPLE = 0)  and  emp_id = '" + empid + "' and AYID='" + HttpContext.Current.Session["Year"].ToString() + "')) as BML,((SELECT ISNULL(sum(cast((outd) as float)), 0 ) FROM   Emp_Leave_Form WHERE del_flag=0 and (approved_flag_HOD = 0 and approved_flag_PRINCIPLE = 0) and emp_id = '" + empid + "' and AYID='" + HttpContext.Current.Session["Year"].ToString() + "')) as BOUTD,(pel+el- (SELECT ISNULL(sum(cast((el) as float)), 0 ) FROM   Emp_Leave_Form WHERE del_flag=0   and (approved_flag_HOD = 0 and approved_flag_PRINCIPLE = 0) and emp_id = '" + empid + "' and AYID='" + HttpContext.Current.Session["Year"].ToString() + "')) as BEL FROM   emp_leave_data WHERE del_flag=0 and emp_id = '" + empid + "' and year='" + HttpContext.Current.Session["Year"].ToString() + "'";

                DataSet ds2 = cls.fillDataset(strm);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Rows[i]["BALANCE LEAVE"] = "CL(" + ds2.Tables[0].Rows[0]["BCL"].ToString() + ")," + " ML(" + ds2.Tables[0].Rows[0]["BML"].ToString() + ")," + "EL(" + ds2.Tables[0].Rows[0]["BEL"].ToString() + ")";
                }
                else
                {
                    ds.Tables[0].Rows[i]["BALANCE LEAVE"] = "";
                }

            }

            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.Clear();
            string FileName = "LEAVE APPROVAL REPORT " + DateTime.Now.ToString("dd-MMM-yyyy / hh:mm tt") + ".xls";

            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.End();

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('No Data Found!! ', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 });", true);
        }
    }
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "view")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvrow = GridView.Rows[index];
            Label lbl_EMPID = (Label)GridView.Rows[index].FindControl("emp_id");
            Label lbl_SRNO = (Label)GridView.Rows[index].FindControl("sr_no");
            Session["srno"] = lbl_SRNO.Text;

            string filename = lbl_EMPID.Text + "_" + lbl_SRNO.Text + ".pdf";




            //string path = ("http://localhost:60604//Applications/" + filename);
            string path = ("https://imr.vivacollege.in/viva_imr_v_1/Applications/" + filename);

            Response.Write("<script>");
            Response.Write("window.open('" + path + "',null,'height=600px,width=700px,status=0,toolbar=no,location=0')");
            Response.Write("</script>");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + path + "','_newtab');", true);
        }
        if (e.CommandName == "print")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvrow = GridView.Rows[index];
            Label lbl_EMPID = (Label)GridView.Rows[index].FindControl("emp_id");
            Label lbl_SRNO = (Label)GridView.Rows[index].FindControl("sr_no");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('LeaveApplicationForm.aspx','_newtab');", true);
            Session["srno"] = lbl_SRNO.Text;
            Session["emp_id"] = lbl_EMPID.Text;
        }
    }
    protected void ddl_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridload();
    }

    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }


    protected void lnkbtn_print_Click(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
        int index = gvrow.RowIndex;

        Label lbl_EMPID = (Label)GridView.Rows[index].FindControl("emp_id");
        Label lbl_SRNO = (Label)GridView.Rows[index].FindControl("sr_no");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('LeaveApplicationForm.aspx','_newtab');", true);
        Session["srno"] = lbl_SRNO.Text;
        Session["emp_id"] = lbl_EMPID.Text;
    }
}