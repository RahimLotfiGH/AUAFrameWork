using System.Collections.Generic;
using System.Reflection;

namespace AUA.ProjectName.Common.BaseUtility
{
    internal class PropertyInfoCache
    {
        private readonly IDictionary<string, PropertyInfo> _propertyInfoCache;

        public PropertyInfoCache()
        {
            this._propertyInfoCache = new Dictionary<string, PropertyInfo>();
        }

        public bool ContainsKey(string key)
        {
            return _propertyInfoCache.ContainsKey(key);
        }

        public void Add(string key, PropertyInfo value)
        {
            _propertyInfoCache.Add(key, value);
        }

        public PropertyInfo this[string key]
        {
            get => this._propertyInfoCache[key];
            set => this._propertyInfoCache[key] = value;
        }
    }
}
