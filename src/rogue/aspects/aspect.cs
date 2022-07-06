using SFML.Graphics;
using SFML.System;

namespace Rogue.Aspects
{
    public abstract class Aspect : Drawable
    {
        public virtual event EventHandler OnTransform {
            add {}
            remove {}
        }

        public virtual Drawable Shape {
            get { return new RectangleShape(); }
            set { }
        }

        public virtual FloatRect Bounds {
            get { return new FloatRect(); }
        }

        public virtual Vector2f Position {
            get { return new Vector2f(); }
            set { }
        }

        public virtual Vector2f Size {
            get { return new Vector2f(); }
        }

        public virtual void Update(float? ms) { }

        public virtual void Draw(RenderTarget t, RenderStates s)
        {
            this.Shape.Draw(t, s);
        }
    }
}