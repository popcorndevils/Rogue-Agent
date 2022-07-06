using SFML.Window;
using Rogue.Services;
using Rogue.Types;

namespace Rogue.System
{
    public class SysInput : BaseSys
    {
        public event EventHandler? ToggleShowDebug;
        public event EventHandler? GameExit;

        // Default Control Map
        public Dictionary<KeyState, GameAction> ControlMap = new Dictionary<KeyState, GameAction>(){
            {new KeyState(Keyboard.Key.End), GameAction.TOGGLE_SHOW_DEBUG},
            {new KeyState(Keyboard.Key.Escape), GameAction.GAME_EXIT},
        };

        public override void Initialize() 
        {
            SvcDisplay.KeyPressed += this.OnKeyPress;
            SvcDisplay.Closed += this.OnWindowClose;
        }

        public void OnWindowClose(object? sender, EventArgs e)
        {
            this.GameExit?.Invoke(this, EventArgs.Empty);
        }

        public void OnKeyPress(object? sender, KeyEventArgs e)
        {
            var _state = (KeyState)e;
            if(this.ControlMap.ContainsKey(_state))
            {
                switch(this.ControlMap[_state])
                {
                    case GameAction.TOGGLE_SHOW_DEBUG:
                        this.ToggleShowDebug?.Invoke(this, EventArgs.Empty);
                        break;
                    case GameAction.GAME_EXIT:
                        this.GameExit?.Invoke(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }
}