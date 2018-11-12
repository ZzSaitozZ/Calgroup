using System.Drawing;

namespace Calgroup.Resources.Common
{
    public class Resizeimage
    {
        public static string Resize(string filename, int width, int height)
        {
            filename = "~" + filename;
            Image image = Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(filename));
            new Bitmap(image, width, height).Save(System.Web.HttpContext.Current.Server.MapPath(filename.Insert(filename.LastIndexOf('.'), "_S")));
            return filename.Insert(filename.LastIndexOf('.'), "_S");
        }
    }
}