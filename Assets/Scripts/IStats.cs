using System;

public interface IStats
{
    void TakeDamage(float damage);
    float GetHealth();
    float GetMaxHealth();
    float GetMoveSpeed();
    void Initialize(IStats stats);
    void SetOnDestroy(Action action);

}
