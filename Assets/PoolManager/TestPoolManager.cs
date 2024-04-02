using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.PoolObjectTest
{
    public class TestPoolManager : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        [SerializeField] TestPoolManager prefab1;
        [ContextMenu("Spawn")]
        public void Spawn()
        {
            PoolManager.Spawn(prefab1);
        }

        [ContextMenu("Despawn")]
        public void Despawn()
        {
            PoolManager.Despawn(prefab1);
        }

        public void DespawnAll()
        {
            PoolManager.DespawnAll(prefab1);
        }

        public void Clear()
        {
            PoolManager.Clear(prefab1);
        }
    }
}
