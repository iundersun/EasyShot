using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace EasyShot
{
    sealed class Save
    {
        const string DATE_FORMAT = "{0:dd.MM.yyyy_HH-mm-ss}";
        private readonly DateTime datetime;

        public Save(DateTime dt)
        {
            datetime = dt;
        }

        public void SaveImage(byte[] data)
        {
            FileStream name = new FileStream(Program.Prime.myDirectory + GetFileName() + GetImageSettings(), FileMode.Create);
            try
            {
                name.Write(data, 0, data.Length);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Скриншот не сохранен...\n" + ex.Message, "Error!");
            }
            finally
            {
                name.Dispose();
            }
        }

        private static string GetImageSettings()
        {
            switch (Properties.Settings.Default.image)
            {
                case 0: return ".bmp";
                case 1: return ".jpeg";
                case 2: return ".tiff";
                case 3: return ".png";
                default: return ".jpeg";
            }
        }

        private string GetFileName()
        {
            return String.Format(DATE_FORMAT, datetime);
        }
    }
}
