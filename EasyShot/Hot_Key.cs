using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

namespace EasyShot
{
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]

    sealed class Hot_Key:IMessageFilter
    {
        const int WM_HOTKEY = 0x312;
        EasyShotForm easyShotForm;

        public Hot_Key(EasyShotForm form)
        {
            easyShotForm = form;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                switch ((int)m.WParam)
                {
                    case 1:
                        easyShotForm.Handle1Hotkey();
                        break;
                    case 2:
                        easyShotForm.Handle2Hotkey();
                        break;
                    default:
                        MessageBox.Show("Ошибка обработчика хоткея", "EasyShot",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}
