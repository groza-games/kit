using System.Collections.Generic;
using GrozaGames.Kit.Archetypes.Components;
using GrozaGames.Kit.Archetypes.MonoBehaviours;
using GrozaGames.Kit.ECS;
using Zenject;

namespace GrozaGames.Kit.Archetypes.Services
{
    /// <summary>
    /// Сервис для создания и управления архетипами ECS сущностей, их компонентами и механизмом выпекания.
    /// Предоставляет методы для регистрации, получения и создания сущностей на основе архетипов.
    /// </summary>
    public class ArchetypeService
    {
        [Inject] private readonly EcsWorld _world;
        
        private readonly Dictionary<int, Archetype> _entityToArchetype = new Dictionary<int, Archetype>();
        private readonly Dictionary<string, int> _archetypeEntitiesByGuid = new Dictionary<string, int>();
        private readonly Dictionary<string, Archetype> _archetypes = new Dictionary<string, Archetype>();
        
        private readonly List<IArchetypeBakingPostProcessor> _postProcessors = new List<IArchetypeBakingPostProcessor>();
        private readonly HashSet<Archetype> _bakedArchetypes = new HashSet<Archetype>();
        
        /// <summary>
        /// Регистрирует архетип сущности.
        /// </summary>
        /// <param name="archetype">Архетип, который нужно зарегистрировать.</param>
        /// <param name="entity">Идентификатор сущности, связанной с этим архетипом.</param>
        public void RegisterArchetype(Archetype archetype, int entity)
        {
            _archetypeEntitiesByGuid[archetype.Guid] = entity;
            _archetypes[archetype.Guid] = archetype;
            _entityToArchetype[entity] = archetype;
        }

        /// <summary>
        /// Возвращает идентификатор сущности, связанной с указанным GUID архетипа.
        /// </summary>
        /// <param name="guid">GUID архетипа.</param>
        /// <returns>Идентификатор сущности, связанной с данным архетипом.</returns>
        public int GetArchetypeEntity(string guid)
        {
            return _archetypeEntitiesByGuid[guid];
        }

        /// <summary>
        /// Возвращает идентификатор сущности, связанной с указанным архетипом.
        /// </summary>
        /// <param name="archetype">Архетип, для которого нужно найти сущность.</param>
        /// <returns>Идентификатор сущности, связанной с данным архетипом.</returns>
        public int GetArchetypeEntity(Archetype archetype)
        {
            return _archetypeEntitiesByGuid[archetype.Guid];
        }

        /// <summary>
        /// Возвращает архетип по его GUID.
        /// </summary>
        /// <param name="guid">GUID архетипа.</param>
        /// <returns>Архетип, соответствующий переданному GUID.</returns>
        public Archetype GetArchetype(string guid)
        {
            return _archetypes[guid];
        }

        /// <summary>
        /// Возвращает архетип по идентификатору сущности.
        /// </summary>
        /// <param name="entity">Идентификатор сущности.</param>
        /// <returns>Архетип, связанный с указанной сущностью.</returns>
        public Archetype GetArchetype(int entity)
        {
            return _entityToArchetype[entity];
        }

        /// <summary>
        /// Возвращает все идентификаторы сущностей, которые соответствуют зарегистрированным архетипам.
        /// </summary>
        /// <returns>Коллекция идентификаторов сущностей.</returns>
        public IEnumerable<int> GetArchetypeEntities()
        {
            return _archetypeEntitiesByGuid.Values;
        }

        /// <summary>
        /// Возвращает словарь, содержащий соответствие между GUID архетипов и их сущностями.
        /// </summary>
        /// <returns>Словарь, где ключом является GUID архетипа, а значением - идентификатор сущности.</returns>
        public IReadOnlyDictionary<string, int> GetArchetypeEntitiesWithGuids()
        {
            return _archetypeEntitiesByGuid;
        }

        /// <summary>
        /// Возвращает текущий ECS мир.
        /// </summary>
        /// <returns>Текущий ECS мир.</returns>
        public EcsWorld GetWorld()
        {
            return _world;
        }

        /// <summary>
        /// Регистрирует постпроцессор для выпекания архетипов.
        /// </summary>
        /// <param name="postProcessor">Объект постпроцессора, который будет применяться после выпекания архетипов.</param>
        public void RegisterArchetypePostProcessor(IArchetypeBakingPostProcessor postProcessor)
        {
            _postProcessors.Add(postProcessor);
        }
        /// <summary>
        /// Выпекает все зарегистрированные архетипы, применяя постпроцессоры после их выпекания.
        /// </summary>
        public void BakeArchetypes()
        {
            foreach (var (entity, archetype) in _entityToArchetype)
            {
                if (_bakedArchetypes.Contains(archetype)) continue;
                
                archetype.Bake(entity, this);
                _postProcessors.ForEach(p => p.Process(entity, archetype));
                _bakedArchetypes.Add(archetype);
            }
        }

        /// <summary>
        /// Создает экземпляр сущности на основе переданного архетипа.
        /// </summary>
        /// <param name="archetypeEntity">Идентификатор сущности архетипа.</param>
        /// <returns>Идентификатор созданной сущности.</returns>
        public int InstantiateArchetype(int archetypeEntity)
        {
            _world.NewEntityWith<ArchetypeInstanceComponent>(out int instance); 
            _world.CopyEntity(archetypeEntity, instance);
            return instance;
        }
    }
}