using UnityEngine;

namespace Relentless.Managers
{
    public class TimeManager
    {
        public static bool IsPaused { get; private set; } = false;

        public static void FreezeTime()
        {
            IsPaused = true;
            Time.timeScale = 0;
            AudioListener.pause = true;
        }

        public static void UnfreezeTime()
        {
            IsPaused = false;
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
    }
}