using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EasyShot
{
    static class Program
    {
        public static EasyShotForm Prime;

        #region для перехвата клавиш
        const int ALT = 0x0001;
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifires, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            bool requestInitialOwnership = true;
            bool mutexWasCreated;

            System.Threading.Mutex mutex = new System.Threading.Mutex(requestInitialOwnership, 
                "MyMutex", out mutexWasCreated);
            if (!(requestInitialOwnership && mutexWasCreated))
            {
                MessageBox.Show("Программа уже запущена", "EasyShot",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //для общения с обьектами на форме
                Prime = new EasyShotForm();

                Hot_Key messageFilter = new Hot_Key(Prime);//
                Application.AddMessageFilter(messageFilter); //добавляем фильтр для перехвата кнопки
                RegisterHotKey(new IntPtr(0), 1, 0, (int)Keys.PrintScreen);//регистрируем PtrSc
                RegisterHotKey(new IntPtr(0), 2, ALT, (int)Keys.PrintScreen); //регистрируем alt+PrtSc
                Application.Run(Prime);
                
                UnregisterHotKey(new IntPtr(0), 1); //чистим
                UnregisterHotKey(new IntPtr(0), 2); //чистим
            }
            mutex.ReleaseMutex();
        }
    }
}
