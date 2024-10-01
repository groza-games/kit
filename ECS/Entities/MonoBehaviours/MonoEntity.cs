using UnityEngine;

namespace GrozaGames.Kit.ECS
{
    /// <summary>
    /// MonoBehaviour that represents an entity.
    /// </summary>
    public class MonoEntity : MonoBehaviour
    {
        /// <summary>
        /// The entity.
        /// </summary>
        public int Value { get; set; }
        
        /// <summary>
        /// The entity's id.
        /// </summary>
        /// <param name="monoEntity">MonoEntity</param>
        /// <returns>Entity's ID</returns>
        public static implicit operator int(MonoEntity monoEntity) => monoEntity.Value;
    }
}