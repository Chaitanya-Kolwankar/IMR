using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class book_search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    [WebMethod]
    public static lib_report[] book_sear(string book_name, string author, string publisher, string keyword, string isbn,string acc_no,string connect)  
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.book_search(book_name, author, publisher, keyword, isbn, acc_no, connect);
    }

    [WebMethod]
    public static lib_report[] Adv_book_search(string book_name, string author, string publisher, string flagKey1, string flagKey2, string flagKey3, string flagLogic, string flagLogic1,string type,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.Adv_book_search(book_name, author, publisher, flagKey1, flagKey2, flagKey3, flagLogic, flagLogic1, type, connect);
    }

    [WebMethod]
    public static lib_report[] CD_search(string book_name, string author, string publisher, string keyword, string isbn,string accession_no,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.CD_search(book_name, author, publisher, keyword, isbn,accession_no, connect);
                    
    }

    [WebMethod]
    public static lib_report[] Map_search(string book_name, string author, string publisher, string keyword, string isbn, string accession_no, string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.Map_search(book_name, author, publisher, keyword, isbn, accession_no, connect);
        
    }
    //[WebMethod]
    //public static lib_report[] book_search(string book_name, string author, string publisher, string keyword, string isbn)
    //{
    //    classWebMethods webCls = new classWebMethods();
    //    return webCls.book_search(book_name, author, publisher, keyword, isbn);
    //}
}