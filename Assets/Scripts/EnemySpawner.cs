using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string EnemyTag;
    [SerializeField] private ShipStats _enemyStats;
    [SerializeField] private ProjectileStats _projectileStats;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            System.Random random = new System.Random();
            if (random.Next(100) > 50)
            {
                EnemyTag = "Enemy";
            }
            else EnemyTag = "EnemyMelee";
            MyGameObject enemy = ObjectPool.instance.SpawnObject(EnemyTag);
            Vector3 position = new Vector2(UnityEngine.Random.value * 20 - 10, UnityEngine.Random.value * 20 - 10);
            position -= GameManager.instance.player.transform.position;
            enemy.gameObject.transform.position = new Vector2(position.x, position.y);
            enemy.activation.OnActive(_enemyStats, _projectileStats);
            yield return new WaitForSeconds(30);
        }
    }
}
