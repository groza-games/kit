using GrozaGames.DebugFramerate.UI;
using UnityEngine;
using Zenject;
using Input = UnityEngine.Input;

namespace GrozaGames.DebugFramerate.Scenarios
{
    public class DebugFramerateScenario : ITickable
    {
        [Inject] private readonly DebugFramerateScreen.Controller _debugFramerateScreenController;
        
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.F7))
                if (_debugFramerateScreenController.IsVisible)
                    _debugFramerateScreenController.Hide();
                else
                    _debugFramerateScreenController.Show();
        }
    }
}