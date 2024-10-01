using GrozaGames.Kit.Archetypes.MonoBehaviours;

namespace GrozaGames.Kit.Archetypes.Services
{
    /// <summary>
    /// Интерфейс для постпроцессоров, которые выполняются после выпекания архетипа.
    /// Позволяет реализовать логику, которая должна быть выполнена для сущностей после того, как архетип был выпечен.
    /// </summary>
    public interface IArchetypeBakingPostProcessor
    {
        /// <summary>
        /// Метод для обработки сущности и её архетипа после выпекания.
        /// </summary>
        /// <param name="entity">Идентификатор сущности, которая была выпечена.</param>
        /// <param name="archetype">Архетип, связанный с данной сущностью.</param>
        void Process(int entity, Archetype archetype);
    }
}