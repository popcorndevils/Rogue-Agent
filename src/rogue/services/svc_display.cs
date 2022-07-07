using SFML.Graphics;
using SFML.Window;
using Rsys = RogueAgent.System;

namespace RogueAgent.Services
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

        public static event EventHandler<MouseMoveEventArgs>? MouseMoved {
            add {
                if (SvcDisplay.Minion is not null)
                {
                    SvcDisplay.Minion.Window.MouseMoved += value;
                }
            }
            remove {
                if (SvcDisplay.Minion is not null)
                {
                    SvcDisplay.Minion.Window.MouseMoved -= value;
                }
            }
        }

        public static event EventHandler<MouseButtonEventArgs>? MouseButtonPressed {
            add {
                if (SvcDisplay.Minion is not null)
                {
                    SvcDisplay.Minion.Window.MouseButtonPressed += value;
                }
            }
            remove {
                if (SvcDisplay.Minion is not null)
                {
                    SvcDisplay.Minion.Window.MouseButtonPressed -= value;
                }
            }
        }

        public static event EventHandler<MouseButtonEventArgs>? MouseButtonReleased {
            add {
                if (SvcDisplay.Minion is not null)
                {
                    SvcDisplay.Minion.Window.MouseButtonReleased += value;
                }
            }
            remove {
                if (SvcDisplay.Minion is not null)
                {
                    SvcDisplay.Minion.Window.MouseButtonReleased -= value;
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