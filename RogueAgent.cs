using Rogue.Services;
using Rogue.Systems;
using Rogue.Aspects;

public class RogueAgent
{
    public static void Main()
    {
        var manager = new SysManager();
        
        var Test = new Label("HELP ME");

        while(manager.Running)
        {
            SvcDisplay.Draw(Test);
            manager.Update();
        }
    }
}
