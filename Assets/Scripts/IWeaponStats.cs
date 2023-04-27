using System;

public interface IWeaponStats: IStats
{
    float GetDamage();
    void OnHit();

    void SetOnHit(Action action);
}
