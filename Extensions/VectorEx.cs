using UnityEngine;
namespace GrozaGames.Kit
{
    public static class VectorEx
    {
        public static Vector2 ToXY(this Vector3 vec)
        {
            return new Vector2(vec.x, vec.y);
        }
        
        public static Vector2 ToXZ(this Vector3 vec)
        {
            return new Vector2(vec.x, vec.z);
        }
        
        public static Vector2Int ToXY(this Vector3Int vec)
        {
            return new Vector2Int(vec.x, vec.y);
        }
        
        public static Vector2Int ToXZ(this Vector3Int vec)
        {
            return new Vector2Int(vec.x, vec.z);
        }
        
        public static Vector3 ToX0Z(this Vector2 vec)
        {
            return new Vector3(vec.x, 0, vec.y);
        }
        
        public static Vector3 ToXY0(this Vector2 vec)
        {
            return new Vector3(vec.x, vec.y, 0);
        }

        public static Vector3 WithX(this Vector3 vec, float x)
        {
            return new Vector3(x, vec.y, vec.z);
        }

        public static Vector3 WithY(this Vector3 vec, float y)
        {
            return new Vector3(vec.x, y, vec.z);
        }

        public static Vector3 WithZ(this Vector3 vec, float z)
        {
            return new Vector3(vec.x, vec.y, z);
        }

        public static Vector3 WithZ(this Vector2 vec, float z)
        {
            return new Vector3(vec.x, vec.y, z);
        }

        public static Vector2 WithX(this Vector2 vec, float x)
        {
            return new Vector2(x, vec.y);
        }

        public static Vector2 WithY(this Vector2 vec, float y)
        {
            return new Vector2(vec.x, y);
        }

        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            var sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            var cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            var tx = v.x;
            var ty = v.y;
            v.x = cos * tx - sin * ty;
            v.y = sin * tx + cos * ty;
            return v;
        }

        public static Vector3 ToHorizontal(this Vector3 v)
        {
            return new Vector3(v.x, 0, v.z);
        }

        public static Vector3 ToVertical(this Vector3 v)
        {
            return new Vector3(0, v.y, 0);
        }
        
        public static Vector2 ToVector2(this Vector2Int v)
        {
            return new Vector2(v.x, v.y);
        }
        
        public static Vector2Int ToVector2Int(this Vector2 v)
        {
            return new Vector2Int((int)v.x, (int)v.y);
        }
        
        public static Vector3 ToVector3(this Vector3Int v)
        {
            return new Vector3(v.x, v.y, v.z);
        }
        
        public static Vector3Int ToVector3Int(this Vector3 v)
        {
            return new Vector3Int((int) v.x, (int) v.y, (int) v.z);
        }

        public static float Lerp(this Vector2 v, float t)
        {
            return Mathf.Lerp(v.x, v.y, t);
        }

        public static float Lerp(this Vector2 v, double t)
        {
            return Mathf.Lerp(v.x, v.y, (float) t);
        }

        public static float GetRandom(this Vector2 v)
        {
            return Random.Range(v.x, v.y);
        }

        public static float GetRandom(this Vector2 v, System.Random random)
        {
            return v.Lerp(random.NextDouble());
        }
        
        public static float GetRandom(this Vector2Int v)
        {
            return Random.Range(v.x, v.y);
        }
    }
}
