using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : MonoBehaviour, IActivation
{
    // Start is called before the first frame update
    public Transform playerTransform;
    public float maxDistance;
    private Rigidbody2D rb;
    private ProjectileStats stats;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        maxDistance *= maxDistance;
        stats = GetComponent<ProjectileStats>();
        stats.AddOnDestroy(() => {gameObject.SetActive(false); });
    }

    void Start()
    {
        playerTransform = GameManager.instance.player.transform;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IStats>(out IStats stats))
        {
            stats.TakeDamage(this.stats.GetDamage());
            if (stats is IWeaponStats weaponStats)
            {
                this.stats.TakeDamage(weaponStats.GetDamage());
            } else
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void OnActive(params IStats[] stats)
    {
        this.stats.Initialize(stats[0]);
        rb.velocity = transform.right * this.stats.GetMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distance = playerTransform.position - transform.position;
        if (distance.sqrMagnitude > maxDistance)
        {
            this.gameObject.SetActive(false);
        }
    }
}
