using System.Diagnostics;

namespace Rogue.Systems
{
    public class SysClock : BaseSys
    {
        public long Ticks;

        public SysClock()
        {
            this.Ticks = Stopwatch.GetTimestamp();
        }

        public override void Update(uint? delta)
        {
            this.Ticks = Stopwatch.GetTimestamp();
        }
    }
}