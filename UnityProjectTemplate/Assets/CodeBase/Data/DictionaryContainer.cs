
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class DictionarySerializeContainer<TKey, TValue>
    {
        public List<TKey> Keys = new();
        public List<TValue> Values = new();

        public DictionarySerializeContainer(Dictionary<TKey, TValue> dictionary)
        {
            foreach (var pair in dictionary)
            {
                Keys.Add(pair.Key);
                Values.Add(pair.Value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            Keys.Add(key);
            Values.Add(value);
        }

        public Dictionary<TKey, TValue> ToDictionary()
        {
            Debug.Assert(Keys.Count == Values.Count, "Keys and Values must be equal quantity");

            Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>(Keys.Count);
            
            for (int i = 0; i < Keys.Count; i++) 
                result.Add(Keys[i], Values[i]);

            return result;
        }

        public void Clear()
        {
            Keys.Clear();
            Values.Clear();
        }
    }
}