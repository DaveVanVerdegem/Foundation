using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Maths
{
    public static class Maths
    {
        #region Angles
        public static float GetAngle(float x, float y)
           => Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        #endregion
    }
}

