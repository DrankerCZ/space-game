using System;

public interface IWeaponStats
{
    float GetDamage();
    void OnHit();

    void AddOnHit(Action action);
}
