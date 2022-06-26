using System;
using Rogue.Systems;
using Rogue.Types;

using SFML.Graphics;

namespace Rogue.Services
{
    public class SvcState : BaseSvc<SysState>
    {   

        public static List<String>? DebugText => SvcState.Client?.DebugText;
        public static GameSettings? Settings => SvcState.Client?.Settings;
        public static Dictionary<DebugMetrics, object?>? Metrics => SvcState.Client?.Metrics;

        public static void Draw(Drawable d)
        {
            SvcDisplay.Client?.Draw(d);
        }
    }
}