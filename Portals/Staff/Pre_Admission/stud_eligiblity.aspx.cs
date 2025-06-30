using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class stud_eligiblity : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static List<ListItem> fillyear()
    {
        classWebMethods cls = new classWebMethods();
        return cls.acdYear();
    }
    [WebMethod]
    public static List<ListItem> subgroup(string grp_id)
    {
        classWebMethods webCls = new classWebMethods();
        QueryClass qryCls = new QueryClass();
        return webCls.subgroup(grp_id);
    }
    [WebMethod]
    public static List<ListItem> fillcourse( string group_ids)
    {
        classWebMethods cls = new classWebMethods();
        return cls.fillcourse(group_ids);
    }

    [WebMethod]
    public static List<ListItem> fillsubcourse(string course_id)
    {
        classWebMethods cls = new classWebMethods();
        return cls.fillsubcourse(course_id);
    }

    [WebMethod]
    public static List<ListItem> filltogroup(string subcourse_id)
    {
        classWebMethods cls = new classWebMethods();
        return cls.filltogroup(subcourse_id);
    }

    [WebMethod]
    public static List<ListItem> fillfromgroup(string togroup)
    {
        classWebMethods cls = new classWebMethods();
        return cls.fillfromgroup(togroup);
    }

    [WebMethod]
    public static EligibilityClass[] changesubgroup_new(string ayid, string group_id, string subcourse_id, string subcrs_text, string stud_Id, string frm_rol, string to_rol, string to_yr)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.changesubgroup_new(ayid, group_id, subcourse_id, subcrs_text, stud_Id, frm_rol, to_rol, to_yr);
    }

    [WebMethod]
    public static bool check_ins_updt(string ayid, string from_yr, string group_id, string subcourse_id, string subcrs_text, string stud_Id,string emp_id,string to_group, string unchk_id)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.check_ins_updt(ayid, from_yr, group_id, subcourse_id, subcrs_text, stud_Id, emp_id, to_group, unchk_id);
    }
}