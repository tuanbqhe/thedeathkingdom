using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MethodExtendsion
{
    public static string RemoveQuotes(this string Value)
    {
        return Value.Replace("\"", "");
    }

    public static float TwoDecimals(this float Value)
    {
        return Mathf.Round(Value * 1000.0f) / 1000.0f;
    }
}
