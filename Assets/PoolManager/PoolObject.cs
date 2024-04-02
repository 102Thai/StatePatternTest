using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class PoolObject : MonoBehaviour
{
    public IObjectPool<GameObject> pool;

    public int maxSize = 10;
    public bool collectionChecks = true;
    public GameObject prefab;

    public LinkedList<GameObject> list;

    public enum PoolType
    {
        stack,
        linkedlist
    }

    public enum DespawnType
    {
        lastObject,
        firstObject
    }
    public PoolType poolType= PoolType.linkedlist;
    public DespawnType despawnType= DespawnType.lastObject;

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
        list = new LinkedList<GameObject>();
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
        list.AddFirst(obj);
        return obj;
    }

    [ContextMenu("Despawn")]
    public void Release()
    {
        if (list.Count > 0)
        {
            if (despawnType == DespawnType.lastObject)
            {
                pool.Release(list.Last.Value);
                list.RemoveLast();
            }
            else
            {
                pool.Release(list.First.Value);
                list.RemoveFirst();
            }
        }
    }

    [ContextMenu("DespawnAll")]
    public void ReleaseAll()
    {
        if (list.Count > 0)
        {
            var count = list.Count;
            if (despawnType == DespawnType.lastObject)
            {
               
                for(int i = count-1; i >=0; i--)
                {
                    pool.Release(list.Last.Value);
                    list.RemoveLast();
                }
            }
            else
            {
                for(int i=0; i<count; i++)
                {
                    pool.Release(list.First.Value);
                    list.RemoveFirst();
                }
            }
        }
    }

    [ContextMenu("Clear")]
    public void ClearAll()
    {
        pool.Clear();
    }
}
