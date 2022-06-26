using SFML.System;
using SFML.Graphics;

namespace Rogue.Aspects
{
    public class Label : Drawable
    {
        public Font Font;
        public Text GText;

        public Label(String text)
        {
            this.Font = new Font("./res/fonts/consola.ttf");
            this.GText = new Text(text, this.Font, 24);
            this.GText.Position = new Vector2f(100, 100);
        }

        public void Draw(RenderTarget t, RenderStates s)
        {
            this.GText.Draw(t, s);
        }
    }
}