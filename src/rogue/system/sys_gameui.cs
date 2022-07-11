using Rogui;
using RogueAgent.UI;
using RogueAgent.Services;

namespace RogueAgent.System
{
    public class SysGameUI : BaseSys
    {
        private UIController MainUI = new UIController();
        private DebugView DebugUI = new DebugView();

        public void Add(params Aspect[] aspects)
        {
            this.MainUI.Add(aspects);
        }

        public override void Initialize()
        {
            this.MainUI.Window = SvcDisplay.Window;
        }

        public override void Update(float? ms)
        {
            this.MainUI.Update(ms);
            this.DebugUI.Update(ms);
        }
        
        public override void Render()
        {
            SvcDisplay.Draw(this.MainUI);
            SvcDisplay.Draw(this.DebugUI);
        }

        public void ToggleDebug()
        {
            this.DebugUI.Visible = !this.DebugUI.Visible;
        }
    }
}