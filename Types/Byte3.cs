using System;
using UnityEngine;

namespace GrozaGames.Types
{
    [Serializable]
    public struct Byte3
    {
        public byte X;
        public byte Y;
        public byte Z;

        public Byte3(byte x, byte y, byte z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator Vector3Int(Byte3 value)
        {
            return new Vector3Int(value.X, value.Y, value.Z);
        }
    }
}