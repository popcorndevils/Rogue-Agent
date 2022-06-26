using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

using Rogue.Aspects;

namespace Rogue.Systems
{
    /// <summary>
    /// System for handling Display.
    /// </summary>
    public class SysDisplay : BaseSys
    {
        public event EventHandler? DisplayClosed;
        public List<Drawable> DrawBuffer = new List<Drawable>();
        private RenderWindow Window;

        public SysDisplay()
        {
            this.Window = new RenderWindow(new VideoMode(800, 600), "Rogue Agent");

            this.Window.Closed += this.OnWindowClose;
        }

        public void OnWindowClose(object? sender, EventArgs e)
        {
            var win = sender as RenderWindow;
            if(win != null)
            {
                this.DisplayClosed?.Invoke(this, EventArgs.Empty);
                win.Close();
            }
        }

        public void Draw(Drawable d)
        {
            this.DrawBuffer.Add(d);
        }

        public override void Update()
        {
            this.Window.Clear();
            this.Window.DispatchEvents();
            foreach(Drawable d in this.DrawBuffer)
            {
                this.Window.Draw(d);
            }
            this.DrawBuffer.Clear();
            this.Window.Display();
        }
    }
}