using System.Collections.Generic;

using Rogue.Services;
using Rogue.Types;

namespace Rogue.System
{
    public class SysState : BaseSys
    {
        public GameSetting Settings = new GameSetting();
        public Dictionary<DebugMetric, object?> Metrics = new Dictionary<DebugMetric, object?>();
        
        public List<String> DebugText {
            get {
                var _output = new List<String>();
                if(SvcState.Metrics is not null)
                {
                    foreach(KeyValuePair<DebugMetric, object?> p in SvcState.Metrics)
                    {
                        _output.Add($"{p.Key} : {p.Value}");
                    }
                }
                return _output;
            }
        }

        public override void Initialize() { }

        public override void Update()
        {
            this.Metrics[DebugMetric.DELTA_MS] = null;
            this.Metrics[DebugMetric.DELTA_FRAMES] = SvcClock.DeltaFps;
            this.Metrics[DebugMetric.DELTA_TICKS] = SvcClock.DeltaT;
        }
    }
}