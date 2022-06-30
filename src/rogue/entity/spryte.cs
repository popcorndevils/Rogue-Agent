using gfx = SFML.Graphics;
using PichaLib;
using Rogue.Extensions;
using Rogue.Services;

namespace Rogue.Entity
{
    public class Spryte : Component<Spryte>, gfx.Drawable
    {
        private Canvas Canvas;
        private gfx.Sprite? Sprite;
        private gfx.Texture[]? Textures;
        private float? Timer = 0f;
        private float? MsPerFrame;
        private int _Frame = 0;
        private int Frame {
            get => this._Frame;
            set {
                if(this.Textures is not null && this.Sprite is not null)
                {
                    if(value >= this.Textures.Length)
                    {
                        this._Frame = 0;
                    }
                    else if(value < 0)
                    {
                        this._Frame = this.Textures.Length;
                    }
                    else
                    {
                        this._Frame = value;
                    }
                    this.Sprite.Texture = this.Textures[this._Frame];
                }
            }
        }

        public Spryte(string name, int layer, string template) : base(name, layer)
        {
            this.Canvas = SvcMedia.LoadResource<Canvas>(template);
            this.Textures = this.Canvas.GenerateFrames(true, 20).ToSFML();
            if(this.Textures is not null && 
               this.Textures.Length > 0 && 
               this.Textures[0] is not null)
            {
                this.MsPerFrame = (this.Canvas.AnimTime * 1000f) / this.Textures.Length;
                this.Sprite = new gfx.Sprite(this.Textures[0]);
            }
        }

        public void Draw(gfx.RenderTarget t, gfx.RenderStates s)
        {
            this.Sprite?.Draw(t, s);
        }

        public void Update(float? ms)
        {
            if(this.Sprite is not null && ms is not null)
            {
                this.Timer += ms;
                if(this.Timer >= this.MsPerFrame)
                {
                    this.Timer = 0;
                    this.Frame += 1;
                }
            }
        }
    }
}