using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.PrefabPoolingService
{
    public sealed class PrefabPoolingService : IPrefabPoolingService
    {
        private IInstantiator instantiator;
        private SpecificPrefabPool.Factory poolsFactory;
        
        private Dictionary<int, SpecificPrefabPool> prefabsToPoolsMap;
        private Dictionary<int, SpecificPrefabPool> objectToPoolMap;

        public PrefabPoolingService(IInstantiator instantiator, SpecificPrefabPool.Factory poolsFactory)
        {
            this.instantiator = instantiator;
            this.poolsFactory = poolsFactory;

            prefabsToPoolsMap = new Dictionary<int, SpecificPrefabPool>();
            objectToPoolMap = new Dictionary<int, SpecificPrefabPool>();
        }

        public GameObject Spawn(GameObject prefab, Transform parent = null)
        {
            SpecificPrefabPool pool = null;
            int prefabInstanceId = prefab.GetInstanceID();
            
            if (!prefabsToPoolsMap.TryGetValue(prefabInstanceId, out pool)) 
                pool = CreateNewPool(prefab);

            GameObject spawnedObject = pool.Spawn(parent);
            objectToPoolMap.Add(spawnedObject.GetInstanceID(), pool);

            return spawnedObject;
        }

        public TComponent Spawn<TComponent>(TComponent prefab, Transform parent = null) where TComponent : MonoBehaviour
        {
            GameObject spawnedObject = Spawn(prefab.gameObject, parent);
            return spawnedObject.GetComponent<TComponent>();
        }

        private SpecificPrefabPool CreateNewPool(GameObject prefab)
        {
            SpecificPrefabPool pool;
            pool = poolsFactory.Create(prefab);
            pool.Initialize();
            prefabsToPoolsMap.Add(prefab.GetInstanceID(), pool);
            return pool;
        }

        public void Despawn(GameObject gameObject)
        {
            int instanceID = gameObject.GetInstanceID();
            if(objectToPoolMap.TryGetValue(instanceID, out SpecificPrefabPool pool))
            {
                objectToPoolMap.Remove(instanceID);
                pool.Despawn(gameObject);
            }
        }

        public void Despawn<TComponent>(TComponent gameObject) where TComponent : MonoBehaviour => 
            Despawn(gameObject.gameObject);
    }
}