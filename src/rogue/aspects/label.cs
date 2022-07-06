using SFML.System;
using SFML.Graphics;

namespace Rogue.Aspects
{
    public class Label : Aspect
    {
        public FloatRect Bounds {
            get => this.GText.GetGlobalBounds();
        } 

        public Vector2f Size {
            get {
                var _bnds = this.GText.GetGlobalBounds();
                return new Vector2f(_bnds.Width, _bnds.Height);
            }
        }

        public Vector2f Position {
            get => this.GText.Position;
            set => this.GText.Position = value;
        }

        public Font Font;
        private Text GText;
        public string DisplayedString {
            get => this.GText.DisplayedString;
            set => this.GText.DisplayedString = value;
        }

        public Label(string text)
        {
            this.Font = new Font("./res/fonts/consola.ttf");
            this.GText = new Text(text, this.Font, 24);
        }

        public void Draw(RenderTarget t, RenderStates s)
        {
            this.GText.Draw(t, s);
        }
    }
}