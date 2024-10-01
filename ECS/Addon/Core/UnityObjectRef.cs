using System;

namespace GrozaGames.Kit.ECS
{
    [Serializable]
    public struct UnityObjectRef<T> where T : UnityEngine.Object
    {
        public T Value;
    }
}