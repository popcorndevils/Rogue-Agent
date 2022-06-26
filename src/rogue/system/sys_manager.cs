using Rogue.Services;

namespace Rogue.System
{
    public class SysManager
    {
        private SysClock Clock;
        private SysDisplay Display;
        private SysState State;
        private SysInput Input;

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
            this.State = new SysState();
            this.Input = new SysInput();

            SvcClock.Register(this.Clock);
            SvcDisplay.Register(this.Display);
            SvcState.Register(this.State);
            SvcInput.Register(this.Input);

            // link display close event
            this.Display.DisplayClosed += this.OnDisplayClose;
        }

        public void Update()
        {
            this.Clock.Update();
            this.State.Update();
            this.Display.Update();
        }

        private void OnDisplayClose(object? sender, EventArgs e)
        {
            this.Running = false;
        }
    }
}