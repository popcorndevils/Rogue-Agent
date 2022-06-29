using Rogue.System;
using Rogue.Entity;

public class RogueAgent
{
    public static void Main()
    {
        var manager = new Manager();
        var sprite = new Spryte("HELLO", 0, "riblet");

        while(manager.Running)
        {
            manager.Run();
        }
    }
}
