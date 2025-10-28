

interface IDamagable
{
    void GetDamage(float damage, DamageType dtype = DamageType.Pure);
}

public enum DamageType
{
    Physical,
    Pure,
    Saint,
    Fire,
    Frozen,
    Electro
}

