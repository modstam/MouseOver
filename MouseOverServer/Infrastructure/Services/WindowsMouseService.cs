using System;

namespace MouseOverServer.Infrastructure.Services
{
    public class WindowsMouseService : IWindowsMouseService
    {
        public bool IsCompatibleSystem()
        {
            throw new NotImplementedException();
        }

        public bool SetAbsoluteMousePosition(int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool SetAdjustedMousePosition(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
