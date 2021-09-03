using UnityEngine;
using System.Collections.Generic;
using System;

namespace JASUtils
{
    public static class Utils
    {
        public static float[] Vector3ToFloatArray(Vector3 vector)
        {
            float posX = vector.x;
            float posY = vector.y;
            float posZ = vector.z;
            return new float[3] { posX, posY, posZ };
        }

        public static Vector3Int ConvertFloatArrayToVector3Int(float[] _float)
        {
            return new Vector3Int((int)_float[0], (int)_float[1], (int)_float[2]);
        }

        public static Vector3 ConvertFloatArrayToVector3(float[] _float)
        {
            return new Vector3(_float[0], _float[1], _float[2]);
        }

        public static Vector3Int ConvertVetor3ToVector3Int(Vector3 vector)
        {
            int x = Mathf.RoundToInt(vector.x);
            int y = Mathf.RoundToInt(vector.y);
            int z = Mathf.RoundToInt(vector.z);

            return new Vector3Int(x, y, z);
        }

        public static float[] GetPosition(List<float[]> positions, float[] position)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                if (IsEqual(positions[i], position))
                {
                    return positions[i];
                }
            }

            return null;
        }

        public static float[] GetPosition(Dictionary<float[], int>.KeyCollection positions, float[] position)
        {
            foreach (float[] _position in positions)
            {
                if (IsEqual(_position, position))
                {
                    return _position;
                }
            }

            return null;
        }

        public static bool IsEqual(float[] position01, float[] position02)
        {
            if (position01.Length != position02.Length)
                return false;
            for (int i = 0; i < position01.Length; i++)
            {
                if (position01[i] != position02[i])
                    return false;
            }

            return true;
        }

        public static bool Contains(List<float[]> positions, float[] position)
        {
            foreach (float[] pos in positions)
            {
                if (IsEqual(pos, position))
                    return true;
            }

            return false;
        }

        public static bool ContainsKey(Dictionary<float[], int>.KeyCollection keys, float[] position)
        {
            foreach (float[] pos in keys)
            {
                if (IsEqual(pos, position))
                    return true;
            }

            return false;
        }
    }
}
