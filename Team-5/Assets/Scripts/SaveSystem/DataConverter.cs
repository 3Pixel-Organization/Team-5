using UnityEngine;
using System.Collections.Generic;

public static class DataConverter
{
    public static float[] ConvertVector3ToFloatArray(Vector3 vector)
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

    public static float[] GetPosition(List<float[]> positions ,float[] position)
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

    public static bool IsEqual(float[] position01, float[] position02)
    {
        if (position01[0] == position02[0] && position01[1] == position02[1] && position01[2] == position02[2])
            return true;
        else return false;
    }
}
