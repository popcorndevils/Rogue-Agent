using RogueAgent.UI;
using RogueAgent.System;
using RogueAgent.Services;
using RogueAgent.Entity;

namespace RogueAgent
{
    public class RogueGame
    {
        public static void Main()
        {
            var manager = new Manager();
            var sprite = new Spryte("HELLO", 0, "riblet");
            SvcGameUI.Add(new UITest());

            while(manager.Running)
            {
                manager.Run();
            }
        }
    }
}