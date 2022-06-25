
namespace Rogue.Systems
{
    public class SysManager
    {
        private SysDisplay Display;

        private bool _Running = false;
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
            this.Display = new SysDisplay();
            this.Running = true;
            this.Display.DisplayClosed += this.OnDisplayClose;
        }

        public void Update()
        {
            this.Display.Update(100);
        }

        private void OnDisplayClose(object? sender, EventArgs e)
        {
            this.Running = false;
        }
    }
}