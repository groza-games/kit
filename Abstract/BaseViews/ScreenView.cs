using System;
using UnityEngine;
using Zenject;

namespace GrozaGames.Abstract.BaseViews
{
    public abstract class ScreenView : MonoBehaviour
    {
        public event Action DestroyCalled;
        private bool _destroyed;
        
        [Inject]
        protected virtual void Initialize()
        {
        }
        
        public virtual void OnInitialize()
        {
        }

        public void Destroy()
        {
            if (_destroyed)
                return;
            
            _destroyed = true;
            DestroyCalled?.Invoke();
        }
    }
    
    public abstract class ScreenView<TScreenModel> : ScreenView where TScreenModel : struct, IScreenModel
    {
        protected TScreenModel Model { get; private set; }

        protected virtual void OnModelSet(TScreenModel model)
        {
        }
        
        public void SetModel(TScreenModel model)
        {
            Model = model;
            OnModelSet(model);
        }
    }
}