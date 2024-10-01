using GrozaGames.Kit.ECS;
using GrozaGames.Kit.Signals;
using UnityEngine;
using Zenject;

namespace GrozaGames.ECS
{
    public class EcsInstaller : MonoInstaller
    {
        [SerializeField] private SceneContext _sceneContext;
        
        public override void InstallBindings()
        {
            Container.BindService<EcsWorld>();
            Container.BindService<EcsRunnerForZenject>();
            
            Container.BindService<SignalBus>();
            Container.BindService<KeySignalBus<int>>();

            _sceneContext.PostResolve += OnSceneContextPostResolve;
        }

        private void OnSceneContextPostResolve()
        {
            _sceneContext.PostResolve -= OnSceneContextPostResolve;
            var world = Container.Resolve<EcsWorld>();
            foreach (var contract in Container.AllContracts)
            {
                if (contract.Type.ContainsGenericParameters)
                    continue;
                
                var objects = Container.ResolveAll(contract.Type);
                foreach (var obj in objects) 
                    EcsInjectionUtils.InjectEcs(obj, world);
            }
        }
    }
}