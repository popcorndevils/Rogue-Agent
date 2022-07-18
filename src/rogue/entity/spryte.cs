using gfx = SFML.Graphics;
using SFML.System;
using PichaLib;
using RogueAgent.Extensions;
using RogueAgent.Services;

namespace RogueAgent.Entity
{
    public class Spryte : Component<Spryte>, gfx.Drawable
    {
        
        public Vector2f? Scale {
            get {
                if(this.Sprite is not null)
                {
                    return this.Sprite.Scale;
                }
                return null;
            }
            set {
                if(this.Sprite is not null && value is not null)
                {
                    this.Sprite.Scale = (Vector2f)value;
                }
            }
        }

        public Spryte(string name, int layer, string template) : base(name, layer)
        {
            this.Canvas = SvcMedia.LoadResource<Canvas>(template);
            this.Textures = this.Canvas.GenerateFrames(true).ToSFML();
            if(this.Textures is not null && 
               this.Textures.Length > 0 && 
               this.Textures[0] is not null)
            {
                this.MsPerFrame = (this.Canvas.AnimTime * 1000f) / this.Textures.Length;
                this.Sprite = new gfx.Sprite(this.Textures[0]){Position = new Vector2f(200, 200)};
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

        // ██╗  ██╗██╗██████╗ ██████╗ ███████╗███╗   ██╗
        // ██║  ██║██║██╔══██╗██╔══██╗██╔════╝████╗  ██║
        // ███████║██║██║  ██║██║  ██║█████╗  ██╔██╗ ██║
        // ██╔══██║██║██║  ██║██║  ██║██╔══╝  ██║╚██╗██║
        // ██║  ██║██║██████╔╝██████╔╝███████╗██║ ╚████║
        // ╚═╝  ╚═╝╚═╝╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝
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
    }
}