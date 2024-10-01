using UnityEngine;
using Zenject;

namespace GrozaGames.Kit.Localization
{
    public class LocalizationInstaller : MonoInstaller
    {
        [SerializeField] private LocalizationManager _localizationManager;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<LocalizationManager>()
                .FromComponentInNewPrefab(_localizationManager)
                .WithGameObjectName("LocalizationManager")
                .UnderTransformGroup("Infrastructure")
                .AsSingle()
                .NonLazy();
        }
    }
}