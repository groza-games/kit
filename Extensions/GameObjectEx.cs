using UnityEngine;

namespace GrozaGames.Kit
{
    public static class GameObjectEx
    {
        public static void SetLayerRecursively(this GameObject gameObject, int layer)
        {
            SetLayerRecursively(gameObject.transform, layer);
        }
        
        public static void SetLayerRecursively(this Transform transform, int layer)
        {
            transform.gameObject.layer = layer;
            foreach (var child in transform)
            {
                SetLayerRecursively((Transform) child, layer);
            }
        }
    }
}