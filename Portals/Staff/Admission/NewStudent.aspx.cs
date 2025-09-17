using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_Master_NewStudent : System.Web.UI.Page
{
    QueryClass qryCls = new QueryClass();
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Convert.ToString(Session["Emp_id"]) == "")
                {
                    Response.Redirect("~/Portals/Staff/Login.aspx");

                }
                else
                {
                    qryCls.getayid(ddlyear);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
        }
    }

    protected void lnksearch_Click(object sender, EventArgs e)
    {
        if (ddlyear.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Select Year.', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 })", true);
        }
        else if (txt_formid.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Enter Form No.', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 })", true);
        }
        else if (txt_formid.Text.Trim().Length != 8)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Invalid Form No', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 })", true);
        }
        else
        {
            string formid = txt_formid.Text.Trim().Substring(0, 5);
            string grp_id = "GRP" + txt_formid.Text.Trim().Substring(txt_formid.Text.Trim().Length - 3);
            string ayd = ddlyear.SelectedValue.Trim();
            hidden_form_no.Value = formid;
            hidden_grp_id.Value = grp_id;
            cls.SetdropdownForMember1(ddlfaculty, "m_crs_faculty", "faculty_name", "faculty_Id", "Del_Flag <>1 And faculty_name <> ''");
            DataTable dt_chk = cls.fillDataTable("select * from  dbo.OLA_FY_adm_CourseSelection where formno = '" + formid + "' and group_id = '" + grp_id + "'");
            if (dt_chk.Rows.Count > 0)
            {
                DataTable dt_date = cls.fillDataTable("SELECT DISTINCT app.F_name, app.M_name, app.L_Name, app.Gender, app.Category, app.Stud_Class, app.stud_id, CONVERT(varchar, app.dob,106) AS dob, ss.subcourse_name, g.Group_title, g.Group_id, ss.subcourse_id, c.course_id, f.faculty_id, c.course_name, f.faculty_name FROM d_adm_applicant app JOIN dbo.m_crs_subjectgroup_tbl g ON g.Group_id = '" + grp_id + "' JOIN dbo.m_crs_subcourse_tbl ss ON ss.subcourse_id = g.Subcourse_id JOIN dbo.m_crs_course_tbl c ON c.course_id = ss.course_id JOIN dbo.m_crs_faculty f ON f.faculty_id = c.faculty_id WHERE app.ACDID = '" + ayd + "' AND app.form_no = '" + formid + "' AND app.del_flag <> '1';");
                if (dt_date.Rows.Count > 0)
                {
                    txt_fname.Text = dt_date.Rows[0]["F_name"].ToString();
                    txt_mname.Text = dt_date.Rows[0]["M_name"].ToString();
                    txt_lname.Text = dt_date.Rows[0]["L_Name"].ToString();
                    txt_birthdate.Text = dt_date.Rows[0]["dob"].ToString();
                    hidden_gender.Value = dt_date.Rows[0]["Gender"].ToString();
                    hidden_category.Value = dt_date.Rows[0]["Category"].ToString();
                    ddlfaculty.SelectedValue = dt_date.Rows[0]["faculty_id"].ToString();
                    cls.SetdropdownForMember1(ddlcourse, "m_crs_course_tbl", "course_name", "course_Id", "Del_Flag <>1 And course_name <> ''");
                    ddlcourse.SelectedValue = dt_date.Rows[0]["course_id"].ToString();
                    cls.SetdropdownForMember1(ddlsubcourse, "m_crs_subcourse_tbl", "subcourse_name", "subcourse_id", "Del_Flag <>1 And subcourse_name <> ''");
                    ddlsubcourse.SelectedValue = dt_date.Rows[0]["subcourse_id"].ToString();
                    cls.SetdropdownForMember1(ddlgroup, "m_crs_subjectgroup_tbl", "Group_title", "Group_id", "Del_Flag <>1 And Group_title <> ''");
                    ddlgroup.SelectedValue = dt_date.Rows[0]["group_id"].ToString();
                    disable_elm();
                    if (dt_chk.Rows[0]["stud_id"].ToString() != "")
                    {
                        lblstudid.Text = dt_chk.Rows[0]["stud_id"].ToString();
                        lblstudid.Visible = true;
                        laod_grd(dt_chk.Rows[0]["stud_id"].ToString());
                        //btn_confirm.Enabled = false;
                        btn_confirm.Attributes["disabled"] = "disabled";
                    }
                }
                else { ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true); }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Form No Npot Found', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 })", true);
            }
        }
    }

    public void disable_elm()
    {
        txt_fname.Enabled = false;
        txt_mname.Enabled = false;
        txt_lname.Enabled = false;
        txt_birthdate.Enabled = false;
        ddlfaculty.Enabled = false;
        ddlcourse.Enabled = false;
        ddlsubcourse.Enabled = false;
        ddlgroup.Enabled = false;
        ddlyear.Enabled = false;
        txt_formid.Enabled = false;
    }

    protected void btn_confirm_Click(object sender, EventArgs e)
    {
        DataTable dt = cls.fillDataTable("select * from admProvFees where formno='" + hidden_form_no.Value + "' and Ayid='" + ddlyear.SelectedValue + "' and paid_status=1 and del_flag=0");
        if (dt.Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Provisional Fee Not Paid !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            string qry = "select MAX(FYID)as FYID from m_financial ";
            DataTable dt_fyid = cls.fillDataTable(qry);
            string fyid = dt_fyid.Rows[0]["FYID"].ToString();

            SqlDataReader resultset = cls.RetriveQuery("Exec proc_autoid_LMS_FY '" + hidden_form_no.Value + "','" + fyid + "','" + ddlyear.SelectedValue + "','" + hidden_grp_id.Value + "'");
            if (resultset.HasRows == true)
            {
                while (resultset.Read())
                {
                    lblstudid.Text = resultset[0].ToString();
                }

                if (lblstudid.Text.Trim() != "")
                {
                    lblstudid.Visible = true;
                    if (!insert_fees(lblstudid.Text.Trim())) { ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Fee Transfer Failed !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true); }
                    laod_grd(lblstudid.Text.Trim());
                    btn_confirm.Enabled = false;
                    cls.DMLqueries("UPDATE m_std_studentacademic_tbl SET Roll_no = (SELECT ISNULL(MAX(Roll_no), 0) + 1 FROM m_std_studentacademic_tbl WITH (UPDLOCK, SERIALIZABLE) WHERE ayid = '" + ddlyear.SelectedValue + "' AND group_id = '" + hidden_grp_id.Value + "' AND del_flag = 0) WHERE stud_id = '" + lblstudid.Text.Trim() + "' AND ayid = '" + ddlyear.SelectedValue + "' AND group_id = '" + hidden_grp_id.Value + "' AND del_flag = 0;");// Roll No Generation
                }
                else { ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true); }
            }
            else { ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true); }
        }
    }

    public void laod_grd(string stud_id)
    {
        string fee_master = "";
        string category = hidden_category.Value.Trim();
        string gender = hidden_gender.Value.Trim();
        gender = gender == "0" ? "FEMALE" : (gender == "1" ? "MALE" : gender);
        if (category == "OPEN")
        {
            fee_master = "m_FeeMaster";
            gender = "NON";
        }
        else
        {
            fee_master = "m_FeeMaster_category";
        }
        string qry = "SELECT '" + stud_id + "' [StudId],'" + (txt_fname.Text + " " + txt_mname.Text + " " + txt_lname.Text) + "'[StudentName],'" + ddlgroup.SelectedItem.Text + "'[GroupTitle],ISNULL(Paid.PaidAmount, 0) AS PaidAmount,ISNULL(Total.TotalAmount, 0) AS TotalAmount,ISNULL(Total.TotalAmount, 0) - ISNULL(Paid.PaidAmount, 0) AS Balance FROM (SELECT SUM(CAST(Amount AS INT)) AS PaidAmount FROM m_FeeEntry WHERE Stud_id = '" + stud_id + "' AND Ayid = '" + ddlyear.SelectedValue + "' AND Chq_status = 'Clear' AND del_flag = 0 and fine_flag=0) AS Paid CROSS JOIN(SELECT SUM(CAST(Amount AS INT)) AS TotalAmount FROM " + fee_master + " WHERE Ayid = '" + ddlyear.SelectedValue + "' AND Group_id = '" + hidden_grp_id.Value + "' AND del_flag = 0 and Gender='" + gender + "' and Category='" + category + "' ) AS Total";
        DataTable dt = cls.fillDataTable(qry);
        if (dt.Rows.Count > 0)
        {
            grid_studentadm.DataSource = dt;
            grid_studentadm.DataBind();
        }
    }
    public bool insert_fees(string stud_id)
    {

        string receiptNo = load_recipt_no(stud_id);
        if (receiptNo != "")
        {
            string fee_master = "";
            string category = hidden_category.Value.Trim();
            string gender = hidden_gender.Value.Trim();
            gender = gender == "0" ? "FEMALE" : (gender == "1" ? "MALE" : gender);
            if (category == "OPEN")
            {
                fee_master = "m_FeeMaster";
                gender = "NON";
            }
            else
            {
                fee_master = "m_FeeMaster_category";
            }
            string qry_mst = "SELECT * FROM " + fee_master + " WHERE Ayid = '" + ddlyear.SelectedValue + "' AND Group_id = '" + hidden_grp_id.Value + "' AND del_flag = 0 and Gender='" + gender + "' and Category='" + category + "' and Struct_type like 'OTHER%'";
            DataTable dt_master = cls.fillDataTable(qry_mst);
            if (dt_master.Rows.Count > 0)
            {
                cls.DMLqueries("insert into m_FeeEntry(Stud_id, Amount, Ayid, Pay_date, Struct_id,Install_id,Struct_name, Recpt_mode, Receipt_no, Recpt_Chq_dt, Recpt_Chq_No, Recpt_Bnk_Name, Recpt_Bnk_Branch, Chq_status, type, user_id)  select top(1) '" + stud_id + "', Amount, Ayid, Pay_date, '" + dt_master.Rows[0]["Struct_id"].ToString() + "','','" + dt_master.Rows[0]["Struct_name"].ToString() + "', (case Recpt_mode when 'Online' then 'Online Pay' else Recpt_mode end), '" + receiptNo + "', Recpt_Chq_dt, Recpt_Chq_No, Recpt_Bnk_Name, Recpt_Bnk_Branch, Chq_status, '" + dt_master.Rows[0]["Struct_type"].ToString() + "', '" + Session["emp_id"].ToString() + "' from admProvFees where formno='" + hidden_form_no.Value + "' and Ayid='" + ddlyear.SelectedValue + "' and del_flag=0");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Fess Not Defined !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                return false;
            }
        }
        else
        {
            return false;
        }
        return true;
    }

    public string load_recipt_no(string studId)
    {
        string base_year = ddlyear.SelectedItem.Text.Trim().Split('/')[2];
        string year = base_year.Split('-')[0];
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


    protected void lnk_select_Click(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)(sender as System.Web.UI.Control).Parent.Parent;
        string stud_id = ((Label)gvrow.FindControl("lbl_stud_id")).Text.Trim();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "window.location.href='" + ResolveUrl("~/Portals/Staff/Fee/FeeEntry_New.aspx") + "?stud_id=" + stud_id + "';", true);
    }
}
