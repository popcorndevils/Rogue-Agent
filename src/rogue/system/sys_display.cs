using SFML.Graphics;
using SFML.Window;
using Rogue.Aspects;
using Rogue.Services;
using Rogue.Entity;

namespace Rogue.System
{
    /// <summary>
    /// System for handling Display.
    /// </summary>
    public class SysDisplay : BaseSys
    {
        public List<Drawable> DrawableBuffer = new List<Drawable>();
        public RenderWindow Window;
        private Debug Debug = new Debug();

        public SysDisplay()
        {
            this.Window = new RenderWindow(new VideoMode(1920, 1080), "Rogue Agent");
        }

        public override void Update()
        {
            this.Window.DispatchEvents();
        }

        public override void Render()
        {
            this.Window.Clear(new Color(100, 100, 100));
            this.DrawBuffer();
            this.DrawDebug();
            this.Window.Display();
        }

        public void Draw(Drawable d)
        {
            this.DrawableBuffer.Add(d);
        }

        public void CloseWindow()
        {
            this.Window.Close();
        }

        private void DrawDebug()
        {
            if(SvcState.Settings?.DISPLAY_DEBUG == true)
            {
                this.Debug.LoadText(SvcState.DebugText);
                this.Window.Draw(this.Debug);
            }
        }

        private void DrawBuffer()
        {
            foreach(Drawable d in this.DrawableBuffer)
            {
                this.Window.Draw(d);
            }
            this.DrawableBuffer.Clear();
        }
    }
}