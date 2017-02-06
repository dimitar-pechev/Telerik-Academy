using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetFileUpload
{
    public partial class UploadTxts : System.Web.UI.Page
    {
        private TxtFilesEntities db = new TxtFilesEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadForm_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            var result = new Dictionary<string, string>();
            using (ZipFile zip = ZipFile.Read(e.GetStreamContents()))
            {
                foreach (ZipEntry entry in zip)
                {
                    MemoryStream data = new MemoryStream();
                    entry.Extract(data);
                    var resString = Encoding.UTF8.GetString(data.ToArray());
                    result.Add(entry.FileName, resString);
                }
            }

            foreach (var file in result)
            {
                var fileArr = file.Key.Split('.').ToList();
                var fileExtesion = fileArr.Last();
                fileArr.RemoveAt(fileArr.Count - 1);
                var fileName = string.Join("", fileArr);
                var txtFile = new AspNetFileUpload.File() { FileName = fileName, FileExtension = fileExtesion, FileContent = file.Value };

                this.db.Files.Add(txtFile);
            }

            this.db.SaveChanges();
        }

        protected void BtnGetFilesFromDb_Click(object sender, EventArgs e)
        {
            var files = this.db.Files.ToList();
            files.Reverse();

            foreach (var file in files)
            {
                var label = new Label();
                label.Text = $"<b>{file.FileName}.{file.FileExtension}</b><br /> {file.FileContent}<br />";
                this.Result.Controls.Add(label);
            }

            this.Result.Visible = true;
        }
    }
}