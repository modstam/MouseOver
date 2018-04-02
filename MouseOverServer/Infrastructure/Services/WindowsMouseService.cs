using System;
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
            if (x >= 0 && y >= 0)
            {
                try
                {
                    SetCursorPos(x, y);
                    return true;
                }

                catch (Exception e)
                {
                    //TODO: Handle logging 
                }
            }
            return false;
        }

        public bool SetAdjustedMousePosition(int x, int y, int senderWidth, int senderHeight)
        {
            if (x >= 0 && y >= 0 && senderWidth >= 0 && senderHeight >= 0)
            {
                try
                {
                    
                }
                catch(Exception e)
                {
                    //TODO: Handle logging
                }
            }
            return false;
        }
    }
}
