using Zenject;

namespace GrozaGames.Abstract
{
    public abstract class EnableableUpdateScenario : ITickable
    {
        public bool IsEnabled { get; private set; }
        
        public void Tick()
        {
            if (!IsEnabled)
                return;

            Update();
        }

        protected abstract void Update();
        
        public virtual void Enable()
        {
            IsEnabled = true;
        }
        
        public virtual void Disable()
        {
            IsEnabled = false;
        }
    }
}