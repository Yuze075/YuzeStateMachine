namespace YuzeToolkit.Framework.StateMachine
{
    public static class Logger
    {
        public static void Log(string massage)
        {
#if LOGGER_SYSTEM
            LoggerSystem.LoggerSystem.Log(massage, new[] { "StateMachine" });
#else
            UnityEngine.Debug.Log(massage);
#endif
        }

        public static void Warning(string massage)
        {
#if LOGGER_SYSTEM
            LoggerSystem.LoggerSystem.Warning(massage, new[] { "StateMachine" });
#else
            UnityEngine.Debug.LogWarning(massage);
#endif
        }

        public static void Error(string massage)
        {
#if LOGGER_SYSTEM
            LoggerSystem.LoggerSystem.Error(massage, new[] { "StateMachine" });
#else
            UnityEngine.Debug.LogError(massage);
#endif
        }
    }
}