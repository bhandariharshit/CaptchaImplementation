using CaptchaImplementation.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace CaptchaImplementation.Common
{
    public class CaptchaHandler
    {
        public static void GenerateCaptcha(int width, int height,int charLength)
        {
            try
            {
                using (Bitmap objBitmap = new Bitmap(width, height))
                {
                    using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                    {
                        objGraphics.Clear(Color.Blue);
                        using (Font objFont = new Font(FontFamily.GenericSerif, 25))
                        {
                            Random objRandom = new Random();
                            string randomNo = objRandom.Next(0, 1000000).ToString("D6");
                            HttpContext.Current.Session[Cons.CaptchaSessionKey] = randomNo;

                            objGraphics.DrawString(randomNo, objFont, Brushes.White, 3, 3);
                            HttpContext.Current.Response.ContentType = "image/GIF";
                            objBitmap.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Gif);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}