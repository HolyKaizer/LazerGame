using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Factory
{
    public class FactoryBuilder
    {
        private readonly Dictionary<Type, Dictionary<string, Func<object[], object>>> _variants = new Dictionary<Type, Dictionary<string, Func<object[], object>>>();
        private readonly Dictionary<Type, Func<object[], object>> _variantsSimpleType = new Dictionary<Type, Func<object[], object>>();
        private readonly Dictionary<Type, IFactory> _factories = new Dictionary<Type, IFactory>();

        public T Build<T>(string key)
        {
            var data = _variants[typeof(T)];
            return (T) data[key].Invoke(null);
        }

        public T SimpleBuild<T>(params object[] param)
        {
            var data = _variantsSimpleType[typeof(T)];
            return (T) data.Invoke(param);
        }

        public T Build<T>(params object[] param)
        {
            Type type = typeof(T);
            IFactory factory = _factories[type];
            return (T) factory.Build(param);
        }

        public bool HasVariant<T>(string key)
        {
            Type type = typeof(T);

            Dictionary<string, Func<object[], object>> data;
            if (_variants.TryGetValue(type, out data))
            {
                return data.ContainsKey(key);
            }

            return false;
        }

        public T Build<T>(string key, params object[] param)
        {
            Type type = typeof(T);
            if (_variants.TryGetValue(type, out var variantBuilder))
            {
                return BuildItem<T>(key, param, variantBuilder);
            }
            
            IFactory factory = _factories[type];
            return factory.Build<T>(key, param);
        }

        private T BuildItem<T>(string key, object[] param, Dictionary<string, Func<object[], object>> variantBuilder)
        {
#if LG_DEVELOP
            try
            {
                if (!variantBuilder.TryGetValue(key, out var constructor))
                {
                    constructor = variantBuilder["Consts.DefaultVariant"];
                }

                return (T) constructor.Invoke(param);
            }
            catch (Exception ex)
            {
                Debug.LogAssertion("key " + key + " ex " + ex);
                throw ex;
            }
#else
            if (!variantBuilder.TryGetValue(key, out var constructor))
            {
                constructor = variantBuilder[string.Empty];
            }

            return (T) constructor.Invoke(param);
#endif

        }

        public void AddVariantFunc<T>(string key, Func<object[], object> type)
        {
            var baseType = typeof(T);
            if (!_variants.ContainsKey(baseType))
            {
                _variants[baseType] = new Dictionary<string, Func<object[], object>>();
            }

            _variants[baseType][key] = type;
        }

        public void AddFactory<T>(IFactory factory)
        {
            Type type = typeof(T);
            _factories[type] = factory;
        }

        public void AddVariantFunc<T>(Func<object[], object> type)
        {
            var baseType = typeof(T);
            _variantsSimpleType[baseType] = type;
        }
    }
}