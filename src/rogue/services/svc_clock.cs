using System;
using Rsys = Rogue.Systems;

namespace Rogue.Services
{
    public class SvcClock : BaseSvc<Rsys.SysClock>
    {   
        public static long? Ticks => SvcClock.Client?.Ticks;
    }
}