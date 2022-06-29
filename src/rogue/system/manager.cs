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

            // link display close event
            SvcInput.GameExit += this.OnExitGame;
        }

        public void Run()
        {
            this.Update();
            this.Render();
        }

        private void Update()
        {
            SvcClock.Update();
            SvcEntities.Update();
            SvcDisplay.Update();
        }

        private void Render()
        {
            SvcEntities.Render();
            SvcDisplay.Render();
        }

        private void OnExitGame(object? sender, EventArgs e)
        {
            SvcDisplay.CloseWindow();
            this.Running = false;
        }
    }
}