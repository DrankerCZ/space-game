using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyController : MonoBehaviour, IActivation
{
    private float dt;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GunScript gun;
    [SerializeField] private ShipStats enemyStats;
    [SerializeField] private ProjectileStats projectileStats;

    private Transform target;

    private Coroutine shootCoroutine;

    void Awake()
    {
        dt = Time.fixedDeltaTime;
        enemyStats.SetOnDestroy(() => {
            gameObject.SetActive(false);
            StopCoroutine(shootCoroutine);
        });
    }
    void Start()
    {
        target = GameManager.instance.player.transform;
    }

    public void SetStats(IStats stats)
    {
        enemyStats.Initialize(stats);
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/enemyStats.GetFireRate());
            gun.Shoot();
        }
    }

    void FixedUpdate()
    {
        var pos = transform.position;
        var targetPos = target.position;
        var dir = targetPos - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        rb.rotation = Mathf.LerpAngle(rb.rotation, angle, enemyStats.GetTurnSpeed() * dt);
        var moveDir = this.transform.right;
        rb.velocity = Vector2.Lerp(rb.velocity, moveDir * enemyStats.GetMoveSpeed(), enemyStats.GetMoveAcceleration() * dt);
    }

    public void OnActive(params IStats[] stats)
    {
        this.enemyStats.Initialize(stats[0]);
        this.projectileStats.Initialize(stats[1]);
        shootCoroutine = StartCoroutine(ShootCoroutine());
    }
}
