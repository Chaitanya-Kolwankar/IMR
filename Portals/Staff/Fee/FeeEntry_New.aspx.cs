using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Math;
using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FeeEntry_New : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["emp_id"] == null)
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "loaddate()", true);
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
        string msg = validate();
        if (msg != "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('" + msg + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
        }
        else
        {
            string stud_id = txt_studid.Text.Trim();
            string ayid = lblayid.Text.Trim();
            DateTime parsedDate = DateTime.ParseExact(txtpaydate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string pay_date = parsedDate.ToString("yyyy-MM-dd");
            string install_id = ddl_install.SelectedValue;
            string chq_status = "";
            string bankname = "";
            string recpt_chq_dt = "";
            string recpt_chq_no = "";
            string recpt_bank_branch = "";
            string receipt_no = load_recipt_no();
            string recpt_mode = ddlmode.SelectedItem.ToString();
            if (ddlmode.SelectedItem.ToString() != "Cash")
            {
                bankname = txtbnkname.Text;
                DateTime parsedDate1 = DateTime.ParseExact(txtchdate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                recpt_chq_dt = parsedDate1.ToString("yyyy-MM-dd");
                recpt_chq_no = txtchno.Text;
                if (ddlmode.SelectedItem.ToString() == "Cheque" || ddlmode.SelectedItem.ToString().Contains("NEFT") == true || ddlmode.SelectedItem.ToString() == "DD")
                {
                    recpt_bank_branch = txtbranch.Text;
                }
                if (ddlmode.SelectedItem.ToString() == "Cheque" || ddlmode.SelectedItem.ToString().Contains("NEFT") == true)
                {
                    chq_status = ddlstatus.SelectedItem.ToString();
                }
                else
                {
                    chq_status = "Clear";
                }
            }
            else
            {
                chq_status = "Clear";
            }

            string qry = string.Empty;
            if (receipt_no != "")
            {
                foreach (GridViewRow row in grdfees.Rows)
                {
                    TextBox txtpay = (TextBox)row.FindControl("txtpay");
                    Label lbl_struct_id = (Label)row.FindControl("lbl_struct_id");
                    Label lbl_struct_type = (Label)row.FindControl("lbl_struct_type");
                    Label lblstructname = (Label)row.FindControl("lblstructname");
                    Label lblpending = (Label)row.FindControl("lblpending");
                    if (txtpay.Text.Trim() != "")
                    {
                        if (btnsave.Text == "Save")
                        {
                            qry += "insert into m_FeeEntry(Stud_id, Amount, Ayid, Pay_date, Struct_id,Install_id,Struct_name, Recpt_mode, Receipt_no, Recpt_Chq_dt, Recpt_Chq_No, Recpt_Bnk_Name, Recpt_Bnk_Branch, Chq_status, type, user_id) values ('" + stud_id + "','" + txtpay.Text.Trim() + "','" + ayid + "',(CAST('" + pay_date + "' AS datetime)),NULLIF('" + lbl_struct_id.Text.Trim() + "',''),'" + install_id + "','" + lblstructname.Text.Trim() + "','" + recpt_mode + "','" + receipt_no + "',NULLIF((CAST('" + recpt_chq_dt + "' AS datetime)),''),NULLIF('" + recpt_chq_no + "',''),NULLIF('" + bankname + "',''),NULLIF('" + recpt_bank_branch + "',''),'" + chq_status + "','" + lbl_struct_type.Text.Trim() + "','" + Session["emp_id"].ToString() + "');";
                        }
                        else
                        {
                            qry += "update m_FeeEntry set Amount='" + txtpay.Text.Trim() + "',Pay_date=(CAST('" + pay_date + "' AS datetime)),Recpt_mode='" + recpt_mode + "',Recpt_Chq_dt=NULLIF((CAST('" + recpt_chq_dt + "' AS datetime)),''),Recpt_Chq_No=NULLIF('" + recpt_chq_no + "',''),Recpt_Bnk_Name=NULLIF('" + bankname + "',''),Recpt_Bnk_Branch=NULLIF('" + recpt_bank_branch + "',''),Chq_status='" + chq_status + "',mod_dt=GETDATE() where stud_id='" + stud_id + "' and Struct_id='" + lbl_struct_id.Text.Trim() + "' and Ayid='" + ayid + "' and Receipt_no='" + hidden_recpt_no.Value + "' and del_flag=0 ;";
                        }
                    }
                }
                if (qry != "")
                {
                    if (div_install.Visible)
                    {
                        qry += "update m_FeeInstallment set balance_Amount='" + hidden_install_bal.Value.Trim() + "',PaymentStatus=" + (hidden_install_bal.Value.Trim() == "0" ? 1 : 0) + " where Install_id='" + install_id + "' and Del_flag=0;";
                    }
                    if (div_fine.Visible && chk_fine.Checked && btnsave.Text == "Save")
                    {
                        qry += "insert into m_FeeEntry(Stud_id, Amount, Ayid, Pay_date, Struct_id,Install_id,Struct_name, Recpt_mode, Receipt_no, Recpt_Chq_dt, Recpt_Chq_No, Recpt_Bnk_Name, Recpt_Bnk_Branch, Chq_status, type, user_id,Fine_flag) values ('" + stud_id + "','" + txt_fine.Text.Trim() + "','" + ayid + "',(CAST('" + pay_date + "' AS datetime)),NULLIF('" + install_id + "',''),'Fine','Fine','" + recpt_mode + "','" + receipt_no + "',NULLIF((CAST('" + recpt_chq_dt + "' AS datetime)),''),NULLIF('" + recpt_chq_no + "',''),NULLIF('" + bankname + "',''),NULLIF('" + recpt_bank_branch + "',''),'" + chq_status + "','Fine','" + Session["emp_id"].ToString() + "',1);";
                    }
                    if (cls.TranDMLqueries(qry))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + btnsave.Text.Trim() + "d Successfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                        load_grd();
                        clear();
                        ddlmode.SelectedIndex = 0;
                        btnsave.Text = "Save";
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
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
            }
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
        ddlmode.SelectedIndex = 0;
        btnsave.Text = "Save";
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
                string student_details = "SELECT ISNULL(Paid.PaidAmount, 0) AS PaidAmount,ISNULL(Total.TotalAmount, 0) AS TotalAmount,ISNULL(Total.TotalAmount, 0) - ISNULL(Paid.PaidAmount, 0) AS Balance FROM (SELECT SUM(CAST(Amount AS INT)) AS PaidAmount FROM m_FeeEntry WHERE Stud_id = '" + stud_id + "' AND Ayid = '" + ayid + "' AND Chq_status = 'Clear' AND del_flag = 0 and fine_flag=0) AS Paid CROSS JOIN(SELECT SUM(CAST(Amount AS INT)) AS TotalAmount FROM " + Session["feemaster"].ToString() + " WHERE Ayid = '" + ayid + "' AND Group_id = '" + group_id + "' AND del_flag = 0 and Gender='" + Session["gender"].ToString() + "' and Category='" + category + "' ) AS Total";

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

    public void load_grd()
    {
        try
        {
            DataTable dt = cls.fillDataTable("select Receipt_no,Chq_status,Type,SUM(CAST(Amount as int)) [Amount],Recpt_mode,Convert(varchar, Pay_date,103) [Pay_date],Install_id from m_FeeEntry where Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and del_flag=0 and fine_flag=0 group by Receipt_no,Chq_status,Type,Recpt_mode,Pay_date,Install_id ;");
            if (dt.Rows.Count > 0)
            {
                grdedit.DataSource = dt;
                grdedit.DataBind();
            }
            else
            {
                grdedit.DataSource = null;
                grdedit.DataBind();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
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
            txt_studid.Enabled = true;
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

    protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (btnsave.Text.Trim() == "Save") { clear(); }
        if (ddlmode.SelectedItem.ToString() != "--Select--")
        {
            load_main_grd();
            if (ddlmode.SelectedItem.ToString() == "Cheque" || ddlmode.SelectedItem.ToString().Contains("NEFT"))
            {
                details.Visible = true;
                status.Visible = true;
                branch.Visible = true;
            }
            else if (ddlmode.SelectedItem.ToString() == "DD")
            {
                details.Visible = true;
                status.Visible = false;
                branch.Visible = true;
            }
            else if (ddlmode.SelectedItem.ToString() == "Online Pay")
            {
                details.Visible = true;
                branch.Visible = false;
                status.Visible = false;
            }
            else
            {
                details.Visible = false;
                status.Visible = false;
                status.Visible = false;
            }
        }
    }

    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void chkselect_CheckedChanged(object sender, EventArgs e)
    {

    }

    public void load_main_grd()
    {
        try
        {
            string qry = "";
            if (btnsave.Text.Trim() == "Save")
            {
                qry = "SELECT CASE WHEN ISNULL(Paid, 0) >= CAST(mst.Amount AS INT) THEN 1 ELSE 0 END AS flag, mst.Struct_type, mst.Struct_name, CAST(mst.Amount AS INT) AS TotalFees, ISNULL(Paid, 0) AS Paid, CAST(mst.Amount AS INT) - ISNULL(Paid, 0) AS Balance, mst.Struct_id, mst.Rank FROM " + Session["feemaster"].ToString() + " mst LEFT JOIN (SELECT fee.Struct_id, SUM(CAST(fee.Amount AS INT)) AS Paid FROM m_FeeEntry fee WHERE fee.Stud_id = '" + txt_studid.Text.Trim() + "' AND fee.Ayid = '" + lblayid.Text.Trim() + "' AND fee.del_flag = 0 AND fee.Chq_status = 'Clear' GROUP BY fee.Struct_id) fee ON fee.Struct_id = mst.Struct_id WHERE mst.Ayid = '" + lblayid.Text.Trim() + "' AND mst.del_flag = 0 AND mst.Group_id = '" + lblgroupid.Text.Trim() + "' AND mst.Gender = '" + Session["gender"].ToString().Trim() + "' AND mst.Category = '" + lblcategory.Text.Trim() + "' ORDER BY mst.Rank;";
            }
            else
            {
                qry = "SELECT CASE WHEN ISNULL(Paid, 0) >= CAST(mst.Amount AS INT) THEN 1 ELSE 0 END AS flag, mst.Struct_type, mst.Struct_name, CAST(mst.Amount AS INT) AS TotalFees, ISNULL(Paid, 0) AS Paid, CAST(mst.Amount AS INT) - ISNULL(Paid, 0) AS Balance, mst.Struct_id, mst.Rank FROM " + Session["feemaster"].ToString() + " mst LEFT JOIN (SELECT fee.Struct_id, SUM(CAST(fee.Amount AS INT)) AS Paid FROM m_FeeEntry fee WHERE fee.Stud_id = '" + txt_studid.Text.Trim() + "' AND fee.Ayid = '" + lblayid.Text.Trim() + "' AND fee.del_flag = 0 AND fee.Chq_status = 'Clear' and Receipt_no !='" + hidden_recpt_no.Value + "' GROUP BY fee.Struct_id) fee ON fee.Struct_id = mst.Struct_id WHERE mst.Ayid = '" + lblayid.Text.Trim() + "' AND mst.del_flag = 0 AND mst.Group_id = '" + lblgroupid.Text.Trim() + "' AND mst.Gender = '" + Session["gender"].ToString().Trim() + "' AND mst.Category = '" + lblcategory.Text.Trim() + "' ORDER BY mst.Rank;";
            }
            DataTable dt = cls.fillDataTable(qry);
            if (dt.Rows.Count > 0)
            {
                grdfees.DataSource = dt;
                grdfees.DataBind();
                btn.Visible = true;
                div_amount.Visible = true;
                load_ddl_install();
            }
            else
            {
                grdfees.DataSource = null;
                grdfees.DataBind();
                btn.Visible = false;
                div_amount.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Fees Not Defined !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
                return;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
    }

    protected void ddl_install_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_amount.Text = string.Empty;
        div_fine.Visible = false;
        if (ddl_install.SelectedValue != "0")
        {
            string selected_valuve = ddl_install.SelectedItem.Text.Trim();
            string amount = Regex.Match(selected_valuve, @"\((.*?)\)").Groups[1].Value;
            txt_amount.Text = amount;
            hidden_install_amount.Value = amount;
            txt_amount_TextChanged(sender, e);
            string qry = "";
            if (btnsave.Text.Trim() == "Save")
            {
                qry = "select  (CASE WHEN GETDATE() > Due_date THEN DATEDIFF(DAY, Due_date, GETDATE()) * 10 ELSE 0 END) [Fine],Fine_flag from m_FeeInstallment where Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Group_id='" + lblgroupid.Text.Trim() + "' and  Install_id='" + ddl_install.SelectedValue + "' and Del_flag=0;";
            }
            else
            {
                qry = "select CAST(Amount as int) [Fine],Fine_flag from m_FeeEntry where Stud_id='22101096' and Ayid='AYD0071' and del_flag=0 and fine_flag=1  and Install_id='" + hidden_install_Id.Value + "' and Receipt_no='" + hidden_recpt_no.Value + "';";
            }
            DataTable dt = cls.fillDataTable(qry);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["Fine"]) > 0)
                {
                    div_fine.Visible = true;
                    txt_fine.Text = dt.Rows[0]["Fine"].ToString().Trim();
                    chk_fine.Checked = Convert.ToBoolean(dt.Rows[0]["Fine_flag"].ToString());
                }
            }
        }
    }

    public void load_ddl_install()
    {
        if (btnsave.Text.Trim() == "Save")
        {
            cls.SetdropdownForMember1(ddl_install, "m_FeeInstallment", "(cast(Install_no As varchar) +' ('+ cast(balance_Amount As varchar) + ')') [install_no]", "Install_id", "Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Group_id='" + lblgroupid.Text.Trim() + "' and PaymentStatus=0 and Del_flag=0");
        }
        else
        {
            cls.SetdropdownForMember1(ddl_install, "m_FeeInstallment", "(cast(Install_no As varchar) +' ('+ cast(Install_Amount As varchar) + ')') [install_no]", "Install_id", "Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Group_id='" + lblgroupid.Text.Trim() + "' and Del_flag=0 and Install_id='" + hidden_install_Id.Value + "'");
        }
        if (ddl_install.Items.Count != 0)
        {
            div_install.Visible = true;
        }
    }

    protected void txt_amount_TextChanged(object sender, EventArgs e)
    {
        if (txt_amount.Text.Trim() != "")
        {
            int amount = Convert.ToInt32(txt_amount.Text.Trim());

            if (amount <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Amount Greater than 0 !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
            }
            else if (ddl_install.Items.Count != 0 && (amount > Convert.ToInt32(hidden_install_amount.Value)))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Maximum Installment Allowed : " + hidden_install_amount.Value + " !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
            }
            else if (amount > Convert.ToInt32(lblbal.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Maximum Value Allowed : " + lblbal.Text + " !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
            }
            else
            {
                if (div_install.Visible) { hidden_install_bal.Value = (Convert.ToInt32(hidden_install_amount.Value) - amount).ToString(); }
                foreach (GridViewRow row in grdfees.Rows)
                {
                    TextBox txtpay = (TextBox)row.FindControl("txtpay");
                    Label lblBalance = (Label)row.FindControl("lblpending");

                    int balance = Convert.ToInt32(lblBalance.Text.Trim());
                    if (amount > 0)
                    {
                        if (balance > 0)
                        {
                            if (amount >= balance)
                            {
                                txtpay.Text = balance.ToString();
                                amount -= balance;
                            }
                            else
                            {
                                txtpay.Text = amount.ToString();
                                amount = 0;
                            }
                        }
                    }
                    else
                    {
                        txtpay.Text = string.Empty;
                    }
                }
            }
        }
    }

    public string validate()
    {
        string msg = "";
        if (ddlmode.SelectedIndex == 0)
        {
            msg = "Select payment mode";
        }
        else if (txtpaydate.Text == "")
        {
            msg = "Select payment date";
        }
        else if (ddl_install.Items.Count != 0 && ddl_install.SelectedValue == "0")
        {
            msg = "Select Installment";
        }
        else if (txt_amount.Text.Trim() == "")
        {
            msg = "Enter Fee Amount";
        }
        else if (ddlmode.SelectedIndex > 0)
        {
            if (ddlmode.SelectedItem.ToString() == "Cheque" || ddlmode.SelectedItem.ToString() == "NEFT")
            {
                if (txtbnkname.Text == "")
                {
                    msg = "Add bank name";
                }
                else if (txtbranch.Text == "")
                {
                    msg = "Add branch name";
                }
                else if (txtchdate.Text == "")
                {
                    msg = "Select Cheque/DD/NEFT date";
                }
                else if (txtchno.Text == "")
                {
                    msg = "Add Cheque/DD/NEFT No.";
                }
                else if (ddlstatus.SelectedIndex == 0)
                {
                    msg = "Select Cheque/NEFT status";
                }
            }
            else if (ddlmode.SelectedItem.ToString() == "DD")
            {
                if (txtbnkname.Text == "")
                {
                    msg = "Add bank name";
                }
                else if (txtbranch.Text == "")
                {
                    msg = "Add branch name";
                }
                else if (txtchdate.Text == "")
                {
                    msg = "Select Cheque/DD/NEFT date";
                }
                else if (txtchno.Text == "")
                {
                    msg = "Add Cheque/DD/NEFT No.";
                }
            }
        }
        return msg;
    }

    public void clear()
    {
        txtbnkname.Text = "";
        txtbranch.Text = "";
        txtchdate.Text = "";
        txtchno.Text = "";
        ddlstatus.SelectedIndex = 0;
        details.Visible = false;
        status.Visible = false;
        btn.Visible = false;
        txtpaydate.Text = "";
        grdfees.DataSource = null;
        grdfees.DataBind();
        div_install.Visible = false;
        div_amount.Visible = false;
        div_fine.Visible = false;
        txt_amount.Text = string.Empty;
    }

    public string load_recipt_no()
    {
        string studId = txt_studid.Text.Trim();
        string year = lblyear.Text.Trim().Split('-')[0];
        string prefix = studId + "-" + year + "-";
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

    protected void btnfeeedit_Click(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
        string Recpt_mode = ((Label)gvrow.FindControl("Recpt_mode")).Text.Trim();
        string Pay_date = ((Label)gvrow.FindControl("Pay_date")).Text.Trim();
        string Install_id = ((Label)gvrow.FindControl("Install_id")).Text.Trim();
        string Receipt_no = ((Label)gvrow.FindControl("Receipt_no")).Text.Trim();
        string Amount = ((Label)gvrow.FindControl("Amount")).Text.Trim();
        hidden_install_Id.Value = Install_id;
        hidden_recpt_no.Value = Receipt_no;
        string check = "select Install_id from m_FeeInstallment where Install_id='" + Install_id + "' and Del_flag=1;select Install_id from m_FeeInstallment where Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Group_id='" + lblgroupid.Text.Trim() + "'  and Del_flag=0;";
        DataSet dscheck = cls.fillDataset(check);
        if (dscheck.Tables[0].Rows.Count > 0 && dscheck.Tables[1].Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Deletion Prohibited New Installment Defined Based on Current Selection!!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            btnsave.Text = "Update";

            ddlmode.SelectedValue = Recpt_mode;
            ddlmode_SelectedIndexChanged(sender, e);
            if (div_install.Visible)
            {
                ddl_install.SelectedValue = Install_id;
                ddl_install_SelectedIndexChanged(sender, e);
            }
            txtpaydate.Text = Pay_date;
            DataSet ds = cls.fillDataset("select distinct Stud_id,Receipt_no,Pay_date,type,Recpt_mode,Recpt_Bnk_Branch,Recpt_Bnk_Name,Recpt_Chq_dt,Recpt_Chq_No,Chq_status from m_FeeEntry where  Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Receipt_no='" + Receipt_no + "';");
            ds.Tables[0].TableName = "Details";
            if (ds.Tables["Details"].Rows[0]["Recpt_mode"].ToString() == "Cheque" || ds.Tables["Details"].Rows[0]["Recpt_mode"].ToString().Contains("NEFT") == true)
            {
                txtbnkname.Text = ds.Tables["Details"].Rows[0]["Recpt_Bnk_Name"].ToString();
                txtbranch.Text = ds.Tables["Details"].Rows[0]["Recpt_Bnk_Branch"].ToString();
                txtchdate.Text = Convert.ToDateTime(ds.Tables["Details"].Rows[0]["Recpt_Chq_dt"]).ToString("dd/MM/yyyy").Replace("-", "/");
                txtchno.Text = ds.Tables["Details"].Rows[0]["Recpt_Chq_No"].ToString();
                ddlstatus.SelectedValue = ds.Tables["Details"].Rows[0]["Chq_status"].ToString();
            }
            else if (ds.Tables["Details"].Rows[0]["Recpt_mode"].ToString() == "DD")
            {
                txtbnkname.Text = ds.Tables["Details"].Rows[0]["Recpt_Bnk_Name"].ToString();
                txtbranch.Text = ds.Tables["Details"].Rows[0]["Recpt_Bnk_Branch"].ToString();
                txtchdate.Text = Convert.ToDateTime(ds.Tables["Details"].Rows[0]["Recpt_Chq_dt"]).ToString("dd/MM/yyyy").Replace("-", "/");
                txtchno.Text = ds.Tables["Details"].Rows[0]["Recpt_Chq_No"].ToString();
            }
            else if (ds.Tables["Details"].Rows[0]["Recpt_mode"].ToString() == "Online Pay")
            {
                txtbnkname.Text = ds.Tables["Details"].Rows[0]["Recpt_Bnk_Name"].ToString();
                txtchdate.Text = Convert.ToDateTime(ds.Tables["Details"].Rows[0]["Recpt_Chq_dt"]).ToString("dd/MM/yyyy").Replace("-", "/");
                txtchno.Text = ds.Tables["Details"].Rows[0]["Recpt_Chq_No"].ToString();
            }
            if (div_install.Visible)
            {
                ddl_install.SelectedValue = Install_id;
                ddl_install_SelectedIndexChanged(sender, e);
            }
            txt_amount.Text = Amount;
            txt_amount_TextChanged(sender, e);
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
        string Receipt_no = ((Label)gvrow.FindControl("Receipt_no")).Text.Trim();
        string Type = ((Label)gvrow.FindControl("Type")).Text.Trim();
        string Install_id = ((Label)gvrow.FindControl("Install_id")).Text.Trim();
        string Amount = ((Label)gvrow.FindControl("Amount")).Text.Trim();

        string confirmValue = Request.Form["confirm_value"];
        string[] CVA = confirmValue.Split(new Char[] { ',' });
        if (CVA[CVA.Length - 1] == "Yes")
        {
            string check = "select Install_id from m_FeeInstallment where Install_id='" + Install_id + "' and Del_flag=1;select Install_id from m_FeeInstallment where Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Group_id='" + lblgroupid.Text.Trim() + "'  and Del_flag=0;";
            DataSet ds = cls.fillDataset(check);
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Deletion Prohibited New Installment Defined Based on Current Selection!!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
            }
            else
            {
                string qry = "update m_FeeEntry set del_flag=1,del_dt=GETDATE() where stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Receipt_no='" + Receipt_no + "' and Type='" + Type + "';update m_FeeInstallment set balance_Amount=(cast(balance_Amount as int) + cast('" + Amount + "' as int)),PaymentStatus=0 where Install_id='" + Install_id + "' and Del_flag=0;";
                if (cls.DMLqueries(qry))
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Deleted Successfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                    load_grd();
                    clear();
                    ddlmode.SelectedIndex = 0;
                    btnsave.Text = "Save";
                    string student_details = "SELECT ISNULL(Paid.PaidAmount, 0) AS PaidAmount,ISNULL(Total.TotalAmount, 0) AS TotalAmount,ISNULL(Total.TotalAmount, 0) - ISNULL(Paid.PaidAmount, 0) AS Balance FROM (SELECT SUM(CAST(Amount AS INT)) AS PaidAmount FROM m_FeeEntry WHERE Stud_id = '" + txt_studid.Text.Trim() + "' AND Ayid = '" + lblayid.Text.Trim() + "' AND Chq_status = 'Clear' AND del_flag = 0 and fine_flag=0) AS Paid CROSS JOIN(SELECT SUM(CAST(Amount AS INT)) AS TotalAmount FROM " + Session["feemaster"].ToString() + " WHERE Ayid = '" + lblayid.Text.Trim() + "' AND Group_id = '" + lblgroupid.Text.Trim() + "' AND del_flag = 0 and Gender='" + Session["gender"].ToString() + "' and Category='" + lblcategory.Text.Trim() + "' ) AS Total";

                    DataTable dt = cls.fillDataTable(student_details);
                    if (dt.Rows.Count > 0)
                    {
                        lblpaidfees.Text = dt.Rows[0]["PaidAmount"].ToString();
                        lblbal.Text = dt.Rows[0]["Balance"].ToString();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                }
            }
        }
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
        string Chq_status = ((Label)gvrow.FindControl("Chq_status")).Text.Trim();
        string Receipt_no = ((Label)gvrow.FindControl("Receipt_no")).Text.Trim();
        string Type = ((Label)gvrow.FindControl("Type")).Text.Trim();
        if (Chq_status != "Clear")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Cheque/NEFT Status :" + Chq_status + "!!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            Session["stud_id"] = txt_studid.Text.Trim();
            Session["ayid"] = lblayid.Text.Trim();
            Session["Type"] = Type;
            Session["Receipt_no"] = Receipt_no;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "redirect('FeeReceiptMergeFees.aspx');", true);
        }
    }

    protected void chk_fine_CheckedChanged(object sender, EventArgs e)
    {
        if (!chk_fine.Checked)
        {
            fine_stud_id.Text = lblmodalid.Text.Trim();
            fine_name.Text = lblmodalname.Text.Trim();
            DataTable dt = cls.fillDataTable("select Install_id,Install_no,CONVERT(varchar, Due_date, 103)[Due_date],Install_Amount,balance_Amount,(CASE WHEN GETDATE() > Due_date THEN DATEDIFF(DAY, Due_date, GETDATE()) * 10 ELSE 0 END) [Fine_Amount],(CASE WHEN GETDATE() > Due_date THEN DATEDIFF(DAY, Due_date, GETDATE()) ELSE 0 END) [Days_Past] from m_FeeInstallment where Stud_id='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Group_id='" + lblgroupid.Text.Trim() + "' and Del_flag=0  and Install_id='" + ddl_install.SelectedValue + "'");
            grd_fine.DataSource = dt;
            grd_fine.DataBind();
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('modal_fine');", true);
            }
            else
            {
                chk_fine.Checked = true;
            }

        }
        else
        {
            cls.DMLqueries("update m_FeeInstallment set Fine_flag =0 where Install_id='" + ddl_install.SelectedValue + "' and Del_flag=0");

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

    protected void Remove_Fine_Click(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
        string Install_id = ((Label)gvrow.FindControl("Install_id")).Text.Trim();

        if (cls.DMLqueries("update m_FeeInstallment set Fine_flag =0 where Install_id='" + Install_id + "' and Del_flag=0"))
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Removed Successfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });closeModal('modal_fine');", true);
        }
    }
}
