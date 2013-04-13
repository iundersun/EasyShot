using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EasyShot
{

    sealed public partial class EasyShotForm : Form
    {
        private string url = "";
        private bool proc_status=false; //статус процесса создания и загрузки снимка(1 = активный, 0 = не активный )
        public readonly string myDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EasyShot\Screenshots\";

        public EasyShotForm()
        {
            InitializeComponent();
            /////////////////////////////////////
            Tray.Visible = true;
            CreateDirectory();
        }

        //сработал хоткей PrtScr
        public void Handle1Hotkey()
        {
            if (!proc_status)
            {
                proc_status = true;
                Save save = new Save(DateTime.Now);
                byte[] bitmapData = ScreenShot.MakeDesktopShot();
                CreateDirectory();
                save.SaveImage(bitmapData); //скриншот на диск
                Tray.ShowBalloonTip(2000, "EasyShot", "Скрин удачно сохранен!", ToolTipIcon.Info);
                Take_link.Enabled = false;
                if (Properties.Settings.Default.net)
                {
                    Load_screen(bitmapData); //скриншот на сервер
                }
                proc_status = false;
            }
        }

        //сработал хоткей alt+PrtScr
        public void Handle2Hotkey()
        {
            if (!proc_status)
            {
                proc_status = true;
                Save save = new Save(DateTime.Now);
                byte[] bitmapData = ScreenShot.MakeActiveWindowShot();
                CreateDirectory();
                save.SaveImage(bitmapData); //скриншот на диск
                Tray.ShowBalloonTip(2000, "EasyShot", "Скрин удачно сохранен!", ToolTipIcon.Info);
                Take_link.Enabled = false;
                if (Properties.Settings.Default.net)
                {
                    Load_screen(bitmapData); //скриншот на сервер
                }
                proc_status = false;
            }
        }

        //загружаем снимок на сервер
        private void Load_screen(byte[] data)
        {
            Tray.ShowBalloonTip(10000, "EasyShot", "Загрузка на хостинг...", ToolTipIcon.Info);
            url = Network.PostToImgur(data);
            if (url[0] != '!')
            {
                Take_link.Enabled = true;
                Tray.ShowBalloonTip(2000, "EasyShot", "Заргузка удачно завершена!", ToolTipIcon.Info);
                if (Properties.Settings.Default.open_screen)
                {
                    OpenLink(url);
                }
            }
            else
            {
                Tray.ShowBalloonTip(2000, "EasyShot", "Произошла ошибка при загрузке!\n\n" + url, ToolTipIcon.Error);
            }
        }

        //ссылка по клике на BalloonTip
        //private void tray_BalloonTipClicked(Object sender, EventArgs e)
        //{
        //    OpenLink(url);
        //}

            //tray.BalloonTipClicked += new EventHandler(tray_BalloonTipClicked);
        //tray.BalloonTipClicked -= new EventHandler(tray_BalloonTipClicked); 

        #region Tray_menu
        private void Tray_MouseDoubleClick(object sender, EventArgs e)
        {
            Handle1Hotkey();
        }

        private void Take_link_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(url);
        }

        private void Open_folder_Click(object sender, EventArgs e)
        {
            CreateDirectory();
            OpenLink(myDirectory);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
#endregion

        #region Settings
        private void Settings_Click(object sender, EventArgs e)
        {
            //показать форму
            int x, y;
            x = Screen.PrimaryScreen.WorkingArea.Right-this.RestoreBounds.Size.Width;
            y = Screen.PrimaryScreen.WorkingArea.Bottom - this.RestoreBounds.Size.Height;
            this.Enabled = true;
            this.Location = new System.Drawing.Point(x, y);
            //настройки загрузки на хостинг
            if (!Properties.Settings.Default.net)
            {
                Net_switch.Checked = false;
            }
            else
            {
                Net_switch.Checked = true;
                if (Properties.Settings.Default.open_screen)
                {
                    Open_Screen.Checked = true;
                }
                else
                {
                    Open_Screen.Checked = false;
                }
            }
            Hosting_switch.SelectedIndex = Properties.Settings.Default.hosting;
            //настройки автозагрузки приложения
            if (!AutoLaunch.IsAutoLaunchEnabled)
            {
                Launch_switch.Checked = false;
            }
            else
            {
                Launch_switch.Checked = true;
            }
            //настройки изображений
            Image_switch.SelectedIndex = Properties.Settings.Default.image;
            Image_Quality.SelectedIndex = Properties.Settings.Default.quality;
            if (Properties.Settings.Default.image != 1)
            {
                Image_Quality.Enabled = false;
            }
            else
            {
                Image_Quality.Enabled = true;
            }
            /////////////////////////////////////////
            this.Visible = true;
            this.Activate();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //записать в реестр
            if (Launch_switch.Checked)
            {
                AutoLaunch.EnableAutoStart();
            }
            else
            {
                AutoLaunch.DisableAutoLaunch();
            }
            //настройки загрузки на хостинг
            if (!Net_switch.Checked)
            {
                Properties.Settings.Default.net = false;
            }
            else
            {
                Properties.Settings.Default.net = true;
                Properties.Settings.Default.hosting = Hosting_switch.SelectedIndex;
                if (!Open_Screen.Checked)
                {
                    Properties.Settings.Default.open_screen = false;
                }
                else
                {
                    Properties.Settings.Default.open_screen = true;
                }
            }
            //настройки изображений
            Properties.Settings.Default.image = Image_switch.SelectedIndex;
            Properties.Settings.Default.quality = Image_Quality.SelectedIndex;
            //сохранение настроек
            Properties.Settings.Default.Save();

            //скрыть форму
            this.Enabled = false;
            this.Visible = false;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //скрыть форму
            this.Enabled = false;
            this.Visible = false;
        }

        private void Image_switch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Image_switch.SelectedIndex != 1)
            {
                Image_Quality.Enabled = false;
            }
            else
            {
                Image_Quality.Enabled = true;
            }
        }

        #region colors
        private void Launch_swich_CheckedChanged(object sender, EventArgs e)
        {
            if (Launch_switch.Checked)
            {
                Launch_page1.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            }
            else
            {
                Launch_page1.BackColor = System.Drawing.Color.Silver;
            }
        }

        private void EasyShotForm_Paint(object sender, PaintEventArgs e)
        {
            if (Launch_switch.Checked)
            {
                Launch_page1.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            }
            else
            {
                Launch_page1.BackColor = System.Drawing.Color.Silver;
            }

            if (Net_switch.Checked)
            {
                Net_page2.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                Hosting_switch.Enabled = true;
                Open_Screen.Enabled = true;
            }
            else
            {
                Net_page2.BackColor = System.Drawing.Color.Silver;
                Hosting_switch.Enabled = false;
                Open_Screen.Enabled = false;
            }
        }

        private void Net_switch_CheckedChanged(object sender, EventArgs e)
        {
            if (Net_switch.Checked)
            {
                Net_page2.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                Hosting_switch.Enabled = true;
                Open_Screen.Enabled = true;
            }
            else
            {
                Net_page2.BackColor = System.Drawing.Color.Silver;
                Hosting_switch.Enabled = false;
                Open_Screen.Enabled = false;
            }
        }
        #endregion
        #endregion

        private void CreateDirectory()
        {
            if (!Directory.Exists(myDirectory))
            {
                Directory.CreateDirectory(myDirectory);
            }
        }

        private void EasyShotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Environment.Exit(0);
            e.Cancel = true;
            this.Enabled = false;
            this.Visible = false;
        }

        //Copied this "as-is" from Microsoft recommendation
        private void OpenLink(string sUrl)
        {
            try
            {
                System.Diagnostics.Process.Start(sUrl);
            }
            catch
                (
                 System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
}
