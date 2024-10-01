namespace GrozaGames.Kit
{
    public struct PrevCurr<T>
    {
        public T Prev;
        public T Curr;
        
        public PrevCurr(T prev, T curr)
        {
            Prev = prev;
            Curr = curr;
        }
        
        public void Set(T curr)
        {
            Prev = Curr;
            Curr = curr;
        }
    }
}