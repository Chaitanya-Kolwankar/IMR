using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Class1 c1 = new Class1();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clearSession();
            //string ip = c1.getClientIp();
        }
    }

    // WebReference.hm_android_news a = new WebReference.hm_android_news();

    public void clearSession()
    {
        Session["emp_id"] = "";
        Session["NAME"] = "";
        Session["FATHER"] = "";
        Session["SURNAME"] = "";
        Session["DOB"] = "";
        Session["DOJ"] = "";
        Session["BLOOD_GROUP"] = "";
        Session["GENDER"] = "";
        Session["CASTE"] = "";
        Session["MOBILE1"] = "";
        Session["EMAIL_ADDRESS"] = "";
        Session["CURRENT_ADDRESS"] = "";
        Session["CURRENT_DEPARTMENT_NAME"] = "";
        Session["MARITIAL_STATUS"] = "";
        Session["PHOTO"] = "";
        Session["form_name"] = "";
        Session["group_ids"] = "";
        Session["CATEGORY"] = "";
        Session["EMAIL_ADDRESS"] = "";
        Session["username"] = "";
        Session["password"] = "";
        Session["MOTHER"] = "";
        Session["MOBILE2"] = "";


        //System.Web.Security.FormsAuthentication.SignOut();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();
        //clearSession["MOTHER"].ToString();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // ds = a.checkLogin(txtUserName.Text, txtPassword.Text);
        ds = c1.checkLogin(txtUserName.Text, txtPassword.Text);
        if (ds.Tables[1].Rows[0]["msg"].ToString() == "")
        {
            if (ds.Tables.Count != 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    string qry = "Select role_name from web_tp_roletype where role_id in (select role_id from web_tp_login where emp_id='" + txtUserName.Text + "');select emp_id from employee_profileCompletion";
                    DataSet dss = c1.fillDataset(qry);
                    if (dss.Tables.Count > 0)
                    {
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            Session["emp_role"] = dss.Tables[0].Rows[0][0].ToString();
                        }
                        if (dss.Tables[1].Rows.Count > 0)
                        {
                            Session["profile_complete"] = "YES";
                        }
                        else
                        {
                            Session["profile_complete"] = "NO";

                        }
                    }
                    else
                    {
                        Session["profile_complete"] = "NO";

                    }
                    Session["username"] = txtUserName.Text;
                    Session["password"] = txtPassword.Text;
                    lblerror.Visible = false;
                    if (ds.Tables[0].Rows[0]["emp_id"].ToString() != "")
                    {
                        Session["emp_id"] = ds.Tables[0].Rows[0]["emp_id"].ToString();
                    }
                    else
                    {
                        Session["NAME"] = "";
                    }
                    if (ds.Tables[0].Rows[0]["NAME"].ToString() != "")
                    {
                        Session["NAME"] = ds.Tables[0].Rows[0]["NAME"].ToString();
                    }
                    else
                    {
                        Session["NAME"] = "";
                    }
                    if (ds.Tables[0].Rows[0]["FATHER"].ToString() != "")
                    {
                        Session["FATHER"] = ds.Tables[0].Rows[0]["FATHER"].ToString();
                    }
                    else
                    {
                        Session["FATHER"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["SURNAME"].ToString() != "")
                    {
                        Session["SURNAME"] = ds.Tables[0].Rows[0]["SURNAME"].ToString();
                    }
                    else
                    {
                        Session["SURNAME"] = "";
                    }
                    if (ds.Tables[0].Rows[0]["MOTHER"].ToString() != "")
                    {
                        Session["MOTHER"] = ds.Tables[0].Rows[0]["MOTHER"].ToString();
                    }
                    else
                    {
                        Session["MOTHER"] = "";
                    }
                    if (ds.Tables[0].Rows[0]["DOB"].ToString() != "")
                    {
                        Session["DOB"] = ds.Tables[0].Rows[0]["DOB"].ToString();
                    }
                    else
                    {
                        Session["DOB"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["DOJ"].ToString() != "")
                    {
                        Session["DOJ"] = ds.Tables[0].Rows[0]["DOJ"].ToString();
                    }
                    else
                    {
                        Session["DOJ"] = "";
                    }
                    if (ds.Tables[0].Rows[0]["PAN_NO"].ToString() != "")
                    {
                        Session["PAN_NO"] = ds.Tables[0].Rows[0]["PAN_NO"].ToString();
                    }
                    else
                    {
                        Session["PAN_NO"] = "";
                    }
                    if (ds.Tables[0].Rows[0]["BLOOD_GROUP"].ToString() != "")
                    {
                        Session["BLOOD_GROUP"] = ds.Tables[0].Rows[0]["BLOOD_GROUP"].ToString();
                    }
                    else
                    {
                        Session["BLOOD_GROUP"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["GENDER"].ToString() != "")
                    {
                        Session["GENDER"] = ds.Tables[0].Rows[0]["GENDER"].ToString();
                    }
                    else
                    {
                        Session["GENDER"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["CASTE"].ToString() != "")
                    {
                        Session["CASTE"] = ds.Tables[0].Rows[0]["CASTE"].ToString();
                    }
                    else
                    {
                        Session["CASTE"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["MOBILE1"].ToString() != "")
                    {
                        Session["MOBILE1"] = ds.Tables[0].Rows[0]["MOBILE1"].ToString();
                    }
                    else
                    {
                        Session["MOBILE1"] = "";
                    }
                    if (ds.Tables[0].Rows[0]["MOBILE2"].ToString() != "")
                    {
                        Session["MOBILE2"] = ds.Tables[0].Rows[0]["MOBILE2"].ToString();
                    }
                    else
                    {
                        Session["MOBILE2"] = "";
                    }
                    if (ds.Tables[0].Rows[0]["EMAIL_ADDRESS"].ToString() != "")
                    {
                        Session["EMAIL_ADDRESS"] = ds.Tables[0].Rows[0]["EMAIL_ADDRESS"].ToString();
                    }
                    else
                    {
                        Session["EMAIL_ADDRESS"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["CURRENT_ADDRESS"].ToString() != "")
                    {
                        Session["CURRENT_ADDRESS"] = ds.Tables[0].Rows[0]["CURRENT_ADDRESS"].ToString();
                    }
                    else
                    {
                        Session["CURRENT_ADDRESS"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["CURRENT_DEPARTMENT_NAME"].ToString() != "")
                    {
                        Session["CURRENT_DEPARTMENT_NAME"] = ds.Tables[0].Rows[0]["CURRENT_DEPARTMENT_NAME"].ToString();
                    }
                    else
                    {
                        Session["CURRENT_DEPARTMENT_NAME"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["CURRENT_DESIGNATION"].ToString() != "")
                    {
                        Session["CURRENT_DESIGNATION"] = ds.Tables[0].Rows[0]["CURRENT_DESIGNATION"].ToString();
                    }
                    else
                    {
                        Session["CURRENT_DEPARTMENT_NAME"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["MARITIAL_STATUS"].ToString() != "")
                    {
                        Session["MARITIAL_STATUS"] = ds.Tables[0].Rows[0]["MARITIAL_STATUS"].ToString();
                    }
                    else
                    {
                        Session["MARITIAL_STATUS"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["PHOTO"].ToString() != "")
                    {
                        Session["PHOTO"] = (Byte[])ds.Tables[0].Rows[0]["PHOTO"];
                    }
                    else
                    {
                        //  Session["PHOTO"] = "";
                    }
                    if (ds.Tables[0].Rows[0]["group_name"].ToString() != "")
                    {
                        Session["group_ids"] = ds.Tables[0].Rows[0]["group_name"].ToString();
                    }
                    else
                    {
                        Session["group_ids"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["form_name"].ToString() != "")
                    {
                        Session["frm"] = "";
                        Session["form_name"] = ds.Tables[0].Rows[0]["form_name"].ToString();
                        string form1 = (string)Session["form_name"];
                        Session["col2"] = ds.Tables[0].Rows[0]["col2"].ToString();
                        //string ext = (string)Session["col2"];
                        //Session["frm"] = form1 + ext;
                        form1 += "," + (string)Session["col2"];
                        Session["frm"] = form1;

                    }
                    else
                    {
                        Session["form_name"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["CATEGORY"].ToString() != "")
                    {
                        Session["CATEGORY"] = ds.Tables[0].Rows[0]["CATEGORY"].ToString();
                    }
                    else
                    {
                        Session["CATEGORY"] = "";
                    }

                    if (ds.Tables[0].Rows[0]["EMAIL_ADDRESS"].ToString() != "")
                    {
                        Session["EMAIL_ADDRESS"] = ds.Tables[0].Rows[0]["EMAIL_ADDRESS"].ToString();
                    }
                    else
                    {
                        Session["EMAIL_ADDRESS"] = "";
                    }

                    c1.insertLog(Session["emp_id"].ToString(), c1.getClientIp(), "", true);
                    Session["Year"] = c1.fillDataTable("select ayid from m_academic where iscurrent=1").Rows[0][0].ToString();
                    //Response.Redirect("https://imr.vivacollege.in/staff_imr/Portals/staff/profile/ViewProfile.aspx");
                    Response.Redirect("~/Portals/Staff/profile/ViewProfile.aspx");


                }
                else
                {
                    lblerror.Text = "Invalid Login";
                    lblerror.Visible = true;
                }
            }
            else
            {
                lblerror.Text = "Invalid Login";
                lblerror.Visible = true;
            }
        }
        else
        {
            if (ds.Tables[1].Rows[0]["msg"].ToString() == "Invalid Password")
            {
                lblerror.Text = "Invalid Password";
                lblerror.Visible = true;
                txtPassword.Text = "";
            }
            else if (ds.Tables[1].Rows[0]["msg"].ToString() == "Invalid Staff ID")
            {
                lblerror.Text = "Invalid Staff ID";
                lblerror.Visible = true;
            }
            else
            {
            }

        }


    }
    [WebMethod]
    public static masterpage[] fillModule(string emp_id)
    {
        classWebMethods cls = new classWebMethods();
        return cls.moduleAccess(emp_id);
    }


    [WebMethod]
    public static masterpage[] fillform(string emp_id)
    {
        classWebMethods cls = new classWebMethods();
        return cls.formAccess(emp_id);
    }


    [WebMethod]
    public static void ClearSession()
    {
        HttpContext.Current.Session["emp_id"] = null; // Clear the session variable
        HttpContext.Current.Session.Remove("emp_id"); // Remove the variable from the session
    }
}