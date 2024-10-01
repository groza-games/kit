using GrozaGames.Kit.Archetypes.Services;
using UnityEngine;

namespace GrozaGames.Kit.Archetypes.MonoBehaviours
{
    /// <summary>
    /// Абстрактный класс, представляющий компонент архетипа.
    /// Архетип-компоненты используются для добавления специфичных данных или поведения сущностям, выпекаемым на основе архетипов.
    /// </summary>
    [RequireComponent(typeof(Archetype))]
    public abstract class ArchetypeComponent : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на архетип, с которым связан компонент.
        /// </summary>
        [field: SerializeField]
        public Archetype Archetype { get; private set; }

        /// <summary>
        /// Метод, вызываемый при сбросе компонента. Автоматически находит и устанавливает ссылку на родительский архетип.
        /// </summary>
        protected virtual void Reset()
        {
            Archetype = GetComponent<Archetype>();
        }

        /// <summary>
        /// Абстрактный метод для выпекания компонента на сущности.
        /// </summary>
        /// <param name="entity">Идентификатор сущности, к которой добавляется компонент.</param>
        /// <param name="archetypeService">Сервис архетипов, через который производится взаимодействие с ECS.</param>
        public abstract void Bake(int entity, ArchetypeService archetypeService);
    }

    /// <summary>
    /// Обобщённый абстрактный класс архетип-компонента, который автоматически выпекает ECS компонент типа <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Тип структуры компонента, который будет добавлен в ECS.</typeparam>
    [RequireComponent(typeof(Archetype))]
    public abstract class ArchetypeComponent<T> : ArchetypeComponent where T : struct
    {
        /// <summary>
        /// Данные компонента, которые будут добавлены на сущность в процессе выпекания.
        /// </summary>
        [field: SerializeField]
        public T Component { get; private set; }

        /// <summary>
        /// Выпекает компонент <typeparamref name="T"/> на сущность, добавляя его в пул ECS.
        /// </summary>
        /// <param name="entity">Идентификатор сущности, к которой добавляется компонент.</param>
        /// <param name="archetypeService">Сервис архетипов, через который производится взаимодействие с ECS.</param>
        public override void Bake(int entity, ArchetypeService archetypeService)
        {
            archetypeService.GetWorld().GetPool<T>().Add(entity) = Component;
        }
    }
}