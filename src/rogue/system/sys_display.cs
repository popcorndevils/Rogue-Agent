using SFML.Graphics;
using SFML.Window;

using Rogue.Aspects;
using Rogue.Services;
using entity = Rogue.Entity;

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
            this.Window = new RenderWindow(new VideoMode(800, 600), "Rogue Agent");
        }

        public override void Update()
        {
            this.Window.Clear();
            this.DrawBuffer();
            this.DrawSprites();
            this.DrawDebug();
            this.Window.Display();
            this.Window.DispatchEvents();
        }

        public void Draw(Drawable d)
        {
            this.DrawableBuffer.Add(d);
        }

        public void DrawSprites()
        {
            if(entity.Spryte.Instances is not null)
            {
                foreach(List<entity.Spryte> sprites in entity.Spryte.Instances.Values)
                {
                    foreach(entity.Spryte sprite in sprites)
                    {
                        this.Window.Draw(sprite);
                    }
                }
            }
        }

        public void DrawDebug()
        {
            if(SvcState.Settings?.DISPLAY_DEBUG == true)
            {
                this.Debug.LoadText(SvcState.DebugText);
                this.Window.Draw(this.Debug);
            }
        }

        public void DrawBuffer()
        {
            foreach(Drawable d in this.DrawableBuffer)
            {
                this.Window.Draw(d);
            }
            this.DrawableBuffer.Clear();
        }
    }
}