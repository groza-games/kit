namespace GrozaGames.Kit.ECS
{
    public interface IEcsInitSystem : IEcsSystem
    {
        void Init(IEcsSystems systems);
    }
}