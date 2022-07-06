using SFML.Graphics;
using SFML.Window;
using SFML.System;
using Rogue.Aspects;
using Rogue.Services;

namespace Rogue.System
{
    /// <summary>
    /// System for handling Display.
    /// </summary>
    public class SysDisplay : BaseSys, Aspect
    {
        public List<Drawable> DrawableBuffer = new List<Drawable>();
        public RenderWindow Window;

        public Vector2f Size => (Vector2f)this.Window.Size;
        public Vector2f Position { get; set; }

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

        public void Draw(RenderTarget t, RenderStates s) { }

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