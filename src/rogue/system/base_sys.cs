namespace Rogue.System
{
    public abstract class BaseSys
    {
        public virtual void Update(float? ms) {}
        public virtual void Render() {}
        public virtual void Initialize() {}
    }
}