using UnityEngine;

namespace Relentless.Utilities
{
    public static class Easings
    {
        public static float EaseInBack(float x)
        {
            const float c1 = 1.70158f;
            const float c3 = c1 + 1;

            return c3 * x * x * x - c1 * x * x;
        }

        public static float EaseOutQuart(float x) => 1f - (1 - x) * (1 - x) * (1 - x) * (1 - x);

        public static float EaseInOut(float x) => -1 * (Mathf.Cos(Mathf.PI * x) - 1) / 2;

        public static float EeaseInBackOutQuart(float x)
        {
            return x < 0.5f
                ? EaseInBack(x * 2f) * 0.5f
                : EaseOutQuart((x - 0.5f) * 2f) * 0.5f + 0.5f;
        }
    }
}
