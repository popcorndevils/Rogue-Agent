using SFML.Graphics;
using SFML.System;

namespace Rogue.Aspects
{
    public interface Aspect : Drawable
    {
        public virtual FloatRect Bounds {
            get { return new FloatRect(); }
        }

        public virtual Vector2f Position {
            get { return new Vector2f(); }
            set { }
        }

        public Vector2f Size {
            get { return new Vector2f(); }
        }

        public new void Draw(RenderTarget t, RenderStates s) {}
    }
}