using Rsys = RogueAgent.System;

namespace RogueAgent.Services
{
    public class SvcClock : BaseSvc<Rsys.SysClock>
    {   
        public static long? Ticks => SvcClock.Minion?.Ticks;
        public static long? DeltaT => SvcClock.Minion?.DeltaT;
        public static float? DeltaFps => SvcClock.Minion?.DeltaFps;
        public static float? DeltaMS => SvcClock.Minion?.DeltaMS;
    }
}