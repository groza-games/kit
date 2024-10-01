using GrozaGames.Kit.Archetypes.Components;
using GrozaGames.Kit.Archetypes.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GrozaGames.Kit.Archetypes.MonoBehaviours
{
    /// <summary>
    /// Класс, представляющий архетип сущности в ECS. Архетипы используются как шаблоны для создания сущностей с предустановленными компонентами.
    /// Включает GUID для идентификации архетипа и метод для выпекания компонентов на сущности.
    /// </summary>
    [AddComponentMenu("ECS/Archetype")]
    public class Archetype : MonoBehaviour
    {
        /// <summary>
        /// Уникальный идентификатор (GUID) архетипа.
        /// </summary>
        [field: SerializeField]
        public string Guid { get; private set; }

        /// <summary>
        /// Метод, вызываемый при сбросе архетипа. Генерирует новый GUID для архетипа.
        /// </summary>
        private void Reset()
        {
            GenerateNewGuid();
        }

        /// <summary>
        /// Генерирует новый уникальный GUID для архетипа.
        /// </summary>
        [Button("Generate New GUID")]
        private void GenerateNewGuid()
        {
            Guid = System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Выпекает архетип, добавляя его компоненты на сущность и регистрируя их в системе ECS.
        /// </summary>
        /// <param name="entity">Идентификатор сущности, для которой выпекается архетип.</param>
        /// <param name="archetypeService">Сервис архетипов, используемый для взаимодействия с ECS.</param>
        public void Bake(int entity, ArchetypeService archetypeService)
        {
            // Добавляем компонент GUID архетипа сущности
            archetypeService.GetWorld().GetPool<ArchetypeGuidComponent>().Add(entity).Guid = Guid;
            // Добавляем компонент префаба архетипа сущности
            archetypeService.GetWorld().GetPool<ArchetypePrefabComponent>().Add(entity);
        
            // Выпекаем все компоненты, связанные с этим архетипом
            var components = GetComponents<ArchetypeComponent>();
            foreach (var component in components) 
                component.Bake(entity, archetypeService);
        }
    }

}