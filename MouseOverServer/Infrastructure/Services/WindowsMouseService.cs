using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MouseOverServer.Infrastructure.Services
{
    public class WindowsMouseService : IMouseService
    {
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        public bool IsCompatibleSystem()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return true;
            }
            return false;
        }


        public bool SetAbsoluteMousePosition(int x, int y)
        {
            try
            {

                if (x >= 0 && y >= 0)
                {
                    SetCursorPos(x, y);
                    return true;
                }
            }
            catch (Exception e)
            {
                //TODO: Handle logging 
            }
            return false;
        }

        public bool SetAdjustedMousePosition(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
