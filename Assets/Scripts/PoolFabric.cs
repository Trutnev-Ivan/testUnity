using UnityEngine;
using System.Collections.Generic;

public class PoolFabric<T> where T : MonoBehaviour
{
    private static Dictionary<string, Pool<T>> pools = new Dictionary<string, Pool<T>>();
    
    public static Pool<T> GetPool(T prefab, Transform parent, int countPrefabs = 5)
    {
        Pool<T> pool;
        
        if (pools.ContainsKey(prefab.GetType().Name.ToString()))
        {
            pools.TryGetValue(prefab.GetType().Name.ToString(), out pool);

            if (pool != null)
            {
                return pool;
            }
        }

        pool = new Pool<T>(prefab, ref parent, countPrefabs);
        pools.Add(prefab.GetType().Name.ToString(), pool);
        return pool;
    }
}