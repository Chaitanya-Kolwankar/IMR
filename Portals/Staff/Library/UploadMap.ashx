<%@ WebHandler Language="C#" Class="UploadMap" %>

using System;
using System.Web;

public class UploadMap : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
       // context.Response.Write("Hello World");
        
        
         string id = context.Request["ID"];
            string[] arr = id.Split('?');

            if (arr[1].ToString() == "map")
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];

                    string[] ext = files[i].FileName.Split('.');

                    string fname = context.Server.MapPath("../../../Library/Map/" + arr[0].ToString() + "." + ext[ext.Length - 1].ToString());
                    
                    file.SaveAs(fname);
                }
            }

        
        
        
        
        
            else if (arr[1].ToString() == "Book")
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];

                    string[] ext = files[i].FileName.Split('.');

                    string fname = context.Server.MapPath("../../../Library/Book/" + arr[0].ToString() + "." + ext[ext.Length - 1].ToString());

                    file.SaveAs(fname);
                }
            }


         
              
                
                  
                
            else 
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];

                    string[] ext = files[i].FileName.Split('.');

                    string fname = context.Server.MapPath("../../../Library/CD/" + arr[0].ToString() + "." + ext[ext.Length - 1].ToString());

                    file.SaveAs(fname);
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write("File Uploaded Successfully!");
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}