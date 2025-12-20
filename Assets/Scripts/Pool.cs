using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T: MonoBehaviour 
{
    private T bulletPrefab;
    private Transform parent;
    private Stack<T> stack = new Stack<T>();

    public Pool(
        T bulletPrefab,
        ref Transform parent,
        int countPrefabs = 5)
    {
        this.bulletPrefab = bulletPrefab;
        this.parent = parent;

        for (int i = 0; i < countPrefabs; i++)
        {
            instantiate();
        }
    }

    public T pop()
    {
        if (stack.Count == 0)
        {
            instantiate();
        }
        
        T obj = stack.Pop();

        obj.transform.position = parent.transform.position;
        obj.transform.rotation = parent.transform.rotation;

        obj.gameObject.SetActive(true);

        return obj;
    }

    public void push(T obj)
    {
        obj.gameObject.SetActive(false);
        stack.Push(obj);
    }

    protected void instantiate()
    {
        T tmp = MonoBehaviour.Instantiate(bulletPrefab, parent.transform.position, parent.transform.rotation);
        tmp.gameObject.SetActive(false);
        stack.Push(tmp);        
    }
}