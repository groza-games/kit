using System;
using UnityEngine;
using Zenject;

namespace GrozaGames.Kit.Localization
{
    [RequireComponent(typeof(LocalizationManager))]
    public class LocalizationInstaller : MonoInstaller
    {
        [SerializeField] private LocalizationManager _localizationManager;

        private void Reset()
        {
            _localizationManager = GetComponent<LocalizationManager>();
        }

        public override void InstallBindings()
        {
            Container.BindObjectOnScene(_localizationManager);
        }
    }
}