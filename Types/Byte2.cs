using System;
using UnityEngine;

namespace GrozaGames.Types
{
    [Serializable]
    public struct Byte2
    {
        public byte X;
        public byte Y;

        public Byte2(byte x, byte y)
        {
            X = x;
            Y = y;
        }

        public Byte2(Vector2Int value)
        {
            X = (byte)value.x;
            Y = (byte)value.y;
        }
        
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static implicit operator Vector2Int(Byte2 value)
        {
            return new Vector2Int(value.X, value.Y);
        }
        
        public static implicit operator Byte2(Vector2Int value)
        {
            return new Byte2(value);
        }
    }
}