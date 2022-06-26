using System;
using Rsys = Rogue.System;

using SFML.Graphics;

namespace Rogue.Services
{
    public class SvcDisplay : BaseSvc<Rsys.SysDisplay>
    {   
        public static RenderWindow? Window => SvcDisplay.Client?.Window;
        public static void Draw(Drawable d)
        {
            SvcDisplay.Client?.Draw(d);
        }
    }
}