using SFML.Graphics;
using SFML.System;

namespace Rogue.Aspects
{
    public class VBox : Aspect
    {
        private float Margin = 0f;

        public List<Aspect> Children = new List<Aspect>();

        public Vector2f Size {
            get {
                var _bnds = this.Children[0].Bounds;
                return new Vector2f(_bnds.Width, _bnds.Height);
            }
        }

        private Vector2f _Position = new Vector2f();
        public Vector2f Position {
            get => this._Position;
            set {
                this._Position = value;
                this.UpdateLayout();
            }
        }

        public void Add(params Aspect[] aspects)
        {
            foreach(Aspect a in aspects)
            {
                this.Children.Add(a);
            }
            this.UpdateLayout();
        }

        public void Draw(RenderTarget t, RenderStates s)
        {
            foreach(Aspect a in this.Children)
            {
                a.Draw(t, s);
            }
        }

        protected void UpdateLayout()
        {
            float _bottom = this.Position.Y;
            foreach(Aspect a in this.Children)
            {
                a.Position = new Vector2f(this.Position.X + this.Margin, _bottom + this.Margin);
                var _bnds = a.Bounds;
                _bottom = _bnds.Top + _bnds.Height;
            }
        }
    }
}