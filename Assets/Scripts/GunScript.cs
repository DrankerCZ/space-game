using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectileSpawn;
    [SerializeField] LayerMask projectileLayer;
    [SerializeField] string projectileTag;
    private ObjectPool pool;
    private int projectileLayerIndex;

    private ProjectileStats projectileStats;

    private void Start()
    {
        pool = ObjectPool.instance;
        projectileLayerIndex = GameManager.instance.LayerToIndex(projectileLayer);
        projectileStats = GetComponent<ProjectileStats>();
    }
    


    public void Shoot()
    {
        MyGameObject p = pool.SpawnObject(projectileTag);
        p.gameObject.layer = projectileLayerIndex;
        p.gameObject.transform.position = projectileSpawn.position;
        p.gameObject.transform.transform.rotation = projectileSpawn.rotation;
        p.activation.OnActive(projectileStats);
    }
}
