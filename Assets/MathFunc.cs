using UnityEngine;

namespace DefaultNamespace
{
    public static class MathFunc
    {
        public static Vector3 Cross(Vector3 v, Vector3 w)
        {
            float xMult = v.y * w.z - v.z * w.y;
            float yMult = v.x * w.z - v.z * w.x;
            float zMult = v.x * w.y - v.y * w.x;

            return (new Vector3(xMult, yMult, zMult));
        }
    
        public static float Dot(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
}