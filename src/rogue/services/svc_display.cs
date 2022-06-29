using SFML.Graphics;
using SFML.Window;
using Rsys = Rogue.System;

namespace Rogue.Services
{
    public class SvcDisplay : BaseSvc<Rsys.SysDisplay>
    {
        public static event EventHandler<KeyEventArgs>? KeyPressed {
            add {
                if (SvcDisplay.Minion is not null)
                {
                    SvcDisplay.Minion.Window.KeyPressed += value;
                }
            }
            remove {
                if (SvcDisplay.Minion is not null)
                {
                    SvcDisplay.Minion.Window.KeyPressed -= value;
                }
            }
        }

        public static event EventHandler? Closed {
            add {
                if (SvcDisplay.Minion is not null)
                {
                    SvcDisplay.Minion.Window.Closed += value;
                }
            }
            remove {
                if (SvcDisplay.Minion is not null)
                {
                    SvcDisplay.Minion.Window.Closed -= value;
                }
            }
        }

        public static void Draw(Drawable d)
        {
            SvcDisplay.Minion?.Draw(d);
        }

        public static void CloseWindow()
        {
            SvcDisplay.Minion?.CloseWindow();
        }
    }
}