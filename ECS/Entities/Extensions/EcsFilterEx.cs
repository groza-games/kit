using System.Linq;
using GrozaGames.Kit.ECS;

namespace GrozaGames.ECS
{
    public static class EcsFilterEx
    {
        public static bool Match(this EcsFilter filter, int entity)
        {
            return filter.GetRawEntities().Contains(entity);
        }
    }
}