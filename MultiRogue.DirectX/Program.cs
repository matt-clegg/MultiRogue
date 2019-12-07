using MultiRogue.Core;
using System;

namespace MultiRogue.DirectX
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            const int windowWidth = 640 * 2;
            const int windowHeight = 384 * 2;
            const int gameWidth = 640;
            const int gameHeight = 384;
            const string title = "Multi Rogue";

            using (Engine engine = new Engine(windowWidth, windowHeight, gameWidth, gameHeight, title))
            {
                engine.Run();
            }
        }
    }
#endif
}
