using SFML.Graphics;
using SFML.System;

namespace Rogue.Aspects.Primitives
{
    public class Line : Aspect
    {
        private RectangleShape LineShape;
        public override Drawable Shape => this.LineShape;

        public Line(int x, int y, int w, int h)
        {
            this.LineShape = new RectangleShape(new Vector2f(w, h));
        }
    }
}