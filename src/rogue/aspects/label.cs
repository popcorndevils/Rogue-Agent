using gfx = SFML.Graphics;

namespace Rogue.Aspects
{
    public class Label : gfx.Drawable
    {
        public gfx.Font Font;
        public gfx.Text GText;

        public Label(String text)
        {
            this.Font = new gfx.Font("./res/fonts/consola.ttf");
            this.GText = new gfx.Text(text, this.Font, 24);
        }

        public void Draw(gfx.RenderTarget t, gfx.RenderStates s)
        {
            this.GText.Draw(t, s);
        }
    }
}