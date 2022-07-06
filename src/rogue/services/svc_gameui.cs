using Rogue.Aspects;
using Rogue.System;

namespace Rogue.Services
{
    public class SvcGameUI : BaseSvc<SysGameUI>
    {
        public static void Add(params Aspect[] aspects)
        {
            if(SvcGameUI.Minion is not null)
            {
                SvcGameUI.Minion.Add(aspects);
            }
        }

        public static void OnToggleShowDebug(object? sender, EventArgs e)
        {
            if(SvcGameUI.Minion is not null)
            {
                SvcGameUI.Minion.ToggleDebug();
            }
        }
    }

}