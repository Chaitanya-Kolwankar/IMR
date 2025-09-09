
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Student_StudentModify : System.Web.UI.Page
{
    Class1 cls = new Class1();
    int queryResult;
    int queryResult1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["emp_id"]) == "")
        {
            Response.Redirect("~/Portals/Staff/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {

                txt_tot_Member.Enabled = false;
                txt_studid.Enabled = false;
                dataonpageload();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
            }
        }
    }
    public void dataonpageload()
    {
        btnUpload.Attributes.Add("disabled", "disabled");
        //    btnUpload.Enabled = false;
        btn_pd.Enabled = false;
        btn_brthplace_updt.Enabled = false;
        btnaddrss.Enabled = false;
        btn_natUPdate.Enabled = false;
        btn_fath_det.Enabled = false;
        btn_Mortherdetail.Enabled = false;
        btn_guard_updte.Enabled = false;
        btn_no_of_fam.Enabled = false;
        btn_new.Enabled = false;
        btn_clr.Enabled = false;
        btnUpload.Enabled = false;
        //  BTN_SAVE_IMAGE.Enabled = false;
        PHOTO.Enabled = false;
        SIGN.Enabled = false;

        CATEGORY();
        //BLOODGROUP();
        religion_load();
        state();
        nat_state();
        for (int i = 2026; i >= 1990; i--)
        {
            string s = i.ToString();
            txtPassingyear.Items.Add(s);
        }
    }

    public void state()
    {
        string state = "select distinct Parent from State_category_details where main ='State' and del_flag=0";
        DataTable dtstat = cls.fillDataTable(state);
        ddlstate.DataTextField = dtstat.Columns["parent"].ToString();
        ddlstate.DataValueField = dtstat.Columns["parent"].ToString();
        ddlstate.DataSource = dtstat;
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, new ListItem("--Select--", " "));
    }
    public void nat_state()
    {
        string state1 = "select distinct Parent from State_category_details where main ='State' and del_flag=0";
        DataTable dtstat1 = cls.fillDataTable(state1);
        ddl_nat_state.DataTextField = dtstat1.Columns["parent"].ToString();
        ddl_nat_state.DataValueField = dtstat1.Columns["parent"].ToString();
        ddl_nat_state.DataSource = dtstat1;
        ddl_nat_state.DataBind();
        ddl_nat_state.Items.Insert(0, new ListItem("--Select--", " "));
    }
    //public void BLOODGROUP()
    //{
    //    string bldgrp = "SELECT parent FROM State_category_details WHERE Main='BLOODGROUP' AND del_flag=0";
    //    DataTable dtbldgrp = cls.fillDataTable(bldgrp);
    //    ddlbldgrp.DataTextField = dtbldgrp.Columns["parent"].ToString();
    //    ddlbldgrp.DataValueField = dtbldgrp.Columns["parent"].ToString();
    //    ddlbldgrp.DataSource = dtbldgrp;
    //    ddlbldgrp.DataBind();
    //    ddlbldgrp.Items.Insert(0, new ListItem("--Select--", " "));
    //}


    public void CATEGORY()
    {
        string cate = "select distinct Parent  from State_category_details where main ='Reserved Category' and del_flag=0";
        DataTable dtcat = cls.fillDataTable(cate);
        ddlcat.DataTextField = dtcat.Columns["Parent"].ToString();
        ddlcat.DataValueField = dtcat.Columns["Parent"].ToString();
        ddlcat.DataSource = dtcat;
        ddlcat.DataBind();
        ddlcat.Items.Insert(0, new ListItem("--Select--", " "));
    }
    public void caste()
    {
        string caste = "select distinct trim(child) as child from   State_category_details where parent='" + ddlcat.SelectedValue.ToString() + "' and del_flag=0";
        DataTable dtcast = cls.fillDataTable(caste);
        ddlcast.DataTextField = dtcast.Columns["child"].ToString().Trim();
        ddlcast.DataValueField = dtcast.Columns["child"].ToString().Trim();
        ddlcast.DataSource = dtcast;
        ddlcast.DataBind();
        ddlcast.Items.Insert(0, new ListItem("--Select--", " "));
    }
    public void religion_load()
    {
        string rel = "select trim(Parent) as parent from State_category_details where Main='Religion' and del_flag=0";
        DataTable reldt = cls.fillDataTable(rel);
        ddlreli.DataTextField = reldt.Columns["Parent"].ToString();
        ddlreli.DataValueField = reldt.Columns["Parent"].ToString();
        ddlreli.DataSource = reldt;
        ddlreli.DataBind();
        ddlreli.Items.Insert(0, new ListItem("--Select--", " "));
    }

    protected void btn_pd_Click(object sender, EventArgs e)
    {
        try
        {
            string gen_value = "";
            if (rad_gender.Checked == true)
            {
                gen_value = "Male";
            }
            else
            {
                gen_value = "Female";
            }
            if (txt_fname.Text.Trim() == "")
            {
                txt_fname.Focus();
                txt_fname.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter First Name .','danger')", true);
            }
            else if (txt_mname.Text.Trim() == "")
            {
                txt_mname.Focus();
                txt_mname.Text =
                    "";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Middle Name.','danger')", true);
            }
            else if (rad_female.Checked == false && rad_gender.Checked == false)
            {
                gen.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Gender','danger')", true);
            }
            else if (txt_dob.Text.Trim() == "")
            {
                txt_dob.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Date of Birth','danger')", true);

            }
            else if (ddlnation.SelectedIndex == 0)
            {
                ddlnation.Focus();

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Nationality','danger')", true);

            }
            else if (ddlcat.SelectedIndex == 0)
            {
                ddlcat.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Category','danger')", true);
            }

            else
            {

                if (ddlcat.SelectedItem.Text != "OPEN")
                {
                    if (ddlcast.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Caste','danger')", true);

                    }
                    else
                    {
                        cls.con.Open();

                        string dat2 = txt_dob.Text.Trim();
                        string updte_personaldetails = "update m_std_personaldetails_tbl set  stud_Gender='" + gen_value + "',stud_DOB= Convert(datetime,'" + dat2 + "',105),stud_BloodGroup='" + ddlbldgrp.SelectedValue.ToString() + "',stud_Nationality='" + ddlnation.SelectedValue.ToString() + "',stud_Category='" + ddlcat.SelectedValue.ToString() + "',stud_Caste='" + ddlcast.SelectedValue.ToString() + "',mod_dt=getdate() where stud_id='" + txt_studid.Text.Trim() + "';UPDATE m_std_studentacademic_tbl SET ID_No='" + txt_prn.Text.Trim() + "' WHERE stud_id='" + txt_studid.Text.Trim() + "'";
                        SqlCommand cmd = new SqlCommand("update m_std_personaldetails_tbl set stud_L_Name=@Lastname, stud_F_Name=@studFname, stud_M_Name=@studMName where stud_id = '" + txt_studid.Text.Trim() + "'", cls.con);
                        SqlParameter[] param = new SqlParameter[3];
                        param[0] = new SqlParameter("@Lastname", txt_lname.Text.Trim());
                        cmd.Parameters.Add(param[0]);
                        param[1] = new SqlParameter("@studFname", txt_fname.Text.Trim());
                        cmd.Parameters.Add(param[1]);
                        param[2] = new SqlParameter("@studMName", txt_mname.Text.Trim());
                        cmd.Parameters.Add(param[2]);
                        int check = cmd.ExecuteNonQuery();
                        cls.con.Close();
                        if (cls.DMLqueries(updte_personaldetails))
                        {

                            string search_stud1 = "select convert(varchar,p.stud_DOB,103) as stud_dob,* from m_std_studentacademic_tbl as a,m_std_personaldetails_tbl as p where a.ayid ='" + Session["Year"].ToString() + "' and a.stud_id ='" + txt_studid.Text.Trim() + "' and a.stud_id = p.stud_id and a.del_flag = 0 and p.del_flag = 0;select * from  m_std_pervrecord_tbl where Stud_id='" + txt_studid.Text.Trim() + "' and Del_Flag=0  ORDER BY Exam;select * from studentImage where stud_id='" + txt_studid.Text.Trim() + "'";

                            DataSet srchdt1 = cls.fillDataset(search_stud1);
                            if (srchdt1.Tables[0].Rows.Count > 0)
                            {

                                txt_prn.Text = srchdt1.Tables[0].Rows[0]["ID_NO"].ToString();
                                txt_studid.Text = srchdt1.Tables[0].Rows[0]["stud_id"].ToString();
                                txt_fname.Text = srchdt1.Tables[0].Rows[0]["stud_F_Name"].ToString();
                                txt_mname.Text = srchdt1.Tables[0].Rows[0]["stud_M_Name"].ToString();
                                txt_lname.Text = srchdt1.Tables[0].Rows[0]["stud_L_Name"].ToString();
                                if (srchdt1.Tables[0].Rows[0]["stud_bloodGroup"].ToString() == "")
                                {
                                    ddlbldgrp.SelectedIndex = 0;
                                }
                                else
                                {
                                    ddlbldgrp.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_bloodGroup"].ToString();
                                }

                                if (srchdt1.Tables[0].Rows[0]["stud_gender"].ToString() == "Female")
                                {
                                    rad_female.Checked = true;
                                    rad_gender.Checked = false;
                                    rad_gender.Checked = false;
                                }
                                else if (srchdt1.Tables[0].Rows[0]["stud_gender"].ToString() == "Male")
                                {
                                    rad_gender.Checked = true;
                                    rad_female.Checked = false;
                                }
                                else
                                { }
                                txt_dob.Text = srchdt1.Tables[0].Rows[0]["stud_DOB"].ToString();
                                ddlcat.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_Category"].ToString();
                                if (ddlcat.SelectedItem.Text == "OPEN")
                                {
                                    ddlcast.Items.Clear();
                                }
                                else { caste(); ddlcast.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_Caste"].ToString().Trim(); }

                                // 
                                ddlnation.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_nationality"].ToString().Trim();
                                txtbirthplace.Text = srchdt1.Tables[0].Rows[0]["stud_BirthPlace"].ToString().Trim();
                                if (srchdt1.Tables[0].Rows[0]["stud_MartialStatus"].ToString() == "Married")
                                {
                                    ddlmart.SelectedValue = "Married";
                                }
                                else
                                {
                                    ddlmart.SelectedValue = "Unmarried";
                                }
                                txtemail.Text = srchdt1.Tables[0].Rows[0]["stud_Email"].ToString().Trim();
                                ddlreli.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_Religion"].ToString().Trim();
                                txtadd.Text = srchdt1.Tables[0].Rows[0]["stud_PermanentAdd"].ToString().Trim();
                                ddlstate.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_PermanentState"].ToString().Trim();
                                txtcity.Text = srchdt1.Tables[0].Rows[0]["stud_Permanentcity"].ToString().Trim();
                                txtpin.Text = srchdt1.Tables[0].Rows[0]["stud_PermanentPincode"].ToString().Trim();
                                txtphone.Text = srchdt1.Tables[0].Rows[0]["stud_PermanentPhone"].ToString().Trim();
                                nat_address.Text = srchdt1.Tables[0].Rows[0]["stud_NativeAdd"].ToString();

                                if (srchdt1.Tables[0].Rows[0]["stud_nativestate"].ToString() == "")
                                {
                                    ddl_nat_state.SelectedIndex = 0;
                                }
                                else
                                {
                                    ddl_nat_state.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_nativestate"].ToString();
                                }
                                nat_txt_city.Text = srchdt1.Tables[0].Rows[0]["stud_NativeCity"].ToString();
                                txt_nat_pin.Text = srchdt1.Tables[0].Rows[0]["stud_NativePincode"].ToString();
                                txt_nat_phone.Text = srchdt1.Tables[0].Rows[0]["stud_nativePhone"].ToString().Trim();
                                //personal Details
                                txt_Fathernam.Text = srchdt1.Tables[0].Rows[0]["stud_M_Name"].ToString();
                                txt_father_mname.Text = srchdt1.Tables[0].Rows[0]["stud_Father_MName"].ToString();
                                txt_fatherLstnam.Text = srchdt1.Tables[0].Rows[0]["stud_L_Name"].ToString();
                                ddl_fath_occupation.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_Father_Occupation"].ToString();
                                txt_fath_phone.Text = srchdt1.Tables[0].Rows[0]["stud_Father_TelNo"].ToString();
                                txt_fath_address.Text = srchdt1.Tables[0].Rows[0]["stud_Father_BusinessServiceAdd"].ToString();
                                txtMother_fname.Text = srchdt1.Tables[0].Rows[0]["stud_Mother_FName"].ToString();
                                txtMother_Mname.Text = srchdt1.Tables[0].Rows[0]["stud_Mother_MName"].ToString();
                                txtMother_LstName.Text = srchdt1.Tables[0].Rows[0]["stud_L_Name"].ToString();
                                txt_Mothe_Phon.Text = srchdt1.Tables[0].Rows[0]["stud_Mother_TelNo"].ToString();
                                txt_Moth_servaddres.Text = srchdt1.Tables[0].Rows[0]["stud_Mother_BusinessServiceAdd"].ToString();
                                ddl_Moth_occu.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_Mother_Occupation"].ToString();
                                //guardian Details
                                txtguard_fname.Text = srchdt1.Tables[0].Rows[0]["stud_Gaurd_FName"].ToString();
                                txt_guard_MiddleName.Text = srchdt1.Tables[0].Rows[0]["stud_Gaurd_MName"].ToString();
                                txt_guard_lstname.Text = srchdt1.Tables[0].Rows[0]["stud_Gaurd_LName"].ToString();
                                txt_guard_phone.Text = srchdt1.Tables[0].Rows[0]["stud_Gaurd_TelNo"].ToString();
                                txt_guard_address.Text = srchdt1.Tables[0].Rows[0]["stud_Gaurd_Add"].ToString();
                                //family members
                                //txt_earning.Text = srchdt1.Tables[0].Rows[0]["stud_Earning"].ToString();
                                //txt_Nonearn.Text = srchdt1.Tables[0].Rows[0]["stud_NonEarning"].ToString();
                                //txt_tot_Member.Text = srchdt1.Tables[0].Rows[0]["stud_NoOfFamilyMembers"].ToString();
                                txt_Incone.Text = srchdt1.Tables[0].Rows[0]["stud_YearlyIncome"].ToString();
                                //educational
                                if (srchdt1.Tables[1].Rows.Count > 0)
                                {
                                    grdviw.DataSource = srchdt1.Tables[1];
                                    grdviw.DataBind();
                                }
                                else
                                {

                                    txt_studid.Enabled = false;
                                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Student ID.','danger')", true);

                                }

                                if (srchdt1.Tables[2].Rows.Count > 0)
                                {
                                    byte[] photoarray = new byte[64];
                                    photoarray = (byte[])srchdt1.Tables[2].Rows[0]["STUD_PHOTO"];
                                    string base64 = Convert.ToBase64String(photoarray);
                                    stud_img.ImageUrl = "data:Image/png;base64," + base64;
                                    //string imgg = string.Format("data:{0};base64,{1}", base64, Convert.ToBase64String(photoarray));
                                }
                            }
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Personal Details Updated.','success')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong','danger')", true);
                        }
                    }
                }
                else
                {
                    cls.con.Open();
                    string caste_null = "NULL";
                    string dat2 = txt_dob.Text.Trim();
                    string updte_personaldetails = "update m_std_personaldetails_tbl set  stud_Gender='" + gen_value + "',stud_DOB= Convert(datetime,'" + dat2 + "',105),stud_BloodGroup='" + ddlbldgrp.SelectedValue.ToString() + "',stud_Nationality='" + ddlnation.SelectedValue.ToString() + "',stud_Category='" + ddlcat.SelectedValue.ToString() + "',stud_Caste='" + caste_null + "',mod_dt=getdate() where stud_id='" + txt_studid.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand("update m_std_personaldetails_tbl set stud_L_Name=@Lastname, stud_F_Name=@studFname, stud_M_Name=@studMName where stud_id = '" + txt_studid.Text.Trim() + "'", cls.con);
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@Lastname", txt_lname.Text.Trim());
                    cmd.Parameters.Add(param[0]);
                    param[1] = new SqlParameter("@studFname", txt_fname.Text.Trim());
                    cmd.Parameters.Add(param[1]);
                    param[2] = new SqlParameter("@studMName", txt_mname.Text.Trim());
                    cmd.Parameters.Add(param[2]);
                    int check = cmd.ExecuteNonQuery();
                    cls.con.Close();
                    if (cls.DMLqueries(updte_personaldetails))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Personal Details Updated.','success')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong','danger')", true);
                    }




                }


            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlcat.SelectedIndex == 0)
            {
                ddlcast.Items.Clear();
            }
            else
            {
                caste();
                if (ddlcat.SelectedItem.Text == "OPEN")
                {
                    ddlcast.Items.Clear();
                }
                else
                {
                    if (ddlcast.SelectedIndex == 0)
                    {
                    }


                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void rad_gender_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rad_gender.Checked == true)
            {
                rad_female.Checked = false;
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void rad_female_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rad_female.Checked == true)
            {
                rad_gender.Checked = false;
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    public void idsearch()
    {
        string ayd = Session["Year"].ToString();
        edit_image.ImageUrl = "";
        edit_image.ImageUrl = "~/user.png";
        if (txtstd_id.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID','danger')", true);
        }
        else if (txtstd_id.Text.Length != 8)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Student ID','danger')", true);
        }
        else
        {
            string search_stud = "select convert(varchar,p.stud_DOB,103) as stud_dob,* from m_std_studentacademic_tbl as a,m_std_personaldetails_tbl as p where a.ayid ='" + ayd + "' and a.stud_id ='" + txtstd_id.Text.Trim() + "' and a.stud_id = p.stud_id and a.del_flag = 0 and p.del_flag = 0;select * from  m_std_pervrecord_tbl where Stud_id='" + txtstd_id.Text.Trim() + "' and Del_Flag=0  ORDER BY Exam;select * from studentImage where stud_id='" + txtstd_id.Text.Trim() + "'";

            DataSet srchdt = cls.fillDataset(search_stud);
            if (srchdt.Tables[0].Rows.Count == 0)
            {
                txt_studid.Enabled = false;
                txtstd_id.Text = "";
                txt_studid.Text = "";
                txt_prn.Text = ""; txt_fname.Text = ""; txt_mname.Text = ""; txt_lname.Text = ""; rad_gender.Checked = false; rad_female.Checked = false;
                txt_dob.Text = ""; ddlbldgrp.SelectedIndex = 0; ddlnation.SelectedIndex = 0; ddlcat.SelectedIndex = 0; ddlcast.SelectedIndex = 0; stud_img.ImageUrl = "~/user__image.png"; txtbirthplace.Text = ""; ddlmart.SelectedIndex = 0; txtemail.Text = ""; ddlreli.SelectedIndex = 0;
                txtadd.Text = ""; ddlstate.SelectedIndex = 0;
                txtcity.Text = "";
                txtpin.Text = ""; txtphone.Text = ""; nat_address.Text = ""; ddl_nat_state.SelectedIndex = 0; nat_txt_city.Text = ""; txt_nat_pin.Text = ""; txt_nat_phone.Text = ""; txt_Fathernam.Text = "";
                txt_father_mname.Text = ""; txt_fatherLstnam.Text = ""; ddl_fath_occupation.SelectedIndex = 0; txt_fath_phone.Text = ""; txt_fath_address.Text = ""; txtMother_fname.Text = ""; txtMother_Mname.Text = ""; txtMother_LstName.Text = ""; ddl_Moth_occu.SelectedIndex = 0; txt_Mothe_Phon.Text = ""; txt_Moth_servaddres.Text = ""; txtguard_fname.Text = ""; txt_guard_MiddleName.Text = ""; txt_guard_lstname.Text = ""; txt_guard_phone.Text = ""; txt_guard_address.Text = ""; txt_earning.Text = ""; txt_Nonearn.Text = ""; txt_tot_Member.Text = ""; txt_Incone.Text = ""; txtexam.SelectedIndex = 0; txt_inst_Name.Text = ""; txt_inst_place.Text = ""; txt_Major_sub.Text = "";
                txt_seat.Text = ""; txt_boardUniver.Text = ""; txtspec.Text = ""; txtcertificate.Text = ""; txtPassingmonth.SelectedIndex = 0; txtPassingyear.SelectedIndex = 0; txtobtmrks.Text = ""; txt_OutOfMarks.Text = "";
                grdviw.DataSource = null;
                grdviw.DataBind();
                btn_pd.Enabled = false;
                btn_brthplace_updt.Enabled = false;
                btnaddrss.Enabled = false;
                btn_natUPdate.Enabled = false;
                btn_fath_det.Enabled = false;
                btn_Mortherdetail.Enabled = false;
                btn_guard_updte.Enabled = false;
                btn_no_of_fam.Enabled = false;
                btn_new.Enabled = false;
                btn_clr.Enabled = false;
                btnUpload.Enabled = false;
                PHOTO.Enabled = false;
                SIGN.Enabled = false;
                btnUpload.Attributes.Remove("data-bs-toggle");

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Student ID.','danger')", true);
            }
            else
            {

                txt_prn.Text = srchdt.Tables[0].Rows[0]["ID_NO"].ToString();
                txt_studid.Text = srchdt.Tables[0].Rows[0]["stud_id"].ToString();
                txt_fname.Text = srchdt.Tables[0].Rows[0]["stud_F_Name"].ToString();
                txt_mname.Text = srchdt.Tables[0].Rows[0]["stud_M_Name"].ToString();
                txt_lname.Text = srchdt.Tables[0].Rows[0]["stud_L_Name"].ToString();
                if (srchdt.Tables[0].Rows[0]["stud_bloodGroup"].ToString() == "")
                {
                    ddlbldgrp.SelectedIndex = 0;
                }
                else
                {
                    ddlbldgrp.SelectedValue = srchdt.Tables[0].Rows[0]["stud_bloodGroup"].ToString();
                }

                if (srchdt.Tables[0].Rows[0]["stud_gender"].ToString() == "Female" || srchdt.Tables[0].Rows[0]["stud_gender"].ToString() == "0")
                {
                    rad_female.Checked = true;
                    rad_gender.Checked = false;
                }
                else if (srchdt.Tables[0].Rows[0]["stud_gender"].ToString() == "Male" || srchdt.Tables[0].Rows[0]["stud_gender"].ToString() == "1")
                {
                    rad_gender.Checked = true;
                    rad_female.Checked = false;
                }
                else
                { }
                txt_dob.Text = srchdt.Tables[0].Rows[0]["stud_DOB"].ToString();
                ddlcat.SelectedValue = srchdt.Tables[0].Rows[0]["stud_Category"].ToString();
                if (ddlcat.SelectedItem.Text == "OPEN")
                {
                    ddlcast.Items.Clear();
                }
                else { caste(); ddlcast.SelectedValue = srchdt.Tables[0].Rows[0]["stud_Caste"].ToString().Trim(); }

                // 
                ddlnation.SelectedValue = srchdt.Tables[0].Rows[0]["stud_nationality"].ToString().Trim();
                txtbirthplace.Text = srchdt.Tables[0].Rows[0]["stud_BirthPlace"].ToString().Trim();
                if (srchdt.Tables[0].Rows[0]["stud_MartialStatus"].ToString() == "Married")
                {
                    ddlmart.SelectedValue = "Married";
                }
                else
                {
                    ddlmart.SelectedValue = "Unmarried";
                }
                txtemail.Text = srchdt.Tables[0].Rows[0]["stud_Email"].ToString().Trim();
                ddlreli.SelectedValue = srchdt.Tables[0].Rows[0]["stud_Religion"].ToString().Trim();
                txtadd.Text = srchdt.Tables[0].Rows[0]["stud_PermanentAdd"].ToString().Trim();
                if (srchdt.Tables[0].Rows[0]["stud_PermanentState"].ToString() != null && srchdt.Tables[0].Rows[0]["stud_PermanentState"].ToString() != "NULL" && srchdt.Tables[0].Rows[0]["stud_PermanentState"].ToString() != "")
                {
                    ddlstate.SelectedValue = srchdt.Tables[0].Rows[0]["stud_PermanentState"].ToString().Trim();
                }
                else
                {
                    state();
                }
                txtcity.Text = srchdt.Tables[0].Rows[0]["stud_Permanentcity"].ToString().Trim();
                txtpin.Text = srchdt.Tables[0].Rows[0]["stud_PermanentPincode"].ToString().Trim();
                txtphone.Text = srchdt.Tables[0].Rows[0]["stud_PermanentPhone"].ToString().Trim();
                nat_address.Text = srchdt.Tables[0].Rows[0]["stud_NativeAdd"].ToString();

                if (srchdt.Tables[0].Rows[0]["stud_nativestate"].ToString() == "")
                {
                    ddl_nat_state.SelectedIndex = 0;
                }
                else
                {
                    ddl_nat_state.SelectedValue = srchdt.Tables[0].Rows[0]["stud_nativestate"].ToString();
                }
                nat_txt_city.Text = srchdt.Tables[0].Rows[0]["stud_NativeCity"].ToString();
                txt_nat_pin.Text = srchdt.Tables[0].Rows[0]["stud_NativePincode"].ToString();
                txt_nat_phone.Text = srchdt.Tables[0].Rows[0]["stud_nativePhone"].ToString().Trim();
                //personal Details
                txt_Fathernam.Text = srchdt.Tables[0].Rows[0]["stud_M_Name"].ToString();
                txt_father_mname.Text = srchdt.Tables[0].Rows[0]["stud_Father_MName"].ToString();
                txt_fatherLstnam.Text = srchdt.Tables[0].Rows[0]["stud_L_Name"].ToString();
                ddl_fath_occupation.SelectedValue = srchdt.Tables[0].Rows[0]["stud_Father_Occupation"].ToString();
                txt_fath_phone.Text = srchdt.Tables[0].Rows[0]["stud_Father_TelNo"].ToString();
                txt_fath_address.Text = srchdt.Tables[0].Rows[0]["stud_Father_BusinessServiceAdd"].ToString();
                txtMother_fname.Text = srchdt.Tables[0].Rows[0]["stud_Mother_FName"].ToString();
                txtMother_Mname.Text = srchdt.Tables[0].Rows[0]["stud_Mother_MName"].ToString();
                txtMother_LstName.Text = srchdt.Tables[0].Rows[0]["stud_L_Name"].ToString();
                txt_Mothe_Phon.Text = srchdt.Tables[0].Rows[0]["stud_Mother_TelNo"].ToString();
                txt_Moth_servaddres.Text = srchdt.Tables[0].Rows[0]["stud_Mother_BusinessServiceAdd"].ToString();
                ddl_Moth_occu.SelectedValue = srchdt.Tables[0].Rows[0]["stud_Mother_Occupation"].ToString().ToUpper();
                //guardian Details
                txtguard_fname.Text = srchdt.Tables[0].Rows[0]["stud_Gaurd_FName"].ToString();
                txt_guard_MiddleName.Text = srchdt.Tables[0].Rows[0]["stud_Gaurd_MName"].ToString();
                txt_guard_lstname.Text = srchdt.Tables[0].Rows[0]["stud_Gaurd_LName"].ToString();
                txt_guard_phone.Text = srchdt.Tables[0].Rows[0]["stud_Gaurd_TelNo"].ToString();
                txt_guard_address.Text = srchdt.Tables[0].Rows[0]["stud_Gaurd_Add"].ToString();
                //family members
                txt_earning.Text = srchdt.Tables[0].Rows[0]["stud_Earning"].ToString();
                txt_Nonearn.Text = srchdt.Tables[0].Rows[0]["stud_NonEarning"].ToString();
                txt_tot_Member.Text = srchdt.Tables[0].Rows[0]["stud_NoOfFamilyMembers"].ToString();
                txt_Incone.Text = srchdt.Tables[0].Rows[0]["stud_YearlyIncome"].ToString();
                //educational

           
                if (srchdt.Tables[1].Rows.Count > 0)
                {
                    grdviw.DataSource = srchdt.Tables[1];
                    grdviw.DataBind();
                }
                else
                {

                    txt_studid.Enabled = false;
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Student ID.','danger')", true);

                }

                if (srchdt.Tables[2].Rows.Count > 0)
                {
                    byte[] photoarray = new byte[64];
                    photoarray = (byte[])srchdt.Tables[2].Rows[0]["STUD_PHOTO"];
                    string base64 = Convert.ToBase64String(photoarray);
                    stud_img.ImageUrl = "data:Image/png;base64," + base64;
                    //string imgg = string.Format("data:{0};base64,{1}", base64, Convert.ToBase64String(photoarray));
                }
                txtstd_id.Text = "";
                btn_pd.Enabled = true;
                btn_brthplace_updt.Enabled = true;
                btnaddrss.Enabled = true;
                btn_natUPdate.Enabled = true;
                btn_fath_det.Enabled = true;
                btn_Mortherdetail.Enabled = true;
                btn_guard_updte.Enabled = true;
                btn_no_of_fam.Enabled = true;
                btnUpload.Enabled = true;
                btn_new.Enabled = true;
                btn_clr.Enabled = true;
                btnUpload.Enabled = true;
                PHOTO.Enabled = true;
                SIGN.Enabled = true;
                BTN_SAVE_IMAGE.Enabled = true;
                btnUpload.Attributes.Add("data-bs-toggle", "modal");
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#searchmodal').modal('hide');", true);
            }
        }

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            idsearch();
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void ddlcast_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btn_brthplace_updt_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtbirthplace.Text.Trim() == "")
            {
                txtbirthplace.Focus();
                txtbirthplace.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter BirthPlace.','danger')", true);
            }
            else if (ddlmart.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Maritial Status.','danger')", true); ddlmart.Focus();
            }
            else if (txtemail.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Email ID.','danger')", true);
                txtemail.Focus();
                txtemail.Text = "";
            }
            else if (ddlreli.SelectedIndex == 0)
            {
                ddlreli.Focus();

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Religion.','danger')", true);
            }
            else
            {
                string mail = txtemail.Text.Trim();
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                if (mail.Contains("@") && mail.Contains("."))
                {

                }
                else
                {
                    bool mail2 = regex.IsMatch(mail);
                    if (!mail2)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Invalid Email ID', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                        return;
                    }
                }
                string brthplacequery = "update m_std_personaldetails_tbl set stud_BirthPlace='" + txtbirthplace.Text.Trim()
    + "',stud_Email='" + txtemail.Text.Trim() + "',stud_MartialStatus='" + ddlmart.SelectedValue.ToString() + "',stud_Religion='" + ddlreli.SelectedValue.ToString() + "' where stud_id='" + txt_studid.Text.Trim() + "'";
                if (cls.DMLqueries(brthplacequery))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Birth Place/Other Details Updated  Successful.','success')", true);
                }
                else { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong.','danger')", true); }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void btnaddrss_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtadd.Text.Trim() == "")
            {
                txtadd.Focus();
                txtadd.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Address.','danger')", true);
            }
            else if (ddlstate.SelectedIndex == 0)
            {
                ddlstate.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select State.','danger')", true);
            }
            else if (txtcity.Text.Trim() == "")
            {
                txtcity.Focus();
                txtcity.Text = "";

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter City.','danger')", true);
            }
            else if (txtpin.Text.Trim() == "")
            {
                txtpin.Focus();
                txtpin.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter PinCode.','danger')", true);
            }
            else if (txtpin.Text.Trim().Length < 6)
            {
                txtpin.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Pincode must be of 6 digit.','danger')", true);
            }
            else if (txtphone.Text.Trim() == "")
            {
                txtphone.Focus();
                txtphone.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Phone No.','danger')", true);
            }
            else if (txtphone.Text.Trim().Length < 10)
            {
                txtphone.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Phone no must of 10 digit.','danger')", true);
            }
            else
            {
                string updte_address = "update m_std_personaldetails_tbl set stud_PermanentState='" + ddlstate.SelectedValue.ToString() + "',stud_PermanentPincode='" + txtpin.Text.Trim() + "',stud_PermanentPhone='" + txtphone.Text.Trim() + "' where stud_id='" + txt_studid.Text.Trim() + "'";
                cls.con.Open();
                SqlCommand cmd2 = new SqlCommand("update m_std_personaldetails_tbl set stud_PermanentAdd=@address,stud_PermanentCity=@stucity where stud_id='" + txt_studid.Text.Trim() + "' ", cls.con);
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@address", txtadd.Text.Trim());
                cmd2.Parameters.Add(param[0]);
                param[1] = new SqlParameter("@stucity", txtcity.Text.Trim());
                cmd2.Parameters.Add(param[1]);
                int check = cmd2.ExecuteNonQuery();
                cls.con.Close();
                if (cls.DMLqueries(updte_address))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Address Updated.','success')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong.','danger')", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void btn_natUPdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_nat_pin.Text.Length > 1 && txt_nat_pin.Text.Length < 6)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('  Native`s Pincode. must be of 6 digit','danger')", true);
                txt_nat_pin.Focus();

            }
            else if (txt_nat_phone.Text.Length > 1 && txt_nat_phone.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Native`s  Phone No. must be of 10 digit','danger')", true);
                txt_nat_phone.Focus();
            }
            else
            {
                string NAT_ADD = "UPDATE m_std_personaldetails_tbl SET stud_NativeState='" + ddl_nat_state.SelectedValue.ToString() + "',stud_NativePincode='" + txt_nat_pin.Text.Trim() + "',stud_NativePhone='" + txt_nat_phone.Text.Trim() + "' where stud_id='" + txt_studid.Text.Trim() + "'";
                cls.con.Open();
                SqlCommand cmd = new SqlCommand("update m_std_personaldetails_tbl set  stud_NativeAdd=@nataddress,stud_NativeCity=@natcity where stud_id = '" + txt_studid.Text.Trim() + "'", cls.con);
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@nataddress", nat_address.Text.Trim());
                cmd.Parameters.Add(param[0]);
                param[1] = new SqlParameter("@natcity", nat_txt_city.Text.Trim());
                cmd.Parameters.Add(param[1]);
                int check = cmd.ExecuteNonQuery();
                cls.con.Close();
                if (cls.DMLqueries(NAT_ADD))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Native`s Details Updated.','success')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong.','danger')", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void btn_fath_det_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Fathernam.Text.Trim() == "")
            {
                txt_Fathernam.Text = "";
                txt_Fathernam.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Father`s First Name.','danger')", true);
            }
            else if (ddl_fath_occupation.SelectedIndex == 0)
            {
                ddl_fath_occupation.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Father Occupation','danger')", true);
            }
            else if (txt_fath_phone.Text.Trim() == "")
            {
                txt_fath_phone.Text = ""; txt_fath_phone.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Father Phone no.','danger')", true);
            }
            else if (txt_fath_phone.Text.Length < 10)
            {
                txt_fath_phone.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Father Phone no. Must be of 10 digit ','danger')", true);
            }
            else
            {
                cls.con.Open();
                string father_updt_qry = "update m_std_personaldetails_tbl set stud_Father_Occupation='" + ddl_fath_occupation.SelectedValue.ToString() + "',stud_Father_TelNo='" + txt_fath_phone.Text.Trim() + "',mod_dt= GETDATE() where stud_id='" + txt_studid.Text.Trim() + "'";

                SqlCommand cmd8 = new SqlCommand("update m_std_personaldetails_tbl set stud_L_Name=@fatherlname, stud_Father_MName=@fatherMiddlename, stud_M_Name=@studfather_firstname,stud_Father_BusinessServiceAdd=@businessadress where stud_id = '" + txt_studid.Text.Trim() + "'", cls.con);
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@fatherlname", txt_fatherLstnam.Text.Trim());
                cmd8.Parameters.Add(param[0]);
                param[1] = new SqlParameter("@fatherMiddlename", txt_father_mname.Text.Trim());
                cmd8.Parameters.Add(param[1]);
                param[2] = new SqlParameter("@studfather_firstname", txt_Fathernam.Text.Trim());
                cmd8.Parameters.Add(param[2]);
                param[3] = new SqlParameter("@businessadress", txt_fath_address.Text.Trim());
                cmd8.Parameters.Add(param[3]);
                int check = cmd8.ExecuteNonQuery();
                cls.con.Close();


                if (cls.DMLqueries(father_updt_qry))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Father Details Updated.','success')", true);
                    string search_stud1 = "select convert(varchar,p.stud_DOB,103) as stud_dob,* from m_std_studentacademic_tbl as a,m_std_personaldetails_tbl as p where a.ayid ='" + Session["Year"].ToString() + "' and a.stud_id ='" + txt_studid.Text.Trim() + "' and a.stud_id = p.stud_id and a.del_flag = 0 and p.del_flag = 0;select * from  m_std_pervrecord_tbl where Stud_id='" + txt_studid.Text.Trim() + "' and Del_Flag=0  ORDER BY Exam;select * from studentImage where stud_id='" + txt_studid.Text.Trim() + "'";

                    DataSet srchdt1 = cls.fillDataset(search_stud1);
                    if (srchdt1.Tables[0].Rows.Count > 0)
                    {

                        txt_prn.Text = srchdt1.Tables[0].Rows[0]["ID_NO"].ToString();
                        txt_studid.Text = srchdt1.Tables[0].Rows[0]["stud_id"].ToString();
                        txt_fname.Text = srchdt1.Tables[0].Rows[0]["stud_F_Name"].ToString();
                        txt_mname.Text = srchdt1.Tables[0].Rows[0]["stud_M_Name"].ToString();
                        txt_lname.Text = srchdt1.Tables[0].Rows[0]["stud_L_Name"].ToString();
                        if (srchdt1.Tables[0].Rows[0]["stud_bloodGroup"].ToString() == "")
                        {
                            ddlbldgrp.SelectedIndex = 0;
                        }
                        else
                        {
                            ddlbldgrp.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_bloodGroup"].ToString();
                        }

                        if (srchdt1.Tables[0].Rows[0]["stud_gender"].ToString() == "Female")
                        {
                            rad_female.Checked = true;
                            rad_gender.Checked = false;
                            rad_gender.Checked = false;
                        }
                        else if (srchdt1.Tables[0].Rows[0]["stud_gender"].ToString() == "Male")
                        {
                            rad_gender.Checked = true;
                            rad_female.Checked = false;
                        }
                        else
                        { }
                        txt_dob.Text = srchdt1.Tables[0].Rows[0]["stud_DOB"].ToString();
                        ddlcat.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_Category"].ToString();
                        if (ddlcat.SelectedItem.Text == "OPEN")
                        {
                            ddlcast.Items.Clear();
                        }
                        else { caste(); ddlcast.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_Caste"].ToString().Trim(); }

                        // 
                        ddlnation.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_nationality"].ToString().Trim();
                        txtbirthplace.Text = srchdt1.Tables[0].Rows[0]["stud_BirthPlace"].ToString().Trim();
                        if (srchdt1.Tables[0].Rows[0]["stud_MartialStatus"].ToString() == "Married")
                        {
                            ddlmart.SelectedValue = "Married";
                        }
                        else
                        {
                            ddlmart.SelectedValue = "Unmarried";
                        }
                        txtemail.Text = srchdt1.Tables[0].Rows[0]["stud_Email"].ToString().Trim();
                        ddlreli.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_Religion"].ToString().Trim();
                        txtadd.Text = srchdt1.Tables[0].Rows[0]["stud_PermanentAdd"].ToString().Trim();
                        ddlstate.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_PermanentState"].ToString().Trim();
                        txtcity.Text = srchdt1.Tables[0].Rows[0]["stud_Permanentcity"].ToString().Trim();
                        txtpin.Text = srchdt1.Tables[0].Rows[0]["stud_PermanentPincode"].ToString().Trim();
                        txtphone.Text = srchdt1.Tables[0].Rows[0]["stud_PermanentPhone"].ToString().Trim();
                        nat_address.Text = srchdt1.Tables[0].Rows[0]["stud_NativeAdd"].ToString();

                        if (srchdt1.Tables[0].Rows[0]["stud_nativestate"].ToString() == "")
                        {
                            ddl_nat_state.SelectedIndex = 0;
                        }
                        else
                        {
                            ddl_nat_state.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_nativestate"].ToString();
                        }
                        nat_txt_city.Text = srchdt1.Tables[0].Rows[0]["stud_NativeCity"].ToString();
                        txt_nat_pin.Text = srchdt1.Tables[0].Rows[0]["stud_NativePincode"].ToString();
                        txt_nat_phone.Text = srchdt1.Tables[0].Rows[0]["stud_nativePhone"].ToString().Trim();
                        //personal Details
                        txt_Fathernam.Text = srchdt1.Tables[0].Rows[0]["stud_M_Name"].ToString();
                        txt_father_mname.Text = srchdt1.Tables[0].Rows[0]["stud_Father_MName"].ToString();
                        txt_fatherLstnam.Text = srchdt1.Tables[0].Rows[0]["stud_L_Name"].ToString();
                        ddl_fath_occupation.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_Father_Occupation"].ToString();
                        txt_fath_phone.Text = srchdt1.Tables[0].Rows[0]["stud_Father_TelNo"].ToString();
                        txt_fath_address.Text = srchdt1.Tables[0].Rows[0]["stud_Father_BusinessServiceAdd"].ToString();
                        txtMother_fname.Text = srchdt1.Tables[0].Rows[0]["stud_Mother_FName"].ToString();
                        txtMother_Mname.Text = srchdt1.Tables[0].Rows[0]["stud_Mother_MName"].ToString();
                        txtMother_LstName.Text = srchdt1.Tables[0].Rows[0]["stud_L_Name"].ToString();
                        txt_Mothe_Phon.Text = srchdt1.Tables[0].Rows[0]["stud_Mother_TelNo"].ToString();
                        txt_Moth_servaddres.Text = srchdt1.Tables[0].Rows[0]["stud_Mother_BusinessServiceAdd"].ToString();
                        ddl_Moth_occu.SelectedValue = srchdt1.Tables[0].Rows[0]["stud_Mother_Occupation"].ToString();
                        //guardian Details
                        txtguard_fname.Text = srchdt1.Tables[0].Rows[0]["stud_Gaurd_FName"].ToString();
                        txt_guard_MiddleName.Text = srchdt1.Tables[0].Rows[0]["stud_Gaurd_MName"].ToString();
                        txt_guard_lstname.Text = srchdt1.Tables[0].Rows[0]["stud_Gaurd_LName"].ToString();
                        txt_guard_phone.Text = srchdt1.Tables[0].Rows[0]["stud_Gaurd_TelNo"].ToString();
                        txt_guard_address.Text = srchdt1.Tables[0].Rows[0]["stud_Gaurd_Add"].ToString();
                        //family members
                        txt_earning.Text = srchdt1.Tables[0].Rows[0]["stud_Earning"].ToString();
                        txt_Nonearn.Text = srchdt1.Tables[0].Rows[0]["stud_NonEarning"].ToString();
                        txt_tot_Member.Text = srchdt1.Tables[0].Rows[0]["stud_NoOfFamilyMembers"].ToString();
                        txt_Incone.Text = srchdt1.Tables[0].Rows[0]["stud_YearlyIncome"].ToString();
                        //educational
                        if (srchdt1.Tables[1].Rows.Count > 0)
                        {
                            grdviw.DataSource = srchdt1.Tables[1];
                            grdviw.DataBind();
                        }
                        else
                        {

                            txt_studid.Enabled = false;
                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Student ID.','danger')", true);

                        }

                        if (srchdt1.Tables[2].Rows.Count > 0)
                        {
                            byte[] photoarray = new byte[64];
                            photoarray = (byte[])srchdt1.Tables[2].Rows[0]["STUD_PHOTO"];
                            string base64 = Convert.ToBase64String(photoarray);
                            stud_img.ImageUrl = "data:Image/png;base64," + base64;
                            //string imgg = string.Format("data:{0};base64,{1}", base64, Convert.ToBase64String(photoarray));
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong.','danger')", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void btn_Mortherdetail_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtMother_fname.Text.Trim() == "")
            {
                txtMother_fname.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Mother`s First Name.','danger')", true);
            }
            else if (ddl_Moth_occu.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Mother Occupation','danger')", true);
            }
            else if (txt_Mothe_Phon.Text.Trim() == "")
            {
                txt_Mothe_Phon.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Mother Phone no.','danger')", true);
            }
            else if (txt_Mothe_Phon.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Mother Phone no. Must be of 10 digit','danger')", true);
            }
            else
            {
                cls.con.Open();
                string Morther_updte_qry = "update m_std_personaldetails_tbl set stud_Mother_Occupation='" + ddl_Moth_occu.SelectedValue.ToString() + "',stud_Mother_TelNo='" + txt_Mothe_Phon.Text.Trim() + "',mod_dt=getdate() where stud_id='" + txt_studid.Text.Trim() + "'";

                SqlCommand cmd = new SqlCommand("update m_std_personaldetails_tbl set stud_Mother_FName=@Motherfirstname, stud_Mother_MName=@motherMiddle, stud_Mother_LName=@Motherlast,stud_Mother_BusinessServiceAdd=@momadrress where stud_id = '" + txt_studid.Text.Trim() + "'", cls.con);
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Motherfirstname", txtMother_fname.Text.Trim());
                cmd.Parameters.Add(param[0]);
                param[1] = new SqlParameter("@motherMiddle", txtMother_Mname.Text.Trim());
                cmd.Parameters.Add(param[1]);
                param[2] = new SqlParameter("@Motherlast", txtMother_LstName.Text.Trim());
                cmd.Parameters.Add(param[2]);
                param[3] = new SqlParameter("@momadrress", txt_Moth_servaddres.Text.Trim());
                cmd.Parameters.Add(param[3]);



                int check = cmd.ExecuteNonQuery();
                cls.con.Close();



                if (cls.DMLqueries(Morther_updte_qry))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Mother Details Updated.','success')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong.','danger')", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void btn_guard_updte_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_guard_phone.Text.Trim().Length < 10)
            {
                txt_guard_phone.Focus();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Guardian Phone`s .','danger')", true);
            }
            else
            {
                cls.con.Open();
                string guard_qry = "update m_std_personaldetails_tbl set stud_Gaurd_TelNo = '" + txt_guard_phone.Text.Trim() + "',mod_dt= GETDATE() where stud_id = '" + txt_studid.Text.Trim() + "'";

                SqlCommand cmd = new SqlCommand("update m_std_personaldetails_tbl set stud_Gaurd_FName=@guardfirst, stud_Gaurd_MName=@guardmiddle, stud_Gaurd_LName=@guardLast,stud_Gaurd_Add=@guardaddress where stud_id = '" + txt_studid.Text.Trim() + "'", cls.con);
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@guardfirst", txtguard_fname.Text.Trim());
                cmd.Parameters.Add(param[0]);
                param[1] = new SqlParameter("@guardmiddle", txt_guard_MiddleName.Text.Trim());
                cmd.Parameters.Add(param[1]);
                param[2] = new SqlParameter("@guardLast", txt_guard_lstname.Text.Trim());
                cmd.Parameters.Add(param[2]);
                param[3] = new SqlParameter("@guardaddress", txt_guard_address.Text.Trim());
                cmd.Parameters.Add(param[3]);
                int check = cmd.ExecuteNonQuery();
                cls.con.Close();



                if (cls.DMLqueries(guard_qry))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Guardian Details Updated.','success')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong.','danger')", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void btn_no_of_fam_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_earning.Text.Trim() == "")
            {
                txt_earning.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Earning.','danger')", true);
            }
            else if (txt_Nonearn.Text.Trim() == "")
            {
                txt_Nonearn.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Non Earning.','danger')", true);
            }
            else if (txt_Incone.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Yearly Income','danger')", true);
            }
            else
            {
                string personinfamily_qry = "update m_std_personaldetails_tbl set stud_Earning='" + txt_earning.Text.Trim() + "',stud_NonEarning='" + txt_Nonearn.Text.Trim() + "',stud_NoOfFamilyMembers='" + txt_tot_Member.Text.Trim() + "',stud_YearlyIncome='" + txt_Incone.Text.Trim() + "',mod_dt= GETDATE() where stud_id='" + txt_studid.Text.Trim() + "'";

                if (cls.DMLqueries(personinfamily_qry))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Family Details Updated Successful.','success')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong.','danger')", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void grd_select_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lbtn = (LinkButton)sender;
            GridViewRow gr = (GridViewRow)lbtn.NamingContainer;
            Label lbl_exm = (Label)gr.FindControl("lblgrdexam") as Label;
            Label instiutname = (Label)gr.FindControl("lblgrd_InstituteName");
            Label ins_place = (Label)gr.FindControl("lblgrd_Instituteplace");
            Label seatno = (Label)gr.FindControl("lbl_grd_seatno");
            Label boarname = (Label)gr.FindControl("lbl_grd_Board_univer");
            Label mnthpassing = (Label)gr.FindControl("lbl_grd_monthpassing");
            Label obtmarks = (Label)gr.FindControl("lbl_grd_mrksobt");
            Label out_ofMarks = (Label)gr.FindControl("lbl_grd_outofMark");
            Label class_obt = (Label)gr.FindControl("lbl_grd_Classobt");
            Label Percent = (Label)gr.FindControl("lbl_grd_Exct_Perct");
            Label maj_sub = (Label)gr.FindControl("lbl_grd_Majorsub");
            Label special = (Label)gr.FindControl("lbl_grd_spec");
            Label certificate = (Label)gr.FindControl("lbl_grd_certi");
            txtexam.SelectedValue = lbl_exm.Text;
            txt_inst_Name.Text = instiutname.Text;
            txt_inst_place.Text = ins_place.Text;
            txt_seat.Text = seatno.Text;
            txt_boardUniver.Text = boarname.Text;
            string mnth_year = mnthpassing.Text;
            string[] month_year_split = mnth_year.Split(' ');


            txtPassingmonth.SelectedValue = month_year_split[0];
            txtPassingyear.SelectedValue = month_year_split[8];
            txtobtmrks.Text = obtmarks.Text;
            txt_OutOfMarks.Text = out_ofMarks.Text;
            txtspec.Text = special.Text; txt_Major_sub.Text = maj_sub.Text;
            txtcertificate.Text = certificate.Text;
            txtexam.Enabled = false;
            btn_new.Text = "Update";
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    public void EDUC_GRID()
    {
        string GRD_QURY = "select * from  m_std_pervrecord_tbl where Stud_id = '" + txt_studid.Text.Trim() + "' and Del_Flag = 0  ORDER BY Exam";
        DataTable DT_EDU = cls.fillDataTable(GRD_QURY);
        grdviw.DataSource = DT_EDU;
        grdviw.DataBind();
    }

    protected void grd_del_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lbtnDEL = (LinkButton)sender;
            GridViewRow gr1 = (GridViewRow)lbtnDEL.NamingContainer;
            Label EXAM1 = (Label)gr1.FindControl("lblgrdexam");
            string del_education = "UPDATE m_std_pervrecord_tbl SET Del_Flag=1 WHERE Stud_id='" + txt_studid.Text.Trim() + "' AND EXAM='" + EXAM1.Text + "'";
            if (cls.DMLqueries(del_education))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Education Record Deleted.','success')", true);
                EDUC_GRID();
                txtexam.SelectedIndex = 0;
                txt_inst_Name.Text = "";
                txt_inst_place.Text = "";
                txt_Major_sub.Text = "";
                txt_seat.Text = "";
                txt_boardUniver.Text = "";
                txtspec.Text = "";
                txtcertificate.Text = "";
                txtPassingyear.SelectedIndex = 0;
                txtPassingmonth.SelectedIndex = 0;
                txt_OutOfMarks.Text = "";
                txtobtmrks.Text = "";
                btn_new.Text = "Save";
                txtexam.Enabled = true;

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong.','danger')", true);
                txtexam.SelectedIndex = 0;
                txt_inst_Name.Text = "";
                txt_inst_place.Text = "";
                txt_Major_sub.Text = "";
                txt_seat.Text = "";
                txt_boardUniver.Text = "";
                txtspec.Text = "";
                txtcertificate.Text = "";
                txtPassingyear.SelectedIndex = 0;
                txtPassingmonth.SelectedIndex = 0;
                txt_OutOfMarks.Text = "";
                txtobtmrks.Text = "";
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {

    }
    protected void btn_new_Click(object sender, EventArgs e)
    {
        try
        {
            string class__obtained = "";
            string class__obtained1 = "";
            string qry_passmnth_and_year = "";
            qry_passmnth_and_year = txtPassingmonth.SelectedValue.ToString() + "        " + txtPassingyear.SelectedValue.ToString();
            if (btn_new.Text == "Save")
            {
                string new_entry = "select * from m_std_pervrecord_tbl where Stud_id='" + txt_studid.Text.Trim() + "' and Exam='" + txtexam.Text.Trim() + "' and Del_Flag=0";
                DataTable dt = cls.fillDataTable(new_entry);
                if (txtexam.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Exam.','danger')", true);

                    txtexam.Focus();
                }
                else if (dt.Rows.Count > 0)
                {
                    txtexam.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Exam type  Already exist','danger')", true);
                }
                else if (txt_inst_Name.Text.Trim() == "")
                {
                    txt_inst_Name.Text = "";
                    txt_inst_Name.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Institute Name','danger')", true);

                }
                else if (txt_inst_place.Text.Trim() == "")
                {
                    txt_inst_place.Text = "";
                    txt_inst_place.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Institute Place','danger')", true);

                }
                else if (txt_seat.Text.Trim() == "")
                {
                    txt_seat.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Seat Number.','danger')", true);
                    txt_seat.Focus();
                }
                else if (txt_boardUniver.Text.Trim() == "")
                {
                    txt_boardUniver.Text = "";
                    txt_boardUniver.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Board / University.','danger')", true);
                }
                else if (txtPassingmonth.SelectedIndex == 0)
                {
                    txtPassingmonth.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Passing Month','danger')", true);
                }
                else if (txtPassingyear.SelectedIndex == 0)
                {
                    txtPassingyear.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Passing Year','danger')", true);

                }
                else if (txtobtmrks.Text.Trim() == "")
                {
                    txtobtmrks.Text = "";
                    txtobtmrks.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Obtain Marks','danger')", true);
                }
                else if (txt_OutOfMarks.Text.Trim() == "")
                {
                    txt_OutOfMarks.Text = "";
                    txt_OutOfMarks.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter OutOf Marks','danger')", true);

                }
                else
                {
                    Int64 OUT_OF_MRKS = Convert.ToInt64(txt_OutOfMarks.Text.Trim());
                    Int64 OBTN_MARK = Convert.ToInt64(txtobtmrks.Text.Trim());
                    float numerator = int.Parse(txtobtmrks.Text.ToString());
                    float denominator = int.Parse(txt_OutOfMarks.Text.ToString());
                    float PERCENTAGE = (float)Math.Round(((numerator / denominator) * 100), 2);
                    if (PERCENTAGE > 75.00)
                    {
                        class__obtained = "Distinct";
                    }
                    else if (PERCENTAGE >= 60.00 && PERCENTAGE <= 75.00)
                    {
                        class__obtained = "First class";
                    }
                    else if (PERCENTAGE >= 45.00 && PERCENTAGE <= 59.00)
                    {
                        class__obtained = "second class";
                    }
                    else
                    {
                        class__obtained = "pass class";
                    }
                    if (OBTN_MARK > OUT_OF_MRKS)
                    {
                        txt_OutOfMarks.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Obtained marks should less than Outof Marks','danger')", true);
                    }
                    else
                    {
                        cls.con.Open();

                        SqlCommand cmd6 = new SqlCommand("INSERT INTO m_std_pervrecord_tbl (Stud_id,Exam,Institute_name,Institute_place,Major_Subject,Exam_seatno,Board_University,Specialization,certificate_no,Marks_obtained,Outof,Month_year_passing,Class_obtained,Exact_percentage,User_id,Curr_dt,Del_Flag,FYID,AYID) VALUES(@studid,@exam,@instname,@instplace,@majorsubject,@seatno,@boarduniversity,@specialization,@certificate,@obtainmrks,@outmrks,@monthandyear,@classobtain,@percentage,@admin,@getdate,@delflag,@fyid,@ayidd)", cls.con);
                        SqlParameter[] param = new SqlParameter[19];

                        param[0] = new SqlParameter("@studid", txt_studid.Text.Trim());
                        cmd6.Parameters.Add(param[0]);
                        param[1] = new SqlParameter("@Exam", txtexam.Text.Trim());
                        cmd6.Parameters.Add(param[1]);
                        param[2] = new SqlParameter("@instname", txt_inst_Name.Text.Trim());
                        cmd6.Parameters.Add(param[2]);
                        param[3] = new SqlParameter("@instplace", txt_inst_place.Text.Trim());
                        cmd6.Parameters.Add(param[3]);
                        param[4] = new SqlParameter("@majorsubject", txt_Major_sub.Text.Trim());
                        cmd6.Parameters.Add(param[4]);
                        param[5] = new SqlParameter("@seatno", txt_seat.Text.Trim());
                        cmd6.Parameters.Add(param[5]);
                        param[6] = new SqlParameter("@boarduniversity", txt_boardUniver.Text.Trim());
                        cmd6.Parameters.Add(param[6]);
                        param[7] = new SqlParameter("@specialization", txtspec.Text.Trim());
                        cmd6.Parameters.Add(param[7]);
                        param[8] = new SqlParameter("@certificate", txtcertificate.Text.Trim());
                        cmd6.Parameters.Add(param[8]);
                        param[9] = new SqlParameter("@obtainmrks", txtobtmrks.Text.Trim());
                        cmd6.Parameters.Add(param[9]);
                        param[10] = new SqlParameter("@outmrks", txt_OutOfMarks.Text.Trim());
                        cmd6.Parameters.Add(param[10]);
                        param[11] = new SqlParameter("@monthandyear", qry_passmnth_and_year);
                        cmd6.Parameters.Add(param[11]);
                        param[12] = new SqlParameter("@classobtain", class__obtained);
                        cmd6.Parameters.Add(param[12]);
                        param[13] = new SqlParameter("@percentage", PERCENTAGE);
                        cmd6.Parameters.Add(param[13]);
                        param[14] = new SqlParameter("@admin", "ADMIN");
                        cmd6.Parameters.Add(param[14]);
                        param[15] = new SqlParameter("@getdate", "");
                        cmd6.Parameters.Add(param[15]);
                        param[16] = new SqlParameter("@delflag", "0");
                        cmd6.Parameters.Add(param[16]);
                        param[17] = new SqlParameter("@fyid", "");
                        cmd6.Parameters.Add(param[17]);
                        param[18] = new SqlParameter("@ayidd", Session["Year"].ToString());
                        cmd6.Parameters.Add(param[18]);

                        int check = cmd6.ExecuteNonQuery();
                        cls.con.Close();


                        if (check == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Education Record Added.','success')", true);
                            EDUC_GRID();
                            txtexam.SelectedIndex = 0;
                            txtexam.Enabled = true;
                            txt_inst_Name.Text = "";
                            txt_inst_place.Text = "";
                            txt_Major_sub.Text = "";
                            txt_seat.Text = "";
                            txt_boardUniver.Text = "";
                            txtspec.Text = "";
                            txtcertificate.Text = "";
                            txtPassingyear.SelectedIndex = 0;
                            txtPassingmonth.SelectedIndex = 0;
                            txt_OutOfMarks.Text = "";
                            txtobtmrks.Text = "";

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong','danger')", true);
                        }

                    }
                }
            }
            else
            {
                if (btn_new.Text == "Update")
                {
                    if (txt_inst_Name.Text.Trim() == "")
                    {
                        txt_inst_Name.Text = "";
                        txt_inst_Name.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Institute Name.','danger')", true);
                    }
                    else if (txt_inst_place.Text.Trim() == "")
                    {
                        txt_inst_place.Text = "";
                        txt_inst_place.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Institute Place.','danger')", true);

                    }
                    else if (txt_seat.Text.Trim() == "")
                    {
                        txt_seat.Text = "";
                        txt_seat.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Seat Number.','danger')", true);
                    }
                    else if (txt_boardUniver.Text.Trim() == "")
                    {
                        txt_boardUniver.Text = "";
                        txt_boardUniver.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Board/University Name.','danger')", true);
                    }
                    else if (txtPassingmonth.SelectedIndex == 0)
                    {
                        txtPassingmonth.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Passing Month.','danger')", true);

                    }
                    else if (txtPassingyear.SelectedIndex == 0)
                    {
                        txtPassingyear.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Passing Year.','danger')", true);
                    }
                    else if (txtobtmrks.Text.Trim() == "")
                    {
                        txtobtmrks.Text = "";

                        txtobtmrks.Focus();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Obtained Marks.','danger')", true);
                    }
                    else if (txt_OutOfMarks.Text.Trim() == "")
                    {
                        txt_OutOfMarks.Text = "";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Outof Marks.','danger')", true);
                        txt_OutOfMarks.Focus();
                    }
                    else
                    {
                        Int64 OUT_OF_MRKS1 = Convert.ToInt64(txt_OutOfMarks.Text.Trim());
                        Int64 OBTN_MARK1 = Convert.ToInt64(txtobtmrks.Text.Trim());
                        float numerator1 = int.Parse(txtobtmrks.Text.ToString());
                        float denominator1 = int.Parse(txt_OutOfMarks.Text.ToString());
                        float PERCENTAGE1 = (float)Math.Round(((numerator1 / denominator1) * 100), 2);
                        if (PERCENTAGE1 > 75.00)
                        {
                            class__obtained1 = "Distinct";
                        }
                        else if (PERCENTAGE1 >= 60.00 && PERCENTAGE1 <= 75.00)                     //PERCENTAGE between 60.00 and 75.00
                        {
                            class__obtained1 = "First class";
                        }
                        else if (PERCENTAGE1 >= 45.00 && PERCENTAGE1 <= 59.00)
                        {
                            class__obtained1 = "second class";
                        }
                        else
                        {
                            class__obtained1 = "pass class";
                        }
                        if (OBTN_MARK1 > OUT_OF_MRKS1)
                        {
                            txt_OutOfMarks.Focus();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Obtained marks should less than Outof Marks','danger')", true);
                        }
                        else
                        {
                            cls.con.Open();

                            string updte_info = "update m_std_pervrecord_tbl set Institute_name='" + txt_inst_Name.Text.Trim() + "',Institute_place='" + txt_inst_place.Text.Trim() + "',Exam_seatno='" + txt_seat.Text.Trim() + "',Month_year_passing='" + qry_passmnth_and_year + "',Marks_obtained='" + txtobtmrks.Text.Trim() + "',Outof='" + txt_OutOfMarks.Text.Trim() + "',Major_Subject='" + txt_Major_sub.Text.Trim() + "',Specialization='" + txtspec.Text.Trim() + "',certificate_no='" + txtcertificate.Text.Trim() + "',Class_obtained='" + class__obtained1 + "',Exact_percentage='" + PERCENTAGE1 + "',mod_dt= GETDATE() where Exam='" + txtexam.Text.Trim() + "' and Stud_id='" + txt_studid.Text.Trim() + "' and Del_Flag=0 and AYID='" + Session["Year"].ToString() + "'";

                            SqlCommand cmd5 = new SqlCommand("update m_std_pervrecord_tbl set Board_University=@univer_board where stud_id='" + txt_studid.Text.Trim() + "' and Del_Flag=0 and AYID='" + Session["Year"].ToString() + "'", cls.con);
                            SqlParameter[] param = new SqlParameter[1];
                            param[0] = new SqlParameter("@univer_board", txt_boardUniver.Text.Trim());
                            cmd5.Parameters.Add(param[0]);

                            int check = cmd5.ExecuteNonQuery();
                            cls.con.Close();


                            if (cls.DMLqueries(updte_info))
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Education Record Updated.','success')", true);
                                btn_new.Text = "Save";
                                EDUC_GRID();
                                txtexam.SelectedIndex = 0;
                                txt_inst_Name.Text = "";
                                txt_inst_place.Text = "";
                                txt_Major_sub.Text = "";
                                txt_seat.Text = "";
                                txt_boardUniver.Text = "";
                                txtspec.Text = "";
                                txtcertificate.Text = "";
                                txtPassingyear.SelectedIndex = 0;
                                txtPassingmonth.SelectedIndex = 0;
                                txt_OutOfMarks.Text = "";
                                txtobtmrks.Text = "";
                                txtexam.Enabled = true;
                            }
                            else
                            {
                                btn_new.Text = "Save";
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong.','danger')", true);
                            }

                        }
                    }
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void btn_clr_Click(object sender, EventArgs e)
    {
        try
        {
            txtexam.SelectedIndex = 0;
            txtexam.Enabled = true;
            txt_inst_Name.Text = "";
            txt_inst_place.Text = "";
            txt_Major_sub.Text = "";
            txt_seat.Text = "";
            txt_boardUniver.Text = "";
            txtspec.Text = "";
            txtcertificate.Text = "";
            txtPassingmonth.SelectedIndex = 0;
            txtPassingyear.SelectedIndex = 0;
            txtobtmrks.Text = "";
            txt_OutOfMarks.Text = "";
            btn_new.Text = "Save";
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void PHOTO_Click(object sender, EventArgs e)
    {
        try
        {
            string student_imagequry = "select * from studentImage where stud_id='" + txt_studid.Text.Trim() + "'";
            DataTable srchdt1 = cls.fillDataTable(student_imagequry);
            if (srchdt1.Rows.Count > 0)
            {
                stud_img.ImageUrl = "";
                byte[] photoarray = new byte[64];
                photoarray = (byte[])srchdt1.Rows[0]["STUD_PHOTO"];
                string base64 = Convert.ToBase64String(photoarray);
                stud_img.ImageUrl = "data:Image/png;base64," + base64;
                //string imgg = string.Format("data:{0};base64,{1}", base64, Convert.ToBase64String(photoarray));
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void SIGN_Click(object sender, EventArgs e)
    {
        try
        {
            string student_imagequry = "select * from studentImage where stud_id='" + txt_studid.Text.Trim() + "'";
            DataTable srchdt1 = cls.fillDataTable(student_imagequry);
            if (srchdt1.Rows.Count > 0)
            {
                stud_img.ImageUrl = "";
                byte[] photoarray = new byte[64];
                photoarray = (byte[])srchdt1.Rows[0]["STUD_SING"];
                string base64 = Convert.ToBase64String(photoarray);
                stud_img.ImageUrl = "data:Image/png;base64," + base64;
                //string imgg = string.Format("data:{0};base64,{1}", base64, Convert.ToBase64String(photoarray));
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    private byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert, System.Drawing.Imaging.ImageFormat formatOfImage)
    {
        byte[] Ret;
        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                Ret = ms.ToArray();
            }
        }
        catch (Exception) { throw; }
        return Ret;
    }

    protected void BTN_SAVE_IMAGE_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_studid.Text != "")
            {



                if (edit_file_upload.HasFile || EDIT_SIGN_FILEUPLOAD.HasFile)
                {
                    string imagqury = "select * from studentImage where stud_id='" + txt_studid.Text.Trim() + "'";
                    if (edit_file_upload.HasFile)
                    {
                        byte[] file = edit_file_upload.FileBytes;
                        int tt = file.Length;
                        if (tt <= 200000)
                        {
                            System.Drawing.Image imag = System.Drawing.Image.FromStream(edit_file_upload.PostedFile.InputStream);
                            System.Data.SqlClient.SqlConnection conn = null;
                            try
                            {
                                try
                                {
                                    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                                    conn.Open();
                                    SqlCommand insertCommand = new SqlCommand("update studentImage set STUD_PHOTO=@Pic where stud_id='" + txt_studid.Text.Trim() + "'", conn);
                                    insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    queryResult = insertCommand.ExecuteNonQuery();

                                    if (edit_file_upload.HasFile && EDIT_SIGN_FILEUPLOAD.HasFile)
                                    {

                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "func", "notify('Profile Updated.','success')", true);
                                    }
                                    DataTable dt3 = cls.fillDataTable(imagqury);
                                    if (dt3.Rows.Count > 0)
                                    {
                                        byte[] photoarray = new byte[64];
                                        photoarray = (byte[])dt3.Rows[0]["STUD_PHOTO"];
                                        string base64 = Convert.ToBase64String(photoarray);
                                        stud_img.ImageUrl = "data:Image/png;base64," + base64;
                                        //string imgg = string.Format("data:{0};base64,{1}", base64, Convert.ToBase64String(photoarray));
                                    }
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            finally
                            {
                                if (conn != null)
                                    conn.Close();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "func", "notify('File Size of Profile photo should be less than 200kb','danger')", true);
                        }
                    }
                    if (EDIT_SIGN_FILEUPLOAD.HasFile)
                    {
                        if (EDIT_SIGN_FILEUPLOAD.HasFile)
                        {
                            byte[] file1 = EDIT_SIGN_FILEUPLOAD.FileBytes;
                            int tt1 = file1.Length;
                            if (tt1 <= 200000)
                            {
                                System.Drawing.Image imag_SIGN = System.Drawing.Image.FromStream(EDIT_SIGN_FILEUPLOAD.PostedFile.InputStream);
                                System.Data.SqlClient.SqlConnection conn = null;
                                try
                                {
                                    try
                                    {
                                        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                                        conn.Open();
                                        SqlCommand insertCommand = new SqlCommand("update studentImage set stud_sing=@sign_Pic where stud_id='" + txt_studid.Text.Trim() + "'", conn);
                                        insertCommand.Parameters.Add("sign_Pic", SqlDbType.Image, 0).Value = ConvertImageToByteArray(imag_SIGN, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        queryResult1 = insertCommand.ExecuteNonQuery();

                                        if (edit_file_upload.HasFile && EDIT_SIGN_FILEUPLOAD.HasFile)
                                        {

                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "func", "notify('Signature Updated','success')", true);
                                        }

                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                finally
                                {
                                    if (conn != null)
                                        conn.Close();
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "func", "notify('File Size of Sign should be less than 200kb','danger')", true);

                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Signature to upload ','danger')", true);
                        }
                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select One File to Update ','danger')", true);

                }

                if (edit_file_upload.HasFile && EDIT_SIGN_FILEUPLOAD.HasFile)
                {
                    if (queryResult1 == 1 && queryResult == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "func", "notify('Signature and Photo  Updated.','success')", true);
                    }
                    else { ScriptManager.RegisterStartupScript(this, this.GetType(), "func", "notify('something went wrong','danger')", true); }
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void txt_Nonearn_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txt_Nonearn.Text != "")
            {
                try
                {
                    txt_tot_Member.Text = "";
                    txt_tot_Member.Text = Convert.ToString(Convert.ToInt32(txt_Nonearn.Text));
                    if (txt_earning.Text != "")
                    {
                        txt_tot_Member.Text = "";
                        txt_tot_Member.Text = Convert.ToString(Convert.ToInt32(txt_earning.Text) + Convert.ToInt32(txt_Nonearn.Text));
                    }
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                if (txt_Nonearn.Text.Trim() != "" || txt_earning.Text.Trim() != "")
                {
                    txt_tot_Member.Text = "";
                    txt_tot_Member.Text = Convert.ToString(Convert.ToInt32(txt_earning.Text));
                }
                else
                {
                    txt_tot_Member.Text = "";
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void txt_earning_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txt_earning.Text != "")
            {
                try
                {
                    txt_tot_Member.Text = "";
                    txt_tot_Member.Text = Convert.ToString(Convert.ToInt32(txt_earning.Text));
                    if (txt_Nonearn.Text != "")
                    {
                        txt_tot_Member.Text = "";
                        txt_tot_Member.Text = Convert.ToString(Convert.ToInt32(txt_Nonearn.Text) + Convert.ToInt32(txt_earning.Text));

                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                txt_tot_Member.Text = "";
                txt_tot_Member.Text = Convert.ToString(Convert.ToInt32(txt_Nonearn.Text));

            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void footermodalclose_Click(object sender, EventArgs e)
    {
        try
        {
            EDIT_SIGN.ImageUrl = "~/sign.jpg";
            edit_image.ImageUrl = "~/user.png";
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void modal_cross_img_Click(object sender, EventArgs e)
    {
        try
        {
            EDIT_SIGN.ImageUrl = "~/sign.jpg";
            edit_image.ImageUrl = "~/user.png";
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

    protected void txtexam_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void modal_cross_Click(object sender, EventArgs e)
    {
        txtstd_id.Text = "";
    }
}