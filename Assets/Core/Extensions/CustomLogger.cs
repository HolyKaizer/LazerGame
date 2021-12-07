using UnityEngine;

namespace Core.Extensions
{
    public static class CustomLogger
    {
        public static void Log(object log)
        {
#if LG_DEVELOP
            Debug.Log(log);
#endif
        }
        
        public static void LogAssertion(object log)
        {
#if LG_DEVELOP
            Debug.LogAssertion(log);
#endif
        }
        
        public static void LogWarning(object log)
        {
#if LG_DEVELOP
            Debug.LogWarning(log);
#endif
        }
        
    }
}