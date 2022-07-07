using Rogui;
using Rogue.UI;
using Rogue.Services;

namespace Rogue.System
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
            SvcDisplay.KeyPressed += this.MainUI.OnKeyPressed;
            SvcDisplay.MouseMoved += this.MainUI.OnMouseMoved;
            SvcDisplay.MouseButtonPressed += this.MainUI.OnMouseButtonPressed;
            SvcDisplay.MouseButtonReleased += this.MainUI.OnMouseButtonReleased;
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