using System;

using SFML.Graphics;
using SFML.Window;

using Rsvc = Rogue.Services;

namespace Rogue.Systems
{
    /// <summary>
    /// System for handling Display.
    /// </summary>
    public class SysDisplay : BaseSys
    {
        public event EventHandler? DisplayClosed;
        private RenderWindow Window;
        private CircleShape Shape;

        public SysDisplay()
        {
            Rsvc.SvcDisplay.Register(this);

            this.Window = new RenderWindow(new VideoMode(200, 200), "TEST");
            this.Shape = new CircleShape(100f);

            this.Window.Closed += this.OnWindowClose;
            this.Shape.FillColor = Color.Green;
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

        public override void Update(uint delta)
        {
            this.Window.Clear();
            this.Window.DispatchEvents();
            this.Window.Draw(this.Shape);
            this.Window.Display();
        }
    }
}