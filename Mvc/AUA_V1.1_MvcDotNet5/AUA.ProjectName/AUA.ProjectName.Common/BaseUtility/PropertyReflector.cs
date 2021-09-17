using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AUA.ProjectName.Common.BaseUtility
{
    public class PropertyReflector
    {
        private static readonly object[] NoParams = new object[0];
        private static readonly Type[] NoTypeParams = new Type[0];
        private readonly IDictionary<Type, PropertyInfoCache> _propertyCache = new Dictionary<Type, PropertyInfoCache>();
        private readonly IDictionary<Type, ConstructorInfo> _constructorCache = new Dictionary<Type, ConstructorInfo>();

        private const char PropertyNameSeparator = '.';

        public Type GetType(Type targetType, string propertyName)
        {
            if (propertyName.IndexOf(PropertyNameSeparator) <= -1)
                return this.GetTypeImpl(targetType, propertyName);
            string str = propertyName;
            char[] chArray = new char[1] { PropertyNameSeparator };
            foreach (string propertyName1 in str.Split(chArray))
                targetType = this.GetTypeImpl(targetType, propertyName1);
            return targetType;
        }

        public object GetValue(object target, string propertyName)
        {
            if (propertyName.IndexOf(PropertyNameSeparator) <= -1)
                return this.GetValueImpl(target, propertyName);
            string str = propertyName;
            char[] chArray = new char[1] { '.' };
            foreach (string propertyName1 in str.Split(chArray))
            {
                target = this.GetValueImpl(target, propertyName1);
                if (target == null)
                    return (object)null;
            }
            return target;
        }

        public void SetValue(object target, string propertyName, object value)
        {
            if (propertyName.IndexOf(PropertyNameSeparator) > -1)
            {
                object target1 = target;
                string[] propertyList = propertyName.Split(PropertyNameSeparator);
                for (int level = 0; level < propertyList.Length - 1; ++level)
                {
                    propertyName = propertyList[level];
                    target = this.GetValueImpl(target, propertyName);
                    if (target == null)
                    {
                        string propertyNameString = PropertyReflector.GetPropertyNameString(propertyList, level);
                        target = this.Construct(this.GetType(target1.GetType(), propertyNameString));
                        this.SetValue(target1, propertyNameString, target);
                    }
                }
                propertyName = propertyList[propertyList.Length - 1];
            }
            this.SetValueImpl(target, propertyName, value);
        }

        private static string GetPropertyNameString(string[] propertyList, int level)
        {
            var stringBuilder = new StringBuilder();
            for (int index = 0; index <= level; ++index)
            {
                if (index > 0)
                    stringBuilder.Append('.');
                stringBuilder.Append(propertyList[index]);
            }
            return stringBuilder.ToString();
        }

        private Type GetTypeImpl(Type targetType, string propertyName)
        {
            return this.GetPropertyInfo(targetType, propertyName).PropertyType;
        }

        private object GetValueImpl(object target, string propertyName)
        {
            return this.GetPropertyInfo(target.GetType(), propertyName).GetValue(target, PropertyReflector.NoParams);
        }

        private void SetValueImpl(object target, string propertyName, object value)
        {
            this.GetPropertyInfo(target.GetType(), propertyName).SetValue(target, value, PropertyReflector.NoParams);
        }

        private PropertyInfo GetPropertyInfo(Type type, string propertyName)
        {
            PropertyInfoCache propertyInfoCache = this.GetPropertyInfoCache(type);
            if (!propertyInfoCache.ContainsKey(propertyName))
            {
                PropertyInfo matchingProperty = PropertyReflector.GetBestMatchingProperty(propertyName, type);
                if (matchingProperty == (PropertyInfo)null)
                    throw new ArgumentException(string.Format("Unable to find public property named {0} on type {1}", (object)propertyName, (object)type.FullName), propertyName);
                propertyInfoCache.Add(propertyName, matchingProperty);
            }
            return propertyInfoCache[propertyName];
        }

        private static PropertyInfo GetBestMatchingProperty(string propertyName, Type type)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            PropertyInfo propertyInfo1 = (PropertyInfo)null;
            int num = int.MaxValue;
            for (int index = 0; index < properties.Length; ++index)
            {
                PropertyInfo propertyInfo2 = properties[index];
                if (propertyInfo2.Name == propertyName)
                {
                    int distance = PropertyReflector.CalculateDistance(type, propertyInfo2.DeclaringType);
                    if (distance == 0)
                        return propertyInfo2;
                    if (distance > 0 && distance < num)
                    {
                        propertyInfo1 = propertyInfo2;
                        num = distance;
                    }
                }
            }
            return propertyInfo1;
        }

        private static int CalculateDistance(Type targetObjectType, Type baseType)
        {
            if (!baseType.IsInterface)
            {
                Type type = targetObjectType;
                int num = 0;
                while (type != (Type)null)
                {
                    if (baseType == type)
                        return num;
                    type = type.BaseType;
                    ++num;
                }
            }
            return -1;
        }

        private PropertyInfoCache GetPropertyInfoCache(Type type)
        {
            if (!this._propertyCache.ContainsKey(type))
            {
                lock (this)
                {
                    if (!this._propertyCache.ContainsKey(type))
                        this._propertyCache.Add(type, new PropertyInfoCache());
                }
            }
            return this._propertyCache[type];
        }

        private object Construct(Type type)
        {
            if (!this._constructorCache.ContainsKey(type))
            {
                lock (this)
                {
                    if (!this._constructorCache.ContainsKey(type))
                    {
                        ConstructorInfo constructor = type.GetConstructor(PropertyReflector.NoTypeParams);
                        if (constructor == (ConstructorInfo)null)
                            throw new Exception(string.Format("Unable to construct instance, no parameterless constructor found in type {0}", (object)type.FullName));
                        this._constructorCache.Add(type, constructor);
                    }
                }
            }
            return this._constructorCache[type].Invoke(PropertyReflector.NoParams);
        }
    }
}
