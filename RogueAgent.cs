using Rogue.System;
using Rogue.Entity;

public class RogueAgent
{
    public static void Main()
    {
        var manager = new SysManager();
        var sprite = new Spryte();

        while(manager.Running)
        {
            manager.Update();
        }
    }
}
