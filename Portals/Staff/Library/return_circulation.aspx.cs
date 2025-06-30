using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class return_circulation : System.Web.UI.Page
{
    QueryClass qryCls = new QueryClass();
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["emp_id"]) == "")
            {
                Response.Redirect("Login.aspx");
            }

        }
        catch (Exception w)
        {
            Response.Redirect("Login.aspx");
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
    public static studentDetailbook[] studentbook(string stud_id, string type, string ayid, string connect,string acc_id)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.studentbook(stud_id, type, ayid, connect, acc_id);
    }
    [WebMethod]
    public static studentDetailbook[] search_accession(string accession_id, string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.search_accession(accession_id,connect);
    }
    [WebMethod]
    public static int calculate_fine(string subcourse_id, int day_diff, string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.calculate_fine(subcourse_id, day_diff,connect);
    }
    [WebMethod]
    public static int get_renew_details(string stud_id, string accession_id, string date, string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.get_renew_details(stud_id, accession_id, date, connect);
    }
    [WebMethod]
    public static bool bookinsert(string stud_id, string member_type, string accession_no, string accession_type, string issue_date, string return_date_given, string return_date, string user_id, string H_R, string lab, string insert_or_update, string renew, string is_lost, string fne_applicable, string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.bookinsert(stud_id, member_type, accession_no, accession_type, issue_date, return_date_given, return_date, user_id, H_R, lab, insert_or_update, renew, is_lost, fne_applicable, connect);
    }
    [WebMethod]
    public static bool update_return_date_given(string stud_id, string accession_no, string accession_type, string return_date_given, string connect)   // update_return_date_given
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.update_return_date_given(stud_id, accession_no, accession_type, return_date_given, connect);
    }
    [WebMethod]
    public static bool update_payments(string stud_id, string accession_no, string accession_type, string return_date, string fine_paid, string fine_discount, string remark, string user_id, string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.update_payments(stud_id, accession_no, accession_type, return_date, fine_paid, fine_discount, remark, user_id, connect);
    }
}