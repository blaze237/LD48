using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtils
{
    public static bool ApproxLessThan(float a, float b)
    {
        return (a - b) < -Mathf.Epsilon;
    }

    public static bool ApproxGreaterThan(float a, float b)
    {
        return a - b > Mathf.Epsilon;
    }


    public static Vector3 AbsVector(Vector3 vector)
    {
        return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    }
}