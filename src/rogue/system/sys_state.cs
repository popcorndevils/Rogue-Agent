using RogueAgent.Services;
using RogueAgent.Types;

namespace RogueAgent.System
{
    public class SysState : BaseSys
    {
        public GameSetting Settings = new GameSetting();
        public Dictionary<DebugMetric, object?> Metrics = new Dictionary<DebugMetric, object?>();
        
        public List<string> DebugText {
            get {
                var _output = new List<string>();
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