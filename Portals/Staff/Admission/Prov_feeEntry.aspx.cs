using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_Prov_feeEntry : System.Web.UI.Page
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

                    //string qry = "select distinct form_no,f_name+' '+m_name+' '+l_name as name,case when gender =1 then 'Male' when gender=0 then 'Female' end as gender from d_adm_applicant where del_flag=0 and f_name like '%" + txt_fname.Text.Trim() + "%' and m_name like '%" + txt_mname.Text.Trim() + "%' and l_name like  '%" + txt_lname.Text.Trim() + "%' and acdid='" + Session["Year"] + "';";

                    string qry = "select a.Form_no, a.f_name + ' ' + a.m_name + ' ' + a.l_name as name,case when gender = 1 then 'Male' when gender = 0 then 'Female' end as gender, c.course_name[Course],f.subcourse_name[Subcourse],e.Group_title[Group],e.Group_id[Group ID],g.Acd_year[Year],g.Ayid[AYID] from d_adm_applicant a, adm_applicant_registration b, m_crs_course_tbl c,OLA_FY_adm_CourseSelection d, m_crs_subjectgroup_tbl e,m_crs_subcourse_tbl f, academic g where a.Form_no = b.formno and a.Form_no = d.formno and d.group_id = e.Group_id and e.Subcourse_id = f.subcourse_id and f.course_id = c.course_id and a.ACDID = g.Ayid and a.Del_Flag = 0 and b.del_flag = 0 and c.del_flag = 0 and d.del_flag = 0 and e.del_flag = 0 and f.del_flag = 0 and g.ayid = '" + Session["Year"] + "' and a.f_name like '%" + txt_fname.Text.Trim() + "%' and a.m_name like '%" + txt_mname.Text.Trim() + "%' and a.l_name like  '%" + txt_lname.Text.Trim() + "%'";

                    DataTable dt = cls.fillDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        grd_name.DataSource = dt;
                        grd_name.DataBind();
                        div_grd_name.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Student does not exist', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
                    }
                }
            }
            else
            {
                if (txt_studid.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Enter Form Number.', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 })", true);
                }
                else if (txt_studid.Text.Trim().Length != 5)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Invalid From Number', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 })", true);
                }
                else
                {
                    DataTable dtstud = cls.fillDataTable("select a.f_name + ' ' + a.m_name + ' ' + a.l_name as Name, c.course_name[Course],f.subcourse_name[Subcourse],e.Group_title[Group],e.Group_id[Group ID],g.Acd_year[Year],g.Ayid[AYID] from d_adm_applicant a, adm_applicant_registration b, m_crs_course_tbl c,OLA_FY_adm_CourseSelection d, m_crs_subjectgroup_tbl e,m_crs_subcourse_tbl f, academic g where a.Form_no = b.formno and a.Form_no = d.formno and d.group_id = e.Group_id and e.Subcourse_id = f.subcourse_id and f.course_id = c.course_id and a.ACDID = g.Ayid and a.Form_no = '" + txt_studid.Text + "' and a.Del_Flag = 0 and b.del_flag = 0 and c.del_flag = 0 and d.del_flag = 0 and e.del_flag = 0 and f.del_flag = 0 and g.ayid='" + Session["Year"] + "'");

                    if (dtstud.Rows.Count > 0)
                    {
                        string stud_id = txt_studid.Text.Trim();
                        string name = dtstud.Rows[0]["Name"].ToString();
                        string group_id = dtstud.Rows[0]["Group Id"].ToString();
                        string course = dtstud.Rows[0]["Course"].ToString();
                        string subcourse = dtstud.Rows[0]["Subcourse"].ToString();
                        string year = dtstud.Rows[0]["Year"].ToString();
                        string ayid = dtstud.Rows[0]["AYID"].ToString();
                        string Group_Title = dtstud.Rows[0]["Group"].ToString();


                        //   DataTable dt_category = cls.fillDataTable("select distinct stud_Category,UPPER(stud_Gender) [stud_Gender] from m_std_personaldetails_tbl where stud_id='" + txt_studid.Text.Trim() + "' and del_flag=0");

                        DataTable dt_category = cls.fillDataTable("select category[stud_Category], gender[stud_gender] from d_adm_applicant  where Form_no = '" + txt_studid.Text.Trim() + "' and Del_Flag = 0");

                        if (dt_category.Rows.Count > 0)
                        {
                            string category = dt_category.Rows[0]["stud_Category"].ToString().Trim().ToUpper();
                            string gender = dt_category.Rows[0]["stud_Gender"].ToString().Trim().ToUpper();
                            gender = gender == "0" ? "FEMALE" : (gender == "1" ? "MALE" : gender);


                            string checkin = "select paid_status,receipt_no,struct_name from admProvFees where formno='" + txt_studid.Text + "'and paid_status=1";
                            DataTable dt = cls.fillDataTable(checkin);
                            if (dt.Rows.Count > 0)
                            {
                                lblayid.Text = ayid.ToString();
                                load_grd();
                                
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Provisional Fee already paid', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 })", true);

                                lblname.Text = name;
                                lblgender.Text = gender;
                                lblgroup.Text = Group_Title;
                                lblgroupid.Text = group_id;
                                lblcategory.Text = category;
                                //btnPrint_Click(sender,e);
                            }
                            else
                            {
                                txt_studid.Enabled = false;
                                lblname.Text = name;
                                lblgender.Text = gender;
                                lblgroup.Text = Group_Title;
                                lblgroupid.Text = group_id;
                                lblyear.Text = year.ToString();
                                lblayid.Text = ayid.ToString();
                                lblcategory.Text = category;
                                feepanel.Visible = true;
                                div_grd_name.Visible = false;
                                load_grd();
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Form Number not found', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
                    }
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
        }
    }
    

    protected void btnPrint_Click(object Sender,EventArgs e)
    {
        string printData = "select paid_status,receipt_no,struct_name,formno from admProvFees where formno='" + txt_studid.Text + "'and paid_status=1";
        DataTable dt = cls.fillDataTable(printData);
        if (dt.Rows.Count > 0)
            Session["Prov_studID"] = dt.Rows[0]["formno"].ToString();
        Session["Prov_ayid"] = Session["Year"].ToString();
        Session["Prov_receipt"] = dt.Rows[0]["receipt_no"].ToString();
        Session["Prov_structname"] = dt.Rows[0]["struct_name"].ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "redirect('ProvisionalFeeReceipt.aspx');", true);
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
            string pay_date = "";
            if (txtpaydate.Visible)
            {
                DateTime parsedDate = DateTime.ParseExact(txtpaydate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                pay_date = parsedDate.ToString("yyyy-MM-dd");
            }
           
            string chq_status = "";
            string bankname = "";
            string recpt_chq_dt = "";
            string recpt_chq_no = "";
            string recpt_bank_branch = "";
            string receipt_no = load_recipt_no();
            string recpt_mode = ddlmode.SelectedItem.ToString();
            string amount = txt_amount.Text;
            if (ddlmode.SelectedItem.ToString() != "Cash" && ddlmode.SelectedItem.ToString() != "Online")
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

            if (btnsave.Text == "Save")
            {

                if (receipt_no != "")
                {
                    //qry = "insert into admProvfees values ('" + stud_id + "','" + amount + "','" + ayid + "',Getdate(),'Provisional Admission','" + receipt_no + "','" + recpt_mode + "',NULLIF((CAST('" + recpt_chq_dt + "' AS datetime)),''),NULLIF('" + recpt_chq_no + "',''),NULLIF('" + bankname + "',''),NULLIF('" + recpt_bank_branch + "',''),'" + chq_status + "',NULL,NULL,'" + Session["emp_id"].ToString() + "',GetDate(),Null,0,NULL,0)";
                    qry = "insert into admProvfees values ('" + stud_id + "','" + amount + "','" + ayid + "',Getdate(),'Provisional Admission','NULL','" + recpt_mode + "',NULLIF((CAST('" + recpt_chq_dt + "' AS datetime)),''),NULLIF('" + recpt_chq_no + "',''),NULLIF('" + bankname + "',''),NULLIF('" + recpt_bank_branch + "',''),'" + chq_status + "',NULL,NULL,'" + Session["emp_id"].ToString() + "',GetDate(),Null,0,NULL,0)";

                    if (qry != "")
                    {
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

            }
            else if (btnsave.Text == "Update")
            {
                qry = "update admProvFees set Amount='" + amount + "',Pay_date=(CAST('" + pay_date + "' AS datetime)),Recpt_mode='" + recpt_mode + "',Recpt_Chq_dt=NULLIF((CAST('" + recpt_chq_dt + "' AS datetime)),''),Recpt_Chq_No=NULLIF('" + recpt_chq_no + "',''),Recpt_Bnk_Name=NULLIF('" + bankname + "',''),Recpt_Bnk_Branch=NULLIF('" + recpt_bank_branch + "',''),Chq_status='" + chq_status + "',mod_dt=GETDATE() where formno='" + stud_id + "' and Ayid='" + ayid + "' and Receipt_no='" + hidden_recpt_no.Value + "' and del_flag=0 ;";

                if (qry != "")
                {
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
        ddlmode1.Visible = false;
        txtpaydate1.Visible = false;
    }


    public void load_grd()
    {
        try
        {
            DataTable dt = cls.fillDataTable("select Receipt_no, Chq_status, CAST(Amount as int) [Amount],Recpt_mode,Convert(varchar, Pay_date, 103)[Pay_date] from admProvfees where formno = '" + txt_studid.Text.Trim() + "' and Ayid = '" + lblayid.Text.Trim() + "' and Paid_status=0 and del_flag = 0 group by Receipt_no,Chq_status,Recpt_mode,Pay_date,Amount;");


            if (dt.Rows.Count > 0)
            {
                grdedit.DataSource = dt;
                grdedit.DataBind();
                ddlmode1.Visible = false;
                txtpaydate1.Visible = false;
                //btn.Visible = false;
                // printsection.Visible = false;
                grdedit.Columns[8].Visible = true;
                grdedit.Columns[9].Visible = false;
            }
            else
            {
                grdedit.DataSource = null;
                grdedit.DataBind();
                ddlmode1.Visible = true;
                txtpaydate1.Visible = true;
                grdedit.Columns[9].Visible = true;
                //btn.Visible = true;


                DataTable dt1 = cls.fillDataTable("select Receipt_no, Chq_status, CAST(Amount as int) [Amount],Recpt_mode,Convert(varchar, Pay_date, 103)[Pay_date] from admProvfees where formno = '" + txt_studid.Text.Trim() + "' and Ayid = '" + lblayid.Text.Trim() + "' and Paid_status=1 and del_flag = 0 group by Receipt_no,Chq_status,Recpt_mode,Pay_date,Amount;");

                if (dt1.Rows.Count > 0)
                {
                    feepanel.Visible = true;
                    grdedit.DataSource = dt1;
                    grdedit.DataBind();
                    //clear();
                    ddlmode1.Visible = false;
                    txtpaydate1.Visible = false;
                    grdedit.Columns[8].Visible = false;
                    //btn.Visible = false;
                    //   paysection.Visible = false;
                }
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
            if (ddlmode.SelectedItem.ToString() == "Cheque" || ddlmode.SelectedItem.ToString().Contains("NEFT"))
            {
                details.Visible = true;
                txtpaydate1.Visible = true;
                status.Visible = true;
                branch.Visible = true;
                div_amount.Visible = true;
            }
            else if (ddlmode.SelectedItem.ToString() == "DD")
            {
                details.Visible = true;
                txtpaydate1.Visible = true;
                status.Visible = false;
                branch.Visible = true;
                div_amount.Visible = true;
            }
            else if (ddlmode.SelectedItem.ToString() == "Online")
            {
                details.Visible = false;
                branch.Visible = false;
                status.Visible = false;
                txtpaydate1.Visible = false;
                div_amount.Visible = true;
            }
            else
            {
                details.Visible = false;
                txtpaydate1.Visible = true;
                status.Visible = false;
                div_amount.Visible = true;
            }
        }
    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
        string Receipt_no = load_recipt_no(); ;
        string Amount = ((Label)gvrow.FindControl("Amount")).Text.Trim();
        string Paymentmode = ((Label)gvrow.FindControl("Recpt_mode")).Text.Trim();

        //string qry = "update admProvfees set del_flag=1,del_dt=getdate() where receipt_no='" + Receipt_no + "' and amount='" + Amount + "' and formno='" + txt_studid.Text.Trim() + "' and ayid='" + Session["Year"] + "'";
        string qry = "update admProvFees set paid_status=1, receipt_no='" + Receipt_no + "' where formno='" + txt_studid.Text.Trim() + "' and  Recpt_mode='" + Paymentmode + "' and ayid='" + lblayid.Text.Trim() + "' and amount='" + Amount + "'";

        if (cls.TranDMLqueries(qry))
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Paid Successfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
            load_grd();
            clear();
            ddlmode1.Visible = false;
            txtpaydate1.Visible = false;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
    }

    protected void txt_amount_TextChanged(object sender, EventArgs e)
    {
        if (txt_amount.Text.Trim() != "")
        {
            int amount = Convert.ToInt32(txt_amount.Text.Trim());
            btn.Visible = true;
            if (amount <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Amount Greater than 0 !!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0, timeout: 100 });", true);
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
        else if (txtpaydate.Text == "" && txtpaydate.Visible)
        {
            msg = "Select payment date";
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
        div_amount.Visible = false;
        txt_amount.Text = "";
    }


    public string load_recipt_no()
    {
        string studId = txt_studid.Text.Trim();
        string year = lblyear.Text.Trim().Split('-')[0];
        string prefix = studId + year;
        int newIncrement = 1;

        string qry = "SELECT MAX(RIGHT(Receipt_No, 2)) FROM admProvfees WHERE Receipt_No LIKE '" + prefix + "%'";
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
        string Pay_date = ((TextBox)gvrow.FindControl("Pay_date")).Text.Trim();
        string Receipt_no = ((Label)gvrow.FindControl("Receipt_no")).Text.Trim();
        string Amount = ((Label)gvrow.FindControl("Amount")).Text.Trim();
        hidden_recpt_no.Value = Receipt_no;
        string check = "select Receipt_no from admProvfees where Receipt_no='" + Receipt_no + "' and Del_flag=1;select Receipt_no from admProvfees where formno='" + txt_studid.Text.Trim() + "' and Ayid='" + lblayid.Text.Trim() + "' and Receipt_no='" + Receipt_no + "' and Del_flag=0;";
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

            txtpaydate.Text = Pay_date;

            DataSet ds = cls.fillDataset("select distinct formno,Receipt_no,Pay_date,Recpt_mode,Recpt_Bnk_Branch,Recpt_Bnk_Name,Recpt_Chq_dt,Recpt_Chq_No,Chq_status from admProvFees where  formno = '" + txt_studid.Text.Trim() + "' and Ayid = '" + lblayid.Text.Trim() + "' and Receipt_no = '" + Receipt_no + "';");

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
            else if (ds.Tables["Details"].Rows[0]["Recpt_mode"].ToString() == "Online")
            {
                txtbnkname.Text = ds.Tables["Details"].Rows[0]["Recpt_Bnk_Name"].ToString();

                txtchdate.Text = ds.Tables["Details"].Rows[0]["Recpt_Chq_dt"] != DBNull.Value ? Convert.ToDateTime(ds.Tables["Details"].Rows[0]["Recpt_Chq_dt"]).ToString("dd/MM/yyyy").Replace("-", "/") : "";
                txtchno.Text = ds.Tables["Details"].Rows[0]["Recpt_Chq_No"].ToString();
            }
            txt_amount.Text = Amount;
            txt_amount_TextChanged(sender, e);
            ddlmode1.Visible = true;
            txtpaydate1.Visible = true;
            btn.Visible = true;
        }
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(sender as Control).Parent.Parent;
        string Receipt_no = ((Label)gvrow.FindControl("Receipt_no")).Text.Trim();
        string Amount = ((Label)gvrow.FindControl("Amount")).Text.Trim();

        string confirmValue = Request.Form["confirm_value"];
        string[] CVA = confirmValue.Split(new Char[] { ',' });
        if (CVA[CVA.Length - 1] == "Yes")
        {
            string qry = "update admProvfees set del_flag=1,del_dt=getdate() where receipt_no='" + Receipt_no + "' and amount='" + Amount + "' and formno='" + txt_studid.Text.Trim() + "' and ayid='" + Session["Year"] + "'";


            if (cls.DMLqueries(qry))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Deleted Successfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                load_grd();
                clear();
            }
        }
    }

}