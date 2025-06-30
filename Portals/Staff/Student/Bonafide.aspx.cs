using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Student_Bonafide : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string date1 = Request.QueryString["date"];
            date.Text = date1;
            string pp1 = Request.QueryString["id"];

            string name = Request.QueryString["name"];
            master_miss.Text = name;

            string srno = Request.QueryString["srnorep"];
            no.Text = srno;
            string subcou = Request.QueryString["subcou"];
            FY_SY.Text = subcou;
            string dur = Request.QueryString["dur"];
            acd_year.Text = dur;
            string dateofbirth = Request.QueryString["dob"];
            dob.Text = dateofbirth;
            string words_dob = Request.QueryString["dobword"];
            inwotds.Text = words_dob;
            string gen1 = Request.QueryString["gen"];
            if (gen1 == "Male")
            {
                mas_mis.InnerText = "Master";
                his_her.InnerText = "His";
                his_her2.InnerText = "He";
            }
            else if(gen1=="Female"){
                his_her.InnerText = "Her";
                mas_mis.InnerText = "Miss";
                his_her2.InnerText = "She";
            }
            string iswas = Request.QueryString["iswas"];
            if (iswas== "is")
            {
                is_was.InnerText = "is";
            }
            else if (iswas == "was") 
            {
                is_was.InnerText = "was";

            }

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
}