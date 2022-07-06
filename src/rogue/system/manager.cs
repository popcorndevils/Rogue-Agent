using Rogue.Services;

namespace Rogue.System
{
    public class Manager
    {
        private bool _Running = true;
        public bool Running {
            get {
                return this._Running;
            }
            private set {
                this._Running = value;
            }
        }

        public Manager()
        {
            SvcDisplay.Register();
            SvcInput.Register();
            SvcState.Register();
            SvcClock.Register();
            SvcMedia.Register();
            SvcEntities.Register();
            SvcGameUI.Register();

            // link display close event
            SvcInput.GameExit += this.OnExitGame;
            SvcInput.ToggleShowDebug += SvcGameUI.OnToggleShowDebug;
        }

        public void Run()
        {
            this.Update();
            this.Render();
        }

        private void Update()
        {
            SvcClock.Update(null);
            var _ms = SvcClock.DeltaMS;
            SvcEntities.Update(_ms);
            SvcGameUI.Update(_ms);
            SvcDisplay.Update(_ms);
        }

        private void Render()
        {
            SvcEntities.Render();
            SvcGameUI.Render();
            SvcDisplay.Render();
        }

        private void OnExitGame(object? sender, EventArgs e)
        {
            SvcDisplay.CloseWindow();
            this.Running = false;
        }
    }
}