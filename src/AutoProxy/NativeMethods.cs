using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace AutoProxy
{
    [SuppressUnmanagedCodeSecurity]
    static class NativeMethods
    {
        static IntPtr Broadcast = new IntPtr(0xffff);

        enum WindowMessage : uint
        {
            SettingChange = 0x001AU
        }

        [Flags]
        enum SendMessageTimeouts : uint
        {
            Normal = 0x0000,
            Block = 0x0001,
            AbortIfHung = 0x0002,
            NoTimeoutIfNotHung = 0x0008
        }

        enum InternetOption : uint
        {
            SettingChanged = 0x27,
            Refresh = 0x25
        }

        [DllImport("wininet.dll", EntryPoint = "InternetSetOptionA",
                  CharSet = CharSet.Ansi, SetLastError = true, PreserveSig = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, InternetOption dwOption,
                                                     IntPtr pBuffer, int dwReserved);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr SendMessageTimeout(IntPtr hWnd,
                                                WindowMessage Msg,
                                                IntPtr wParam,
                                                IntPtr lParam,
                                                SendMessageTimeouts fuFlags,
                                                uint uTimeout,
                                                out IntPtr lpdwResult);

        public static void RefreshInternetOptions()
        {
            IntPtr tmp;
            SendMessageTimeout(
                Broadcast, WindowMessage.SettingChange,
                IntPtr.Zero, IntPtr.Zero,
                SendMessageTimeouts.Normal, 1000, out tmp);

            InternetSetOption(IntPtr.Zero, InternetOption.SettingChanged, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, InternetOption.Refresh, IntPtr.Zero, 0);
        }
    }
}
