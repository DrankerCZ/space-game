using System;
using UnityEngine;

[Serializable]
public class ProjectileStats : MonoBehaviour, IWeaponStats, IStats
{
    public float GetDamage()
    {
        return Damage;
    }

    public float GetHealth()
    {
        return Health;
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }


    public void Initialize(IStats stats)
    {
        ProjectileStats projectileStats = stats as ProjectileStats;
        this.Health = projectileStats.Health;
        this.MaxHealth = projectileStats.MaxHealth;
        this.Damage = projectileStats.Damage;
        this.MoveSpeed = projectileStats.MoveSpeed;
    }

    public void TakeDamage(float damage)
    {
        if ((this.Health -= damage) <= 0)
        {
            _onDestroy();
        }
    }

    public void SetMoveSpeed(float speed)
    {
        this.MoveSpeed = speed;
    }

    public float GetMoveSpeed()
    {
        return MoveSpeed;
    }

    public void AddOnDestroy(Action action)
    {
        this._onDestroy = action;
    }

    public void OnHit()
    {
        _onHit();
    }

    public void AddOnHit(Action action)
    {
        this._onHit += action;
    }

    public void AddOnTakeDamage(Action action)
    {
        throw new NotImplementedException();
    }

    [SerializeField] float Damage;
    [SerializeField] float Health;
    [SerializeField] float MaxHealth;
    [SerializeField] float MoveSpeed;
    private Action _onHit;
    private Action _onDestroy;

    public ProjectileStats(float damage, float health, float maxHealth, float moveSpeed)
    {
        Damage = damage;
        Health = health;
        MaxHealth = maxHealth;
        MoveSpeed = moveSpeed;
    }
}

