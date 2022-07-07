using RogueAgent.System;

namespace RogueAgent.Services
{
    public class SvcInput : BaseSvc<SysInput>
    {
        public static event EventHandler? ToggleShowDebug {
            add {
                if (SvcInput.Minion is not null)
                {
                    SvcInput.Minion.ToggleShowDebug += value;
                }
            }
            remove {
                if (SvcInput.Minion is not null)
                {
                    SvcInput.Minion.ToggleShowDebug -= value;
                }
            }
        }
        
        public static event EventHandler? GameExit {
            add {
                if (SvcInput.Minion is not null)
                {
                    SvcInput.Minion.GameExit += value;
                }
            }
            remove {
                if (SvcInput.Minion is not null)
                {
                    SvcInput.Minion.GameExit -= value;
                }
            }
        }
    }
}