using System;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] int poolCount = 10;
    private bool isMouseReleased = true;
    private Pool<Bullet> bulletPool;
    
    void Start()
    {
        if (bulletPrefab == null)
        {
            throw new System.ArgumentNullException("bulletPrefab");
        }
        
        bulletPool = PoolFabric<Bullet>.GetPool(bulletPrefab, transform, poolCount);
    }

    
    void Update()
    {
        bool isFire = Convert.ToBoolean(Input.GetAxisRaw("Fire1"));

        if (isFire && isMouseReleased)
        {
            isMouseReleased =  false;
            bulletPool.pop();
        }

        if (!isFire)
        {
            isMouseReleased = true;
        }
    }
}
