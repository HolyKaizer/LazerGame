namespace Core.Extensions
{
    public static class NodeExtensions
    {
        public static T GetValue<T>(this object[] objs, int index)
        {
            if (index >= objs.Length) return default;

            if (objs[index] is T tV) return tV;

            CustomLogger.LogAssertion($"Object array of {objs.Length} doesn't contains {index} item");
            return default;
        }
    }
}