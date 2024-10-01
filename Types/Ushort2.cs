using System;
using UnityEngine;

namespace GrozaGames.Types
{
    [Serializable]
    public struct Ushort2
    {
        public ushort X;
        public ushort Y;

        public Ushort2(ushort x, ushort y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Vector2Int(Ushort2 value)
        {
            return new Vector2Int(value.X, value.Y);
        }
    }
}