using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

using Rogue.Aspects;
using Rogue.Services;

namespace Rogue.System
{
    /// <summary>
    /// System for handling Display.
    /// </summary>
    public class SysDisplay : BaseSys
    {
        public List<Drawable> DrawBuffer = new List<Drawable>();
        public RenderWindow Window;
        private Debug Debug = new Debug();

        public SysDisplay()
        {
            this.Window = new RenderWindow(new VideoMode(800, 600), "Rogue Agent");
        }

        public override void Update()
        {
            this.Window.Clear();
            foreach(Drawable d in this.DrawBuffer)
            {
                this.Window.Draw(d);
            }
            if(SvcState.Settings?.DISPLAY_DEBUG == true)
            {
                this.Debug.LoadText(SvcState.DebugText);
                this.Window.Draw(this.Debug);
            }
            this.DrawBuffer.Clear();
            this.Window.Display();
            this.Window.DispatchEvents();
        }

        public void Draw(Drawable d)
        {
            this.DrawBuffer.Add(d);
        }
    }
}