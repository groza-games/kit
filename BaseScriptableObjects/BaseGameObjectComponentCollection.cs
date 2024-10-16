using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GrozaGames.Kit
{
    public abstract class BaseGameObjectComponentCollection<T> : BaseScriptableObjectCollection<T> where T : Component
    {
        /// <summary>
        /// Пути, по которым будут производиться поиски элементов в виде префабов.
        /// </summary>
        [SerializeField] 
        private string[] _searchPaths = {
            "Assets/Prefabs"
        };

        /// <summary>
        /// Наполняет коллекцию новыми элементами, найденными в указанных путях поиска.
        /// </summary>
        public override void FillWithNewElements()
        {
            var newElements = new List<GameObject>();

            foreach (var searchPath in _searchPaths) 
                newElements.AddRange(AssetDatabaseUtils.FindObjects<GameObject>(searchPath));

            if (newElements.Count == 0)
                return;

            foreach (var newElement in newElements)
                if (newElement.TryGetComponent(out T element))
                    if (!Elements.Contains(element))
                        Elements.Add(element);

            Reinitialize();
        }
    }
}