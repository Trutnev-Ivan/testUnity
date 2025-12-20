using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    [SerializeField] private float offset = 2;
    [SerializeField] private int TTL = 5;

    private float timeElapsed = 0;

    void OnEnable()
    {
        transform.Translate(Vector3.forward * offset);
        timeElapsed = 0;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= TTL)
        {
            die();
        }
    }

    void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime * Vector3.forward);
    }

    void OnTriggerEnter(Collider other)
    {
        die();

        if (other.TryGetComponent<Trigger>(out Trigger tmp))
        {
            Statistics.incrementScore();
            Debug.Log("<color=green>Попадание!</color>");
        }
    }

    private void die()
    {
        PoolFabric<Bullet>.GetPool(this, transform).push(this);
    }
}
