using MouseOverServer.Infrastructure.Services;
using System;
using System.Collections.Generic;
namespace MouseOverServer.Infrastructure.Managers
{
    public class MouseManager : IMouseManager
    {
        private readonly IMouseService _mouseService;

        public MouseManager(IEnumerable<IMouseService> mouseServices)
        {
            foreach (IMouseService service in mouseServices)
            {
                if (service.IsCompatibleSystem())
                {
                    _mouseService = service;
                    break;
                }
            }
        }

        public bool SetMouseAbsolute(int x, int y)
        {
            if(_mouseService != null)
            {
                return _mouseService.SetAbsoluteMousePosition(x, y);
            }
            return false;
        }

        public bool SetMouseAdjusted(int x, int y, int resX, int resY)
        {
            if (_mouseService != null)
            {
                return _mouseService.SetAdjustedMousePosition(x, y, resX, resY);
            }
            return false;
        }
    }
}
