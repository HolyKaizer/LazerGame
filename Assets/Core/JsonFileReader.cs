using System.IO;
using fastJSON;

namespace Core
{
    internal class JsonFileReader
    {
        public void Save<T>(T data, string path = null)
        {
            var str = JSON.ToNiceJSON(data);
            File.WriteAllText(path, str);
        }
        
        public T Load<T>(string path = null)
        {
            if (!File.Exists(path)) return default;
            
            var str = File.ReadAllText(path);

            return str == string.Empty ? default : JSON.ToObject<T>(str);
        }
    }
}