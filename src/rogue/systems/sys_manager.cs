
namespace Rogue.Systems
{
    public class SysManager
    {
        private SysDisplay Display;

        public bool RUNNING {
            get {
                return this.Display.RUNNING;
            }
        }

        public SysManager()
        {
            this.Display = new SysDisplay();
        }

        public void Update()
        {
            this.Display.Update(100);
        }
    }
}