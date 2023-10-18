using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PS.ActivityVerification
{
    public class CurrentProcess
    {
        public static IntPtr CurrentActiveApplication()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return IntPtr.Zero;       // No window is currently activated
            }

            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);
            var procces = Process.GetProcessById(activeProcId);
            return procces.MainWindowHandle;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    }

}
