using Rsys = Rogue.Systems;

public class RogueAgent
{
    public static void Main()
    {
        Rsys.SysManager manager = new Rsys.SysManager();

        while(manager.Running)
        {
            manager.Update();
        }
    }
}
