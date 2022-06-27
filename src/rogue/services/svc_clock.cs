using System;
using Rsys = Rogue.System;

namespace Rogue.Services
{
    public class SvcClock : BaseSvc<Rsys.SysClock>
    {   
        public static long? Ticks => SvcClock.Client?.Ticks;
        public static long? DeltaT => SvcClock.Client?.DeltaT;
        public static float? DeltaFps => SvcClock.Client?.DeltaFps;
        public static float? DeltaMS => SvcClock.Client?.DeltaMS;
    }
}