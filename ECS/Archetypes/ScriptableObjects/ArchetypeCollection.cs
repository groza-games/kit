using System.Collections.Generic;
using GrozaGames.Kit.Archetypes.MonoBehaviours;
using UnityEngine;

namespace GrozaGames.Kit.Archetypes.ScriptableObjects
{
    /// <summary>
    /// Коллекция архетипов, которая используется для управления списком архетипов в проекте.
    /// Предоставляет механизм поиска и добавления новых архетипов на основе префабов в указанных директориях.
    /// </summary>
    [CreateAssetMenu(fileName = "ArchetypeCollection", menuName = "Groza Games/Archetypes/ArchetypeCollection")]
    public class ArchetypeCollection : BaseScriptableObjectCollection<Archetype>
    {
        /// <summary>
        /// Пути, по которым будут производиться поиски архетипов в виде префабов.
        /// </summary>
        [SerializeField] 
        private string[] _searchPaths = {
            "Assets/Prefabs"
        };

        /// <summary>
        /// Наполняет коллекцию новыми архетипами, найденными в указанных путях поиска.
        /// </summary>
        public override void FillWithNewElements()
        {
            // Создаем список для хранения новых элементов
            var newElements = new List<GameObject>();

            // Ищем объекты в каждом из указанных путей
            foreach (var searchPath in _searchPaths) 
                newElements.AddRange(AssetDatabaseUtils.FindObjects<GameObject>(searchPath));

            // Если новые элементы не найдены, выходим
            if (newElements.Count == 0)
                return;

            // Проходим по всем новым объектам и добавляем архетипы в коллекцию
            foreach (var newElement in newElements)
                if (newElement.TryGetComponent(out Archetype archetype))
                    if (!Elements.Contains(archetype))
                        Elements.Add(archetype);

            // Реинициализируем коллекцию после добавления новых элементов
            Reinitialize();
        }
    }
}