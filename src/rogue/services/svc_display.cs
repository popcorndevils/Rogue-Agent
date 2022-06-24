using Rsys = Rogue.Systems;

namespace Rogue.Services
{
    public static class SvcDisplay
    {    
        private static Rsys.SysDisplay? Display;

        internal static void Register(Rsys.SysDisplay display)
        {
            SvcDisplay.Display = display;
        }
    }
}