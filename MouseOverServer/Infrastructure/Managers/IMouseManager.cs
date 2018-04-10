using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseOverServer.Infrastructure.Managers
{
    public interface IMouseManager
    {
        bool SetMouseAbsolute(int x, int y);
        bool SetMouseAdjusted(int x, int y, int resX, int resY);

        bool ClickMouseAbsolute(int x, int y);
        bool ClickMouseAdjusted(int x, int y, int resX, int resY);
    }
}
