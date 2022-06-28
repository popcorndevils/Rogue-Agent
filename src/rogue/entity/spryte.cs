using gfx = SFML.Graphics;

namespace Rogue.Entity
{
    public class Spryte : Component<Spryte>, gfx.Drawable
    {
        public gfx.Texture? Texture;
        public gfx.Image? Image;
        public gfx.Sprite? Sprite;
        public String Name;

        public Spryte()
        {
            // TODO actually implement sprite component elements
            this.Name = "TEST ME";
            this.Image = new gfx.Image(32, 32, gfx.Color.Green);

            this.Image.SetPixel(10, 10, gfx.Color.Red);
            this.Texture = new gfx.Texture(this.Image);
            this.Sprite = new gfx.Sprite(this.Texture);
            // this.Texture = new gfx.Sprite(new gfx.Texture("./res/test/ball.png"));
            // TODO actually implement sprite generation here somehow
        }

        public void Draw(gfx.RenderTarget t, gfx.RenderStates s)
        {
            this.Sprite?.Draw(t, s);
        }
    }
}