using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Employee_leaveapplicationForm : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Session["srno"] = (string)HttpContext.Current.Session["srno"];
                if (Convert.ToString(Session["emp_id"]) == "")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {

                    //cls.chkPassword();

                    loadApplication();
                    HttpContext.Current.Response.Write("<script>window.print();</script>");
                }

            }
            catch (Exception ex)
            {
                string Error = ex.ToString();
                Response.Redirect("Login.aspx");
            }
        }
    }

    public void loadApplication()
    {
        string str = "select NAME+' '+FATHER+' '+SURNAME as name,emp_dept_id,current_designation,current_department_name from EmployeePersonal where emp_id='" + Session["emp_id"].ToString() + "'";

        DataTable ds = cls.fillDataTable(str);
        lbl_name.Text = ds.Rows[0]["name"].ToString();
        lbl_designation.Text = ds.Rows[0]["current_designation"].ToString();
        lbl_department.Text = ds.Rows[0]["current_department_name"].ToString();

        string str1 = "select * from Emp_Leave_Form  where  emp_id='" + Session["emp_id"].ToString() + "'";   //
        DataTable ds1 = new DataTable();
        ds1 = cls.fillDataTable(str1);
        if (ds1.Rows.Count > 0)
        {
            lbl_leavetype.Text = ds1.Rows[0]["leaveType"].ToString();
            lbl_leavedays.Text = ds1.Rows[0]["leaveDays"].ToString();
            lbl_fromdate.Text = Convert.ToDateTime(ds1.Rows[0]["leaveF"].ToString()).ToString("dd / MM / yyyy");
            lbl_todate.Text = Convert.ToDateTime(ds1.Rows[0]["leaveT"].ToString()).ToString("dd / MM / yyyy");
            lbl_reason.Text = ds1.Rows[0]["resleave"].ToString();
            lbl_inform_to_superior.Text = ds1.Rows[0]["inform_to_superior"].ToString();
            lbl_adjustwith.Text = ds1.Rows[0]["locumName"].ToString();
            lbl_leavedaystype.Text = ds1.Rows[0]["leave_days_type"].ToString();
            lbl_no_leavedaystype.Text = ds1.Rows[0]["leave_days_type_no"].ToString();
            lbl_details.Text = ds1.Rows[0]["details"].ToString();
            lbl_alt_arr.Text = ds1.Rows[0]["locumName"].ToString();

            if (lbl_alt_arr.Text != "")
            {
                lbl_alt_arr.Text = "YES";
            }
            else
            {
                lbl_alt_arr.Text = "NO";
            }


            if (lbl_leavetype.Text == "COMP")
            {

                lbl_extraduty.Text = Convert.ToDateTime(ds1.Rows[0]["leaveF"].ToString()).ToString("dd / MM / yyyy");
            }
            else
            {
                lbl_extraduty.Text = "";
            }


            if (lbl_leavetype.Text == "HQ")
            {

                lbl_HQleave.Text = "YES";
                lbl_leaveaddress.Text = ds1.Rows[0]["leaveadd"].ToString();
                lbl_contactno.Text = ds1.Rows[0]["contactno"].ToString();
            }
            else
            {
                lbl_HQleave.Text = "NO";
            }

            string hod_id = ds1.Rows[0]["HOD_ID"].ToString();
            string principal_id = ds1.Rows[0]["PRINCIPAL_ID"].ToString();

            string qry_hod = "select NAME+' '+FATHER+' '+SURNAME as name,emp_dept_id,current_designation,current_department_name from EmployeePersonal where emp_id='" + hod_id.Trim() + "'";
            DataTable ds2 = cls.fillDataTable(qry_hod);

            if (ds2.Rows.Count > 0)
            {
                string hod_name = ds2.Rows[0]["name"].ToString();
                lbl_HOD.Text = "(" + hod_name + ")";
            }

            string principal_name = "select NAME+' '+FATHER+' '+SURNAME as name,emp_dept_id,current_designation,current_department_name from EmployeePersonal where emp_id='" + principal_id.Trim() + "'";
            DataTable ds3 = cls.fillDataTable(principal_name);
            lbl_principal.Text = ds3.Rows[0]["name"].ToString();
        }
    }
}