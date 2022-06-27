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
                if(this.Metrics is not null)
                {
                    foreach(KeyValuePair<DebugMetric, object?> p in this.Metrics)
                    {
                        _output.Add($"{p.Key} : {p.Value}");
                    }
                }
                return _output;
            }
        }

        public override void Initialize()
        {
            SvcInput.ToggleShowDebug += this.OnToggleShowDebug;
        }

        public void OnToggleShowDebug(object? sender, EventArgs e)
        {
            this.Settings.DISPLAY_DEBUG = this.Settings.DISPLAY_DEBUG == false;
        }
    }
}