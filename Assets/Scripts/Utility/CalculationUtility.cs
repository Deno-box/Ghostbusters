using System;
using System.Collections.Generic;
using UnityEngine;

namespace GhosterUtility
{
    // 計算系のUtility
    public static class CalculationUtility
    {
        // 指定範囲内に値が収まっているか
        // true : 範囲内 /　false : 範囲外
        public static bool IsWithinRange(float _value,float _min, float _max)
        {
            if (_min <= _value &&
                _value <= _max)
                return true;

            return false;
        }
    }
}

