using System;
using Rsys = Rogue.Systems;

namespace Rogue.Services
{
    public class SvcClock : BaseSvc<Rsys.SysClock>
    {   
        public static long? Ticks => SvcClock.Client?.Ticks;
        public static long? DeltaT => SvcClock.Client?.DeltaT;
        public static float? DeltaFps => SvcClock.Client?.DeltaFps;
    }
}