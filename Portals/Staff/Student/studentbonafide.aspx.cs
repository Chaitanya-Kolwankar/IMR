using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Student_studentbonafide : System.Web.UI.Page
{
    Class1 cls = new Class1();
    Int32 srno;

    public string srno_on_report { get; private set; }

    DataTable dt = new DataTable();
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
                btn_clear.Attributes.Add("style", "margin-left:210px;margin-top:34px");
                txtname.Enabled = false;
                rad_gender.Enabled = false;
                rad_female.Enabled = false;
                row_visible.Visible = false;
                txt_subcou.Enabled = false;
                txt_ayd.Enabled = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
            }
        }
        
    }

    protected void btn_getdata_Click(object sender, EventArgs e)
    {
        try
        {

            if (btn_getdata.Text == "Get Data")
            {
                if (txt_studID.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID','danger')", true);

                }
                else
                {

                    string getdata = "select p.stud_F_Name+'  '+p.stud_M_Name+'  '+ p.stud_L_Name as [name],p.stud_Gender,dbo.DOBTOWORDS(dbo.www_date_display_personal(stud_DOB)) as [words],convert(varchar,p.stud_DOB,105) as dob,sb.subcourse_name,substring(ayd.Duration,9,4)+'-'+substring(ayd.Duration,21,4) AS Duration,ayd.AYID from m_crs_subcourse_tbl as sb,m_std_personaldetails_tbl as p,m_std_studentacademic_tbl as a,m_academic as ayd  where a.stud_id = p.stud_id and a.stud_id = '" + txt_studID.Text.Trim() + "' and sb.subcourse_id = a.subcourse_Id and ayd.AYID = a.ayid and a.ayid='"+ Session["Year"].ToString() + "'";
                    dt = cls.fillDataTable(getdata);
                    if (dt.Rows.Count > 0)
                    {
                        row_visible.Visible = true;
                        Session["stud__id"] = txt_studID.Text.Trim();
                        txtname.Text = dt.Rows[0]["name"].ToString();
                        Session["name"] = txtname.Text.Trim();
                        dob.Text = dt.Rows[0]["dob"].ToString();
                        Session["inwotdstext"] = dt.Rows[0]["words"].ToString();
                        Session["Datofbirth"] = dob.Text.Trim();
                        txt_subcou.Text = dt.Rows[0]["subcourse_name"].ToString();
                        Session["subcourse"] = txt_subcou.Text.Trim();
                        txt_ayd.Text = dt.Rows[0]["Duration"].ToString();
                        Session["ayd"] = txt_ayd.Text.Trim();
                        Session["aydqury"] = dt.Rows[0]["AYID"].ToString();

                        if (dt.Rows[0]["stud_Gender"].ToString() == "Male")
                        {
                            rad_gender.Checked = true;
                            Session["gender"] = "Male";
                        }
                        else
                        {
                            rad_female.Checked = true;
                            Session["gender"] = "Female";

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Invalid Student ID','danger')", true);
                        txt_studID.Text = "";
                        txtname.Text = "";
                        if (rad_female.Checked == true)
                        {
                            rad_female.Checked = false;
                        }
                        else if (rad_gender.Checked == true)
                        {
                            rad_gender.Checked = false;
                        }
                        dob.Text = "";
                        txt_subcou.Text = "";
                        txt_ayd.Text = "";
                        row_visible.Visible = false;
                        txt_studID.Text = "";

                    }

                }
            }
            else
            {
                if (btn_getdata.Text == "Reprint")
                {
                    if (txt_studID.Text.Trim() == "" && txtsrn.Text.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Sr no. and Student ID. ','danger')", true);
                    }
                    else if (txt_studID.Text.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID. ','danger')", true);
                    }
                    else if (txtsrn.Text.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Sr no.','danger')", true);
                    }
                    else
                    {
                        string reprint_qry = "select * from bonafide_certificate where stud_id = '" + txt_studID.Text.Trim() + "' and srno = '" + txtsrn.Text.Trim() + "'";
                        DataTable dtrep = cls.fillDataTable(reprint_qry);
                        if (dtrep.Rows.Count > 0)
                        {
                            string reprint = "select bc.srno, p.stud_F_Name + '  ' + p.stud_M_Name + '  ' + p.stud_L_Name as [name],p.stud_Gender,dbo.DOBTOWORDS(dbo.www_date_display_personal(stud_DOB)) as [words],convert(varchar, p.stud_DOB, 105) as dob,sb.subcourse_name,substring(ayd.Duration, 9, 4) + '-' + substring(ayd.Duration, 21, 4) AS Duration, ayd.AYID,convert(varchar,GETDATE(),103) as srdate from m_crs_subcourse_tbl as sb,m_std_personaldetails_tbl as p,m_std_studentacademic_tbl as a,m_academic as ayd, bonafide_certificate as bc  where a.stud_id = p.stud_id and a.stud_id = '" + txt_studID.Text.Trim() + "' and sb.subcourse_id = a.subcourse_Id and ayd.AYID = a.ayid and bc.stud_id = a.stud_id and bc.srno = '" + txtsrn.Text.Trim() + "'";
                            DataTable dt2 = cls.fillDataTable(reprint);
                            string dater1 = dt2.Rows[0]["srdate"].ToString();
                            string gen2 = dt2.Rows[0]["stud_Gender"].ToString();
                            if (gen2 == "Male")
                            {
                                Session["gender"] = "Male";
                            }
                            else if(gen2 == "Female") {
                                Session["gender"] = "Female";
                            }
                            string reprint_name = dt2.Rows[0]["name"].ToString();
                            string srno_on_report1 = dt2.Rows[0]["srno"].ToString() + '/' + txt_studID.Text.Trim() + '/' + dt2.Rows[0]["duration"].ToString();
                            string subcou_name = dt2.Rows[0]["subcourse_name"].ToString();
                            string dur = dt2.Rows[0]["duration"].ToString();
                            string dob_reprint = dt2.Rows[0]["dob"].ToString();
                            string dob_word_repriny = dt2.Rows[0]["words"].ToString();
                            string iswas2 = "was";
                            string webPageAddress = "Bonafide.aspx?id=" + txt_studID.Text.Trim() + "&name=" + reprint_name + "&srnorep=" + srno_on_report1 + "&subcou=" + subcou_name + "&dur=" + dur + "&dob=" + dob_reprint + "&dobword=" + dob_word_repriny + "&date="+ dater1 + "&gen="+ gen2 + "&iswas="+ iswas2 + "";

                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow1", "window.open(" + webPageAddress + ",'_newtab');", true);

                            Response.Redirect(string.Format(webPageAddress));


                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Bonafide issued before for this ID.','danger')", true);
                            txtsrn.Text = "";
                            txt_studID.Text = "";
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

    protected void btn_clear_Click(object sender, EventArgs e)
    {
        try
        {
            btn_getdata.Text = "Get Data";
            txt_studID.Text = "";
            txtname.Text = "";
            rad_gender.Checked = false;
            rad_female.Checked = false;
            dob.Text = "";
            txt_subcou.Text = "";
            txt_ayd.Text = "";
            row_visible.Visible = false;
            txtsrn.Text = "";
            chk_srno.Checked = false;
            col_srtxtid.Attributes.Add("style", "display:none");
          //  col_btnprei.Attributes.Add("style", "display:none");
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }

    }
    public void bonafide() 
    {
        string is__was;
        string inser_in_bonafide_certificate = "insert into bonafide_certificate(srno, stud_id, ayid, issue_date, user_id, del_flag, remark)values('" + srno + "','" + txt_studID.Text.Trim() + "','" + Session["aydqury"].ToString() + "',GETDATE(),'" + Session["username"].ToString() + "',0,null)";
        if (cls.DMLqueries(inser_in_bonafide_certificate))
        {

            string getdata1 = "select p.stud_F_Name+'  '+p.stud_M_Name+'  '+ p.stud_L_Name as [name],stud_Gender,dbo.DOBTOWORDS(dbo.www_date_display_personal(stud_DOB)) as [words],convert(varchar,p.stud_DOB,105) as dob,sb.subcourse_name,substring(ayd.Duration,9,4)+'-'+substring(ayd.Duration,21,4) AS Duration,ayd.AYID,convert(varchar,GETDATE(),103) as srdate from m_crs_subcourse_tbl as sb,m_std_personaldetails_tbl as p,m_std_studentacademic_tbl as a,m_academic as ayd  where a.stud_id = p.stud_id and a.stud_id = '" + txt_studID.Text.Trim() + "' and sb.subcourse_id = a.subcourse_Id and ayd.AYID = a.ayid and a.ayid='" + Session["Year"].ToString() + "'";
            string is_was_qry = "select * from m_academic where IsCurrent=1 ";
            DataTable dt0 = cls.fillDataTable(is_was_qry);
            if (dt0.Rows[0]["ayid"].ToString() == Session["Year"].ToString())
            {

                is__was = "is";
            }
            else
            {
                is__was = "was";
            }
            dt = cls.fillDataTable(getdata1);

            string dater = dt.Rows[0]["srdate"].ToString();
            string gen = dt.Rows[0]["stud_Gender"].ToString();
            string reprint_name = dt.Rows[0]["name"].ToString(); ;
            string srno_on_report12 = srno_on_report;
            string subcou_name1 = dt.Rows[0]["subcourse_name"].ToString();
            string dur = dt.Rows[0]["Duration"].ToString();
            string dob_reprint = dt.Rows[0]["dob"].ToString();
            string dob_word_repriny = dt.Rows[0]["words"].ToString();

            string webPageAddress = "Bonafide.aspx?id=" + txt_studID.Text.Trim() + "&name=" + reprint_name + "&srnorep=" + srno_on_report12 + "&subcou=" + subcou_name1 + "&dur=" + dur + "&dob=" + dob_reprint + "&dobword=" + dob_word_repriny + "&date=" + dater + "&gen=" + gen + "&iswas=" + is__was + "";


            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + webPageAddress + "','_newtab');", true);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong','danger')", true);
        }
    }
   // protected void getbonafide_Click(object sender, EventArgs e)
   // {
        //try
        //{
            
        //    if (btn_getdata.Text == "Get Data")
        //    {
        //        string sessionstud_id = Session["stud__id"].ToString();
        //        if (txt_studID.Text.Trim() == "")
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID ','danger')", true);
        //            txt_studID.Focus();

        //        }
        //        else if (sessionstud_id != txt_studID.Text.Trim())
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Student ID was changed','danger')", true);
        //            txtname.Text = "";
        //            if (rad_female.Checked == true)
        //            {
        //                rad_female.Checked = false;
        //            }
        //            else if (rad_gender.Checked == true)
        //            {
        //                rad_gender.Checked = false;
        //            }
        //            dob.Text = "";
        //            txt_subcou.Text = "";
        //            txt_ayd.Text = "";
        //            row_visible.Visible = false;
        //            txt_studID.Text = "";

        //            return;


        //        }
        //        else
        //        {


        //            string srn = "select max(srno) as srno from bonafide_certificate where ayid='" + Session["Year"].ToString() + "'  and stud_id='" + txt_studID.Text.Trim() + "'";

        //            DataTable dtsr = cls.fillDataTable(srn);

        //            if (dtsr.Rows[0]["srno"].ToString() == "")
        //            {
        //                srno = 1;
        //                srno_on_report = srno.ToString() + '/' + txt_studID.Text.Trim() + '/' + Session["ayd"].ToString();
        //            }
        //            else
        //            {
        //                string count_of_sr = dtsr.Rows[0]["srno"].ToString();
        //                ScriptManager.RegisterStartupScript(this, GetType(), "InvokeButton", "Confirm(" + count_of_sr + ");", true);

        //                string dtsrsnvalue = dtsr.Rows[0]["srno"].ToString();
        //                srno = Convert.ToInt32(dtsrsnvalue) + 1;
        //                srno_on_report = srno.ToString() + '/' + txt_studID.Text.Trim() + '/' + Session["ayd"].ToString();
        //            }
        //            string confirmValue = Request.Form["confirm_value"];
        //           // string f1 = System.Web.HttpContext.Current.Request.Form["confirm_value"];
        //            if (confirmValue == "Yes")
        //            {



                     
        //            }
        //            else {
        //                txt_studID.Text = "";
        //                txtname.Text = "";
        //                rad_gender.Checked = false;
        //                rad_female.Checked = false;
        //                dob.Text = "";
        //                txt_subcou.Text = "";
        //                txt_ayd.Text = ""; row_visible.Visible = false;


        //            }

        //        }
        //    }
        //    else
        //    {



        //    }
        //}
        //catch (Exception d)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        //}
   // }

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

    protected void chk_srno_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chk_srno.Checked == true)
            {
                col_srtxtid.Attributes.Add("style", "display:block");
               // col_btnprei.Attributes.Add("style", "display:block");
                btn_getdata.Text = "Reprint";
                txtname.Text = "";
                if (rad_female.Checked == true)
                {
                    rad_female.Checked = false;
                }
                else if (rad_gender.Checked == true)
                {
                    rad_gender.Checked = false;
                }
                dob.Text = "";
                txt_subcou.Text = "";
                txt_ayd.Text = "";
                row_visible.Visible = false;
                txt_studID.Text = "";


            }
            else
            {
                btn_clear.Attributes.Add("style","margin-left:210px;margin-top:34px");
                col_srtxtid.Attributes.Add("style", "display:none");
               // col_btnprei.Attributes.Add("style", "display:none");
                btn_getdata.Text = "Get Data";
                txtname.Text = "";
                if (rad_female.Checked == true)
                {
                    rad_female.Checked = false;
                }
                else if (rad_gender.Checked == true)
                {
                    rad_gender.Checked = false;
                }
                dob.Text = "";
                txt_subcou.Text = "";
                txt_ayd.Text = "";
                row_visible.Visible = false;
                txt_studID.Text = "";
                txtsrn.Text = "";

            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    public void yesckick() {

        try
        {

            if (btn_getdata.Text == "Get Data")
            {
                string sessionstud_id = Session["stud__id"].ToString();
                if (txt_studID.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Enter Student ID ','danger')", true);
                    txt_studID.Focus();

                }
                else if (sessionstud_id != txt_studID.Text.Trim())
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Student ID was changed','danger')", true);
                    txtname.Text = "";
                    if (rad_female.Checked == true)
                    {
                        rad_female.Checked = false;
                    }
                    else if (rad_gender.Checked == true)
                    {
                        rad_gender.Checked = false;
                    }
                    dob.Text = "";
                    txt_subcou.Text = "";
                    txt_ayd.Text = "";
                    row_visible.Visible = false;
                    txt_studID.Text = "";

                    return;


                }
                else
                {


                    string srn = "select max(srno) as srno from bonafide_certificate where ayid='" + Session["Year"].ToString() + "'  and stud_id='" + txt_studID.Text.Trim() + "'";

                    DataTable dtsr = cls.fillDataTable(srn);

                    if (dtsr.Rows[0]["srno"].ToString() == "")
                    {
                        srno = 1;
                        srno_on_report = srno.ToString() + '/' + txt_studID.Text.Trim() + '/' + Session["ayd"].ToString();
                    }
                    else
                    {
                        string count_of_sr = dtsr.Rows[0]["srno"].ToString();



                        string dtsrsnvalue = dtsr.Rows[0]["srno"].ToString();
                        srno = Convert.ToInt32(dtsrsnvalue) + 1;
                        srno_on_report = srno.ToString() + '/' + txt_studID.Text.Trim() + '/' + Session["ayd"].ToString();
                    }
                    bonafide();

                }
            }
            else
            {



            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }




    }


    protected void btnyes_Click(object sender, EventArgs e)
    {
        yesckick();
    }

    protected void btnno_Click(object sender, EventArgs e)
    {
        txtname.Text = "";
        if (rad_female.Checked == true)
        {
            rad_female.Checked = false;
        }
        else if (rad_gender.Checked == true)
        {
            rad_gender.Checked = false;
        }
        dob.Text = "";
        txt_subcou.Text = "";
        txt_ayd.Text = "";
        row_visible.Visible = false;
        txt_studID.Text = "";


    }

    protected void getbonafide_Click(object sender, EventArgs e)
      {
        string srn = "select max(srno) as srno from bonafide_certificate where ayid='" + Session["Year"].ToString() + "'  and stud_id='" + txt_studID.Text.Trim() + "'";
        DataTable dtsr = cls.fillDataTable(srn);
        string count= dtsr.Rows[0]["srno"].ToString();
        if (count == "") 
        {

            yesckick();

       }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#alertmodal').modal('show');</script>", false);
            mdl_srncount.Text = dtsr.Rows[0]["srno"].ToString();

        }
    }
}