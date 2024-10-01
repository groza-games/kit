using UnityEngine;
using Zenject;

namespace GrozaGames.Abstract.BaseViews
{
    public abstract class ScreenController<TScreenView> where TScreenView : ScreenView
    {
        [Inject] protected DiContainer DiContainer;
        [Inject] protected TScreenView ViewPrefab;
        
        public TScreenView View { get; private set; }
        
        public bool IsVisible => View != null;

        public TScreenView Show()
        {
            if (View != null)
                throw new System.Exception("View is already instantiated");
            
            View = DiContainer.InstantiatePrefabForComponent<TScreenView>(ViewPrefab);
            return View;
        }
        
        public void Hide()
        {
            if (View == null)
                throw new System.Exception("View is not instantiated");
            
            Object.Destroy(View.gameObject);
            View = null;
        }
    }
    
    public abstract class ScreenController<TScreenView, TScreenModel> where TScreenView : ScreenView<TScreenModel> where TScreenModel : struct, IScreenModel
    {
        [Inject] protected DiContainer DiContainer;
        [Inject] protected TScreenView ViewPrefab;
        
        public TScreenView View { get; private set; }
        
        public bool IsVisible => View != null;

        public TScreenView Show(TScreenModel model)
        {
            if (View != null)
                throw new System.Exception("View is already instantiated");
            
            View = DiContainer.InstantiatePrefabForComponent<TScreenView>(ViewPrefab);
            View.SetModel(model);
            return View;
        }
        
        public void Hide()
        {
            if (View == null)
                throw new System.Exception("View is not instantiated");
            
            Object.Destroy(View.gameObject);
            View = null;
        }
    }
}