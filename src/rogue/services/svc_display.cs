using System;
using Rsys = Rogue.Systems;

using SFML.Graphics;

namespace Rogue.Services
{
    public class SvcDisplay : BaseSvc<Rsys.SysDisplay>
    {   
        public static void Draw(Drawable d)
        {
            SvcDisplay.Client?.Draw(d);
        }
    }
}