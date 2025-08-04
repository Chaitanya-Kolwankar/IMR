using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class searchstudent : System.Web.UI.Page
{

    Class1 obj1 = new Class1();

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
                btnupdate.Enabled = false;
                btnupdate1.Enabled = false;
                btnupdate2.Enabled = false;
                btnupdate3.Enabled = false; btnupdt5.Enabled = false;

               
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
        ddlrel.DataTextField = dt4.Columns["parent"].ToString().ToUpper();
        ddlrel.DataValueField = dt4.Columns["parent"].ToString().ToUpper();
        
        ddlrel.DataBind();
        ddlrel.Items.Insert(0, new ListItem("--Select--", ""));

    }
    public void state()
    {
        string state = "select distinct trim(upper(Parent)) as parent from State_category_details where Main='State'";
        obj1.fillDataTable(state);
        DataTable dtstate = obj1.fillDataTable(state);
        ddlstate1.DataSource = dtstate;
        ddlstate1.DataTextField = dtstate.Columns["Parent"].ToString().ToUpper();
        ddlstate1.DataValueField = dtstate.Columns["Parent"].ToString().ToUpper();
        
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
                btnupdate.Enabled = false;
                btnupdate1.Enabled = false;
                btnupdate2.Enabled = false;
                btnupdate3.Enabled = false; btnupdt5.Enabled = false;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Form no.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else
            {
                //string formnumber = Session["formno"].ToString();
                //string rdm = rdmale
                btnupdate.Enabled = true;
                btnupdate1.Enabled = true;
                btnupdate2.Enabled = true;
                btnupdate3.Enabled = true;
                btnupdt5.Enabled = true;

                //string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                string select = "select *,CONVERT(VARCHAR,DOB ,105) as birth from d_adm_applicant where  Form_no ='" + formno + "'";

                DataTable dt = new DataTable();
                //string form = dt.Rows[0]["Form_no"].ToString(); emp_fname=@fname
                //(form == formno)
                dt = obj1.fillDataTable(select);
                if (dt.Rows.Count == 1)
                {
                    //collap1.Attributes.Add("class", "show");
                    state();
                    ddlsta();
                    fillcat();
                    int Ear = Convert.ToInt32(dt.Rows[0]["Earning"]);
                    //Ear = Convert.ToInt32(txtearn.Text);
                    //txtearn.Text = Ear.ToString();
                    int noEar = Convert.ToInt32(dt.Rows[0]["NonEarning"]);
                    // noEar =Convert.ToInt32( txtnonear.Text);
                    // txtnonear.Text = noEar.ToString();

                    // int total = Ear + noEar;
                    //txttotal.Text = total.ToString();
                    int total = Ear + noEar;
                    txttotal.Text = total.ToString();
                    lastname.Text = dt.Rows[0]["L_name"].ToString();
                    firstname.Text = dt.Rows[0]["F_name"].ToString();
                    midname.Text = dt.Rows[0]["M_name"].ToString();
                    mothername.Text = dt.Rows[0]["Mo_name"].ToString();
                    dob.Text = dt.Rows[0]["birth"].ToString();
                    emailbox.Text = dt.Rows[0]["Email_id"].ToString();
                    mobno.Text = dt.Rows[0]["Mob_No"].ToString();
                    othercont.Text = dt.Rows[0]["Phone_No"].ToString();
                    //if (dt.Rows[0]["Gender"].ToString() == "False")
                    //{
                    //    rdgender.SelectedValue = "0";
                    //}
                    //else 
                    //{
                    //    rdgender.SelectedValue = "1";
                    //}
                    rdgender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                    //bool gen = false;
                    //if (gen == true)
                    //{
                    //    rdgender.Checked = gen;
                    //}

                    ddlblood.SelectedValue = dt.Rows[0]["blood_group"].ToString().Trim();
                    birthplace.Text = dt.Rows[0]["birth_place"].ToString().Trim();
                    if (dt.Rows[0]["Marital_status"].ToString() == "Unmarried")
                    {
                        ddlmarrystatus.SelectedValue = "0";
                    }
                    else if (dt.Rows[0]["Marital_status"].ToString() == "Married")
                    {
                        ddlmarrystatus.SelectedValue = "1";
                    }

                    domicileid.Text = dt.Rows[0]["Domicile"].ToString();
                    flattxtbox.Text = dt.Rows[0]["Address_line1"].ToString();
                    areatxtbox.Text = dt.Rows[0]["Address_line2"].ToString();
                    streettxtbox.Text = dt.Rows[0]["Address_line3"].ToString();
                    pintxtbox.Text = dt.Rows[0]["pincode"].ToString();
                    statetxtbox.Text = dt.Rows[0]["State"].ToString();
                    citytxtbox.Text = dt.Rows[0]["city"].ToString();

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
                    // rdattempt.SelectedValue = dt.Rows[0]["S_First_Attempt"].ToString();
                    ddlpassyear.SelectedValue = dt.Rows[0]["S_Year"].ToString().Trim();
                    string pasmnth = dt.Rows[0]["S_Month"].ToString().Trim();
                    ddlpassmth.SelectedValue = pasmnth;
                    //ddlpassmth.Items.FindByText(pasmnth).Selected = true;
                    //ddlpassmth.SelectedItem.Text = dt.Rows[0]["S_Month"].ToString().Trim();
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
                    // rdattempt1.SelectedValue = dt.Rows[0]["firstAttempt"].ToString();


                    ddlpassyear1.SelectedValue = dt.Rows[0]["Year"].ToString().Trim();

                    string pasmnth1 = dt.Rows[0]["Month"].ToString().Trim();
                    ddlpassmth1.SelectedValue = pasmnth1;
                    //  ddlpassmth1.SelectedItem.Text = dt.Rows[0]["Month"].ToString();
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
                    // focupation.SelectedItem.Text = dt.Rows[0]["Father_Occup"].ToString();
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
                    // Moccupation.SelectedItem.Text = dt.Rows[0]["Mother_Occup"].ToString();
                    mdesig.Text = dt.Rows[0]["Mother_desg"].ToString();
                    Madd.Text = dt.Rows[0]["Mother_Busi_addr"].ToString();

                    //////////////////////////////////

                    ddlcat.Text = dt.Rows[0]["Category"].ToString();
                    ddlcat_SelectedIndexChanged2(this, EventArgs.Empty);
                    string castfillquery = "SELECT DISTINCT child FROM State_Category_details where parent='" + ddlcat.SelectedItem.ToString() + "'";
                    obj1.fillDataTable(castfillquery);
                    DataTable dt12 = new DataTable();
                    dt12 = obj1.fillDataTable(castfillquery);
                    
                    ddlcaste.DataTextField = dt12.Columns["child"].ToString();
                    ddlcaste.DataValueField = dt12.Columns["child"].ToString();
                    ddlcaste.DataSource = dt12;
                    ddlcaste.DataBind();

                    ddlcaste.Items.Insert(0, new ListItem("--Select--", "na"));

                    if (dt.Rows[0]["caste"].ToString() == "--Select--" || dt.Rows[0]["caste"].ToString() == "" || dt.Rows[0]["caste"].ToString() == null)
                    {
                        ddlcaste.SelectedIndex = 0;
                    }
                    else
                    {
                        if (dt.Rows[0]["caste"].ToString() != "NULL" && dt.Rows[0]["caste"].ToString() == null)
                        {
                            ///error
                            //ddlcaste.SelectedValue = dt.Rows[0]["caste"].ToString();
                            ddlcaste.SelectedValue = dt.Rows[0]["caste"].ToString();
                        }


                    }
                    ddlphy.SelectedValue = dt.Rows[0]["Phy_handicap_Description"].ToString();

                    certibox.Text = dt.Rows[0]["Certificate_No"].ToString();
                    //if (dt.Rows[0]["Religion"].ToString() == "" || dt.Rows[0]["Religion"].ToString() == "--Select--")
                    //{
                    //    ddlrel.SelectedIndex =
                    //    ddlrel.Items.IndexOf(ddlrel.Items.FindByText("--Select--"));
                    //}
                    //else if (dt.Rows[0]["Religion"].ToString() != null)f
                    //{
                    //     ddlrel.SelectedValue= dt.Rows[0]["Religion"].ToString();
                    //}

                    if (dt.Rows[0]["Religion"].ToString() != "0")
                    {
                        ddlrel.Text = dt.Rows[0]["Religion"].ToString().ToUpper();

                    }

                    //religion
                    ddlcaste.SelectedItem.Text = dt.Rows[0]["caste"].ToString();
                    //   ddlphy.Text = dt.Rows[0]["Phy_handicap_Description"].ToString();



                    if (dt.Rows[0]["Extra_Curricular_Activities"].ToString() == "")
                    {
                        ddlProficien.SelectedValue = "0";
                    }
                    else
                    {

                        ddlProficien.SelectedValue = dt.Rows[0]["Extra_Curricular_Activities"].ToString();
                    }

                    ddlnccnss.Text = dt.Rows[0]["is_NSS_NCC"].ToString();
                    if (dt.Rows[0]["is_Scholarship"].ToString() == "True")
                    {
                        rdbscholar.SelectedValue = "1";
                    }
                    else
                    {
                        rdbscholar.SelectedValue = "0";
                    }
                    //rdbscholar.SelectedValue = dt.Rows[0]["is_Scholarship"].ToString();
                    txtearn.Text = dt.Rows[0]["earning"].ToString();
                    txtnonear.Text = dt.Rows[0]["NonEarning"].ToString();
                    txtincome.Text = dt.Rows[0]["Annual_Income"].ToString();



                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Invalid Student ID !', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                    txtformno.Text = "";
                }
            }
        }
        catch (Exception d)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('"+d.Message+"', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(Page.Request.RawUrl, false);
        }
        catch (Exception d)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string mail = emailbox.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
         
            bool mail2 = regex.IsMatch(mail);
            //if (mail.Contains("@") && mail.Contains(".")) { 
            //}
            //else
            //{
            //if (!mail2)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Invalid Email', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            //}
            //if ()
            //{ }
            string formno = txtformno.Text.Trim();
            if (firstname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter First Name.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (midname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Middle  Name.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (mothername.Text.Trim() == "")

            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Mother Name.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (dob.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter D.O.B', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (emailbox.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Email ID', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (!mail2)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Invalid Email', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (mobno.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Mobile No.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (othercont.Text.Trim() == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Other Mobile No.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else
            {
                String updt = ("update d_adm_applicant set F_name='" + firstname.Text.Trim().Replace("'", "''") + "',M_name='" + midname.Text.Trim().Replace("'", "''") + "',L_name='" + lastname.Text.Trim().Replace("'", "''") + "',Mo_name='" + mothername.Text.Trim().Replace("'", "''") + "',DOB='"+ dob.Text.Trim()+ "',Email_id='" + mail.Trim().Replace("'", "''") + "',Mob_No='" + mobno.Text.Trim() + "',Phone_No='" + othercont.Text.Trim() + "' where Form_no='" + formno + "'");


                bool chk = obj1.DMLqueries(updt);

                if (chk)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Updated Successfully', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Something Went Wrong', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }

            }   //}
        }
        catch (Exception d)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }//}
    }

    protected void btnupdate1_Click1(object sender, EventArgs e)
    {

        try
        {


            string formno = txtformno.Text.Trim();
            if (birthplace.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Place of Birth.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (citytxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter City.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (ddlmarrystatus.SelectedIndex==0)
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select Maritial Status.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (flattxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Flat no./blg.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (areatxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Area.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (streettxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Street.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (pintxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Pincode.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (statetxtbox.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter state.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else
            {
                String updt1 = ("update d_adm_applicant set Gender='" + rdgender.SelectedValue + "',blood_group='" + ddlblood.Text.Trim() + "',birth_place='" + birthplace.Text.Trim().Replace("'", "''") + "',Marital_status='" + ddlmarrystatus.SelectedValue + "',Domicile='" + domicileid.Text.Trim().Replace("'", "''") + "',Address_line1='" + flattxtbox.Text.Trim().Replace("'", "''") + "',Address_line2='" + areatxtbox.Text.Trim().Replace("'", "''") + "',Address_line3='" + streettxtbox.Text.Trim().Replace("'", "''") + "',pincode='" + pintxtbox.Text.Trim() + "',State='" + statetxtbox.Text.Trim().Replace("'", "''") + "',city='" + citytxtbox.Text.Trim().Replace("'", "''") + "' where Form_no='" + formno + "'");


                bool chk1 = obj1.DMLqueries(updt1);

                if (chk1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Updated Successfully', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Something Went Wrong', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

                }
            }
        }
        catch(Exception d)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('"+d.Message+"','danger')", true);
        
        }
    }


    protected void btnupdate2_Click(object sender, EventArgs e)
    {
        try
        {
            string formno = txtformno.Text;
            if (ddlstate.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select State in S.S.C.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (ddlboard.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select board in SSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (schoolname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter  School Name in SSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (schoolplace.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter  School Place in SSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (ddlpassmth.SelectedIndex == 0)
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter  Passing Month in SSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }


            else if (seatno.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Seat no. in SSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (mksobt.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Marks obtained in SSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (outofmks.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Out of Marks in SSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (Convert.ToInt32(mksobt.Text.Trim()) > Convert.ToInt32(outofmks.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('obtain marks should be less than out of marks.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                mksobt.Text = "";
                outofmks.Text = "";

            }

            else if (gradeobt.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter grade of SSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            //=================hsc
            else if (ddlstate1.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select State of HSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (ddlboard1.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select board of HSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (colgname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter College Name of HSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (colgplace.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter College Place of HSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (ddlpassmth1.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select Passing of  HSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }


            else if (seatno1.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Seat of HSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (mksobt1.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Marks Obtained of HSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (outofmks1.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Out Marks Obtained of HSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (Convert.ToInt32(mksobt1.Text.Trim()) > Convert.ToInt32(outofmks1.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('obtain marks should be less than out of marks.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                mksobt1.Text = "";
                outofmks1.Text = "";

            }
            else if (gradeobt1.Text.Trim() == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Grade Obtained of HSC.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else
            {
                string updt2 = ("update d_adm_applicant set S_State='" + ddlstate.Text + "',S_Board_name='" + ddlboard.Text + "',S_Ins_Name='" + schoolname.Text.Trim().Replace("'", "''") + "',S_Ins_place='" + schoolplace.Text.Trim().Replace("'", "''") + "',S_First_Attempt='" + rdattempt.SelectedValue + "',S_Year='" + ddlpassyear.Text + "',S_Month='" + ddlpassmth.Text + "',S_Mks_Obtained='" + mksobt.Text + "',S_Mks_OutOf='" + outofmks.Text.Trim() + "',S_grade='" + gradeobt.Text.Trim() + "',S_seat_no='" + seatno.Text.Trim().Replace("'", "''") + "',State_board='" + ddlstate1.Text + "',Board_name='" + ddlboard1.Text + "',Ins_name='" + colgname.Text.Trim().Replace("'", "''") + "',Ins_place='" + colgplace.Text.Trim().Replace("'", "''") + "',firstAttempt='" + rdattempt1.SelectedValue + "',Year='" + ddlpassyear1.Text + "',Month='" + ddlpassmth1.Text + "',Mks_Obtained='" + mksobt1.Text + "',Mks_Outof='" + outofmks1.Text + "',grade='" + gradeobt1.Text.Trim() + "',Seat_No='" + seatno1.Text.Trim() + "' where Form_no='" + formno + "' ");

                bool chk2 = obj1.DMLqueries(updt2);

                if (chk2)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Updated Successfully', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Something Went Wrong', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
            }
        }
        catch (Exception d)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }


    protected void btnupdate3_Click(object sender, EventArgs e)
    {
        try
        {
            

            string formno = txtformno.Text;
            if (fathername.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Father Name', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (fcontact.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Father`s Contact No. ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (focupation.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select  Father`s  Occupation', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }

            else if (mname.Text.Trim() == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Mother Name. ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (mcontact.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Mother`s Contact no. ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
            }
            else if (Moccupation.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select Mother`s Occupation. ', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

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
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Updated Successfully', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
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
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Something went wrong', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
            }
        }
        catch (Exception d)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
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
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select Category', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (ddlrel.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Select Religion', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
          
            else if (txtearn.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Earning', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (txtnonear.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter non Earning', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else if (txtincome.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Enter Year Income', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);

            }
            else
            {

                string update5 = "update d_adm_applicant set Category='" + ddlcat.SelectedItem.ToString() + "', caste='" + ddlcaste.SelectedItem.ToString() + "',Certificate_No='" + certibox.Text + "',Religion='" + ddlrel.SelectedItem.ToString() + "',Phy_handicap_Description='" + ddlphy.SelectedItem.ToString() + "',Extra_Curricular_Activities='" + ddlProficien.SelectedValue.ToString() + "',is_NSS_NCC='" + ddlnccnss.SelectedItem.ToString() + "',is_Scholarship='" + rdbscholar.SelectedValue + "',Earning='" + txtearn.Text + "',NonEarning='" + txtnonear.Text + "',Annual_Income='" + txtincome.Text + "'where Form_no='" + formno + "'";
                bool chk4 = obj1.DMLqueries(update5);
                if (chk4)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Updated Successfully', { type: 'success', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Updated Unsuccessfully', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('"+d.Message+"', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }
    protected void ddlcaste_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception d)
        {

        }
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
                ddlcaste.Items.Insert(0, new ListItem("--Select--", "na"));
            }
            if (ddlcat.SelectedItem.Text == "OPEN")
            {

                ddlcaste.Items.Clear();
                ddlcaste.Enabled = false;
            }
            else
            {
                ddlcaste.Enabled = true ;

            }

        }
        catch (Exception d)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
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

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
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

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }
    public void ddlsta()
    {
        string state = "select distinct trim(upper(Parent)) as parent from State_category_details where Main='State'";
        obj1.fillDataTable(state);
        DataTable dtstate = obj1.fillDataTable(state);
        ddlstate.DataSource = dtstate;
        ddlstate.DataTextField = dtstate.Columns["Parent"].ToString();
        ddlstate.DataValueField = dtstate.Columns["Parent"].ToString();
        
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, new ListItem("--Select--", ""));




    }
    public void fillcat() {
        string catfillquery = "SELECT DISTINCT Parent FROM State_Category_details where Main ='Reserved Category'";
        obj1.fillDataTable(catfillquery);
        DataTable dt1 = new DataTable();
        dt1 = obj1.fillDataTable(catfillquery);
        ddlcat.DataSource = dt1;
        ddlcat.DataTextField = dt1.Columns["parent"].ToString();
        ddlcat.DataValueField = dt1.Columns["parent"].ToString();
        ddlcat.DataBind();
        ddlcat.Items.Insert(0, new ListItem("--Select--", "na"));
        //ddl_Faculty.Items.Insert(0, new ListItem("--Select--", "na"));
    }

    protected void txtnonear_TextChanged(object sender, EventArgs e)
    {
        if (txtnonear.Text.Trim() == "")
        { }
        else
        {
            int add = Convert.ToInt32(txtearn.Text.Trim()) + Convert.ToInt32(txtnonear.Text.Trim());
            txttotal.Text = "";

            txttotal.Text = add.ToString();
        }


    }

    public string valid_date(string date)
    {
        DateTime parsedDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        string pay_date = parsedDate.ToString("yyyy-MM-dd");
        return "(CAST('" + pay_date + "' AS datetime))";
    }
}