using System;
using Rsys = Rogue.System;

using SFML.Graphics;
using SFML.Window;

namespace Rogue.Services
{
    public class SvcDisplay : BaseSvc<Rsys.SysDisplay>
    {
        public static event EventHandler<KeyEventArgs>? KeyPressed {
            add {
                if (SvcDisplay.Client is not null)
                {
                    SvcDisplay.Client.Window.KeyPressed += value;
                }
            }
            remove {
                if (SvcDisplay.Client is not null)
                {
                    SvcDisplay.Client.Window.KeyPressed -= value;
                }
            }
        }

        public static event EventHandler? Closed {
            add {
                if (SvcDisplay.Client is not null)
                {
                    SvcDisplay.Client.Window.Closed += value;
                }
            }
            remove {
                if (SvcDisplay.Client is not null)
                {
                    SvcDisplay.Client.Window.Closed -= value;
                }
            }
        }

        public static void Draw(Drawable d)
        {
            SvcDisplay.Client?.Draw(d);
        }
    }
}