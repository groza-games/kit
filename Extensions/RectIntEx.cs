using System.Collections.Generic;
using UnityEngine;

namespace GrozaGames.Kit
{
    public static class RectIntEx
    {
        public static IEnumerable<Vector2Int> Asd(this RectInt rectInt, RectInt b)
        {
            for (var x = rectInt.min.x; x <= b.max.x; x++)
            for (var y = rectInt.min.y; y <= b.max.y; y++)
            {
                var p = new Vector2Int(x, y);
                if (!b.Contains(p))
                    yield return p;
            }
        }
        
        public static IEnumerable<Vector2Int> GetAllVectors(this RectInt rectInt)
        {
            for (var x = rectInt.xMin; x <= rectInt.xMax; x++)
            for (var y = rectInt.yMin; y <= rectInt.yMax; y++)
                yield return new Vector2Int(x, y);
        }
    }
}