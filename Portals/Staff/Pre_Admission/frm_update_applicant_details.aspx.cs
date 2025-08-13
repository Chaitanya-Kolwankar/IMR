using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_update_applicant_details : System.Web.UI.Page
{
    Class1 obj1 = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["Emp_id"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                btnupdate.Enabled = false;
                btnupdate1.Enabled = false;
                btnupdate2.Enabled = false;
                btnupdate3.Enabled = false;
                btnupdt5.Enabled = false;
            }
        }

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
    }
    public void religion()
    {
        string relqury = "SELECT DISTINCT Parent FROM State_Category_details where Main='Religion'";
        obj1.fillDataTable(relqury);
        DataTable dt4 = new DataTable();
        dt4 = obj1.fillDataTable(relqury);
        ddlrel.DataSource = dt4;
        ddlrel.DataTextField = dt4.Columns["parent"].ToString();
        ddlrel.DataValueField = dt4.Columns["parent"].ToString();
        ddlrel.DataBind();
        ddlrel.Items.Insert(0, new ListItem("--Select--", ""));
    }
    public void state()
    {
        string state = "select distinct trim(Parent) as parent,UPPER(trim(Parent)) as valueparent from State_category_details where Main='State'";
        obj1.fillDataTable(state);
        DataTable dtstate = obj1.fillDataTable(state);
        ddlstate1.DataSource = dtstate;
        ddlstate1.DataTextField = dtstate.Columns["Parent"].ToString();
        ddlstate1.DataValueField = dtstate.Columns["valueparent"].ToString();

        ddlstate1.DataBind();
        ddlstate1.Items.Insert(0, new ListItem("--Select--", ""));
    }

    protected void btnsearch_Click1(object sender, EventArgs e)
    {

        try
        {
            string formno = txtformno.Text;
            string frstname = firstname.Text;
            string middlename = midname.Text;
            string moname = mothername.Text;
            string stddob = dob.Text;
            string email = emailbox.Text;
            string mob = mobno.Text;
            string other = othercont.Text;

            religion();

            if (formno == "")
            {
                clear();
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Form no.', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else
            {
                btnupdate.Enabled = true;
                btnupdate1.Enabled = true;
                btnupdate2.Enabled = true;
                btnupdate3.Enabled = true;
                btnupdt5.Enabled = true;
                string select = "select *,CONVERT(VARCHAR,DOB ,105) as birth,(COALESCE(Earning,0) + COALESCE(NonEarning,0)) as Totalern from d_adm_applicant where  Form_no ='" + formno + "'";
                DataTable dt = new DataTable();
                dt = obj1.fillDataTable(select);
                if (dt.Rows.Count == 1)
                {
                    state();
                    ddlsta();
                    fillcat();
                    religion();
                    fill_ddl_state_personal();
                    string are = dt.Rows[0]["Earning"].ToString();
                    txttotal.Text = dt.Rows[0]["Totalern"].ToString();
                    lastname.Text = dt.Rows[0]["L_name"].ToString();
                    firstname.Text = dt.Rows[0]["F_name"].ToString();
                    midname.Text = dt.Rows[0]["M_name"].ToString();
                    mothername.Text = dt.Rows[0]["Mo_name"].ToString();
                    dob.Text = dt.Rows[0]["birth"].ToString();
                    emailbox.Text = dt.Rows[0]["Email_id"].ToString();
                    mobno.Text = dt.Rows[0]["Mob_No"].ToString();
                    othercont.Text = dt.Rows[0]["Phone_No"].ToString();
                    rdgender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                    ddlblood.SelectedValue = dt.Rows[0]["blood_group"].ToString().Trim();
                    birthplace.Text = dt.Rows[0]["birth_place"].ToString().Trim();
                    if (dt.Rows[0]["Marital_status"].ToString() == "False")
                    {
                        ddlmarrystatus.SelectedValue = "0";
                    }
                    else
                    {
                        ddlmarrystatus.SelectedValue = "1";
                    }
                    domicileid.Text = dt.Rows[0]["Domicile"].ToString();
                    flattxtbox.Text = dt.Rows[0]["Address_line1"].ToString();
                    areatxtbox.Text = dt.Rows[0]["Address_line2"].ToString();
                    streettxtbox.Text = dt.Rows[0]["Address_line3"].ToString();
                    pintxtbox.Text = dt.Rows[0]["pincode"].ToString();
                    ddl_state_personal.SelectedValue = dt.Rows[0]["State"].ToString().ToUpper();
                    citytxtbox.Text = dt.Rows[0]["city"].ToString();
                    ddlsta();
                    ddlstate.SelectedValue = dt.Rows[0]["S_State"].ToString().Trim().ToUpper();
                    ddlstate_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlboard.Text = dt.Rows[0]["S_Board_name"].ToString();
                    schoolname.Text = dt.Rows[0]["S_Ins_Name"].ToString();
                    schoolplace.Text = dt.Rows[0]["S_Ins_place"].ToString();
                    if (dt.Rows[0]["S_First_Attempt"].ToString() == "False")
                    {
                        rdattempt.SelectedValue = "0";
                    }
                    else
                    {
                        rdattempt.SelectedValue = "1";
                    }
                    ddlpassyear.SelectedValue = dt.Rows[0]["S_Year"].ToString().Trim();
                    string pasmnth = dt.Rows[0]["S_Month"].ToString().Trim();
                    ddlpassmth.SelectedValue = pasmnth;
                    mksobt.Text = dt.Rows[0]["S_Mks_Obtained"].ToString();
                    outofmks.Text = dt.Rows[0]["S_Mks_OutOf"].ToString();
                    gradeobt.Text = dt.Rows[0]["S_grade"].ToString();
                    seatno.Text = dt.Rows[0]["S_seat_no"].ToString();
                    ddlstate1.SelectedValue = dt.Rows[0]["State_board"].ToString().Trim().ToUpper();

                    ddlstate1_SelectedIndexChanged(this, EventArgs.Empty);

                    ddlboard1.Text = dt.Rows[0]["Board_name"].ToString();
                    colgname.Text = dt.Rows[0]["Ins_name"].ToString();
                    colgplace.Text = dt.Rows[0]["Ins_place"].ToString();
                    if (dt.Rows[0]["firstAttempt"].ToString() == "False")
                    {
                        rdattempt1.SelectedValue = "0";
                    }
                    else
                    {
                        rdattempt1.SelectedValue = "1";
                    }
                    ddlpassyear1.SelectedValue = dt.Rows[0]["Year"].ToString().Trim();
                    string pasmnth1 = dt.Rows[0]["Month"].ToString().Trim();
                    ddlpassmth1.SelectedValue = pasmnth1;
                    mksobt1.Text = dt.Rows[0]["Mks_Obtained"].ToString();
                    outofmks1.Text = dt.Rows[0]["Mks_Outof"].ToString();
                    gradeobt1.Text = dt.Rows[0]["grade"].ToString();
                    seatno1.Text = dt.Rows[0]["Seat_No"].ToString();
                    fathername.Text = dt.Rows[0]["M_name"].ToString();
                    if (dt.Rows[0]["Father_age"].ToString() == "0")
                    {
                        fage.Text = "";
                    }
                    else
                    {
                        fage.Text = dt.Rows[0]["Father_age"].ToString();
                    }
                    fmail.Text = dt.Rows[0]["Father_emailID"].ToString();
                    fcontact.Text = dt.Rows[0]["Father_contact_No"].ToString();
                    fquali.Text = dt.Rows[0]["Father_Qualification"].ToString();
                    string focup = dt.Rows[0]["Father_Occup"].ToString();
                    focupation.SelectedValue = focup;
                    fdesg.Text = dt.Rows[0]["Father_desg"].ToString();
                    fadd.Text = dt.Rows[0]["Father_Busi_addr"].ToString();
                    mname.Text = dt.Rows[0]["Mo_name"].ToString();
                    if (dt.Rows[0]["Mother_age"].ToString() == "0")
                    {
                        mage.Text = "";
                    }
                    else
                    {
                        mage.Text = dt.Rows[0]["Mother_age"].ToString();
                    }
                    mmail.Text = dt.Rows[0]["Mother_emailID"].ToString().Trim();
                    mcontact.Text = dt.Rows[0]["Mother_contact_No"].ToString();
                    mquali.Text = dt.Rows[0]["Mother_Qualification"].ToString();
                    string mocup = dt.Rows[0]["Mother_Occup"].ToString();
                    Moccupation.SelectedValue = mocup;
                    mdesig.Text = dt.Rows[0]["Mother_desg"].ToString();
                    Madd.Text = dt.Rows[0]["Mother_Busi_addr"].ToString();
                    //////////////////////////////////
                    ddlcat.SelectedValue = dt.Rows[0]["Category"].ToString();
                    ddlcat_SelectedIndexChanged2(this, EventArgs.Empty);
                    if (dt.Rows[0]["caste"].ToString() == "--Select--" || dt.Rows[0]["caste"].ToString() == "" || dt.Rows[0]["caste"].ToString() == null || dt.Rows[0]["caste"].ToString() == "0" || dt.Rows[0]["caste"].ToString() == "NULL")
                    {
                        ddlcaste.SelectedValue = "";
                    }
                    else
                    {
                        ddlcaste.SelectedValue = dt.Rows[0]["caste"].ToString();
                    }
                    ddlphy.SelectedValue = dt.Rows[0]["Phy_handicap_Description"].ToString();
                    if (dt.Rows[0]["Religion"].ToString() != "0")
                    {
                        ddlrel.Text = dt.Rows[0]["Religion"].ToString();

                    }
                    if (dt.Rows[0]["Extra_Curricular_Activities"].ToString() == "")
                    {
                        ddlProficien.SelectedValue = "0";
                    }
                    else
                    {

                        ddlProficien.SelectedValue = dt.Rows[0]["Extra_Curricular_Activities"].ToString();
                    }
                    ddlnccnss.SelectedValue = dt.Rows[0]["is_NSS_NCC"].ToString();
                    if (dt.Rows[0]["is_Scholarship"].ToString() == "True")
                    {
                        rdbscholar.SelectedValue = "1";
                    }
                    else
                    {
                        rdbscholar.SelectedValue = "0";
                    }
                    txtearn.Text = dt.Rows[0]["earning"].ToString();
                    txtnonear.Text = dt.Rows[0]["NonEarning"].ToString();
                    txtincome.Text = dt.Rows[0]["Annual_Income"].ToString();
                    string[] arrycastcer = dt.Rows[0]["Certificate_No"].ToString().Trim().Split(new char[] { '|' });
                    if (arrycastcer.Count() > 1)
                    {
                        if (ddlcat.SelectedItem.Text != "OPEN" && ddlcat.SelectedItem.Text != "TFWS")
                        {
                            if (ddlcat.SelectedItem.Text == "EBC" || ddlcat.SelectedItem.Text == "EWS" || ddlcat.SelectedItem.Text == "SEBC")
                            {
                                if (arrycastcer.Count() == 2)
                                {
                                    txt_income_date.Text = arrycastcer[0].ToString().Trim();
                                    txt_income_cer.Text = arrycastcer[1].ToString().Trim();
                                }
                                else
                                {
                                    txt_income_date.Text = arrycastcer[2].ToString().Trim();
                                    txt_income_cer.Text = arrycastcer[3].ToString().Trim();
                                }

                            }
                            else
                            {
                                certibox.Text = arrycastcer[0].ToString().Trim();
                                txt_cast_date.Text = arrycastcer[1].ToString().Trim();
                                txt_income_cer.Text = arrycastcer[2].ToString().Trim();
                                txt_income_date.Text = arrycastcer[3].ToString().Trim();
                            }
                        }
                    }
                    ddl_special_category.SelectedValue = dt.Rows[0]["Other_criteria"].ToString().Trim();
                    ddl_minority.SelectedValue = dt.Rows[0]["subjects"].ToString().Trim();
                    string[] arryaadhra = dt.Rows[0]["Remark"].ToString().Trim().Split(new char[] { '|' });
                    if (arryaadhra.Count() > 1)
                    {
                        txt_aadhar.Text = arryaadhra[0].ToString().Trim();
                        txt_dte_application.Text = arryaadhra[1].ToString().Trim();
                    }
                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Form Number !', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                    txtformno.Text = "";
                    clear();
                }
            }
        }
        catch (Exception d)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + d.Message + "', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            clear();
        }
        catch (Exception d)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + d.Message + "', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string mail = emailbox.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);

            bool mail2 = regex.IsMatch(mail);
            string formno = txtformno.Text.Trim();

            if (firstname.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter First Name', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            if (firstname.Text.Trim().Length < 2)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Minimum 2 Character for First Name', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (midname.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Middle  Name', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (midname.Text.Trim().Length < 2)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Minimum 2 Character for Middle Name', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (mothername.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Mother Name', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (mothername.Text.Trim().Length < 2)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Minimum 2 Character for Mother Name', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (mobno.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Mobile No', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (mobno.Text.Trim().Length < 10)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Mobile No. Should Be Of 10 Digits', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (othercont.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Other Mobile No', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (othercont.Text.Trim().Length < 10)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify(' Other Mobile No Should Be Of 10 Digits', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (dob.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter D.O.B', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (emailbox.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Email ID', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (!mail2)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Email', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else
            {
                String updt = ("update d_adm_applicant set F_name='" + firstname.Text.Trim().Replace("'", "''") + "',M_name='" + midname.Text.Trim().Replace("'", "''") + "',L_name='" + lastname.Text.Trim().Replace("'", "''") + "',Mo_name='" + mothername.Text.Trim().Replace("'", "''") + "',DOB='" + dob.Text + "',Email_id='" + mail.Trim().Replace("'", "''") + "',Mob_No='" + mobno.Text.Trim() + "',Phone_No='" + othercont.Text.Trim() + "' where Form_no='" + formno + "'");
                bool chk = obj1.DMLqueries(updt);
                if (chk)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updated Successfully', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + d.Message + "', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
        }//}
    }

    protected void btnupdate1_Click1(object sender, EventArgs e)
    {

        try
        {
            string formno = txtformno.Text.Trim();
            if (birthplace.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Place of Birth', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (citytxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter City', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

            }
            else if (ddlmarrystatus.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Maritial Status', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (flattxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Flat No. / Building', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (areatxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Area', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (streettxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Street', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (pintxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Pincode', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (pintxtbox.Text.Trim().Length < 6)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Pincode', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (ddl_state_personal.SelectedValue.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter state', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else
            {
                String updt1 = ("update d_adm_applicant set Gender='" + rdgender.SelectedValue + "',blood_group='" + ddlblood.SelectedValue.Trim().Replace("0", null) + "',birth_place='" + birthplace.Text.Trim().Replace("'", "''") + "',Marital_status='" + ddlmarrystatus.SelectedValue + "',Domicile='" + domicileid.Text.Trim().Replace("'", "''") + "',Address_line1='" + flattxtbox.Text.Trim().Replace("'", "''") + "',Address_line2='" + areatxtbox.Text.Trim().Replace("'", "''") + "',Address_line3='" + streettxtbox.Text.Trim().Replace("'", "''") + "',pincode='" + pintxtbox.Text.Trim() + "',State='" + ddl_state_personal.SelectedValue.Trim() + "',city='" + citytxtbox.Text.Trim().Replace("'", "''") + "' where Form_no='" + formno + "'");


                bool chk1 = obj1.DMLqueries(updt1);

                if (chk1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updated Successfully', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + d.Message + "', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
        }
    }

    protected void btnupdate2_Click(object sender, EventArgs e)
    {
        try
        {
            string formno = txtformno.Text.Trim();
            string strgrad = "select * from adm_applicant_registration where formno='" + formno + "' and group_id='GRP040' and del_flag=0";
            DataSet dsgrad = obj1.fillDataset(strgrad);
            if (dsgrad.Tables[0].Rows.Count > 0)
            {
                if (ddlstate.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select State in S.S.C.', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (ddlboard.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select board in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

                }
                else if (schoolname.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter  School Name in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

                }
                else if (schoolplace.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter  School Place in SSC.', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

                }
                else if (ddlpassyear.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter  Passing Year in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (ddlpassmth.SelectedIndex == 0)
                {

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter  Passing Month in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (seatno.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Seat no. in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (seatno.Text.Trim().Length < 7)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Seat No. Must Be Of 7 Digit for SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (mksobt.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Marks obtained in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (outofmks.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Out of Marks in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

                }
                else if (Convert.ToInt32(mksobt.Text.Trim()) > Convert.ToInt32(outofmks.Text.Trim()))
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Obtained Marks Should be less than out of Marks for SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                    mksobt.Text = "";
                    outofmks.Text = "";

                }
                else if (gradeobt.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter grade of SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                //=================hsc
                else if (ddlstate1.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select State of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (ddlboard1.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select board of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (colgname.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter College Name of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (colgplace.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter College Place of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (ddlpassyear1.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Passing Year of  HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (ddlpassmth1.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Passing Month of  HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (seatno1.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Seat of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (seatno1.Text.Trim().Length < 7)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Seat No. Must Be Of 7 Digit for HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (mksobt1.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Marks Obtained of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (outofmks1.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Out Marks Obtained of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (Convert.ToInt32(mksobt1.Text.Trim()) > Convert.ToInt32(outofmks1.Text.Trim()))
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Obtained Marks Should be less than out of Marks for HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                    mksobt1.Text = "";
                    outofmks1.Text = "";

                }
                else if (gradeobt1.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Grade Obtained of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                //===================Graduation
                else
                {
                    int diploma = 0;
                    string updt2 = ("update d_adm_applicant set S_State='" + ddlstate.SelectedValue + "',S_Board_name='" + ddlboard.Text + "',S_Ins_Name='" + schoolname.Text.Trim().Replace("'", "''") + "',S_Ins_place='" + schoolplace.Text.Trim().Replace("'", "''") + "',S_First_Attempt='" + rdattempt.SelectedValue + "',S_Year='" + ddlpassyear.Text + "',S_Month='" + ddlpassmth.Text + "',S_Mks_Obtained='" + mksobt.Text + "',S_Mks_OutOf='" + outofmks.Text.Trim() + "',S_grade='" + gradeobt.Text.Trim() + "',S_seat_no='" + seatno.Text.Trim().Replace("'", "''") + "',State_board='" + ddlstate1.SelectedValue + "',Board_name='" + ddlboard1.Text + "',Ins_name='" + colgname.Text.Trim().Replace("'", "''") + "',Ins_place='" + colgplace.Text.Trim().Replace("'", "''") + "',firstAttempt='" + rdattempt1.SelectedValue + "',Year='" + ddlpassyear1.Text + "',Month='" + ddlpassmth1.Text + "',Mks_Obtained='" + mksobt1.Text + "',Mks_Outof='" + outofmks1.Text + "',grade='" + gradeobt1.Text.Trim() + "',Seat_No='" + seatno1.Text.Trim().Replace("'", "''") + "',diploma_holder=" + diploma + " where Form_no='" + formno + "' ");

                    bool chk2 = obj1.DMLqueries(updt2);

                    if (chk2)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updated Successfully', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                    }
                }
            }
            else
            {
                if (ddlstate.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select State in S.S.C.', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (ddlboard.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Board in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

                }
                else if (schoolname.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter  School Name in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

                }
                else if (schoolplace.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter  School Place in SSC.', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

                }
                else if (ddlpassyear.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Passing Year in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (ddlpassmth.SelectedIndex == 0)
                {

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Passing Month in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (seatno.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Seat no. in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (seatno.Text.Trim().Length < 7)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Seat No. Must Be Of 7 Digit for SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (mksobt.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Marks obtained in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (outofmks.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Out of Marks in SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

                }
                else if (Convert.ToInt32(mksobt.Text.Trim()) > Convert.ToInt32(outofmks.Text.Trim()))
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Obtained marks should be less than out of marks', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                    mksobt.Text = "";
                    outofmks.Text = "";

                }
                else if (gradeobt.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter grade of SSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                //=================hsc
                else if (ddlstate1.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select State of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (ddlboard1.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select board of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (colgname.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter College Name of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (colgplace.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter College Place of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (ddlpassyear1.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Passing Year of  HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (ddlpassmth1.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Passing Month of  HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (seatno1.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Seat of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (seatno1.Text.Trim().Length < 7)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Seat No. Must Be Of 7 Digit for HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (mksobt1.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Marks Obtained of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (outofmks1.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Out Marks Obtained of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                else if (Convert.ToInt32(mksobt1.Text.Trim()) > Convert.ToInt32(outofmks1.Text.Trim()))
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Obtained marks should be less than out of marks', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                    mksobt1.Text = "";
                    outofmks1.Text = "";

                }
                else if (gradeobt1.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Grade Obtained of HSC', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
                //===================Graduation
                else
                {
                    int diploma = 0;

                    string updt2 = ("update d_adm_applicant set S_State='" + ddlstate.SelectedValue + "',S_Board_name='" + ddlboard.Text + "',S_Ins_Name='" + schoolname.Text.Trim().Replace("'", "''") + "',S_Ins_place='" + schoolplace.Text.Trim().Replace("'", "''") + "',S_First_Attempt='" + rdattempt.SelectedValue + "',S_Year='" + ddlpassyear.Text + "',S_Month='" + ddlpassmth.Text + "',S_Mks_Obtained='" + mksobt.Text + "',S_Mks_OutOf='" + outofmks.Text.Trim() + "',S_grade='" + gradeobt.Text.Trim() + "',S_seat_no='" + seatno.Text.Trim().Replace("'", "''") + "',State_board='" + ddlstate1.SelectedValue + "',Board_name='" + ddlboard1.Text + "',Ins_name='" + colgname.Text.Trim().Replace("'", "''") + "',Ins_place='" + colgplace.Text.Trim().Replace("'", "''") + "',firstAttempt='" + rdattempt1.SelectedValue + "',Year='" + ddlpassyear1.Text + "',Month='" + ddlpassmth1.Text + "',Mks_Obtained='" + mksobt1.Text + "',Mks_Outof='" + outofmks1.Text + "',grade='" + gradeobt1.Text.Trim() + "',Seat_No='" + seatno1.Text.Trim() + "',diploma_holder=" + diploma + " where Form_no='" + formno + "' ");
                    bool chk2 = obj1.DMLqueries(updt2);

                    if (chk2)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updated Successfully', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                    }
                }
            }
        }
        catch (Exception d)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + d.Message + "', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
        }
    }

    protected void btnupdate3_Click(object sender, EventArgs e)
    {
        try
        {
            string fmails = fmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool fmail2 = regex.IsMatch(fmails);

            string mmails = mmail.Text;
            Regex regexm = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool mmail2 = regexm.IsMatch(mmails);

            string formno = txtformno.Text;
            if (fathername.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Father Name', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

            }
            else if (fmail.Text != "" && !fmail2)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Father Email', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (fcontact.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Fathers Contact No.', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

            }
            else if (fcontact.Text.Trim().Length < 10)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Father Contact', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (focupation.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select  Fathers  Occupation', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }

            else if (mname.Text.Trim() == "")
            {

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Mother Name', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (mmail.Text != "" && !mmail2)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Mother Email', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (mcontact.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Mothers Contact no', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (mcontact.Text.Trim().Length < 10)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Mother Contact', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (Moccupation.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Mothers Occupation', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

            }
            else
            {
                string updt3 = ("update d_adm_applicant set M_name='" + fathername.Text.Trim().Replace("'", "''") + "',Father_age='" + fage.Text.Trim() + "',Father_emailID='" + fmail.Text.Trim().Replace("'", "''") + "',Father_contact_No='" + fcontact.Text.Trim() + "',Father_Qualification='" + fquali.Text.Trim().Replace("'", "''") + "',Father_Occup='" + focupation.SelectedValue.ToString() + "',Father_desg='" + fdesg.Text.Trim().Replace("'", "''") + "',Father_Busi_addr='" + fadd.Text.Trim().Replace("'", "''") + "',Mo_name='" + mname.Text.Trim().Replace("'", "''") + "',Mother_age='" + mage.Text.Trim() + "',Mother_emailID='" + mmail.Text.Trim().Replace("'", "''") + "',Mother_contact_No='" + mcontact.Text.Trim() + "',Mother_Qualification='" + mquali.Text.Trim().Replace("'", "''") + "',Mother_Occup='" + Moccupation.SelectedValue.ToString() + "',Mother_desg='" + mdesig.Text.Trim().Replace("'", "''") + "',Mother_Busi_addr='" + Madd.Text.Trim().Replace("'", "''") + "'  where Form_no='" + formno + "'");

                bool chk3 = obj1.DMLqueries(updt3);
                if (chk3)
                {

                    //int father_age = Convert.ToInt32(fage.Text);
                    //int mothr_age = Convert.ToInt32(mage.Text);

                    //if (father_age >= 21 && father_age <= 100)
                    //{

                    //    if (mothr_age >= 21 && mothr_age <= 100)
                    //    {
                    //        if (chk3)
                    //        {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updated Successfully', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                    //        }
                    //        else
                    //        {
                    //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Something Went Wrong', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter  proper Mother age', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                    //    }


                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter  proper Father age', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);



                    //}
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something went wrong', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
            }
        }
        catch (Exception d)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + d.Message + "', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
        }
    }

    protected void btnupdt5_Click(object sender, EventArgs e)
    {
        try
        {
            string formno = txtformno.Text;
            string totEar = txtearn.Text;

            if (ddlcat.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Category', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                return;
            }
            if (ddlcat.SelectedItem.Text != "OPEN" && ddlcat.SelectedItem.Text != "TFWS")
            {
                if (ddlcat.SelectedItem.Text != "EBC" && ddlcat.SelectedItem.Text != "EWS" && ddlcat.SelectedItem.Text != "SEBC")
                {
                    if (ddlcaste.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Caste', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                    else if (certibox.Text.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Caste Cast Validity/Receipt No', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                    else if (txt_cast_date.Text.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Caste Certificate Date', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                    else if (txt_income_cer.Text.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Income Certificate/Receipt No', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                    else if (txt_income_date.Text.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Income Certificate Date', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
                else
                {
                    if (txt_income_cer.Text.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Income Certificate No', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                    else if (txt_income_date.Text.Trim() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Income Certificate date', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                        return;
                    }
                }
            }
            if (ddlrel.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Religion', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (ddlnccnss.SelectedValue == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Member of NCC/NSS', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (txtearn.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Earning', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (txtnonear.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter non Earning', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);

            }
            else if (txtincome.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Year Income', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (txt_aadhar.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Aadhar Card No', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (txt_aadhar.Text.Trim().Length < 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Invalid Aadhar Card No', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else if (txt_dte_application.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter DTE / ARA Application ID', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
            }
            else
            {
                string certificat = "";
                if (certibox.Text.Trim() != "" && txt_cast_date.Text.Trim() != "" && txt_income_cer.Text.Trim() != "" && txt_income_date.Text.Trim() != "")
                {
                    certificat = certibox.Text.Trim() + '|' + txt_cast_date.Text.Trim() + '|' + txt_income_cer.Text.Trim() + '|' + txt_income_date.Text.Trim();
                }
                else if (certibox.Text.Trim() != "" && txt_cast_date.Text.Trim() != "")
                {
                    certificat = certibox.Text.Trim() + '|' + txt_cast_date.Text.Trim();
                }
                else if (txt_income_cer.Text.Trim() != "" && txt_income_date.Text.Trim() != "")
                {
                    certificat = txt_income_cer.Text.Trim() + '|' + txt_income_date.Text.Trim();
                }

                string update5 = "update d_adm_applicant set Category='" + ddlcat.SelectedItem.ToString() + "', caste='" + ddlcaste.SelectedItem.Text.ToString().Replace("--Select--", null) + "',Religion='" + ddlrel.SelectedItem.ToString() + "',Phy_handicap_Description='" + ddlphy.SelectedItem.ToString() + "',Extra_Curricular_Activities='" + ddlProficien.SelectedValue.ToString() + "',is_NSS_NCC='" + ddlnccnss.SelectedItem.ToString() + "',is_Scholarship='" + rdbscholar.SelectedValue + "',Earning='" + txtearn.Text + "',NonEarning='" + txtnonear.Text + "',Annual_Income='" + txtincome.Text + "',Remark='" + txt_aadhar.Text + "'+'|'+'" + txt_dte_application.Text.Replace("'", "''") + "',subjects='" + ddl_minority.SelectedValue + "',Certificate_No='" + certificat.Replace("'", "''") + "',Other_criteria='" + ddl_special_category.SelectedValue + "' where Form_no='" + formno + "'";

                bool chk4 = obj1.DMLqueries(update5);
                if (chk4)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updated Successfully', { color: '#fff', background: '#04701f', blur: 0.2, delay: 0 });", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Update Unsuccessfull', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + d.Message + "', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
        }
    }
    protected void ddlcaste_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
       
    protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
    {

       

    }
    protected void ddlcat_SelectedIndexChanged1(object sender, EventArgs e)
    {
    }
    protected void ddlcat_SelectedIndexChanged2(object sender, EventArgs e)
    {
        try
        {
            string castqury = "SELECT DISTINCT child FROM State_Category_details where parent='" + ddlcat.SelectedValue.ToString() + "'";
            obj1.fillDataTable(castqury);
            DataTable dt2 = new DataTable();
            dt2 = obj1.fillDataTable(castqury);
            if (dt2.Rows.Count == 0)
            {
                ddlcaste.Items.Clear();
            }
            else
            {
                ddlcaste.DataSource = dt2;
                ddlcaste.DataTextField = dt2.Columns["child"].ToString();
                ddlcaste.DataValueField = dt2.Columns["child"].ToString();
                ddlcaste.DataBind();
                ddlcaste.Items.Insert(0, new ListItem("--Select--", ""));
                certibox.Enabled = true;
                txt_cast_date.Enabled = true;
                txt_income_cer.Enabled = true;
                txt_income_date.Enabled = true;

                certibox.Text = "";
                txt_cast_date.Text = "";
                txt_income_cer.Text = "";
                txt_income_date.Text = "";
            }
            if (ddlcat.SelectedItem.Text == "OPEN" || ddlcat.SelectedItem.Text == "TFWS")
            {
                certibox.Enabled = false;
                txt_cast_date.Enabled = false;
                txt_income_cer.Enabled = false;
                txt_income_date.Enabled = false;
            }
            else if (ddlcat.SelectedItem.Text == "EBC" || ddlcat.SelectedItem.Text == "EWS" || ddlcat.SelectedItem.Text == "SEBC")
            {
                certibox.Enabled = false;
                txt_cast_date.Enabled = false;
            }
            else
            {
                ddlcaste.Enabled = true;
                certibox.Enabled = true;
                txt_cast_date.Enabled = true;
                txt_income_cer.Enabled = true;
                txt_income_date.Enabled = true;
            }

        }
        catch (Exception d)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + d.Message + "', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
        }
    }
    protected void ddlstate1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string board = "select  Child from State_category_details where Main='State' and Parent='" + ddlstate1.SelectedItem.ToString() + "'";
            obj1.fillDataTable(board);
            DataTable dtbo = obj1.fillDataTable(board);
            ddlboard1.DataSource = dtbo;
            ddlboard1.DataTextField = dtbo.Columns["Child"].ToString();
            ddlboard1.DataValueField = dtbo.Columns["Child"].ToString();
            ddlboard1.DataBind();
            ddlboard1.Items.Insert(0, new ListItem("--Select--", "na"));
        }
        catch (Exception d)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + d.Message + "', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
        }
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)     //ssc
    {
        try
        {
            string board = "select  Child from State_category_details where Main='State' and Parent='" + ddlstate.SelectedValue.ToString() + "'";
            obj1.fillDataTable(board);
            DataTable dtbo = obj1.fillDataTable(board);
            ddlboard.DataSource = dtbo;
            ddlboard.DataTextField = dtbo.Columns["Child"].ToString();
            ddlboard.DataValueField = dtbo.Columns["Child"].ToString();

            ddlboard.DataBind();
            ddlboard.Items.Insert(0, new ListItem("--Select--", ""));
        }
        catch (Exception d)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + d.Message + "', { color: '#fff', background: '#d9534f', blur: 0.2, delay: 0 });", true);
        }
    }
    public void ddlsta()
    {
        string state = "select distinct trim(Parent) as parent,UPPER(trim(Parent)) as valueparent from State_category_details where Main='State'";
        obj1.fillDataTable(state);
        DataTable dtstate = obj1.fillDataTable(state);
        ddlstate.DataSource = dtstate;
        ddlstate.DataTextField = dtstate.Columns["Parent"].ToString();
        ddlstate.DataValueField = dtstate.Columns["valueparent"].ToString();
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, new ListItem("--Select--", ""));
    }
    public void fillcat()
    {
        string catfillquery = "SELECT DISTINCT Parent FROM State_Category_details where Main ='Reserved Category'";
        obj1.fillDataTable(catfillquery);
        DataTable dt1 = new DataTable();
        dt1 = obj1.fillDataTable(catfillquery);
        ddlcat.DataSource = dt1;
        ddlcat.DataTextField = dt1.Columns["parent"].ToString();
        ddlcat.DataValueField = dt1.Columns["parent"].ToString();
        ddlcat.DataBind();
        ddlcat.Items.Insert(0, new ListItem("--Select--", ""));
        //ddlcat.Items.Insert(1, new ListItem("OPEN", "OPEN"));
        //ddl_Faculty.Items.Insert(0, new ListItem("--Select--", "na"));
    }

    public void clear()
    {
        lastname.Text = "";
        txtformno.Text = "";
        txtearn.Text = "";
        txtincome.Text = "";
        txtnonear.Text = "";
        txttotal.Text = "";
        areatxtbox.Text = "";
        citytxtbox.Text = "";
        flattxtbox.Text = "";
        pintxtbox.Text = "";
        ddl_state_personal.ClearSelection();
        streettxtbox.Text = "";
        firstname.Text = "";
        midname.Text = "";
        mothername.Text = "";
        mobno.Text = "";
        othercont.Text = "";
        dob.Text = "";
        emailbox.Text = "";
        rdgender.ClearSelection();
        ddlblood.ClearSelection();
        birthplace.Text = "";
        domicileid.Text = "";
        ddlstate.ClearSelection();
        ddlboard.ClearSelection();
        schoolname.Text = "";
        schoolplace.Text = "";
        rdattempt.ClearSelection();
        ddlpassyear.ClearSelection();
        ddlpassmth.ClearSelection();
        seatno.Text = "";
        mksobt.Text = "";
        outofmks.Text = "";
        gradeobt.Text = "";
        ddlstate1.ClearSelection();
        ddlboard1.ClearSelection();
        colgname.Text = "";
        colgplace.Text = "";
        rdattempt1.ClearSelection();
        ddlpassyear1.ClearSelection();
        ddlpassmth1.ClearSelection();
        seatno1.Text = "";
        mksobt1.Text = "";
        outofmks1.Text = "";
        gradeobt1.Text = "";
        fathername.Text = "";
        fage.Text = "";
        fmail.Text = "";
        fcontact.Text = "";
        fquali.Text = "";
        focupation.ClearSelection();
        fdesg.Text = "";
        fadd.Text = "";
        mname.Text = "";
        mage.Text = "";
        mmail.Text = "";
        mcontact.Text = "";
        mquali.Text = "";
        Moccupation.ClearSelection();
        mdesig.Text = "";
        Madd.Text = "";
        ddlcat.ClearSelection();
        ddlcaste.ClearSelection();
        certibox.Text = "";
        ddlrel.ClearSelection();
        ddlphy.ClearSelection();
        ddlProficien.ClearSelection();
        ddlnccnss.ClearSelection();
        rdbscholar.ClearSelection();
        certibox.Text = "";
        txt_cast_date.Text = "";
        txt_income_date.Text = "";
        txt_income_cer.Text = "";
        txt_aadhar.Text = "";
        txt_dte_application.Text = "";
        ddl_minority.ClearSelection();
        ddl_special_category.ClearSelection();
        btnupdate.Enabled = false;
        btnupdate1.Enabled = false;
        btnupdate2.Enabled = false;
        btnupdate3.Enabled = false;
        btnupdt5.Enabled = false;
        ddlmarrystatus.ClearSelection();
    }
   
    public void fill_ddl_state_personal()
    {
        string state = "select distinct trim(Parent) as parent,UPPER(trim(Parent)) as valueparent from State_category_details where Main='State'";
        obj1.fillDataTable(state);
        DataTable dtstate = obj1.fillDataTable(state);
        ddl_state_personal.DataSource = dtstate;
        ddl_state_personal.DataTextField = dtstate.Columns["Parent"].ToString();
        ddl_state_personal.DataValueField = dtstate.Columns["valueparent"].ToString();
        ddl_state_personal.DataBind();
        ddl_state_personal.Items.Insert(0, new ListItem("--Select--", ""));
    }

    protected void txtnonear_TextChanged(object sender, EventArgs e)
    {
        if (txtnonear.Text.Trim() == "" || txtearn.Text.Trim() == "")
        {
            txttotal.Text = "";
        }
        else
        {
            int add = Convert.ToInt32(txtearn.Text.Trim()) + Convert.ToInt32(txtnonear.Text.Trim());
            txttotal.Text = "";

            txttotal.Text = add.ToString();
        }
    }
}