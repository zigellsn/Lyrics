using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Lyrics
{
    public class Win32
    {
        public Win32()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [DllImport("User32.Dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int EM_LINEINDEX = 0xBB;
    } 
}
