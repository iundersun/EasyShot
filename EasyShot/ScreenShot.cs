using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

namespace EasyShot
{
    sealed class ScreenShot
    {
        #region для снимка активного окна
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, ref RECT rectangle);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        #endregion


        //снимок главного монитора
        public static byte[] MakeDesktopShot()
        {
            Screen screen = Screen.PrimaryScreen;
            Bitmap bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
            using (Graphics gfx = Graphics.FromImage(bitmap))
            {
                gfx.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, new Size(bitmap.Width, bitmap.Height));
            }
            MemoryStream ms = new MemoryStream();
            EncoderParameter enParam = new EncoderParameter(Encoder.Quality, GetImageQuality());
            EncoderParameters enParams=new EncoderParameters(1);
            enParams.Param[0]=enParam;
            ImageCodecInfo codecInfo = GetEncoderInfo(GetImageSettings());
            bitmap.Save(ms, codecInfo, enParams);
            bitmap.Dispose();
            byte[] ret_data = ms.ToArray();
            ms.Close();
            return ret_data;
        }

        //снимок активного окна
        public static byte[] MakeActiveWindowShot()
        {
            IntPtr intptr = ScreenShot.GetForegroundWindow();
            RECT rect = GetActiveWindowRect(intptr);
            Screen screen;
            byte[] ret_data;

            //если нет активного окна - в фокусе черти-что размера 54х54. избавляемся от этого 
            if (rect.right - rect.left <= 54)
            {
                //делаем снимок экрана
                ret_data = MakeDesktopShot(); 
            }
            else  //если все нормально - снимаем само окно
            {
                screen = Screen.FromHandle(intptr);
                Bitmap bitmap = new Bitmap(rect.right - rect.left, rect.bottom - rect.top);
                using (Graphics gfx = Graphics.FromImage(bitmap))
                {
                    gfx.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(bitmap.Width, bitmap.Height));
                }
                MemoryStream ms = new MemoryStream();
                EncoderParameter enParam = new EncoderParameter(Encoder.Quality, GetImageQuality());
                EncoderParameters enParams = new EncoderParameters(1);
                enParams.Param[0] = enParam;
                ImageCodecInfo codecInfo = GetEncoderInfo(GetImageSettings());
                bitmap.Save(ms, codecInfo, enParams);
                bitmap.Dispose();
                ret_data = ms.ToArray();
                ms.Close();
            }
            return ret_data;
        }

        private static Int64 GetImageQuality()
        {
            switch(Properties.Settings.Default.quality)
            {
                case 0: return 25L;
                case 1: return 50L;
                case 2: return 75L;
                case 3: return 100L;
                default: return 100L;
            }
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        private static string GetImageSettings()
        {
            switch(Properties.Settings.Default.image)
            {
                case 0: return "image/bmp";
                case 1: return "image/jpeg";
                case 2: return "image/tiff";
                case 3: return "image/png";
                default: return "image/jpeg";
            }
        }

        private static RECT GetActiveWindowRect(IntPtr hwnd)
        {
            RECT rect = new RECT();

            if (!GetWindowRect(hwnd, ref rect))
            {
                MessageBox.Show("Ошибка: не найдено активное окно!", "EasyShot",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //когда окно в полноэкранном режиме - значения больше на 8 единиц чем экран
            //когда окно вылазит за границы экрана
            //этот кусок кода нормализирует значения
            if (rect.left < Screen.PrimaryScreen.WorkingArea.Left)
            {
                rect.left = Screen.PrimaryScreen.WorkingArea.Left;
            }
            if (rect.top < Screen.PrimaryScreen.WorkingArea.Top)
            {
                rect.top = Screen.PrimaryScreen.WorkingArea.Top;
            }
            if (rect.right > Screen.PrimaryScreen.WorkingArea.Width)
            {
                rect.right = Screen.PrimaryScreen.WorkingArea.Width;
            }
            if (rect.bottom > Screen.PrimaryScreen.WorkingArea.Height)
            {
                rect.bottom = Screen.PrimaryScreen.WorkingArea.Height;
            }

            return rect;
        }
    }
}
