using System;
using System.Collections;
using System.Collections.Generic;
using Core.Models;
using UnityEngine;

namespace Core.UI
{
    public static class RawNodeExtension
    {
        public static IDictionary<string, object> GetOrCreateNode(this IDictionary<string, object> node, string key)
        {
            if (node.ContainsKey(key))
                return (IDictionary<string, object>) node[key];
            return new Dictionary<string, object>();
        }
        
        public static IDictionary<string, object> TryGetNode(this IDictionary<string, object> node, string key)
        {
            if (node.ContainsKey(key))
                return (IDictionary<string, object>) node[key];
            return EmptyRaw.Default;
        }
        
        public static IDictionary<string, object> TryGetNode(this IDictionary<string, object> node, string key, IDictionary<string, object> defaultNode)
        {
            if (node.ContainsKey(key))
                return (IDictionary<string, object>) node[key];
            return defaultNode;
        }
        
        public static Dictionary<string, string> TryGetDictionary(this IDictionary<string, object> node, string key)
        {
            var dict = new Dictionary<string, string>();

            if (node.ContainsKey(key))
            {
                var data = (IDictionary<string, object>) node[key];
                foreach (var item in data)
                {
                    dict.Add(item.Key, item.Value.ToString()); 
                }
            }

            return dict;
        }
       
        public static IDictionary<string, object> TryGetNode(this IList<object> node, int id)
        {
            if (node.Contains(id))
                return (IDictionary<string, object>) node[id];
            return new Dictionary<string, object>();
        }

        public static IDictionary<string, object> GetNode(this IDictionary<string, object> node, string key)
        {
            return (IDictionary<string, object>)node[key];
        }

        public static IDictionary<string, object> GetNode(this IList<object> node, int id)
        {
            return (IDictionary<string, object>) node[id];
        }

        public static IList<object> GetArray(this IDictionary<string, object> node, string key)
        {
            return (IList<object>) node[key];
        }

        public static IList<object> GetArray(this IList<object> node, int id)
        {
            return (IList<object>) node[id];
        }

        public static Vector4 GetVector4(this IDictionary<string, object> node, string key, Vector4 defaultValue = new Vector4())
        {
            var list = node.GetFloatList(key);
            return list.Count > 0 ? list.GetVector4() : defaultValue;
        }

        public static Vector4 GetVector4(this List<float> node)
        {
            return new Vector4(node[0], node[1], node[2], node[3]);
        }
        
        public static List<Vector2> GetVector2List(this IDictionary<string, object> node, string key)
        {
            var objects = node.GetObjectList(key);
            var ret = new List<Vector2>(objects.Count);

            for (var i = 0; i < objects.Count; i++)
            {
                var rawVector2 = objects.GetFloatList(i);
                ret.Add(rawVector2.GetVector2());
            }

            return ret;
        }
        
        public static List<Vector3> GetVector3List(this IDictionary<string, object> node, string key)
        {
            var objects = node.GetObjectList(key);
            var ret = new List<Vector3>(objects.Count);

            for (var i = 0; i < objects.Count; i++)
            {
                var rawVector3 = objects.GetFloatList(i);
                ret.Add(rawVector3.GetVector3());
            }

            return ret;
        }  
        
        public static HashSet<Vector3> GetVector3HashSet(this IDictionary<string, object> node, string key)
        {
            var objects = node.GetObjectList(key);
            var ret = new HashSet<Vector3>();

            for (var i = 0; i < objects.Count; i++)
            {
                var rawVector3 = objects.GetFloatList(i);
                ret.Add(rawVector3.GetVector3());
            }

            return ret;
        }
        
        public static List<Vector3> GetVector3List(this IList<object> objects)
        {
            var ret = new List<Vector3>(objects.Count);

            for (var i = 0; i < objects.Count; i++)
            {
                var rawVector3 = objects.GetFloatList(i);
                ret.Add(rawVector3.GetVector3());
            }

            return ret;
        }
        
        public static List<Vector4> GetVector4List(this IDictionary<string, object> node, string key)
        {
            var objects = node.GetObjectList(key);
            var ret = new List<Vector4>(objects.Count);

            for (var i = 0; i < objects.Count; i++)
            {
                var rawVector4 = objects.GetFloatList(i);
                ret.Add(rawVector4.GetVector4());
            }

            return ret;
        }
        

        public static Vector3 GetVector3(this IDictionary<string, object> node, string key, Vector3 defaultValue = new Vector3())
        {
            var list = node.GetFloatList(key);
            return list.Count > 0 ? list.GetVector3() : defaultValue;
        }
        
        public static Vector3 GetVector3(this List<float> node)
        {
            return new Vector3(node[0], node[1], node[2]);
        }

        public static Vector2 GetVector2(this IDictionary<string, object> node, string key, Vector2 defaultValue = new Vector2())
        {
            var list = node.GetFloatList(key);
            return list.Count > 0 ? list.GetVector2() : defaultValue;
        }
        
        public static Vector2 GetVector2(this List<float> node)
        {
            return new Vector2(node[0], node[1]);
        }
        
        public static Color32 GetColor32(this IDictionary<string, object> node, string key, Color32 defaultValue = new Color32())
        {
            var list = node.GetByteList(key);
            return list.Count > 0 ? list.GetColor32() : defaultValue;
        }
        
        public static Color32 GetColor32(this List<byte> node)
        {
            return new Color32(node[0], node[1], node[2], node.Count == 4 ? node[3] : byte.MaxValue);
        }
        
        public static List<Color32> GetColor32List(this IList<object> node)
        {
            var result = new List<Color32>();
            foreach (var array in node)
            {
                var colorRaw = new List<byte>();
                foreach (var item in (IEnumerable) array)
                    colorRaw.Add(Convert.ToByte(item));
                result.Add(colorRaw.GetColor32());
            }
            return result;
        }
        
        public static Color GetColor(this IDictionary<string, object> node, string key, Color defaultValue = new Color())
        {
            var list = node.GetFloatList(key);
            return list.Count > 0 ? list.GetColor() : defaultValue;
        }
        
        public static Color GetColor(this List<float> node)
        {
            return new Color(node[0], node[1], node[2], node.Count == 4 ? node[3] : 1f);
        }
        
        public static List<Color> GetColorList(this IList<object> node)
        {
            var result = new List<Color>();
            foreach (var array in node)
            {
                var colorRaw = new List<float>();
                foreach (var item in (IEnumerable) array)
                    colorRaw.Add(Convert.ToSingle(item));
                result.Add(colorRaw.GetColor());
            }
            return result;
        }

        public static Color GetColorHex(this IDictionary<string, object> node, string key, Color defaultValue = new Color())
        {
            Color color;

            return ColorUtility.TryParseHtmlString(string.Format("#{0}", node.GetString(key)), out color) ? color : defaultValue;
        }

        public static int GetInt(this IDictionary<string, object> node, string key, int defaultValue = 0)
        {
            if (node.TryGetValue(key, out var value) && !(value is ICollection))
                return Convert.ToInt32(value);
            return defaultValue;
        }

        public static int GetInt(this IList<object> node, int id, int defaultValue = 0)
        {
            if (id >= 0 && id < node.Count)
                return Convert.ToInt32(node[id]);
            return defaultValue;
        }

        public static long GetLong(this IDictionary<string, object> node, string key, long defaultValue = 0)
        {
            if (node.TryGetValue(key, out var value) && !(value is ICollection))
                return Convert.ToInt64(value);
            return defaultValue;
        }

        public static float GetFloat(this IDictionary<string, object> node, string key, float defaultValue = 0)
        {
            if (node.TryGetValue(key, out var value) && !(value is ICollection))
                return Convert.ToSingle(value);
            return defaultValue;
        }

        public static double GetDouble(this IDictionary<string, object> node, string key, double defaultValue = 0)
        {
            if (node.TryGetValue(key, out var value) && !(value is ICollection))
            {
                return Convert.ToDouble(value);
            }
            return defaultValue;
        }

        public static string GetString(this IDictionary<string, object> node, string key, string defaultValue = Consts.StringEmpty)
        {
            if (node.TryGetValue(key, out var value))
            {
                if (value == null) return string.Empty;
                return value.ToString();
            }

            return defaultValue;
        }

        public static string GetString(this IList<object> node, int id, string defaultValue = Consts.StringEmpty)
        {
            try
            {
                if (id >= 0 && id < node.Count)
                    return node[id].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
            return defaultValue;
        }

        public static bool GetBool(this IDictionary<string, object> node, string key, bool defaultValue = false)
        {
            if (node.TryGetValue(key, out var value))
                return Convert.ToBoolean(value);
            return defaultValue;
        }

        public static List<int> GetIntList(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var value))
            {
                var objects = (IEnumerable) value;
                var ret = new List<int>();
                
                foreach (var e in objects)
                    ret.Add(Convert.ToInt32(e));
                
                return ret;
            }
            
            return new List<int>(0);
        }
        
        public static List<long> GetLongList(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var value))
            {
                var objects = (IEnumerable) value;
                var ret = new List<long>();
                
                foreach (var e in objects)
                    ret.Add(Convert.ToInt64(e));
                
                return ret;
            }
            
            return new List<long>(0);
        }

        public static List<int> GetIntList(this IList<object> node, int id)
        {
            if (id < node.Count)
            {
                var objects = (IEnumerable)node[id];
                var ret = new List<int>();
                
                foreach (var o in objects)
                    ret.Add(Convert.ToInt32(o));
                
                return ret;
            }
            
            return new List<int>(0);
        }

        public static List<float> GetFloatList(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var value))
            {
                var objects = (IEnumerable)value;
                var ret = new List<float>();

                foreach (var e in objects)
                    ret.Add(Convert.ToSingle(e));
                
                return ret;
            }
            
            return  new List<float>(0);
        }

        public static List<float> GetFloatList(this IList<object> node, int id)
        {
            if (id < node.Count)
            {
                var objects = (IEnumerable)node[id];
                var ret = new List<float>();

                foreach (var o in objects)
                    ret.Add(Convert.ToSingle(o));
                    
                return ret;   
            }
            
            return new List<float>(0);
        }

        public static List<double> GetDoubleList(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var value))
            {
                var ret = new List<double>();

                foreach (var e in (IEnumerable)value)
                    ret.Add(Convert.ToDouble(e));
                
                return ret;
            }
            
            return new List<double>(0);
        }

        public static List<string> GetStringList(this IDictionary<string, object> node, string key, List<string> defaultValue)
        {
            if (node.TryGetValue(key, out var value))
            {
                var ret = new List<string>();
                foreach (var e in (IEnumerable)value)
                    ret.Add(Convert.ToString(e));
                return ret;
            }
            return defaultValue;
        }

        public static List<string> GetStringList(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var value))
            {
                var ret = new List<string>();

                foreach (var e in (IEnumerable)value)
                    ret.Add(Convert.ToString(e));
                
                return ret;
            }
            
            return new List<string>(0); 
        }

        public static List<string> GetStringList(this IList<object> node, int id)
        {
            if (id < node.Count)
            {
                var objects = (IEnumerable)node[id];
                var ret = new List<string>();

                foreach (var o in objects)
                    ret.Add(Convert.ToString(o));
                    
                return ret;   
            }
            
            return new List<string>(0);
        }

        public static HashSet<string> GetHashSetList(this IDictionary<string, object> node, string key, HashSet<string> defaultValue)
        {
            object value;
            if (node.TryGetValue(key, out value))
            {
                var ret = new HashSet<string>();
                foreach (var e in (IEnumerable) value)
                {
                    ret.Add(Convert.ToString(e));
                }
                
                return ret;
            }
            
            return defaultValue;
        }

        public static HashSet<string> GetHashSetList(this IDictionary<string, object> node, string key)
        {
            var ret = new HashSet<string>();
            if (node.TryGetValue(key, out var value))
                foreach (var e in (IEnumerable)value)
                    ret.Add(Convert.ToString(e));

            return ret;
        }
        
        public static IDictionary<string, int> ToIntDictionary(this IDictionary<string, object> node)
        {
            var result = new Dictionary<string, int>();
            foreach (var key in node.Keys)
            {
                result.Add(key, node.GetInt(key));
            }

            return result;
        }
        
        public static IDictionary<string, long> ToLongDictionary(this IDictionary<string, object> node)
        {
            var result = new Dictionary<string, long>();
            foreach (var key in node.Keys)
            {
                result.Add(key, node.GetLong(key));
            }

            return result;
        }
        
        public static Dictionary<string, string> ToStringDictionary(this IDictionary<string, object> node)
        {
            var result = new Dictionary<string, string>();
            foreach (var key in node.Keys)
            {
                result.Add(key, node.GetString(key));
            }

            return result;
        }
        
        public static List<HashSet<string>> GetListHashSetString(this IDictionary<string, object> node, string key)
        {
            var objectList = node.GetObjectList(key);
            var result = new List<HashSet<string>>(objectList.Count);
            foreach (var item in objectList)
            {
                var ret = new HashSet<string>();
                foreach (var e in (IEnumerable)item)
                    ret.Add(Convert.ToString(e));
                result.Add(ret);
            }
            return result;
        }

        public static List<byte> GetByteList(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var value))
            {
                var ret = new List<byte>();

                foreach (var e in (IEnumerable)value)
                    ret.Add(Convert.ToByte(e));
                return ret;
            }
            
            return new List<byte>(0);
        }

        public static List<bool> GetBoolList(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var value))
            {
                var ret = new List<bool>();

                foreach (var e in (IEnumerable)value)
                    ret.Add(Convert.ToBoolean(e));
                
                return ret;
            }
            
            return new List<bool>(0);
        }

        public static void AddListRange(this IList<object> array, IEnumerable<object> items)
        {
            foreach (var item in items)
            {
                array.Add(item);
            }
        }

        public static IList<object> GetObjectList(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var value))
                return value as IList<object>;
            return new List<object>();
        }
        
        public static IList<object> GetObjectList(this IDictionary<string, object> node, string key, IList<object> defaultValue)
        {
            if (node.TryGetValue(key, out var value))
                return value as IList<object>;
            return defaultValue;
        }

        public static IList<IDictionary<string,object>> GetNodeList(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var value))
            {
                var ret = new List<IDictionary<string, object>>();

                foreach (var e in (IEnumerable)value)
                    ret.Add((IDictionary<string, object>) e);
                
                return ret;
            }
            
            return new List<IDictionary<string, object>>(0);
        }

        public static IDictionary<string, int> GetDictionaryStringInt(this IDictionary<string, object> node, string key)
        {
            if (node.ContainsKey(key))
            {
                var dictNode = (IDictionary<string, object>) node[key];
                var result = new Dictionary<string, int>(dictNode.Count);
                foreach (var e in dictNode)
                    result[e.Key] = Convert.ToInt32(e.Value);

                return result;
            }

            return new Dictionary<string, int>(0);
        }
        
        public static IDictionary<int, string> GetDictionaryIntString(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var rawDict))
            {
                var result = new Dictionary<int, string>(node.Count);
                if (rawDict is IDictionary<int, string> dictIntString)
                {
                    foreach (var entry in dictIntString)
                    {
                        result.Add(entry.Key, entry.Value);
                    }
                }
                else if (rawDict is IDictionary<string, object> dictStringObject)
                {
                    foreach (var entry in dictStringObject)
                    {
                        int.TryParse(entry.Key, out var id);
                        result.Add(id, entry.Value.ToString());
                    }
                }

                return result;
            }

            return new Dictionary<int, string>(0);
        }
        
        public static Dictionary<string, long> GetDictionaryStringLong(this IDictionary<string, object> node, string key)
        {
            if (node.ContainsKey(key))
            {
                var dictNode = (IDictionary<string, object>) node[key];
                var result = new Dictionary<string, long>(dictNode.Count);
                foreach (var e in dictNode)
                    result[e.Key] = Convert.ToInt64(e.Value);

                return result;
            }

            return new Dictionary<string, long>(0);
        }

        public static Dictionary<string, string> GetDictionaryStringString(this IDictionary<string, object> node, string key)
        {
            if (node.ContainsKey(key))
            {
                var dictNode = (IDictionary<string, object>) node[key];
                var result = new Dictionary<string, string>(dictNode.Count);
                foreach (var e in dictNode)
                    result[e.Key] = e.Value.ToString();

                return result;
            }

            return new Dictionary<string, string>(0);
        }  
        
        public static Dictionary<string, IList<string>> GetDictionaryStringList(this IDictionary<string, object> node, string key)
        {
            if (node.ContainsKey(key))
            {
                var dictNode = (IDictionary<string, object>) node[key];
                var result = new Dictionary<string, IList<string>>(dictNode.Count);
                foreach (var dictKey in dictNode.Keys)
                    result[dictKey] = dictNode.GetStringList(dictKey);

                return result;
            }

            return new Dictionary<string, IList<string>>(0);
        }

        public static List<T> GetTypedList<T>(this IDictionary<string, object> node, string key)
        {
            if (node.TryGetValue(key, out var value))
            {
                var ret = new List<T>();

                foreach (var e in (IEnumerable)value)
                    ret.Add((T) e);
                
                return ret;
            }
            
            return new List<T>(0);
        }

        public static object GetValue(this IDictionary<string, object> node, string key, object defaultValue)
        {
            if (node.TryGetValue(key, out var value))
                return value;

            return defaultValue;
        }

        public static T GetValue<T>(this IDictionary<string, T> node, string key)
        {
            T value;
            if (node.TryGetValue(key, out value))
                return value;

            return default;
        }

        public static byte[] GetBytesUUID(this Guid guid)
        {
            byte[] guidBytes = guid.ToByteArray();
            byte[] uuidBytes =
            {
                guidBytes[3],
                guidBytes[2],
                guidBytes[1],
                guidBytes[0],
                guidBytes[5],
                guidBytes[4],
                guidBytes[7],
                guidBytes[6],
                guidBytes[8],
                guidBytes[9],
                guidBytes[10],
                guidBytes[11],
                guidBytes[12],
                guidBytes[13],
                guidBytes[14],
                guidBytes[15]
            };
            return uuidBytes;
        }
    }
}