using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Pre_Admission_NaacAdmissionFormPrint : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {

            if (Convert.ToString(Session["Emp_id"]) == "")
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
            else
            {
                string query = "select * from m_academic where AYID >='AYD0056'";
                DataTable dt = cls.fillDataTable(query);
                ddlyear.DataSource = dt;
                ddlyear.DataTextField = "duration";
                ddlyear.DataValueField = "AYID";
                ddlyear.DataBind();
                ddlyear.Items.Insert(0, new ListItem("--Select--", "na"));

            }

        }

    }

    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query = "select * from m_crs_subjectgroup_tbl where del_flag=0";
        DataTable dt = cls.fillDataTable(query);
        ddlgroup.DataSource = dt;
        ddlgroup.DataTextField = "Group_title";
        ddlgroup.DataValueField = "Group_id";
        ddlgroup.DataBind();
        ddlgroup.Items.Insert(0, new ListItem("--Select--", "na"));

    }

    protected void ddlgroup_SelectedIndexChanged(object sender, EventArgs e)
    {

        Session["admissionyear"] = ddlyear.SelectedValue.ToString();

        string abc = ddlyear.SelectedItem.ToString();
        string datee = abc.Substring(8, 4) + '-' + abc.Substring(20, 4);
        Session["year"] = datee;
        Session["admissiongroup"] = ddlgroup.SelectedValue.ToString();

        //Response.Redirect("AdmissionForm.aspx", false);

        get_form();
    }
    public void get_form()
    {

        string query = "";
        if (Session["admissionyear"].ToString() == "AYD0071")
        {
            query = "select stud_id,stud_Grno,stud_F_Name,stud_M_Name,stud_L_Name, stud_Gender  as stud_Gender, stud_BloodGroup,dbo.www_date_display_personal(stud_DOB)as stud_DOB,stud_Nationality,stud_Religion,stud_BirthPlace,stud_Taluka, stud_District,stud_State,stud_DomiciledIn,stud_PermanentAdd,stud_PermanentState,stud_PermanentCity,stud_PermanentPincode,stud_PermanentPhone,stud_NativeAdd,stud_NativeState,stud_NativeCity,stud_NativePincode,stud_NativePhone,stud_Category,isnull(stud_Caste,'--') as stud_Caste,stud_MotherTounge,  stud_MartialStatus,stud_Email,stud_Father_FName,stud_Father_MName,stud_Father_LName,stud_Father_ResidentAdd,stud_Father_Occupation, stud_Father_BusinessServiceAdd,stud_Father_TelNo,stud_Mother_FName,stud_Mother_MName,stud_Mother_LName,stud_Mother_ResidentAdd,stud_Mother_Occupation,stud_Mother_BusinessServiceAdd,stud_Mother_TelNo,stud_Gaurd_FName,stud_Gaurd_MName,stud_Gaurd_LName,stud_Gaurd_Add,stud_Gaurd_TelNo,stud_NoOfFamilyMembers,stud_Earning,stud_NonEarning,stud_YearlyIncome,stud_Photo_Path,user_id,curr_dt,mod_dt,del_flag,del_dt,year_of_adm from dbo.m_std_personaldetails_tbl where stud_id in(select stud_id from m_std_studentacademic_tbl where  del_flag=0 AND ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') order by stud_id;select Group_title, group_id  from dbo.m_crs_subjectgroup_tbl where group_id in(select value from dbo.www_m_std_personaldetails_tbl where stud_id in(select stud_id from m_std_studentacademic_tbl where del_flag=0 AND ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') and field_type = 'Group_id' and ayid = '" + Session["admissionyear"].ToString() + "'); select email_id from dbo.www_login where stud_id in ( select stud_id from m_std_studentacademic_tbl where del_flag=0 and ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "')order by stud_id; select Phy_handicap, Phy_handicap_Description from dbo.d_adm_applicant where stud_id in(select stud_id from m_std_studentacademic_tbl where del_flag=0 and  ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') order by stud_id; select subcourse_id, subcourse_name from m_crs_subcourse_tbl where subcourse_id in (select distinct subcourse_id from m_crs_subjectgroup_tbl where Group_id in (SELECT ca.data AS[grps] FROM www_Eligibility t CROSS APPLY(SELECT * FROM[CSVToTableWithID](t.to_group_id)) ca where t.stud_id in (select stud_id from m_std_studentacademic_tbl where del_flag=0 and  ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') and to_year = '" + Session["admissionyear"].ToString() + "')); select a.subcourse_Id,a.roll_no,b.subcourse_name,c.Group_title from dbo.m_std_studentacademic_tbl as a, m_crs_subcourse_tbl as b, m_crs_subjectgroup_tbl as c where a.subcourse_Id = b.subcourse_id and a.group_id = c.Group_id and a.stud_id in (select stud_id from m_std_studentacademic_tbl where del_flag=0 and  ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') and a.ayid ='" + Session["admissionyear"].ToString() + "' order by stud_id ; select Group_id, Group_title from m_crs_subjectgroup_tbl where Group_id in (SELECT ca.data AS[grps] FROM www_Eligibility t CROSS APPLY(SELECT * FROM[CSVToTableWithID](t.to_group_id)) ca where t.stud_id in (select stud_id from m_std_studentacademic_tbl where del_flag=0 and  ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "')and to_year = '" + Session["admissionyear"].ToString() + "');select * from studentImage where stud_id in (select stud_id from m_std_studentacademic_tbl where  del_flag=0 AND ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') order by stud_id ";
        }
        else
        {
            query = "select stud_id,stud_Grno,stud_F_Name,stud_M_Name,stud_L_Name, stud_Gender  as stud_Gender,case stud_BloodGroup when 0 then 'A -ve' when 1 then 'A +ve' when 2 then 'AB -ve' when 3 then 'AB +ve' when 4 then 'B -ve' when 5 then 'B +ve' when 6 then 'O -ve' when 7 then 'O +ve' end as stud_BloodGroup,dbo.www_date_display_personal(stud_DOB)as stud_DOB,stud_Nationality,stud_Religion,stud_BirthPlace,stud_Taluka, stud_District,stud_State,stud_DomiciledIn,stud_PermanentAdd,stud_PermanentState,stud_PermanentCity,stud_PermanentPincode,stud_PermanentPhone,stud_NativeAdd,stud_NativeState,stud_NativeCity,stud_NativePincode,stud_NativePhone,stud_Category,isnull(stud_Caste,'--') as stud_Caste,stud_MotherTounge,  stud_MartialStatus,stud_Email,stud_Father_FName,stud_Father_MName,stud_Father_LName,stud_Father_ResidentAdd,stud_Father_Occupation, stud_Father_BusinessServiceAdd,stud_Father_TelNo,stud_Mother_FName,stud_Mother_MName,stud_Mother_LName,stud_Mother_ResidentAdd,stud_Mother_Occupation,stud_Mother_BusinessServiceAdd,stud_Mother_TelNo,stud_Gaurd_FName,stud_Gaurd_MName,stud_Gaurd_LName,stud_Gaurd_Add,stud_Gaurd_TelNo,stud_NoOfFamilyMembers,stud_Earning,stud_NonEarning,stud_YearlyIncome,stud_Photo_Path,user_id,curr_dt,mod_dt,del_flag,del_dt,year_of_adm from dbo.m_std_personaldetails_tbl where stud_id in(select stud_id from m_std_studentacademic_tbl where  del_flag=0 AND ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') order by stud_id;select Group_title, group_id  from dbo.m_crs_subjectgroup_tbl where group_id in(select value from dbo.www_m_std_personaldetails_tbl where stud_id in(select stud_id from m_std_studentacademic_tbl where del_flag=0 AND ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') and field_type = 'Group_id' and ayid = '" + Session["admissionyear"].ToString() + "'); select email_id from dbo.www_login where stud_id in ( select stud_id from m_std_studentacademic_tbl where del_flag=0 and  ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') order by stud_id; select Phy_handicap, Phy_handicap_Description from dbo.d_adm_applicant where stud_id in(select stud_id from m_std_studentacademic_tbl where del_flag=0 and  ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "')order by stud_id; select subcourse_id, subcourse_name from m_crs_subcourse_tbl where subcourse_id in (select distinct subcourse_id from m_crs_subjectgroup_tbl where Group_id in (SELECT ca.data AS[grps] FROM www_Eligibility t CROSS APPLY(SELECT * FROM[CSVToTableWithID](t.to_group_id)) ca where t.stud_id in (select stud_id from m_std_studentacademic_tbl where del_flag=0 and  ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') and to_year = '" + Session["admissionyear"].ToString() + "')); select a.subcourse_Id,a.roll_no,b.subcourse_name,c.Group_title from dbo.m_std_studentacademic_tbl as a, m_crs_subcourse_tbl as b, m_crs_subjectgroup_tbl as c where a.subcourse_Id = b.subcourse_id and a.group_id = c.Group_id and a.stud_id in (select stud_id from m_std_studentacademic_tbl where del_flag=0 and  ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "') and a.ayid ='" + Session["admissionyear"].ToString() + "' order by stud_id; select Group_id, Group_title from m_crs_subjectgroup_tbl where Group_id in (SELECT ca.data AS[grps] FROM www_Eligibility t CROSS APPLY(SELECT * FROM[CSVToTableWithID](t.to_group_id)) ca where t.stud_id in (select stud_id from m_std_studentacademic_tbl where del_flag=0 and  ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "')and to_year = '" + Session["admissionyear"].ToString() + "');select * from studentImage where stud_id in (select stud_id from m_std_studentacademic_tbl where  del_flag=0 AND ayid='" + Session["admissionyear"].ToString() + "' and group_id='" + Session["admissiongroup"].ToString() + "')order by stud_id ";

        }

        string substring_academicyear = Session["year"].ToString();
        DataSet ds = cls.fillDataset(query);
        DataTable dt = ds.Tables[0];
        DataTable dtgrp = ds.Tables[5];
        DataTable dtphoto = ds.Tables[7];
        //string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Specify the file path
        //string filePath = Path.Combine(documentsFolder, "admissionform.html");

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        path = Server.MapPath("bulk_admissionform");
        //StreamWriter table12 = new StreamWriter("E:\\website\\staff\\ID_card_html_files\\" + ddl_subcrs.SelectedItem.Text.ToString() + "_ID_card.html");
        StreamWriter table12 = new StreamWriter(path + "\\admission_naac.html");
        try
        {
            //StreamWriter table12 = new StreamWriter(filePath);
            for (int i = 0; i < dt.Rows.Count; i++)
            {


                DataRow row = dt.Rows[i];
                //lblstud_id.Text = row["stud_id"].ToString();
                DataRow rowphoto = dtphoto.Rows[i];
                Byte[] img = (Byte[])rowphoto["STUD_PHOTO"];
                string s_img = Convert.ToBase64String(img);
                Session["image"] = s_img;
                //  Image1.ImageUrl = "data:image/png;base64," + s_img;
                DataRow rowgroup = dtgrp.Rows[i];
                // lbl_group_id.Text = rowgroup["Group_title"].ToString();
                // grpname = rowgroup["Group_title"].ToString().Trim();
                String full_name = row["stud_L_Name"].ToString() + " " + row["stud_F_Name"].ToString() + " " + row["stud_M_Name"].ToString() + " " + row["stud_Mother_FName"].ToString();
                //lblfname.Text = full_name;
                table12.WriteLine("<table style='width:100%;border-spacing: 0px;'><tbody><tr><td style='border:0.5px solid black;height: 57px;'>Teaching Staff:</td><td style='border:0.5px solid black;height: 57px;'>Non Teaching Staff</td><td style='border: 1px solid black;'>Student ID:" + row["stud_id"].ToString() + "</td><td style='border:1.5px solid black;height: 57px;'>Roll No</td><td style='border:1.5px solid black;'>Fees Paid:</td></tr></tbody></table><br>");


                table12.WriteLine("<table style='width:100%;border-spacing: 0px;border: 1px solid;'><tbody><tr><td style='height: 87px; width:18%'><img src='http://localhost:38117/Assets/img/mu.png' style='height:117px;padding:15px;display:flex;float:right' /></td><td style='height: 87px;text-align: center;'><br/><span><b style=\"font-size:26px;font-family:'Times New Roman', Times, serif;\"> Rajeev Gandhi College of Management Studies </b></span><br/><br/><span style = 'font-size: 18px'> An Autonomous college affiliated to University of Mumbai </span><br/><span style = 'font-size: 18px'> Approved by AICTE and Accredited by NAAC 'A' Grade </span></td><td style='width:17%'><img src='" + "data:image/png;base64," + s_img + "' style='height:90px;text-align:center' ></td></tr><tr><td colspan='3' style='border:1.5px solid black;height: 57px;text-align: center;width:100%;font-weight:bold'>ADMISSION FORM FOR " + rowgroup["Group_title"].ToString().Trim() + " " + Session["year"].ToString() + "</td></tr></tbody></table>");
                //https://imr.vivacollege.in/staff_imr/Assets/img/watermark.gif'
                //https://imr.vivacollege.in/staff_imr/Portals/Staff/Pre_Admission/
                table12.WriteLine("<br><div style='color: #d0d0d0;position: absolute;margin-top:50px;height:180px;margin-bottom:100px;margin-left:159px;margin-right:50px;z-index:100;opacity: 0.2;'><img src='http://localhost:38117/Assets/img/RGCMS-2.png' style='height:500px'/></div><table style='width:100%;border-spacing: 0px;font-style:normal'><tbody><tr><td style='font-weight:bold;border: 0.5px solid #9d9b9b' >Full Name: </td><td style='font-weight:bold;border: 0.5px solid #9d9b9b' colspan='3'>" + full_name + "</td></tr><tr><td style='font-weight:bold;border: 0.5px solid #9d9b9b;'>Address: </td><td style='font-weight:bold;border: 0.5px solid #9d9b9b;font-size:12px;' colspan='3'>" + row["stud_PermanentAdd"].ToString() + "</td></tr><tr><td  style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Mobile No.</td><td style='border: 0.5px solid #9d9b9b'>" + row["stud_PermanentPhone"].ToString() + "</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'> Phone No</td><td style='border:0.5px solid #9d9b9b'></td></tr><tr><td style='font-weight:bold;border: 0.5px solid #9d9b9b'>Email ID</td><td style='border: 0.5px solid #9d9b9b'>" + row["stud_Email"].ToString() + "</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Date of Birth</td><td style='border: 0.5px solid #9d9b9b';font-weight:bold;'>" + row["stud_DOB"].ToString() + "</td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Birth Place</td><td style='border: 0.5px solid #9d9b9b' >" + row["stud_BirthPlace"].ToString() + "</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'> Bloodgroup</td><td style='border: 1px solid #9d9b9b;'>" + row["stud_BloodGroup"].ToString() + "</td></tr><tr><td style='border: 1px solid #9d9b9b;font-weight:bold;'>Category</td><td style='border: 1px solid #9d9b9b;font-weight:bold;'>" + row["stud_Category"].ToString() + "</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Caste</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>" + row["stud_Caste"].ToString() + "</td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Caste Validity/Receipt No.:</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>--</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Caste Validity Date:</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>--</td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Income Certificate / Receipt No.:</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'></td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Income Certificate Date:</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'></td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Nationality</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>  </td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Domicle:</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>  </td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Religion</td><td style='border: 0.5px solid #9d9b9b;'>" + row["stud_Religion"].ToString() + "</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Gender</td><td style='border: 0.5px solid #9d9b9b;'>" + row["stud_Gender"].ToString() + "</td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Married/Unmarried</td> <td style='border: 0.5px solid #9d9b9b;'>" + row["stud_MartialStatus"].ToString() + "</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Physically challenged</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>  </td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'> Father Occupation</td><td style='border: 0.5px solid #9d9b9b;'>" + row["stud_Father_Occupation"].ToString() + "</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Tel No.</td><td style='border: 0.5px solid #9d9b9b;'>" + row["stud_Father_TelNo"].ToString() + "</td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Business/Service Address:</td><td style='border: 0.5px solid #9d9b9b;' colspan='3'>" + row["stud_Father_BusinessServiceAdd"].ToString() + "</td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Mother Occupation</td><td style='border: 0.5px solid #9d9b9b;'>" + row["stud_Mother_Occupation"].ToString() + "</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Tel No.</td><td style='border: 0.5px solid #9d9b9b;'>" + row["stud_Mother_TelNo"].ToString() + "</td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Business/Service Address:</td><td style='border: 0.5px solid #9d9b9b;' colspan='3'>" + row["stud_Mother_Occupation"].ToString() + "</td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>No. of Persons in Family</td><td style='border: 0.5px solid #9d9b9b;'>" + row["stud_NoOfFamilyMembers"].ToString() + "</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Annual income of the Family</td><td style='border: 0.5px solid #9d9b9b;'>" + row["stud_YearlyIncome"].ToString() + "</td> </tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Earning</td><td style='border: 0.5px solid #9d9b9b;'>" + row["stud_Earning"].ToString() + "</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Non Earning</td><td style='border: 0.5px solid #9d9b9b;'>" + row["stud_NonEarning"].ToString() + "</td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Have You Applied for Scholarship / Freeship:</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>  </td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Whether a Member of NCC / NSS </td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'> --  </td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Proficiency acquired in Extra curricular Activities:</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'></td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'>Aadhar No:</td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;'></td></tr><tr><td style='border: 0.5px solid #9d9b9b;' colspan='4'><span style='font-weight:bold'>Declaration by Student:</span>I hereby declare that, I have read the rules related to admission and the information filled by me in this form is accurate and true to the best of my knowledge.I will be responsible for any discrepency, arising out of the form signed by me and I undertake that, without necessary documents the final admission will not be granted and / or admission will stand cancelled.will not be granted and / or admission will stand cancelled admission will stand cancelled.</td></tr><tr><td  style='border:0.5px solid #9d9b9b;' colspan='4'><span style='font-weight:bold'>Note:</span>Students from Backward class may please note that their freeship/Schollarship form is official sanctioning from government.They will not be allowed change of stream.Students writing any negative and offensive remark about any staff member or institution on any social networking website may be booked under cyber crime law, Indian I.T Act 2000.</td></tr><tr><td style='border: 0.5px solid #9d9b9b;font-weight:bold;' colspan='2'>Student's Signature </td><td style='border: 0.5px solid #9d9b9b;font-weight:bold;' colspan='2'>Parent's Signature</ td><tr></tbody></table><div style='page-break-after: always;'></div>");

            }
            table12.Close();
            string url = "http://localhost:38117/Portals/Staff/Pre_Admission/bulk_admissionform/admission_naac.html";
            string s = "window.open('" + url + "', 'popup_window', 'width=500,height=200,left=100,top=100,resizable=yes');";


            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_File",
                   "window.open('" + url + "','_blank');", true);
        }
        catch (Exception ex)
        {
            table12.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ex.Message+"')", true);
        }
    }
}