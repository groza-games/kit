using GrozaGames.Abstract.BaseViews;
using TMPro;
using UnityEngine;

namespace GrozaGames.DebugFramerate.UI
{
    public class DebugFramerateScreen : ScreenView
    {
        [SerializeField] private TMP_Text _framerateText;
        [SerializeField] private float _updateRate = 0.5f;
        
        private float _timer;
        
        private void Awake()
        {
            _framerateText.text = string.Empty;
        }
        
        private void Update()
        {
            _timer += Time.unscaledDeltaTime;
            if (_timer >= _updateRate)
            {
                _timer = 0f;
                var fps = 1f / Time.unscaledDeltaTime;
                var color = Color.green;
                if (fps < 45)
                    color = Color.yellow;
                if (fps < 25)
                    color = Color.red;
                _framerateText.text = $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{fps:0}</color>";
            }
        }
        
        public class Controller : ScreenController<DebugFramerateScreen>
        {
        }
    }
}