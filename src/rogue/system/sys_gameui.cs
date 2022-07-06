using Rogue.Aspects;
using Rogue.Aspects.Prefabs;
using Rogue.Aspects.Containers;
using Rogue.Services;

namespace Rogue.System
{
    public class SysGameUI : BaseSys
    {
        private Container Container = new Container();
        private DebugView DebugView = new DebugView();

        public void Add(params Aspect[] aspects)
        {
            this.Container.Add(aspects);
        }

        public override void Update(float? ms)
        {
            this.Container.Update(ms);
            this.DebugView.Update(ms);
        }
        
        public override void Render()
        {
            SvcDisplay.Draw(this.Container);
            SvcDisplay.Draw(this.DebugView);
        }

        public void ToggleDebug()
        {
            this.DebugView.Visible = !this.DebugView.Visible;
        }
    }
}