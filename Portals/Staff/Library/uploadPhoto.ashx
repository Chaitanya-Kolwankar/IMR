<%@ WebHandler Language="C#" Class="uploadPhoto" %>

using System;
using System.Web;

public class uploadPhoto : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (context.Request.Files.Count > 0)
        {
            //HttpFileCollection SelectedFiles = context.Request.Files;
            //for (int i = 0; i < SelectedFiles.Count; i++)
            //{
            //    HttpPostedFile PostedFile = SelectedFiles[i];
            //    string FileName = context.Server.MapPath("StudentPhoto/" + PostedFile.FileName);
            //    PostedFile.SaveAs(FileName);
            //}

            string id = context.Request["ID"];
            string[] arr = id.Split('?');

            if (arr[1].ToString() == "sign")
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];

                    string[] ext = files[i].FileName.Split('.');

                    string fname = context.Server.MapPath("~/StudentPhoto/sign/" + arr[0].ToString() + "." + ext[ext.Length - 1].ToString());

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

                    string fname = context.Server.MapPath("~/StudentPhoto/photo/" + arr[0].ToString() + "." + ext[ext.Length - 1].ToString());

                    file.SaveAs(fname);
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write("File Uploaded Successfully!");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}