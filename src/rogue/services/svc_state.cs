using SFML.Graphics;
using Rogue.System;
using Rogue.Types;

namespace Rogue.Services
{
    public class SvcState : BaseSvc<SysState>
    {   

        public static List<string>? DebugText => SvcState.Minion?.DebugText;
        public static GameSetting? Settings => SvcState.Minion?.Settings;
        public static Dictionary<DebugMetric, object?>? Metrics => SvcState.Minion?.Metrics;

        public static void Draw(Drawable d)
        {
            SvcDisplay.Minion?.Draw(d);
        }
    }
}