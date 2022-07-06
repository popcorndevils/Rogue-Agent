using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Rogue.System
{
    /// <summary>
    /// System for handling Display.
    /// </summary>
    public class SysDisplay : BaseSys
    {
        public List<Drawable> DrawableBuffer = new List<Drawable>();
        public RenderWindow Window;

        public Vector2f Size => (Vector2f)this.Window.Size;
        public Vector2f Position { get; set; }

        public SysDisplay()
        {
            this.Window = new RenderWindow(new VideoMode(1920, 1080), "Rogue Agent");
        }

        public override void Update(float? ms)
        {
            this.Window.DispatchEvents();
        }

        public override void Render()
        {
            this.Window.Clear(new Color(100, 100, 100));
            this.DrawBuffer();
            this.Window.Display();
        }
        
        public void CloseWindow()
        {
            this.Window.Close();
        }

        public void Draw(RenderTarget t, RenderStates s) { }
        
        public void Draw(Drawable d)
        {
            this.DrawableBuffer.Add(d);
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