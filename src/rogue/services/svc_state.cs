using SFML.Graphics;
using RogueAgent.System;
using RogueAgent.Types;

namespace RogueAgent.Services
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