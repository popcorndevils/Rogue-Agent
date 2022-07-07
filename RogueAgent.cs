using RogueAgent.System;
using RogueAgent.Entity;

namespace RogueAgent
{
    public class RogueGame
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
}