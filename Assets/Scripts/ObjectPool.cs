using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    private class PoolItem
    {
        public string tag;
        public GameObject prefab;
        public int poolSize;
    }

    [SerializeField] private List<PoolItem> poolItems;
    private Dictionary<string, Queue<MyGameObject>> pools = new Dictionary<string, Queue<MyGameObject>>();

    public static ObjectPool instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        foreach(PoolItem item in poolItems)
        {
            Queue<MyGameObject> queue = new Queue<MyGameObject>();
            pools.Add(item.tag, queue);
            for (int i = 0; i < item.poolSize; i++)
            {
                MyGameObject myGameObject = new MyGameObject(Instantiate(item.prefab));
                queue.Enqueue(myGameObject);
            }
        }
    }

    public MyGameObject SpawnObject(string tag)
    {
        Queue<MyGameObject> queue = pools[tag];
        if (queue != null)
        {
            MyGameObject gameObject = queue.Dequeue();
            gameObject.gameObject.SetActive(true);
            queue.Enqueue(gameObject);
            return gameObject;
        }
        return null;
    }
}
