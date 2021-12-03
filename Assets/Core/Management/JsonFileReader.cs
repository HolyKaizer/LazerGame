using System.IO;
using Core.Interfaces;
using fastJSON;

namespace Core.Management
{
    public class JsonFileReader : IJsonFileReader
    {
        public void Save<T>(T data, string path = null)
        {
            if(string.IsNullOrEmpty(path)) return;
            
            var str = JSON.ToNiceJSON(data);
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                }
            }
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