using Rogue.System;
using Rogue.Entity;

public class RogueAgent
{
    public static void Main()
    {
        var manager = new SysManager();

        while(manager.Running)
        {
            manager.Update();
        }
    }
}
