namespace GrozaGames.Kit.ECS
{
    public interface IEcsPostDestroySystem : IEcsSystem
    {
        void PostDestroy(IEcsSystems systems);
    }
}