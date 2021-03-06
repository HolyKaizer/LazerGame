using System.Collections.Generic;

namespace Core.Extensions
{
    public static class EmptyRaw
    {
        private static IDictionary<string, object> _default;
        
        public static IDictionary<string, object> Default => _default ??= new Dictionary<string, object>(0);
    }
}