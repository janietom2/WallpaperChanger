using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wallpaperchanger
{
    class Image
    {

        public static void DownloadFromWeb(string imageUrl, string directory, string fileName)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri(imageUrl),
                    // Param2 = Path to save
                    directory+fileName
                );
            }
        }
    }

}
