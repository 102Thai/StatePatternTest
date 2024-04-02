using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolObject : MonoBehaviour
{
    public IObjectPool<GameObject> pool;

    public int maxSize = 10;
    public bool collectionChecks = true;
    public GameObject prefab;

    public List<GameObject> list;

    public enum PoolType
    {
        stack,
        linkedlist
    }
    public PoolType poolType= PoolType.stack;

    private void OnEnable()
    {
        if(poolType == PoolType.stack)
        {
            pool = new ObjectPool<GameObject>(CreatAObject, GetObjectFromPool, ReturnObjectToPool, DestroyObject, collectionChecks,10, maxSize);
        }
        else
        {
            pool = new LinkedPool<GameObject>(CreatAObject, GetObjectFromPool, ReturnObjectToPool, DestroyObject, collectionChecks, maxSize);
        }
        list = new List<GameObject>(); 
    }

    GameObject CreatAObject()
    {
        return Instantiate(prefab);
    }

    void GetObjectFromPool(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    void ReturnObjectToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    [ContextMenu("Spawn")]
    public GameObject Get()
    {
        var obj = pool.Get();
        list.Add(obj);
        return obj;
    }
    [ContextMenu("Despawn")]
    public void Release()
    {
        if (list.Count > 0)
        {
            pool.Release(list[list.Count - 1]);
            list.RemoveAt(list.Count - 1);
        }
    }
    [ContextMenu("DespawnAll")]
    public void ReleaseAll()
    {
        if (list.Count > 0)
        {
            for (int i = list.Count-1; i >= 0; i--)
            {
                pool.Release(list[i]);
                list.RemoveAt(i);
            }
        }
    }

    [ContextMenu("Clear")]
    public void ClearAll()
    {
        pool.Clear();
    }
}
