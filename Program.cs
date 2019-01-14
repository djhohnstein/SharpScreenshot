using System;
using System.Collections.Generic;
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
                // Determine the size of the "virtual screen", which includes all monitors.
                int screenLeft = SystemInformation.VirtualScreen.Left;
                int screenTop = SystemInformation.VirtualScreen.Top;
                int screenWidth = SystemInformation.VirtualScreen.Width;
                int screenHeight = SystemInformation.VirtualScreen.Height;

                // Create a bitmap of the appropriate size to receive the screenshot.
                using (Bitmap bmp = new Bitmap(screenWidth, screenHeight))
                {
                    // Draw the screenshot into our bitmap.
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(screenLeft, screenTop, 0, 0, bmp.Size);
                    }

                    // Do something with the Bitmap here, like save it to a file:
                    bmp.Save(fileName, ImageFormat.Jpeg);
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
