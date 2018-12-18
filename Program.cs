using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace SharpScreenshot
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName;
            if (args.Length == 1)
            {
                fileName = args[0];
            }
            else
            {
                fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".jpeg";
            }
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            try
            {
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    bitmap.Save(fileName, ImageFormat.Jpeg);
                }
                Console.WriteLine("[+] Saved screenshot to:");
                Console.WriteLine("\t{0}", fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[X] Error: {0}", ex);
            }
        }
    }
}
