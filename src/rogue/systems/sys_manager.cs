using Rogue.Services;

namespace Rogue.Systems
{
    public class SysManager
    {
        private SysDisplay Display;
        private SysClock Clock;

        private bool _Running = true;
        public bool Running {
            get {
                return this._Running;
            }
            private set {
                this._Running = value;
            }
        }

        public SysManager()
        {
            this.Clock = new SysClock() {FrameLimit = 60};
            this.Display = new SysDisplay();

            SvcClock.Register(this.Clock);
            SvcDisplay.Register(this.Display);

            // link display close event
            this.Display.DisplayClosed += this.OnDisplayClose;
        }

        public void Update()
        {
            this.Clock.Update();
            this.Display.Update();
        }

        private void OnDisplayClose(object? sender, EventArgs e)
        {
            this.Running = false;
        }
    }
}