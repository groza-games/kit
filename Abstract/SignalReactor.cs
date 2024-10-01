using System;
using GrozaGames.Kit.Signals;
using Zenject;

namespace GrozaGames.Abstract
{
    public abstract class SignalReactor<T> : IInitializable, IDisposable where T : struct
    {
        [Inject] private readonly SignalBus _entitySignalBus;
        
        public void Initialize()
        {
            _entitySignalBus.Subscribe<T>(OnSignal);
        }

        public void Dispose()
        {
            _entitySignalBus.Unsubscribe<T>(OnSignal);
        }

        protected abstract void OnSignal(T signal);
    }
}