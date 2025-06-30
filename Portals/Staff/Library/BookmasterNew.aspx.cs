using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookmasterNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string[] LoadPublisher(string type,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.LoadPublisher(type, connect);
    }

    //Insert Author
    [WebMethod]
    public static bool AuthorInsert(string generalid, string generaltype, string generalname, string contact1, string contact2, string email, string location, string address, string not_in_use, string userid,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.AuthorInsert(generalid, generaltype, generalname, contact1, contact2, email, location, address, not_in_use, userid,connect);
    }

    [WebMethod]
    public static book_master[] Get_book_Title(string type,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.Get_book_Title(type,connect);
    }


    //bookload
    [WebMethod]
    public static bookmasternew[] get_cd_data(string cd, string cd_name, string type,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.get_cd_data(cd, cd_name, type,connect);
    }


    [WebMethod]
    public static bookmasternew[] Get_cd_Title(string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.Get_cd_Title(connect);
    }


    [WebMethod]
    public static List<ListItem> cd_dept(string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.cd_dept(connect);
    }


    [WebMethod]
    public static bool saveData(string qry, string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.saveData_newspaper(qry,connect);
    }
    [WebMethod]
    public static MAP[] LoadMap(string accession,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.LoadMap(accession, connect);
    }

    [WebMethod]
    public static MAP[] load_cd_book(string accession,string type,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.load_cd_book(accession, type, connect);
    }

    //for langauage
    [WebMethod]
    public static List<ListItem> fillLanguage(string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.fillDropdown(connect);
    }


    [WebMethod]
    public static List<ListItem> LoadPrefix(string type,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.LoadPrefix(type,connect);
    }

    [WebMethod]
    public static string getMaxAccession(string accession, string type,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.getMaxAccession(accession, type,connect);
    }
    [WebMethod]
    public static book_master[] CheckAlready(string booktitle, string edition, string author,string publisher,string accession,string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.CheckAlready(booktitle, edition, author, publisher, accession,connect);
    }
      [WebMethod]
    public static book_master[] CheckAlreadyebook(string accession, string connect)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.CheckAlreadyebook(accession, connect);
    }
}