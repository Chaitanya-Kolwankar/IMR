using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Student_studenttransfercertificate : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
     {
         if (!IsPostBack) 
        {
            txtstud_fname.Enabled = false;
            txt_LstName.Enabled = false;
            txt_Mname.Enabled = false;
            TXT_DOB.Enabled = false;
            //rad_gender.Enabled = false;
            //rad_female.Enabled = false;

            int curr_year = int.Parse(DateTime.Now.Year.ToString());
            for (int i = curr_year; i >= 2000; i--)
            {
                string s = i.ToString();
                ddl_exm_yr.Items.Add(s);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
            dataonpageload();
        }
        else
        {
             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
        }
    }


    public void dataonpageload()
    {
        string modal_grd = "select distinct college_name,college_add,college_pincode from transfercertificate";
        DataTable dt1= cls.fillDataTable(modal_grd);
        if (dt1.Rows.Count > 0) 
        {          
            grdaddress.DataSource = dt1;
            grdaddress.DataBind();
        }           
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (txtstud_id.Text.Trim() == "")
        {
            txtstud_id.Focus();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID','danger')", true);
        }
        else if (txtstud_id.Text.Trim().Length < 8)
        {
            txtstud_id.Focus();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Student ID','danger')", true);

        }
        else
        {
            string check_academic_year = "select * from m_std_studentacademic_tbl where stud_id = '"+txtstud_id.Text.Trim()+"'and ayid = '"+ Session["Year"].ToString() + "' and ayid in(select MAX(ayid) from m_std_studentacademic_tbl where stud_id = '"+txtstud_id.Text.Trim()+"')";
            DataTable dt6 = cls.fillDataTable(check_academic_year);
            if (dt6.Rows.Count > 0)
            {


                string chk_stud_entry = "select * from transfercertificate where stud_id='" + txtstud_id.Text.Trim() + "'";
                DataTable dt3 = cls.fillDataTable(chk_stud_entry);
                if (dt3.Rows.Count > 0)
                {
                    btn_gettc.Text = "Reprint";
                    Session["studentid"] = txtstud_id.Text.Trim();
                    string fetch = "select * from transfercertificate where stud_id='" + txtstud_id.Text.Trim() + "';select p.stud_F_Name,p.stud_M_Name,p.stud_L_Name,convert(varchar,p.stud_DOB,105)  as stud_DOB ,dbo.DOBTOWORDS(dbo.www_date_display_personal(p.stud_DOB)) as [words] from m_std_personaldetails_tbl as p where p.stud_id='" + txtstud_id.Text.Trim() + "'";
                    DataSet dt9 = cls.fillDataset(fetch);
                    txtstud_fname.Text = dt9.Tables[1].Rows[0]["stud_F_Name"].ToString();
                    txt_Mname.Text = dt9.Tables[1].Rows[0]["stud_M_Name"].ToString();
                    txt_LstName.Text = dt9.Tables[1].Rows[0]["stud_L_Name"].ToString();
                    TXT_DOB.Text = dt9.Tables[1].Rows[0]["stud_DOB"].ToString();
                    txt_cou.Text = dt9.Tables[0].Rows[0]["course"].ToString();
                    txt_sub.Text = dt9.Tables[0].Rows[0]["subcourse"].ToString();
                    ddlfirsttrm_from.SelectedValue = dt9.Tables[0].Rows[0]["frst_term_from"].ToString();
                    ddlfirstterm_to.SelectedValue = dt9.Tables[0].Rows[0]["frst_term_to"].ToString();
                    ddlsecond_frm.SelectedValue = dt9.Tables[0].Rows[0]["sec_term_from"].ToString();
                    ddlsecnd_to.SelectedValue = dt9.Tables[0].Rows[0]["sec_term_to"].ToString();
                    ddl_exm_yr.SelectedValue = dt9.Tables[0].Rows[0]["examination_year"].ToString();
                    txt_tranfercourse.Text = dt9.Tables[0].Rows[0]["transferedcourse"].ToString();
                    txt_remark.Text = dt9.Tables[0].Rows[0]["remark"].ToString();
                    txt_voluntary_grup.Text = dt9.Tables[0].Rows[0]["voluntary_sub"].ToString();
                    clgadd.Text = dt9.Tables[0].Rows[0]["college_name"].ToString();
                    clgadd2.Text = dt9.Tables[0].Rows[0]["college_add"].ToString();
                    clgadd3.Text = dt9.Tables[0].Rows[0]["college_pincode"].ToString();
                    ddl_is_pas_fail.SelectedValue = dt9.Tables[0].Rows[0]["is_pass_fail"].ToString();
                    ViewState["dobwrds"] = dt9.Tables[1].Rows[0]["words"].ToString();

                }
                else
                {
                    string search = "select  a.stud_id,p.stud_F_Name,p.stud_M_Name,p.stud_L_Name ,dbo.DOBTOWORDS(dbo.www_date_display_personal(p.stud_DOB)) as [words],a.ID_No,p.stud_Gender,sb.subcourse_id,sb.subcourse_name,c.course_name ,sb.semester,substring(ayd.Duration,9,4)+'-'+substring(ayd.Duration,21,4) AS Duration,convert(varchar,p.stud_DOB,105) as DOB,dbo.DOBTOWORDS(dbo.www_date_display_personal(p.stud_DOB)) as [words] from m_std_studentacademic_tbl as a,m_crs_subcourse_tbl as sb,m_std_personaldetails_tbl as p,m_academic as ayd,m_crs_course_tbl as c where  a.ayid  in (select max(ayid) from m_std_studentacademic_tbl where a.del_flag=0 and p.del_flag=0 and stud_id='" + txtstud_id.Text.Trim() + "')  and a.stud_id='" + txtstud_id.Text.Trim() + "' and sb.subcourse_id=a.subcourse_Id and p.stud_id=a.stud_id and ayd.AYID=a.ayid and c.del_flag=0 and c.course_id=sb.course_id";


                    DataTable dt = cls.fillDataTable(search);
                    if (dt.Rows.Count > 0)
                    {
                        Session["birthinword"] = dt.Rows[0]["words"].ToString();
                        Session["studentid"] = txtstud_id.Text.Trim();
                        Session["subcou_id"] = dt.Rows[0]["subcourse_id"].ToString();
                        txtstud_fname.Text = dt.Rows[0]["stud_F_Name"].ToString();
                        txt_Mname.Text = dt.Rows[0]["stud_M_Name"].ToString();
                        txt_LstName.Text = dt.Rows[0]["stud_L_Name"].ToString();
                        TXT_DOB.Text = dt.Rows[0]["DOB"].ToString();
                        if (dt.Rows[0]["stud_Gender"].ToString() == "Male" )
                        {
                            //rad_gender.Checked = true;
                            Session["gender"] = "Male";
                        }
                        else
                        {
                            //rad_female.Checked = true;
                            Session["gender"] = "Female";
                        }
                        txt_sub.Text = dt.Rows[0]["subcourse_name"].ToString();
                        txt_cou.Text = dt.Rows[0]["course_name"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Student ID','danger')", true);
                        txtstud_id.Text = "";
                        txtstud_id.Focus();

                    }
                }
            }
            else {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Student ID is not of Current Year','danger')", true);


            }
        }
        
    }

    protected void btn_gettc_Click(object sender, EventArgs e)
     {
         if (btn_gettc.Text == "Get Transference Certificate")
        {
            if (txtstud_id.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID','danger')", true);
            }
            else if (txtstud_fname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student First Name','danger')", true);
            }
            else if (txt_Mname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student Middle Name','danger')", true);
            }
            else if (txt_LstName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student Last Name','danger')", true);
            }
            else if (TXT_DOB.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter  Date of Birth.','danger')", true);
            }
            else if (txt_cou.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Course','danger')", true);

            }
            else if (txt_sub.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Subcourse.','danger')", true);

            }
            else if (ddlfirsttrm_from.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select First term (from).','danger')", true);
            }
            else if (ddlfirstterm_to.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select First term (To).','danger')", true);
            }
            else if (ddlsecond_frm.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Second term (From).','danger')", true);
            }
            else if (ddlsecnd_to.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Second term (To).','danger')", true);
            }
            else if (ddl_exm_yr.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Examination year.','danger')", true);

            }
            else if (txt_tranfercourse.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Transfered Course.','danger')", true);

            }
            else if (txt_remark.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Remark.','danger')", true);

            }
            else if (txt_voluntary_grup.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Voluntary Subject.','danger')", true);
            }
            else if (clgadd.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter College Name.','danger')", true);
            }
            else if (clgadd2.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter College Address.','danger')", true);
            }
            else if (clgadd3.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter College Pincode.','danger')", true);
            }
            else if (clgadd3.Text.Length<6) { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('invalid College Pincode.','danger')", true); }
            else if (ddl_is_pas_fail.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select IS Passed or Failed.','danger')", true);
            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#alertmodal').modal('show');</script>", false);

            }
        }
        else 
         {
             if (btn_gettc.Text=="Reprint")
             {

                 if (txtstud_id.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID','danger')", true);
                }
                else if (txtstud_fname.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student First Name','danger')", true);
                }
                else if (txt_Mname.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student Middle Name','danger')", true);
                }
                else if (txt_LstName.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student Last Name','danger')", true);
                }
                else if (TXT_DOB.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter  Date of Birth.','danger')", true);
                }
                else if (txt_cou.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Course','danger')", true);

                }
                else if (txt_sub.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Subcourse.','danger')", true);

                }
                else if (ddlfirsttrm_from.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select First term (from).','danger')", true);
                }
                else if (ddlfirstterm_to.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select First term (To).','danger')", true);
                }
                else if (ddlsecond_frm.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Second term (From).','danger')", true);
                }
                else if (ddlsecnd_to.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Second term (To).','danger')", true);
                }
                else if (ddl_exm_yr.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Examination year.','danger')", true);

                }
                else if (txt_tranfercourse.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Transfered Course.','danger')", true);

                }
                else if (txt_remark.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Remark.','danger')", true);

                }
                else if (txt_voluntary_grup.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Voluntary Subject.','danger')", true);
                }
                else if (clgadd.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter College Name.','danger')", true);
                }
                else if (clgadd2.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter College Address.','danger')", true);
                }
                else if (clgadd3.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter College Pincode.','danger')", true);
                }
                else if (ddl_is_pas_fail.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select IS Passed or Failed.','danger')", true);
                }
                else
                {
                    if (Session["studentid"].ToString() == txtstud_id.Text.Trim())
                    {

                        string durationquery = " select * from  m_academic where AYID='" + Session["Year"] + "'";
                        DataTable dudt = cls.fillDataTable(durationquery);
                        string year = dudt.Rows[0]["Duration"].ToString();
                        string dur = year.Substring(8, 4) + '-' + year.Substring(20);
                        string reportyear = year.Substring(20);
                        string tcno = "TC/" + dur + "/01";

                        string updte = "update transfercertificate set TC_No = '" + tcno + "', stud_id = '" + txtstud_id.Text.Trim() + "', ayid = '" + dur + "', course = '" + txt_cou.Text.Trim() + "', subcourse = '" + txt_sub.Text.Trim() + "', college_name = '" + clgadd.Text.Trim().Replace("'","''") + "', college_add = '" + clgadd2.Text.Trim().Replace("'", "''") + "', college_pincode = '" + clgadd3.Text.Trim() + "', examination_year = '"+ ddl_exm_yr.SelectedItem.Text + "', remark = '"+txt_remark.Text.Trim()+"', prnno = '"+txt_prn.Text.Trim()+"', frst_term_from = '"+ddlfirsttrm_from.SelectedValue.ToString() +"', frst_term_to = '"+ddlfirstterm_to.SelectedValue.ToString()+"', sec_term_from = '"+ddlsecond_frm.SelectedValue.ToString()+"', sec_term_to = '"+ddlsecnd_to.SelectedValue.ToString()+"', is_pass_fail = '"+ddl_is_pas_fail.SelectedValue.ToString()+"', transferedcourse = '"+txt_tranfercourse.Text.ToString()+"', voluntary_sub = '"+txt_voluntary_grup.Text.Trim()+ "', del_flag = 0, curr_dt =  GETDATE() where stud_id = '" + txtstud_id.Text.Trim() + "'";
                        if (cls.DMLqueries(updte))
                        {


                            string name = txtstud_fname.Text.Trim() + ' ' + txt_Mname.Text.Trim() + ' ' + txt_LstName.Text.Trim();
                            string dob = TXT_DOB.Text.Trim();
                            string dobword = ViewState["dobwrds"].ToString();
                            string cou = txt_cou.Text.Trim();
                            string a1subcou = txt_sub.Text.Trim();
                            string fir_term_frm = ddlfirsttrm_from.SelectedItem.Text;
                            string fir_term_to = ddlfirstterm_to.SelectedItem.Text;
                            string sec_term_frm = ddlsecond_frm.SelectedItem.Text;
                            string sec_term_to = ddlsecnd_to.SelectedItem.Text;
                            string reportyeara2 = year.Substring(20);
                            string month_yeara3 = ddlsecnd_to.SelectedItem.Text + " " + year.Substring(20);
                            string tranfercour = txt_tranfercourse.Text.Trim();
                            string remark = txt_remark.Text.Trim();
                            // string dobwrd = Session["birthinword"].ToString();
                            string voluntarysubject = txt_voluntary_grup.Text.Trim();
                            string col_name = clgadd.Text.Trim();
                            string col_add = clgadd2.Text.Trim();
                            string col_pincode = clgadd3.Text.Trim();
                            string is_pass_fail = ddl_is_pas_fail.SelectedItem.Text;
                            string prnno = txt_prn.Text.Trim();
                            string webaddress = "tc.aspx?id=" + Session["studentid"].ToString() + "&name=" + name + "&dob=" + dob + "&dobword=" + dobword + "&cou=" + cou + "&subcou=" + a1subcou + "&fir_term_frm=" + fir_term_frm + "&fir_term_to=" + fir_term_to + "&sec_term_frm=" + sec_term_frm + "&sec_term_to=" + sec_term_to + "&reportyeara2=" + reportyeara2 + "&month_yeara3=" + month_yeara3 + "&tranfercour=" + tranfercour + "&remark=" + remark + "&voluntarysubject=" + voluntarysubject + "&reportyear=" + reportyear + "&colname=" + col_name + "&coladd=" + col_add + "&colpin=" + col_pincode + " &gender=" + Session["gender"].ToString() + "&pass_fail=" + ddl_is_pas_fail.SelectedItem.Text + "";

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + webaddress + "','_newtab');", true);
                            Response.Redirect(string.Format(webaddress, "_blank"));
                            //  Response.Redirect(string.Format(webaddress, "_blank"));

                        }
                        else 
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('somenthing went wrong','danger')", true);


                        }
                    }




                }


            }
        
        
        }
    }

    protected void btnyes_Click(object sender, EventArgs e)
    {
        if (Session["studentid"].ToString()==txtstud_id.Text.Trim()) 
        {
            string durationquery = " select * from  m_academic where AYID='"+Session["Year"] +"'";
            DataTable dudt = cls.fillDataTable(durationquery);
            string year = dudt.Rows[0]["Duration"].ToString();
            string dur = year.Substring(8, 4)+'-'+year.Substring(20);
            string reportyear= year.Substring(20);
            string tcno = "TC/"+dur+ "/01";
            string insrt_trn_cert_tbl = " insert into transfercertificate  (TC_NO,stud_id,ayid,course,subcourse,college_name,college_add,college_pincode,examination_year,remark,prnno,del_flag,curr_dt,frst_term_from,frst_term_to,sec_term_from,sec_term_to,is_pass_fail,transferedcourse,voluntary_sub) values('" + tcno + "','" + Session["studentid"].ToString() + "','" + dur + "','" + txt_cou.Text.Trim() + "','" + txt_sub.Text.Trim() + "','" + clgadd.Text.Trim().Replace("'", "''") + "','" + clgadd2.Text.Trim().Replace("'", "''") + "','" + clgadd3.Text.Trim() + "','" + ddl_exm_yr.SelectedItem.Text.Trim() + "','" + txt_remark.Text.Trim() + "','" + txt_prn.Text.Trim() + "',0,getdate(),'" + ddlfirsttrm_from.SelectedItem.Text.Trim() + "','" + ddlfirstterm_to.SelectedItem.Text.Trim() + "','" + ddlsecond_frm.SelectedItem.Text.Trim() + "','" + ddlsecnd_to.SelectedItem.Text.Trim() + "','" + ddl_is_pas_fail.SelectedValue.ToString().Trim() + "','"+ txt_tranfercourse.Text.Trim() + "','"+txt_voluntary_grup.Text.Trim()+"')";
            

           if (cls.DMLqueries(insrt_trn_cert_tbl)) 
            {
                string name = txtstud_fname.Text.Trim() + ' ' + txt_Mname.Text.Trim() + ' ' + txt_LstName.Text.Trim();
                string dob = TXT_DOB.Text.Trim();
                string dobword =Session["birthinword"].ToString();
                string cou = txt_cou.Text.Trim();
                string a1subcou = txt_sub.Text.Trim();
                string fir_term_frm = ddlfirsttrm_from.SelectedItem.Text;
                string fir_term_to = ddlfirstterm_to.SelectedItem.Text;
                string sec_term_frm = ddlsecond_frm.SelectedItem.Text;
                string sec_term_to = ddlsecnd_to.SelectedItem.Text;
                string reportyeara2 = year.Substring(20);
                string month_yeara3 = ddlsecnd_to.SelectedItem.Text + " " + year.Substring(20);
                string tranfercour = txt_tranfercourse.Text.Trim();
                string remark = txt_remark.Text.Trim();
               // string dobwrd = Session["birthinword"].ToString();
                string voluntarysubject = txt_voluntary_grup.Text.Trim();
                string col_name = clgadd.Text.Trim().Replace("''","'");
                string col_add = clgadd2.Text.Trim();
                string col_pincode = clgadd3.Text.Trim();
                string is_pass_fail = ddl_is_pas_fail.SelectedItem.Text;
                string prnno = txt_prn.Text.Trim();
                string webaddress = "tc.aspx?id=" + Session["studentid"].ToString() + "&name="+ name + "&dob="+ dob + "&dobword="+ dobword + "&cou="+ cou + "&subcou="+a1subcou+ "&fir_term_frm="+ fir_term_frm + "&fir_term_to="+ fir_term_to + "&sec_term_frm="+ sec_term_frm + "&sec_term_to="+ sec_term_to + "&reportyeara2="+ reportyeara2 + "&month_yeara3="+ month_yeara3 + "&tranfercour="+ tranfercour + "&remark="+ remark + "&voluntarysubject="+ voluntarysubject + "&reportyear="+ reportyear + "&colname="+ col_name + "&coladd="+ col_add + "&colpin="+ col_pincode + " &gender=" + Session["gender"].ToString() + "&pass_fail="+ddl_is_pas_fail.SelectedItem.Text+"";
             

           // Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + webaddress + "','_newtab');", true);
                Response.Redirect(string.Format(webaddress, "_blank"));
            }
  
        }
        else 
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Student ID has changed.','danger')", true);

        }
  
    }



    protected void grdaddress_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName== "rowselect") 
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow grverow = grdaddress.Rows[index];
            Label grd_lbl_clg_name = (Label)grdaddress.Rows[index].FindControl("grd_lbl_colg_name");
            Label grd_lbl_clg_address= (Label)grdaddress.Rows[index].FindControl("grd_lbl_clgaddres");
            Label grd_lbl_clg_pin = (Label)grdaddress.Rows[index].FindControl("grd_lbl_colg_Pin");
            clgadd.Text = grd_lbl_clg_name.Text;
            clgadd2.Text = grd_lbl_clg_address.Text;
            clgadd3.Text = grd_lbl_clg_pin.Text;
            //   ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#staticBackdrop",  "$('body').removeClass('modal-open');$('.modal-backdrop').remove();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalHide", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#staticBackdrop').hide();", true);

        }
    }

    protected void modal_btnsearch_Click(object sender, EventArgs e)
    {
        if (mdl_txt_colg_name.Text.Trim()==""|| mdl_txt_col_address.Text.Trim()==""|| mdl_txt_col_pin.Text.Trim()=="") 

        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter College Name, College Address,College Pincode To Search .','danger')", true);
        }
        else {
            string sreach_clg_name = "select distinct college_name ,college_add,college_pincode from transfercertificate where college_name like '" + mdl_txt_colg_name.Text.Trim() + "%' and college_add like '" + mdl_txt_col_address.Text.Trim() + "%' and college_pincode like '" + mdl_txt_col_pin.Text.Trim() + "%'";
            DataTable dt1 = cls.fillDataTable(sreach_clg_name);
            if (dt1.Rows.Count > 0)
            {

                grdaddress.DataSource = dt1;
                grdaddress.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('College Name not availabe.Enter College name,College Address,College Pincode.','danger')", true);
                clgadd.Focus();
                clgadd3.Focus();
                clgadd2.Focus();
                dataonpageload();



            }
        }

    }
}