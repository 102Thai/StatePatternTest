using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.PoolObjectTest
{
    public class TestPoolManager : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        [ContextMenu("Spawn")]
        public void Spawn()
        {
            PoolManager.Spawn(prefab);
        }

        [ContextMenu("Despawn")]
        public void Despawn()
        {
            PoolManager.Despawn(prefab);
        }

        public void DespawnAll()
        {
            PoolManager.DespawnAll(prefab);
        }

        public void Clear()
        {
            PoolManager.Clear(prefab);
        }
    }
}
