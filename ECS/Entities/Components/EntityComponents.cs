using System;

namespace GrozaGames.Kit.ECS
{
    /// <summary>
    /// Component that represents an entity name.
    /// </summary>
    [Serializable]
    public struct EntityNameComponent
    {
        /// <summary>
        /// The value of the entity name.
        /// </summary>
        public string Value;
        
        /// <summary>
        /// Implicit conversion from EntityId to string.
        /// </summary>
        /// <param name="entityName">Component to convert.</param>
        /// <returns>Name from component</returns>
        public static implicit operator string(EntityNameComponent entityName) => entityName.Value;
    }

    /// <summary>
    /// Component that represents an serializable entity.
    /// </summary>
    public struct SerializableEntityTagComponent
    {
    }
}