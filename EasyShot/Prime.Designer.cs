namespace EasyShot
{
    partial class EasyShotForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasyShotForm));
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.Tray_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Take_link = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_folder = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator0 = new System.Windows.Forms.ToolStripSeparator();
            this.Settings_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveDlg = new System.Windows.Forms.SaveFileDialog();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Launch_control = new System.Windows.Forms.TabControl();
            this.Launch_page1 = new System.Windows.Forms.TabPage();
            this.Launch_switch = new System.Windows.Forms.CheckBox();
            this.Net_page2 = new System.Windows.Forms.TabPage();
            this.Open_Screen = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Hosting_switch = new System.Windows.Forms.ComboBox();
            this.Net_switch = new System.Windows.Forms.CheckBox();
            this.Image_page3 = new System.Windows.Forms.TabPage();
            this.Image_Quality = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Image_switch = new System.Windows.Forms.ComboBox();
            this.Tray_menu.SuspendLayout();
            this.Launch_control.SuspendLayout();
            this.Launch_page1.SuspendLayout();
            this.Net_page2.SuspendLayout();
            this.Image_page3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tray
            // 
            this.Tray.ContextMenuStrip = this.Tray_menu;
            this.Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray.Icon")));
            this.Tray.Text = "двойной клик - снимок экрана, правой - открыть меню";
            this.Tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseDoubleClick);
            // 
            // Tray_menu
            // 
            this.Tray_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Take_link,
            this.Open_folder,
            this.Separator0,
            this.Settings_menu,
            this.Separator1,
            this.Exit});
            this.Tray_menu.Name = "tray_menu";
            this.Tray_menu.Size = new System.Drawing.Size(172, 104);
            // 
            // Take_link
            // 
            this.Take_link.Enabled = false;
            this.Take_link.Name = "Take_link";
            this.Take_link.Size = new System.Drawing.Size(171, 22);
            this.Take_link.Text = "Получить ссылку";
            this.Take_link.ToolTipText = "Копирует в буфер обмена ссылку на последний снимок экрана";
            this.Take_link.Click += new System.EventHandler(this.Take_link_Click);
            // 
            // Open_folder
            // 
            this.Open_folder.Name = "Open_folder";
            this.Open_folder.Size = new System.Drawing.Size(171, 22);
            this.Open_folder.Text = "Открыть папку...";
            this.Open_folder.Click += new System.EventHandler(this.Open_folder_Click);
            // 
            // Separator0
            // 
            this.Separator0.Name = "Separator0";
            this.Separator0.Size = new System.Drawing.Size(168, 6);
            // 
            // Settings_menu
            // 
            this.Settings_menu.Name = "Settings_menu";
            this.Settings_menu.Size = new System.Drawing.Size(171, 22);
            this.Settings_menu.Text = "Настройки";
            this.Settings_menu.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(168, 6);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(171, 22);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(207, 192);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(81, 27);
            this.Save.TabIndex = 3;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(12, 192);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(77, 27);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Launch_control
            // 
            this.Launch_control.Controls.Add(this.Launch_page1);
            this.Launch_control.Controls.Add(this.Net_page2);
            this.Launch_control.Controls.Add(this.Image_page3);
            this.Launch_control.Location = new System.Drawing.Point(12, 12);
            this.Launch_control.Name = "Launch_control";
            this.Launch_control.SelectedIndex = 0;
            this.Launch_control.Size = new System.Drawing.Size(280, 174);
            this.Launch_control.TabIndex = 6;
            // 
            // Launch_page1
            // 
            this.Launch_page1.Controls.Add(this.Launch_switch);
            this.Launch_page1.Location = new System.Drawing.Point(4, 22);
            this.Launch_page1.Name = "Launch_page1";
            this.Launch_page1.Padding = new System.Windows.Forms.Padding(3);
            this.Launch_page1.Size = new System.Drawing.Size(272, 148);
            this.Launch_page1.TabIndex = 0;
            this.Launch_page1.Text = "Автозагрузка";
            this.Launch_page1.UseVisualStyleBackColor = true;
            // 
            // Launch_switch
            // 
            this.Launch_switch.AutoSize = true;
            this.Launch_switch.Location = new System.Drawing.Point(23, 28);
            this.Launch_switch.Name = "Launch_switch";
            this.Launch_switch.Size = new System.Drawing.Size(159, 17);
            this.Launch_switch.TabIndex = 2;
            this.Launch_switch.Text = "Автоматическая загрузка";
            this.Launch_switch.UseVisualStyleBackColor = true;
            this.Launch_switch.CheckedChanged += new System.EventHandler(this.Launch_swich_CheckedChanged);
            // 
            // Net_page2
            // 
            this.Net_page2.Controls.Add(this.Open_Screen);
            this.Net_page2.Controls.Add(this.Label1);
            this.Net_page2.Controls.Add(this.Hosting_switch);
            this.Net_page2.Controls.Add(this.Net_switch);
            this.Net_page2.Location = new System.Drawing.Point(4, 22);
            this.Net_page2.Name = "Net_page2";
            this.Net_page2.Padding = new System.Windows.Forms.Padding(3);
            this.Net_page2.Size = new System.Drawing.Size(272, 148);
            this.Net_page2.TabIndex = 1;
            this.Net_page2.Text = "Сеть";
            this.Net_page2.UseVisualStyleBackColor = true;
            // 
            // Open_Screen
            // 
            this.Open_Screen.AutoSize = true;
            this.Open_Screen.Location = new System.Drawing.Point(23, 115);
            this.Open_Screen.Name = "Open_Screen";
            this.Open_Screen.Size = new System.Drawing.Size(205, 17);
            this.Open_Screen.TabIndex = 3;
            this.Open_Screen.Text = "Открывать снимки после загрузки";
            this.Open_Screen.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(20, 63);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(127, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Выберите фотохостинг:";
            // 
            // Hosting_switch
            // 
            this.Hosting_switch.FormattingEnabled = true;
            this.Hosting_switch.Items.AddRange(new object[] {
            "Imgur"});
            this.Hosting_switch.Location = new System.Drawing.Point(23, 79);
            this.Hosting_switch.Name = "Hosting_switch";
            this.Hosting_switch.Size = new System.Drawing.Size(150, 21);
            this.Hosting_switch.TabIndex = 1;
            // 
            // Net_switch
            // 
            this.Net_switch.AutoSize = true;
            this.Net_switch.Location = new System.Drawing.Point(23, 28);
            this.Net_switch.Name = "Net_switch";
            this.Net_switch.Size = new System.Drawing.Size(203, 17);
            this.Net_switch.TabIndex = 0;
            this.Net_switch.Text = "Загружать снимки на фотохостинг";
            this.Net_switch.UseVisualStyleBackColor = true;
            this.Net_switch.CheckedChanged += new System.EventHandler(this.Net_switch_CheckedChanged);
            // 
            // Image_page3
            // 
            this.Image_page3.Controls.Add(this.Image_Quality);
            this.Image_page3.Controls.Add(this.label3);
            this.Image_page3.Controls.Add(this.label2);
            this.Image_page3.Controls.Add(this.Image_switch);
            this.Image_page3.Location = new System.Drawing.Point(4, 22);
            this.Image_page3.Name = "Image_page3";
            this.Image_page3.Size = new System.Drawing.Size(272, 148);
            this.Image_page3.TabIndex = 2;
            this.Image_page3.Text = "Изображение";
            this.Image_page3.UseVisualStyleBackColor = true;
            // 
            // Image_Quality
            // 
            this.Image_Quality.FormattingEnabled = true;
            this.Image_Quality.Items.AddRange(new object[] {
            "25%",
            "50%",
            "75%",
            "100%"});
            this.Image_Quality.Location = new System.Drawing.Point(23, 91);
            this.Image_Quality.Name = "Image_Quality";
            this.Image_Quality.Size = new System.Drawing.Size(150, 21);
            this.Image_Quality.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Качество изображения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Формат изображения:";
            // 
            // Image_switch
            // 
            this.Image_switch.FormattingEnabled = true;
            this.Image_switch.Items.AddRange(new object[] {
            "BMP",
            "JPEG",
            "TIFF",
            "PNG"});
            this.Image_switch.Location = new System.Drawing.Point(23, 32);
            this.Image_switch.Name = "Image_switch";
            this.Image_switch.Size = new System.Drawing.Size(150, 21);
            this.Image_switch.TabIndex = 0;
            this.Image_switch.SelectedIndexChanged += new System.EventHandler(this.Image_switch_SelectedIndexChanged);
            // 
            // EasyShotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 226);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Launch_control);
            this.Enabled = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 4000);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EasyShotForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EasyShot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EasyShotForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EasyShotForm_Paint);
            this.Tray_menu.ResumeLayout(false);
            this.Launch_control.ResumeLayout(false);
            this.Launch_page1.ResumeLayout(false);
            this.Launch_page1.PerformLayout();
            this.Net_page2.ResumeLayout(false);
            this.Net_page2.PerformLayout();
            this.Image_page3.ResumeLayout(false);
            this.Image_page3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip Tray_menu;
        private System.Windows.Forms.ToolStripMenuItem Take_link;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        public System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.ToolStripSeparator Separator0;
        private System.Windows.Forms.SaveFileDialog SaveDlg;
        private System.Windows.Forms.ToolStripMenuItem Open_folder;
        private System.Windows.Forms.ToolStripMenuItem Settings_menu;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TabControl Launch_control;
        private System.Windows.Forms.TabPage Launch_page1;
        private System.Windows.Forms.TabPage Net_page2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox Hosting_switch;
        private System.Windows.Forms.CheckBox Net_switch;
        private System.Windows.Forms.CheckBox Launch_switch;
        private System.Windows.Forms.CheckBox Open_Screen;
        private System.Windows.Forms.TabPage Image_page3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Image_switch;
        private System.Windows.Forms.ComboBox Image_Quality;
        private System.Windows.Forms.Label label3;
    }
}

