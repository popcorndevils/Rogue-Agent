using System.Collections.Generic;

using SFML.Graphics;
using SFML.System;

using Rogue.Types;
using Rogue.Services;

namespace Rogue.Aspects
{
    public class Debug : Drawable
    {
        public Font Font = new Font("./res/fonts/consola.ttf");
        public List<Text> DisplayText = new List<Text>();

        public void Draw(RenderTarget t, RenderStates s)
        {
            var _debug = SvcState.DebugText;
            if(_debug is not null)
            {
                for(int i = 0; i < _debug.Count; i++)
                {
                    if(i >= this.DisplayText.Count)
                    {
                        this.DisplayText.Add(new Text(_debug[i], this.Font, 24));
                        this.DisplayText[i].Position = new Vector2f(20, 20 + (20 * i));
                    }
                    else
                    {
                        this.DisplayText[i].DisplayedString = _debug[i];
                    }
                }
                foreach(Text txt in this.DisplayText)
                {
                    txt.Draw(t, s);
                }
            }
        }
    }
}