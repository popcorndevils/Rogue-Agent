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
            this.Clock = new SysClock();
            this.Display = new SysDisplay();
            this.State = new SysState();
            this.Input = new SysInput();

            SvcClock.Register(this.Clock);
            SvcDisplay.Register(this.Display);
            SvcInput.Register(this.Input);
            SvcState.Register(this.State);

            // link display close event
            SvcInput.GameExit += this.OnExitGame;
        }

        public void Update()
        {
            this.Clock.Update();
            this.State.Update();
            this.Display.Update();
        }

        private void OnExitGame(object? sender, EventArgs e)
        {
            this.Display.Window.Close();
            this.Running = false;
        }
    }
}