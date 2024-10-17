using GrozaGames.DebugFramerate.UI;
using UnityEngine;
using GrozaGames.DebugFramerate.Scenarios;
using Zenject;

namespace GrozaGames.DebugFramerate
{
    public class DebugFramerateInstaller : MonoInstaller
    {
        [SerializeField] private DebugFramerateScreen _debugFramerateScreen;
        
        public override void InstallBindings()
        {
            Container.BindScenario<DebugFramerateScenario>();
            Container.BindScreenView(_debugFramerateScreen).WithScreenController<DebugFramerateScreen.Controller>();
        }
    }
}