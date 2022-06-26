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

        public void LoadText(List<String>? txt)
        {
            if(txt is not null)
            {
                for(int i = 0; i < txt.Count; i++)
                {
                    if(i >= this.DisplayText.Count)
                    {
                        this.DisplayText.Add(new Text(txt[i], this.Font, 24));
                        this.DisplayText[i].Position = new Vector2f(20, 20 + (20 * i));
                    }
                    else
                    {
                        this.DisplayText[i].DisplayedString = txt[i];
                    }
                }
            }
        }

        public void Draw(RenderTarget t, RenderStates s)
        {
            foreach(Text txt in this.DisplayText)
            {
                txt.Draw(t, s);
            }
        }
    }
}