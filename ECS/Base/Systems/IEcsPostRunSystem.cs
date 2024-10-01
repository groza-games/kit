namespace GrozaGames.Kit.ECS
{
    public interface IEcsPostRunSystem : IEcsSystem
    {
        void PostRun(IEcsSystems systems);
    }
}