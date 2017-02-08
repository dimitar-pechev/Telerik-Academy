using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjaxControls
{
    public partial class PhotoAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = this.Server.MapPath("~/Gallery");

            Uri pathUri = new Uri(path, UriKind.Absolute);
            string[] files = Directory.GetFiles(path);

            var images = new List<GalleryImage>();
            foreach (string file in files)
            {
                Uri filePathUri = new Uri(file, UriKind.Absolute);
                images.Add(new GalleryImage
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    Url = pathUri.MakeRelativeUri(filePathUri).ToString()
                });
            }

            this.ListViewImages.DataSource = images;
            this.ListViewImages.DataBind();
        }

        [WebMethod]
        [ScriptMethod]
        public static Slide[] GetImages()
        {
            List<Slide> slides = new List<Slide>();
            string path = HttpContext.Current.Server.MapPath("~/Gallery");

            Uri pathUri = new Uri(path, UriKind.Absolute);
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                Uri filePathUri = new Uri(file, UriKind.Absolute);
                slides.Add(new Slide
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    Description = Path.GetFileNameWithoutExtension(file) + " Description.",
                    ImagePath = pathUri.MakeRelativeUri(filePathUri).ToString()
                });
            }

            return slides.ToArray();
        }

        protected void Click_ImagePreviewContainer()
        {

        }
    }
}