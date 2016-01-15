using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WebGridExample.Query
{
    public abstract class Enumeration : IComparable
    {
        private readonly int _index;
        private readonly string _value;

        protected Enumeration()
        {
        }

        protected Enumeration(int index, string displayName, string value)
        {
            _index = index;
            _value = value;
            DisplayName = displayName;
        }

        public int Index
        {
            get { return _index; }
        }

        public string Value
        {
            get { return _value; }
        }

        public string DisplayName { get; }

        public override string ToString()
        {
            return DisplayName;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return (from info in fields
                    let instance = new T()
                    select info.GetValue(instance)).OfType<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = _index.Equals(otherValue.Index);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return _index.GetHashCode();
        }

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Index - secondValue.Index);
            return absoluteDifference;
        }

        public static T FromIndex<T>(int index) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, int>(index, "index", item => item.Index == index);
            return matchingItem;
        }

        public static T FromValue<T>(string value) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, string>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem != null) return matchingItem;

            var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));

            throw new ApplicationException(message);
        }

        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration)other).Value);
        }
    }
}