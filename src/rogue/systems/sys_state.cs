using System.Collections.Generic;

using Rogue.Services;
using Rogue.Types;

namespace Rogue.Systems
{
    public class SysState : BaseSys
    {
        public GameSettings Settings = new GameSettings();
        public Dictionary<DebugMetrics, object?> Metrics = new Dictionary<DebugMetrics, object?>();
        
        public List<String> DebugText {
            get {
                var _output = new List<String>();
                if(SvcState.Metrics is not null)
                {
                    foreach(KeyValuePair<DebugMetrics, object?> p in SvcState.Metrics)
                    {
                        _output.Add($"{p.Key} : {p.Value}");
                    }
                }
                return _output;
            }
        }

        public override void Update()
        {
            this.Metrics[DebugMetrics.DELTA_MS] = null;
            this.Metrics[DebugMetrics.DELTA_FRAMES] = SvcClock.DeltaFps;
            this.Metrics[DebugMetrics.DELTA_TICKS] = SvcClock.DeltaT;
        }
    }
}