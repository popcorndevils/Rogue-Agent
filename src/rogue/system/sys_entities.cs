using Rogue.Entity;
using Rogue.Services;

namespace Rogue.System
{
    public class SysEntities : BaseSys
    {
        public override void Update(float? ms)
        {
            var _ms = SvcClock.DeltaMS;
            if(Spryte.Instances is not null)
            {
                foreach(List<Spryte> sprites in Spryte.Instances.Values)
                {
                    foreach(Spryte sprite in sprites)
                    {
                        sprite.Update(SvcClock.DeltaMS);
                    }
                }
            }
        }

        public override void Render()
        {
            if(Spryte.Instances is not null)
            {
                foreach(List<Spryte> sprites in Spryte.Instances.Values)
                {
                    foreach(Spryte sprite in sprites)
                    {
                        SvcDisplay.Draw(sprite);
                    }
                }
            }
        }
    }
}