using Unity.Mathematics;

namespace GrozaGames.Kit
{
    public static class ByteUtils
    {
        public static byte Float01ToByte(float value)
        {
            return FloatToByte(value, 0, 1);
        }
        
        public static byte FloatToByte(float value, float min = -1f, float max = 1f)
        {
            return (byte) math.remap(min, max, 0, 255, value);
        }
        
        public static float ByteToFloat01(byte byteValue)
        {
            return ByteToFloat(byteValue, 0, 1);
        }
        
        public static float ByteToFloat(byte byteValue, float min = -1f, float max = 1f)
        {
            return math.remap(0, 255, min, max, byteValue);
        }
        
        public static byte RotationToByte(float rotation)
        {
            while (rotation < 0) rotation += 360;
            while (rotation >= 360) rotation -= 360;
            return (byte) math.remap(0, 360, 0, 255, rotation);
        }
        
        public static float ByteToRotation(byte byteRotation)
        {
            return math.remap(0, 255, 0, 360, byteRotation);
        }
    }
}