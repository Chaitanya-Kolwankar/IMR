using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class IssueReturnReport : System.Web.UI.Page
{

    QueryClass qryCls = new QueryClass();
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Report
    [WebMethod]
    public static Issuereturnreport[] GetIssuereturnReport(string datetimepicker1, string datetimepicker2, string memberType, string isssueReturn, string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.GetIssuereturnReport(datetimepicker1, datetimepicker2, memberType, isssueReturn, connect);
    }
}