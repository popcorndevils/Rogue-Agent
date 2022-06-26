using Rogue.Services;
using Rogue.Systems;
using Rogue.Aspects;

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
