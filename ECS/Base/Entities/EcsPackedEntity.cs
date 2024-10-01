namespace GrozaGames.Kit.ECS
{
    public struct EcsPackedEntity
    {
        public int Id;
        public int Gen;

        public override int GetHashCode()
        {
            unchecked
            {
                return (23 * 31 + Id) * 31 + Gen;
            }
        }
    }
}