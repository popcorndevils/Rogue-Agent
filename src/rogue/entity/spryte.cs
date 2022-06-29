using PichaLib;
using System.Drawing;
using Newtonsoft.Json;
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
            
            using (StreamReader r = new StreamReader("./res/templates/Riblet.plab"))
            {
                string json = r.ReadToEnd();
                Canvas canvas = JsonConvert.DeserializeObject<Canvas>(json);
                var _sprite = canvas.GenerateSprite();
                this.Image = new gfx.Image(this.ToSFMLImage(_sprite));
            }

            this.Texture = new gfx.Texture(this.Image);
            this.Sprite = new gfx.Sprite(this.Texture);
            // this.Texture = new gfx.Sprite(new gfx.Texture("./res/test/ball.png"));
            // TODO actually implement sprite generation here somehow
        }
    
        private SFML.Graphics.Image ToSFMLImage(Bitmap bmp) 
        {
            SFML.Graphics.Color[,] sfmlcolorarray = new gfx.Color[bmp.Height, bmp.Width];
            SFML.Graphics.Image newimage = null;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color csharpcolor = bmp.GetPixel(x, y);
                    sfmlcolorarray[y,x] = new SFML.Graphics.Color(csharpcolor.R, csharpcolor.G, csharpcolor.B, csharpcolor.A);
                }
            }

            newimage = new SFML.Graphics.Image(sfmlcolorarray);

            return newimage;
        }

        public void Draw(gfx.RenderTarget t, gfx.RenderStates s)
        {
            this.Sprite?.Draw(t, s);
        }
    }
}