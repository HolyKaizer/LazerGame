using System.Collections.Generic;

namespace Core.Extensions
{
    public static class NodeExtensions
    {
        public static T GetValue<T>(this object[] objs, int index)
        {
            if (index >= objs.Length) return default;

            if (objs[index] is T tV) return tV;

            CustomLogger.LogAssertion($"Object array Length={objs.Length} doesn't contains {objs[index]} item at {index} index; Expect {typeof(T)} item type");
            return default;
        }
        
        public static IDictionary<string, object> TryGetNode(this object[] objs, int index)
        {
            if (index >= objs.Length) return default;

            if (objs[index] is IDictionary<string, object> tV) return tV;

            CustomLogger.LogAssertion($"Object array Length={objs.Length} doesn't contains node for index={index}; Param is {objs[index].GetType()} type");
            return default;
        }
    }
}