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


public partial class EditProfile : System.Web.UI.Page
{
    Class1 obj = new Class1();
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection("Data Source=103.31.144.152;Initial Catalog=VIVAIMR_Test;User Id=sa; password=passwd@12");
        try
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["Emp_id"]) == "")
                {
                    Response.Redirect("~/Portals/Staff/Login.aspx");
                }
                categorydropdown();
                data_on_page_load();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Response.Redirect("~/Portals/Staff/Login.aspx");
            
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
    }
    public void data_on_page_load()
    {
        try
        {

            string query = "select *,CONVERT(VARCHAR,emp_dob ,103) as date ,CONVERT(VARCHAR,emp_doj ,103) as date_doj from m_employee_personal where emp_id = '" + Session["emp_id"].ToString() + "'";
            obj.fillDataTable(query);
            DataTable t1 = new DataTable();
            t1 = obj.fillDataTable(query);
            txt_title.Text = t1.Rows[0]["emp_title"].ToString();
            txt_LName.Text = t1.Rows[0]["emp_lname"].ToString().ToLower();
            txt_FName.Text = t1.Rows[0]["emp_fname"].ToString().ToLower();
            txt_MName.Text = t1.Rows[0]["emp_mname"].ToString().ToLower();
            txt_MotherName.Text = t1.Rows[0]["emp_mother_name"].ToString().ToLower();
            txt_dob.Text = t1.Rows[0]["date"].ToString();
            txt_add1.Text = t1.Rows[0]["emp_address_curr"].ToString().ToLower();
            ddl_state.SelectedValue = t1.Rows[0]["emp_state_curr"].ToString();
            txt_city.Text = t1.Rows[0]["emp_state_curr"].ToString().ToLower();
            txt_pin.Text = t1.Rows[0]["emp_pincode_curr"].ToString().ToLower();
            txt_padd1.Text = t1.Rows[0]["emp_address_per"].ToString().ToLower();
            ddl_pstate.SelectedValue = t1.Rows[0]["emp_state_per"].ToString();
            txt_pcity.Text = t1.Rows[0]["emp_state_per"].ToString().ToLower();
            txt_ppin.Text = t1.Rows[0]["emp_pincode_per"].ToString();

            txt_doj.Text = t1.Rows[0]["date_doj"].ToString();

            ddl_category.SelectedValue = t1.Rows[0]["emp_category"].ToString();
            //load department data
            string query1 = "select emp_dept_id,emp_des_id from employee_department_des where emp_id='" + Session["emp_id"].ToString() + "'";
            obj.fillDataTable(query1);
            DataTable t2 = new DataTable();
            t2 = obj.fillDataTable(query1);
            ddl_department.SelectedValue = t2.Rows[0]["emp_dept_id"].ToString();

            ddl_designation.SelectedValue = t2.Rows[0]["emp_des_id"].ToString();
            string query3 = "SELECT DISTINCT child FROM State_Category_details where parent = '" + t1.Rows[0]["emp_category"].ToString() + "'";
            obj.fillDataTable(query3);
            DataTable dt = new DataTable();
            dt = obj.fillDataTable(query3);
            ddl_caste.DataTextField = dt.Columns["child"].ToString();
            ddl_caste.DataValueField = dt.Columns["child"].ToString();
            ddl_caste.DataSource = dt;
            ddl_caste.DataBind();
            ddl_caste.Items.Insert(0, new ListItem("--Select--", "na"));
            string cst = "";
            cst= t1.Rows[0]["emp_cast"].ToString();
            ddl_caste.SelectedValue= ddl_caste.Items.FindByText(cst).Text;

            ddl_religion.Text = t1.Rows[0]["emp_religion"].ToString();
            txt_mobile1.Text = t1.Rows[0]["emp_mobile1"].ToString();
            txt_mobile2.Text = t1.Rows[0]["emp_mobile2"].ToString();
            txt_email.Text = t1.Rows[0]["emp_email"].ToString();
            ddl_bloodg.Text = t1.Rows[0]["emp_blood_group"].ToString();
            txt_pan.Text = t1.Rows[0]["emp_pan_no"].ToString();
            txt_aadhar.Text = t1.Rows[0]["emp_aadhar_no"].ToString();

            string gen = t1.Rows[0]["emp_gender"].ToString();
            if (gen == "True")
            {
                foreach (ListItem item in rad_gender.Items)
                {
                    if (item.Text.Contains("Male"))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (ListItem item in rad_gender.Items)
                {
                    if (item.Text.Contains("Female"))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            string marital = t1.Rows[0]["emp_maritial_status"].ToString();
            if (marital == "True")
            {
                foreach (ListItem item in rad_marital.Items)
                {
                    if (item.Text.Contains("Married"))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (ListItem item in rad_marital.Items)
                {
                    if (item.Text.Contains("Unmarried"))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        }
    }
    protected void categorydropdown()
    {
        try
        {
            string query4 = "SELECT DISTINCT parent FROM State_Category_details where main = 'state'";
            obj.fillDataset(query4);
            DataSet ds = new DataSet();
            ds = obj.fillDataset(query4);
            ddl_state.DataTextField = ds.Tables[0].Columns["parent"].ToString();
            ddl_state.DataValueField = ds.Tables[0].Columns["parent"].ToString();
            ddl_state.DataSource = ds.Tables[0];
            ddl_state.DataBind();
            ddl_state.Items.Insert(0, new ListItem("--Select--", "na"));

            //permanent state data retrive

            string query5 = "SELECT DISTINCT parent FROM State_Category_details where main = 'state' and del_flag=0";
            obj.fillDataset(query5);
            DataSet ds1 = new DataSet();
            ds1 = obj.fillDataset(query5);
            ddl_pstate.DataTextField = ds1.Tables[0].Columns["parent"].ToString();
            ddl_pstate.DataValueField = ds1.Tables[0].Columns["parent"].ToString();
            ddl_pstate.DataSource = ds1.Tables[0];
            ddl_pstate.DataBind();
            ddl_pstate.Items.Insert(0, new ListItem("--Select--", "na"));

            //Category data retrive
            string query6 = "SELECT DISTINCT parent FROM State_Category_details where main = 'Reserved Category' and del_flag=0";
            obj.fillDataset(query6);
            DataSet ds2 = new DataSet();
            ds2 = obj.fillDataset(query6);
            ddl_category.DataTextField = ds2.Tables[0].Columns["parent"].ToString();
            ddl_category.DataValueField = ds2.Tables[0].Columns["parent"].ToString();
            ddl_category.DataSource = ds2.Tables[0];
            ddl_category.DataBind();
            ddl_category.Items.Insert(0, new ListItem("--Select--", "na"));

            //Religion data retrive
            string query7 = "select * from State_category_details WHERE MAIN='RELIGION'  and del_flag=0";
            DataSet ds3 = new DataSet();
            ds3 = obj.fillDataset(query7);
            ddl_religion.DataTextField = ds3.Tables[0].Columns["parent"].ToString();
            ddl_religion.DataValueField = ds3.Tables[0].Columns["parent"].ToString();
            ddl_religion.DataSource = ds3.Tables[0];
            ddl_religion.DataBind();
            ddl_religion.Items.Insert(0, new ListItem("--Select--", "na"));

            //Department data retrive
            string query8 = "select dept_id,Department_name from m_department";
            obj.fillDataset(query8);
            
            DataSet ds4 = new DataSet();
            ds4 = obj.fillDataset(query8);
            ddl_department.DataTextField = ds4.Tables[0].Columns["Department_name"].ToString();
            ddl_department.DataValueField = ds4.Tables[0].Columns["dept_id"].ToString();
            ddl_department.DataSource = ds4.Tables[0];
            ddl_department.DataBind();
            ddl_department.Items.Insert(0, new ListItem("--Select--", "na"));


            //Designation data retrive
            string query9 = "select designation_id,Designation_Title from m_designation  where del_flag=0";
            obj.fillDataset(query9);
            DataSet ds5 = new DataSet();
            ds5 = obj.fillDataset(query9);
            ddl_designation.DataTextField = ds5.Tables[0].Columns["Designation_Title"].ToString();
            ddl_designation.DataValueField = ds5.Tables[0].Columns["designation_id"].ToString();
            ddl_designation.DataSource = ds5.Tables[0];
            ddl_designation.DataBind();
            ddl_designation.Items.Insert(0, new ListItem("--Select--", "na"));
            string query11 = "select emp_dept_id,emp_des_id from employee_department_des where emp_id='" + Session["emp_id"].ToString() + "'";
            obj.fillDataset(query9);
            DataSet dsempdep_des = new DataSet();
            dsempdep_des = obj.fillDataset(query9);
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_FName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter First Name.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_FName.Focus();
            }
            else if (txt_MName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Middle Name.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_MName.Focus();
            }
            else if (txt_MotherName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Mother Name.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_MotherName.Focus();

            }
            else if (txt_dob.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Date of Birth.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_dob.Focus();
            }
            else if (txt_email.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Email ID', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_email.Focus();

            }
            else if (rad_gender.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Check Gender.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                rad_gender.Focus();

            }
            else if (rad_marital.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Check Marital status.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                rad_marital.Focus();

            }
            else if (txt_doj.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select Date of joining.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_doj.Focus();
            }
            else if (txt_mobile2.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Mobile No.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_mobile2.Focus();
            }
            else if (txt_mobile1.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Mobile No.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_mobile1.Focus();
            }
            else if (ddl_department.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select Department', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                ddl_department.Focus();

            }
            else if (ddl_designation.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select Designation.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                ddl_designation.Focus();

            }
            else if (txt_aadhar.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Aadhaar No..', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_aadhar.Focus();

            }
            else if (txt_pan.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter pan no..', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_pan.Focus();

            }
           
            else if (txt_add1.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Address.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_add1.Focus();

            }
            else if (ddl_state.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select State.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                ddl_state.Focus();

            }
            else if (txt_city.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter City.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_city.Focus();
            }
            else if (txt_pin.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Pin code.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                txt_pin.Focus();
            }
           
            else
            {
                string mail = txt_email.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                if (mail.Contains("@") && mail.Contains("."))
                {

                }
                else
                {
                    bool mail2 = regex.IsMatch(mail);
                    if (!mail2)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Invalid Email', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                        return;
                    }
                }
                SqlCommand cmd1 = new SqlCommand("update m_employee_personal set emp_lname=@LName, emp_title=@title,emp_fname=@fname,emp_mname=@mname, emp_mother_name=@mothername, emp_dob=CONVERT(datetime,@emp_dob,105),               emp_gender=@emp_gender, emp_maritial_status=@emp_maritial_status, emp_address_curr=@emp_address_curr, emp_state_curr=@emp_state_curr, emp_pincode_curr=@emp_pincode_curr,     emp_address_per=@emp_address_per, emp_state_per=@emp_state_per, emp_pincode_per=@emp_pincode_per, emp_doj=CONVERT(datetime,@emp_doj,105), emp_category=@emp_category, emp_cast=@emp_cast, emp_religion=@emp_religion, emp_mobile1=@emp_mobile1, emp_mobile2=@emp_mobile2, emp_email=@emp_email, emp_blood_group=@emp_blood_group, emp_pan_no=@emp_pan_no, emp_aadhar_no=@emp_aadhar_no  where emp_id = '" + Session["emp_id"].ToString() + "'", con);

                SqlParameter[] param = new SqlParameter[25];
                param[0] = new SqlParameter("@LName", txt_LName.Text.Trim());
                cmd1.Parameters.Add(param[0]);
                param[1] = new SqlParameter("@title", txt_title.Text);
                cmd1.Parameters.Add(param[1]);
                param[2] = new SqlParameter("@fname", txt_FName.Text.Trim());
                cmd1.Parameters.Add(param[2]);
                param[3] = new SqlParameter("@mname", txt_MName.Text.Trim());
                cmd1.Parameters.Add(param[3]);
                param[4] = new SqlParameter("@mothername", txt_MotherName.Text.Trim());
                cmd1.Parameters.Add(param[4]);
                param[5] = new SqlParameter("@emp_dob", txt_dob.Text);
                cmd1.Parameters.Add(param[5]);
                param[6] = new SqlParameter("@emp_gender", rad_gender.Text);
                cmd1.Parameters.Add(param[6]);
                param[7] = new SqlParameter("@emp_maritial_status", rad_marital.Text);
                cmd1.Parameters.Add(param[7]);
                param[8] = new SqlParameter("@emp_address_curr", txt_add1.Text.Trim());
                cmd1.Parameters.Add(param[8]);
                param[10] = new SqlParameter("@emp_state_curr", ddl_state.Text);
                cmd1.Parameters.Add(param[10]);
                param[11] = new SqlParameter("@emp_pincode_curr", txt_pin.Text.Trim());
                cmd1.Parameters.Add(param[11]);
                param[12] = new SqlParameter("@emp_address_per", txt_padd1.Text.Trim());
                cmd1.Parameters.Add(param[12]);
                param[13] = new SqlParameter("@emp_state_per", ddl_pstate.Text.Trim());
                cmd1.Parameters.Add(param[13]);
                param[14] = new SqlParameter("@emp_pincode_per", txt_ppin.Text.Trim());
                cmd1.Parameters.Add(param[14]);
                param[15] = new SqlParameter("@emp_doj", txt_doj.Text.Trim());
                cmd1.Parameters.Add(param[15]);
                param[16] = new SqlParameter("@emp_category", ddl_category.Text);
                cmd1.Parameters.Add(param[16]);
                param[17] = new SqlParameter("@emp_cast", ddl_caste.Text);
                cmd1.Parameters.Add(param[17]);
                param[18] = new SqlParameter("@emp_religion", ddl_religion.Text);
                cmd1.Parameters.Add(param[18]);
                param[19] = new SqlParameter("@emp_mobile1", txt_mobile1.Text.Trim());
                cmd1.Parameters.Add(param[19]);
                param[20] = new SqlParameter("@emp_mobile2", txt_mobile2.Text.Trim());
                cmd1.Parameters.Add(param[20]);
                param[21] = new SqlParameter("@emp_email", txt_email.Text.Trim());
                cmd1.Parameters.Add(param[21]);
                param[22] = new SqlParameter("@emp_blood_group", ddl_bloodg.Text);
                cmd1.Parameters.Add(param[22]);
                param[23] = new SqlParameter("@emp_pan_no", txt_pan.Text.Trim());
                cmd1.Parameters.Add(param[23]);
                param[24] = new SqlParameter("@emp_aadhar_no", txt_aadhar.Text.Trim());
                cmd1.Parameters.Add(param[24]);
                string update2 = "update employee_department_des set emp_dept_id='" + ddl_department.SelectedValue + "',emp_des_id='" + ddl_designation.SelectedValue + " ' where emp_id='" + Session["emp_id"].ToString() + "'";
                obj.DMLqueries(update2);
                con.Open();
                int check = cmd1.ExecuteNonQuery();
                con.Close();
                data_on_page_load();
                chk_same.Checked = false;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Updated Successfully', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Updated Successfully.','success')", true);
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('"+d.Message+"','danger')", true);
            
        }
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_same.Checked)
            {
                txt_padd1.Text = txt_add1.Text;
                ddl_pstate.Text = ddl_state.Text;
                txt_pcity.Text = txt_city.Text;
                txt_ppin.Text = txt_pin.Text;
            }
            else
            {
                txt_padd1.Text = "";
                //ddl_pstate.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddl_pstate.SelectedIndex = 0;
                txt_pcity.Text = "";
                txt_ppin.Text = "";
            }
        }
        catch (Exception d) 
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);        
        }
    }

    protected void ddl_category_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string query11 = "SELECT DISTINCT child FROM State_Category_details where parent = '" + ddl_category.SelectedValue + "'";
            obj.fillDataTable(query11);
            DataTable dt = new DataTable();
            dt = obj.fillDataTable(query11);
            ddl_caste.DataTextField = dt.Columns["child"].ToString();
            ddl_caste.DataValueField = dt.Columns["child"].ToString();
            ddl_caste.DataSource = dt;
            ddl_caste.DataBind();
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        }
    }
    protected void ddl_department_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

}