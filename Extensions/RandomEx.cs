using System;

namespace GrozaGames.Kit
{
    public static class RandomEx
    {
        public static float NextFloat(this Random random)
        {
            return (float) random.NextDouble();
        }
    }
}