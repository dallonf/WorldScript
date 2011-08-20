using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
{

    public class DictionaryEventArgs : EventArgs
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public DictionaryEventArgs(KeyValuePair<TKey, TValue> pair)
        {
            Key = pair.Key;
            Value = pair.Value;
        }

        public DictionaryEventArgs(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    public event EventHandler<DictionaryEventArgs> OnAdded;
    public event EventHandler<DictionaryEventArgs> OnChanged;
    public event EventHandler<DictionaryEventArgs> OnRemoved;

    private IDictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

    public bool ContainsKey(TKey key)
    {
        return dictionary.ContainsKey(key);
    }

    public void Add(TKey key, TValue value)
    {
        dictionary.Add(key, value);
        OnAdded(this, new DictionaryEventArgs(key, value));
    }

    public bool Remove(TKey key)
    {
        TValue value = dictionary[key];
        bool result = dictionary.Remove(key);
        if (result)
        {
            OnRemoved(this, new DictionaryEventArgs(key, value));
        }
        return result;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return dictionary.TryGetValue(key, out value);
    }

    public TValue this[TKey key]
    {
        get
        {
            return dictionary[key];
        }
        set
        {
            dictionary[key] = value;
            OnChanged(this, new DictionaryEventArgs(key, value));
        }
    }

    public ICollection<TKey> Keys
    {
        get
        {
            return dictionary.Keys;
        }
    }

    public ICollection<TValue> Values
    {
        get
        {
            return dictionary.Values;
        }
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        dictionary.Add(item.Key, item.Value);
        OnAdded(this, new DictionaryEventArgs(item));
    }

    public void Clear()
    {
        var backup = dictionary.Select(kv => new KeyValuePair<TKey, TValue>(kv.Key, kv.Value)).ToList();
        dictionary.Clear();
        foreach (var item in backup)
        {
            OnRemoved(this, new DictionaryEventArgs(item));
        }
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        return dictionary.Contains(item);
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        dictionary.CopyTo(array, arrayIndex);
    }

    public int Count
    {
        get { return dictionary.Count; }
    }

    public bool IsReadOnly
    {
        get { return dictionary.IsReadOnly; }
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        bool result = dictionary.Remove(item);
        OnRemoved(this, new DictionaryEventArgs(item));
        return result;
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }
}
