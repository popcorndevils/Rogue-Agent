using System;
using Rogue.System;
using Rogue.Types;

using SFML.Graphics;

namespace Rogue.Services
{
    public class SvcState : BaseSvc<SysState>
    {   

        public static List<String>? DebugText => SvcState.Minion?.DebugText;
        public static GameSetting? Settings => SvcState.Minion?.Settings;
        public static Dictionary<DebugMetric, object?>? Metrics => SvcState.Minion?.Metrics;

        public static void Draw(Drawable d)
        {
            SvcDisplay.Minion?.Draw(d);
        }
    }
}