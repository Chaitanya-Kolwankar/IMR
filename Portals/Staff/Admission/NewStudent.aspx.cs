using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_Master_NewStudent : System.Web.UI.Page
{
   QueryClass qryCls = new QueryClass();
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Convert.ToString(Session["Emp_id"]) == "")
                {
                    Response.Redirect("~/Portals/Staff/Login.aspx");
              
                }
                else
                {
                    cls.chkPassword();
                    qryCls.getayid(ddlyear);
                    // qryCls.getayid(ddlyear);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");

            }

        }
    }

    [WebMethod]
    public static List<ListItem> getayidadm()
    {
        classWebMethods webCls = new classWebMethods();
        QueryClass qryCls = new QueryClass();
        return webCls.getayidadm();
    }
    [WebMethod]
    public static List<ListItem> getcourse(string fid)
    {
        classWebMethods webCls = new classWebMethods();
        QueryClass qryCls = new QueryClass();
        return webCls.getcourse(fid);
    }
    [WebMethod]
    public static List<ListItem> getfaculty()
    {
        classWebMethods webCls = new classWebMethods();
        QueryClass qryCls = new QueryClass();
        return webCls.getfaculty();
    }

    [WebMethod]
    public static List<ListItem> getsubcourse(string course)
    {
        classWebMethods webCls = new classWebMethods();
        QueryClass qryCls = new QueryClass();
        return webCls.getsubcourse(course);
    }

    [WebMethod]
    public static string[] fillAuthBy()
    {
        classWebMethods webCls = new classWebMethods();

        return webCls.fillAuthBy();
    }
    [WebMethod]
    public static List<ListItem> getgroup(string subcourse)
    {
        classWebMethods webCls = new classWebMethods();
        QueryClass qryCls = new QueryClass();
        return webCls.getgroup(subcourse);
    }
    [WebMethod]
    public static string[] fillbanknane()
    {
        classWebMethods webCls = new classWebMethods();

        return webCls.fillbanknane();
    }
    // formid

    [WebMethod]
    public static admission[] Admissionform(string formid, string year)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.Admissionform(formid, year);
    }
    [WebMethod]
    public static admission[] Admissiongrid(string formid, string year, string fname, string mname, string lname, string dob)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.Admissiongrid(formid, year, fname, mname, lname, dob);
    }
    [WebMethod]
    public static admission[] Confirm(string formid, string year, string ddlfaculty, string ddlgroup , string ddlsubcourse ,string ddlgroupname, string ddlsubcoursename)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.Confirm(formid, year, ddlfaculty, ddlgroup, ddlsubcourse, ddlgroupname, ddlsubcoursename);
        
    }

    
    //[WebMethod]
    //public static admission[] feesdetails(string formid, string year, string ddlfaculty, string ddlgroup)
    //{
    //    classWebMethods webCls = new classWebMethods();
    //    return webCls.feesdetails(formid, year, ddlfaculty, ddlgroup);

    //}

    [WebMethod]
    //  public static bool savefees(string stud_id, string ddlsubcourse, string ddlgroup,int amount, int Course_tot_fees, int Course_fee_Bal, string Pay_date, string reciptmode, int reciptno, string Recpt_Chq_dt,string Recpt_Chq_No, string Recpt_Bnk_Name, string Recpt_Bnk_Branch, string Chq_status, string type, string Remark, string Authorized_By, string Ayid, string user_id)   //(logClass logclass)
    public static bool savefees(admission admission)
    {
        classWebMethods webCls = new classWebMethods();
        // return webCls.savefees(stud_id, ddlsubcourse, ddlgroup,amount, Course_tot_fees, Course_fee_Bal, Pay_date, reciptmode, reciptno, Recpt_Chq_dt,Recpt_Chq_No, Recpt_Bnk_Name, Recpt_Bnk_Branch, Chq_status, type, Remark, Authorized_By, Ayid, user_id);
        return webCls.savefees(admission);
    }
    //   savefees


    [WebMethod]
    public static admission[] transferfees(string oldstud_id, string formid, string stud_id, string Ayid, string fyid, string userid)   //(logClass logclass)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.transferfees(oldstud_id, formid, stud_id, Ayid, fyid, userid);
    }
   [WebMethod]
   public static studentmodify[] parpayment(string stud_id,string ayid)
   {
      classWebMethods webCls = new classWebMethods();
      return webCls.parpayment(stud_id ,ayid);
   }


   [System.Web.Services.WebMethod(enableSession: true)]
   public static void Setsession(string id)
   {
       HttpContext.Current.Session["id"] = id;

   }
   protected void txt_formid_TextChanged(object sender, EventArgs e)
   {

   }
}
