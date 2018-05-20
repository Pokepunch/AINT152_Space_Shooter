using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extention
{
    /// <summary>
    /// Linearly interpolates between vectors a,b and c by t.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Vector2 LerpCurve(Vector2 a, Vector2 b, Vector2 c, float t)
    {
        Vector2 p0 = Vector2.Lerp(a, b, t);
        Vector2 p1 = Vector2.Lerp(b, c, t);
        return Vector2.Lerp(p0, p1, t);
    }
}