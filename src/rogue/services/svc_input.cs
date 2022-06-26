using Rogue.System;

namespace Rogue.Services
{
    public class SvcInput : BaseSvc<SysInput>
    {
        public static event EventHandler? ToggleShowDebug {
            add {
                if (SvcInput.Client is not null)
                {
                    SvcInput.Client.ToggleShowDebug += value;
                }
            }
            remove {
                if (SvcInput.Client is not null)
                {
                    SvcInput.Client.ToggleShowDebug -= value;
                }
            }
        }
        
        public static event EventHandler? GameExit {
            add {
                if (SvcInput.Client is not null)
                {
                    SvcInput.Client.GameExit += value;
                }
            }
            remove {
                if (SvcInput.Client is not null)
                {
                    SvcInput.Client.GameExit -= value;
                }
            }
        }
    }
}