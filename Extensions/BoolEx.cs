using System.Runtime.CompilerServices;
namespace GrozaGames.Kit
{
    public static class BoolEx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToSign(this bool value)
        {
            return value ? 1 : -1;
        }
    }
}
