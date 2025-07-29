using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ViewProfile : System.Web.UI.Page
{
    Class1 obj = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Convert.ToString(Session["Emp_id"]) == "")
                    {
                        Response.Redirect("~/Portals/Staff/Login.aspx");
                    }

                }
                catch (Exception ex)
                {
                    Response.Redirect("~/Portals/Staff/Login.aspx");
                    Console.WriteLine(ex.Message);
                }
            }
            
            string query = "SELECT employee_department_des.emp_id AS Expr1, m_employee_personal.emp_id, m_employee_personal.emp_fname, m_employee_personal.emp_mname, m_employee_personal.emp_lname, m_employee_personal.emp_dob,m_employee_personal.emp_doj, m_employee_personal.emp_blood_group, m_employee_personal.emp_gender, m_employee_personal.emp_maritial_status, m_employee_personal.emp_cast,m_employee_personal.emp_mobile1, m_employee_personal.emp_email, m_employee_personal.emp_address_curr, m_designation.Designation_ID, m_designation.Designation_Title, m_department.Department_name,m_department.Dept_id,m_employee_personal.emp_category FROM employee_department_des INNER JOIN  m_department ON employee_department_des.emp_dept_id = m_department.Dept_id INNER JOIN m_designation ON employee_department_des.emp_des_id = m_designation.Designation_ID INNER JOIN m_employee_personal ON employee_department_des.emp_id = m_employee_personal.emp_id where employee_department_des.emp_id='" + Session["emp_id"].ToString() + "'";

            obj.fillDataTable(query);
            DataTable t1 = new DataTable();
            t1 = obj.fillDataTable(query);
            fname.Text = t1.Rows[0]["emp_fname"].ToString().ToLower() + ' ' + t1.Rows[0]["emp_mname"].ToString().ToLower() + ' ' + t1.Rows[0]["emp_lname"].ToString().ToLower();
            //Label lblUserVal = (Label)Page.Master.FindControl("lblUserName");

            Session["Name"] = t1.Rows[0]["emp_fname"].ToString().ToLower() + ' ' + t1.Rows[0]["emp_lname"].ToString().ToLower();
            Session["Designation"] = t1.Rows[0]["Designation_Title"].ToString().ToLower();

            fullname.Text = t1.Rows[0]["emp_fname"].ToString().ToLower() + ' ' + t1.Rows[0]["emp_mname"].ToString().ToLower() + ' ' + t1.Rows[0]["emp_lname"].ToString().ToLower();
            dob.Text = t1.Rows[0]["emp_dob"].ToString().Substring(0, 10);
            //address.Text = t1.Rows[0]["emp_address_curr"].ToString().ToLower();
            string finaladd = "";
            string advar = t1.Rows[0]["emp_address_curr"].ToString().ToLower();
            string[] addresese = advar.Split('~');
            for (int i = 0; i < addresese.Length; i++)
            {
                if (finaladd == "")
                {
                    finaladd = addresese[i];
                }
                else
                {
                    finaladd = finaladd + ' ' + addresese[i];
                }

            }
            address.Text = finaladd;

            doj.Text = t1.Rows[0]["emp_doj"].ToString().Substring(0, 10);

              //string strpath = System.IO.Path.GetExtension(photoUpload.FileName);
              //string strpath1 = System.IO.Path.GetExtension(signUpload.FileName);  


            //profileImage.ImageUrl = "../../Staff/Staff_Photo/" + Session["emp_id"].ToString() +  ".jpg";
            //signImage.ImageUrl = "../../Staff/Staff_Signature/" + Session["emp_id"].ToString() + ".jpg";
            String pathimg = HttpContext.Current.Server.MapPath("../../Staff/Staff_Photo/" + Session["emp_id"].ToString() + ".jpg");
            String pathsign = HttpContext.Current.Server.MapPath("../../Staff/Staff_Signature/" + Session["emp_id"].ToString() + ".jpg");

            if (File.Exists(pathsign))
            {

                signImage.ImageUrl = "../../Staff/Staff_Signature/" + Session["emp_id"].ToString() + ".jpg";

            }
            else
            {


                signImage.ImageUrl = "~/Assets/img/sign.jpg";
            }
            if (File.Exists(pathimg))
            {
                profileImage.ImageUrl = "../../Staff/Staff_Photo/" + Session["emp_id"].ToString() + ".jpg";

            }
            else
            {

                profileImage.ImageUrl = "~/Assets/img/user.png";
            }



            caste.Text = t1.Rows[0]["emp_cast"].ToString().ToLower();
            string cst = t1.Rows[0]["emp_cast"].ToString();
            if (cst == "0")
            {
                caste.Text = "Open";
            }
            else if (cst == "--Select--")
            {
                caste.Text = null;
                caste1.Text = null;
            }
            else
            {
                caste.Text = t1.Rows[0]["emp_cast"].ToString().ToLower();
            }
            category.Text = t1.Rows[0]["emp_category"].ToString().ToLower();
            mobileno.Text = t1.Rows[0]["emp_mobile1"].ToString();
            email.Text = t1.Rows[0]["emp_email"].ToString().ToLower();
            bloodgroup.Text = t1.Rows[0]["emp_blood_group"].ToString();
            string bldgrup = t1.Rows[0]["emp_blood_group"].ToString();
            bloodgroup.Text = bldgrup;
                
            //if (Int16.Parse(bldgrup) == 0)
            //{
            //    bloodgroup.Text = "A -ve";
            //}
            //else if (Int16.Parse(bldgrup) == 1)
            //{
            //    bloodgroup.Text = "  A +ve";

            //}
            //else if (Int16.Parse(bldgrup) == 2)
            //{
            //    bloodgroup.Text = "A -ve";
            //}
            //else if (Int16.Parse(bldgrup) == 3)
            //{
            //    bloodgroup.Text = "AB +ve";

            //}
            //else if (Int16.Parse(bldgrup) == 4)
            //{

            //    bloodgroup.Text = "B -ve";

            //}
            //else if (Int16.Parse(bldgrup) == 5)
            //{
            //    bloodgroup.Text = "B +ve";
            //}
            //else if (Int16.Parse(bldgrup) == 6)
            //{
            //    bloodgroup.Text = "O -ve";
            //}
            //else if (Int16.Parse(bldgrup) == 7)
            //{
            //    bloodgroup.Text = "O +ve";
            //}
            department.Text = t1.Rows[0]["Department_name"].ToString().ToLower();
            string dept = t1.Rows[0]["Department_name"].ToString();
            if (dept == "")
            {
                lbldept.Text = null;
            }
            designation.Text = t1.Rows[0]["Designation_Title"].ToString().ToLower();


            lblgen.Text = t1.Rows[0]["emp_gender"].ToString();
            string gen = t1.Rows[0]["emp_gender"].ToString();
            lblgen.Text = gen;
            //if (Convert.ToBoolean(gen) == true)
            //{
            //    lblgen.Text = "Female";
            //}
            //else
            //{
            //    lblgen.Text = "Male";
            //}

            Lbldesignation.Text = t1.Rows[0]["Designation_Title"].ToString().ToLower();
            lblmartial.Text = t1.Rows[0]["emp_maritial_status"].ToString();
            string martial = t1.Rows[0]["emp_maritial_status"].ToString();
            lblmartial.Text = martial;
            //if (Convert.ToBoolean(martial) == true)
            //{
            //    lblmartial.Text = "Married";
            //}
            //else
            //{
            //    lblmartial.Text = "Unmarried";

            //}

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
            
        }

    }



    //protected void btnUpload_Click(object sender, EventArgs e)
    //{
        // btnUpload.Attributes.Add("onclick", "document.getElementById('" + picUpload.ClientID + "').click();");

        //insertPic();
        ////picUp
        //  if (picUpload.HasFile)
        //  {
        //      string filename = picUpload.FileName;
        //      string filePath = Server.MapPath("Staff_Photo/" + filename);
        //      //picUpload.SaveAs(filePath);
        //  }
        //  else
        //  {
        //      //Response.Write("<script>alert('file not found')</script>");
        //  }
    //}
    //public void insertPic()
    //{
      
    //}
    //protected void picUpload_Load(object sender, EventArgs e)
    //{
    //    if (picUpload.HasFile)
    //    {
    //        string filename = picUpload.FileName;
    //        string filePath = Server.MapPath("Staff_tPhoo/" + filename);
    //        //picUpload.SaveAs(filePath);
    //    }
    //    else
    //    {
    //        //Response.Write("<script>alert('file not found')</script>");
    //    }
    //}
    //protected void picUpload_Init(object sender, EventArgs e)
    //{

    //}
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        if (photoUpload.HasFile)
        {
           //int a = photoUpload.PostedFile.ContentLength;
          byte[] file =photoUpload.FileBytes;
          int tt=file.Length;


          if (tt <= 200000)
          {
              string filename = Session["emp_id"].ToString() + ".jpg";
              string filePath = Server.MapPath("~/Portals/Staff/Staff_Photo/" + filename);
              photoUpload.SaveAs(filePath);

          }
          else
          {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "func", "notify('File Size of photo should be less than 200kb','danger')", true);
          }
        }


        if (signUpload.HasFile)
        {
            //string strpath = System.IO.Path.GetExtension(signUpload.FileName);
            byte[] fileimage = signUpload.FileBytes;
            int ttt = fileimage.Length;
           


            if (ttt <= 200000)
            {
                string filename = Session["emp_id"].ToString() + ".jpg";
                string filePath = Server.MapPath("~/Portals/Staff/Staff_Signature/" + filename);
                signUpload.SaveAs(filePath);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "func", "notify('File Size of Signature should be less than 200kb','danger')", true);
            }
        }
    }
}
