using gfx = SFML.Graphics;

namespace Rogue.Entity
{
    public class Spryte : Component<Spryte>, gfx.Drawable
    {
        public gfx.Sprite? Texture;
        public String Name;

        public Spryte()
        {
            // TODO actually implement sprite component elements
            this.Name = "TEST ME";
            // this.Texture = new gfx.Sprite(new gfx.Texture("./res/test/ball.png"));
        }

        public void Draw(gfx.RenderTarget t, gfx.RenderStates s)
        {
            this.Texture?.Draw(t, s);
        }
    }
}