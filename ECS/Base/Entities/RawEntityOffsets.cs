using System;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace GrozaGames.Kit.ECS
{
    public static class RawEntityOffsets
    {
        public const int ComponentsCount = 0;
        public const int Gen = 1;
        public const int Components = 2;
    }
}

#if ENABLE_IL2CPP
namespace Unity.IL2CPP.CompilerServices 
{
    public enum Option {
        NullChecks = 1,
        ArrayBoundsChecks = 2
    }

    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class Il2CppSetOptionAttribute : Attribute {
        public Option Option { get; private set; }
        public object Value { get; private set; }

        public Il2CppSetOptionAttribute (Option option, object value) { Option = option; Value = value; }
    }
}
#endif