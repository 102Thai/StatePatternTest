using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public static class PoolManager
{
    static Dictionary<GameObject, PoolObject> keyValuePairs = new Dictionary<GameObject, PoolObject>();

    public static GameObject Spawn(GameObject prefab)
    {
        if(prefab == null)
        {
            Debug.LogError("this prefab is null, Make sure you assign a prefab for this method");
            return null;
        }
        else
        {
            var pool = default(PoolObject);
            if (keyValuePairs.ContainsKey(prefab))
            {
                pool = keyValuePairs[prefab];
            }
            else
            {
                var go = new GameObject($"PoolManager {prefab.name}");
                pool = go.AddComponent<PoolObject>();
                pool.prefab = prefab;
                keyValuePairs.Add(prefab, pool);
            }
            return pool.Get();
        }
    }

    public static T Spawn<T>(T prefab) where T : Component
    {
        if (prefab == null)
        {
            Debug.LogError("this prefab is null, Make sure you assign a prefab for this method");
            return null;
        }
        else
        {
            var clone = Spawn(prefab.gameObject);
            return clone != null ? clone.GetComponent<T>() : null;
        }
    }

    public static void Despawn(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.LogError("this prefab is null, Make sure you assign a prefab for this method");
            return;
        }
        else
        {
            var pool = default(PoolObject);
            if (keyValuePairs.ContainsKey(prefab))
            {
                pool = keyValuePairs[prefab];
                pool.Release();
            }
        }
    }

    public static void Despawn<T>(T prefab) where T : Component
    {
        if (prefab == null)
        {
            Debug.LogError("this prefab is null, Make sure you assign a prefab for this method");
            return;
        }
        else
        {
            Despawn(prefab.gameObject);
        }
    }

    public static void DespawnAll(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.LogError("this prefab is null, Make sure you assign a prefab for this method");
            return;
        }
        else
        {
            var pool = default(PoolObject);
            if (keyValuePairs.ContainsKey(prefab))
            {
                pool = keyValuePairs[prefab];
                pool.ReleaseAll();
            }
        }
    }

    public static void DespawnAll<T>(T obj) where T : Component
    {
        DespawnAll(obj.gameObject);
    }

    public static void Clear(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.LogError("this prefab is null, Make sure you assign a prefab for this Spawn method");
            return;
        }
        else
        {
            var pool = default(PoolObject);
            if (keyValuePairs.ContainsKey(prefab))
            {
                pool = keyValuePairs[prefab];
                pool.ClearAll();
            }
        }
    }

    public static void Clear<T>(T prefab) where T: Component
    {
        if (prefab == null)
        {
            Debug.LogError("this prefab is null, Make sure you assign a prefab for this Spawn method");
            return;
        }
        else
        {
            Clear(prefab.gameObject);
        }
    }
}