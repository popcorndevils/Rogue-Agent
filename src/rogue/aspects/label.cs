using gfx = SFML.Graphics;

namespace Rogue.Aspects
{
    public class Label
    {
        public gfx.Font Font;
        public gfx.Text GText;

        public Label(String text)
        {
            this.Font = new gfx.Font("./res/fonts/consola.ttf");
            this.GText = new gfx.Text(text, this.Font, 24);
        }
    }
}