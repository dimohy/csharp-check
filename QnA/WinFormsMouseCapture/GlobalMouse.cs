using Gma.System.MouseKeyHook;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMouseCapture
{
    public static class GlobalMouse
    {
        private static IKeyboardMouseEvents _globalHook;

        static GlobalMouse()
        {
            _globalHook = Hook.GlobalEvents();
        }

        public static void CaptureMouse(EventHandler<MouseEventExtArgs> mouseEventHandler)
        {
            _globalHook.MouseMoveExt += mouseEventHandler;
            _globalHook.MouseDownExt += mouseEventHandler;
        }

        public static void ReleaseMouse(EventHandler<MouseEventExtArgs> mouseEventHandler)
        {
            _globalHook.MouseMoveExt -= mouseEventHandler;
            _globalHook.MouseDownExt -= mouseEventHandler;
        }
    }
}
