using System.Collections.Generic;
using SFML.Window;
using Rogue.Services;
using Rogue.Types;

namespace Rogue.System
{
    public partial class SysInput : BaseSys
    {
        public Dictionary<KeyEventArgs, GameAction> ControlMap = new Dictionary<KeyEventArgs, GameAction>();

        public override void Update() { }

        public override void Initialize() 
        {
            if(SvcDisplay.Window is not null)
            {
                SvcDisplay.Window.KeyPressed += this.OnKeyPress;
            }
        }

        public void OnKeyPress(object? sender, KeyEventArgs e)
        {
            Console.WriteLine(e);
        }
    }
}