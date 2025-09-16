using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Portals_Staff_Fee_DefineInstallment : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnksearch_Click(object sender, EventArgs e)
    {
        try
        {
            feepanel.Visible = false;
            if (chk_bx.Checked)
            {
                if (txt_fname.Text.Trim() == "" && txt_mname.Text.Trim() == "" && txt_lname.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Enter Student Name', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 })", true);
                }
                else
                {
                    string qry = "select distinct  a.stud_id, stud_F_name +' ' + stud_m_name + ' ' + stud_L_name as name  ,a.stud_Gender as [Gender] from m_std_personaldetails_tbl as a,m_std_studentacademic_tbl as b where a.del_flag=0 and  b.del_flag=0 and a.stud_id = b.stud_id and a.stud_id is not null and a.stud_F_name like '%" + txt_fname.Text.Trim() + "%' and stud_m_name like '%" + txt_mname.Text.Trim() + "%' and stud_L_name like '%" + txt_lname.Text.Trim() + "%';";
                    DataTable dt = cls.fillDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        grd_name.DataSource = dt;
                        grd_name.DataBind();
                        div_grd_name.Visible = true;
                    }
                }
            }
            else
            {
                if (txt_studid.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Enter Student ID.', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 })", true);
                }
                else if (txt_studid.Text.Trim().Length != 8)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Invalid Student Id', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 })", true);
                }
                else
                {
                    DataTable dtstud = cls.fillDataTable("select (select isnull(stud_F_Name,'')+' '+isnull(stud_M_Name,'')+' '+isnull(stud_L_Name,'') [Name] from m_std_personaldetails_tbl where stud_id=a.stud_id) as [Name], (select course_name from m_crs_course_tbl where del_flag=0 and course_id in (select course_id from m_crs_subcourse_tbl where subcourse_id=a.subcourse_Id and del_flag=0)) as Course,(select subcourse_name from m_crs_subcourse_tbl where del_flag=0 and subcourse_id=a.subcourse_Id) Subcourse,(select Group_title from m_crs_subjectgroup_tbl where del_flag=0 and Group_id=a.group_id)[Group],group_id as [Group ID],(select Acd_year from academic where AYID=a.ayid)[Year],ayid as [AYID] from (select * from m_std_studentacademic_tbl where stud_id='" + txt_studid.Text + "' and del_flag=0)a order by ayid");
                    if (dtstud.Rows.Count > 0)
                    {
                        div_grd_name.Visible = false;
                        grdyear.DataSource = dtstud;
                        grdyear.DataBind();
                        lblmodalid.Text = txt_studid.Text;
                        lblmodalname.Text = dtstud.Rows[0]["Name"].ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('modalyear');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Student ID not found', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
    }

    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (installtable.Visible)
        {
            if (grd_install.Rows.Count > 0)
            {
                string qry = "";
                bool validate = true;
                for (int i = 0; i < grd_install.Rows.Count; i++)
                {
                    string lbl_sr_no = ((Label)grd_install.Rows[i].FindControl("lbl_sr_no")).Text.Trim();
                    string Install_id = ((Label)grd_install.Rows[i].FindControl("Install_id")).Text.Trim();
                    string Due_date = ((TextBox)grd_install.Rows[i].FindControl("Due_date")).Text.Trim();
                    DateTime parsedDate = DateTime.ParseExact(Due_date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    Due_date = parsedDate.ToString("yyyy-MM-dd");
                    string Install_Amount = ((TextBox)grd_install.Rows[i].FindControl("Install_Amount")).Text.Trim();
                    string balance_Amount = ((TextBox)grd_install.Rows[i].FindControl("balance_Amount")).Text.Trim();
                    if (Due_date == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Due Date', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                        ((TextBox)grd_install.Rows[i].FindControl("Due_date")).Focus();
                        validate = false;
                        break;
                    }
                    else
                    {
                        qry += "insert into m_FeeInstallment (Install_id,Stud_id,Ayid,Group_id,Install_no,Due_date,Install_Amount,balance_Amount,PaymentStatus,user_id) values ('" + Install_id + "','" + txt_studid.Text.Trim() + "','" + lblayid.Text.Trim() + "','" + lblgroupid.Text.Trim() + "'," + lbl_sr_no + ",(CAST('" + Due_date + "' AS datetime))," + Install_Amount + "," + balance_Amount + ",0,'" + Session["emp_id"].ToString() + "');";
                    }
                }
                if (validate == true)
                {
                    if (qry != "")
                    {
                        if (cls.TranDMLqueries(qry) == true)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Saved Successfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                            load_grd();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('No Changes Made !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Installment !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Waive Off In Process !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        ddl_installment.SelectedIndex = 0;
        ddl_installment_SelectedIndexChanged(sender, e);
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        try
        {
            txt_studid.Enabled = false;
            GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
            string stud_id = txt_studid.Text.Trim();
            string group_id = ((Label)gvrow.FindControl("lblgroupid")).Text.Trim();
            string course = ((Label)gvrow.FindControl("lblcourse")).Text.Trim();
            string subcourse = ((Label)gvrow.FindControl("lblsubcourse")).Text.Trim();
            string year = ((Label)gvrow.FindControl("lblyear")).Text.Trim();
            string ayid = ((Label)gvrow.FindControl("lblayid")).Text.Trim();
            string Group_Title = ((Label)gvrow.FindControl("lblgroup")).Text.Trim();

            DataTable dt_category = cls.fillDataTable("select distinct stud_Category,UPPER(stud_Gender) [stud_Gender] from m_std_personaldetails_tbl where stud_id='" + txt_studid.Text.Trim() + "' and del_flag=0");

            if (dt_category.Rows.Count > 0)
            {
                string category = dt_category.Rows[0]["stud_Category"].ToString().Trim().ToUpper();
                string gender = dt_category.Rows[0]["stud_Gender"].ToString().Trim().ToUpper();
                gender = gender == "0" ? "FEMALE" : (gender == "1" ? "MALE" : gender);
                if (dt_category.Rows[0]["stud_Category"].ToString() == "OPEN")
                {
                    Session["feemaster"] = "m_FeeMaster";
                    Session["gender"] = "NON";
                }
                else
                {
                    Session["feemaster"] = "m_FeeMaster_category";
                    Session["gender"] = gender;
                }
                string student_details = "SELECT ISNULL(Paid.PaidAmount,0) AS PaidAmount,(ISNULL(Total.TotalAmount,0)-ISNULL(Concession.ConcessionAmount,0)) AS TotalAmount,ISNULL(Concession.ConcessionAmount,0) AS ConcessionAmount,(ISNULL(Total.TotalAmount,0)-ISNULL(Concession.ConcessionAmount,0))-ISNULL(Paid.PaidAmount,0) AS Balance FROM (SELECT SUM(CAST(Amount AS INT)) AS PaidAmount FROM m_FeeEntry WHERE Stud_id='" + stud_id + "' AND Ayid='" + ayid + "' AND Chq_status='Clear' AND del_flag=0 AND fine_flag=0 AND ISNULL(concession_flag,0)=0) AS Paid CROSS JOIN (SELECT SUM(CAST(Amount AS INT)) AS TotalAmount FROM " + Session["feemaster"].ToString() + " WHERE Ayid='" + ayid + "' AND Group_id='" + group_id + "' AND del_flag=0 AND Gender='" + Session["gender"].ToString() + "' AND Category='" + category + "') AS Total CROSS JOIN (SELECT SUM(CAST(Amount AS INT)) AS ConcessionAmount FROM m_FeeEntry WHERE Stud_id='" + stud_id + "' AND Ayid='" + ayid + "' AND del_flag=0 AND Chq_status='Clear' AND concession_flag=1) AS Concession;";

                DataTable dt = cls.fillDataTable(student_details);
                if (dt.Rows.Count > 0)
                {
                    lblname.Text = lblmodalname.Text.Trim();
                    lblgender.Text = gender;
                    lbl_totalfees.Text = dt.Rows[0]["TotalAmount"].ToString();
                    lblgroup.Text = Group_Title;
                    lblgroupid.Text = group_id;
                    lblyear.Text = year.ToString();
                    lblayid.Text = ayid.ToString();
                    lblcategory.Text = category;
                    lblpaidfees.Text = dt.Rows[0]["PaidAmount"].ToString();
                    lblbal.Text = dt.Rows[0]["Balance"].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal('modalyear');", true);
                    feepanel.Visible = true;
                    ddl_installment.SelectedIndex = 0;
                    load_grd();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Fees not defined', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Category not defined', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
    }

    protected void ddl_installment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (installtable.Visible)
        {
            grd_install.DataSource = null;
            grd_install.DataBind();

            if (ddl_installment.SelectedValue != "")
            {
                int totalAmount = Convert.ToInt32(lblbal.Text);
                int no_of_installments = Convert.ToInt32(ddl_installment.SelectedValue);

                int baseAmount = totalAmount / no_of_installments;
                int remainder = totalAmount % no_of_installments;

                DataTable dt = new DataTable();
                dt.Columns.Add("Install_id");
                dt.Columns.Add("Due_date");
                dt.Columns.Add("Install_Amount");
                dt.Columns.Add("balance_Amount");

                for (int i = 1; i <= no_of_installments; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Install_id"] = getinstall_id(i);
                    dr["Due_date"] = "";
                    int installmentAmt = (i <= remainder) ? baseAmount + 1 : baseAmount;
                    dr["Install_Amount"] = installmentAmt.ToString();
                    dr["balance_Amount"] = installmentAmt.ToString();
                    dt.Rows.Add(dr);
                }
                if (dt.Rows.Count > 0)
                {
                    grd_install.DataSource = dt;
                    grd_install.DataBind();
                    installtable.Visible = true;
                    feetable.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Waive Off In Process !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
    }
    public string getnum(int num)
    {
        switch (num)
        {
            case 1: return "ONE";
            case 2: return "TWO";
            case 3: return "THREE";
            case 4: return "FOUR";
            case 5: return "FIVE";
            case 6: return "SIX";
            case 7: return "SEVEN";
            case 8: return "EIGHT";
            case 9: return "NINE";
            case 10: return "TEN";
            default: return "INVALID";
        }
    }

    public string getinstall_id(int i)
    {
        string qry = "select MAX(Install_id) from m_FeeInstallment where Stud_id='" + txt_studid.Text.Trim() + "' and Group_id='" + lblgroupid.Text.Trim() + "'";
        DataTable dt = cls.fillDataTable(qry);
        int lastNo = 0;
        if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value && dt.Rows[0][0].ToString().Length >= 10)
        {
            string lastInstallId = dt.Rows[0][0].ToString();
            string suffix = lastInstallId.Substring(lastInstallId.Length - 2);
            int.TryParse(suffix, out lastNo);
        }
        int newNumber = lastNo + i;
        string paddedNumber = newNumber.ToString().PadLeft(2, '0');
        return txt_studid.Text.Trim() + paddedNumber;
    }

    public void load_grd()
    {
        try
        {
            DataTable dt = cls.fillDataTable("select Install_id,Install_no,CONVERT(varchar, Due_date, 103)[Due_date],Install_Amount,balance_Amount from m_FeeInstallment where Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Group_id='" + lblgroupid.Text.Trim() + "' and Del_flag=0 order by Install_no");
            if (dt.Rows.Count > 0)
            {
                grd_install.DataSource = dt;
                grd_install.DataBind();
                ddl_installment.SelectedValue = dt.Rows.Count.ToString();
                ddl_installment.Enabled = false;
                div_new.Visible = true;
                div_print.Visible = true;
                btnsave.Enabled = false;
                btncancel.Enabled = false;
                installtable.Visible = true;
                feetable.Visible = false;
            }
            else
            {
                grd_install.DataSource = null;
                grd_install.DataBind();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
    }

    protected void lnkEnableDate_Click(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
        LinkButton lnkEnableDate = (LinkButton)gvrow.FindControl("lnkEnableDate");
        TextBox Due_date = (TextBox)gvrow.FindControl("Due_date");
        string Install_id = ((Label)gvrow.FindControl("Install_id")).Text.Trim();
        if (lnkEnableDate.CssClass.Contains("bi-pencil"))
        {
            Due_date.Enabled = true;
            lnkEnableDate.CssClass = "btn btn-outline-success bi bi-save";
        }
        else
        {
            if (Due_date.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Due Date', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                Due_date.Focus();
            }
            else
            {
                DateTime parsedDate = DateTime.ParseExact(Due_date.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string Due_date_sql = parsedDate.ToString("yyyy-MM-dd");
                string qry = "update  m_FeeInstallment set Due_date=(CAST('" + Due_date_sql + "' AS datetime)),mod_dt=GETDATE(),user_id='" + Session["emp_id"].ToString() + "' where Install_id='" + Install_id + "' and Del_flag=0";
                if (cls.DMLqueries(qry))
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updated Successfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                    load_grd();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                }
            }
        }
    }

    protected void btn_new_Click(object sender, EventArgs e)
    {
        if (installtable.Visible)
        {
            string confirmValue = Request.Form["confirm_value"];
            string[] CVA = confirmValue.Split(new Char[] { ',' });
            if (CVA[CVA.Length - 1] == "Yes")
            {
                string qry = "update  m_FeeInstallment set Del_flag=1 ,del_dt=GETDATE(),user_id='" + Session["emp_id"].ToString() + "'  where Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Group_id='" + lblgroupid.Text.Trim() + "' and Del_flag=0";
                if (cls.DMLqueries(qry))
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Redefine Installment', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                    ddl_installment.SelectedValue = "";
                    ddl_installment.Enabled = true;
                    div_new.Visible = false;
                    div_print.Visible = false;
                    grd_install.DataSource = null;
                    grd_install.DataBind();
                    btnsave.Enabled = true;
                    btncancel.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Waive Off In Process !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
    }

    protected void chk_bx_CheckedChanged(object sender, EventArgs e)
    {
        feepanel.Visible = false;
        if (chk_bx.Checked)
        {
            div_name.Visible = true;
            div_stud_id.Visible = false;
            txt_fname.Text = "";
            txt_mname.Text = "";
            txt_lname.Text = "";
            txt_studid.Text = "";
        }
        else
        {
            txt_fname.Text = "";
            txt_mname.Text = "";
            txt_lname.Text = "";
            txt_studid.Text = "";
            div_name.Visible = false;
            div_stud_id.Visible = true;
        }
    }

    protected void lnk_name_view_Click(object sender, EventArgs e)
    {
        chk_bx.Checked = false;
        chk_bx_CheckedChanged(sender, e);
        GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
        txt_studid.Text = ((Label)gvrow.FindControl("lbl_stud_id")).Text.Trim();
        lnksearch_Click(sender, e);
    }

    protected void btn_waveoff_Click(object sender, EventArgs e)
    {
        DataTable dt_in = cls.fillDataTable("select Install_id from m_FeeInstallment where Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Del_flag=0");
        if (dt_in.Rows.Count > 0) { ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Installment Defined Cannot Define Concession !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true); }
        else
        {
            if (!btn_waveoff.Text.Contains("Cancel"))
            {
                string qry = "SELECT CASE ISNULL(con.concession,0) WHEN 0 THEN 0 ELSE 1 END AS flag, mst.Struct_type, mst.Struct_name, (CAST(mst.Amount AS INT)-ISNULL(con.concession,0)) AS TotalFees, ISNULL(Paid,0) AS Paid, ISNULL(con.concession,'') AS Concession, CAST(mst.Amount AS INT) - ISNULL(Paid,0) - ISNULL(con.concession,0) AS Balance, mst.Struct_id, mst.Rank  FROM " + Session["feemaster"].ToString() + " mst LEFT JOIN (SELECT fee.Struct_id, SUM(CAST(fee.Amount AS INT)) AS Paid FROM m_FeeEntry fee WHERE fee.Stud_id='" + txt_studid.Text.Trim() + "' AND fee.Ayid='" + lblayid.Text.Trim() + "' AND fee.del_flag=0 AND fee.Chq_status='Clear'  AND fee.concession_flag=0 GROUP BY fee.Struct_id) fee ON fee.Struct_id=mst.Struct_id LEFT JOIN (SELECT con.Struct_id, SUM(CAST(con.Amount AS INT)) AS concession FROM m_FeeEntry con WHERE con.Stud_id='" + txt_studid.Text.Trim() + "' AND con.Ayid='" + lblayid.Text.Trim() + "' AND con.del_flag=0 AND con.Chq_status='Clear' AND con.concession_flag=1 GROUP BY con.Struct_id) con ON con.Struct_id=mst.Struct_id WHERE mst.Ayid='" + lblayid.Text.Trim() + "' AND mst.del_flag=0 AND mst.Group_id='" + lblgroupid.Text.Trim() + "' AND mst.Gender='" + Session["gender"].ToString().Trim() + "' AND mst.Category='" + lblcategory.Text.Trim() + "' AND mst.Struct_type like 'OTHER%' ORDER BY mst.Rank";

                DataTable dt = cls.fillDataTable(qry);
                if (dt.Rows.Count > 0)
                {

                    grdfees.DataSource = dt;
                    grdfees.DataBind();
                    installtable.Visible = false;
                    feetable.Visible = true;
                    btn_waveoff.Text = "Cancel Waive Off";
                }
                else
                {
                    grdfees.DataSource = null;
                    grdfees.DataBind();
                    installtable.Visible = true;
                    feetable.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Fees Not Defined !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
                    return;
                }
            }
            else
            {
                btn_waveoff.Text = "Waive Off";
                installtable.Visible = true;
                feetable.Visible = false;
            }
        }
    }

    protected void btn_save_waveoff_Click(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
        LinkButton lnkEnableDate = (LinkButton)gvrow.FindControl("btn_save_waveoff");
        TextBox txtpay = (TextBox)gvrow.FindControl("txtpay");
        string lblflag = ((Label)gvrow.FindControl("lblflag")).Text.Trim();
        string lbl_struct_id = ((Label)gvrow.FindControl("lbl_struct_id")).Text.Trim();
        string lblstructname = ((Label)gvrow.FindControl("lblstructname")).Text.Trim();
        if (lnkEnableDate.CssClass.Contains("bi-trash"))
        {
            string qry = "Update m_FeeEntry  set del_flag=1  WHERE Stud_id='" + txt_studid.Text.Trim() + "' AND Ayid='" + lblayid.Text.Trim() + "' AND del_flag=0 AND concession_flag=1 ";
            if (cls.DMLqueries(qry))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Concession Deleted !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
                btn_waveoff.Text = "Waive Off";
                btn_waveoff_Click(sender, e);
            }
        }
        else
        {
            if (txtpay.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Concession Amount !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
                return;
            }
            else if (txtpay.Text.Trim() == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Concession Amount Cannot be Zero!!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
                return;
            }
            else
            {
                string qry = "insert into m_FeeEntry(Stud_id, Amount, Ayid, Pay_date, Struct_id,Install_id,Struct_name, Recpt_mode, Receipt_no, Recpt_Chq_dt, Recpt_Chq_No, Recpt_Bnk_Name, Recpt_Bnk_Branch, Chq_status, type, user_id,concession_flag) values ('" + txt_studid.Text.Trim() + "','" + txtpay.Text.Trim() + "','" + lblayid.Text.Trim() + "',Getdate(),'" + lbl_struct_id + "',NULL,'" + lblstructname + "','concession','" + load_recipt_no() + "',NULL,NULL,NULL,NULL,'Clear','concession','" + Session["emp_id"].ToString() + "',1);";
                if (cls.DMLqueries(qry))
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Concession Updated Successfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                    btn_waveoff.Text = "Waive Off";
                    btn_waveoff_Click(sender, e);
                }
            }
        }
        string student_details = "SELECT ISNULL(Paid.PaidAmount,0) AS PaidAmount,(ISNULL(Total.TotalAmount,0)-ISNULL(Concession.ConcessionAmount,0)) AS TotalAmount,ISNULL(Concession.ConcessionAmount,0) AS ConcessionAmount,(ISNULL(Total.TotalAmount,0)-ISNULL(Concession.ConcessionAmount,0))-ISNULL(Paid.PaidAmount,0) AS Balance FROM (SELECT SUM(CAST(Amount AS INT)) AS PaidAmount FROM m_FeeEntry WHERE Stud_id='" + txt_studid.Text.Trim() + "' AND Ayid='" + lblayid.Text.Trim() + "' AND Chq_status='Clear' AND del_flag=0 AND fine_flag=0 AND ISNULL(concession_flag,0)=0) AS Paid CROSS JOIN (SELECT SUM(CAST(Amount AS INT)) AS TotalAmount FROM " + Session["feemaster"].ToString() + " WHERE Ayid='" + lblayid.Text.Trim() + "' AND Group_id='" + lblgroupid.Text.Trim() + "' AND del_flag=0 AND Gender='" + Session["gender"].ToString() + "' AND Category='" + lblcategory.Text.Trim() + "') AS Total CROSS JOIN (SELECT SUM(CAST(Amount AS INT)) AS ConcessionAmount FROM m_FeeEntry WHERE Stud_id='" + txt_studid.Text.Trim() + "' AND Ayid='" + lblayid.Text.Trim() + "' AND del_flag=0 AND Chq_status='Clear' AND concession_flag=1) AS Concession;";

        DataTable dt = cls.fillDataTable(student_details);
        if (dt.Rows.Count > 0)
        {
            lbl_totalfees.Text = dt.Rows[0]["TotalAmount"].ToString();
            lblpaidfees.Text = dt.Rows[0]["PaidAmount"].ToString();
            lblbal.Text = dt.Rows[0]["Balance"].ToString();
        }
    }

    public string load_recipt_no()
    {
        string studId = txt_studid.Text.Trim();
        string year = lblyear.Text.Trim().Split('-')[0];
        string prefix = studId + "-" + year + "CON-";
        int newIncrement = 1;

        string qry = "SELECT MAX(RIGHT(Receipt_No, 2)) FROM m_FeeEntry WHERE Receipt_No LIKE '" + prefix + "%'";
        DataTable dt = cls.fillDataTable(qry);

        if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
        {
            int maxVal = Convert.ToInt32(dt.Rows[0][0].ToString());
            if (maxVal >= 99)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Maximum receipt count (99) reached for this student and year !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
                return null;
            }
            newIncrement = maxVal + 1;
        }

        string receiptNo = prefix + newIncrement.ToString("D2");
        return receiptNo;
    }

    protected void btn_print_Click(object sender, EventArgs e)
    {
        Session["install_stud_id"] = txt_studid.Text.Trim();
        Session["instll_group_id"] = lblgroupid.Text;
        Session["install_ayid"] = lblayid.Text.Trim();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "redirect('Installment_Receipt.aspx');", true);
    }
}