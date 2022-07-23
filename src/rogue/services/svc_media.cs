using RogueAgent.System;

namespace RogueAgent.Services
{
    public class SvcMedia : BaseSvc<SysMedia>
    {   
        public static T LoadResource<T>(string name) 
        where T : new()
        {
            if(SvcMedia.Minion is not null)
            {
                return SvcMedia.Minion.LoadResource<T>(name);
            }
            else
            {
                return new T();
            }
        }
    }
}