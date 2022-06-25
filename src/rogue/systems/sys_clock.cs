using System;
using System.Diagnostics;
using Rogue.Services;

namespace Rogue.Systems
{
    public class SysClock : BaseSys
    {
        public long Ticks;

        public SysClock()
        {
            SvcClock.Register(this);
            this.Ticks = Stopwatch.GetTimestamp();
        }

        public override void Update(uint? delta)
        {
            this.Ticks = Stopwatch.GetTimestamp();
        }
    }
}