using System;
using System.Runtime.InteropServices;

namespace MouseOverServer.Infrastructure.Services
{
    public class WindowsMouseService : IMouseService
    {
        private readonly int _currentWidth;
        private readonly int _currentHeight;

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);
        const int ENUM_CURRENT_SETTINGS = -1;

        const int ENUM_REGISTRY_SETTINGS = -2;

        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {

            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            [MarshalAs(UnmanagedType.ByValArray)]
            public byte[] dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;

        }

        public WindowsMouseService()
        {

            try
            {
                DEVMODE vDevMode = new DEVMODE();
                var displaySetting = EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref vDevMode);
                _currentWidth = vDevMode.dmPelsWidth;
                _currentHeight = vDevMode.dmPelsHeight;
            }

            catch (Exception e)
            {
                //TODO: Handle logging
            }
        }

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
                double adjustedX = x * (_currentWidth / senderWidth);
                double adjustedY = y * (_currentHeight / senderHeight);

                try
                {
                    SetCursorPos((int)adjustedX, (int)adjustedY);
                    return true;
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
