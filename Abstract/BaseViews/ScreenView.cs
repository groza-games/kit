using UnityEngine;

namespace GrozaGames.Abstract.BaseViews
{
    public abstract class ScreenView : MonoBehaviour
    {
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